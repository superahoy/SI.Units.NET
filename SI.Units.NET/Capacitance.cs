using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Capacitance Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Capacitance : IQuantity<Capacitance>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Farad;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "F";

        /// <summary> Supported units of measure for Capacitance Quantity type </summary>
        public enum Units
        {
            Farad,
            Decifarad,
            Centifarad,
            Millifarad,
            Microfarad,
            Nanofarad,
            Picofarad,
            Femtofarad,
            Decafarad,
            Hectofarad,
            Kilofarad,
            Megafarad,
            Gigafarad,
            Terafarad,
            Petafarad
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Farad
            Prefixes.Deci.Factor,   // Decifarad
            Prefixes.Centi.Factor,  // Centifarad
            Prefixes.Milli.Factor,  // Millifarad
            Prefixes.Micro.Factor,  // Microfarad
            Prefixes.Nano.Factor,   // Nanofarad
            Prefixes.Pico.Factor,   // Picofarad
            Prefixes.Femto.Factor,  // Femtofarad
            Prefixes.Deca.Factor,   // Decafarad
            Prefixes.Hecto.Factor,  // Hectofarad
            Prefixes.Kilo.Factor,   // Kilofarad
            Prefixes.Mega.Factor,   // Megafarad
            Prefixes.Giga.Factor,   // Gigafarad
            Prefixes.Tera.Factor,   // Terafarad
            Prefixes.Peta.Factor,   // Petafarad
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
        /// Create new Capacitance object
        /// </summary>
        /// <param name="value">Capacitance value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Capacitance(double value, Units unit)
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
            if ((obj is Capacitance) == false) { return false; }
            
            return Equals((Capacitance)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Capacitance ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Capacitance other)
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
        public Capacitance As(Units target)
        {
            return new Capacitance(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Capacitance other)
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
        public Capacitance Sqrt()
        {
            return new Capacitance(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Cbrt()
        {
            return new Capacitance(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Log()
        {
            return new Capacitance(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Log2()
        {
            return new Capacitance(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Log10()
        {
            return new Capacitance(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Pow(double exp)
        {
            return new Capacitance(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Abs()
        {
            return new Capacitance(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Floor()
        {
            return new Capacitance(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Ceiling()
        {
            return new Capacitance(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Truncate()
        {
            return new Capacitance(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Round()
        {
            return new Capacitance(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Capacitance Round(int digits)
        {
            return new Capacitance(Math.Round(Value, digits), Unit);
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
        public static Capacitance Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Capacitance(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Capacitance result)
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
                result = default(Capacitance);
                return false;
            }
        }

        #region OperatorOverloading

        public static Capacitance operator++(Capacitance value)
        {
            return new Capacitance(value.Value + 1, value.Unit);
        }

        public static Capacitance operator--(Capacitance value)
        {
            return new Capacitance(value.Value - 1, value.Unit);
        }

        public static Capacitance operator/(Capacitance value, double scalar)
        {
            return new Capacitance(value.Value / scalar, value.Unit);
        }

        public static Capacitance operator*(Capacitance value, double scalar)
        {
            return new Capacitance(value.Value * scalar, value.Unit);
        }

        public static Capacitance operator*(double scalar, Capacitance value)
        {
            return new Capacitance(value.Value * scalar, value.Unit);
        }

        public static Capacitance operator-(Capacitance a)
        {
            return new Capacitance(-a.Value, a.Unit);
        }

        public static Capacitance operator-(Capacitance a, Capacitance b)
        {
            if (a.Unit == b.Unit)
            {
                return new Capacitance(a.Value - b.Value, a.Unit);
            }

            return new Capacitance(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Capacitance operator+(Capacitance a, Capacitance b)
        {
            if (a.Unit == b.Unit)
            {
                return new Capacitance(a.Value + b.Value, a.Unit);
            }

            return new Capacitance(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Capacitance a, Capacitance b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Capacitance a, Capacitance b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Capacitance a, Capacitance b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Capacitance a, Capacitance b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Capacitance a, Capacitance b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Capacitance a, Capacitance b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Capacitance a, Capacitance b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Capacitance operator%(Capacitance a, double b)
        {
            return new Capacitance(a.Value % b, a.Unit);
        }

        #endregion
    }
}
