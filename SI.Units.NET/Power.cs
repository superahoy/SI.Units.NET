using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Power Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Power : IQuantity<Power>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Watt;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "J";

        /// <summary> Supported units of measure for Power Quantity type </summary>
        public enum Units
        {
            Watt,
            Deciwatt,
            Centiwatt,
            Milliwatt,
            Microwatt,
            Nanowatt,
            Picowatt,
            Femtowatt,
            Decawatt,
            Hectowatt,
            Kilowatt,
            Megawatt,
            Gigawatt,
            Terawatt,
            Petawatt
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Watt
            Prefixes.Deci.Factor,   // Deciwatt
            Prefixes.Centi.Factor,  // Centiwatt
            Prefixes.Milli.Factor,  // Milliwatt
            Prefixes.Micro.Factor,  // Microwatt
            Prefixes.Nano.Factor,   // Nanowatt
            Prefixes.Pico.Factor,   // Picowatt
            Prefixes.Femto.Factor,  // Femtowatt
            Prefixes.Deca.Factor,   // Decawatt
            Prefixes.Hecto.Factor,  // Hectowatt
            Prefixes.Kilo.Factor,   // Kilowatt
            Prefixes.Mega.Factor,   // Megawatt
            Prefixes.Giga.Factor,   // Gigawatt
            Prefixes.Tera.Factor,   // Terawatt
            Prefixes.Peta.Factor,   // Petawatt
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
        /// Create new Power object
        /// </summary>
        /// <param name="value">Power value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Power(double value, Units unit)
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
            if ((obj is Power) == false) { return false; }
            
            return Equals((Power)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Power ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Power other)
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
        public Power As(Units target)
        {
            return new Power(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Power other)
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
        public Power Sqrt()
        {
            return new Power(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Cbrt()
        {
            return new Power(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Log()
        {
            return new Power(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Log2()
        {
            return new Power(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Log10()
        {
            return new Power(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Pow(double exp)
        {
            return new Power(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Power Abs()
        {
            return new Power(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Floor()
        {
            return new Power(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Ceiling()
        {
            return new Power(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Truncate()
        {
            return new Power(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Round()
        {
            return new Power(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Power Round(int digits)
        {
            return new Power(Math.Round(Value, digits), Unit);
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
        public static Power Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Power(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Power result)
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
                result = default(Power);
                return false;
            }
        }

        #region OperatorOverloading

        public static Power operator++(Power value)
        {
            return new Power(value.Value + 1, value.Unit);
        }

        public static Power operator--(Power value)
        {
            return new Power(value.Value - 1, value.Unit);
        }

        public static Power operator/(Power value, double scalar)
        {
            return new Power(value.Value / scalar, value.Unit);
        }

        public static Power operator*(Power value, double scalar)
        {
            return new Power(value.Value * scalar, value.Unit);
        }

        public static Power operator*(double scalar, Power value)
        {
            return new Power(value.Value * scalar, value.Unit);
        }

        public static Power operator-(Power a)
        {
            return new Power(-a.Value, a.Unit);
        }

        public static Power operator-(Power a, Power b)
        {
            if (a.Unit == b.Unit)
            {
                return new Power(a.Value - b.Value, a.Unit);
            }

            return new Power(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Power operator+(Power a, Power b)
        {
            if (a.Unit == b.Unit)
            {
                return new Power(a.Value + b.Value, a.Unit);
            }

            return new Power(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Power a, Power b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Power a, Power b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Power a, Power b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Power a, Power b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Power a, Power b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Power a, Power b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Power a, Power b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Power operator%(Power a, double b)
        {
            return new Power(a.Value % b, a.Unit);
        }

        #endregion
    }
}
