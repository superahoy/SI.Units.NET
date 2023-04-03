using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Temperature Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct Temperature : IQuantity<Temperature>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Kelvin;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "°K";

        /// <summary> Offset from 0°K to 0°C </summary>
        public const double KELVIN2CELSIUS = -273.15;
        
        /// <summary> Offset from 0°C to 0°K </summary>
        public const double CELSIUS2KELVIN = 273.15;

        /// <summary> Offset from 0°R to 0°F </summary>
        public const double RANKINE2FAHRENHEIT = -459.67;

        /// <summary> Offset from 0°F to 0°R </summary>
        public const double FAHRENHEIT2RANKINE = -459.67;

        /// <summary> Supported units of measure for Temperature Quantity type </summary>
        public enum Units
        {
            Kelvin,            
            Celsius,
            Fahrenheit,
            Rankine
        };

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // Kelvin
            "°C",       // Celsius
            "°F",       // Fahrenheit
            "°R"        // Rankine
        };

        /// <summary>
        /// Create new Temperature object
        /// </summary>
        /// <param name="value">Temperature value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public Temperature(double value, Units unit)
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
            if ((obj is Temperature) == false) { return false; }
            
            return Equals((Temperature)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            switch (Unit) 
            {                 
                case Units.Celsius:
                    return Value + CELSIUS2KELVIN;
                case Units.Fahrenheit:
                    return (Value - 32.0) * 5.0/9.0 + CELSIUS2KELVIN;
                case Units.Rankine:
                    return (Value + RANKINE2FAHRENHEIT - 32.0) * 5.0/9.0 + CELSIUS2KELVIN;
                case Units.Kelvin:
                default:
                    return Value;
            }
        }

        /// <inheritdoc/>
        public Temperature ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(Temperature other)
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
        public Temperature As(Units target)
        {
            var kelvin = BaseValue();

            switch (target) 
            {
                case Units.Celsius:
                    return new Temperature(kelvin + KELVIN2CELSIUS, Units.Celsius);
                case Units.Fahrenheit:
                    return new Temperature((kelvin + KELVIN2CELSIUS) * 9.0/5.0 + 32, Units.Fahrenheit);
                case Units.Rankine:
                    return new Temperature(kelvin * 9.0 / 5.0, Units.Rankine);
                case Units.Kelvin:
                default:
                    return new Temperature(kelvin, Units.Kelvin);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(Temperature other)
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
        public Temperature Sqrt()
        {
            return new Temperature(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Cbrt()
        {
            return new Temperature(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Log()
        {
            return new Temperature(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Log2()
        {
            return new Temperature(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Log10()
        {
            return new Temperature(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Pow(double exp)
        {
            return new Temperature(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public Temperature Abs()
        {
            return new Temperature(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Floor()
        {
            return new Temperature(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Ceiling()
        {
            return new Temperature(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Truncate()
        {
            return new Temperature(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Round()
        {
            return new Temperature(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public Temperature Round(int digits)
        {
            return new Temperature(Math.Round(Value, digits), Unit);
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
        public static Temperature Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new Temperature(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Temperature result)
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
                result = default(Temperature);
                return false;
            }
        }

        #region OperatorOverloading

        public static Temperature operator++(Temperature value)
        {
            return new Temperature(value.Value + 1, value.Unit);
        }

        public static Temperature operator--(Temperature value)
        {
            return new Temperature(value.Value - 1, value.Unit);
        }

        public static Temperature operator/(Temperature value, double scalar)
        {
            return new Temperature(value.Value / scalar, value.Unit);
        }

        public static Temperature operator*(Temperature value, double scalar)
        {
            return new Temperature(value.Value * scalar, value.Unit);
        }

        public static Temperature operator*(double scalar, Temperature value)
        {
            return new Temperature(value.Value * scalar, value.Unit);
        }

        public static Temperature operator-(Temperature a)
        {
            return new Temperature(-a.Value, a.Unit);
        }

        public static Temperature operator-(Temperature a, Temperature b)
        {
            if (a.Unit == b.Unit)
            {
                return new Temperature(a.Value - b.Value, a.Unit);
            }

            return new Temperature(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static Temperature operator+(Temperature a, Temperature b)
        {
            if (a.Unit == b.Unit)
            {
                return new Temperature(a.Value + b.Value, a.Unit);
            }

            return new Temperature(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(Temperature a, Temperature b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(Temperature a, Temperature b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(Temperature a, Temperature b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(Temperature a, Temperature b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(Temperature a, Temperature b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(Temperature a, Temperature b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(Temperature a, Temperature b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static Temperature operator%(Temperature a, double b)
        {
            return new Temperature(a.Value % b, a.Unit);
        }

        #endregion
    }
}
