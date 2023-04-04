using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents CurrentDensity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct CurrentDensity : IQuantity<CurrentDensity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.AmperePerSquareMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "A/m²";

        /// <summary> Supported units of measure for CurrentDensity Quantity type </summary>
        public enum Units
        {
            AmperePerSquareMeter,
            AmperePerSquareDecimeter,
            AmperePerSquareCentimeter,
            AmperePerSquareMillimeter,
            AmperePerSquareMicrometer,

            DeciamperePerSquareMeter,
            DeciamperePerSquareDecimeter,
            DeciamperePerSquareCentimeter,
            DeciamperePerSquareMillimeter,
            DeciamperePerSquareMicrometer,

            CentiamperePerSquareMeter,
            CentiamperePerSquareDecimeter,
            CentiamperePerSquareCentimeter,
            CentiamperePerSquareMillimeter,
            CentiamperePerSquareMicrometer,

            MilliamperePerSquareMeter,
            MilliamperePerSquareDecimeter,
            MilliamperePerSquareCentimeter,
            MilliamperePerSquareMillimeter,
            MilliamperePerSquareMicrometer,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,    // AmperePerSquareMeter,
            1.0e2,  // AmperePerSquareDecimeter,
            1.0e4,  // AmperePerSquareCentimeter,
            1.0e6,  // AmperePerSquareMillimeter,
            1.0e12, // AmperePerSquareMicrometer,

            0.1,    // DeciamperePerSquareMeter,
            1.0e1,  // DeciamperePerSquareDecimeter,
            1.0e3,  // DeciamperePerSquareCentimeter,
            1.0e5,  // DeciamperePerSquareMillimeter,
            1.0e11, // DeciamperePerSquareMicrometer,

            1.0e-2,     // CentiamperePerSquareMeter,
            1.0,        // CentiamperePerSquareDecimeter,
            1.0e+2,     // CentiamperePerSquareCentimeter,
            1.0e+4,     // CentiamperePerSquareMillimeter,
            1.0e+10,    // CentiamperePerSquareMicrometer,

            1.0e-3, // MilliamperePerSquareMeter,
            1.0e-1, // MilliamperePerSquareDecimeter,
            1.0e+1, // MilliamperePerSquareCentimeter,
            1.0e+3, // MilliamperePerSquareMillimeter,
            1.0e+9, // MilliamperePerSquareMicrometer,
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            "A/dm²",    // AmperePerSquareDecimeter,
            "A/cm²",    // AmperePerSquareCentimeter,
            "A/mm²",    // AmperePerSquareMillimeter,
            "A/μm²",    // AmperePerSquareMicrometer,

            "dA/m²",    // DeciamperePerSquareMeter,
            "dA/dm²",   // DeciamperePerSquareDecimeter,
            "dA/cm²",   // DeciamperePerSquareCentimeter,
            "dA/mm²",   // DeciamperePerSquareMillimeter,
            "dA/μm²",   // DeciamperePerSquareMicrometer,

            "cA/m²",    // CentiamperePerSquareMeter,
            "cA/dm²",   // CentiamperePerSquareDecimeter,
            "cA/cm²",   // CentiamperePerSquareCentimeter,
            "cA/mm²",   // CentiamperePerSquareMillimeter,
            "cA/μm²",   // CentiamperePerSquareMicrometer,

            "mA/m²",    // MilliamperePerSquareMeter,
            "mA/dm²",   // MilliamperePerSquareDecimeter,
            "mA/cm²",   // MilliamperePerSquareCentimeter,
            "mA/mm²",   // MilliamperePerSquareMillimeter,
            "mA/μm²",   // MilliamperePerSquareMicrometer,
        };

        /// <summary>
        /// Create new CurrentDensity object
        /// </summary>
        /// <param name="value">CurrentDensity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public CurrentDensity(double value, Units unit)
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
            if ((obj is CurrentDensity) == false) { return false; }
            
            return Equals((CurrentDensity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public CurrentDensity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(CurrentDensity other)
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
        public CurrentDensity As(Units target)
        {
            return new CurrentDensity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(CurrentDensity other)
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
        public CurrentDensity Sqrt()
        {
            return new CurrentDensity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Cbrt()
        {
            return new CurrentDensity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Log()
        {
            return new CurrentDensity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Log2()
        {
            return new CurrentDensity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Log10()
        {
            return new CurrentDensity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Pow(double exp)
        {
            return new CurrentDensity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Abs()
        {
            return new CurrentDensity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Floor()
        {
            return new CurrentDensity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Ceiling()
        {
            return new CurrentDensity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Truncate()
        {
            return new CurrentDensity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Round()
        {
            return new CurrentDensity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public CurrentDensity Round(int digits)
        {
            return new CurrentDensity(Math.Round(Value, digits), Unit);
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
        public static CurrentDensity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new CurrentDensity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out CurrentDensity result)
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
                result = default(CurrentDensity);
                return false;
            }
        }

        #region OperatorOverloading

        public static CurrentDensity operator++(CurrentDensity value)
        {
            return new CurrentDensity(value.Value + 1, value.Unit);
        }

        public static CurrentDensity operator--(CurrentDensity value)
        {
            return new CurrentDensity(value.Value - 1, value.Unit);
        }

        public static CurrentDensity operator/(CurrentDensity value, double scalar)
        {
            return new CurrentDensity(value.Value / scalar, value.Unit);
        }

        public static CurrentDensity operator*(CurrentDensity value, double scalar)
        {
            return new CurrentDensity(value.Value * scalar, value.Unit);
        }

        public static CurrentDensity operator*(double scalar, CurrentDensity value)
        {
            return new CurrentDensity(value.Value * scalar, value.Unit);
        }

        public static CurrentDensity operator-(CurrentDensity a)
        {
            return new CurrentDensity(-a.Value, a.Unit);
        }

        public static CurrentDensity operator-(CurrentDensity a, CurrentDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new CurrentDensity(a.Value - b.Value, a.Unit);
            }

            return new CurrentDensity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static CurrentDensity operator+(CurrentDensity a, CurrentDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new CurrentDensity(a.Value + b.Value, a.Unit);
            }

            return new CurrentDensity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(CurrentDensity a, CurrentDensity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(CurrentDensity a, CurrentDensity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(CurrentDensity a, CurrentDensity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(CurrentDensity a, CurrentDensity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(CurrentDensity a, CurrentDensity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(CurrentDensity a, CurrentDensity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(CurrentDensity a, CurrentDensity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static CurrentDensity operator%(CurrentDensity a, double b)
        {
            return new CurrentDensity(a.Value % b, a.Unit);
        }

        #endregion
    }
}
