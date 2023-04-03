using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Area Base Quantity type from 
    /// Table 5. Examples of coherent derived units in the SI expressed in terms of base units
    /// </summary>
    public readonly struct Area : IQuantity<Area>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.SquareMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m²";

        /// <summary> Area, Hectare from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string HectareSymbol = "ha";

        /// <summary> Supported units of measure for Area Quantity type </summary>
        public enum Units
        {
            SquareMeter,
            SquareDecimeter,
            SquareCentimeter,
            SquareMillimeter,
            SquareMicrometer,
            SquareNanometer,
            SquareDecameter,
            SquareHectometer,
            SquareKilometer,
            SquareMegameter,
            SquareGigameter,
            Hectare,
            SquareInch,
            SquareFoot,
            SquareYard,
            SquareMile,
            Acre
        };

        private const double SqFt2SqM = USCustomary.FOOT2METER * USCustomary.FOOT2METER;

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                                // SquareMeter
            Math.Pow(Prefixes.Deci.Factor,2),   // SquareDecimeter
            Math.Pow(Prefixes.Centi.Factor,2),  // SquareCentimeter
            Math.Pow(Prefixes.Milli.Factor,2),  // SquareMillimeter
            Math.Pow(Prefixes.Micro.Factor,2),  // SquareMicrometer
            Math.Pow(Prefixes.Nano.Factor,2),   // SquareNanometer
            Math.Pow(Prefixes.Deca.Factor,2),   // SquareDecameter
            Math.Pow(Prefixes.Hecto.Factor,2),  // SquareHectometer
            Math.Pow(Prefixes.Kilo.Factor,2),   // SquareKilometer
            Math.Pow(Prefixes.Mega.Factor,2),   // SquareMegameter
            Math.Pow(Prefixes.Giga.Factor,2),   // SquareGigameter
            1.0e4,                              // Hectare,
            SqFt2SqM / 144.0,                   // SquareInch
            SqFt2SqM,                           // SquareFoot
            SqFt2SqM * 9.0,                     // SquareYard
            SqFt2SqM * 5280.0 * 5280,           // SquareMile
            SqFt2SqM * 43560                    // Acre
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            Prefixes.Deci.Symbol    + BaseSymbol,
            Prefixes.Centi.Symbol   + BaseSymbol,
            Prefixes.Milli.Symbol   + BaseSymbol,
            Prefixes.Micro.Symbol   + BaseSymbol,
            Prefixes.Nano.Symbol    + BaseSymbol,
            Prefixes.Deca.Symbol    + BaseSymbol,
            Prefixes.Hecto.Symbol   + BaseSymbol,
            Prefixes.Kilo.Symbol    + BaseSymbol,
            Prefixes.Mega.Symbol    + BaseSymbol,
            Prefixes.Giga.Symbol    + BaseSymbol,
            HectareSymbol,  // Hectare
            "in²",  // SquareInch
            "ft²",  // SquareFoot,
            "yd²",  // SquareYard
            "mi²",  // SquareMile,
            "ac",   // Acre
        };

        /// <summary>
        /// Create new Area object
        /// </summary>
        /// <param name="value">Area value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Area(double value, Units unit)
        {
            Value   = value; 
            Unit    = unit;
        }

        /// <inheritdoc/>
        public double Value { get; init; }

        /// <summary>
        /// Unit of Measure value is in
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Units Unit { get; init; }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return BaseValue().GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if ((obj is Area) == false) { return false; }
            
            return Equals((Area)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Area ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Area other)
        {
            if (Math.Abs(BaseValue() - other.BaseValue()) > 1.0e-14)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Convert Quantity to target unit of measure
        /// </summary>
        /// <param name="target">Target unit of measure</param>
        /// <returns>Quantity converted to target unit of measure</returns>
        public Area As(Units target)
        {
            return new Area(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Area other)
        {
            return BaseValue().CompareTo(other.BaseValue());
        }

        /// <inheritdoc/>
        public string ToString(string? format)
        {
            return ToString(format, null);
        }

        /// <inheritdoc/>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            return $"{Value.ToString(format, formatProvider)} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public Area Sqrt()
        {
            return new Area(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Cbrt()
        {
            return new Area(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Log()
        {
            return new Area(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Log2()
        {
            return new Area(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Log10()
        {
            return new Area(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Pow(double exp)
        {
            return new Area(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Area Abs()
        {
            return new Area(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Floor()
        {
            return new Area(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Ceiling()
        {
            return new Area(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Truncate()
        {
            return new Area(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Round()
        {
            return new Area(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Area Round(int digits)
        {
            return new Area(Math.Round(Value, digits), Unit);
        }

        /// <inheritdoc/>
        public bool IsNegativeInfinity()
        {
            return Double.IsNegativeInfinity(Value);
        }

        /// <inheritdoc/>
        public bool IsPositiveInfinity()
        {
            return Double.IsPositiveInfinity(Value);
        }

        /// <inheritdoc/>
        public bool IsNaN()
        {
            return Double.IsNaN(Value);
        }

        /// <inheritdoc/>
        public bool IsInfinity()
        {
            return Double.IsInfinity(Value);
        }

        /// <inheritdoc/>
        public int Sign()
        {
            return Math.Sign(Value);
        }

        /// <inheritdoc/>
        public static Area Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Area(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Area result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = default;
                return false;
            }

            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch
            {
                result = default(Area);
                return false;
            }
        }

        #region OperatorOverloading

        public static Area operator++(Area value)
        {
            return new Area(value.Value + 1, value.Unit);
        }

        public static Area operator--(Area value)
        {
            return new Area(value.Value - 1, value.Unit);
        }

        public static Area operator/(Area value, double scalar)
        {
            return new Area(value.Value / scalar, value.Unit);
        }

        public static Area operator*(Area value, double scalar)
        {
            return new Area(value.Value * scalar, value.Unit);
        }

        public static Area operator*(double scalar, Area value)
        {
            return new Area(value.Value * scalar, value.Unit);
        }

        public static Area operator-(Area a)
        {
            return new Area(-a.Value, a.Unit);
        }

        public static Area operator-(Area a, Area b)
        {
            if (a.Unit == b.Unit)
            {
                return new Area(a.Value - b.Value, a.Unit);
            }

            return new Area(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Area operator+(Area a, Area b)
        {
            if (a.Unit == b.Unit)
            {
                return new Area(a.Value + b.Value, a.Unit);
            }

            return new Area(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Area a, Area b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Area a, Area b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Area a, Area b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Area a, Area b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Area a, Area b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Area a, Area b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Area a, Area b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Area operator%(Area a, double b)
        {
            return new Area(a.Value % b, a.Unit);
        }

        #endregion
    }
}
