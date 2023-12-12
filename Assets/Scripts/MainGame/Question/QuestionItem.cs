using UnityEngine;

namespace MainGame.Question
{ 
    [CreateAssetMenu(fileName = "QuestionItem", menuName = "Question/QuestionItem")]
    public class QuestionItem : ScriptableObject
    {
        #region Variable
        
            [SerializeField] private int m_id;
            [SerializeField] private int m_winAnswer;
            [SerializeField] private bool isUse;
            [SerializeField] private string m_questionKey;
            [SerializeField] private string m_answerFirst;
            [SerializeField] private string m_answerSecond;
            [SerializeField] private string m_answerThird;
            [SerializeField] private string m_answerFouth;
            
            #endregion
        
            #region Properties

            public int ID
            {
                get => m_id;
                set => m_id = value;
            }

            public int WinAnswer
            {
                get => m_winAnswer;
                set => m_winAnswer = value;
            }

            public bool IsUse
            {
                get => isUse;
                set => isUse = value;
            }

            public string Question
            {
                get => m_questionKey;
                set => m_questionKey = value;
            }

            public string AnswerFirst
            {
                get => m_answerFirst;
                set => m_answerFirst = value;
            }

            public string AnswerSecond
            {
                get => m_answerSecond;
                set => m_answerSecond = value;
            }

            public string AnswerThird
            {
                get => m_answerThird;
                set => m_answerThird = value;
            }

            public string AnswerFouth
            {
                get => m_answerFouth;
                set => m_answerFouth = value;
            }

            #endregion
        }
}
