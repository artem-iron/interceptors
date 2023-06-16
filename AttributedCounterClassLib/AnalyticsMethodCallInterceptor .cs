using Castle.DynamicProxy;

namespace AttributedCounterClassLib
{
    public class AnalyticsMethodCallInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            object[] countAttributes = invocation.Method.GetCustomAttributes(typeof(AnalyticsTrackedMethodAttribute), true);
            if (countAttributes.Length > 0)
            {
                AttributedCounter.Increment(invocation.Method);
            }

            invocation.Proceed();
        }
    }
}
