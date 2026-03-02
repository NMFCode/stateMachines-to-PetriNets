
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7462/24H2/2024Update/HudsonValley)
AMD Ryzen 7 PRO 6850H with Radeon Graphics 3.20GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  Job-HEAIER : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=50  UnrollFactor=1  
WarmupCount=5  

 Method        | Size   | Mode              | Mean         | Error       | StdDev      | Median       |
-------------- |------- |------------------ |-------------:|------------:|------------:|-------------:|
 **ChangeName**    | **100**    | **ReInitialize**      |   **1,930.1 μs** |   **126.75 μs** |   **256.04 μs** |   **1,859.7 μs** |
 AddTransition | 100    | ReInitialize      |   2,302.7 μs |   165.51 μs |   330.53 μs |   2,249.9 μs |
 ToggleIsFinal | 100    | ReInitialize      |   1,889.5 μs |   114.18 μs |   230.65 μs |   1,827.5 μs |
 **ChangeName**    | **100**    | **Update**            |     **316.7 μs** |    **37.47 μs** |    **74.83 μs** |     **295.5 μs** |
 AddTransition | 100    | Update            |   1,316.3 μs |   105.18 μs |   212.47 μs |   1,272.7 μs |
 ToggleIsFinal | 100    | Update            |     170.7 μs |    13.98 μs |    27.60 μs |     167.8 μs |
 **ChangeName**    | **100**    | **UpdateWithFeature** |     **283.2 μs** |    **34.77 μs** |    **69.45 μs** |     **266.1 μs** |
 AddTransition | 100    | UpdateWithFeature |   1,071.5 μs |   123.54 μs |   249.56 μs |   1,004.4 μs |
 ToggleIsFinal | 100    | UpdateWithFeature |     120.5 μs |     4.79 μs |     8.76 μs |     117.4 μs |
 **ChangeName**    | **1000**   | **ReInitialize**      |   **8,688.6 μs** | **3,269.63 μs** | **6,604.81 μs** |   **4,124.2 μs** |
 AddTransition | 1000   | ReInitialize      |   9,179.3 μs | 3,469.86 μs | 7,009.30 μs |   5,191.0 μs |
 ToggleIsFinal | 1000   | ReInitialize      |   4,472.3 μs | 1,123.36 μs | 1,967.48 μs |   3,493.4 μs |
 **ChangeName**    | **1000**   | **Update**            |   **1,184.3 μs** |   **296.06 μs** |   **598.05 μs** |   **1,132.6 μs** |
 AddTransition | 1000   | Update            |   6,119.4 μs | 2,044.32 μs | 4,129.63 μs |   3,610.8 μs |
 ToggleIsFinal | 1000   | Update            |     687.8 μs |   116.53 μs |   235.40 μs |     752.5 μs |
 **ChangeName**    | **1000**   | **UpdateWithFeature** |     **939.0 μs** |   **123.34 μs** |   **234.67 μs** |     **921.6 μs** |
 AddTransition | 1000   | UpdateWithFeature |   4,995.5 μs | 1,471.24 μs | 2,971.97 μs |   4,110.6 μs |
 ToggleIsFinal | 1000   | UpdateWithFeature |     578.8 μs |    59.15 μs |   118.12 μs |     595.7 μs |
 **ChangeName**    | **10000**  | **ReInitialize**      |  **54,207.3 μs** |   **303.40 μs** |   **584.54 μs** |  **54,195.3 μs** |
 AddTransition | 10000  | ReInitialize      |  53,298.8 μs |   376.70 μs |   760.96 μs |  53,287.8 μs |
 ToggleIsFinal | 10000  | ReInitialize      |  52,307.1 μs |   355.16 μs |   709.28 μs |  52,388.9 μs |
 **ChangeName**    | **10000**  | **Update**            |   **4,966.1 μs** |   **293.85 μs** |   **559.08 μs** |   **5,060.1 μs** |
 AddTransition | 10000  | Update            |  41,769.9 μs |   363.87 μs |   718.25 μs |  41,627.1 μs |
 ToggleIsFinal | 10000  | Update            |   2,900.1 μs |    59.61 μs |   113.42 μs |   2,880.7 μs |
 **ChangeName**    | **10000**  | **UpdateWithFeature** |   **5,134.0 μs** |   **312.10 μs** |   **586.20 μs** |   **5,253.2 μs** |
 AddTransition | 10000  | UpdateWithFeature |  29,291.7 μs |   337.11 μs |   665.43 μs |  29,018.0 μs |
 ToggleIsFinal | 10000  | UpdateWithFeature |   2,823.6 μs |    62.23 μs |   121.38 μs |   2,815.4 μs |
 **ChangeName**    | **100000** | **ReInitialize**      | **636,910.9 μs** | **2,962.21 μs** | **5,707.17 μs** | **637,338.2 μs** |
 AddTransition | 100000 | ReInitialize      | 622,545.6 μs | 2,026.05 μs | 3,999.23 μs | 622,569.4 μs |
 ToggleIsFinal | 100000 | ReInitialize      | 642,750.7 μs | 2,599.87 μs | 5,131.89 μs | 643,668.7 μs |
 **ChangeName**    | **100000** | **Update**            |  **41,348.2 μs** | **2,501.18 μs** | **5,052.51 μs** |  **42,165.8 μs** |
 AddTransition | 100000 | Update            | 466,954.9 μs | 1,912.95 μs | 3,820.37 μs | 467,962.8 μs |
 ToggleIsFinal | 100000 | Update            |  20,865.5 μs |   205.67 μs |   410.75 μs |  20,857.2 μs |
 **ChangeName**    | **100000** | **UpdateWithFeature** |  **41,435.6 μs** | **2,447.96 μs** | **4,888.83 μs** |  **42,004.7 μs** |
 AddTransition | 100000 | UpdateWithFeature | 368,238.8 μs | 1,828.25 μs | 3,693.16 μs | 368,475.2 μs |
 ToggleIsFinal | 100000 | UpdateWithFeature |  19,526.5 μs |   152.93 μs |   294.64 μs |  19,494.5 μs |
