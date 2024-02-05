using UnityEngine;

namespace MainGame
{
    public class WheelFortuneView : MonoBehaviour
    {
        [SerializeField] private WheelFortuneModel m_viewModel = null;
        private WheelFortuneController m_controller = null;

        private void Start()
        {
            m_controller = new WheelFortuneController(m_viewModel);
            m_controller.Initialize();
        }
        public void Result()
        {
            m_controller.Result();
        }
        public void Result(int changeCoins)
        {
            m_controller.Result(changeCoins);
        }
        private void OnDestroy()
        {
            m_controller.Dispose();
        }
        
    }
}
