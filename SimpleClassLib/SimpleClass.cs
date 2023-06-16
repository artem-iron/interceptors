using SimpleCounterClassLib;
using System.Reflection;

namespace SimpleClassLib
{
    public class SimpleClass
    {
        internal int _methodCounts = 0;
        internal int _propertyGetterCounts = 0;
        internal int _propertySetterCounts = 0;
        internal int _propertyToTrack = 0;

        public int PropertyToTrack
        {
            get
            {
                SimpleCounter.Increment(MethodBase.GetCurrentMethod());

                _propertyGetterCounts++;
                _propertyToTrack++;

                return _propertyToTrack;
            }
            set
            {
                SimpleCounter.Increment(MethodBase.GetCurrentMethod());

                _propertySetterCounts++;
                _propertyToTrack++;
            }
        }

        public SimpleClass()
        {
            SimpleCounter.Increment(MethodBase.GetCurrentMethod());
        }

        public int MethodToTrack()
        {
            SimpleCounter.Increment(MethodBase.GetCurrentMethod());

            _methodCounts++;

            return _methodCounts;
        }

        public int MethodNotToTrack()
        {
            return 0;
        }
    }
}