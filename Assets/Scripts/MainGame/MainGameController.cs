using System;
using UnityEngine.SceneManagement;
using Utils;

namespace MainGame
{
    public class MainGameController
    {
        private MainGameModel m_viewModel = null;
        private TimeSpan m_span;
        private bool m_isRandom = false;
        public MainGameController(MainGameModel viewModel)
        {
            m_viewModel = viewModel;
        }
        public void Initialize()
        {
            InitializeButtons();
            InitializeName();
            InitializeTime();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnTimeTickEvent += TimeTick;
            ApplicationContainer.Instance.EventHolder.OnLooseAnswerEvent += LooseAnswer;
            ApplicationContainer.Instance.EventHolder.OnCloseQuestionWindowEvent += AddQuestion;
            ApplicationContainer.Instance.EventHolder.OnFinishGameEvent += FinishGame;
        }
        
        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnTimeTickEvent -= TimeTick;
            ApplicationContainer.Instance.EventHolder.OnLooseAnswerEvent -= LooseAnswer;
            ApplicationContainer.Instance.EventHolder.OnCloseQuestionWindowEvent -= AddQuestion;
            ApplicationContainer.Instance.EventHolder.OnFinishGameEvent -= FinishGame;
        }
        private void InitializeTime()
        {
            TimeSpan span = TimeToRecharge();
            ApplicationContainer.Instance.EventHolder.OnStartTime(span, (() => FinishGame(false)));
        }
        
        private TimeSpan TimeToRecharge()
        {
            DateTime time = DateTime.UtcNow;
            return m_span;
            // return (time + TimeSpan.FromMinutes(GlobalConst.TimeDuration)) - DateTime.UtcNow;
        }
        private void TimeTick(TimeSpan span)
        {
            if (span.TotalSeconds > 0.1)
            {
                m_viewModel.TimeGame.text = StringUtils.TimeSpanToFormattedString(span);
            }
            else
            {
                ApplicationContainer.Instance.EventHolder.OnFinishGame(false);
                ApplicationContainer.Instance.ResultGame.IsWin = false;
            }
        }
        private void InitializeName()
        {
            m_viewModel.YourName.text = SaveManager.LoadString(GlobalConst.NameKey);
        }

        private void InitializeButtons()
        {
            m_viewModel.AddQuestionButton.onClick.AddListener(()=>ApplicationContainer.Instance.EventHolder.OnCloseQuestionWindow(true));
            m_viewModel.RandomQuestion.onClick.AddListener(RandomQuestion);
        }
        
        private void DisposeButtons()
        {
            m_viewModel.AddQuestionButton.onClick.RemoveAllListeners();
            m_viewModel.RandomQuestion.onClick.RemoveAllListeners();
        }
        public void Dispose()
        {
            DisposeButtons();
            DisposeEvents();
        }
        private void LooseAnswer(int count)
        {
            // if (count == GlobalConst.CountMistake)
            // {
            //     ApplicationContainer.Instance.EventHolder.OnFinishGame(false);
            //     ApplicationContainer.Instance.ResultGame.IsWin = false;
            //     FinishGame(false);
            // }

            m_viewModel.MistakeGame.text = count.ToString();
        }

        private void FinishGame(bool state)
        {
            ApplicationContainer.Instance.ResultGame.IsRandom = false;
            ApplicationContainer.Instance.ResultGame.TimeCount = m_viewModel.TimeGame.text;
       //     SceneManager.LoadScene(GlobalConst.SceneFinishGame);
        }
        private void RandomQuestion()
        {
            m_isRandom = !m_isRandom;
            m_viewModel.RandomPutImage.enabled = m_isRandom;
            ApplicationContainer.Instance.ResultGame.IsRandom = m_isRandom;
        }
        private void AddQuestion(bool state)
        {
            m_viewModel.CanvasCreateQuestion.enabled = state;
        }
    }
}
