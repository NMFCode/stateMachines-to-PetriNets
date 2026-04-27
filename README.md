# stateMachines-to-PetriNets

This repository contains a demo of a VS Code extension that synchronizes models of finite state machines and Petri nets online. Further, it includes a benchmark to measure the runtime of synchronization operations.

## Running the benchmark as Docker container

The simplest way to run the benchmark is to start it as a Docker container as follows:

```bash
docker run georghinkel/synchronization_benchmark
```

The benchmark takes about 60-80 minutes to complete and produces a number of results, including plain values, HTML/Markdown summaries and CSV files with the raw measurement results. It also will print its results as ASCII-art in the console. Alternatively, you can find the results under `/benchmark/BenchmarkDotNet.Artifacts/results`. Note that it will contain the R scripts necessary to produce the diagrams, but not the resulting diagrams because the Docker container does not have R installed.

Benchmark.NET unfortunately uses older versions of _dplyr_, in particular the function `group_by_` defunct since version 0.7. In the `results` directory, we included a slight modification of the R scripts that work with more recent versions of dplyr. For the paper, we extracted the parameter sizes from the job names and used the sizes as X-axis.

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

The benchmark takes about 60-80 minutes to complete and produces a number of results, including plain values, HTML/Markdown summaries, CSV files with the raw measurement results and (if R is installed), plots.

## Compile and Run the extension

In order to compile and run the Visual Studio Code extension, you again need to compile the backend:

```bash
dotnet build --configuration Release backend
```

Further, you need to have a recent version of Node installed and run the following:

```bash
cd vscode
npm install
npm compile
```

Afterwards, you can open the repository in Visual Studio Code, go to the run menu and run the _Run Extension_ command registered in the launch configurations. It will launch the extension. We recommand to open the two example models side-by-side in order to see directly how changes in one model cause impacts in the other model.

_Note:_ If you compile the extension in Debug mode (which is the default unless you specify `--configuration Release` as above), opening the extension will ask you to select a debugger that should be used to attach to the LSP server process. Please do not do this unless you have a suitable .NET debugger installed (e.g., Visual Studio).
