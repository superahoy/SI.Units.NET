using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents LuminousIntensity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct LuminousIntensity : IQuantity<LuminousIntensity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Candela;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "A";

        /// <summary> Supported units of measure for LuminousIntensity Quantity type </summary>
        public enum Units
        {
            Candela,
            Decicandela,
            Centicandela,
            Millicandela,
            Microcandela,
            Nanocandela,
            Picocandela,
            Femtocandela,
            Decacandela,
            Hectocandela,
            Kilocandela,
            Megacandela,
            Gigacandela,
            Teracandela,
            Petacandela
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Candela
            Prefixes.Deci.Factor,   // Decicandela
            Prefixes.Centi.Factor,  // Centicandela
            Prefixes.Milli.Factor,  // Millicandela
            Prefixes.Micro.Factor,  // Microcandela
            Prefixes.Nano.Factor,   // Nanocandela
            Prefixes.Pico.Factor,   // Picocandela
            Prefixes.Femto.Factor,  // Femtocandela
            Prefixes.Deca.Factor,   // Decacandela
            Prefixes.Hecto.Factor,  // Hectocandela
            Prefixes.Kilo.Factor,   // Kilocandela
            Prefixes.Mega.Factor,   // Megacandela
            Prefixes.Giga.Factor,   // Gigacandela
            Prefixes.Tera.Factor,   // Teracandela
            Prefixes.Peta.Factor,   // Petacandela
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
        /// Create new LuminousIntensity object
        /// </summary>
        /// <param name="value">LuminousIntensity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public LuminousIntensity(double value, Units unit)
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
            if ((obj is LuminousIntensity) == false) { return false; }
            
            return Equals((LuminousIntensity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public LuminousIntensity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(LuminousIntensity other)
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
        public LuminousIntensity As(Units target)
        {
            return new LuminousIntensity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(LuminousIntensity other)
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
        public LuminousIntensity Sqrt()
        {
            return new LuminousIntensity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Cbrt()
        {
            return new LuminousIntensity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Log()
        {
            return new LuminousIntensity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Log2()
        {
            return new LuminousIntensity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Log10()
        {
            return new LuminousIntensity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Pow(double exp)
        {
            return new LuminousIntensity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Abs()
        {
            return new LuminousIntensity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Floor()
        {
            return new LuminousIntensity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Ceiling()
        {
            return new LuminousIntensity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Truncate()
        {
            return new LuminousIntensity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Round()
        {
            return new LuminousIntensity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public LuminousIntensity Round(int digits)
        {
            return new LuminousIntensity(Math.Round(Value, digits), Unit);
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
        public static LuminousIntensity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new LuminousIntensity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out LuminousIntensity result)
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
                result = default(LuminousIntensity);
                return false;
            }
        }

        #region OperatorOverloading

        public static LuminousIntensity operator++(LuminousIntensity value)
        {
            return new LuminousIntensity(value.Value + 1, value.Unit);
        }

        public static LuminousIntensity operator--(LuminousIntensity value)
        {
            return new LuminousIntensity(value.Value - 1, value.Unit);
        }

        public static LuminousIntensity operator/(LuminousIntensity value, double scalar)
        {
            return new LuminousIntensity(value.Value / scalar, value.Unit);
        }

        public static LuminousIntensity operator*(LuminousIntensity value, double scalar)
        {
            return new LuminousIntensity(value.Value * scalar, value.Unit);
        }

        public static LuminousIntensity operator*(double scalar, LuminousIntensity value)
        {
            return new LuminousIntensity(value.Value * scalar, value.Unit);
        }

        public static LuminousIntensity operator-(LuminousIntensity a)
        {
            return new LuminousIntensity(-a.Value, a.Unit);
        }

        public static LuminousIntensity operator-(LuminousIntensity a, LuminousIntensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new LuminousIntensity(a.Value - b.Value, a.Unit);
            }

            return new LuminousIntensity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static LuminousIntensity operator+(LuminousIntensity a, LuminousIntensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new LuminousIntensity(a.Value + b.Value, a.Unit);
            }

            return new LuminousIntensity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(LuminousIntensity a, LuminousIntensity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(LuminousIntensity a, LuminousIntensity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(LuminousIntensity a, LuminousIntensity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(LuminousIntensity a, LuminousIntensity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(LuminousIntensity a, LuminousIntensity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(LuminousIntensity a, LuminousIntensity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(LuminousIntensity a, LuminousIntensity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static LuminousIntensity operator%(LuminousIntensity a, double b)
        {
            return new LuminousIntensity(a.Value % b, a.Unit);
        }

        #endregion
    }
}
