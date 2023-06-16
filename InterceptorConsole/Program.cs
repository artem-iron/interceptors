using Castle.DynamicProxy;
using InterceptorConsole;

IProxyBuilder builder = new DefaultProxyBuilder();
var generator = new ProxyGenerator(builder);

object proxy = generator.CreateClassProxy(typeof(ServiceClass), new ResultModifierInterceptor());

var instance = (ServiceClass)proxy;

Console.WriteLine(instance.Sum(20, 25));
