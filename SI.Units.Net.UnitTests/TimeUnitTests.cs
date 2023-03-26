namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class TimeUnitTests
    {
        /// <summary> Double comparison tolerance </summary>
        private const double EPS = 1.0e-12;
        
        [DataTestMethod]
        [DataRow(100,  Time.Units.Second, Time.Units.Second,          100)]
        [DataRow(100,  Time.Units.Second, Time.Units.Decisecond,      1000)]
        [DataRow(100,  Time.Units.Second, Time.Units.Centisecond,     10000)]
        [DataRow(100,  Time.Units.Second, Time.Units.Millisecond,     100000)]
        [DataRow(100,  Time.Units.Second, Time.Units.Microsecond,     1e8)]
        [DataRow(100,  Time.Units.Second, Time.Units.Nanosecond,      1e11)]
        [DataRow(100,  Time.Units.Second, Time.Units.Picosecond,      1e14)]
        [DataRow(100,  Time.Units.Second, Time.Units.Femtosecond,     1e17)]
        [DataRow(100,  Time.Units.Second, Time.Units.Decasecond,      10)]
        [DataRow(100,  Time.Units.Second, Time.Units.Hectosecond,     1)]
        [DataRow(100,  Time.Units.Second, Time.Units.Kilosecond,      0.1)]
        [DataRow(100,  Time.Units.Second, Time.Units.Megasecond,      0.0001)]
        [DataRow(100,  Time.Units.Second, Time.Units.Gigasecond,      1e-7)]
        [DataRow(100,  Time.Units.Second, Time.Units.Terasecond,      1e-10)]
        [DataRow(100,  Time.Units.Second, Time.Units.Petasecond,      1e-13)]
        
        [DataRow(60,    Time.Units.Second, Time.Units.Minute,          1.0)]
        [DataRow(120,   Time.Units.Second, Time.Units.Minute,          2.0)]
        [DataRow(180,   Time.Units.Second, Time.Units.Minute,          3.0)]
        [DataRow(3600,  Time.Units.Second, Time.Units.Hour,           1.0)]
        [DataRow(7200,  Time.Units.Second, Time.Units.Hour,           2.0)]
        [DataRow(14400, Time.Units.Second, Time.Units.Hour,          4.0)]
        [DataRow(86400, Time.Units.Second, Time.Units.Day,           1.0)]
        

        [DataRow(100,                   Time.Units.Second,         Time.Units.Second, 100)]
        [DataRow(1000,                  Time.Units.Decisecond,     Time.Units.Second, 100)]
        [DataRow(10000,                 Time.Units.Centisecond,    Time.Units.Second, 100)]
        [DataRow(100000,                Time.Units.Millisecond,    Time.Units.Second, 100)]
        [DataRow(1e8,                   Time.Units.Microsecond,    Time.Units.Second, 100)]
        [DataRow(1e11,                  Time.Units.Nanosecond,     Time.Units.Second, 100)]
        [DataRow(1e14,                  Time.Units.Picosecond,     Time.Units.Second, 100)]
        [DataRow(1e17,                  Time.Units.Femtosecond,    Time.Units.Second, 100)]
        [DataRow(10,                    Time.Units.Decasecond,     Time.Units.Second, 100)]
        [DataRow(1,                     Time.Units.Hectosecond,    Time.Units.Second, 100)]
        [DataRow(0.1,                   Time.Units.Kilosecond,     Time.Units.Second, 100)]
        [DataRow(0.0001,                Time.Units.Megasecond,     Time.Units.Second, 100)]
        [DataRow(1e-7,                  Time.Units.Gigasecond,     Time.Units.Second, 100)]
        [DataRow(1e-10,                 Time.Units.Terasecond,     Time.Units.Second, 100)]
        [DataRow(1e-13,                 Time.Units.Petasecond,     Time.Units.Second, 100)]
        
        [DataRow(1.0,   Time.Units.Minute, Time.Units.Second,          60)]
        [DataRow(2.0,   Time.Units.Minute, Time.Units.Second,          120)]
        [DataRow(3.0,   Time.Units.Minute, Time.Units.Second,          180)]
        [DataRow(1.0,   Time.Units.Hour, Time.Units.Second,           3600)]
        [DataRow(2.0,   Time.Units.Hour, Time.Units.Second,           7200)]
        [DataRow(4.0,   Time.Units.Hour, Time.Units.Second,          14400)]
        [DataRow(1.0,   Time.Units.Day, Time.Units.Second,           86400)]
        public void AsTest(double value, Time.Units unit, Time.Units target, double expected)
        {
            var a = new Time(value, unit);
            var b = a.As(target);

            Assert.AreEqual(expected, b.Value, EPS);
        }
    }
}
