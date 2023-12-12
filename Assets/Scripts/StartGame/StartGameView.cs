using UnityEngine;

namespace StartGame
{
    public class StartGameView : MonoBehaviour
    {
        [SerializeField] private StartGameModel m_viewModel = null;
        private StartGameController m_controller = null;

        private void Start()
        {
            m_controller = new StartGameController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}
