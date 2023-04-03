using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Plane Angle
    /// </summary>
    public readonly struct Angle : IQuantity<Angle>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Radian;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "rad";

        public const double DEG2RAD = Math.PI / 180.0;

        /// <summary> Supported units of measure for Angle Quantity type </summary>
        public enum Units
        {
            Radian,
            Deciradian,
            Centiradian,
            Milliradian,
            Microradian,
            Degree,
            Minute,
            Second,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Radian
            Prefixes.Deci.Factor,   // Deciradian
            Prefixes.Centi.Factor,  // Centiradian
            Prefixes.Milli.Factor,  // Milliradian
            Prefixes.Micro.Factor,  // Microradian
            DEG2RAD,        // Degree
            Math.PI / 10800.0,      // Minute
            Math.PI / 648000.0      // Second
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,                             // Radian
            Prefixes.Deci.Symbol    + BaseSymbol,   // Deciradian
            Prefixes.Centi.Symbol   + BaseSymbol,   // Centiradian
            Prefixes.Milli.Symbol   + BaseSymbol,   // Milliradian
            Prefixes.Micro.Symbol   + BaseSymbol,   // Microradian
            "°",    // Degree
            "′",    // Minute
            "″"     // Second
        };

        /// <summary>
        /// Create new Angle object
        /// </summary>
        /// <param name="value">Angle value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Angle(double value, Units unit)
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
            if ((obj is Angle) == false) { return false; }
            
            return Equals((Angle)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public Angle ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Angle other)
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
        public Angle As(Units target)
        {
            return new Angle(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Angle other)
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
        public Angle Sqrt()
        {
            return new Angle(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Cbrt()
        {
            return new Angle(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Log()
        {
            return new Angle(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Log2()
        {
            return new Angle(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Log10()
        {
            return new Angle(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Pow(double exp)
        {
            return new Angle(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Angle Abs()
        {
            return new Angle(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Floor()
        {
            return new Angle(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Ceiling()
        {
            return new Angle(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Truncate()
        {
            return new Angle(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Round()
        {
            return new Angle(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Angle Round(int digits)
        {
            return new Angle(Math.Round(Value, digits), Unit);
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
        public static Angle Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Angle(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Angle result)
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
                result = default(Angle);
                return false;
            }
        }

        #region OperatorOverloading

        public static Angle operator++(Angle value)
        {
            return new Angle(value.Value + 1, value.Unit);
        }

        public static Angle operator--(Angle value)
        {
            return new Angle(value.Value - 1, value.Unit);
        }

        public static Angle operator/(Angle value, double scalar)
        {
            return new Angle(value.Value / scalar, value.Unit);
        }

        public static Angle operator*(Angle value, double scalar)
        {
            return new Angle(value.Value * scalar, value.Unit);
        }

        public static Angle operator*(double scalar, Angle value)
        {
            return new Angle(value.Value * scalar, value.Unit);
        }

        public static Angle operator-(Angle a)
        {
            return new Angle(-a.Value, a.Unit);
        }

        public static Angle operator-(Angle a, Angle b)
        {
            if (a.Unit == b.Unit)
            {
                return new Angle(a.Value - b.Value, a.Unit);
            }

            return new Angle(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Angle operator+(Angle a, Angle b)
        {
            if (a.Unit == b.Unit)
            {
                return new Angle(a.Value + b.Value, a.Unit);
            }

            return new Angle(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Angle a, Angle b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Angle a, Angle b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Angle a, Angle b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Angle a, Angle b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Angle a, Angle b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Angle a, Angle b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Angle a, Angle b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Angle operator%(Angle a, double b)
        {
            return new Angle(a.Value % b, a.Unit);
        }

        #endregion

        #region Trig

        public double Sin() { return Math.Sin(this.BaseValue()); }

        public double Cos() { return Math.Cos(this.BaseValue()); }

        public double Tan() { return Math.Tan(this.BaseValue()); }

        public double Sinh() { return Math.Sinh(this.BaseValue()); }

        public double Cosh() { return Math.Cosh(this.BaseValue()); }

        public double Tanh() { return Math.Tanh(this.BaseValue()); }

        public static Angle Asin(double value)
        {
            return new Angle(Math.Asin(value), Angle.BaseUnit);
        }

        public static Angle Acos(double value)
        {
            return new Angle(Math.Acos(value), Angle.BaseUnit);
        }

        public static Angle Atan(double value)
        {
            return new Angle(Math.Atan(value), Angle.BaseUnit);
        }

        public static Angle Atan2(double y, double x)
        {
            return new Angle(Math.Atan2(y, x), Angle.BaseUnit);
        }

        public static Angle Asinh(double value)
        {
            return new Angle(Math.Asinh(value), Angle.BaseUnit);
        }

        public static Angle Acosh(double value)
        {
            return new Angle(Math.Acosh(value), Angle.BaseUnit);
        }

        public static Angle Atanh(double value)
        {
            return new Angle(Math.Atanh(value), Angle.BaseUnit);
        }
        
        #endregion
    }
}
