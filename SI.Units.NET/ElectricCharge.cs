using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ElectricCharge Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ElectricCharge : IQuantity<ElectricCharge>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Coulomb;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "C";

        /// <summary> Supported units of measure for ElectricCharge Quantity type </summary>
        public enum Units
        {
            Coulomb,
            Decicoulomb,
            Centicoulomb,
            Millicoulomb,
            Microcoulomb,
            Nanocoulomb,
            Picocoulomb,
            Femtocoulomb,
            Decacoulomb,
            Hectocoulomb,
            Kilocoulomb,
            Megacoulomb,
            Gigacoulomb,
            Teracoulomb,
            Petacoulomb
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Coulomb
            Prefixes.Deci.Factor,   // Decicoulomb
            Prefixes.Centi.Factor,  // Centicoulomb
            Prefixes.Milli.Factor,  // Millicoulomb
            Prefixes.Micro.Factor,  // Microcoulomb
            Prefixes.Nano.Factor,   // Nanocoulomb
            Prefixes.Pico.Factor,   // Picocoulomb
            Prefixes.Femto.Factor,  // Femtocoulomb
            Prefixes.Deca.Factor,   // Decacoulomb
            Prefixes.Hecto.Factor,  // Hectocoulomb
            Prefixes.Kilo.Factor,   // Kilocoulomb
            Prefixes.Mega.Factor,   // Megacoulomb
            Prefixes.Giga.Factor,   // Gigacoulomb
            Prefixes.Tera.Factor,   // Teracoulomb
            Prefixes.Peta.Factor,   // Petacoulomb
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
        /// Create new ElectricCharge object
        /// </summary>
        /// <param name="value">ElectricCharge value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ElectricCharge(double value, Units unit)
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
            if ((obj is ElectricCharge) == false) { return false; }
            
            return Equals((ElectricCharge)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ElectricCharge ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ElectricCharge other)
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
        public ElectricCharge As(Units target)
        {
            return new ElectricCharge(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ElectricCharge other)
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
        public ElectricCharge Sqrt()
        {
            return new ElectricCharge(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Cbrt()
        {
            return new ElectricCharge(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Log()
        {
            return new ElectricCharge(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Log2()
        {
            return new ElectricCharge(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Log10()
        {
            return new ElectricCharge(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Pow(double exp)
        {
            return new ElectricCharge(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Abs()
        {
            return new ElectricCharge(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Floor()
        {
            return new ElectricCharge(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Ceiling()
        {
            return new ElectricCharge(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Truncate()
        {
            return new ElectricCharge(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Round()
        {
            return new ElectricCharge(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricCharge Round(int digits)
        {
            return new ElectricCharge(Math.Round(Value, digits), Unit);
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
        public static ElectricCharge Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ElectricCharge(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ElectricCharge result)
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
                result = default(ElectricCharge);
                return false;
            }
        }

        #region OperatorOverloading

        public static ElectricCharge operator++(ElectricCharge value)
        {
            return new ElectricCharge(value.Value + 1, value.Unit);
        }

        public static ElectricCharge operator--(ElectricCharge value)
        {
            return new ElectricCharge(value.Value - 1, value.Unit);
        }

        public static ElectricCharge operator/(ElectricCharge value, double scalar)
        {
            return new ElectricCharge(value.Value / scalar, value.Unit);
        }

        public static ElectricCharge operator*(ElectricCharge value, double scalar)
        {
            return new ElectricCharge(value.Value * scalar, value.Unit);
        }

        public static ElectricCharge operator*(double scalar, ElectricCharge value)
        {
            return new ElectricCharge(value.Value * scalar, value.Unit);
        }

        public static ElectricCharge operator-(ElectricCharge a)
        {
            return new ElectricCharge(-a.Value, a.Unit);
        }

        public static ElectricCharge operator-(ElectricCharge a, ElectricCharge b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricCharge(a.Value - b.Value, a.Unit);
            }

            return new ElectricCharge(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ElectricCharge operator+(ElectricCharge a, ElectricCharge b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricCharge(a.Value + b.Value, a.Unit);
            }

            return new ElectricCharge(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ElectricCharge a, ElectricCharge b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ElectricCharge a, ElectricCharge b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ElectricCharge a, ElectricCharge b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ElectricCharge a, ElectricCharge b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ElectricCharge a, ElectricCharge b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ElectricCharge a, ElectricCharge b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ElectricCharge a, ElectricCharge b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ElectricCharge operator%(ElectricCharge a, double b)
        {
            return new ElectricCharge(a.Value % b, a.Unit);
        }

        #endregion
    }
}
