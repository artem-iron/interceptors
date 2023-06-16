namespace AttributedCounterClassLib
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AnalyticsTrackedMethodAttribute : Attribute
    {
    }
}
