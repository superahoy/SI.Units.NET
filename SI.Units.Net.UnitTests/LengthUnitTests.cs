﻿using System.Text.Json;

namespace SI.Units.NET.UnitTests
{
    [TestClass]
    public class LengthUnitTests
    {
        /// <summary> Double comparison tolerance </summary>
        private const double EPS = 1.0e-12;
        
        [DataTestMethod]
        [DataRow(100,  Length.Units.Meter, Length.Units.Meter,          100)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Decimeter,      1000)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Centimeter,     10000)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Millimeter,     100000)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Micrometer,     1e8)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Nanometer,      1e11)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Picometer,      1e14)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Femtometer,     1e17)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Decameter,      10)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Hectometer,     1)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Kilometer,      0.1)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Megameter,      0.0001)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Gigameter,      1e-7)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Terameter,      1e-10)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Petameter,      1e-13)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Foot,           328.0839895013123)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Inch,           3937.007874015748)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Yard,           109.36132983377077)]
        [DataRow(1852, Length.Units.Meter, Length.Units.NauticalMile,   1.0)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Rod,            19.883878151594686)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Chain,          4.970969537898672)]
        [DataRow(100,  Length.Units.Meter, Length.Units.Link,           497.09695378986714)]

        [DataRow(100,                   Length.Units.Meter,         Length.Units.Meter, 100)]
        [DataRow(1000,                  Length.Units.Decimeter,     Length.Units.Meter, 100)]
        [DataRow(10000,                 Length.Units.Centimeter,    Length.Units.Meter, 100)]
        [DataRow(100000,                Length.Units.Millimeter,    Length.Units.Meter, 100)]
        [DataRow(1e8,                   Length.Units.Micrometer,    Length.Units.Meter, 100)]
        [DataRow(1e11,                  Length.Units.Nanometer,     Length.Units.Meter, 100)]
        [DataRow(1e14,                  Length.Units.Picometer,     Length.Units.Meter, 100)]
        [DataRow(1e17,                  Length.Units.Femtometer,    Length.Units.Meter, 100)]
        [DataRow(10,                    Length.Units.Decameter,     Length.Units.Meter, 100)]
        [DataRow(1,                     Length.Units.Hectometer,    Length.Units.Meter, 100)]
        [DataRow(0.1,                   Length.Units.Kilometer,     Length.Units.Meter, 100)]
        [DataRow(0.0001,                Length.Units.Megameter,     Length.Units.Meter, 100)]
        [DataRow(1e-7,                  Length.Units.Gigameter,     Length.Units.Meter, 100)]
        [DataRow(1e-10,                 Length.Units.Terameter,     Length.Units.Meter, 100)]
        [DataRow(1e-13,                 Length.Units.Petameter,     Length.Units.Meter, 100)]
        [DataRow(328.0839895013123,     Length.Units.Foot,          Length.Units.Meter, 100)]
        [DataRow(3937.007874015748,     Length.Units.Inch,          Length.Units.Meter, 100)]
        [DataRow(109.36132983377077,    Length.Units.Yard,          Length.Units.Meter, 100)]
        [DataRow(1.0,                   Length.Units.NauticalMile,  Length.Units.Meter, 1852)]
        [DataRow(19.883878151594686,    Length.Units.Rod,           Length.Units.Meter, 100)]
        [DataRow(4.970969537898672,     Length.Units.Chain,         Length.Units.Meter, 100)]
        [DataRow(497.09695378986714,    Length.Units.Link,          Length.Units.Meter, 100)]
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

        [TestMethod]
        public void ParseTest()
        {
            var text = "100 km";
            var parsed = Length.Parse(text, null);
            var expected = new Length(100, Length.Units.Kilometer);
            
            Assert.AreEqual(expected, parsed);

            text = "100 μm";
            parsed = Length.Parse(text, null);
            
            expected = new Length(100, Length.Units.Micrometer);
            
            Assert.AreEqual(expected, parsed);
        }

        [TestMethod]
        public void SqrtTest()
        {
            var a = new Length(25, Length.Units.Kilometer);
            var b = a.Sqrt();

            Assert.AreEqual(5, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit);
        }

        [TestMethod]
        public void CbrtTest()
        {
            var a = new Length(27, Length.Units.Kilometer);
            var b = a.Cbrt();

            Assert.AreEqual(3, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit);
        }

        [TestMethod]
        public void Log2Test()
        {
            var a = new Length(16, Length.Units.Kilometer);
            var b = a.Log2();

            Assert.AreEqual(4, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit);
        }

        [TestMethod]
        public void Log10Test()
        {
            var a = new Length(1000, Length.Units.Kilometer);
            var b = a.Log10();

            Assert.AreEqual(3, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit);
        }

        [TestMethod]
        public void AbsTest()
        {
            var a = new Length(-100, Length.Units.Kilometer);
            var b = a.Abs();

            Assert.AreEqual(100, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit); 
        }

        [TestMethod]
        public void RoundTest()
        {
            var a = new Length(100.2569, Length.Units.Kilometer);
            var b = a.Round(1);

            Assert.AreEqual(100.3, b.Value, EPS);
            Assert.AreEqual(Length.Units.Kilometer, b.Unit); 
        }

        [TestMethod]
        public void EqualsTest()
        {
            var a = new Length(1000, Length.Units.Meter);
            var b = new Length(1, Length.Units.Kilometer);

            Assert.AreEqual(a, b);

            b = new Length(500, Length.Units.Meter);
            Assert.AreNotEqual(a, b);
        }
    }
}
