using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.System.Tools
{
    public class Timer : MonoBehaviour
    {
        public Action<float> OnChangeTimEvent;
        private Coroutine m_curentTimer = null;
        public Action m_onFinish;
        private List<KeyValuePair<float, Action>> m_optionalActions = new List<KeyValuePair<float, Action>>();
        private List<bool> m_optionalActionExecuted = new List<bool>();

        private int m_mod = 0;

        public float CurrentTime { get; private set; } = 0;
        public float FullTime { get; private set; } = 0;

        public void Initialize()
        {
            CurrentTime = 0;
            FullTime = 0;
            m_onFinish = null;
            m_mod = 1;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod, m_onFinish));
        }

        public void Initialize(float timer, Action onFinish)
        {
            CurrentTime = timer;
            FullTime = 0;
            m_mod = -1;
            m_onFinish = onFinish;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod, m_onFinish));
        }

        public void ProlongTime(float timer)
        {
            CurrentTime += timer;
            m_mod = -1;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod, m_onFinish));
        }
        public void Restart(float timer)
        {
            CurrentTime = timer;
            m_mod = -1;
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
                m_curentTimer = null;
            }
            m_curentTimer = StartCoroutine(Timetik(m_mod, m_onFinish));
        }
        public void AddOptionalAction(float time, Action action)
        {
            m_optionalActions.Add(new KeyValuePair<float, Action>(time, action));
            m_optionalActionExecuted.Add(false);
        }

        public void Pause()
        {
            if (m_curentTimer != null)
            {
                StopCoroutine(m_curentTimer);
            }
            //m_time = 0;
            m_curentTimer = null;
        }

        public void Resume()
        {
            if (m_curentTimer == null)
            {
                m_curentTimer = StartCoroutine(Timetik(m_mod, m_onFinish));
            }
        }

        private IEnumerator Timetik(int factor, Action onfinish)
        { 
            bool isStart = true;
            while (isStart)
            {
                if (OnChangeTimEvent != null)
                {
                    OnChangeTimEvent(CurrentTime);
                }
                CurrentTime += factor * Time.deltaTime;
                FullTime += Time.deltaTime;

                if (CurrentTime <= 0)
                {
                    isStart = false;
                    if(onfinish != null)
                    {
                        onfinish();
                    }
                }
                if (m_optionalActions.Count > 0)
                {
                    for (int i = 0; i < m_optionalActions.Count; i++)
                    {
                        if (!m_optionalActionExecuted[i] && ((CurrentTime < m_optionalActions[i].Key && factor == -1)|| (CurrentTime > m_optionalActions[i].Key && factor == 1)))
                        {
                            m_optionalActions[i].Value();
                            m_optionalActionExecuted[i] = true;
                        }
                    }
                }
                yield return null;
            }
        }
    }
}
