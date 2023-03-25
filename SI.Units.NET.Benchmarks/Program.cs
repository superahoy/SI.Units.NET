// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using SI.Units.NET.Benchmarks;

var summary = BenchmarkRunner.Run<LengthBenchmarks>();
