using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame
{
    public class AddNewQuestionModel : MonoBehaviour
    {
        [SerializeField] private TMP_InputField m_mainQuestion;
        [Header("Answer")] 
        [SerializeField] private TMP_InputField m_firstAnswer;
        [SerializeField] private TMP_InputField m_secondAnswer;
        [SerializeField] private TMP_InputField m_thirdAnswer;
        [SerializeField] private TMP_InputField m_fouthAnswer;
        [SerializeField] private TMP_InputField m_correctAnswer;
        
        [Header("Save Question")]
        [SerializeField] private Button m_saveQuestion;
    
        [Header("Main Game button")]
        [SerializeField] private Button m_comebackButton;

        public Button ComeBack => m_comebackButton;
        public Button SaveQuestion => m_saveQuestion;
        public TMP_InputField MainQuestion => m_mainQuestion;
        public TMP_InputField FirstAnswer => m_firstAnswer;
        public TMP_InputField SecondAnswer => m_secondAnswer;
        public TMP_InputField ThirdAnswer => m_thirdAnswer;
        public TMP_InputField FouthAnswer => m_fouthAnswer;
        public TMP_InputField CorrectAnswer => m_correctAnswer;
    }
}
