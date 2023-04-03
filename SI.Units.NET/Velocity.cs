using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Velocity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Velocity : IQuantity<Velocity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.MeterPerSecond;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m/s";

        /// <summary> Supported units of measure for Velocity Quantity type </summary>
        public enum Units
        {                
            MeterPerSecond,
            MeterPerMinute,
            MeterPerHour,

            DecimeterPerSecond,
            DecimeterPerMinute,
            DecimeterPerHour,

            CentimeterPerSecond,
            CentimeterPerMinute,
            CentimeterPerHour,

            MillimeterPerSecond,
            MillimeterPerMinute,
            MillimeterPerHour,

            DecameterPerSecond,
            DecameterPerMinute,
            DecameterPerHour,

            HectometerPerSecond,
            HectometerPerMinute,
            HectometerPerHour,

            KilometerPerSecond,
            KilometerPerMinute,
            KilometerPerHour,

            FootPerSecond,
            FootPerMinute,
            FootPerHour,

            YardPerSecond,
            YardPerMinute,
            YardPerHour,

            MilePerSecond,
            MilePerMinute,
            MilePerHour,

            Knot
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,            // MeterPerSecond,
            1.0 / 60.0,     // MeterPerMinute,
            1.0 / 3600.0,   // MeterPerHour,

            Prefixes.Deci.Factor,           // DecimeterPerSecond,
            Prefixes.Deci.Factor / 60.0,    // DecimeterPerMinute,
            Prefixes.Deci.Factor / 3600.0,  // DecimeterPerHour,

            Prefixes.Centi.Factor,          // CentimeterPerSecond,
            Prefixes.Centi.Factor / 60.0,   // CentimeterPerMinute,
            Prefixes.Centi.Factor / 3600.0, // CentimeterPerHour,

            Prefixes.Milli.Factor,          // MillimeterPerSecond,
            Prefixes.Milli.Factor / 60.0,   // MillimeterPerMinute,
            Prefixes.Milli.Factor / 3600.0, // MillimeterPerHour,

            Prefixes.Deca.Factor,           // DecameterPerSecond,
            Prefixes.Deca.Factor / 60.0,    // DecameterPerMinute,
            Prefixes.Deca.Factor / 3600.0,  // DecameterPerHour,

            Prefixes.Hecto.Factor,          // HectometerPerSecond,
            Prefixes.Hecto.Factor / 60.0,   // HectometerPerMinute,
            Prefixes.Hecto.Factor / 3600.0, // HectometerPerHour,

            Prefixes.Kilo.Factor,           // KilometerPerSecond,
            Prefixes.Kilo.Factor / 60.0,    // KilometerPerMinute,
            Prefixes.Kilo.Factor / 3600.0,  // KilometerPerHour,

            Length.FOOT2METER,                  // FootPerSecond,
            Length.FOOT2METER / 60.0,           // FootPerMinute,
            Length.FOOT2METER / 3600.0,         // FootPerHour,

            Length.FOOT2METER * 3,              // YardPerSecond,
            Length.FOOT2METER * 3 / 60.0,       // YardPerMinute,
            Length.FOOT2METER * 3 / 3600.0,     // YardPerHour,

            Length.FOOT2METER * 5280,           // MilePerSecond,
            Length.FOOT2METER * 5280 / 60.0,    // MilePerMinute,
            Length.FOOT2METER * 5280 / 3600.0,  // MilePerHour,

            1852.0 / 3600.0,                    // Knot (1 Nautical Mile per Hour / Seconds Per Hour)
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // MeterPerSecond,
            "m/min", // MeterPerMinute,
            "m/hr", // MeterPerHour,

            "dm/s",     // DecimeterPerSecond,
            "dm/min",   // DecimeterPerMinute,
            "dm/hr",    // DecimeterPerHour,

            "cm/s",     // CentimeterPerSecond,
            "cm/min",   // CentimeterPerMinute,
            "cm/hr",    // CentimeterPerHour,

            "mm/s",     // MillimeterPerSecond,
            "mm/min",   // MillimeterPerMinute,
            "mm/hr",    // MillimeterPerHour,

            "dam/s",    // DecameterPerSecond,
            "dam/min",  // DecameterPerMinute,
            "dan/hr",   // DecameterPerHour,

            "hm/s",     // HectometerPerSecond,
            "hm/min",   // HectometerPerMinute,
            "hm/hr",    // HectometerPerHour,

            "km/s",     // KilometerPerSecond,
            "km/min",   // KilometerPerMinute,
            "km/hr",    // KilometerPerHour,

            "ft/s",     // FootPerSecond,
            "ft/min",   // FootPerMinute,
            "ft/hr",    // FootPerHour,

            "yd/s",     // YardPerSecond,
            "yd/min",   // YardPerMinute,
            "yd/hr",    // YardPerHour,

            "mi/s",     // MilePerSecond,
            "mi/min",   // MilePerMinute,
            "mph",      // MilePerHour,

            "kt",       // Knot
        };

        /// <summary>
        /// Create new Velocity object
        /// </summary>
        /// <param name="value">Velocity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Velocity(double value, Units unit)
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
            if ((obj is Velocity) == false) { return false; }
            
            return Equals((Velocity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Velocity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Velocity other)
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
        public Velocity As(Units target)
        {
            return new Velocity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Velocity other)
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
        public Velocity Sqrt()
        {
            return new Velocity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Cbrt()
        {
            return new Velocity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Log()
        {
            return new Velocity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Log2()
        {
            return new Velocity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Log10()
        {
            return new Velocity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Pow(double exp)
        {
            return new Velocity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Velocity Abs()
        {
            return new Velocity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Floor()
        {
            return new Velocity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Ceiling()
        {
            return new Velocity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Truncate()
        {
            return new Velocity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Round()
        {
            return new Velocity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Velocity Round(int digits)
        {
            return new Velocity(Math.Round(Value, digits), Unit);
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
        public static Velocity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Velocity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Velocity result)
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
                result = default(Velocity);
                return false;
            }
        }

        #region OperatorOverloading

        public static Velocity operator++(Velocity value)
        {
            return new Velocity(value.Value + 1, value.Unit);
        }

        public static Velocity operator--(Velocity value)
        {
            return new Velocity(value.Value - 1, value.Unit);
        }

        public static Velocity operator/(Velocity value, double scalar)
        {
            return new Velocity(value.Value / scalar, value.Unit);
        }

        public static Velocity operator*(Velocity value, double scalar)
        {
            return new Velocity(value.Value * scalar, value.Unit);
        }

        public static Velocity operator*(double scalar, Velocity value)
        {
            return new Velocity(value.Value * scalar, value.Unit);
        }

        public static Velocity operator-(Velocity a)
        {
            return new Velocity(-a.Value, a.Unit);
        }

        public static Velocity operator-(Velocity a, Velocity b)
        {
            if (a.Unit == b.Unit)
            {
                return new Velocity(a.Value - b.Value, a.Unit);
            }

            return new Velocity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Velocity operator+(Velocity a, Velocity b)
        {
            if (a.Unit == b.Unit)
            {
                return new Velocity(a.Value + b.Value, a.Unit);
            }

            return new Velocity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Velocity a, Velocity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Velocity a, Velocity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Velocity a, Velocity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Velocity a, Velocity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Velocity a, Velocity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Velocity a, Velocity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Velocity a, Velocity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Velocity operator%(Velocity a, double b)
        {
            return new Velocity(a.Value % b, a.Unit);
        }

        #endregion
    }
}
