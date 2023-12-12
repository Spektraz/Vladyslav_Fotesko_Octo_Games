using UnityEngine;

namespace MainGame
{
    public class AddNewQuestionView : MonoBehaviour
    {
        [SerializeField] private AddNewQuestionModel m_viewModel = null;
        private AddNewQuestionController m_controller = null;

        private void Start()
        {
            m_controller = new AddNewQuestionController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
        
    }
}
