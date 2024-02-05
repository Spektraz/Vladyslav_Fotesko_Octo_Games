using UnityEngine;

namespace StartMenu
{
    public class StartMenuView : MonoBehaviour
    {
        [SerializeField] private StartMenuModel m_viewModel = null;
        private StartMenuController m_controller = null;

        private void Start()
        {
            m_controller = new StartMenuController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}
