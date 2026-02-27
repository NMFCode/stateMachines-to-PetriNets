using Benchmark;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
    .RunAll(ManualConfig.CreateMinimumViable()
        .WithOption(ConfigOptions.DisableOptimizationsValidator, true));

//var benchmark = new SynchronizationBenchmark
//{
//    Size = 1000
//};
//benchmark.Init();
//benchmark.AddTargetPlace();