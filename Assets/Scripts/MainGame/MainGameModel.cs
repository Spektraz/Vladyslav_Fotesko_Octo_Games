using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame
{
    public class MainGameModel : MonoBehaviour
    {
        [Header("Button Main")]
        [SerializeField] private Button m_addQuestionButton = null;
        [SerializeField] private Button m_randomQuestion = null;
        
        [Header("Time Game")] 
        [SerializeField] private TextMeshProUGUI m_timeGame = null;
        
        [Header("Mistake Game")] 
        [SerializeField] private TextMeshProUGUI m_mistakeGame = null;
        
        [Header("YourName")]
        [SerializeField] private TextMeshProUGUI m_yourName = null;

        [Header("Random Put image")]
        [SerializeField] private Image m_randomPutImage = null;

        [Header("Canvas create question")] 
        [SerializeField] private Canvas m_canvasCreateQuestion;

        public Canvas CanvasCreateQuestion => m_canvasCreateQuestion;
        public Button AddQuestionButton => m_addQuestionButton;
        public Button RandomQuestion => m_randomQuestion;
        public Image RandomPutImage=> m_randomPutImage;
        public TextMeshProUGUI TimeGame => m_timeGame;
        public TextMeshProUGUI MistakeGame => m_mistakeGame;
        public TextMeshProUGUI YourName => m_yourName;
    }
}
