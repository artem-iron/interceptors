using System.Reflection;

namespace AttributedCounterClassLib
{
    public static class AttributedCounter
    {
        private static readonly Dictionary<string, int> _counter = new();

        public static void Increment(MethodBase? methodBase)
        {
            if (methodBase is null)
            {
                throw new ArgumentNullException(nameof(methodBase));
            }

            string methodName = GetMethodIdentifyer(methodBase);

            if (_counter.ContainsKey(methodName))
            {
                _counter[methodName]++;
            }
            else
            {
                _counter.Add(methodName, 1);
            }
        }

        public static void PrintCounter()
        {
            Console.WriteLine("AttributedCounter:");
            Console.WriteLine("==========================================================");

            foreach (KeyValuePair<string, int> item in _counter)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine("==========================================================\n");
        }

        public static int GetCount(string methodName)
        {
            return _counter.ContainsKey(methodName) ? _counter[methodName] : 0;
        }

        private static string GetMethodIdentifyer(MethodBase methodBase)
        {
            return $"{methodBase?.DeclaringType?.FullName}.{methodBase?.Name}";
        }
    }
}