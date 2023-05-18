using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents Volumetric FlowRate Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct VolumetricFlowRate : IQuantity<VolumetricFlowRate>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.CubicMeterPerSecond;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "m³/s";

        /// <summary> Supported units of measure for FlowRate Quantity type </summary>
        public enum Units
        {
            CubicMeterPerSecond,
            CubicMeterPerMinute,
            CubicMeterPerHour,
            
            CubicDecimeterPerMinute,
            CubicDecimeterPerSecond,
            CubicDecimeterPerHour,
            
            CubicCentimeterPerSecond,
            CubicCentimeterPerMinute,
            CubicCentimeterPerHour,
            
            CubicMillimeterPerSecond,
            CubicMillimeterPerMinute,
            CubicMillimeterPerHour,
            
            CubicDecameterPerSecond,
            CubicDecameterPerMinute,
            CubicDecameterPerHour,
            
            CubicHectometerPerSecond,
            CubicHectometerPerMinute,
            CubicHectometerPerHour,
            
            CubicKilometerPerSecond,
            CubicKilometerPerMinute,
            CubicKilometerPerHour,
            
            CubicInchPerSecond,
            CubicInchPerMinute,
            CubicInchPerHour,

            CubicFootPerSecond,
            CubicFootPerMinute,
            CubicFootPerHour,
            
            CubicYardPerSecond,
            CubicYardPerMinute,
            CubicYardPerHour,

            CubicMilePerSecond,
            CubicMilePerMinute,
            CubicMilePerHour,

            LiterPerSecond,
            LiterPerMinute,
            LiterPerHour,
            
            DeciliterPerSecond,
            DeciliterPerMinute,
            DeciliterPerHour,

            CentiliterPerSecond,
            CentiliterPerMinute,
            CentiliterPerHour,

            MilliliterPerSecond,
            MilliliterPerMinute,
            MilliliterPerHour,

            GallonPerSecondPerSecond,
            GallonPerMinute,
            GallonPerHourPerHour,
            
            QuartPerSecond,
            QuartPerMinute,
            QuartPerHour,

            PintPerSecond,
            PintPerMinute,
            PintPerHour,
            
            FluidOuncePerSecond,
            FluidOuncePerMinute,
            FluidOuncePerHour
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,                    // CubicMeterPerSecond
            1.0 / Time.MinuteValue, // CubicMeterPerMinute
            1.0 / Time.HourValue,   // CubicMeterPerHour
            
            Math.Pow(Prefixes.Deci.Factor,3),                       // CubicDecimeterPerMinute
            Math.Pow(Prefixes.Deci.Factor,3) / Time.MinuteValue,    // CubicDecimeterPerSecond
            Math.Pow(Prefixes.Deci.Factor,3) / Time.HourValue,      // CubicDecimeterPerHour
            
            Math.Pow(Prefixes.Centi.Factor,3),                      // CubicCentimeterPerSecond
            Math.Pow(Prefixes.Centi.Factor,3) / Time.MinuteValue,   // CubicCentimeterPerMinute
            Math.Pow(Prefixes.Centi.Factor,3) / Time.HourValue,     // CubicCentimeterPerHour
            
            Math.Pow(Prefixes.Milli.Factor,3),                      // CubicMillimeterPerSecond
            Math.Pow(Prefixes.Milli.Factor,3) / Time.MinuteValue,   // CubicMillimeterPerMinute
            Math.Pow(Prefixes.Milli.Factor,3) / Time.HourValue,     // CubicMillimeterPerHour
            
            Math.Pow(Prefixes.Deca.Factor,3),                       // CubicDecameterPerSecond
            Math.Pow(Prefixes.Deca.Factor,3) / Time.MinuteValue,    // CubicDecameterPerMinute
            Math.Pow(Prefixes.Deca.Factor,3) / Time.HourValue,      // CubicDecameterPerHour
            
            Math.Pow(Prefixes.Hecto.Factor,3),                      // CubicHectometerPerSecond
            Math.Pow(Prefixes.Hecto.Factor,3) / Time.MinuteValue,   // CubicHectometerPerMinute
            Math.Pow(Prefixes.Hecto.Factor,3) / Time.HourValue,     // CubicHectometerPerHour
            
            Math.Pow(Prefixes.Kilo.Factor,3),                       // CubicKilometerPerSecond
            Math.Pow(Prefixes.Kilo.Factor,3) / Time.MinuteValue,    // CubicKilometerPerMinute
            Math.Pow(Prefixes.Kilo.Factor,3) / Time.HourValue,      // CubicKilometerPerHour
            
            USCustomary.CUBICFOOT2CUBICMETER / 1728.0,                    // CubicInchPerSecond
            USCustomary.CUBICFOOT2CUBICMETER / 1728.0 / Time.MinuteValue, // CubicInchPerMinute
            USCustomary.CUBICFOOT2CUBICMETER / 1728.0 / Time.HourValue,   // CubicInchPerHour

            USCustomary.CUBICFOOT2CUBICMETER,                    // CubicFootPerSecond
            USCustomary.CUBICFOOT2CUBICMETER / Time.MinuteValue, // CubicFootPerMinute
            USCustomary.CUBICFOOT2CUBICMETER / Time.HourValue,   // CubicFootPerHour
            
            USCustomary.CUBICFOOT2CUBICMETER * 27.0,                    // CubicYardPerSecond
            USCustomary.CUBICFOOT2CUBICMETER * 27.0 / Time.MinuteValue, // CubicYardPerMinute
            USCustomary.CUBICFOOT2CUBICMETER * 27.0 / Time.HourValue,   // CubicYardPerHour

            USCustomary.CUBICFOOT2CUBICMETER * 5280 * 5280 * 5280,                    // CubicMilePerSecond
            USCustomary.CUBICFOOT2CUBICMETER * 5280 * 5280 * 5280 / Time.MinuteValue, // CubicMilePerMinute
            USCustomary.CUBICFOOT2CUBICMETER * 5280 * 5280 * 5280 / Time.HourValue,   // CubicMilePerHour

            1.0e-3,                    // LiterPerSecond
            1.0e-3 / Time.MinuteValue, // LiterPerMinute
            1.0e-3 / Time.HourValue,   // LiterPerHour
            
            1.0e-4,                    // DeciliterPerSecond
            1.0e-4 / Time.MinuteValue, // DeciliterPerMinute
            1.0e-4 / Time.HourValue,   // DeciliterPerHour

            1.0e-5,                    // CentiliterPerSecond
            1.0e-5 / Time.MinuteValue, // CentiliterPerMinute
            1.0e-5 / Time.HourValue,   // CentiliterPerHour

            1.0e-6,                    // MilliliterPerSecond
            1.0e-6 / Time.MinuteValue, // MilliliterPerMinute
            1.0e-6 / Time.HourValue,   // MilliliterPerHour

            USCustomary.Gallon.Factor,                          // GallonPerSecondPerSecond
            USCustomary.Gallon.Factor / Time.MinuteValue,       // GallonPerMinute
            USCustomary.Gallon.Factor / Time.HourValue,         // GallonPerHourPerHour
            
            USCustomary.Quart.Factor,                           // QuartPerSecond
            USCustomary.Quart.Factor / Time.MinuteValue,        // QuartPerMinute
            USCustomary.Quart.Factor / Time.HourValue,          // QuartPerHour

            USCustomary.Pint.Factor,                            // PintPerSecond
            USCustomary.Pint.Factor / Time.MinuteValue,         // PintPerMinute
            USCustomary.Pint.Factor / Time.HourValue,           // PintPerHour
            
            USCustomary.FluidOnce.Factor,                       // FluidOuncePerSecond
            USCustomary.FluidOnce.Factor / Time.MinuteValue,    // FluidOuncePerMinute
            USCustomary.FluidOnce.Factor / Time.HourValue,      // FluidOuncePerHour
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // CubicMeterPerSecond,
            $"{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",  // CubicMeterPerMinute,
            $"{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",    // CubicMeterPerHour,
            
            $"{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicDecimeterPerSecond,
            $"{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicDecimeterPerMinute,
            $"{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicDecimeterPerHour,
            
            $"{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",     // CubicCentimeterPerSecond,
            $"{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",   // CubicCentimeterPerMinute,
            $"{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",     // CubicCentimeterPerHour,
            
            $"{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",     // CubicMillimeterPerSecond,
            $"{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",   // CubicMillimeterPerMinute,
            $"{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",     // CubicMillimeterPerHour,
            
            $"{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicDecameterPerSecond,
            $"{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicDecameterPerMinute,
            $"{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicDecameterPerHour,
            
            $"{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",     // CubicHectometerPerSecond,
            $"{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",   // CubicHectometerPerMinute,
            $"{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",     // CubicHectometerPerHour,
            
            $"{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicKilometerPerSecond,
            $"{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicKilometerPerMinute,
            $"{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicKilometerPerHour,
            
            $"{USCustomary.Inch.Symbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicInchPerSecond,
            $"{USCustomary.Inch.Symbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicInchPerMinute,
            $"{USCustomary.Inch.Symbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicInchPerHour,

            $"{USCustomary.Foot.Symbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicFootPerSecond,
            $"{USCustomary.Foot.Symbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicFootPerMinute,
            $"{USCustomary.Foot.Symbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicFootPerHour,
            
            $"{USCustomary.Yard.Symbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicYardPerSecond,
            $"{USCustomary.Yard.Symbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicYardPerMinute,
            $"{USCustomary.Yard.Symbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicYardPerHour,

            $"{USCustomary.Mile.Symbol}{Unicode.Cubed}/{Time.BaseSymbol}",      // CubicMilePerSecond,
            $"{USCustomary.Mile.Symbol}{Unicode.Cubed}/{Time.MinuteSymbol}",    // CubicMilePerMinute,
            $"{USCustomary.Mile.Symbol}{Unicode.Cubed}/{Time.HourSymbol}",      // CubicMilePerHour,

            $"{Volume.LiterSymbol}/{Time.BaseSymbol}",      // LiterPerSecond,
            $"{Volume.LiterSymbol}/{Time.MinuteSymbol}",    // LiterPerMinute,
            $"{Volume.LiterSymbol}/{Time.HourSymbol}",      // LiterPerHour,
            
            $"{Prefixes.Deci.Symbol}{Volume.LiterSymbol}/{Time.BaseSymbol}",    // DeciliterPerSecond,
            $"{Prefixes.Deci.Symbol}{Volume.LiterSymbol}/{Time.MinuteSymbol}",  // DeciliterPerMinute,
            $"{Prefixes.Deci.Symbol}{Volume.LiterSymbol}/{Time.HourSymbol}",    // DeciliterPerHour,

            $"{Prefixes.Centi.Symbol}{Volume.LiterSymbol}/{Time.BaseSymbol}",   // CentiliterPerSecond,
            $"{Prefixes.Centi.Symbol}{Volume.LiterSymbol}/{Time.MinuteSymbol}", // CentiliterPerMinute,
            $"{Prefixes.Centi.Symbol}{Volume.LiterSymbol}/{Time.HourSymbol}",   // CentiliterPerHour,

            $"{Prefixes.Milli.Symbol}{Volume.LiterSymbol}/{Time.BaseSymbol}",   // MilliliterPerSecond,
            $"{Prefixes.Milli.Symbol}{Volume.LiterSymbol}/{Time.MinuteSymbol}", // MilliliterPerMinute,
            $"{Prefixes.Milli.Symbol}{Volume.LiterSymbol}/{Time.HourSymbol}",   // MilliliterPerHour,

            $"{USCustomary.Gallon.Symbol}/{Time.BaseSymbol}",   // GallonPerSecondPerSecond,
            $"{USCustomary.Gallon.Symbol}/{Time.MinuteSymbol}", // GallonPerMinute,
            $"{USCustomary.Gallon.Symbol}/{Time.HourSymbol}",   // GallonPerHourPerHour,
            
            $"{USCustomary.Quart.Symbol}/{Time.BaseSymbol}",    // QuartPerSecond,
            $"{USCustomary.Quart.Symbol}/{Time.MinuteSymbol}",  // QuartPerMinute,
            $"{USCustomary.Quart.Symbol}/{Time.HourSymbol}",    // QuartPerHour,

            $"{USCustomary.Pint.Symbol}/{Time.BaseSymbol}",     // PintPerSecond,
            $"{USCustomary.Pint.Symbol}/{Time.MinuteSymbol}",   // PintPerMinute,
            $"{USCustomary.Pint.Symbol}/{Time.HourSymbol}",     // PintPerHour,
            
            $"{USCustomary.FluidOnce.Symbol}/{Time.BaseSymbol}",    // FluidOuncePerSecond,
            $"{USCustomary.FluidOnce.Symbol}/{Time.MinuteSymbol}",  // FluidOuncePerMinute,
            $"{USCustomary.FluidOnce.Symbol}/{Time.HourSymbol}",    // FluidOuncePerHour
        };

        /// <summary>
        /// Create new FlowRate object
        /// </summary>
        /// <param name="value">FlowRate value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public VolumetricFlowRate(double value, Units unit)
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
            if ((obj is VolumetricFlowRate) == false) { return false; }
            
            return Equals((VolumetricFlowRate)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public VolumetricFlowRate ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(VolumetricFlowRate other)
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
        public VolumetricFlowRate As(Units target)
        {
            return new VolumetricFlowRate(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(VolumetricFlowRate other)
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
        public VolumetricFlowRate Sqrt()
        {
            return new VolumetricFlowRate(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Cbrt()
        {
            return new VolumetricFlowRate(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Log()
        {
            return new VolumetricFlowRate(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Log2()
        {
            return new VolumetricFlowRate(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Log10()
        {
            return new VolumetricFlowRate(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Pow(double exp)
        {
            return new VolumetricFlowRate(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Abs()
        {
            return new VolumetricFlowRate(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Floor()
        {
            return new VolumetricFlowRate(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Ceiling()
        {
            return new VolumetricFlowRate(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Truncate()
        {
            return new VolumetricFlowRate(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Round()
        {
            return new VolumetricFlowRate(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public VolumetricFlowRate Round(int digits)
        {
            return new VolumetricFlowRate(Math.Round(Value, digits), Unit);
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
        public static VolumetricFlowRate Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new VolumetricFlowRate(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out VolumetricFlowRate result)
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
                result = default(VolumetricFlowRate);
                return false;
            }
        }

        #region OperatorOverloading

        public static VolumetricFlowRate operator++(VolumetricFlowRate value)
        {
            return new VolumetricFlowRate(value.Value + 1, value.Unit);
        }

        public static VolumetricFlowRate operator--(VolumetricFlowRate value)
        {
            return new VolumetricFlowRate(value.Value - 1, value.Unit);
        }

        public static VolumetricFlowRate operator/(VolumetricFlowRate value, double scalar)
        {
            return new VolumetricFlowRate(value.Value / scalar, value.Unit);
        }

        public static VolumetricFlowRate operator*(VolumetricFlowRate value, double scalar)
        {
            return new VolumetricFlowRate(value.Value * scalar, value.Unit);
        }

        public static VolumetricFlowRate operator*(double scalar, VolumetricFlowRate value)
        {
            return new VolumetricFlowRate(value.Value * scalar, value.Unit);
        }

        public static VolumetricFlowRate operator-(VolumetricFlowRate a)
        {
            return new VolumetricFlowRate(-a.Value, a.Unit);
        }

        public static VolumetricFlowRate operator-(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            if (a.Unit == b.Unit)
            {
                return new VolumetricFlowRate(a.Value - b.Value, a.Unit);
            }

            return new VolumetricFlowRate(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static VolumetricFlowRate operator+(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            if (a.Unit == b.Unit)
            {
                return new VolumetricFlowRate(a.Value + b.Value, a.Unit);
            }

            return new VolumetricFlowRate(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(VolumetricFlowRate a, VolumetricFlowRate b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static VolumetricFlowRate operator%(VolumetricFlowRate a, double b)
        {
            return new VolumetricFlowRate(a.Value % b, a.Unit);
        }

        #endregion
    }
}
