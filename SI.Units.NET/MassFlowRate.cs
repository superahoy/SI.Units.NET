using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents MassFlowRate Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct MassFlowRate : IQuantity<MassFlowRate>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.KilogramPerSecond;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "kg/s";

        /// <summary> Supported units of measure for MassFlowRate Quantity type </summary>
        public enum Units
        {
            KilogramPerSecond,
            KilogramPerMinute,
            KilogramPerHour,

            HectogramPerSecond,
            HectogramPerMinute,
            HectogramPerHour,

            DecagramPerSecond,
            DecagramPerMinute,
            DecagramPerHour,

            GramPerSecond,
            GramPerMinute,
            GramPerHour,

            DecigramPerSecond,
            DecigramPerMinute,
            DecigramPerHour,

            CentigramPerSecond,
            CentigramPerMinute,
            CentigramPerHour,

            MilligramPerSecond,
            MilligramPerMinute,
            MilligramPerHour,

            OuncePerSecond,
            OuncePerMinute,
            OuncePerHour,

            PoundPerSecond,
            PoundPerMinute,
            PoundPerHour,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                        // KilogramPerSecond,
            1.0 / Time.MinuteValue,     // KilogramPerMinute,
            1.0 / Time.HourValue,       // KilogramPerHour,

            1.0e-1,                     // HectogramPerSecond,
            1.0e-1 / Time.MinuteValue,  // HectogramPerMinute,
            1.0e-1 / Time.HourValue,    // HectogramPerHour,

            1.0e-2,                     // DecagramPerSecond,
            1.0e-2 / Time.MinuteValue,  // DecagramPerMinute,
            1.0e-2 / Time.HourValue,    // DecagramPerHour,

            1.0e-3,                     // GramPerSecond,
            1.0e-3 / Time.MinuteValue,  // GramPerMinute,
            1.0e-3 / Time.HourValue,    // GramPerHour,

            1.0e-4,                     // DecigramPerSecond,
            1.0e-4 / Time.MinuteValue,  // DecigramPerMinute,
            1.0e-4 / Time.HourValue,    // DecigramPerHour,

            1.0e-5,                     // CentigramPerSecond,
            1.0e-5 / Time.MinuteValue,  // CentigramPerMinute,
            1.0e-5 / Time.HourValue,    // CentigramPerHour,

            1.0e-6,                     // MilligramPerSecond,
            1.0e-6 / Time.MinuteValue,  // MilligramPerMinute,
            1.0e-6 / Time.HourValue,    // MilligramPerHour,

            USCustomary.Ounce.Factor,                       // OuncePerSecond
            USCustomary.Ounce.Factor / Time.MinuteValue,    // OuncePerMinute
            USCustomary.Ounce.Factor / Time.HourValue,      // OuncePerHour
            
            USCustomary.Pound.Factor,                       // OuncePerSecond
            USCustomary.Pound.Factor / Time.MinuteValue,    // OuncePerMinute
            USCustomary.Pound.Factor / Time.HourValue,      // OuncePerHour

        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // KilogramPerSecond,
            "kg/min",   // KilogramPerMinute,
            "kg/hr",    // KilogramPerHour,

            "hg/s",     // HectogramPerSecond,
            "hg/min",   // HectogramPerMinute,
            "hg/hr",    // HectogramPerHour,

            "dag/s",    // DecagramPerSecond,
            "dag/min",  // DecagramPerMinute,
            "dag/hr",   // DecagramPerHour,

            "g/s",      // GramPerSecond,
            "g/min",    // GramPerMinute,
            "g/hr",     // GramPerHour,

            "dg/s",     // DecigramPerSecond,
            "dg/min",   // DecigramPerMinute,
            "dg/hr",    // DecigramPerHour,

            "cg/s",     // CentigramPerSecond,
            "cg/min",   // CentigramPerMinute,
            "cg/hr",    // CentigramPerHour,

            "mg/s",     // MilligramPerSecond,
            "mg/min",   // MilligramPerMinute,
            "mg/hr",    // MilligramPerHour,

            "oz/s",     // OuncePerSecond,
            "oz/min",   // OuncePerMinute,
            "oz/hr",    // OuncePerHour,

            "lb/s",     // PoundPerSecond,
            "lb/min",   // PoundPerMinute,
            "lib/hr",   // PoundPerHour,
        };

        /// <summary>
        /// Create new MassFlowRate object
        /// </summary>
        /// <param name="value">MassFlowRate value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public MassFlowRate(double value, Units unit)
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
            if ((obj is MassFlowRate) == false) { return false; }
            
            return Equals((MassFlowRate)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public MassFlowRate ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(MassFlowRate other)
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
        public MassFlowRate As(Units target)
        {
            return new MassFlowRate(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(MassFlowRate other)
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
        public MassFlowRate Sqrt()
        {
            return new MassFlowRate(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Cbrt()
        {
            return new MassFlowRate(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Log()
        {
            return new MassFlowRate(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Log2()
        {
            return new MassFlowRate(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Log10()
        {
            return new MassFlowRate(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Pow(double exp)
        {
            return new MassFlowRate(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Abs()
        {
            return new MassFlowRate(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Floor()
        {
            return new MassFlowRate(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Ceiling()
        {
            return new MassFlowRate(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Truncate()
        {
            return new MassFlowRate(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Round()
        {
            return new MassFlowRate(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public MassFlowRate Round(int digits)
        {
            return new MassFlowRate(Math.Round(Value, digits), Unit);
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
        public static MassFlowRate Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new MassFlowRate(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MassFlowRate result)
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
                result = default(MassFlowRate);
                return false;
            }
        }

        #region OperatorOverloading

        public static MassFlowRate operator++(MassFlowRate value)
        {
            return new MassFlowRate(value.Value + 1, value.Unit);
        }

        public static MassFlowRate operator--(MassFlowRate value)
        {
            return new MassFlowRate(value.Value - 1, value.Unit);
        }

        public static MassFlowRate operator/(MassFlowRate value, double scalar)
        {
            return new MassFlowRate(value.Value / scalar, value.Unit);
        }

        public static MassFlowRate operator*(MassFlowRate value, double scalar)
        {
            return new MassFlowRate(value.Value * scalar, value.Unit);
        }

        public static MassFlowRate operator*(double scalar, MassFlowRate value)
        {
            return new MassFlowRate(value.Value * scalar, value.Unit);
        }

        public static MassFlowRate operator-(MassFlowRate a)
        {
            return new MassFlowRate(-a.Value, a.Unit);
        }

        public static MassFlowRate operator-(MassFlowRate a, MassFlowRate b)
        {
            if (a.Unit == b.Unit)
            {
                return new MassFlowRate(a.Value - b.Value, a.Unit);
            }

            return new MassFlowRate(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static MassFlowRate operator+(MassFlowRate a, MassFlowRate b)
        {
            if (a.Unit == b.Unit)
            {
                return new MassFlowRate(a.Value + b.Value, a.Unit);
            }

            return new MassFlowRate(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(MassFlowRate a, MassFlowRate b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(MassFlowRate a, MassFlowRate b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(MassFlowRate a, MassFlowRate b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(MassFlowRate a, MassFlowRate b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(MassFlowRate a, MassFlowRate b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(MassFlowRate a, MassFlowRate b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(MassFlowRate a, MassFlowRate b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static MassFlowRate operator%(MassFlowRate a, double b)
        {
            return new MassFlowRate(a.Value % b, a.Unit);
        }

        public static Mass operator*(MassFlowRate a, Time b) 
        {
            return new Mass(a.BaseValue() * b.BaseValue(), Mass.BaseUnit);
        }

        #endregion
    }
}
