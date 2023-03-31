using System.Text.Json;

namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class MassUnitTests
    {
        /// <summary> Double comparison tolerance </summary>
        private const double EPS = 1.0e-12;

        [TestMethod]
        public void SerializeTest()
        {
            var a           = new Mass(100, Mass.Units.Milligram);
            var text        = JsonSerializer.Serialize(a);
            var restored    = JsonSerializer.Deserialize<Mass>(text);

            Assert.AreEqual("{\"Value\":100,\"Unit\":\"Milligram\"}", text);
            Assert.AreEqual(a, restored);
        }

        [DataTestMethod]
        [DataRow(10.0, Mass.Units.Kilogram, Mass.Units.Gram, 10000.0)]
        [DataRow(1000.0, Mass.Units.Kilogram, Mass.Units.Tonne, 1.0)]
        public void AsTest(double value, Mass.Units unit, Mass.Units target, double expected)
        {
            var a = new Mass(value, unit);
            var b = a.As(target);

            Assert.AreEqual(expected, b.Value, EPS);
        }
    }
}
