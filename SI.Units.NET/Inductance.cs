using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Inductance Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Inductance : IQuantity<Inductance>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Henry;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "H";

        /// <summary> Supported units of measure for Inductance Quantity type </summary>
        public enum Units
        {
            Henry,
            Decihenry,
            Centihenry,
            Millihenry,
            Microhenry,
            Nanohenry,
            Picohenry,
            Femtohenry,
            Decahenry,
            Hectohenry,
            Kilohenry,
            Megahenry,
            Gigahenry,
            Terahenry,
            Petahenry
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Henry
            Prefixes.Deci.Factor,   // Decihenry
            Prefixes.Centi.Factor,  // Centihenry
            Prefixes.Milli.Factor,  // Millihenry
            Prefixes.Micro.Factor,  // Microhenry
            Prefixes.Nano.Factor,   // Nanohenry
            Prefixes.Pico.Factor,   // Picohenry
            Prefixes.Femto.Factor,  // Femtohenry
            Prefixes.Deca.Factor,   // Decahenry
            Prefixes.Hecto.Factor,  // Hectohenry
            Prefixes.Kilo.Factor,   // Kilohenry
            Prefixes.Mega.Factor,   // Megahenry
            Prefixes.Giga.Factor,   // Gigahenry
            Prefixes.Tera.Factor,   // Terahenry
            Prefixes.Peta.Factor,   // Petahenry
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
        /// Create new Inductance object
        /// </summary>
        /// <param name="value">Inductance value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Inductance(double value, Units unit)
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
            if ((obj is Inductance) == false) { return false; }
            
            return Equals((Inductance)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Inductance ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Inductance other)
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
        public Inductance As(Units target)
        {
            return new Inductance(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Inductance other)
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
        public Inductance Sqrt()
        {
            return new Inductance(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Cbrt()
        {
            return new Inductance(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Log()
        {
            return new Inductance(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Log2()
        {
            return new Inductance(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Log10()
        {
            return new Inductance(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Pow(double exp)
        {
            return new Inductance(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Inductance Abs()
        {
            return new Inductance(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Floor()
        {
            return new Inductance(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Ceiling()
        {
            return new Inductance(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Truncate()
        {
            return new Inductance(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Round()
        {
            return new Inductance(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Inductance Round(int digits)
        {
            return new Inductance(Math.Round(Value, digits), Unit);
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
        public static Inductance Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Inductance(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Inductance result)
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
                result = default(Inductance);
                return false;
            }
        }

        #region OperatorOverloading

        public static Inductance operator++(Inductance value)
        {
            return new Inductance(value.Value + 1, value.Unit);
        }

        public static Inductance operator--(Inductance value)
        {
            return new Inductance(value.Value - 1, value.Unit);
        }

        public static Inductance operator/(Inductance value, double scalar)
        {
            return new Inductance(value.Value / scalar, value.Unit);
        }

        public static Inductance operator*(Inductance value, double scalar)
        {
            return new Inductance(value.Value * scalar, value.Unit);
        }

        public static Inductance operator*(double scalar, Inductance value)
        {
            return new Inductance(value.Value * scalar, value.Unit);
        }

        public static Inductance operator-(Inductance a)
        {
            return new Inductance(-a.Value, a.Unit);
        }

        public static Inductance operator-(Inductance a, Inductance b)
        {
            if (a.Unit == b.Unit)
            {
                return new Inductance(a.Value - b.Value, a.Unit);
            }

            return new Inductance(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Inductance operator+(Inductance a, Inductance b)
        {
            if (a.Unit == b.Unit)
            {
                return new Inductance(a.Value + b.Value, a.Unit);
            }

            return new Inductance(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Inductance a, Inductance b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Inductance a, Inductance b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Inductance a, Inductance b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Inductance a, Inductance b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Inductance a, Inductance b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Inductance a, Inductance b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Inductance a, Inductance b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Inductance operator%(Inductance a, double b)
        {
            return new Inductance(a.Value % b, a.Unit);
        }

        #endregion
    }
}
