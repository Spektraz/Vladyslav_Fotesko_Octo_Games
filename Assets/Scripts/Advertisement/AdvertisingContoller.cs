using System;
using MainGame;
using Utils;

namespace Advertisement
{
    public class AdvertisingContoller 
    {
        private AdvertisingModel m_viewModel = null;
        private AdvertisementUtils m_advertisementUtils = null;
        private WheelFortuneView m_wheelFortuneView = null;
        public AdvertisingContoller(AdvertisingModel viewModel, AdvertisementUtils advertisementUtils, WheelFortuneView wheelFortuneView)
        {
            m_viewModel = viewModel;
            m_advertisementUtils = advertisementUtils;
            m_wheelFortuneView = wheelFortuneView;
        }
        public void Initialize()
        {
            InitializeButtons();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchAdvertisingEvent += SwitchPanel;
        }
        
        private void InitializeButtons()
        {
            m_viewModel.CloseButton.onClick.AddListener(SetPanel);
            m_viewModel.AdvertisingButton.onClick.AddListener(Advertising);
        }
        private void DisposeButtons()
        {
            m_viewModel.CloseButton.onClick.RemoveListener(SetPanel);
            m_viewModel.AdvertisingButton.onClick.RemoveListener(Advertising);
        }
        public void Dispose()
        {
            DisposeButtons();
            DisposeEvents();
        }

        private void DisposeEvents()
        {
            ApplicationContainer.Instance.EventHolder.OnSwitchAdvertisingEvent -= SwitchPanel; 
        }
        private void Advertising()
        {
            m_advertisementUtils.ShowOffer();
            m_advertisementUtils.userBalanceChanged(20, 100, 10);
            m_wheelFortuneView.Result(1000000);
        }

        private void SetPanel()
        {
            SwitchPanel(false);
        }
        private void SwitchPanel(bool state)
        {
            m_viewModel.AdvertisingCanvas.enabled = state;
        }
    }
}
