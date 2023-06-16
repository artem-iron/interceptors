using AttributeClassLib;
using AttributedCounterClassLib;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Castle.DynamicProxy;
using SimpleClassLib;

[MemoryDiagnoser]
public class MyBenchmark
{
    private readonly SimpleClass _simpleClass = new();
    private AttributedClass _attributedClass = new();

    [GlobalSetup]
    public void Setup()
    {
        IProxyBuilder builder = new DefaultProxyBuilder();
        var generator = new ProxyGenerator(builder);
        object proxy = generator.CreateClassProxy(typeof(AttributedClass), new AnalyticsMethodCallInterceptor());

        _attributedClass = (AttributedClass)proxy;
    }

    [Benchmark]
    public void Simple()
    {
        _simpleClass.MethodToTrack();
        _simpleClass.MethodNotToTrack();
    }

    [Benchmark]
    public void Attributed()
    {
        _attributedClass.MethodToTrack();
        _attributedClass.MethodNotToTrack();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run<MyBenchmark>();
    }
}
