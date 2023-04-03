using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents AngularVelocity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct AngularVelocity : IQuantity<AngularVelocity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.RadianPerSecond;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "rad/s";

        /// <summary> Supported units of measure for AngularVelocity Quantity type </summary>
        public enum Units
        {
            RadianPerSecond,
            RadianPerMinute,
            RadianPerHour,
            
            DegreePerSecond,
            DegreePerMinute,
            DegreePerHour,

            DeciradianPerSecond,
            DeciradianPerMinute,
            DeciradianPerHour,

            CentiradianPerSecond,
            CentiradianPerMinute,
            CentiradianPerHour,

            MilliradianPerSecond,
            MilliradianPerMinute,
            MilliradianPerHour,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // RadianPerSecond,
            1.0 / Time.MinuteValue, // RadianPerMinute,
            1.0 / Time.HourValue,   // RadianPerHour,
            
            Angle.DEG2RAD,                              // DegreePerSecond,
            Angle.DEG2RAD / Time.MinuteValue,           // DegreePerMinute,
            Angle.DEG2RAD / Time.HourValue,             // DegreePerHour,

            Prefixes.Deci.Factor,                      // DeciradianPerSecond,
            Prefixes.Deci.Factor / Time.MinuteValue,   // DeciradianPerMinute,
            Prefixes.Deci.Factor / Time.HourValue,     // DeciradianPerHour,

            Prefixes.Centi.Factor,                      // CentiradianPerSecond,
            Prefixes.Centi.Factor / Time.MinuteValue,   // CentiradianPerMinute,
            Prefixes.Centi.Factor / Time.HourValue,     // CentiradianPerHour,

            Prefixes.Milli.Factor,                      // MilliradianPerSecond,
            Prefixes.Milli.Factor / Time.MinuteValue,   // MilliradianPerMinute,
            Prefixes.Milli.Factor / Time.HourValue,     // MilliradianPerHour,
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            "rad/min",  // RadianPerMinute,
            "rad/hr",   // RadianPerHour,
            
            "°/s",      // DegreePerSecond,
            "°/min",    // DegreePerMinute,
            "°/hr",     // DegreePerHour,

            "drad/s",   // DeciradianPerSecond,
            "drad/min", // DeciradianPerMinute,
            "drad/hr",  // DeciradianPerHour,

            "crad/s",   // CentiradianPerSecond,
            "crad/min", // CentiradianPerMinute,
            "crad/hr",  // CentiradianPerHour,

            "mrad/s",   // MilliradianPerSecond,
            "mrad/min", // MilliradianPerMinute,
            "mrad/hr",  // MilliradianPerHour,
        };

        /// <summary>
        /// Create new AngularVelocity object
        /// </summary>
        /// <param name="value">AngularVelocity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public AngularVelocity(double value, Units unit)
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
            if ((obj is AngularVelocity) == false) { return false; }
            
            return Equals((AngularVelocity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public AngularVelocity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(AngularVelocity other)
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
        public AngularVelocity As(Units target)
        {
            return new AngularVelocity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(AngularVelocity other)
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
        public AngularVelocity Sqrt()
        {
            return new AngularVelocity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Cbrt()
        {
            return new AngularVelocity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Log()
        {
            return new AngularVelocity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Log2()
        {
            return new AngularVelocity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Log10()
        {
            return new AngularVelocity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Pow(double exp)
        {
            return new AngularVelocity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Abs()
        {
            return new AngularVelocity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Floor()
        {
            return new AngularVelocity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Ceiling()
        {
            return new AngularVelocity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Truncate()
        {
            return new AngularVelocity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Round()
        {
            return new AngularVelocity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularVelocity Round(int digits)
        {
            return new AngularVelocity(Math.Round(Value, digits), Unit);
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
        public static AngularVelocity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new AngularVelocity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out AngularVelocity result)
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
                result = default(AngularVelocity);
                return false;
            }
        }

        #region OperatorOverloading

        public static AngularVelocity operator++(AngularVelocity value)
        {
            return new AngularVelocity(value.Value + 1, value.Unit);
        }

        public static AngularVelocity operator--(AngularVelocity value)
        {
            return new AngularVelocity(value.Value - 1, value.Unit);
        }

        public static AngularVelocity operator/(AngularVelocity value, double scalar)
        {
            return new AngularVelocity(value.Value / scalar, value.Unit);
        }

        public static AngularVelocity operator*(AngularVelocity value, double scalar)
        {
            return new AngularVelocity(value.Value * scalar, value.Unit);
        }

        public static AngularVelocity operator*(double scalar, AngularVelocity value)
        {
            return new AngularVelocity(value.Value * scalar, value.Unit);
        }

        public static AngularVelocity operator-(AngularVelocity a)
        {
            return new AngularVelocity(-a.Value, a.Unit);
        }

        public static AngularVelocity operator-(AngularVelocity a, AngularVelocity b)
        {
            if (a.Unit == b.Unit)
            {
                return new AngularVelocity(a.Value - b.Value, a.Unit);
            }

            return new AngularVelocity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static AngularVelocity operator+(AngularVelocity a, AngularVelocity b)
        {
            if (a.Unit == b.Unit)
            {
                return new AngularVelocity(a.Value + b.Value, a.Unit);
            }

            return new AngularVelocity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(AngularVelocity a, AngularVelocity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(AngularVelocity a, AngularVelocity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(AngularVelocity a, AngularVelocity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(AngularVelocity a, AngularVelocity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(AngularVelocity a, AngularVelocity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(AngularVelocity a, AngularVelocity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(AngularVelocity a, AngularVelocity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static AngularVelocity operator%(AngularVelocity a, double b)
        {
            return new AngularVelocity(a.Value % b, a.Unit);
        }

        public static Angle operator*(AngularVelocity velocity, Time time)
        {
            return new Angle(velocity.BaseValue() * time.BaseValue(), Angle.BaseUnit);
        }

        public static Angle operator*(Time time, AngularVelocity velocity)
        {
            return new Angle(velocity.BaseValue() * time.BaseValue(), Angle.BaseUnit);
        }

        #endregion
    }
}
