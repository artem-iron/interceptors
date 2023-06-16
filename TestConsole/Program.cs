using AttributeClassLib;
using AttributedCounterClassLib;
using Castle.DynamicProxy;
using SimpleClassLib;
using SimpleCounterClassLib;

var simpleClass = new SimpleClass();
simpleClass.MethodToTrack();
simpleClass.MethodNotToTrack();
_ = simpleClass.PropertyToTrack;
simpleClass.PropertyToTrack++;

SimpleCounter.PrintCounter();

IProxyBuilder builder = new DefaultProxyBuilder();
var generator = new ProxyGenerator(builder);
object proxy = generator.CreateClassProxy(typeof(AttributedClass), new AnalyticsMethodCallInterceptor());

var attributedClass = (AttributedClass)proxy;
attributedClass.MethodToTrack();
attributedClass.MethodNotToTrack();
_ = attributedClass.PropertyToTrack;
attributedClass.PropertyToTrack++;

AttributedCounter.PrintCounter();