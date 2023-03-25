namespace SI.Units.NET
{
    /// <summary>
    /// Prefix represents a single SI prefix from Table 7. SI prefixes
    /// </summary>
    public readonly struct Prefix
    {
        /// <summary>
        /// Create new Prefix object
        /// </summary>
        /// <param name="symbol">Prefix symbol</param>
        /// <param name="factor">Prefix factor</param>
        public Prefix(string name, string symbol, double factor)
        {
            Name    = name;    
            Factor  = factor;
            Symbol  = symbol;
        }

        /// <summary> Prefix name </summary>
        public string Name { get; init; }

        /// <summary> Prefix factor </summary>
        public double Factor { get; init; }

        /// <summary> Prefix symbols </summary>
        public string Symbol { get; init; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sup = Superscript();
            return $"10{sup} {Name} {Symbol}";
        }

        /// <summary>
        /// Generate unicode based superscript for prefix Factor
        /// </summary>
        /// <returns>Unicode superscript for prefix factor</returns>
        private string Superscript()
        {
            var f = (int)Math.Log10(Factor);

            switch (f)
            {
                case 1: return "\u00B9";
                case 2: return "\u00B2";
                case 3: return "\u00B3";
                case 6: return "\u2076";
                case 9: return "\u2079";
                case 12: return "\u00B9\u00B2";
                case 15: return "\u00B9\u2075";
                
                case -1: return "\u207B\u00B9";
                case -2: return "\u207B\u00B2";
                case -3: return "\u207B\u00B3";
                case -6: return "\u207B\u2076";
                case -9: return "\u207B\u2079";
                case -12: return "\u207B\u00B9\u00B2";
                case -15: return "\u207B\u00B9\u2075";
            }

            return string.Empty;
        }
    }
}