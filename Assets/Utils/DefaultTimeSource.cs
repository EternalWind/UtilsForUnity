using UnityEngine;

namespace Utils
{
    public class DefaultTimeSource : AutoConstructSingleton<DefaultTimeSource>, ITimeSource
    {
        public float CurrentTime
        {
            get
            {
                return Time.time;
            }
        }

        protected override bool OnAwake()
        {
            return true;
        }
    }
}