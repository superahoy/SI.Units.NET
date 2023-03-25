namespace SI.Units.NET
{
    /// <summary>
    /// Based on Table 7. SI Prefixes
    /// </summary>
    public static class Prefixes
    {
        public static readonly Prefix Deca = new Prefix("deca", "da", 1.0e1);
        
        public static readonly Prefix Hecto = new Prefix("hecto", "h", 1.0e2);
        
        public static readonly Prefix Kilo = new Prefix("kilo", "k", 1.0e3);

        public static readonly Prefix Mega = new Prefix("mega", "M", 1.0e6);

        public static readonly Prefix Giga = new Prefix("giga", "G", 1.0e9);

        public static readonly Prefix Tera = new Prefix("tera", "T", 1.0e12);

        public static readonly Prefix Peta = new Prefix("peta", "P", 1.0e15);

        public static readonly Prefix Deci = new Prefix("deci", "d", 1.0e-1);

        public static readonly Prefix Centi = new Prefix("centi", "c", 1.0e-2);
        
        public static readonly Prefix Milli = new Prefix("milli", "m", 1.0e-3);

        public static readonly Prefix Micro = new Prefix("micro", "μ", 1.0e-6);

        public static readonly Prefix Nano = new Prefix("nano", "n", 1.0e-9);

        public static readonly Prefix Pico = new Prefix("pico", "p", 1.0e-12);

        public static readonly Prefix Femto = new Prefix("femto", "f", 1.0e-15);
    }
}
