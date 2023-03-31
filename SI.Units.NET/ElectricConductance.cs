using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ElectricConductance Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ElectricConductance : IQuantity<ElectricConductance>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Siemens;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "S";

        /// <summary> Supported units of measure for ElectricConductance Quantity type </summary>
        public enum Units
        {
            Siemens,
            Decisiemens,
            Centisiemens,
            Millisiemens,
            Microsiemens,
            Nanosiemens,
            Picosiemens,
            Femtosiemens,
            Decasiemens,
            Hectosiemens,
            Kilosiemens,
            Megasiemens,
            Gigasiemens,
            Terasiemens,
            Petasiemens
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Siemens
            Prefixes.Deci.Factor,   // Decisiemens
            Prefixes.Centi.Factor,  // Centisiemens
            Prefixes.Milli.Factor,  // Millisiemens
            Prefixes.Micro.Factor,  // Microsiemens
            Prefixes.Nano.Factor,   // Nanosiemens
            Prefixes.Pico.Factor,   // Picosiemens
            Prefixes.Femto.Factor,  // Femtosiemens
            Prefixes.Deca.Factor,   // Decasiemens
            Prefixes.Hecto.Factor,  // Hectosiemens
            Prefixes.Kilo.Factor,   // Kilosiemens
            Prefixes.Mega.Factor,   // Megasiemens
            Prefixes.Giga.Factor,   // Gigasiemens
            Prefixes.Tera.Factor,   // Terasiemens
            Prefixes.Peta.Factor,   // Petasiemens
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
        /// Create new ElectricConductance object
        /// </summary>
        /// <param name="value">ElectricConductance value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ElectricConductance(double value, Units unit)
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
            if ((obj is ElectricConductance) == false) { return false; }
            
            return Equals((ElectricConductance)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ElectricConductance ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ElectricConductance other)
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
        public ElectricConductance As(Units target)
        {
            return new ElectricConductance(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ElectricConductance other)
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
        public ElectricConductance Sqrt()
        {
            return new ElectricConductance(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Cbrt()
        {
            return new ElectricConductance(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Log()
        {
            return new ElectricConductance(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Log2()
        {
            return new ElectricConductance(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Log10()
        {
            return new ElectricConductance(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Pow(double exp)
        {
            return new ElectricConductance(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Abs()
        {
            return new ElectricConductance(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Floor()
        {
            return new ElectricConductance(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Ceiling()
        {
            return new ElectricConductance(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Truncate()
        {
            return new ElectricConductance(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Round()
        {
            return new ElectricConductance(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ElectricConductance Round(int digits)
        {
            return new ElectricConductance(Math.Round(Value, digits), Unit);
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
        public static ElectricConductance Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ElectricConductance(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ElectricConductance result)
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
                result = default(ElectricConductance);
                return false;
            }
        }

        #region OperatorOverloading

        public static ElectricConductance operator++(ElectricConductance value)
        {
            return new ElectricConductance(value.Value + 1, value.Unit);
        }

        public static ElectricConductance operator--(ElectricConductance value)
        {
            return new ElectricConductance(value.Value - 1, value.Unit);
        }

        public static ElectricConductance operator/(ElectricConductance value, double scalar)
        {
            return new ElectricConductance(value.Value / scalar, value.Unit);
        }

        public static ElectricConductance operator*(ElectricConductance value, double scalar)
        {
            return new ElectricConductance(value.Value * scalar, value.Unit);
        }

        public static ElectricConductance operator*(double scalar, ElectricConductance value)
        {
            return new ElectricConductance(value.Value * scalar, value.Unit);
        }

        public static ElectricConductance operator-(ElectricConductance a)
        {
            return new ElectricConductance(-a.Value, a.Unit);
        }

        public static ElectricConductance operator-(ElectricConductance a, ElectricConductance b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricConductance(a.Value - b.Value, a.Unit);
            }

            return new ElectricConductance(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ElectricConductance operator+(ElectricConductance a, ElectricConductance b)
        {
            if (a.Unit == b.Unit)
            {
                return new ElectricConductance(a.Value + b.Value, a.Unit);
            }

            return new ElectricConductance(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ElectricConductance a, ElectricConductance b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ElectricConductance a, ElectricConductance b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ElectricConductance a, ElectricConductance b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ElectricConductance a, ElectricConductance b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ElectricConductance a, ElectricConductance b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ElectricConductance a, ElectricConductance b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ElectricConductance a, ElectricConductance b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ElectricConductance operator%(ElectricConductance a, double b)
        {
            return new ElectricConductance(a.Value % b, a.Unit);
        }

        #endregion
    }
}
