using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Energy Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Energy : IQuantity<Energy>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Joule;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "J";

        /// <summary> Supported units of measure for Energy Quantity type </summary>
        public enum Units
        {
            Joule,
            Decijoule,
            Centijoule,
            Millijoule,
            Microjoule,
            Nanojoule,
            Picojoule,
            Femtojoule,
            Decajoule,
            Hectojoule,
            Kilojoule,
            Megajoule,
            Gigajoule,
            Terajoule,
            Petajoule
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Joule
            Prefixes.Deci.Factor,   // Decijoule
            Prefixes.Centi.Factor,  // Centijoule
            Prefixes.Milli.Factor,  // Millijoule
            Prefixes.Micro.Factor,  // Microjoule
            Prefixes.Nano.Factor,   // Nanojoule
            Prefixes.Pico.Factor,   // Picojoule
            Prefixes.Femto.Factor,  // Femtojoule
            Prefixes.Deca.Factor,   // Decajoule
            Prefixes.Hecto.Factor,  // Hectojoule
            Prefixes.Kilo.Factor,   // Kilojoule
            Prefixes.Mega.Factor,   // Megajoule
            Prefixes.Giga.Factor,   // Gigajoule
            Prefixes.Tera.Factor,   // Terajoule
            Prefixes.Peta.Factor,   // Petajoule
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
        /// Create new Energy object
        /// </summary>
        /// <param name="value">Energy value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Energy(double value, Units unit)
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
            if ((obj is Energy) == false) { return false; }
            
            return Equals((Energy)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Energy ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Energy other)
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
        public Energy As(Units target)
        {
            return new Energy(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Energy other)
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
        public Energy Sqrt()
        {
            return new Energy(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Cbrt()
        {
            return new Energy(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Log()
        {
            return new Energy(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Log2()
        {
            return new Energy(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Log10()
        {
            return new Energy(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Pow(double exp)
        {
            return new Energy(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Energy Abs()
        {
            return new Energy(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Floor()
        {
            return new Energy(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Ceiling()
        {
            return new Energy(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Truncate()
        {
            return new Energy(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Round()
        {
            return new Energy(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Energy Round(int digits)
        {
            return new Energy(Math.Round(Value, digits), Unit);
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
        public static Energy Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Energy(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Energy result)
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
                result = default(Energy);
                return false;
            }
        }

        #region OperatorOverloading

        public static Energy operator++(Energy value)
        {
            return new Energy(value.Value + 1, value.Unit);
        }

        public static Energy operator--(Energy value)
        {
            return new Energy(value.Value - 1, value.Unit);
        }

        public static Energy operator/(Energy value, double scalar)
        {
            return new Energy(value.Value / scalar, value.Unit);
        }

        public static Energy operator*(Energy value, double scalar)
        {
            return new Energy(value.Value * scalar, value.Unit);
        }

        public static Energy operator*(double scalar, Energy value)
        {
            return new Energy(value.Value * scalar, value.Unit);
        }

        public static Energy operator-(Energy a)
        {
            return new Energy(-a.Value, a.Unit);
        }

        public static Energy operator-(Energy a, Energy b)
        {
            if (a.Unit == b.Unit)
            {
                return new Energy(a.Value - b.Value, a.Unit);
            }

            return new Energy(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Energy operator+(Energy a, Energy b)
        {
            if (a.Unit == b.Unit)
            {
                return new Energy(a.Value + b.Value, a.Unit);
            }

            return new Energy(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Energy a, Energy b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Energy a, Energy b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Energy a, Energy b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Energy a, Energy b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Energy a, Energy b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Energy a, Energy b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Energy a, Energy b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Energy operator%(Energy a, double b)
        {
            return new Energy(a.Value % b, a.Unit);
        }

        #endregion
    }
}
