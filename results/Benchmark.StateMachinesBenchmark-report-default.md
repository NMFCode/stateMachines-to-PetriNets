
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26100.7462/24H2/2024Update/HudsonValley)
AMD Ryzen 7 PRO 6850H with Radeon Graphics 3.20GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.103
  [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3
  Job-HEAIER : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=50  UnrollFactor=1  
WarmupCount=5  

 Method        | Size   | Mode              | Mean         | Error        | StdDev       | Median       |
-------------- |------- |------------------ |-------------:|-------------:|-------------:|-------------:|
 **ChangeName**    | **100**    | **ReInitialize**      |   **1,998.4 μs** |    **101.03 μs** |    **201.76 μs** |   **1,929.0 μs** |
 AddTransition | 100    | ReInitialize      |   2,405.2 μs |    193.39 μs |    390.66 μs |   2,339.2 μs |
 ToggleIsFinal | 100    | ReInitialize      |   2,000.5 μs |    130.07 μs |    262.74 μs |   2,050.2 μs |
 **ChangeName**    | **100**    | **Update**            |     **280.4 μs** |     **29.33 μs** |     **56.51 μs** |     **271.4 μs** |
 AddTransition | 100    | Update            |   1,526.3 μs |    142.40 μs |    284.38 μs |   1,498.6 μs |
 ToggleIsFinal | 100    | Update            |     152.6 μs |     10.24 μs |     19.72 μs |     146.0 μs |
 **ChangeName**    | **100**    | **UpdateWithFeature** |     **286.5 μs** |     **34.40 μs** |     **67.90 μs** |     **278.9 μs** |
 AddTransition | 100    | UpdateWithFeature |   1,109.7 μs |    106.55 μs |    215.23 μs |   1,084.9 μs |
 ToggleIsFinal | 100    | UpdateWithFeature |     115.6 μs |      3.84 μs |      7.31 μs |     113.5 μs |
 **ChangeName**    | **1000**   | **ReInitialize**      |   **8,050.2 μs** |  **2,692.27 μs** |  **5,438.53 μs** |   **4,470.9 μs** |
 AddTransition | 1000   | ReInitialize      |   7,147.8 μs |  2,317.28 μs |  4,681.01 μs |   4,415.9 μs |
 ToggleIsFinal | 1000   | ReInitialize      |   9,002.9 μs |  3,458.42 μs |  6,986.18 μs |   4,334.3 μs |
 **ChangeName**    | **1000**   | **Update**            |     **996.8 μs** |    **137.03 μs** |    **273.66 μs** |     **944.9 μs** |
 AddTransition | 1000   | Update            |   7,007.6 μs |  2,117.15 μs |  4,276.75 μs |   6,181.4 μs |
 ToggleIsFinal | 1000   | Update            |     634.9 μs |    149.20 μs |    297.97 μs |     664.9 μs |
 **ChangeName**    | **1000**   | **UpdateWithFeature** |     **876.2 μs** |     **97.20 μs** |    **182.56 μs** |     **853.3 μs** |
 AddTransition | 1000   | UpdateWithFeature |   5,119.0 μs |  1,674.08 μs |  3,381.73 μs |   3,549.8 μs |
 ToggleIsFinal | 1000   | UpdateWithFeature |     622.6 μs |    116.33 μs |    232.32 μs |     649.9 μs |
 **ChangeName**    | **10000**  | **ReInitialize**      |  **53,188.3 μs** |    **376.90 μs** |    **752.70 μs** |  **53,330.4 μs** |
 AddTransition | 10000  | ReInitialize      |  53,355.3 μs |    361.98 μs |    722.91 μs |  53,425.1 μs |
 ToggleIsFinal | 10000  | ReInitialize      |  54,377.9 μs |    361.18 μs |    704.46 μs |  54,484.0 μs |
 **ChangeName**    | **10000**  | **Update**            |   **4,725.9 μs** |    **294.57 μs** |    **567.55 μs** |   **4,786.6 μs** |
 AddTransition | 10000  | Update            |  45,356.9 μs |    291.54 μs |    568.63 μs |  45,198.6 μs |
 ToggleIsFinal | 10000  | Update            |   2,883.8 μs |     53.98 μs |    104.00 μs |   2,868.8 μs |
 **ChangeName**    | **10000**  | **UpdateWithFeature** |   **4,562.4 μs** |    **276.63 μs** |    **532.97 μs** |   **4,659.6 μs** |
 AddTransition | 10000  | UpdateWithFeature |  29,984.9 μs |    257.95 μs |    490.77 μs |  29,862.6 μs |
 ToggleIsFinal | 10000  | UpdateWithFeature |   2,845.9 μs |     43.68 μs |     82.04 μs |   2,824.2 μs |
 **ChangeName**    | **100000** | **ReInitialize**      | **696,434.3 μs** | **25,995.59 μs** | **50,084.67 μs** | **704,134.1 μs** |
 AddTransition | 100000 | ReInitialize      | 688,265.3 μs |  5,163.24 μs | 10,430.01 μs | 690,529.8 μs |
 ToggleIsFinal | 100000 | ReInitialize      | 655,068.2 μs |  2,929.88 μs |  5,714.51 μs | 655,039.0 μs |
 **ChangeName**    | **100000** | **Update**            |  **40,208.0 μs** |  **2,106.86 μs** |  **4,207.64 μs** |  **40,744.2 μs** |
 AddTransition | 100000 | Update            | 529,698.1 μs |  2,137.14 μs |  4,317.12 μs | 530,705.5 μs |
 ToggleIsFinal | 100000 | Update            |  21,718.4 μs |    175.36 μs |    350.22 μs |  21,728.8 μs |
 **ChangeName**    | **100000** | **UpdateWithFeature** |  **42,726.1 μs** |  **2,719.10 μs** |  **5,492.71 μs** |  **44,095.2 μs** |
 AddTransition | 100000 | UpdateWithFeature | 385,851.8 μs |  2,028.47 μs |  4,051.08 μs | 386,946.7 μs |
 ToggleIsFinal | 100000 | UpdateWithFeature |  21,471.5 μs |    165.78 μs |    327.23 μs |  21,478.5 μs |
