using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents MagneticFlux Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct MagneticFlux : IQuantity<MagneticFlux>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Weber;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "Wb";

        /// <summary> Supported units of measure for MagneticFlux Quantity type </summary>
        public enum Units
        {
            Weber,
            Deciweber,
            Centiweber,
            Milliweber,
            Microweber,
            Nanoweber,
            Picoweber,
            Femtoweber,
            Decaweber,
            Hectoweber,
            Kiloweber,
            Megaweber,
            Gigaweber,
            Teraweber,
            Petaweber
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Weber
            Prefixes.Deci.Factor,   // Deciweber
            Prefixes.Centi.Factor,  // Centiweber
            Prefixes.Milli.Factor,  // Milliweber
            Prefixes.Micro.Factor,  // Microweber
            Prefixes.Nano.Factor,   // Nanoweber
            Prefixes.Pico.Factor,   // Picoweber
            Prefixes.Femto.Factor,  // Femtoweber
            Prefixes.Deca.Factor,   // Decaweber
            Prefixes.Hecto.Factor,  // Hectoweber
            Prefixes.Kilo.Factor,   // Kiloweber
            Prefixes.Mega.Factor,   // Megaweber
            Prefixes.Giga.Factor,   // Gigaweber
            Prefixes.Tera.Factor,   // Teraweber
            Prefixes.Peta.Factor,   // Petaweber
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
        /// Create new MagneticFlux object
        /// </summary>
        /// <param name="value">MagneticFlux value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public MagneticFlux(double value, Units unit)
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
            if ((obj is MagneticFlux) == false) { return false; }
            
            return Equals((MagneticFlux)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public MagneticFlux ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(MagneticFlux other)
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
        public MagneticFlux As(Units target)
        {
            return new MagneticFlux(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(MagneticFlux other)
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
        public MagneticFlux Sqrt()
        {
            return new MagneticFlux(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Cbrt()
        {
            return new MagneticFlux(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Log()
        {
            return new MagneticFlux(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Log2()
        {
            return new MagneticFlux(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Log10()
        {
            return new MagneticFlux(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Pow(double exp)
        {
            return new MagneticFlux(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Abs()
        {
            return new MagneticFlux(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Floor()
        {
            return new MagneticFlux(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Ceiling()
        {
            return new MagneticFlux(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Truncate()
        {
            return new MagneticFlux(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Round()
        {
            return new MagneticFlux(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFlux Round(int digits)
        {
            return new MagneticFlux(Math.Round(Value, digits), Unit);
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
        public static MagneticFlux Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new MagneticFlux(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MagneticFlux result)
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
                result = default(MagneticFlux);
                return false;
            }
        }

        #region OperatorOverloading

        public static MagneticFlux operator++(MagneticFlux value)
        {
            return new MagneticFlux(value.Value + 1, value.Unit);
        }

        public static MagneticFlux operator--(MagneticFlux value)
        {
            return new MagneticFlux(value.Value - 1, value.Unit);
        }

        public static MagneticFlux operator/(MagneticFlux value, double scalar)
        {
            return new MagneticFlux(value.Value / scalar, value.Unit);
        }

        public static MagneticFlux operator*(MagneticFlux value, double scalar)
        {
            return new MagneticFlux(value.Value * scalar, value.Unit);
        }

        public static MagneticFlux operator*(double scalar, MagneticFlux value)
        {
            return new MagneticFlux(value.Value * scalar, value.Unit);
        }

        public static MagneticFlux operator-(MagneticFlux a)
        {
            return new MagneticFlux(-a.Value, a.Unit);
        }

        public static MagneticFlux operator-(MagneticFlux a, MagneticFlux b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFlux(a.Value - b.Value, a.Unit);
            }

            return new MagneticFlux(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static MagneticFlux operator+(MagneticFlux a, MagneticFlux b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFlux(a.Value + b.Value, a.Unit);
            }

            return new MagneticFlux(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(MagneticFlux a, MagneticFlux b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(MagneticFlux a, MagneticFlux b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(MagneticFlux a, MagneticFlux b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(MagneticFlux a, MagneticFlux b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(MagneticFlux a, MagneticFlux b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(MagneticFlux a, MagneticFlux b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(MagneticFlux a, MagneticFlux b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static MagneticFlux operator%(MagneticFlux a, double b)
        {
            return new MagneticFlux(a.Value % b, a.Unit);
        }

        #endregion
    }
}
