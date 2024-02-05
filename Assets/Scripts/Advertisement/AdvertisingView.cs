using MainGame;
using UnityEngine;
using Utils;

namespace Advertisement
{
    public class AdvertisingView : MonoBehaviour
    {
        [SerializeField] private AdvertisingModel m_viewModel = null;
        [SerializeField] private AdvertisementUtils m_viewUtils = null;
        [SerializeField] private WheelFortuneView m_wheelFortuneView = null;
        private AdvertisingContoller m_controller = null;

        private void Start()
        {
            m_controller = new AdvertisingContoller(m_viewModel, m_viewUtils, m_wheelFortuneView);
            m_controller.Initialize();
        }
 
        private void OnDestroy()
        {
            m_controller.Dispose();
        }
        
    }
}

