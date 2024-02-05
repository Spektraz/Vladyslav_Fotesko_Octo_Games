using UnityEngine;
using UnityEngine.UI;

namespace StartMenu
{
    public class StartMenuModel : MonoBehaviour
    {
        [Header("Button Main")]
        [SerializeField] private Button m_startButton = null;
        [Header("Audio")]
        [SerializeField] private AudioSource m_audioSource = null;
        public Button StartButton => m_startButton;
        public AudioSource AudioSource => m_audioSource;
    }
}
