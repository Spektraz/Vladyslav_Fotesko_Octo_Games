using System;
using MainGame.Question;
using UnityEngine;

namespace MainGame
{
    public class AddNewQuestionController 
    {
        private AddNewQuestionModel m_viewModel = null;
        private QuestionManager m_questionManager = null;
        public AddNewQuestionController(AddNewQuestionModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            m_viewModel.ComeBack.onClick.AddListener(CloseWindow);
            m_viewModel.SaveQuestion.onClick.AddListener(SaveQuestion);
        }
        
        private void DisposeButtons()
        {
            m_viewModel.ComeBack.onClick.RemoveAllListeners();
            m_viewModel.SaveQuestion.onClick.RemoveAllListeners();
        }
        public void Dispose()
        {
            DisposeButtons();
        }

        private void CloseWindow()
        {
            ApplicationContainer.Instance.EventHolder.OnCloseQuestionWindow(false);
        }

        private void SaveQuestion()
        {
            m_questionManager = new QuestionManager();
            m_questionManager.TryCreateNewItem(CreateItem(m_questionManager));
        }

        private QuestionItem CreateItem(QuestionManager questionManager)
        {
            QuestionItem newItem = ScriptableObject.CreateInstance<QuestionItem>();
            newItem.Question = m_viewModel.MainQuestion.text;
            newItem.AnswerFirst = m_viewModel.FirstAnswer.text;
            newItem.AnswerSecond = m_viewModel.SecondAnswer.text;
            newItem.AnswerThird = m_viewModel.ThirdAnswer.text;
            newItem.AnswerFouth = m_viewModel.FouthAnswer.text;
            var winAnswer = Int32.Parse(m_viewModel.CorrectAnswer.text);
            newItem.WinAnswer = winAnswer;
            newItem.IsUse = false;
            var countQuestion = questionManager.CountItem();
            newItem.ID = countQuestion;
            return newItem;
        }
    }
}
