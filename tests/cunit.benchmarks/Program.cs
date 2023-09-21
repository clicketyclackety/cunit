// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using cunit.benchmarks;

Console.WriteLine("Running Benchmark, World!");

var summaries = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
// BenchmarkRunner.Run<Multiply_Benchmark>();