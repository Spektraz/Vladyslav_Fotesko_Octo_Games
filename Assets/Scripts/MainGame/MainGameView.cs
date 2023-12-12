using UnityEngine;

namespace MainGame
{
    public class MainGameView : MonoBehaviour
    {
        [SerializeField] private MainGameModel m_viewModel = null;
        private MainGameController m_controller = null;

        private void Start()
        {
            m_controller = new MainGameController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}
