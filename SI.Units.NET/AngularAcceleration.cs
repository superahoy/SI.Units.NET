using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents AngularAcceleration Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct AngularAcceleration : IQuantity<AngularAcceleration>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.RadianPerSecondSquared;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "rad/s²";

        /// <summary> Supported units of measure for AngularAcceleration Quantity type </summary>
        public enum Units
        {
            RadianPerSecondSquared,
            DegreePerSecondSquared,
            DeciradianPerSecondSquared,
            CentiradianPerSecondSquared,
            MilliradianPerSecondSquared
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // RadianPerSecondSquared,
            Angle.DEG2RAD,          // DegreePerSecondSquared,
            Prefixes.Deci.Factor,   // DeciradianPerSecondSquared,
            Prefixes.Centi.Factor,  // CentiradianPerSecondSquared,
            Prefixes.Milli.Factor,  // MilliradianPerSecondSquared
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // RadianPerSecondSquared
            "°/s²",     // DegreePerSecondSquared,
            "drad/s²",  // DeciradianPerSecondSquared,
            "crad/s²",  // CentiradianPerSecondSquared,
            "mrad/s²",  // MilliradianPerSecondSquared
        };

        /// <summary>
        /// Create new AngularAcceleration object
        /// </summary>
        /// <param name="value">AngularAcceleration value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public AngularAcceleration(double value, Units unit)
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
            if ((obj is AngularAcceleration) == false) { return false; }
            
            return Equals((AngularAcceleration)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public AngularAcceleration ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(AngularAcceleration other)
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
        public AngularAcceleration As(Units target)
        {
            return new AngularAcceleration(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(AngularAcceleration other)
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
        public AngularAcceleration Sqrt()
        {
            return new AngularAcceleration(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Cbrt()
        {
            return new AngularAcceleration(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Log()
        {
            return new AngularAcceleration(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Log2()
        {
            return new AngularAcceleration(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Log10()
        {
            return new AngularAcceleration(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Pow(double exp)
        {
            return new AngularAcceleration(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Abs()
        {
            return new AngularAcceleration(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Floor()
        {
            return new AngularAcceleration(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Ceiling()
        {
            return new AngularAcceleration(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Truncate()
        {
            return new AngularAcceleration(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Round()
        {
            return new AngularAcceleration(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public AngularAcceleration Round(int digits)
        {
            return new AngularAcceleration(Math.Round(Value, digits), Unit);
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
        public static AngularAcceleration Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new AngularAcceleration(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out AngularAcceleration result)
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
                result = default(AngularAcceleration);
                return false;
            }
        }

        #region OperatorOverloading

        public static AngularAcceleration operator++(AngularAcceleration value)
        {
            return new AngularAcceleration(value.Value + 1, value.Unit);
        }

        public static AngularAcceleration operator--(AngularAcceleration value)
        {
            return new AngularAcceleration(value.Value - 1, value.Unit);
        }

        public static AngularAcceleration operator/(AngularAcceleration value, double scalar)
        {
            return new AngularAcceleration(value.Value / scalar, value.Unit);
        }

        public static AngularAcceleration operator*(AngularAcceleration value, double scalar)
        {
            return new AngularAcceleration(value.Value * scalar, value.Unit);
        }

        public static AngularAcceleration operator*(double scalar, AngularAcceleration value)
        {
            return new AngularAcceleration(value.Value * scalar, value.Unit);
        }

        public static AngularAcceleration operator-(AngularAcceleration a)
        {
            return new AngularAcceleration(-a.Value, a.Unit);
        }

        public static AngularAcceleration operator-(AngularAcceleration a, AngularAcceleration b)
        {
            if (a.Unit == b.Unit)
            {
                return new AngularAcceleration(a.Value - b.Value, a.Unit);
            }

            return new AngularAcceleration(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static AngularAcceleration operator+(AngularAcceleration a, AngularAcceleration b)
        {
            if (a.Unit == b.Unit)
            {
                return new AngularAcceleration(a.Value + b.Value, a.Unit);
            }

            return new AngularAcceleration(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(AngularAcceleration a, AngularAcceleration b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(AngularAcceleration a, AngularAcceleration b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(AngularAcceleration a, AngularAcceleration b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(AngularAcceleration a, AngularAcceleration b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(AngularAcceleration a, AngularAcceleration b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(AngularAcceleration a, AngularAcceleration b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(AngularAcceleration a, AngularAcceleration b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static AngularAcceleration operator%(AngularAcceleration a, double b)
        {
            return new AngularAcceleration(a.Value % b, a.Unit);
        }

        public static AngularVelocity operator*(AngularAcceleration acceleration, Time time) 
        { 
            return new AngularVelocity(acceleration.BaseValue() * time.BaseValue(), AngularVelocity.BaseUnit);
        }

        public static AngularVelocity operator*(Time time, AngularAcceleration acceleration) 
        { 
            return new AngularVelocity(acceleration.BaseValue() * time.BaseValue(), AngularVelocity.BaseUnit);
        }

        #endregion
    }
}
