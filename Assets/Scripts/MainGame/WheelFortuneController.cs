using System;
using Name;
using Save;
using Random = UnityEngine.Random;

namespace MainGame
{
    public class WheelFortuneController 
    {
        private WheelFortuneModel m_viewModel = null;
        private CoinsController m_controller = null;
   
        public WheelFortuneController(WheelFortuneModel viewModel)
        {
            m_viewModel = viewModel;
            Check();
        }
        public void Initialize()
        {
            InitializeButtons();
          
        }
        private void InitializeButtons()
        {
            m_viewModel.StartWheel.onClick.AddListener(PlayFortune);
        }
        private void DisposeButtons()
        {
            m_viewModel.StartWheel.onClick.RemoveAllListeners();
        }
        public void Dispose()
        {
            DisposeButtons();
        }

        private void PlayFortune()
        {
            RandomizerNumbers();
            m_viewModel.AnimatorWheel.SetTrigger(GlobalConst.WheelTrigger);
            m_viewModel.EventSystem.enabled = false;
        }

        public void Result()
        {
            Save(m_viewModel.Numbers[GlobalConst.WinCoins].text);
            m_viewModel.EventSystem.enabled = true;
        }
        private void Check()
        {
            m_controller ??= new CoinsController();
            if(m_controller.MainCoins != null)
                m_viewModel.Coins.text = m_controller.MainCoins.ToString();
            else
                m_viewModel.Coins.text = "0";
        }
        private void Save(string coins)
        {
            m_controller.SaveCoins(coins);
            m_viewModel.Coins.text = m_controller.MainCoins.ToString();
        }
        private void RandomizerNumbers()
        {
            foreach (var var in m_viewModel.Numbers)
            {
                var number =  Random.Range(GlobalConst.StartNumber, GlobalConst.FinishNumber);
                var.text = number.ToString();
                var.text = var.text + "000";
            }
        }
    }
}