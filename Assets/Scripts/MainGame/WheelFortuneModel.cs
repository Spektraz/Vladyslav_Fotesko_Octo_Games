using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MainGame
{
    public class WheelFortuneModel : MonoBehaviour
    {
        
        [Header("Name User")]
        [SerializeField] private TextMeshProUGUI m_name;
        
        [Header("Main Coins")]
        [SerializeField] private TextMeshProUGUI m_coins;
        
        [Header("Numbers")]
        [SerializeField] private List<TextMeshProUGUI> m_numbers;
        
        [Header("Start Button")]
        [SerializeField] private Button m_startWheel;

        [Header("Animation")] 
        [SerializeField] private Animator m_animatorWheel;

        [Header("Event System")] 
        [SerializeField] private EventSystem m_eventSystem;
        
        public  List<TextMeshProUGUI> Numbers => m_numbers;
        public Animator AnimatorWheel => m_animatorWheel;
        public EventSystem EventSystem => m_eventSystem;
        public Button StartWheel => m_startWheel;
        public TextMeshProUGUI Coins => m_coins;
       
        
    }
}
