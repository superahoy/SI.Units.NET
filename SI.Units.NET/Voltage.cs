using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Voltage Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Voltage : IQuantity<Voltage>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Volt;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "V";

        /// <summary> Supported units of measure for Voltage Quantity type </summary>
        public enum Units
        {
            Volt,
            Decivolt,
            Centivolt,
            Millivolt,
            Microvolt,
            Nanovolt,
            Picovolt,
            Femtovolt,
            Decavolt,
            Hectovolt,
            Kilovolt,
            Megavolt,
            Gigavolt,
            Teravolt,
            Petavolt
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Volt
            Prefixes.Deci.Factor,   // Decivolt
            Prefixes.Centi.Factor,  // Centivolt
            Prefixes.Milli.Factor,  // Millivolt
            Prefixes.Micro.Factor,  // Microvolt
            Prefixes.Nano.Factor,   // Nanovolt
            Prefixes.Pico.Factor,   // Picovolt
            Prefixes.Femto.Factor,  // Femtovolt
            Prefixes.Deca.Factor,   // Decavolt
            Prefixes.Hecto.Factor,  // Hectovolt
            Prefixes.Kilo.Factor,   // Kilovolt
            Prefixes.Mega.Factor,   // Megavolt
            Prefixes.Giga.Factor,   // Gigavolt
            Prefixes.Tera.Factor,   // Teravolt
            Prefixes.Peta.Factor,   // Petavolt
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
        /// Create new Voltage object
        /// </summary>
        /// <param name="value">Voltage value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Voltage(double value, Units unit)
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
            if ((obj is Voltage) == false) { return false; }
            
            return Equals((Voltage)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Voltage ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Voltage other)
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
        public Voltage As(Units target)
        {
            return new Voltage(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Voltage other)
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
        public Voltage Sqrt()
        {
            return new Voltage(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Cbrt()
        {
            return new Voltage(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Log()
        {
            return new Voltage(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Log2()
        {
            return new Voltage(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Log10()
        {
            return new Voltage(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Pow(double exp)
        {
            return new Voltage(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Voltage Abs()
        {
            return new Voltage(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Floor()
        {
            return new Voltage(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Ceiling()
        {
            return new Voltage(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Truncate()
        {
            return new Voltage(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Round()
        {
            return new Voltage(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Voltage Round(int digits)
        {
            return new Voltage(Math.Round(Value, digits), Unit);
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
        public static Voltage Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Voltage(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Voltage result)
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
                result = default(Voltage);
                return false;
            }
        }

        #region OperatorOverloading

        public static Voltage operator++(Voltage value)
        {
            return new Voltage(value.Value + 1, value.Unit);
        }

        public static Voltage operator--(Voltage value)
        {
            return new Voltage(value.Value - 1, value.Unit);
        }

        public static Voltage operator/(Voltage value, double scalar)
        {
            return new Voltage(value.Value / scalar, value.Unit);
        }

        public static Voltage operator*(Voltage value, double scalar)
        {
            return new Voltage(value.Value * scalar, value.Unit);
        }

        public static Voltage operator*(double scalar, Voltage value)
        {
            return new Voltage(value.Value * scalar, value.Unit);
        }

        public static Voltage operator-(Voltage a)
        {
            return new Voltage(-a.Value, a.Unit);
        }

        public static Voltage operator-(Voltage a, Voltage b)
        {
            if (a.Unit == b.Unit)
            {
                return new Voltage(a.Value - b.Value, a.Unit);
            }

            return new Voltage(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Voltage operator+(Voltage a, Voltage b)
        {
            if (a.Unit == b.Unit)
            {
                return new Voltage(a.Value + b.Value, a.Unit);
            }

            return new Voltage(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Voltage a, Voltage b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Voltage a, Voltage b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Voltage a, Voltage b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Voltage a, Voltage b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Voltage a, Voltage b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Voltage a, Voltage b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Voltage a, Voltage b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Voltage operator%(Voltage a, double b)
        {
            return new Voltage(a.Value % b, a.Unit);
        }

        #endregion
    }
}
