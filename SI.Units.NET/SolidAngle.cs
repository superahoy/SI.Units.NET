using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents SolidAngle from Table 4. The 22 SI units with special names and symbols
    /// </summary>
    public readonly struct SolidAngle : IQuantity<SolidAngle>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Steradian;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "sr";

        /// <summary> Supported units of measure for SolidAngle Quantity type </summary>
        public enum Units
        {
            Steradian,
            Decisteradian,
            Centisteradian,
            Millisteradian,
            Microsteradian
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Steradian
            Prefixes.Deci.Factor,   // Decisteradian
            Prefixes.Centi.Factor,  // Centisteradian
            Prefixes.Milli.Factor,  // Millisteradian
            Prefixes.Micro.Factor,  // Microsteradian
            
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
        };

        /// <summary>
        /// Create new SolidAngle object
        /// </summary>
        /// <param name="value">SolidAngle value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public SolidAngle(double value, Units unit)
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
            if ((obj is SolidAngle) == false) { return false; }
            
            return Equals((SolidAngle)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public SolidAngle ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(SolidAngle other)
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
        public SolidAngle As(Units target)
        {
            return new SolidAngle(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(SolidAngle other)
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
        public SolidAngle Sqrt()
        {
            return new SolidAngle(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Cbrt()
        {
            return new SolidAngle(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Log()
        {
            return new SolidAngle(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Log2()
        {
            return new SolidAngle(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Log10()
        {
            return new SolidAngle(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Pow(double exp)
        {
            return new SolidAngle(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Abs()
        {
            return new SolidAngle(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Floor()
        {
            return new SolidAngle(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Ceiling()
        {
            return new SolidAngle(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Truncate()
        {
            return new SolidAngle(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Round()
        {
            return new SolidAngle(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public SolidAngle Round(int digits)
        {
            return new SolidAngle(Math.Round(Value, digits), Unit);
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
        public static SolidAngle Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new SolidAngle(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out SolidAngle result)
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
                result = default(SolidAngle);
                return false;
            }
        }

        #region OperatorOverloading

        public static SolidAngle operator++(SolidAngle value)
        {
            return new SolidAngle(value.Value + 1, value.Unit);
        }

        public static SolidAngle operator--(SolidAngle value)
        {
            return new SolidAngle(value.Value - 1, value.Unit);
        }

        public static SolidAngle operator/(SolidAngle value, double scalar)
        {
            return new SolidAngle(value.Value / scalar, value.Unit);
        }

        public static SolidAngle operator*(SolidAngle value, double scalar)
        {
            return new SolidAngle(value.Value * scalar, value.Unit);
        }

        public static SolidAngle operator*(double scalar, SolidAngle value)
        {
            return new SolidAngle(value.Value * scalar, value.Unit);
        }

        public static SolidAngle operator-(SolidAngle a)
        {
            return new SolidAngle(-a.Value, a.Unit);
        }

        public static SolidAngle operator-(SolidAngle a, SolidAngle b)
        {
            if (a.Unit == b.Unit)
            {
                return new SolidAngle(a.Value - b.Value, a.Unit);
            }

            return new SolidAngle(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static SolidAngle operator+(SolidAngle a, SolidAngle b)
        {
            if (a.Unit == b.Unit)
            {
                return new SolidAngle(a.Value + b.Value, a.Unit);
            }

            return new SolidAngle(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(SolidAngle a, SolidAngle b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(SolidAngle a, SolidAngle b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(SolidAngle a, SolidAngle b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(SolidAngle a, SolidAngle b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(SolidAngle a, SolidAngle b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(SolidAngle a, SolidAngle b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(SolidAngle a, SolidAngle b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static SolidAngle operator%(SolidAngle a, double b)
        {
            return new SolidAngle(a.Value % b, a.Unit);
        }

        #endregion
    }
}
