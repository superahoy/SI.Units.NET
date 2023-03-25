using SI.Units.NET;

namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class PrefixUnitTests
    {
        [DataTestMethod]
        [DataRow("deca",  "da", 1e1,   "10¹ deca da")]
        [DataRow("hecto", "h",  1e2,   "10² hecto h")]
        [DataRow("kilo",  "k",  1e3,   "10³ kilo k")]
        [DataRow("mega",  "M",  1e6,   "10⁶ mega M")]        
        [DataRow("giga",  "G",  1e9,   "10⁹ giga G")]
        [DataRow("tera",  "T",  1e12,  "10¹² tera T")]
        [DataRow("peta",  "P",  1e15,  "10¹⁵ peta P")]
        [DataRow("deci",  "d",  1e-1,  "10⁻¹ deci d")]
        [DataRow("centi", "c",  1e-2,  "10⁻² centi c")]
        [DataRow("milli", "m",  1e-3,  "10⁻³ milli m")]
        [DataRow("micro", "μ",  1e-6,  "10⁻⁶ micro μ")]        
        [DataRow("nano",  "n",  1e-9,  "10⁻⁹ nano n")]
        [DataRow("pico",  "p",  1e-12, "10⁻¹² pico p")]
        [DataRow("femto", "f",  1e-15, "10⁻¹⁵ femto f")]
        public void ToStringTest(string name, string symbol, double factor, string expected)
        {
            var prefix = new Prefix(name, symbol, factor);
            var text = prefix.ToString();

            Assert.IsNotNull(text);
            Assert.AreEqual(expected, text);
        }
    }
}