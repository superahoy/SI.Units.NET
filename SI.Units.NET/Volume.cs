using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Volume Base Quantity type from 
    /// Table 5. Examples of coherent derived units in the SI expressed in terms of base units
    /// </summary>
    public readonly struct Volume : IQuantity<Volume>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.CubicMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m³";

        /// <summary> Volume, Litre, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string LiterSymbol = "L";

        /// <summary> Supported units of measure for Volume Quantity type </summary>
        public enum Units
        {
            CubicMeter,
            CubicDecimeter,
            CubicCentimeter,
            CubicMillimeter,
            CubicDecameter,
            CubicHectometer,
            CubicKilometer,
            CubicInch,
            CubicFoot,
            CubicYard,
            CubicMile,
            Liter,
            Deciliter,
            Centiliter,
            Milliliter,
            Gallon,
            Quart,
            Pint,
            Cup,
            FluidOunce
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                                        // CubicMeter
            Math.Pow(Prefixes.Deci.Factor,3),           // CubicDecimeter
            Math.Pow(Prefixes.Centi.Factor,3),          // CubicCentimeter
            Math.Pow(Prefixes.Milli.Factor,3),          // CubicMillimeter
            Math.Pow(Prefixes.Deca.Factor,3),           // CubicDecameter
            Math.Pow(Prefixes.Hecto.Factor,3),          // CubicHectometer
            Math.Pow(Prefixes.Kilo.Factor,3),           // CubicKilometer
            USCustomary.CUBICFOOT2CUBICMETER / 1728.0,  // CubicInch
            USCustomary.CUBICFOOT2CUBICMETER,           // CubicFoot
            USCustomary.CUBICFOOT2CUBICMETER * 27.0,    // CubicYard
            USCustomary.CUBICFOOT2CUBICMETER * 5280 * 5280 * 5280,  // CubicMile
            1.0e-3,                         // Liter
            1.0e-4,                         // Deciliter
            1.0e-5,                         // Centiliter
            1.0e-6,                         // Milliliter
            USCustomary.Gallon.Factor,      // Gallon
            USCustomary.Quart.Factor,       // Quart
            USCustomary.Pint.Factor,        // Pint
            USCustomary.Cup.Factor,         // Cup
            USCustomary.FluidOnce.Factor    // Fluid Ounce
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
            Prefixes.Deca.Symbol    + BaseSymbol,
            Prefixes.Hecto.Symbol   + BaseSymbol,
            Prefixes.Kilo.Symbol    + BaseSymbol,
            "in³",  // CubicInch
            "ft³",  // CubicFoot,
            "yd³",  // CubicYard
            "mi³",  // CubicMile,
            LiterSymbol,                            // Liter,
            Prefixes.Deci.Symbol  + LiterSymbol,    // Deciliter,
            Prefixes.Centi.Symbol + LiterSymbol,    // Centiliter,
            Prefixes.Milli.Symbol + LiterSymbol,    // Milliliter,
            USCustomary.Gallon.Symbol,              // Gallon
            USCustomary.Quart.Symbol,               // Quart
            USCustomary.Pint.Symbol,                // Pint
            USCustomary.Cup.Symbol,                 // Cup
            USCustomary.FluidOnce.Symbol            // Fluid Ounce
        };

        /// <summary>
        /// Create new Volume object
        /// </summary>
        /// <param name="value">Volume value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Volume(double value, Units unit)
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
            if ((obj is Volume) == false) { return false; }
            
            return Equals((Volume)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Volume ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Volume other)
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
        public Volume As(Units target)
        {
            return new Volume(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Volume other)
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
        public Volume Sqrt()
        {
            return new Volume(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Cbrt()
        {
            return new Volume(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Log()
        {
            return new Volume(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Log2()
        {
            return new Volume(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Log10()
        {
            return new Volume(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Pow(double exp)
        {
            return new Volume(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Volume Abs()
        {
            return new Volume(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Floor()
        {
            return new Volume(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Ceiling()
        {
            return new Volume(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Truncate()
        {
            return new Volume(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Round()
        {
            return new Volume(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Volume Round(int digits)
        {
            return new Volume(Math.Round(Value, digits), Unit);
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
        public static Volume Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Volume(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Volume result)
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
                result = default(Volume);
                return false;
            }
        }

        #region OperatorOverloading

        public static Volume operator++(Volume value)
        {
            return new Volume(value.Value + 1, value.Unit);
        }

        public static Volume operator--(Volume value)
        {
            return new Volume(value.Value - 1, value.Unit);
        }

        public static Volume operator/(Volume value, double scalar)
        {
            return new Volume(value.Value / scalar, value.Unit);
        }

        public static Volume operator*(Volume value, double scalar)
        {
            return new Volume(value.Value * scalar, value.Unit);
        }

        public static Volume operator*(double scalar, Volume value)
        {
            return new Volume(value.Value * scalar, value.Unit);
        }

        public static Volume operator-(Volume a)
        {
            return new Volume(-a.Value, a.Unit);
        }

        public static Volume operator-(Volume a, Volume b)
        {
            if (a.Unit == b.Unit)
            {
                return new Volume(a.Value - b.Value, a.Unit);
            }

            return new Volume(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Volume operator+(Volume a, Volume b)
        {
            if (a.Unit == b.Unit)
            {
                return new Volume(a.Value + b.Value, a.Unit);
            }

            return new Volume(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Volume a, Volume b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Volume a, Volume b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Volume a, Volume b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Volume a, Volume b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Volume a, Volume b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Volume a, Volume b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Volume a, Volume b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Volume operator%(Volume a, double b)
        {
            return new Volume(a.Value % b, a.Unit);
        }

        #endregion
    }
}
