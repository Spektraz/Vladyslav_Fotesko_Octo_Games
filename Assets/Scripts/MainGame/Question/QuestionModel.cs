using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame.Question
{
    public class QuestionModel : MonoBehaviour
    {
        [Header("Text Question")] 
        [SerializeField] private TextMeshProUGUI m_mainQuestion = null;
        [SerializeField] private TextMeshProUGUI m_firstAnswer = null;
        [SerializeField] private TextMeshProUGUI m_secondAnswer = null;
        [SerializeField] private TextMeshProUGUI m_thirdAnswer = null;
        [SerializeField] private TextMeshProUGUI m_fourthAnswer = null;

        [Header("Button")]
        [SerializeField] private Button m_firstButton = null;
        [SerializeField] private Button m_secondButton = null;
        [SerializeField] private Button m_thirdButton = null;
        [SerializeField] private Button m_fourthButton = null;

        [Header("GameObject")] 
        [SerializeField] private GameObject m_thirdObject = null;
        [SerializeField] private GameObject m_fourthObject = null;
        public TextMeshProUGUI MainQuestion => m_mainQuestion;
        public TextMeshProUGUI FirstAnswer => m_firstAnswer;
        public TextMeshProUGUI SecondAnswer => m_secondAnswer;
        public TextMeshProUGUI ThirdAnswer => m_thirdAnswer;
        public TextMeshProUGUI FourthAnswer => m_fourthAnswer;
        public Button FirstButton => m_firstButton;
        public Button SecondButton => m_secondButton;
        public Button ThirdButton => m_thirdButton;
        public Button FourthButton => m_fourthButton;
        public GameObject ThirdObject => m_thirdObject;
        public GameObject FourthObject => m_fourthObject;
    }
}
