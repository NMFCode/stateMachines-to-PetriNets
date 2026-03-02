
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7462/24H2/2024Update/HudsonValley)
AMD Ryzen 7 PRO 6850H with Radeon Graphics 3.20GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  Job-QKDGBD : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=10  UnrollFactor=1  
WarmupCount=3  

 Method            | Size   | Mean         | Error       | StdDev       | Median       |
------------------ |------- |-------------:|------------:|-------------:|-------------:|
 **ChangeStateName**   | **100**    |     **895.6 μs** |    **150.2 μs** |     **89.40 μs** |     **897.3 μs** |
 RemoveTransition  | 100    |   2,567.9 μs |    532.7 μs |    317.01 μs |   2,714.6 μs |
 SetStateAsInitial | 100    |   1,087.6 μs |  1,671.9 μs |  1,105.83 μs |     279.8 μs |
 AddTargetPlace    | 100    |   1,795.8 μs |    300.3 μs |    198.66 μs |   1,841.9 μs |
 **ChangeStateName**   | **1000**   |   **3,105.7 μs** |  **1,670.8 μs** |  **1,105.11 μs** |   **2,708.2 μs** |
 RemoveTransition  | 1000   |  13,614.7 μs |  8,970.1 μs |  5,933.16 μs |  11,275.7 μs |
 SetStateAsInitial | 1000   |  13,117.4 μs | 10,667.4 μs |  7,055.81 μs |  11,266.5 μs |
 AddTargetPlace    | 1000   |   9,580.6 μs |  4,302.9 μs |  2,846.11 μs |  11,207.0 μs |
 **ChangeStateName**   | **10000**  |  **18,084.6 μs** |  **4,259.0 μs** |  **2,534.45 μs** |  **17,458.7 μs** |
 RemoveTransition  | 10000  |  71,264.1 μs |  2,266.2 μs |  1,348.55 μs |  71,339.4 μs |
 SetStateAsInitial | 10000  |  69,611.3 μs |  4,090.4 μs |  2,434.12 μs |  70,289.6 μs |
 AddTargetPlace    | 10000  |  46,385.2 μs |  4,623.8 μs |  3,058.38 μs |  47,673.3 μs |
 **ChangeStateName**   | **100000** | **188,942.9 μs** | **63,286.4 μs** | **41,860.01 μs** | **178,014.3 μs** |
 RemoveTransition  | 100000 | 747,643.5 μs | 49,022.9 μs | 32,425.64 μs | 751,577.9 μs |
 SetStateAsInitial | 100000 | 738,083.0 μs | 53,399.8 μs | 35,320.68 μs | 744,356.6 μs |
 AddTargetPlace    | 100000 | 524,994.3 μs | 81,072.3 μs | 53,624.29 μs | 554,298.1 μs |
