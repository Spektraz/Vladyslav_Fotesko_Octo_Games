using System;
using Random = UnityEngine.Random;

namespace MainGame.Question
{
    public class QuestionController 
    {
        private QuestionModel m_viewModel = null;
        private QuestionManager m_questionManager = null;
        private int m_winNumberAnswer = 0;
        private int m_looseAnswer = 0;
        private int m_winAnswer = 0;
        private int counterQuestion = 0;
        private int countRandom = 0;
        public QuestionController(QuestionModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            InitializeButtons();
            InitializeEvents();
            SetQuestion(0);
        }
        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnFinishGameEvent += Save;
        }

        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnFinishGameEvent -= Save;
        }
        private void InitializeRandomQuestion()
        {
            m_questionManager = new QuestionManager();
            // if (countRandom > GlobalConst.CountMistakeRandom)
            // {
            //     SetQuestion(null);
            //     return;
            // }
            var random = Random.Range(0, m_questionManager.CountItem()+1);
            SetQuestion(random);
        }
        private void InitializeQuestion()
        {
            counterQuestion++;
            SetQuestion(counterQuestion);
        }

        private void SetQuestion(int count)
        {
            m_questionManager = new QuestionManager();
            SetQuestion(m_questionManager.TryGetItem(count));
        }
        private void SetQuestion(QuestionItem questionItem)
        {
            if (questionItem == null)
            {
                ApplicationContainer.Instance.ResultGame.IsWin = true;
                ApplicationContainer.Instance.EventHolder.OnFinishGame(false);
                return;
            }
            if (questionItem.IsUse || ApplicationContainer.Instance.ResultGame.IsLast)
            {
                countRandom++;
                QuestionTypeShow();
                return;
            }
            if (questionItem.ID == m_questionManager.CountItem() + 1)
                ApplicationContainer.Instance.ResultGame.IsLast = true;
            m_viewModel.MainQuestion.text = questionItem.Question;
            m_viewModel.FirstAnswer.text = questionItem.AnswerFirst;
            m_viewModel.SecondAnswer.text = questionItem.AnswerSecond;
            m_viewModel.ThirdAnswer.text = questionItem.AnswerThird;
            m_viewModel.FourthAnswer.text = questionItem.AnswerFouth;
            m_winNumberAnswer = questionItem.WinAnswer;
            SetCountAnswers();
            countRandom = 0;
            questionItem.IsUse = true;
        }
        private void InitializeButtons()
        {
            m_viewModel.FirstButton.onClick.AddListener((() => AnswerVariant(GlobalConst.VariantAnswer.FirstVar)));
            m_viewModel.SecondButton.onClick.AddListener((() => AnswerVariant(GlobalConst.VariantAnswer.SecondVar)));
            m_viewModel.ThirdButton.onClick.AddListener((() => AnswerVariant(GlobalConst.VariantAnswer.ThirdVar)));
            m_viewModel.FourthButton.onClick.AddListener((() => AnswerVariant(GlobalConst.VariantAnswer.FourthVar)));
            
        }
        private void AnswerVariant(GlobalConst.VariantAnswer variantAnswer)
        {
            var id = (int)variantAnswer;
            if (id != m_winNumberAnswer)
            {
                m_looseAnswer++;
                ApplicationContainer.Instance.EventHolder.OnLooseAnswer(m_looseAnswer);
            }
            else
            {
                m_winAnswer++;
                QuestionTypeShow();
            }
        }

        private void SetCountAnswers()
        {
            m_viewModel.FourthObject.SetActive(m_viewModel.FourthAnswer.text != string.Empty);
            m_viewModel.ThirdObject.SetActive(m_viewModel.ThirdAnswer.text != string.Empty);
        }
        private void QuestionTypeShow()
        {
            if (ApplicationContainer.Instance.ResultGame.IsRandom)
                InitializeRandomQuestion();
            else
                InitializeQuestion();
        }
        private void Save(bool state)
        {
            ApplicationContainer.Instance.ResultGame.WinCount = m_winAnswer;
        }
        private void DisposeButtons()
        {
            m_viewModel.FirstButton.onClick.RemoveAllListeners();
            m_viewModel.SecondButton.onClick.RemoveAllListeners();
            m_viewModel.ThirdButton.onClick.RemoveAllListeners();
            m_viewModel.FourthButton.onClick.RemoveAllListeners();
        }
        public void Dispose()
        {
            DisposeQuestion();
            DisposeButtons();
            DisposeEvents();
        }

        private void DisposeQuestion()
        {
            ApplicationContainer.Instance.ResultGame.IsLast = false;
            ApplicationContainer.Instance.ResultGame.IsSave = false;
            m_questionManager = new QuestionManager();
            m_questionManager.ResetIsUse();
        }
    }
}
