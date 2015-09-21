using UnityEngine;
using System;

namespace Utils
{
    public struct SyncInterpolation<T>
    {
        private float m_SyncInterval;
        public float SyncInterval
        {
            get
            {
                return m_SyncInterval;
            }
        }

        private float m_LastSyncTime;

        private T m_From;
        private T m_To;

        private Func<T, T, float, T> m_InterpolationMethod;
        private ITimeSource m_TimeSource;

        public T Current
        {
            get
            {
                if (m_InterpolationMethod == null)
                    return m_From;

                var current = m_InterpolationMethod(m_From, m_To, NormalizedProgress);
                return current;
            }
        }

        private float ElapsedTimeSinceLastSync
        {
            get
            {
                if (m_LastSyncTime == 0.0f)
                    return 0.0f;
                else
                    return m_TimeSource.CurrentTime - m_LastSyncTime;
            }
        }

        private float NormalizedProgress
        {
            get
            {
                if (m_SyncInterval == 0.0f)
                    return 0.0f;
                else
                    return ElapsedTimeSinceLastSync / m_SyncInterval;
            }
        }

        public SyncInterpolation(T initial_val, Func<T, T, float, T> interpolation_method, ITimeSource time_source = null)
        {
            m_SyncInterval = 0.0f;
            m_LastSyncTime = 0.0f;
            m_From = initial_val;
            m_To = initial_val;
            m_InterpolationMethod = interpolation_method;
            m_TimeSource = time_source;

            if (m_TimeSource == null)
                m_TimeSource = DefaultTimeSource.Instance;
        }

        public void Reset(T from, T to)
        {
            m_From = from;
            m_To = to;

            var current_time = m_TimeSource.CurrentTime;

            m_SyncInterval = current_time - m_LastSyncTime;
            m_LastSyncTime = current_time;
        }
    }
}