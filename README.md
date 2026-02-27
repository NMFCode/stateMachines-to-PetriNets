# stateMachines-to-PetriNets
Demo repository of a VS Code extension that synchronizes models of finite state machines and Petri nets online

## Install prerequisites

To run the benchmark, you need to have the .NET SDK installed. To install it, follow the [instructions](https://github.com/dotnet/core/blob/main/release-notes/10.0/install.md) provided by Microsoft. 

To render the plots visible in the paper, you need to have R installed.

## Compile and Run the Benchmark

The benchmark can be compiled using the dotnet CLI:

```bash
dotnet build --configuration Release backend
```

Afterwards, you can execute the benchmark by starting

```bash
dotnet backend/benchmark/bin/Release/net10.0/Benchmark.dll
```

The benchmark takes about 60 hours to complete and produces a number of results, including plain values, HTML summaries, CSV files with the raw measurement results and (if R is installed), plots.