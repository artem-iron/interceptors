using Castle.DynamicProxy;

namespace InterceptorConsole;

public class ServiceClass
{
    public virtual int Sum(int b1, int b2)
    {
        return b1 + b2;
    }

    public class InernalClass
    {
    }
}

public class ResultModifierInterceptor : StandardInterceptor
{
    protected override void PostProceed(IInvocation invocation)
    {
        object returnValue = invocation.ReturnValue;

        if (returnValue != null && returnValue.GetType() == typeof(int))
        {
            int value = (int)returnValue;

            invocation.ReturnValue = --value;
        }

        if (returnValue != null && returnValue.GetType() == typeof(bool))
        {
            invocation.ReturnValue = true;
        }
    }
}

public class StandardInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        PreProceed(invocation);
        PerformProceed(invocation);
        PostProceed(invocation);
    }

    protected virtual void PerformProceed(IInvocation invocation)
    {
        invocation.Proceed();
    }

    protected virtual void PreProceed(IInvocation invocation)
    {
    }

    protected virtual void PostProceed(IInvocation invocation)
    {
    }
}
