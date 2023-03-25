using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI.Units.NET.Benchmarks
{
    public class LengthBenchmarks
    {
        private static readonly Length Length1 = new Length(100, Length.Units.Centimeter);
        private static readonly Length Length2 = new Length(100, Length.Units.Centimeter);
        private static readonly Length Length3 = new Length(1000, Length.Units.Millimeter);

        [Benchmark]
        public void AsBenchmark()
        {
            var b = Length1.As(Length.Units.Kilometer);
        }

        [Benchmark]
        public void AddSameUnitBenchmark()
        {
            var result = Length1 + Length2;
        }

        [Benchmark]
        public void AddMixedUnitBenchmark()
        {
            var result = Length1 + Length3;
        }
    }
}
