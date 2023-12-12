using UnityEngine;

namespace MainGame.Question
{
    public class QuestionView : MonoBehaviour
    {
        [SerializeField] private QuestionModel m_viewModel = null;
        private QuestionController m_controller = null;

        private void Start()
        {
            m_controller = new QuestionController(m_viewModel);
            m_controller.Initialize();
        }

        private void OnDestroy()
        {
            m_controller.Dispose();
        }
    }
}
