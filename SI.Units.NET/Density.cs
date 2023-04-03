using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Density Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Density : IQuantity<Density>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.KilogramPerCubicMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "kg/m³";

        /// <summary> Supported units of measure for Density Quantity type </summary>
        public enum Units
        {
            KilogramPerCubicMeter,
            KilogramPerCubicDecimeter,
            KilogramPerCubicCentimeter,
            KilogramPerCubicMillimeter,

            GramPerCubicMeter,
            GramPerCubicDecimeter,
            GramPerCubicCentimeter,
            GramPerCubicMillimeter,

            PoundPerCubicInch,
            PoundPerCubicFoot,
            PoundPerCubicYard,
            
            OuncePerCubicInch,
            OuncePerCubicFoot,
            OuncePerCubicYard,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                                // KilogramPerCubicMeter
            Math.Pow(Prefixes.Deci.Factor, 3),  // KilogramPerCubicDecimeter
            Math.Pow(Prefixes.Centi.Factor, 3), // KilogramPerCubicCentimeter
            Math.Pow(Prefixes.Milli.Factor, 3), // KilogramPerCubicMillimeter

            1.0e-3, // GramPerCubicMeter
            1.0,    // GramPerCubicDecimeter
            1.0e3,  // GramPerCubicCentimeter
            1.0e6,  // GramPerCubicMillimeter
            
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3) * Math.Pow(12,3),    // PoundPerCubicInch
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3),                     // PoundPerCubicFoot
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3) / Math.Pow(3, 3),    // PoundPerCubicYard
            
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3) * Math.Pow(12,3) / 16.0, // OuncePerCubicInch
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3) / 16.0,                  // OuncePerCubicFoot
            USCustomary.POUND2KILO / Math.Pow(USCustomary.FOOT2METER,3) / Math.Pow(3, 3) / 16.0, // OuncePerCubicYard            
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            "kg/dm³",   // KilogramPerCubicDecimeter
            "kg/cm³",   // KilogramPerCubicCentimeter
            "kg/mm³",   // KilogramPerCubicMillimeter
            "g/m³",     // GramPerCubicMeter
            "g/dm³",    // GramPerCubicDecimeter
            "g/cm³",    // GramPerCubicCentimeter
            "g/mm³",    // GramPerCubicMillimeter
            "lb/in³",   // PoundPerCubicInch
            "lb/ft³",   // PoundPerCubicFoot
            "lb/yd³",   // PoundPerCubicYard            
            "oz/in³",   // OuncePerCubicInch
            "oz/ft³",   // OuncePerCubicFoot
            "oz/yd³",   // OuncePerCubicYard
        };

        /// <summary>
        /// Create new Density object
        /// </summary>
        /// <param name="value">Density value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Density(double value, Units unit)
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
            if ((obj is Density) == false) { return false; }
            
            return Equals((Density)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Density ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Density other)
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
        public Density As(Units target)
        {
            return new Density(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Density other)
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
        public Density Sqrt()
        {
            return new Density(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Cbrt()
        {
            return new Density(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Log()
        {
            return new Density(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Log2()
        {
            return new Density(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Log10()
        {
            return new Density(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Pow(double exp)
        {
            return new Density(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Density Abs()
        {
            return new Density(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Floor()
        {
            return new Density(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Ceiling()
        {
            return new Density(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Truncate()
        {
            return new Density(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Round()
        {
            return new Density(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Density Round(int digits)
        {
            return new Density(Math.Round(Value, digits), Unit);
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
        public static Density Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Density(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Density result)
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
                result = default(Density);
                return false;
            }
        }

        #region OperatorOverloading

        public static Density operator++(Density value)
        {
            return new Density(value.Value + 1, value.Unit);
        }

        public static Density operator--(Density value)
        {
            return new Density(value.Value - 1, value.Unit);
        }

        public static Density operator/(Density value, double scalar)
        {
            return new Density(value.Value / scalar, value.Unit);
        }

        public static Density operator*(Density value, double scalar)
        {
            return new Density(value.Value * scalar, value.Unit);
        }

        public static Density operator*(double scalar, Density value)
        {
            return new Density(value.Value * scalar, value.Unit);
        }

        public static Density operator-(Density a)
        {
            return new Density(-a.Value, a.Unit);
        }

        public static Density operator-(Density a, Density b)
        {
            if (a.Unit == b.Unit)
            {
                return new Density(a.Value - b.Value, a.Unit);
            }

            return new Density(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Density operator+(Density a, Density b)
        {
            if (a.Unit == b.Unit)
            {
                return new Density(a.Value + b.Value, a.Unit);
            }

            return new Density(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Density a, Density b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Density a, Density b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Density a, Density b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Density a, Density b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Density a, Density b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Density a, Density b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Density a, Density b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Density operator%(Density a, double b)
        {
            return new Density(a.Value % b, a.Unit);
        }

        #endregion
    }
}
