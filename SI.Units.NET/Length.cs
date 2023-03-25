using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    public readonly struct Length : IQuantity<Length>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Meter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m";

        /// <summary> Supported units of measure for Length Quantity type </summary>
        public enum Units
        {
            Meter,
            Decimeter,
            Centimeter,
            Millimeter,
            Micrometer,
            Nanometer,
            Picometer,
            Femtometer,
            Decameter,
            Hectometer,
            Kilometer,
            Megameter,
            Gigameter,
            Terameter,
            Petameter,
            Inch,
            Foot,
            Yard,
            Mile,
            NauticalMile,
            Link,
            Chain,
            Rod,
            Furlong,
        };

        /// <summary>
        /// Conversion factors from base unit to unit of measure
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,
            Prefixes.Deci.Factor,
            Prefixes.Centi.Factor,
            Prefixes.Milli.Factor,
            Prefixes.Micro.Factor,
            Prefixes.Nano.Factor,
            Prefixes.Pico.Factor,
            Prefixes.Femto.Factor,
            Prefixes.Deca.Factor,
            Prefixes.Hecto.Factor,
            Prefixes.Kilo.Factor,
            Prefixes.Mega.Factor,
            Prefixes.Giga.Factor,
            Prefixes.Tera.Factor,
            Prefixes.Peta.Factor,
            0.3048 / 12.0,
            0.3048,
            0.3048 * 3.0,
            0.3048 * 5280.0,
            1852.0,
            0.3048 * 0.66,
            0.3048 * 66,
            0.3048 * 16.5,
            0.3048 * 660
        };

        private static readonly string[] Symbols =
        {
            BaseSymbol,
            Prefixes.Deci.Symbol + BaseSymbol,
            Prefixes.Centi.Symbol + BaseSymbol,
            Prefixes.Milli.Symbol + BaseSymbol,
            Prefixes.Micro.Symbol + BaseSymbol,
            Prefixes.Nano.Symbol + BaseSymbol,
            Prefixes.Pico.Symbol + BaseSymbol,
            Prefixes.Femto.Symbol + BaseSymbol,
            Prefixes.Deca.Symbol + BaseSymbol,
            Prefixes.Hecto.Symbol + BaseSymbol,
            Prefixes.Kilo.Symbol + BaseSymbol,
            Prefixes.Mega.Symbol + BaseSymbol,
            Prefixes.Giga.Symbol + BaseSymbol,
            Prefixes.Tera.Symbol + BaseSymbol,
            Prefixes.Peta.Symbol + BaseSymbol,
            "in",
            "ft",
            "yd",
            "mi",
            "NM",
            "lnk",
            "ch",
            "rod",
            "fur"
        };

        /// <summary>
        /// Create new Length object
        /// </summary>
        /// <param name="value">Length value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Length(double value, Units unit)
        {
            Value = value; 
            Unit = unit;
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
            return HashCode.Combine(Value, Unit);
        }

        /// <inheritdoc/>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if ((obj is Length) == false) { return false; }
            
            return Equals((Length)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            if (Unit == BaseUnit) return Value;

            return Value * Factors[(int)Unit] / Factors[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Length ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Length other)
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
        public Length As(Units target)
        {
            return new Length(Value * Factors[(int)Unit] / Factors[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Length other)
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
        public Length Sqrt()
        {
            return new Length(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Cbrt()
        {
            return new Length(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Log()
        {
            return new Length(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Log2()
        {
            return new Length(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Log10()
        {
            return new Length(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Pow(double exp)
        {
            return new Length(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Length Abs()
        {
            return new Length(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Floor()
        {
            return new Length(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Ceiling()
        {
            return new Length(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Truncate()
        {
            return new Length(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Round()
        {
            return new Length(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Length Round(int digits)
        {
            return new Length(Math.Round(Value, digits), Unit);
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

        #region OperatorOverloading

        public static Length operator/(Length value, double scalar)
        {
            return new Length(value.Value / scalar, value.Unit);
        }

        public static Length operator*(Length value, double scalar)
        {
            return new Length(value.Value * scalar, value.Unit);
        }

        public static Length operator*(double scalar, Length value)
        {
            return new Length(value.Value * scalar, value.Unit);
        }

        public static Length operator-(Length a)
        {
            return new Length(-a.Value, a.Unit);
        }

        public static Length operator-(Length a, Length b)
        {
            if (a.Unit == b.Unit)
            {
                return new Length(a.Value - b.Value, a.Unit);
            }

            return new Length(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Length operator+(Length a, Length b)
        {
            if (a.Unit == b.Unit)
            {
                return new Length(a.Value + b.Value, a.Unit);
            }

            return new Length(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Length a, Length b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Length a, Length b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Length a, Length b)
        {
            return !a.Equals(b);
        }

        #endregion
    }
}
