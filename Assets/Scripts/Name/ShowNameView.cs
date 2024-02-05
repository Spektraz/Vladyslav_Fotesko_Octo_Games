using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace Name
{
    public class ShowNameView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI m_nameText = null;
        private NameController m_controller = null;
        private void Start()
        {
            m_controller ??= new NameController();
            if(m_controller.MainName == string.Empty)
                m_controller.SaveName(GlobalConst.DefaultName);
            m_nameText.text = m_controller.MainName;
            
        }

      
    }
}
