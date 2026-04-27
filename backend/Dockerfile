FROM mcr.microsoft.com/dotnet/sdk:10.0

COPY . benchmark
RUN dotnet build benchmark/FiniteStateMachinesToPetriNetsLspServer.sln --configuration Release

WORKDIR /benchmark

CMD [ "dotnet", "benchmark/bin/Release/net10.0/Benchmark.dll" ]