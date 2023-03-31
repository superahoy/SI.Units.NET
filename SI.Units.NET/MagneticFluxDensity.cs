using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents MagneticFluxDensity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct MagneticFluxDensity : IQuantity<MagneticFluxDensity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.Tesla;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "T";

        /// <summary> Supported units of measure for MagneticFluxDensity Quantity type </summary>
        public enum Units
        {
            Tesla,
            Decitesla,
            Centitesla,
            Millitesla,
            Microtesla,
            Nanotesla,
            Picotesla,
            Femtotesla,
            Decatesla,
            Hectotesla,
            Kilotesla,
            Megatesla,
            Gigatesla,
            Teratesla,
            Petatesla
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // Tesla
            Prefixes.Deci.Factor,   // Decitesla
            Prefixes.Centi.Factor,  // Centitesla
            Prefixes.Milli.Factor,  // Millitesla
            Prefixes.Micro.Factor,  // Microtesla
            Prefixes.Nano.Factor,   // Nanotesla
            Prefixes.Pico.Factor,   // Picotesla
            Prefixes.Femto.Factor,  // Femtotesla
            Prefixes.Deca.Factor,   // Decatesla
            Prefixes.Hecto.Factor,  // Hectotesla
            Prefixes.Kilo.Factor,   // Kilotesla
            Prefixes.Mega.Factor,   // Megatesla
            Prefixes.Giga.Factor,   // Gigatesla
            Prefixes.Tera.Factor,   // Teratesla
            Prefixes.Peta.Factor,   // Petatesla
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
        /// Create new MagneticFluxDensity object
        /// </summary>
        /// <param name="value">MagneticFluxDensity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public MagneticFluxDensity(double value, Units unit)
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
            if ((obj is MagneticFluxDensity) == false) { return false; }
            
            return Equals((MagneticFluxDensity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public MagneticFluxDensity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(MagneticFluxDensity other)
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
        public MagneticFluxDensity As(Units target)
        {
            return new MagneticFluxDensity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(MagneticFluxDensity other)
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
        public MagneticFluxDensity Sqrt()
        {
            return new MagneticFluxDensity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Cbrt()
        {
            return new MagneticFluxDensity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Log()
        {
            return new MagneticFluxDensity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Log2()
        {
            return new MagneticFluxDensity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Log10()
        {
            return new MagneticFluxDensity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Pow(double exp)
        {
            return new MagneticFluxDensity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Abs()
        {
            return new MagneticFluxDensity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Floor()
        {
            return new MagneticFluxDensity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Ceiling()
        {
            return new MagneticFluxDensity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Truncate()
        {
            return new MagneticFluxDensity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Round()
        {
            return new MagneticFluxDensity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public MagneticFluxDensity Round(int digits)
        {
            return new MagneticFluxDensity(Math.Round(Value, digits), Unit);
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
        public static MagneticFluxDensity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new MagneticFluxDensity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MagneticFluxDensity result)
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
                result = default(MagneticFluxDensity);
                return false;
            }
        }

        #region OperatorOverloading

        public static MagneticFluxDensity operator++(MagneticFluxDensity value)
        {
            return new MagneticFluxDensity(value.Value + 1, value.Unit);
        }

        public static MagneticFluxDensity operator--(MagneticFluxDensity value)
        {
            return new MagneticFluxDensity(value.Value - 1, value.Unit);
        }

        public static MagneticFluxDensity operator/(MagneticFluxDensity value, double scalar)
        {
            return new MagneticFluxDensity(value.Value / scalar, value.Unit);
        }

        public static MagneticFluxDensity operator*(MagneticFluxDensity value, double scalar)
        {
            return new MagneticFluxDensity(value.Value * scalar, value.Unit);
        }

        public static MagneticFluxDensity operator*(double scalar, MagneticFluxDensity value)
        {
            return new MagneticFluxDensity(value.Value * scalar, value.Unit);
        }

        public static MagneticFluxDensity operator-(MagneticFluxDensity a)
        {
            return new MagneticFluxDensity(-a.Value, a.Unit);
        }

        public static MagneticFluxDensity operator-(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFluxDensity(a.Value - b.Value, a.Unit);
            }

            return new MagneticFluxDensity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static MagneticFluxDensity operator+(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new MagneticFluxDensity(a.Value + b.Value, a.Unit);
            }

            return new MagneticFluxDensity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(MagneticFluxDensity a, MagneticFluxDensity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static MagneticFluxDensity operator%(MagneticFluxDensity a, double b)
        {
            return new MagneticFluxDensity(a.Value % b, a.Unit);
        }

        #endregion
    }
}
