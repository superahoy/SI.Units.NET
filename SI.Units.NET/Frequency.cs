using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Frequency Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Frequency : IQuantity<Frequency>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Hertz;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "Hz";

        /// <summary> Supported units of measure for Frequency Quantity type </summary>
        public enum Units
        {
            Hertz,
            Decihertz,
            Centihertz,
            Millihertz,
            Microhertz,
            Nanohertz,
            Picohertz,
            Femtohertz,
            Decahertz,
            Hectohertz,
            Kilohertz,
            Megahertz,
            Gigahertz,
            Terahertz,
            Petahertz
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Hertz
            Prefixes.Deci.Factor,   // Decihertz
            Prefixes.Centi.Factor,  // Centihertz
            Prefixes.Milli.Factor,  // Millihertz
            Prefixes.Micro.Factor,  // Microhertz
            Prefixes.Nano.Factor,   // Nanohertz
            Prefixes.Pico.Factor,   // Picohertz
            Prefixes.Femto.Factor,  // Femtohertz
            Prefixes.Deca.Factor,   // Decahertz
            Prefixes.Hecto.Factor,  // Hectohertz
            Prefixes.Kilo.Factor,   // Kilohertz
            Prefixes.Mega.Factor,   // Megahertz
            Prefixes.Giga.Factor,   // Gigahertz
            Prefixes.Tera.Factor,   // Terahertz
            Prefixes.Peta.Factor,   // Petahertz
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
        /// Create new Frequency object
        /// </summary>
        /// <param name="value">Frequency value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Frequency(double value, Units unit)
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
            if ((obj is Frequency) == false) { return false; }
            
            return Equals((Frequency)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Frequency ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Frequency other)
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
        public Frequency As(Units target)
        {
            return new Frequency(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Frequency other)
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
        public Frequency Sqrt()
        {
            return new Frequency(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Cbrt()
        {
            return new Frequency(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Log()
        {
            return new Frequency(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Log2()
        {
            return new Frequency(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Log10()
        {
            return new Frequency(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Pow(double exp)
        {
            return new Frequency(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Frequency Abs()
        {
            return new Frequency(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Floor()
        {
            return new Frequency(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Ceiling()
        {
            return new Frequency(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Truncate()
        {
            return new Frequency(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Round()
        {
            return new Frequency(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Frequency Round(int digits)
        {
            return new Frequency(Math.Round(Value, digits), Unit);
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
        public static Frequency Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Frequency(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Frequency result)
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
                result = default(Frequency);
                return false;
            }
        }

        #region OperatorOverloading

        public static Frequency operator++(Frequency value)
        {
            return new Frequency(value.Value + 1, value.Unit);
        }

        public static Frequency operator--(Frequency value)
        {
            return new Frequency(value.Value - 1, value.Unit);
        }

        public static Frequency operator/(Frequency value, double scalar)
        {
            return new Frequency(value.Value / scalar, value.Unit);
        }

        public static Frequency operator*(Frequency value, double scalar)
        {
            return new Frequency(value.Value * scalar, value.Unit);
        }

        public static Frequency operator*(double scalar, Frequency value)
        {
            return new Frequency(value.Value * scalar, value.Unit);
        }

        public static Frequency operator-(Frequency a)
        {
            return new Frequency(-a.Value, a.Unit);
        }

        public static Frequency operator-(Frequency a, Frequency b)
        {
            if (a.Unit == b.Unit)
            {
                return new Frequency(a.Value - b.Value, a.Unit);
            }

            return new Frequency(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Frequency operator+(Frequency a, Frequency b)
        {
            if (a.Unit == b.Unit)
            {
                return new Frequency(a.Value + b.Value, a.Unit);
            }

            return new Frequency(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Frequency a, Frequency b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Frequency a, Frequency b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Frequency a, Frequency b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Frequency a, Frequency b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Frequency a, Frequency b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Frequency a, Frequency b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Frequency a, Frequency b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Frequency operator%(Frequency a, double b)
        {
            return new Frequency(a.Value % b, a.Unit);
        }

        #endregion
    }
}
