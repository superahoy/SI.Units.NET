using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Pressure Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Pressure : IQuantity<Pressure>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Pascal;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "Pa";

        /// <summary> Supported units of measure for Pressure Quantity type </summary>
        public enum Units
        {
            Pascal,
            Decipascal,
            Centipascal,
            Millipascal,
            Micropascal,
            Nanopascal,
            Picopascal,
            Femtopascal,
            Decapascal,
            Hectopascal,
            Kilopascal,
            Megapascal,
            Gigapascal,
            Terapascal,
            Petapascal,
            Bar,
            Millibar,
            InchesMercury,
            MillimetersMercury,
            PoundsPerSquareInch,
            [Description("Average air pressure at sea level at a temperature of 15 degrees Celsius")]
            Atmosphere 
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Pascal
            Prefixes.Deci.Factor,   // Decipascal
            Prefixes.Centi.Factor,  // Centipascal
            Prefixes.Milli.Factor,  // Millipascal
            Prefixes.Micro.Factor,  // Micropascal
            Prefixes.Nano.Factor,   // Nanopascal
            Prefixes.Pico.Factor,   // Picopascal
            Prefixes.Femto.Factor,  // Femtopascal
            Prefixes.Deca.Factor,   // Decapascal
            Prefixes.Hecto.Factor,  // Hectopascal
            Prefixes.Kilo.Factor,   // Kilopascal
            Prefixes.Mega.Factor,   // Megapascal
            Prefixes.Giga.Factor,   // Gigapascal
            Prefixes.Tera.Factor,   // Terapascal
            Prefixes.Peta.Factor,   // Petapascal
            100000,                 // Bar
            100,                    // Millibar
            3386.38866666667,       // InchesMercury
            133.322387415,          // MillimetersMercury
            6894.7572931783,        // PoundsPerSquareInch
            101325.0                // Atmosphere
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
            Prefixes.Pico.Symbol    + BaseSymbol,
            Prefixes.Femto.Symbol   + BaseSymbol,
            Prefixes.Deca.Symbol    + BaseSymbol,
            Prefixes.Hecto.Symbol   + BaseSymbol,
            Prefixes.Kilo.Symbol    + BaseSymbol,
            Prefixes.Mega.Symbol    + BaseSymbol,
            Prefixes.Giga.Symbol    + BaseSymbol,
            Prefixes.Tera.Symbol    + BaseSymbol,
            Prefixes.Peta.Symbol    + BaseSymbol,
            "bar",  // Bar
            "mbar", // Millibar
            "inHg", // InchesMercury
            "mmHg", // MillimetersMercury
            "psi",  // PoundsPerSquareInch
            "atm"   // Atmosphere
        };

        /// <summary>
        /// Create new Pressure object
        /// </summary>
        /// <param name="value">Pressure value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Pressure(double value, Units unit)
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
            if ((obj is Pressure) == false) { return false; }
            
            return Equals((Pressure)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Pressure ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Pressure other)
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
        public Pressure As(Units target)
        {
            return new Pressure(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Pressure other)
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
        public Pressure Sqrt()
        {
            return new Pressure(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Cbrt()
        {
            return new Pressure(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Log()
        {
            return new Pressure(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Log2()
        {
            return new Pressure(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Log10()
        {
            return new Pressure(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Pow(double exp)
        {
            return new Pressure(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Pressure Abs()
        {
            return new Pressure(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Floor()
        {
            return new Pressure(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Ceiling()
        {
            return new Pressure(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Truncate()
        {
            return new Pressure(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Round()
        {
            return new Pressure(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Pressure Round(int digits)
        {
            return new Pressure(Math.Round(Value, digits), Unit);
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
        public static Pressure Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Pressure(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Pressure result)
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
                result = default(Pressure);
                return false;
            }
        }

        #region OperatorOverloading

        public static Pressure operator++(Pressure value)
        {
            return new Pressure(value.Value + 1, value.Unit);
        }

        public static Pressure operator--(Pressure value)
        {
            return new Pressure(value.Value - 1, value.Unit);
        }

        public static Pressure operator/(Pressure value, double scalar)
        {
            return new Pressure(value.Value / scalar, value.Unit);
        }

        public static Pressure operator*(Pressure value, double scalar)
        {
            return new Pressure(value.Value * scalar, value.Unit);
        }

        public static Pressure operator*(double scalar, Pressure value)
        {
            return new Pressure(value.Value * scalar, value.Unit);
        }

        public static Pressure operator-(Pressure a)
        {
            return new Pressure(-a.Value, a.Unit);
        }

        public static Pressure operator-(Pressure a, Pressure b)
        {
            if (a.Unit == b.Unit)
            {
                return new Pressure(a.Value - b.Value, a.Unit);
            }

            return new Pressure(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Pressure operator+(Pressure a, Pressure b)
        {
            if (a.Unit == b.Unit)
            {
                return new Pressure(a.Value + b.Value, a.Unit);
            }

            return new Pressure(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Pressure a, Pressure b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Pressure a, Pressure b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Pressure a, Pressure b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Pressure a, Pressure b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Pressure a, Pressure b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Pressure a, Pressure b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Pressure a, Pressure b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Pressure operator%(Pressure a, double b)
        {
            return new Pressure(a.Value % b, a.Unit);
        }

        #endregion
    }
}
