using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Length Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Length : IQuantity<Length>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Meter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m";

        /// <summary> Length, Astronomical Unit, Symbol for unit, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string AstronomicalUnitSymbol = "au";

        /// <summary> Length, Astronomical Unit, Value in SI Units, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const double AstronomicalUnitValue = 149597870700.0;

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
            [Description("1 Inch = 1/12 ft")]
            Inch,
            [Description("1 Foot = 0.3048 m")]
            Foot,
            [Description("1 Yard = 3 ft")]
            Yard,
            [Description("1 Mile = 5280 ft")]
            Mile,
            [Description("1 Nautical Mile = 1852 m")]
            NauticalMile,
            [Description("1 Link = 1/100 chain = 0.66 ft")]
            Link,
            [Description("1 Chain = 66 ft")]
            Chain,
            [Description("1 Rod = 16.5 ft")]
            Rod,
            [Description("1 Furlong = 660 ft")]
            Furlong,
            [Description("1 Fathom = 6 ft")]
            Fathom,
            [Description("1 Astronomical Unit = 149,597,870,700 m")]
            AstronomicalUnit,
        };

        /// <summary> US Customary units definition, foot to meter </summary>
        internal const double FOOT2METER = 0.3048;

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Meter
            Prefixes.Deci.Factor,   // Decimeter
            Prefixes.Centi.Factor,  // Centimeter
            Prefixes.Milli.Factor,  // Millimeter
            Prefixes.Micro.Factor,  // Micrometer
            Prefixes.Nano.Factor,   // Nanometer
            Prefixes.Pico.Factor,   // Picometer
            Prefixes.Femto.Factor,  // Femtometer
            Prefixes.Deca.Factor,   // Decameter
            Prefixes.Hecto.Factor,  // Hectometer
            Prefixes.Kilo.Factor,   // Kilometer
            Prefixes.Mega.Factor,   // Megameter
            Prefixes.Giga.Factor,   // Gigameter
            Prefixes.Tera.Factor,   // Terameter
            Prefixes.Peta.Factor,   // Petameter
            USCustomary.Inch.Factor,    // Inch
            USCustomary.Foot.Factor,    // Foot
            USCustomary.Yard.Factor,    // Yard
            USCustomary.Mile.Factor,    // Mile
            1852.0,                     // NauticalMile
            USCustomary.Link.Factor,    // Link
            USCustomary.Chain.Factor,   // Chain
            USCustomary.Rod.Factor,     // Rod
            USCustomary.Furlong.Factor, // Furlong
            USCustomary.Fathom.Factor,  // Fathom
            AstronomicalUnitValue       // AstronomicalUnit
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
            Prefixes.Peta.Symbol    + BaseSymbol,
            USCustomary.Inch.Symbol,    // Inch
            USCustomary.Foot.Symbol,    // Foot
            USCustomary.Yard.Symbol,    // Yard
            USCustomary.Mile.Symbol,    // Mile
            "NM",                       // Nautical Mile (Symbol defined by International Civil Aviation Organization)
            USCustomary.Link.Symbol,    // Link
            USCustomary.Chain.Symbol,   // Chain
            USCustomary.Rod.Symbol,     // Rod
            USCustomary.Furlong.Symbol, // Furlong
            USCustomary.Fathom.Symbol,  // Fathom
            AstronomicalUnitSymbol      // AstronomicalUnit
        };

        /// <summary>
        /// Create new Length object
        /// </summary>
        /// <param name="value">Length value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Length(double value, Units unit)
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
            if ((obj is Length) == false) { return false; }
            
            return Equals((Length)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
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
            return new Length(Value * Factors[(int)Unit] * Inverse[(int)target], target);
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

        /// <inheritdoc/>
        public int Sign()
        {
            return Math.Sign(Value);
        }

        /// <inheritdoc/>
        public static Length Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Length(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Length result)
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
                result = default(Length);
                return false;
            }
        }

        #region OperatorOverloading

        public static Length operator++(Length value)
        {
            return new Length(value.Value + 1, value.Unit);
        }

        public static Length operator--(Length value)
        {
            return new Length(value.Value - 1, value.Unit);
        }

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

        public static bool operator>(Length a, Length b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Length a, Length b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Length a, Length b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Length a, Length b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Length operator%(Length a, double b)
        {
            return new Length(a.Value % b, a.Unit);
        }

        #endregion
    }
}
