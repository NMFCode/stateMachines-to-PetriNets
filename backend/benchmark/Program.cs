using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
    .RunAll(ManualConfig.CreateMinimumViable()
        .WithOption(ConfigOptions.DisableOptimizationsValidator, true));