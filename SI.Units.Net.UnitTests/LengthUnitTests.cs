using System.Text.Json;

namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class LengthUnitTests
    {
        private const double EPS = 1.0e-14;
        
        [DataTestMethod]
        [DataRow(100, Length.Units.Meter, Length.Units.Meter,       100)]
        [DataRow(100, Length.Units.Meter, Length.Units.Decimeter,   1000)]
        [DataRow(100, Length.Units.Meter, Length.Units.Centimeter,  10000)]
        [DataRow(100, Length.Units.Meter, Length.Units.Millimeter,  100000)]
        [DataRow(100, Length.Units.Meter, Length.Units.Micrometer,  1e8)]
        [DataRow(100, Length.Units.Meter, Length.Units.Nanometer,   1e11)]
        [DataRow(100, Length.Units.Meter, Length.Units.Picometer,   1e14)]
        [DataRow(100, Length.Units.Meter, Length.Units.Femtometer,  1e17)]

        [DataRow(100, Length.Units.Meter, Length.Units.Decameter,   10)]
        [DataRow(100, Length.Units.Meter, Length.Units.Hectometer,  1)]
        [DataRow(100, Length.Units.Meter, Length.Units.Kilometer,   0.1)]
        [DataRow(100, Length.Units.Meter, Length.Units.Megameter,   0.0001)]
        [DataRow(100, Length.Units.Meter, Length.Units.Gigameter,   1e-7)]
        [DataRow(100, Length.Units.Meter, Length.Units.Terameter,   1e-10)]
        [DataRow(100, Length.Units.Meter, Length.Units.Petameter,   1e-13)]

        public void AsTest(double value, Length.Units unit, Length.Units target, double expected)
        {
            var a = new Length(value, unit);
            var b = a.As(target);

            Assert.AreEqual(expected, b.Value, EPS);
        }

        [TestMethod]
        public void SerializeTest()
        {
            var a           = new Length(100, Length.Units.Centimeter);
            var text        = JsonSerializer.Serialize(a);
            var restored    = JsonSerializer.Deserialize<Length>(text);

            Assert.AreEqual("{\"Value\":100,\"Unit\":\"Centimeter\"}", text);
            Assert.AreEqual(a, restored);
        }
    }
}
