using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents ChemicalAmountConcentration Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct ChemicalAmountConcentration : IQuantity<ChemicalAmountConcentration>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.MolePerCubicMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "mol/m³";

        /// <summary> Supported units of measure for ChemicalAmountConcentration Quantity type </summary>
        public enum Units
        {
            MolePerCubicMeter,
            MolePerCubicDecimeter,
            MolePerCubicCentimeter,
            MolePerCubicMillimeter,
            MolePerCubicDecameter,
            MolePerCubicHectoMeter,
            MolePerCubicKilometer,
            MolePerCubicInch,
            MolePerCubicFoot,
            MolePerCubicYard,
            MolePerCubicMile,
            MolePerLiter,
            MolePerDeciliter,
            MolePerCentiliter,
            MolePerMilliliter,
            MolePerGallon,
            MolePerQuart,
            MolePerPint,
            MolePerCup,
            MolePerFluidOunce
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0, // MolePerCubicMeter,
            1.0, // MolePerCubicDecimeter,
            1.0, // MolePerCubicCentimeter,
            1.0, // MolePerCubicMillimeter,
            1.0, // MolePerCubicDecameter,
            1.0, // MolePerCubicHectoMeter,
            1.0, // MolePerCubicKilometer,
            USCustomary.CUBICFOOT2CUBICMETER / 1728,                // MolePerCubicInch,
            USCustomary.CUBICFOOT2CUBICMETER,                       // MolePerCubicFoot,
            USCustomary.CUBICFOOT2CUBICMETER * 27,                  // MolePerCubicYard,
            USCustomary.CUBICFOOT2CUBICMETER * 5280 * 5280 * 5280,  // MolePerCubicMile,
            1.0e3, // MolePerLiter,
            1.0e4, // MolePerDeciliter,
            1.0e5, // MolePerCentiliter,
            1.0e6, // MolePerMilliliter,
            USCustomary.Gallon.Factor,      // MolePerGallon,
            USCustomary.Quart.Factor,       // MolePerQuart,
            USCustomary.Pint.Factor,        // MolePerPint,
            USCustomary.Cup.Factor,         // MolePerCup,
            USCustomary.FluidOnce.Factor,   // MolePerFluidOunce
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",   // MolePerCubicDecimeter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",  // MolePerCubicCentimeter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",  // MolePerCubicMillimeter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",   // MolePerCubicDecameter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",  // MolePerCubicHectoMeter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Cubed}",   // MolePerCubicKilometer,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Inch.Symbol}{Unicode.Cubed}",                   // MolePerCubicInch,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Foot.Symbol}{Unicode.Cubed}",                   // MolePerCubicFoot,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Yard.Symbol}{Unicode.Cubed}",                   // MolePerCubicYard,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Mile.Symbol}{Unicode.Cubed}",                   // MolePerCubicMile,
            $"{ChemicalAmount.BaseSymbol}/{Volume.LiterSymbol}",                        // MolePerLiter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Deci.Symbol}{Volume.LiterSymbol}",  // MolePerDeciliter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Centi.Symbol}{Volume.LiterSymbol}", // MolePerCentiliter,
            $"{ChemicalAmount.BaseSymbol}/{Prefixes.Milli.Symbol}{Volume.LiterSymbol}", // MolePerMilliliter,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Gallon.Symbol}",                 // MolePerGallon,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Quart.Symbol}",                  // MolePerQuart,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Pint.Symbol}",                   // MolePerPint,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.Cup.Symbol}",                    // MolePerCup,
            $"{ChemicalAmount.BaseSymbol}/{USCustomary.FluidOnce.Symbol}",              // MolePerFluidOunce
        };

        /// <summary>
        /// Create new ChemicalAmountConcentration object
        /// </summary>
        /// <param name="value">ChemicalAmountConcentration value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public ChemicalAmountConcentration(double value, Units unit)
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
            if ((obj is ChemicalAmountConcentration) == false) { return false; }
            
            return Equals((ChemicalAmountConcentration)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(ChemicalAmountConcentration other)
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
        public ChemicalAmountConcentration As(Units target)
        {
            return new ChemicalAmountConcentration(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(ChemicalAmountConcentration other)
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
        public ChemicalAmountConcentration Sqrt()
        {
            return new ChemicalAmountConcentration(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Cbrt()
        {
            return new ChemicalAmountConcentration(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Log()
        {
            return new ChemicalAmountConcentration(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Log2()
        {
            return new ChemicalAmountConcentration(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Log10()
        {
            return new ChemicalAmountConcentration(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Pow(double exp)
        {
            return new ChemicalAmountConcentration(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Abs()
        {
            return new ChemicalAmountConcentration(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Floor()
        {
            return new ChemicalAmountConcentration(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Ceiling()
        {
            return new ChemicalAmountConcentration(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Truncate()
        {
            return new ChemicalAmountConcentration(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Round()
        {
            return new ChemicalAmountConcentration(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public ChemicalAmountConcentration Round(int digits)
        {
            return new ChemicalAmountConcentration(Math.Round(Value, digits), Unit);
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
        public static ChemicalAmountConcentration Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new ChemicalAmountConcentration(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ChemicalAmountConcentration result)
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
                result = default(ChemicalAmountConcentration);
                return false;
            }
        }

        #region OperatorOverloading

        public static ChemicalAmountConcentration operator++(ChemicalAmountConcentration value)
        {
            return new ChemicalAmountConcentration(value.Value + 1, value.Unit);
        }

        public static ChemicalAmountConcentration operator--(ChemicalAmountConcentration value)
        {
            return new ChemicalAmountConcentration(value.Value - 1, value.Unit);
        }

        public static ChemicalAmountConcentration operator/(ChemicalAmountConcentration value, double scalar)
        {
            return new ChemicalAmountConcentration(value.Value / scalar, value.Unit);
        }

        public static ChemicalAmountConcentration operator*(ChemicalAmountConcentration value, double scalar)
        {
            return new ChemicalAmountConcentration(value.Value * scalar, value.Unit);
        }

        public static ChemicalAmountConcentration operator*(double scalar, ChemicalAmountConcentration value)
        {
            return new ChemicalAmountConcentration(value.Value * scalar, value.Unit);
        }

        public static ChemicalAmountConcentration operator-(ChemicalAmountConcentration a)
        {
            return new ChemicalAmountConcentration(-a.Value, a.Unit);
        }

        public static ChemicalAmountConcentration operator-(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            if (a.Unit == b.Unit)
            {
                return new ChemicalAmountConcentration(a.Value - b.Value, a.Unit);
            }

            return new ChemicalAmountConcentration(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static ChemicalAmountConcentration operator+(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            if (a.Unit == b.Unit)
            {
                return new ChemicalAmountConcentration(a.Value + b.Value, a.Unit);
            }

            return new ChemicalAmountConcentration(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(ChemicalAmountConcentration a, ChemicalAmountConcentration b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static ChemicalAmountConcentration operator%(ChemicalAmountConcentration a, double b)
        {
            return new ChemicalAmountConcentration(a.Value % b, a.Unit);
        }

        #endregion
    }
}
