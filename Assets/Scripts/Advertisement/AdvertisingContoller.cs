namespace Advertisement
{
    public class AdvertisingContoller 
    {
        private AdvertisingModel m_viewModel = null;
       
    
        public AdvertisingContoller(AdvertisingModel viewModel)
        {
            m_viewModel = viewModel;
          
        }
        public void Initialize()
        {
            InitializeButtons();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
         //   ApplicationContainer.Instance.EventHolder.OnStateAdvertisingEvent += GoodResultAdvertising;
        }

        private void InitializeButtons()
        {
            m_viewModel.CloseButton.onClick.AddListener(ClosePanel);
            m_viewModel.AdvertisingButton.onClick.AddListener(Advertising);
        }
        private void DisposeButtons()
        {
            
        }
        public void Dispose()
        {
            DisposeButtons();
        }

        private void Advertising()
        {
            
        }
        private void ClosePanel()
        {
            m_viewModel.AdvertisingCanvas.enabled = false;
        }
    }
}
