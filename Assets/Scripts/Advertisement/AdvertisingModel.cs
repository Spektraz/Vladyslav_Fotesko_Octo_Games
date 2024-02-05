using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Advertisement
{
    public class AdvertisingModel : MonoBehaviour
    {

        [Header("Buttons")] 
        [SerializeField] private Button m_closeButton;
        [SerializeField] private Button m_advertisingButton;
        
        [Header("Canvas")] [SerializeField]
        private Canvas m_advertisingCanvas;
        public Button CloseButton => m_closeButton;
        public Button AdvertisingButton => m_advertisingButton;
        public Canvas AdvertisingCanvas => m_advertisingCanvas;
    }
}
