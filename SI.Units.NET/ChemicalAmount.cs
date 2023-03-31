using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ChemicalAmount Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ChemicalAmount : IQuantity<ChemicalAmount>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Mole;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "mol";

        /// <summary> Supported units of measure for ChemicalAmount Quantity type </summary>
        public enum Units
        {
            Mole,
            Decimole,
            Centimole,
            Millimole,
            Micromole,
            Nanomole,
            Picomole,
            Femtomole,
            Decamole,
            Hectomole,
            Kilomole,
            Megamole,
            Gigamole,
            Teramole,
            Petamole
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Mole
            Prefixes.Deci.Factor,   // Decimole
            Prefixes.Centi.Factor,  // Centimole
            Prefixes.Milli.Factor,  // Millimole
            Prefixes.Micro.Factor,  // Micromole
            Prefixes.Nano.Factor,   // Nanomole
            Prefixes.Pico.Factor,   // Picomole
            Prefixes.Femto.Factor,  // Femtomole
            Prefixes.Deca.Factor,   // Decamole
            Prefixes.Hecto.Factor,  // Hectomole
            Prefixes.Kilo.Factor,   // Kilomole
            Prefixes.Mega.Factor,   // Megamole
            Prefixes.Giga.Factor,   // Gigamole
            Prefixes.Tera.Factor,   // Teramole
            Prefixes.Peta.Factor,   // Petamole
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
        /// Create new ChemicalAmount object
        /// </summary>
        /// <param name="value">ChemicalAmount value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ChemicalAmount(double value, Units unit)
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
            if ((obj is ChemicalAmount) == false) { return false; }
            
            return Equals((ChemicalAmount)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ChemicalAmount ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ChemicalAmount other)
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
        public ChemicalAmount As(Units target)
        {
            return new ChemicalAmount(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ChemicalAmount other)
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
        public ChemicalAmount Sqrt()
        {
            return new ChemicalAmount(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Cbrt()
        {
            return new ChemicalAmount(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Log()
        {
            return new ChemicalAmount(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Log2()
        {
            return new ChemicalAmount(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Log10()
        {
            return new ChemicalAmount(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Pow(double exp)
        {
            return new ChemicalAmount(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Abs()
        {
            return new ChemicalAmount(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Floor()
        {
            return new ChemicalAmount(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Ceiling()
        {
            return new ChemicalAmount(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Truncate()
        {
            return new ChemicalAmount(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Round()
        {
            return new ChemicalAmount(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmount Round(int digits)
        {
            return new ChemicalAmount(Math.Round(Value, digits), Unit);
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
        public static ChemicalAmount Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ChemicalAmount(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ChemicalAmount result)
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
                result = default(ChemicalAmount);
                return false;
            }
        }

        #region OperatorOverloading

        public static ChemicalAmount operator++(ChemicalAmount value)
        {
            return new ChemicalAmount(value.Value + 1, value.Unit);
        }

        public static ChemicalAmount operator--(ChemicalAmount value)
        {
            return new ChemicalAmount(value.Value - 1, value.Unit);
        }

        public static ChemicalAmount operator/(ChemicalAmount value, double scalar)
        {
            return new ChemicalAmount(value.Value / scalar, value.Unit);
        }

        public static ChemicalAmount operator*(ChemicalAmount value, double scalar)
        {
            return new ChemicalAmount(value.Value * scalar, value.Unit);
        }

        public static ChemicalAmount operator*(double scalar, ChemicalAmount value)
        {
            return new ChemicalAmount(value.Value * scalar, value.Unit);
        }

        public static ChemicalAmount operator-(ChemicalAmount a)
        {
            return new ChemicalAmount(-a.Value, a.Unit);
        }

        public static ChemicalAmount operator-(ChemicalAmount a, ChemicalAmount b)
        {
            if (a.Unit == b.Unit)
            {
                return new ChemicalAmount(a.Value - b.Value, a.Unit);
            }

            return new ChemicalAmount(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ChemicalAmount operator+(ChemicalAmount a, ChemicalAmount b)
        {
            if (a.Unit == b.Unit)
            {
                return new ChemicalAmount(a.Value + b.Value, a.Unit);
            }

            return new ChemicalAmount(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ChemicalAmount a, ChemicalAmount b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ChemicalAmount a, ChemicalAmount b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ChemicalAmount a, ChemicalAmount b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ChemicalAmount a, ChemicalAmount b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ChemicalAmount a, ChemicalAmount b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ChemicalAmount a, ChemicalAmount b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ChemicalAmount a, ChemicalAmount b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ChemicalAmount operator%(ChemicalAmount a, double b)
        {
            return new ChemicalAmount(a.Value % b, a.Unit);
        }

        #endregion
    }
}
