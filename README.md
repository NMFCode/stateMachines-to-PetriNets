# stateMachines-to-PetriNets

Demo repository of a VS Code extension that synchronizes models of finite state machines and Petri nets online

## Install prerequisites

To run the benchmark, you need to have the .NET SDK installed. To install it, follow the [instructions](https://github.com/dotnet/core/blob/main/release-notes/10.0/install.md) provided by Microsoft.

To render the plots visible in the paper, you need to have R installed.

## Compile and Run the Benchmark

The benchmark can be compiled using the dotnet CLI:

```bash
dotnet build --configuration Release backend
```-

Afterwards, you can execute the benchmark by starting

```bash
dotnet backend/benchmark/bin/Release/net10.0/Benchmark.dll
```

The benchmark takes about 80 minutes to complete and produces a number of results, including plain values, HTML summaries, CSV files with the raw measurement results and (if R is installed), plots.

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
