using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SI.Units.NET
{
    /// <summary>
    /// Represents SurfaceDensity Base Quantity type from Table 2. SI base units
    /// </summary>
    public readonly struct SurfaceDensity : IQuantity<SurfaceDensity>
    {
        /// <summary> Base unit of measure </summary>
        public const Units BaseUnit = Units.KilogramPerSquareMeter;

        /// <summary> Base symbol </summary>
        public const string BaseSymbol = "kg/m²";

        /// <summary> Supported units of measure for SurfaceDensity Quantity type </summary>
        public enum Units
        {
            KilogramPerSquareMeter,
            KilogramPerSquareKilometer,
            KilogramPerSquareHectometer,
            KilogramPerSquareDecameter,
            KilogramPerSquareDecimeter,
            KilogramPerSquareCentimeter,
            KilogramPerSquareMillimeter,

            GramPerSquareKilometer,
            GramPerSquareHectometer,
            GramPerSquareDecameter,
            GramPerSquareMeter,
            GramPerSquareDecimeter,
            GramPerSquareCentimeter,
            GramPerSquareMillimeter,

            CentigramPerSquareKilometer,
            CentigramPerSquareHectometer,
            CentigramPerSquareDecameter,
            CentigramPerSquareMeter,
            CentigramPerSquareDecimeter,
            CentigramPerSquareCentimeter,
            CentigramPerSquareMillimeter,

            MilligramPerSquareKilometer,
            MilligramPerSquareHectometer,
            MilligramPerSquareDecameter,
            MilligramPerSquareMeter,
            MilligramPerSquareDecimeter,
            MilligramPerSquareCentimeter,
            MilligramPerSquareMillimeter,

            TonnePerSquareKilometer,
            TonnePerSquareHectometer,
            TonnePerSquareDecameter,
            TonnePerSquareMeter,
            TonnePerSquareDecimeter,
            TonnePerSquareCentimeter,
            TonnePerSquareMillimeter,

            OuncePerSquareInch,
            OuncePerSquareFoot,
            OuncePerSquareYard,
            OuncePerSquareMile,

            PoundPerSquareInch,
            PoundPerSquareFoot,
            PoundPerSquareYard,
            PoundPerSquareMile,

            TonPerSquareInch,
            TonPerSquareFoot,
            TonPerSquareYard,
            TonPerSquareMile,
        };

        /// <summary>
        /// Conversion factors from target unit to base unit.
        /// </summary>
        private static readonly double[] Factors =
        {
            1.0,        // KilogramPerSquareMeter,
            1.0e-6,     // KilogramPerSquareKilometer,
            1.0e-4,     // KilogramPerSquareHectometer,
            1.0e-2,     // KilogramPerSquareDecameter,
            1.0e+2,     // KilogramPerSquareDecimeter,
            1.0e+4,     // KilogramPerSquareCentimeter,
            1.0e+6,     // KilogramPerSquareMillimeter,

            1.0e-9,     // GramPerSquareKilometer
            1.0e-7,     // GramPerSquareHectometer,
            1.0e-5,     // GramPerSquareDecameter,
            1.0e-3,     // GramPerSquareMeter,
            0.1,        // GramPerSquareDecimeter,
            10.0,       // GramPerSquareCentimeter,
            1000,       // GramPerSquareMillimeter,

            1.0e-11,    // CentigramPerSquareKilometer,
            1.0e-9,     // CentigramPerSquareHectometer,
            1.0e-7,     // CentigramPerSquareDecameter,
            1.0e-5,     // CentigramPerSquareMeter,
            1.0e-3,     // CentigramPerSquareDecimeter,
            1.0e-1,     // CentigramPerSquareCentimeter,
            1.0e+2,     // CentigramPerSquareMillimeter,

            1.0e-12,    // MilligramPerSquareKilometer,
            1.0e-10,    // MilligramPerSquareHectometer,
            1.0e-8,     // MilligramPerSquareDecameter,
            1e-6,       // MilligramPerSquareMeter,
            1e-4,       // MilligramPerSquareDecimeter,
            1e-2,       // MilligramPerSquareCentimeter,
            1.0,        // MilligramPerSquareMillimeter,

            1.0e-3,     // TonnePerSquareKilometer,
            1.0e-1,     // TonnePerSquareHectometer,
            1.0e+1,     // TonnePerSquareDecameter,
            1.0e+3,     // TonnePerSquareMeter,
            1.0e+5,     // TonnePerSquareDecimeter,
            1.0e+7,     // TonnePerSquareCentimeter,
            1.0e+9,     // TonnePerSquareMillimeter,

            USCustomary.Ounce.Factor / Math.Pow(USCustomary.Inch.Factor, 2), // OuncePerSquareInch,
            USCustomary.Ounce.Factor / Math.Pow(USCustomary.Foot.Factor, 2), // OuncePerSquareFoot,
            USCustomary.Ounce.Factor / Math.Pow(USCustomary.Yard.Factor, 2), // OuncePerSquareYard,
            USCustomary.Ounce.Factor / Math.Pow(USCustomary.Mile.Factor, 2), // OuncePerSquareMile

            USCustomary.Pound.Factor / Math.Pow(USCustomary.Inch.Factor, 2), // PoundPerSquareInch,
            USCustomary.Pound.Factor / Math.Pow(USCustomary.Foot.Factor, 2), // PoundPerSquareFoot,
            USCustomary.Pound.Factor / Math.Pow(USCustomary.Yard.Factor, 2), // PoundPerSquareYard,
            USCustomary.Pound.Factor / Math.Pow(USCustomary.Mile.Factor, 2), // PoundPerSquareMile

            USCustomary.Ton.Factor / Math.Pow(USCustomary.Inch.Factor, 2),  // TonPerSquareInch,
            USCustomary.Ton.Factor / Math.Pow(USCustomary.Foot.Factor, 2),  // TonPerSquareFoot,
            USCustomary.Ton.Factor / Math.Pow(USCustomary.Yard.Factor, 2),  // TonPerSquareYard,
            USCustomary.Ton.Factor / Math.Pow(USCustomary.Mile.Factor, 2),  // TonPerSquareMile,
        };

        private static readonly double[] Inverse = Factors.Select(x => 1.0 / x).ToArray();

        /// <summary>
        /// Unit of measure symbols for each Unit. Order of
        /// array must match Units order / int value
        /// </summary>
        private static readonly string[] Symbols =
        {
            BaseSymbol, // KilogramPerSquareMeter,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Squared}",      // KilogramPerSquareKilometer,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // KilogramPerSquareHectometer,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Squared}",      // KilogramPerSquareDecameter,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Squared}",      // KilogramPerSquareDecimeter,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // KilogramPerSquareCentimeter,
            $"{Prefixes.Kilo.Symbol}{Mass.BaseSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // KilogramPerSquareKilometer,

            $"{Mass.BaseSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // gramPerSquareKilometer,
            $"{Mass.BaseSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // gramPerSquareHectometer,
            $"{Mass.BaseSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // gramPerSquareDecameter,
            $"{Mass.BaseSymbol}/{Length.BaseSymbol}{Unicode.Squared}",                          // gramPerSquareMeter,
            $"{Mass.BaseSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // gramPerSquareDecimeter,
            $"{Mass.BaseSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // gramPerSquareCentimeter,
            $"{Mass.BaseSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // gramPerSquaremeter,

            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // CentigramPerSquareKilometer,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // CentigramPerSquareHectometer,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // CentigramPerSquareDecameter,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Length.BaseSymbol}{Unicode.Squared}",                           // CentigramPerSquareMeter,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // CentigramPerSquareDecimeter,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // CentigramPerSquareCentimeter,
            $"{Prefixes.Centi.Symbol}{Mass.BaseSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // CentigramPerSquareCentimeter,

            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // MilligramPerSquareKilometer,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // MilligramPerSquareHectometer,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // MilligramPerSquareDecameter,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Length.BaseSymbol}{Unicode.Squared}",                           // MilligramPerSquareMeter,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Squared}",     // MilligramPerSquareDecimeter,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // MilligramPerSquareCentimeter,
            $"{Prefixes.Milli.Symbol}{Mass.BaseSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Squared}",    // MilligramPerSquareMillimeter,

            $"{Mass.TonneSymbol}/{Prefixes.Kilo.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // TonnePerSquareKilometer,
            $"{Mass.TonneSymbol}/{Prefixes.Hecto.Symbol}{Length.BaseSymbol}{Unicode.Squared}",  // TonnePerSquareHectometer,
            $"{Mass.TonneSymbol}/{Prefixes.Deca.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // TonnePerSquareDecameter,
            $"{Mass.TonneSymbol}/{Length.BaseSymbol}{Unicode.Squared}",                         // TonnePerSquareMeter,
            $"{Mass.TonneSymbol}/{Prefixes.Deci.Symbol}{Length.BaseSymbol}{Unicode.Squared}",   // TonnePerSquareDecimeter,
            $"{Mass.TonneSymbol}/{Prefixes.Centi.Symbol}{Length.BaseSymbol}{Unicode.Squared}",  // TonnePerSquareCentimeter,
            $"{Mass.TonneSymbol}/{Prefixes.Milli.Symbol}{Length.BaseSymbol}{Unicode.Squared}",  // TonnePerSquareMillimeter,

            $"{USCustomary.Ounce.Symbol}/{USCustomary.Inch}{Unicode.Squared}",  // OuncePerSquareInch,
            $"{USCustomary.Ounce.Symbol}/{USCustomary.Foot}{Unicode.Squared}",  // OuncePerSquareFoot,
            $"{USCustomary.Ounce.Symbol}/{USCustomary.Yard}{Unicode.Squared}",  // OuncePerSquareYard,
            $"{USCustomary.Ounce.Symbol}/{USCustomary.Mile}{Unicode.Squared}",  // OuncePerSquareMile,

            $"{USCustomary.Pound.Symbol}/{USCustomary.Inch}{Unicode.Squared}",  // PoundPerSquareInch,
            $"{USCustomary.Pound.Symbol}/{USCustomary.Foot}{Unicode.Squared}",  // PoundPerSquareFoot,
            $"{USCustomary.Pound.Symbol}/{USCustomary.Yard}{Unicode.Squared}",  // PoundPerSquareYard,
            $"{USCustomary.Pound.Symbol}/{USCustomary.Mile}{Unicode.Squared}",  // PoundPerSquareMile

            $"{USCustomary.Ton.Symbol}/{USCustomary.Inch}{Unicode.Squared}",    // TonPerSquareInch
            $"{USCustomary.Ton.Symbol}/{USCustomary.Foot}{Unicode.Squared}",    // TonPerSquareFoot
            $"{USCustomary.Ton.Symbol}/{USCustomary.Yard}{Unicode.Squared}",    // TonPerSquareYard
            $"{USCustomary.Ton.Symbol}/{USCustomary.Mile}{Unicode.Squared}"     // TonPerSquareMile
        };

        /// <summary>
        /// Create new SurfaceDensity object
        /// </summary>
        /// <param name="value">SurfaceDensity value (amount)</param>
        /// <param name="unit">Unit of measure value is in</param>
        [JsonConstructor]
        public SurfaceDensity(double value, Units unit)
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
            if ((obj is SurfaceDensity) == false) { return false; }
            
            return Equals((SurfaceDensity)obj);
        }

        /// <inheritdoc/>
        public double BaseValue()
        {
            return Value * Factors[(int)Unit] * Inverse[(int)BaseUnit];
        }

        /// <inheritdoc/>
        public SurfaceDensity ToBase()
        {
            return As(BaseUnit);
        }

        /// <inheritdoc/>
        public bool Equals(SurfaceDensity other)
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
        public SurfaceDensity As(Units target)
        {
            return new SurfaceDensity(Value * Factors[(int)Unit] * Inverse[(int)target], target);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Value} {Symbols[(int)Unit]}";
        }

        /// <inheritdoc/>
        public int CompareTo(SurfaceDensity other)
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
        public SurfaceDensity Sqrt()
        {
            return new SurfaceDensity(Math.Sqrt(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Cbrt()
        {
            return new SurfaceDensity(Math.Cbrt(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Log()
        {
            return new SurfaceDensity(Math.Log(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Log2()
        {
            return new SurfaceDensity(Math.Log2(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Log10()
        {
            return new SurfaceDensity(Math.Log10(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Pow(double exp)
        {
            return new SurfaceDensity(Math.Pow(Value, exp), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Abs()
        {
            return new SurfaceDensity(Math.Abs(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Floor()
        {
            return new SurfaceDensity(Math.Floor(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Ceiling()
        {
            return new SurfaceDensity(Math.Ceiling(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Truncate()
        {
            return new SurfaceDensity(Math.Truncate(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Round()
        {
            return new SurfaceDensity(Math.Round(Value), Unit);
        }

        /// <inheritdoc/>
        public SurfaceDensity Round(int digits)
        {
            return new SurfaceDensity(Math.Round(Value, digits), Unit);
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
        public static SurfaceDensity Parse(string s, IFormatProvider? provider)
        {
            var tokens  = s.Split(' ', 2);

            var value   = double.Parse(tokens[0]);
            var unit    = (Units)Array.IndexOf(Symbols, tokens[1].Trim());

            return new SurfaceDensity(value, unit);
        }

        /// <inheritdoc/>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out SurfaceDensity result)
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
                result = default(SurfaceDensity);
                return false;
            }
        }

        #region OperatorOverloading

        public static SurfaceDensity operator++(SurfaceDensity value)
        {
            return new SurfaceDensity(value.Value + 1, value.Unit);
        }

        public static SurfaceDensity operator--(SurfaceDensity value)
        {
            return new SurfaceDensity(value.Value - 1, value.Unit);
        }

        public static SurfaceDensity operator/(SurfaceDensity value, double scalar)
        {
            return new SurfaceDensity(value.Value / scalar, value.Unit);
        }

        public static SurfaceDensity operator*(SurfaceDensity value, double scalar)
        {
            return new SurfaceDensity(value.Value * scalar, value.Unit);
        }

        public static SurfaceDensity operator*(double scalar, SurfaceDensity value)
        {
            return new SurfaceDensity(value.Value * scalar, value.Unit);
        }

        public static SurfaceDensity operator-(SurfaceDensity a)
        {
            return new SurfaceDensity(-a.Value, a.Unit);
        }

        public static SurfaceDensity operator-(SurfaceDensity a, SurfaceDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new SurfaceDensity(a.Value - b.Value, a.Unit);
            }

            return new SurfaceDensity(a.BaseValue() - b.BaseValue(), BaseUnit);
        }

        public static SurfaceDensity operator+(SurfaceDensity a, SurfaceDensity b)
        {
            if (a.Unit == b.Unit)
            {
                return new SurfaceDensity(a.Value + b.Value, a.Unit);
            }

            return new SurfaceDensity(a.BaseValue() + b.BaseValue(), BaseUnit);
        }

        public static double operator/(SurfaceDensity a, SurfaceDensity b)
        {
            return a.BaseValue() / b.BaseValue();
        }

        public static bool operator==(SurfaceDensity a, SurfaceDensity b)
        {
            return a.Equals(b);
        }

        public static bool operator!=(SurfaceDensity a, SurfaceDensity b)
        {
            return !a.Equals(b);
        }

        public static bool operator>(SurfaceDensity a, SurfaceDensity b)
        {
            return a.BaseValue() > b.BaseValue();
        }

        public static bool operator<(SurfaceDensity a, SurfaceDensity b)
        {
            return a.BaseValue() < b.BaseValue();
        }

        public static bool operator>=(SurfaceDensity a, SurfaceDensity b)
        {
            return a.BaseValue() >= b.BaseValue();
        }

        public static bool operator<=(SurfaceDensity a, SurfaceDensity b)
        {
            return a.BaseValue() <= b.BaseValue();
        }

        public static SurfaceDensity operator%(SurfaceDensity a, double b)
        {
            return new SurfaceDensity(a.Value % b, a.Unit);
        }

        #endregion
    }
}
