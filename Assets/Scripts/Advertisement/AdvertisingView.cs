using UnityEngine;

namespace Advertisement
{
    public class AdvertisingView : MonoBehaviour
    {
        [SerializeField] private AdvertisingModel m_viewModel = null;
        private AdvertisingContoller m_controller = null;

        private void Start()
        {
            m_controller = new AdvertisingContoller(m_viewModel);
            m_controller.Initialize();
        }
 
        private void OnDestroy()
        {
            m_controller.Dispose();
        }
        
    }
}

