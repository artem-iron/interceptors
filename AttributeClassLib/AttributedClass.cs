using AttributedCounterClassLib;

namespace AttributeClassLib
{
    public class AttributedClass
    {
        internal int _methodCounts = 0;
        internal int _propertyGetterCounts = 0;
        internal int _propertySetterCounts = 0;
        internal int _propertyToTrack = 0;

        [AnalyticsTrackedMethod]
        public virtual int PropertyToTrack
        {
            get
            {
                _propertyGetterCounts++;
                _propertyToTrack++;

                return _propertyToTrack;
            }
            set
            {
                _propertySetterCounts++;
                _propertyToTrack++;
            }
        }

        [AnalyticsTrackedMethod]
        public AttributedClass()
        {
            
        }

        [AnalyticsTrackedMethod]
        public virtual int MethodToTrack()
        {
            _methodCounts++;

            return _methodCounts;
        }

        public virtual int MethodNotToTrack()
        {
            return 0;
        }
    }
}