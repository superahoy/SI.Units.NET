using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents TemperatureDelta Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct TemperatureDifference : IQuantity<TemperatureDifference>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.DegreeCelsius;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "ΔT °C";

        /// <summary> Supported units of measure for TemperatureDelta Quantity type </summary>
        public enum Units
        {
            DegreeCelsius,
            DegreeFahrenheit            
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,    // DegreeCelsius
            5.0/9.0 // DegreeFahrenheit
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            "ΔT °F"
        };

        /// <summary>
        /// Create new TemperatureDelta object
        /// </summary>
        /// <param name="value">TemperatureDelta value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public TemperatureDifference(double value, Units unit)
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
            if ((obj is TemperatureDifference) == false) { return false; }
            
            return Equals((TemperatureDifference)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public TemperatureDifference ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(TemperatureDifference other)
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
        public TemperatureDifference As(Units target)
        {
            return new TemperatureDifference(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(TemperatureDifference other)
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
        public TemperatureDifference Sqrt()
        {
            return new TemperatureDifference(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Cbrt()
        {
            return new TemperatureDifference(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Log()
        {
            return new TemperatureDifference(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Log2()
        {
            return new TemperatureDifference(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Log10()
        {
            return new TemperatureDifference(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Pow(double exp)
        {
            return new TemperatureDifference(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Abs()
        {
            return new TemperatureDifference(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Floor()
        {
            return new TemperatureDifference(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Ceiling()
        {
            return new TemperatureDifference(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Truncate()
        {
            return new TemperatureDifference(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Round()
        {
            return new TemperatureDifference(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public TemperatureDifference Round(int digits)
        {
            return new TemperatureDifference(Math.Round(Value, digits), Unit);
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
        public static TemperatureDifference Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new TemperatureDifference(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TemperatureDifference result)
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
                result = default(TemperatureDifference);
                return false;
            }
        }

        #region OperatorOverloading

        public static TemperatureDifference operator++(TemperatureDifference value)
        {
            return new TemperatureDifference(value.Value + 1, value.Unit);
        }

        public static TemperatureDifference operator--(TemperatureDifference value)
        {
            return new TemperatureDifference(value.Value - 1, value.Unit);
        }

        public static TemperatureDifference operator/(TemperatureDifference value, double scalar)
        {
            return new TemperatureDifference(value.Value / scalar, value.Unit);
        }

        public static TemperatureDifference operator*(TemperatureDifference value, double scalar)
        {
            return new TemperatureDifference(value.Value * scalar, value.Unit);
        }

        public static TemperatureDifference operator*(double scalar, TemperatureDifference value)
        {
            return new TemperatureDifference(value.Value * scalar, value.Unit);
        }

        public static TemperatureDifference operator-(TemperatureDifference a)
        {
            return new TemperatureDifference(-a.Value, a.Unit);
        }

        public static TemperatureDifference operator-(TemperatureDifference a, TemperatureDifference b)
        {
            if (a.Unit == b.Unit)
            {
                return new TemperatureDifference(a.Value - b.Value, a.Unit);
            }

            return new TemperatureDifference(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static TemperatureDifference operator+(TemperatureDifference a, TemperatureDifference b)
        {
            if (a.Unit == b.Unit)
            {
                return new TemperatureDifference(a.Value + b.Value, a.Unit);
            }

            return new TemperatureDifference(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(TemperatureDifference a, TemperatureDifference b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(TemperatureDifference a, TemperatureDifference b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(TemperatureDifference a, TemperatureDifference b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(TemperatureDifference a, TemperatureDifference b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(TemperatureDifference a, TemperatureDifference b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(TemperatureDifference a, TemperatureDifference b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(TemperatureDifference a, TemperatureDifference b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static TemperatureDifference operator%(TemperatureDifference a, double b)
        {
            return new TemperatureDifference(a.Value % b, a.Unit);
        }

        #endregion
    }
}
