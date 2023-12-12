using System;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class AudioSwitch : MonoBehaviour
    {
        [SerializeField] private Button m_audioButton = null;
        [SerializeField] private Image m_closeMusic = null;
        private bool m_isClose = false;
        private void Start()
        {
            CheckSound();
            m_audioButton.onClick.AddListener(SetStateAudio);
        }

        private void OnDestroy()
        {
            m_audioButton.onClick.RemoveAllListeners();
        }

        private void CheckSound()
        { 
            m_isClose = Load();
            m_closeMusic.enabled = m_isClose;
            ApplicationContainer.Instance.EventHolder.OnSwitchAudio(m_isClose);
        }
        private void SetStateAudio()
        {
            m_isClose = !m_isClose;
            m_closeMusic.enabled = m_isClose;
            Save(BoolToInt(m_isClose));
            ApplicationContainer.Instance.EventHolder.OnSwitchAudio(m_isClose);
        }
        private void Save(int save)
        {
            SaveManager.Save(GlobalConst.SoundKey, save);
        }

        private bool Load()
        {
            var result = SaveManager.LoadInt(GlobalConst.SoundKey);
            return IntToBool(result);
        }
        #region Utils bool

        private static int BoolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        private static bool IntToBool(int val)
        {
            return val != 0;
        }
        #endregion
    }
}
