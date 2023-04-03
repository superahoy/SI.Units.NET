using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Time Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Time : IQuantity<Time>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Second;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "s";

        /// <summary> Time, Minute from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string MinuteSymbol = "min";

        /// <summary> Time, Hour from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string HourSymbol = "hr";

        /// <summary> Time, Day from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const string DaySymbol = "d";

        /// <summary> Time, Minute, Value in SI Units, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const double MinuteValue = 60.0;

        /// <summary> Time, Hour, Value in SI Units, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const double HourValue = 3600.0;

        /// <summary> Time, Day, Value in SI Units, from Table 8. Non-SI units accepted for use with the SI units </summary>
        public const double DayValue = 86400.0;

        /// <summary> Supported units of measure for Time Quantity type </summary>
        public enum Units
        {
            Second,
            Decisecond,
            Centisecond,
            Millisecond,
            Microsecond,
            Nanosecond,
            Picosecond,
            Femtosecond,
            Decasecond,
            Hectosecond,
            Kilosecond,
            Megasecond,
            Gigasecond,
            Terasecond,
            Petasecond,
            [Description("1 Minute = 60 s")]
            Minute,
            [Description("1 Hour = 60 min = 3600 s")]
            Hour,
            [Description("1 Day = 24 hr = 86,400 s")]
            Day
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Second
            Prefixes.Deci.Factor,   // Decisecond
            Prefixes.Centi.Factor,  // Centisecond
            Prefixes.Milli.Factor,  // Millisecond
            Prefixes.Micro.Factor,  // Microsecond
            Prefixes.Nano.Factor,   // Nanosecond
            Prefixes.Pico.Factor,   // Picosecond
            Prefixes.Femto.Factor,  // Femtosecond
            Prefixes.Deca.Factor,   // Decasecond
            Prefixes.Hecto.Factor,  // Hectosecond
            Prefixes.Kilo.Factor,   // Kilosecond
            Prefixes.Mega.Factor,   // Megasecond
            Prefixes.Giga.Factor,   // Gigasecond
            Prefixes.Tera.Factor,   // Terasecond
            Prefixes.Peta.Factor,   // Petasecond
            MinuteValue,            // Minute
            HourValue,              // Hour
            DayValue                // Day
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

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
            MinuteSymbol,
            HourSymbol,
            DaySymbol            
        };

        /// <summary>
        /// Create new Time object
        /// </summary>
        /// <param name="value">Time value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Time(double value, Units unit)
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
            if ((obj is Time) == false) { return false; }
            
            return Equals((Time)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Time ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Time other)
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
        public Time As(Units target)
        {
            return new Time(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Time other)
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
        public Time Sqrt()
        {
            return new Time(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Cbrt()
        {
            return new Time(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Log()
        {
            return new Time(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Log2()
        {
            return new Time(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Log10()
        {
            return new Time(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Pow(double exp)
        {
            return new Time(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Time Abs()
        {
            return new Time(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Floor()
        {
            return new Time(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Ceiling()
        {
            return new Time(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Truncate()
        {
            return new Time(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Round()
        {
            return new Time(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Time Round(int digits)
        {
            return new Time(Math.Round(Value, digits), Unit);
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
        public static Time Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Time(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Time result)
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
                result = default(Time);
                return false;
            }
        }

        #region OperatorOverloading

        public static Time operator++(Time value)
        {
            return new Time(value.Value + 1, value.Unit);
        }

        public static Time operator--(Time value)
        {
            return new Time(value.Value - 1, value.Unit);
        }

        public static Time operator/(Time value, double scalar)
        {
            return new Time(value.Value / scalar, value.Unit);
        }

        public static Time operator*(Time value, double scalar)
        {
            return new Time(value.Value * scalar, value.Unit);
        }

        public static Time operator*(double scalar, Time value)
        {
            return new Time(value.Value * scalar, value.Unit);
        }

        public static Time operator-(Time a)
        {
            return new Time(-a.Value, a.Unit);
        }

        public static Time operator-(Time a, Time b)
        {
            if (a.Unit == b.Unit)
            {
                return new Time(a.Value - b.Value, a.Unit);
            }

            return new Time(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Time operator+(Time a, Time b)
        {
            if (a.Unit == b.Unit)
            {
                return new Time(a.Value + b.Value, a.Unit);
            }

            return new Time(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Time a, Time b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Time a, Time b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Time a, Time b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Time a, Time b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Time a, Time b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Time a, Time b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Time a, Time b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Time operator%(Time a, double b)
        {
            return new Time(a.Value % b, a.Unit);
        }

        #endregion
    }
}
