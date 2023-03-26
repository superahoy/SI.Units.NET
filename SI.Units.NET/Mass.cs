using SI.Units.NET;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
/// <summary>
/// Represents Mass Base Quantity type from Table 2. SI base units
/// </summary>
    public readonly struct Mass : IQuantity<Mass>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Kilogram;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "g";

        /// <summary> Supported units of measure for Mass Quantity type </summary>
        public enum Units
        {
            Kilogram,
            Decigram,
            Centigram,
            Milligram,
            Microgram,
            Nanogram,
            Picogram,
            Femtogram,
            Decagram,
            Hectogram,
            Gram,
            Megagram,
            Gigagram,
            Teragram,
            Petagram,
            Tonne,
            Ounce,
            Pound,
            Ton,
            Slug,
            Stone
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
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

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
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
        /// Create new Mass object
        /// </summary>
        /// <param name="value">Mass value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Mass(double value, Units unit)
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
            if ((obj is Mass) == false) { return false; }
            
            return Equals((Mass)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            if (Unit == BaseUnit) return Value;

            return Value * Factors[(int)Unit] / Factors[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Mass ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Mass other)
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
        public Mass As(Units target)
        {
            return new Mass(Value * Factors[(int)Unit] / Factors[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Mass other)
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
        public Mass Sqrt()
        {
            return new Mass(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Cbrt()
        {
            return new Mass(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Log()
        {
            return new Mass(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Log2()
        {
            return new Mass(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Log10()
        {
            return new Mass(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Pow(double exp)
        {
            return new Mass(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Mass Abs()
        {
            return new Mass(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Floor()
        {
            return new Mass(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Ceiling()
        {
            return new Mass(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Truncate()
        {
            return new Mass(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Round()
        {
            return new Mass(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Mass Round(int digits)
        {
            return new Mass(Math.Round(Value, digits), Unit);
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
        public static Mass Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Mass(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Mass result)
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
                result = default(Mass);
                return false;
            }
        }

        #region OperatorOverloading

        public static Mass operator++(Mass value)
        {
            return new Mass(value.Value + 1, value.Unit);
        }

        public static Mass operator--(Mass value)
        {
            return new Mass(value.Value - 1, value.Unit);
        }

        public static Mass operator/(Mass value, double scalar)
        {
            return new Mass(value.Value / scalar, value.Unit);
        }

        public static Mass operator*(Mass value, double scalar)
        {
            return new Mass(value.Value * scalar, value.Unit);
        }

        public static Mass operator*(double scalar, Mass value)
        {
            return new Mass(value.Value * scalar, value.Unit);
        }

        public static Mass operator-(Mass a)
        {
            return new Mass(-a.Value, a.Unit);
        }

        public static Mass operator-(Mass a, Mass b)
        {
            if (a.Unit == b.Unit)
            {
                return new Mass(a.Value - b.Value, a.Unit);
            }

            return new Mass(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Mass operator+(Mass a, Mass b)
        {
            if (a.Unit == b.Unit)
            {
                return new Mass(a.Value + b.Value, a.Unit);
            }

            return new Mass(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Mass a, Mass b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Mass a, Mass b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Mass a, Mass b)
        {
            return !a.Equals(b);
        }

        #endregion
    }