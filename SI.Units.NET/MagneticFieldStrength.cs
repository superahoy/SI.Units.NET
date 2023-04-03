using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents MagneticFieldStrength from:
    /// Table 5. Examples of coherent derived units in the SI expressed in terms of base units
    /// </summary>
    public readonly struct MagneticFieldStrength : IQuantity<MagneticFieldStrength>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.AmperePerMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "A/m";

        /// <summary> Supported units of measure for MagneticFieldStrength Quantity type </summary>
        public enum Units
        {
            AmperePerMeter,
            AmperePerDecimeter,
            AmperePerCentimeter,
            AmperePerMillimeter,
            AmperePerMicrometer,
            AmperePerNanometer,

            MilliamperePerMeter,
            MilliamperePerDecimeter,
            MilliamperePerCentimeter,
            MilliamperePerMillimeter,
            MilliamperePerMicrometer,
            MilliamperePerNanometer,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // AmperePerMeter
            Prefixes.Deci.Factor,   // AmperePerDecimeter
            Prefixes.Centi.Factor,  // AmperePerCentimeter
            Prefixes.Milli.Factor,  // AmperePerMillimeter
            Prefixes.Micro.Factor,  // AmperePerMicrometer
            Prefixes.Nano.Factor,   // AmperePerNanometer
            
            1.0e-3, // MilliamperePerMeter
            1.0e-2, // MilliamperePerDecimeter
            1.0e-1, // MilliamperePerCentimeter
            1.0,    // MilliamperePerMillimeter
            1.0e3,  // MilliamperePerMicrometer
            1.0e6,  // MilliamperePerNanometer
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // AmperePerMeter
            "A/dm",     // AmperePerDecimeter,
            "A/cm",     // AmperePerCentimeter,
            "A/mm",     // AmperePerMillimeter,
            "A/μm",     // AmperePerMicrometer,
            "A/nm",     // AmperePerNanometer,

            "mA/m",     // MilliamperePerMeter,
            "mA/dm",    // MilliamperePerDecimeter,
            "mA/cm",    // MilliamperePerCentimeter,
            "mA/mm",    // MilliamperePerMillimeter,
            "mA/μm",    // MilliamperePerMicrometer,
            "mA/nm",    // MilliamperePerNanometer,
        };

        /// <summary>
        /// Create new MagneticFieldStrength object
        /// </summary>
        /// <param name="value">MagneticFieldStrength value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public MagneticFieldStrength(double value, Units unit)
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
            if ((obj is MagneticFieldStrength) == false) { return false; }
            
            return Equals((MagneticFieldStrength)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public MagneticFieldStrength ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(MagneticFieldStrength other)
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
        public MagneticFieldStrength As(Units target)
        {
            return new MagneticFieldStrength(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(MagneticFieldStrength other)
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
        public MagneticFieldStrength Sqrt()
        {
            return new MagneticFieldStrength(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Cbrt()
        {
            return new MagneticFieldStrength(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Log()
        {
            return new MagneticFieldStrength(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Log2()
        {
            return new MagneticFieldStrength(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Log10()
        {
            return new MagneticFieldStrength(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Pow(double exp)
        {
            return new MagneticFieldStrength(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Abs()
        {
            return new MagneticFieldStrength(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Floor()
        {
            return new MagneticFieldStrength(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Ceiling()
        {
            return new MagneticFieldStrength(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Truncate()
        {
            return new MagneticFieldStrength(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Round()
        {
            return new MagneticFieldStrength(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFieldStrength Round(int digits)
        {
            return new MagneticFieldStrength(Math.Round(Value, digits), Unit);
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
        public static MagneticFieldStrength Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new MagneticFieldStrength(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MagneticFieldStrength result)
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
                result = default(MagneticFieldStrength);
                return false;
            }
        }

        #region OperatorOverloading

        public static MagneticFieldStrength operator++(MagneticFieldStrength value)
        {
            return new MagneticFieldStrength(value.Value + 1, value.Unit);
        }

        public static MagneticFieldStrength operator--(MagneticFieldStrength value)
        {
            return new MagneticFieldStrength(value.Value - 1, value.Unit);
        }

        public static MagneticFieldStrength operator/(MagneticFieldStrength value, double scalar)
        {
            return new MagneticFieldStrength(value.Value / scalar, value.Unit);
        }

        public static MagneticFieldStrength operator*(MagneticFieldStrength value, double scalar)
        {
            return new MagneticFieldStrength(value.Value * scalar, value.Unit);
        }

        public static MagneticFieldStrength operator*(double scalar, MagneticFieldStrength value)
        {
            return new MagneticFieldStrength(value.Value * scalar, value.Unit);
        }

        public static MagneticFieldStrength operator-(MagneticFieldStrength a)
        {
            return new MagneticFieldStrength(-a.Value, a.Unit);
        }

        public static MagneticFieldStrength operator-(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFieldStrength(a.Value - b.Value, a.Unit);
            }

            return new MagneticFieldStrength(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static MagneticFieldStrength operator+(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFieldStrength(a.Value + b.Value, a.Unit);
            }

            return new MagneticFieldStrength(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(MagneticFieldStrength a, MagneticFieldStrength b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static MagneticFieldStrength operator%(MagneticFieldStrength a, double b)
        {
            return new MagneticFieldStrength(a.Value % b, a.Unit);
        }

        #endregion
    }
}
