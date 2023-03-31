using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Force Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Force : IQuantity<Force>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Newton;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "N";

        /// <summary> Supported units of measure for Force Quantity type </summary>
        public enum Units
        {
            Newton,
            Decinewton,
            Centinewton,
            Millinewton,
            Micronewton,
            Nanonewton,
            Piconewton,
            Femtonewton,
            Decanewton,
            Hectonewton,
            Kilonewton,
            Meganewton,
            Giganewton,
            Teranewton,
            Petanewton
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Newton
            Prefixes.Deci.Factor,   // Decinewton
            Prefixes.Centi.Factor,  // Centinewton
            Prefixes.Milli.Factor,  // Millinewton
            Prefixes.Micro.Factor,  // Micronewton
            Prefixes.Nano.Factor,   // Nanonewton
            Prefixes.Pico.Factor,   // Piconewton
            Prefixes.Femto.Factor,  // Femtonewton
            Prefixes.Deca.Factor,   // Decanewton
            Prefixes.Hecto.Factor,  // Hectonewton
            Prefixes.Kilo.Factor,   // Kilonewton
            Prefixes.Mega.Factor,   // Meganewton
            Prefixes.Giga.Factor,   // Giganewton
            Prefixes.Tera.Factor,   // Teranewton
            Prefixes.Peta.Factor,   // Petanewton
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
            Prefixes.Peta.Symbol    + BaseSymbol
        };

        /// <summary>
        /// Create new Force object
        /// </summary>
        /// <param name="value">Force value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Force(double value, Units unit)
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
            if ((obj is Force) == false) { return false; }
            
            return Equals((Force)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Force ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Force other)
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
        public Force As(Units target)
        {
            return new Force(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Force other)
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
        public Force Sqrt()
        {
            return new Force(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Cbrt()
        {
            return new Force(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Log()
        {
            return new Force(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Log2()
        {
            return new Force(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Log10()
        {
            return new Force(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Pow(double exp)
        {
            return new Force(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Force Abs()
        {
            return new Force(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Floor()
        {
            return new Force(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Ceiling()
        {
            return new Force(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Truncate()
        {
            return new Force(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Round()
        {
            return new Force(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Force Round(int digits)
        {
            return new Force(Math.Round(Value, digits), Unit);
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
        public static Force Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Force(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Force result)
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
                result = default(Force);
                return false;
            }
        }

        #region OperatorOverloading

        public static Force operator++(Force value)
        {
            return new Force(value.Value + 1, value.Unit);
        }

        public static Force operator--(Force value)
        {
            return new Force(value.Value - 1, value.Unit);
        }

        public static Force operator/(Force value, double scalar)
        {
            return new Force(value.Value / scalar, value.Unit);
        }

        public static Force operator*(Force value, double scalar)
        {
            return new Force(value.Value * scalar, value.Unit);
        }

        public static Force operator*(double scalar, Force value)
        {
            return new Force(value.Value * scalar, value.Unit);
        }

        public static Force operator-(Force a)
        {
            return new Force(-a.Value, a.Unit);
        }

        public static Force operator-(Force a, Force b)
        {
            if (a.Unit == b.Unit)
            {
                return new Force(a.Value - b.Value, a.Unit);
            }

            return new Force(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Force operator+(Force a, Force b)
        {
            if (a.Unit == b.Unit)
            {
                return new Force(a.Value + b.Value, a.Unit);
            }

            return new Force(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Force a, Force b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Force a, Force b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Force a, Force b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Force a, Force b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Force a, Force b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Force a, Force b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Force a, Force b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Force operator%(Force a, double b)
        {
            return new Force(a.Value % b, a.Unit);
        }

        #endregion
    }
}
