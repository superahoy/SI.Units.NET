using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Acceleration Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Acceleration : IQuantity<Acceleration>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.MeterPerSecondSquared;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m/s²";

        /// <summary> Supported units of measure for Acceleration Quantity type </summary>
        public enum Units
        {
            MeterPerSecondSquared,
            
            DecimeterPerSecondSquared,
            CentimeterPerSecondSquared,
            MillimeterPerSecondSquared,
            
            DecameterPerSecondSquared,
            HectometerPerSecondSquared,
            KilometerPerSecondSquared,

            InchPerSecondSquared,
            FootPerSecondSquared,
            YardPerSecondSquared,
            MilePerSecondSquared,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0, // MeterPerSecondSquared,
            
            Prefixes.Deci.Factor,   // DecimeterPerSecondSquared,
            Prefixes.Centi.Factor,  // CentimeterPerSecondSquared,
            Prefixes.Milli.Factor,  // MillimeterPerSecondSquared,
            
            Prefixes.Deca.Factor,   // DecameterPerSecondSquared,
            Prefixes.Hecto.Factor,  // HectometerPerSecondSquared,
            Prefixes.Kilo.Factor,   // KilometerPerSecondSquared,

            USCustomary.Inch.Factor, // InchPerSecondSquared,
            USCustomary.Foot.Factor, // FootPerSecondSquared,
            USCustomary.Yard.Factor, // YardPerSecondSquared,
            USCustomary.Mile.Factor, // MilePerSecondSquared,
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            "dm/s²", // DecimeterPerSecondSquared,
            "cm/s²", // CentimeterPerSecondSquared,
            "mm/s²", // MillimeterPerSecondSquared,
            
            "dam/s²", // DecameterPerSecondSquared,
            "hm/s²", // HectometerPerSecondSquared,
            "km/s²", // KilometerPerSecondSquared,

            "in/s²", // InchPerSecondSquared,
            "ft/s²", // FootPerSecondSquared,
            "yd/s²", // YardPerSecondSquared,
            "mi/s²", // MilePerSecondSquared,
        };

        /// <summary>
        /// Create new Acceleration object
        /// </summary>
        /// <param name="value">Acceleration value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Acceleration(double value, Units unit)
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
            if ((obj is Acceleration) == false) { return false; }
            
            return Equals((Acceleration)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Acceleration ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Acceleration other)
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
        public Acceleration As(Units target)
        {
            return new Acceleration(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Acceleration other)
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
        public Acceleration Sqrt()
        {
            return new Acceleration(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Cbrt()
        {
            return new Acceleration(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Log()
        {
            return new Acceleration(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Log2()
        {
            return new Acceleration(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Log10()
        {
            return new Acceleration(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Pow(double exp)
        {
            return new Acceleration(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Abs()
        {
            return new Acceleration(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Floor()
        {
            return new Acceleration(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Ceiling()
        {
            return new Acceleration(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Truncate()
        {
            return new Acceleration(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Round()
        {
            return new Acceleration(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Acceleration Round(int digits)
        {
            return new Acceleration(Math.Round(Value, digits), Unit);
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
        public static Acceleration Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Acceleration(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Acceleration result)
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
                result = default(Acceleration);
                return false;
            }
        }

        #region OperatorOverloading

        public static Acceleration operator++(Acceleration value)
        {
            return new Acceleration(value.Value + 1, value.Unit);
        }

        public static Acceleration operator--(Acceleration value)
        {
            return new Acceleration(value.Value - 1, value.Unit);
        }

        public static Acceleration operator/(Acceleration value, double scalar)
        {
            return new Acceleration(value.Value / scalar, value.Unit);
        }

        public static Acceleration operator*(Acceleration value, double scalar)
        {
            return new Acceleration(value.Value * scalar, value.Unit);
        }

        public static Acceleration operator*(double scalar, Acceleration value)
        {
            return new Acceleration(value.Value * scalar, value.Unit);
        }

        public static Acceleration operator-(Acceleration a)
        {
            return new Acceleration(-a.Value, a.Unit);
        }

        public static Acceleration operator-(Acceleration a, Acceleration b)
        {
            if (a.Unit == b.Unit)
            {
                return new Acceleration(a.Value - b.Value, a.Unit);
            }

            return new Acceleration(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Acceleration operator+(Acceleration a, Acceleration b)
        {
            if (a.Unit == b.Unit)
            {
                return new Acceleration(a.Value + b.Value, a.Unit);
            }

            return new Acceleration(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Acceleration a, Acceleration b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Acceleration a, Acceleration b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Acceleration a, Acceleration b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Acceleration a, Acceleration b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Acceleration a, Acceleration b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Acceleration a, Acceleration b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Acceleration a, Acceleration b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Acceleration operator%(Acceleration a, double b)
        {
            return new Acceleration(a.Value % b, a.Unit);
        }

        /// <summary>
        /// Force = Mass * Acceleration
        /// </summary>
        /// <param name="mass">Mass value</param>
        /// <param name="acceleration">Acceleration value</param>
        /// <returns>Force in Newton</returns>
        public static Force operator*(Mass mass, Acceleration acceleration)
        {
            return new Force(mass.BaseValue() * acceleration.BaseValue(), Force.BaseUnit);
        }

        /// <summary>
        /// Force = Mass * Acceleration
        /// </summary>
        /// <param name="acceleration">Acceleration value</param>
        /// <param name="mass">Mass value</param>
        /// <returns>Force in Newton</returns>
        public static Force operator*(Acceleration acceleration, Mass mass)
        {
            return new Force(mass.BaseValue() * acceleration.BaseValue(), Force.BaseUnit);
        }

        #endregion
    }
}
