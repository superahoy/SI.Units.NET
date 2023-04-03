namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class TemperatureUnitTests
    {
        public const double EPS = 0.001;

        [DataTestMethod]
        [DataRow(  0, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 32.0)]
        [DataRow( 10, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 50.0)]
        [DataRow( 20, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 68.0)]
        [DataRow( 30, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 86.0)]
        [DataRow( 40, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 104.0)]
        [DataRow( 50, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 122.0)]
        [DataRow( 60, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 140.0)]
        [DataRow( 70, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 158.0)]
        [DataRow( 80, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 176.0)]
        [DataRow( 90, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 194.0)]
        [DataRow(100, Temperature.Units.Celsius, Temperature.Units.Fahrenheit, 212.0)]

        [DataRow(  0, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -459.67)]
        [DataRow( 10, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -441.67)]
        [DataRow( 20, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -423.67)]
        [DataRow( 30, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -405.67)]
        [DataRow( 40, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -387.67)]
        [DataRow( 50, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -369.67)]
        [DataRow( 60, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -351.67)]
        [DataRow( 70, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -333.67)]
        [DataRow( 80, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -315.67)]
        [DataRow( 90, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -297.67)]
        [DataRow(100, Temperature.Units.Kelvin, Temperature.Units.Fahrenheit, -279.67)]

        [DataRow(  0, Temperature.Units.Kelvin, Temperature.Units.Celsius, -273.15)]
        [DataRow( 10, Temperature.Units.Kelvin, Temperature.Units.Celsius, -263.15)]
        [DataRow( 20, Temperature.Units.Kelvin, Temperature.Units.Celsius, -253.15)]
        [DataRow( 30, Temperature.Units.Kelvin, Temperature.Units.Celsius, -243.15)]
        [DataRow( 40, Temperature.Units.Kelvin, Temperature.Units.Celsius, -233.15)]
        [DataRow( 50, Temperature.Units.Kelvin, Temperature.Units.Celsius, -223.15)]
        [DataRow( 60, Temperature.Units.Kelvin, Temperature.Units.Celsius, -213.15)]
        [DataRow( 70, Temperature.Units.Kelvin, Temperature.Units.Celsius, -203.15)]
        [DataRow( 80, Temperature.Units.Kelvin, Temperature.Units.Celsius, -193.15)]
        [DataRow( 90, Temperature.Units.Kelvin, Temperature.Units.Celsius, -183.15)]
        [DataRow(100, Temperature.Units.Kelvin, Temperature.Units.Celsius, -173.15)]
        [DataRow(200, Temperature.Units.Kelvin, Temperature.Units.Celsius, -073.15)]
        [DataRow(300, Temperature.Units.Kelvin, Temperature.Units.Celsius,  026.85)]
        [DataRow(400, Temperature.Units.Kelvin, Temperature.Units.Celsius,  126.85)]
        [DataRow(500, Temperature.Units.Kelvin, Temperature.Units.Celsius,  226.85)]
        [DataRow(600, Temperature.Units.Kelvin, Temperature.Units.Celsius,  326.85)]

        [DataRow(  0, Temperature.Units.Kelvin, Temperature.Units.Rankine,    0)]
        [DataRow( 10, Temperature.Units.Kelvin, Temperature.Units.Rankine,   18)]
        [DataRow( 20, Temperature.Units.Kelvin, Temperature.Units.Rankine,   36)]
        [DataRow( 30, Temperature.Units.Kelvin, Temperature.Units.Rankine,   54)]
        [DataRow( 40, Temperature.Units.Kelvin, Temperature.Units.Rankine,   72)]
        [DataRow( 50, Temperature.Units.Kelvin, Temperature.Units.Rankine,   90)]
        [DataRow( 60, Temperature.Units.Kelvin, Temperature.Units.Rankine,  108)]
        [DataRow( 70, Temperature.Units.Kelvin, Temperature.Units.Rankine,  126)]
        [DataRow( 80, Temperature.Units.Kelvin, Temperature.Units.Rankine,  144)]
        [DataRow( 90, Temperature.Units.Kelvin, Temperature.Units.Rankine,  162)]
        [DataRow(100, Temperature.Units.Kelvin, Temperature.Units.Rankine,  180)]
        [DataRow(200, Temperature.Units.Kelvin, Temperature.Units.Rankine,  360)]
        [DataRow(300, Temperature.Units.Kelvin, Temperature.Units.Rankine,  540)]
        [DataRow(400, Temperature.Units.Kelvin, Temperature.Units.Rankine,  720)]
        [DataRow(500, Temperature.Units.Kelvin, Temperature.Units.Rankine,  900)]
        [DataRow(600, Temperature.Units.Kelvin, Temperature.Units.Rankine, 1080)]

        [DataRow(  0, Temperature.Units.Rankine, Temperature.Units.Celsius, -273.150)]
        [DataRow( 10, Temperature.Units.Rankine, Temperature.Units.Celsius, -267.594)]
        [DataRow( 20, Temperature.Units.Rankine, Temperature.Units.Celsius, -262.039)]
        [DataRow( 30, Temperature.Units.Rankine, Temperature.Units.Celsius, -256.483)]
        [DataRow( 40, Temperature.Units.Rankine, Temperature.Units.Celsius, -250.928)]
        [DataRow( 50, Temperature.Units.Rankine, Temperature.Units.Celsius, -245.372)]
        [DataRow( 60, Temperature.Units.Rankine, Temperature.Units.Celsius, -239.817)]
        [DataRow( 70, Temperature.Units.Rankine, Temperature.Units.Celsius, -234.261)]
        [DataRow( 80, Temperature.Units.Rankine, Temperature.Units.Celsius, -228.706)]
        [DataRow( 90, Temperature.Units.Rankine, Temperature.Units.Celsius, -223.150)]
        [DataRow(100, Temperature.Units.Rankine, Temperature.Units.Celsius, -217.594)]
        [DataRow(200, Temperature.Units.Rankine, Temperature.Units.Celsius, -162.039)]
        [DataRow(300, Temperature.Units.Rankine, Temperature.Units.Celsius, -106.483)]
        [DataRow(400, Temperature.Units.Rankine, Temperature.Units.Celsius, -50.9278)]
        [DataRow(500, Temperature.Units.Rankine, Temperature.Units.Celsius,  4.62778)]
        [DataRow(600, Temperature.Units.Rankine, Temperature.Units.Celsius,  60.1833)]

        public void AsTest(double value, Temperature.Units unit, Temperature.Units target, double expected)
        {
            // target conversion

            var a = new Temperature(value, unit);
            var b = a.As(target);

            Assert.AreEqual(expected, b.Value, EPS);

            // reverse conversion

            var c = new Temperature(expected, target);
            var d = c.As(unit);

            Assert.AreEqual(value, d.Value, EPS);
        }
    }
}
