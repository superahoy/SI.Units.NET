using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ElectricResistance Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ElectricResistance : IQuantity<ElectricResistance>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Ohm;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "Ω";

        /// <summary> Supported units of measure for ElectricResistance Quantity type </summary>
        public enum Units
        {
            Ohm,
            Deciohm,
            Centiohm,
            Milliohm,
            Microohm,
            Nanoohm,
            Picoohm,
            Femtoohm,
            Decaohm,
            Hectoohm,
            Kiloohm,
            Megaohm,
            Gigaohm,
            Teraohm,
            Petaohm
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Ohm
            Prefixes.Deci.Factor,   // Deciohm
            Prefixes.Centi.Factor,  // Centiohm
            Prefixes.Milli.Factor,  // Milliohm
            Prefixes.Micro.Factor,  // Microohm
            Prefixes.Nano.Factor,   // Nanoohm
            Prefixes.Pico.Factor,   // Picoohm
            Prefixes.Femto.Factor,  // Femtoohm
            Prefixes.Deca.Factor,   // Decaohm
            Prefixes.Hecto.Factor,  // Hectoohm
            Prefixes.Kilo.Factor,   // Kiloohm
            Prefixes.Mega.Factor,   // Megaohm
            Prefixes.Giga.Factor,   // Gigaohm
            Prefixes.Tera.Factor,   // Teraohm
            Prefixes.Peta.Factor,   // Petaohm
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
        /// Create new ElectricResistance object
        /// </summary>
        /// <param name="value">ElectricResistance value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ElectricResistance(double value, Units unit)
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
            if ((obj is ElectricResistance) == false) { return false; }
            
            return Equals((ElectricResistance)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ElectricResistance ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ElectricResistance other)
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
        public ElectricResistance As(Units target)
        {
            return new ElectricResistance(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ElectricResistance other)
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
        public ElectricResistance Sqrt()
        {
            return new ElectricResistance(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Cbrt()
        {
            return new ElectricResistance(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Log()
        {
            return new ElectricResistance(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Log2()
        {
            return new ElectricResistance(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Log10()
        {
            return new ElectricResistance(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Pow(double exp)
        {
            return new ElectricResistance(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Abs()
        {
            return new ElectricResistance(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Floor()
        {
            return new ElectricResistance(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Ceiling()
        {
            return new ElectricResistance(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Truncate()
        {
            return new ElectricResistance(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Round()
        {
            return new ElectricResistance(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricResistance Round(int digits)
        {
            return new ElectricResistance(Math.Round(Value, digits), Unit);
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
        public static ElectricResistance Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ElectricResistance(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ElectricResistance result)
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
                result = default(ElectricResistance);
                return false;
            }
        }

        #region OperatorOverloading

        public static ElectricResistance operator++(ElectricResistance value)
        {
            return new ElectricResistance(value.Value + 1, value.Unit);
        }

        public static ElectricResistance operator--(ElectricResistance value)
        {
            return new ElectricResistance(value.Value - 1, value.Unit);
        }

        public static ElectricResistance operator/(ElectricResistance value, double scalar)
        {
            return new ElectricResistance(value.Value / scalar, value.Unit);
        }

        public static ElectricResistance operator*(ElectricResistance value, double scalar)
        {
            return new ElectricResistance(value.Value * scalar, value.Unit);
        }

        public static ElectricResistance operator*(double scalar, ElectricResistance value)
        {
            return new ElectricResistance(value.Value * scalar, value.Unit);
        }

        public static ElectricResistance operator-(ElectricResistance a)
        {
            return new ElectricResistance(-a.Value, a.Unit);
        }

        public static ElectricResistance operator-(ElectricResistance a, ElectricResistance b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricResistance(a.Value - b.Value, a.Unit);
            }

            return new ElectricResistance(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ElectricResistance operator+(ElectricResistance a, ElectricResistance b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricResistance(a.Value + b.Value, a.Unit);
            }

            return new ElectricResistance(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ElectricResistance a, ElectricResistance b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ElectricResistance a, ElectricResistance b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ElectricResistance a, ElectricResistance b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ElectricResistance a, ElectricResistance b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ElectricResistance a, ElectricResistance b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ElectricResistance a, ElectricResistance b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ElectricResistance a, ElectricResistance b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ElectricResistance operator%(ElectricResistance a, double b)
        {
            return new ElectricResistance(a.Value % b, a.Unit);
        }

        #endregion
    }
}
