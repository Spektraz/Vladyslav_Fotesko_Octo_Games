using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartGame
{
    public class StartGameController
    {
        private StartGameModel m_viewModel = null;
        private int maxCharacters = 10; 
        public StartGameController(StartGameModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public void Initialize()
        {
            InitializeButtons();
            InitializeNamePlayer();
        }
        private void InitializeButtons()
        {
            m_viewModel.CloseButton.onClick.AddListener(CloseGame);
            m_viewModel.StartButton.onClick.AddListener(StartGame);
        }

        private void InitializeNamePlayer()
        {
            
            m_viewModel.NamePlayer.onValueChanged.AddListener(OnInputValueChanged);
            m_viewModel.NamePlayer.text = SaveManager.LoadString(GlobalConst.PlayerName);
        }
        private void DisposeButtons()
        {
            m_viewModel.CloseButton.onClick.RemoveListener(CloseGame);
            m_viewModel.StartButton.onClick.RemoveListener(StartGame);
        }
        public void Dispose()
        {
            DisposeButtons();
        }
        private void StartGame()
        {
            SaveManager.Save("PlayerName", m_viewModel.NamePlayer.text);
            SceneManager.LoadScene(GlobalConst.SceneFirstLocal);
        }

        private void ColorStartGame(bool isActive)
        {
            if (isActive)
            {
                m_viewModel.StartButton.enabled = false;
                m_viewModel.StartButton.image.color = Color.gray;;
            }
            else
            {
                m_viewModel.StartButton.enabled = true;
                m_viewModel.StartButton.image.color = Color.white;;
            }
        }
        private void CloseGame()
        {
            Application.Quit();
        }
        private void OnInputValueChanged(string newValue)
        {
            if (newValue.Length > maxCharacters)
            {
                m_viewModel.NamePlayer.text = newValue.Substring(0, maxCharacters);
            }
            if (!IsInputLanguageValid(newValue))
            {
                m_viewModel.NamePlayer.text =  m_viewModel.NamePlayer.text.Substring(0,  m_viewModel.NamePlayer.text.Length - 1);
                Debug.LogWarning("Error name");
            }
            else 
                ColorStartGame(IsEmpty(newValue));
        }

        private bool IsInputLanguageValid(string inputText)
        {
            return IsEmpty(inputText) || System.Text.RegularExpressions.Regex.IsMatch(inputText, @"^[a-zA-Z]+$");
        }

        private bool IsEmpty(string inputText)
        {
            return inputText == String.Empty;
        }
    }
}
