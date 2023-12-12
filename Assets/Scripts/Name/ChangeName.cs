using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Name
{
    public class ChangeName : MonoBehaviour
    {
        [SerializeField] TMP_InputField m_inputField = null;
        private NameController m_controller = null;
        private void Start()
        {
            m_controller ??= new NameController();
            if(m_controller.MainName == string.Empty)
                m_controller.SaveName(GlobalConst.DefaultName);
            m_inputField.text = m_controller.MainName;
            
        }

        public void ValidateChanges()
        {
            string match = Regex.Match(m_inputField.text, "^[а-яА-Яa-zA-Z0-9äöüÄÖÜß_-]*$").Value;
            if (m_inputField.text.Length > 0)
            {
                m_inputField.text = m_inputField.text.Equals(match) ? match : m_inputField.text.Remove(m_inputField.text.Length - 1, 1);
            }
        }

        public void SetName()
        {
            m_controller = new NameController();
            m_controller.SaveName(m_inputField.text);
        }
    }
}
