using UnityEngine;

namespace System
{
    public class TimerHolder : MonoBehaviour
    {
        private RealtimeTimer m_answerTimer;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            InitEvents();
        }

        private void InitEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnStartTimeEvent += StartTimer;
        }
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnStartTimeEvent -= StartTimer;
        }

        private void Dispose()
        {
            DisposeEvents();
            m_answerTimer.Final();
        }

        public void OnDestroy()
        {
            Dispose();
        }

        private void StartTimer(TimeSpan span, Action onComplete = null)
        {
            if (span.TotalSeconds > 0)
                UpdateTimer(span, onComplete);
        }
        private void UpdateTimer(TimeSpan time, Action onComplete = null)
        {
            if (time.TotalSeconds > 0)
            {
                if (m_answerTimer == null)
                {
                    m_answerTimer = this.gameObject.AddComponent<RealtimeTimer>();
                    m_answerTimer.OnTimeTick += OnTimeTick;
                }
                m_answerTimer.Run(time, 2f, onComplete);
            }
        }
        private void  OnTimeTick(TimeSpan span)
        {
            ApplicationContainer.Instance.EventHolder.OnTimeTick(span);
        }
    }
}
