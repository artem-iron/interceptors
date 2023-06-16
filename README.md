# Benchmark Counters

This solution contains examples of two possible implementations of method call
counters:

- One is a simple counter, increments of which are invoked by the counted method
itself, but to make it possible, the call for incrementation has to be put in
the code of the method.
- The second one is more complicated. It allows using a special attribute to
mark methods whose calls should be counted. It then uses a proxy to intercept
the calls. The interceptor will increment the counter and then will proceed with
the original method call.

The purpose of this solution is to measure the impact on performance and memory
allocation by the interceptor.

To run the benchmark build the solution, navigate to the
`[solution root]\BenchmarkConsole\bin\Release\net6.0` directory and run
BenchmarkConsole.exe

Results of the last run:
|     Method |       Mean |    Error |   StdDev |   Gen0 | Allocated |
|----------- |-----------:|---------:|---------:|-------:|----------:|
|     Simple |   844.8 ns | 11.29 ns | 10.01 ns | 0.0229 |     192 B |
| Attributed | 1,001.1 ns | 19.63 ns | 28.78 ns | 0.0572 |     480 B |
