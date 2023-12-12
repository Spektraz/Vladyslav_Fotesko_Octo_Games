using System.Collections;
using UnityEngine;

namespace System
{
    public class RealtimeTimer : MonoBehaviour
    {
        public Action<TimeSpan> OnTimeTick;
        private DateTime m_startTime;
        private TimeSpan m_span;
        private Coroutine m_curentTimer = null;
        private Action m_onFinish;

        private int m_mod = 0;
        private float m_tickrate;
        private bool m_isRunning = false;
        public bool IsRunning => m_isRunning;

        public TimeSpan CurrentTime
        {
            get
            {
                if (m_mod == 1)
                {
                    return (DateTime.UtcNow - m_startTime);
                }
                else
                {
                    return m_span - (DateTime.UtcNow - m_startTime);
                }
            }
        }

        public void Run(TimeSpan span, float tickRate, Action onFinish)
        {
            m_startTime = DateTime.UtcNow;
            m_span = span;
            m_tickrate = tickRate;
            m_mod = -1;
            m_onFinish = onFinish;
            m_isRunning = true;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod));
        }

        public void Run(float tickRate)
        {
            m_startTime = DateTime.UtcNow;
            m_onFinish = null;
            m_mod = 1;
            m_isRunning = true;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod));
        }

        public void Final()
        {
            m_isRunning = false;
            if (m_onFinish != null)
            {
                m_onFinish();
            }
        }

        private IEnumerator Timetik(int factor)
        {
            bool isActive = true;
            while (isActive)
            {
                if (OnTimeTick != null)
                {
                    OnTimeTick(CurrentTime);
                }

                if (m_mod == -1 && CurrentTime.TotalSeconds <= 0)
                {
                    isActive = false;
                    Final();
                }
                yield return new WaitForSecondsRealtime(1f / m_tickrate);
            }
        }
    }
}