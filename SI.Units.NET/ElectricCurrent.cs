using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ElectricCurrent Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ElectricCurrent : IQuantity<ElectricCurrent>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Ampere;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "A";

        /// <summary> Supported units of measure for ElectricCurrent Quantity type </summary>
        public enum Units
        {
            Ampere,
            Deciampere,
            Centiampere,
            Milliampere,
            Microampere,
            Nanoampere,
            Picoampere,
            Femtoampere,
            Decaampere,
            Hectoampere,
            Kiloampere,
            Megaampere,
            Gigaampere,
            Teraampere,
            Petaampere
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Ampere
            Prefixes.Deci.Factor,   // Deciampere
            Prefixes.Centi.Factor,  // Centiampere
            Prefixes.Milli.Factor,  // Milliampere
            Prefixes.Micro.Factor,  // Microampere
            Prefixes.Nano.Factor,   // Nanoampere
            Prefixes.Pico.Factor,   // Picoampere
            Prefixes.Femto.Factor,  // Femtoampere
            Prefixes.Deca.Factor,   // Decaampere
            Prefixes.Hecto.Factor,  // Hectoampere
            Prefixes.Kilo.Factor,   // Kiloampere
            Prefixes.Mega.Factor,   // Megaampere
            Prefixes.Giga.Factor,   // Gigaampere
            Prefixes.Tera.Factor,   // Teraampere
            Prefixes.Peta.Factor,   // Petaampere
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
        /// Create new ElectricCurrent object
        /// </summary>
        /// <param name="value">ElectricCurrent value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ElectricCurrent(double value, Units unit)
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
            if ((obj is ElectricCurrent) == false) { return false; }
            
            return Equals((ElectricCurrent)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ElectricCurrent ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ElectricCurrent other)
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
        public ElectricCurrent As(Units target)
        {
            return new ElectricCurrent(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ElectricCurrent other)
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
        public ElectricCurrent Sqrt()
        {
            return new ElectricCurrent(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Cbrt()
        {
            return new ElectricCurrent(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Log()
        {
            return new ElectricCurrent(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Log2()
        {
            return new ElectricCurrent(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Log10()
        {
            return new ElectricCurrent(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Pow(double exp)
        {
            return new ElectricCurrent(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Abs()
        {
            return new ElectricCurrent(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Floor()
        {
            return new ElectricCurrent(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Ceiling()
        {
            return new ElectricCurrent(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Truncate()
        {
            return new ElectricCurrent(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Round()
        {
            return new ElectricCurrent(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCurrent Round(int digits)
        {
            return new ElectricCurrent(Math.Round(Value, digits), Unit);
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
        public static ElectricCurrent Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ElectricCurrent(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ElectricCurrent result)
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
                result = default(ElectricCurrent);
                return false;
            }
        }

        #region OperatorOverloading

        public static ElectricCurrent operator++(ElectricCurrent value)
        {
            return new ElectricCurrent(value.Value + 1, value.Unit);
        }

        public static ElectricCurrent operator--(ElectricCurrent value)
        {
            return new ElectricCurrent(value.Value - 1, value.Unit);
        }

        public static ElectricCurrent operator/(ElectricCurrent value, double scalar)
        {
            return new ElectricCurrent(value.Value / scalar, value.Unit);
        }

        public static ElectricCurrent operator*(ElectricCurrent value, double scalar)
        {
            return new ElectricCurrent(value.Value * scalar, value.Unit);
        }

        public static ElectricCurrent operator*(double scalar, ElectricCurrent value)
        {
            return new ElectricCurrent(value.Value * scalar, value.Unit);
        }

        public static ElectricCurrent operator-(ElectricCurrent a)
        {
            return new ElectricCurrent(-a.Value, a.Unit);
        }

        public static ElectricCurrent operator-(ElectricCurrent a, ElectricCurrent b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricCurrent(a.Value - b.Value, a.Unit);
            }

            return new ElectricCurrent(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ElectricCurrent operator+(ElectricCurrent a, ElectricCurrent b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricCurrent(a.Value + b.Value, a.Unit);
            }

            return new ElectricCurrent(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ElectricCurrent a, ElectricCurrent b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ElectricCurrent a, ElectricCurrent b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ElectricCurrent a, ElectricCurrent b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ElectricCurrent a, ElectricCurrent b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ElectricCurrent a, ElectricCurrent b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ElectricCurrent a, ElectricCurrent b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ElectricCurrent a, ElectricCurrent b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ElectricCurrent operator%(ElectricCurrent a, double b)
        {
            return new ElectricCurrent(a.Value % b, a.Unit);
        }

        #endregion
    }
}
