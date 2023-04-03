namespace SI.Units.NET
{
    /// <summary>
    /// US Customary Units and their conversion to base SI units
    /// </summary>
    public static class USCustomary
    {
        /// <summary> US Customary units definition, foot to meter </summary>
        public const double FOOT2METER = 0.3048;

        /// <summary> US Customary units definition, pound to kilogram </summary>
        public const double POUND2KILO = 0.45359237;

        #region Length
        
        /// <summary> 12 inches = 1 foot </summary>
        public static readonly Prefix Inch = new Prefix("inch", "in", FOOT2METER / 12.0);

        /// <summary> 1 foot = 0.3048 meter </summary>
        public static readonly Prefix Foot = new Prefix("foot", "ft", FOOT2METER);

        /// <summary> 1 yard = 3 feet </summary>
        public static readonly Prefix Yard = new Prefix("yard", "yd", FOOT2METER * 3.0);

        /// <summary> 1 mile = 5280 feet </summary>
        public static readonly Prefix Mile = new Prefix("mile", "mi", FOOT2METER * 5280.0);

        /// <summary> 1 Fathom = 6 feet </summary>
        public static readonly Prefix Fathom = new Prefix("fathom", "ftm", FOOT2METER * 6.0);

        /// <summary> 1 Link = 0.66 feet (100 Link = 1 Chain) </summary>
        public static readonly Prefix Link = new Prefix("link", "lnk", FOOT2METER * 0.66);

        /// <summary> 1 Chain = 66 feet </summary>
        public static readonly Prefix Chain = new Prefix("chain", "ch", FOOT2METER * 66.0);

        /// <summary> 1 Furlong = 660 feet </summary>
        public static readonly Prefix Furlong = new Prefix("furlong", "fur", FOOT2METER * 660.0);

        /// <summary> 1 Rod = 16.5 feet </summary>
        public static readonly Prefix Rod = new Prefix("rod", "rod", FOOT2METER * 16.5);

        #endregion

        #region Mass

        /// <summary> 1 pound = 0.45359237 kilogram </summary>
        public static readonly Prefix Pound = new Prefix("pound", "lb", POUND2KILO);

        /// <summary> 16 ounces = 1 pound </summary>
        public static readonly Prefix Ounce = new Prefix("ounce", "oz", POUND2KILO / 16.0);

        /// <summary> 1 ton (short) = 2000 pounds </summary>
        public static readonly Prefix Ton = new Prefix("ton", "tn", POUND2KILO * 2000.0);

        /// <summary> 1 long ton = 2240 pounds </summary>
        public static readonly Prefix LongTon = new Prefix("long ton", "LT", POUND2KILO * 2240.0);

        /// <summary> 1 stone = 14 pounds </summary>
        public static readonly Prefix Stone = new Prefix("stone", "st", POUND2KILO * 14.0);

        /// <summary> 1 slug = 32.174048556 pounds </summary>
        public static readonly Prefix Slug = new Prefix("slug", "slug", POUND2KILO * 32.174048556);

        #endregion
    }
}
