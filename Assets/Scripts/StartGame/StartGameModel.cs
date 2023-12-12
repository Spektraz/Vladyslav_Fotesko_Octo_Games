using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StartGame
{
    public class StartGameModel : MonoBehaviour
    {
        [Header("Button Main")]
        [SerializeField] private Button m_closeButton = null;
        [SerializeField] private Button m_startButton = null;

        [Header("Name Player")] 
        [SerializeField] private TMP_InputField m_namePlayer = null;
        public Button CloseButton => m_closeButton;
        public Button StartButton => m_startButton;
        public TMP_InputField NamePlayer => m_namePlayer;
        
    }
}
