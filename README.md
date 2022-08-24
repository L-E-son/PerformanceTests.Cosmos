# Cosmos Performance Tests: Standard vs. Bulk Execution
Tested with `Microsoft.Azure.Cosmos 3.28.0`

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.22000
AMD Ryzen 9 5950X, 1 CPU, 32 logical and 16 physical cores
.NET Core SDK=7.0.100-preview.2.22153.17
  [Host]     : .NET Core 3.1.27 (CoreCLR 4.700.22.30802, CoreFX 4.700.22.31504), X64 RyuJIT
  DefaultJob : .NET Core 3.1.27 (CoreCLR 4.700.22.30802, CoreFX 4.700.22.31504), X64 RyuJIT


```
|           Method |    N | DocumentSizeInBytes |         Mean |     Error |    StdDev |       Median |
|----------------- |----- |-------------------- |-------------:|----------:|----------:|-------------:|
| **DefaultExecution** |    **1** |                **6461** |     **42.76 ms** |  **0.711 ms** |  **0.665 ms** |     **42.67 ms** |
|    BulkExecution |    1 |                6461 |     96.68 ms |  2.791 ms |  8.229 ms |     91.61 ms |
| **DefaultExecution** |   **10** |                **6461** |    **424.94 ms** |  **2.227 ms** |  **1.974 ms** |    **424.85 ms** |
|    BulkExecution |   10 |                6461 |    104.57 ms |  7.499 ms | 21.028 ms |    100.87 ms |
| **DefaultExecution** |  **100** |                **6461** |  **4,233.75 ms** | **15.197 ms** | **14.215 ms** |  **4,238.09 ms** |
|    BulkExecution |  100 |                6461 |  1,238.20 ms | 23.336 ms | 45.515 ms |  1,237.61 ms |
| **DefaultExecution** | **1000** |                **6461** | **42,525.37 ms** | **73.576 ms** | **68.824 ms** | **42,503.06 ms** |
|    BulkExecution | 1000 |                6461 | 12,509.25 ms | 67.113 ms | 62.777 ms | 12,512.70 ms |
