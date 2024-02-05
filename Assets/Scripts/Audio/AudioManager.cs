using System;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager: MonoBehaviour
    {
        [SerializeField] private List<AudioSource> m_audioSourceList = new List<AudioSource>();
        private static GameObject instance = null;
        private void Initialize()
        {
            InitializeEvents();
        }
        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchAudioEvent += SetAudio;
        }

        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchAudioEvent -= SetAudio;
        }
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            if (instance == null)
                instance = gameObject;
            else
                Destroy(gameObject);
            Initialize();
        }
        
        private void OnDestroy()
        {
            DisposeEvents();
        }

        private void SetAudio(bool state)
        {
            foreach (var var in m_audioSourceList)
            {
                var.mute = state;
            }
        }
    }
}
