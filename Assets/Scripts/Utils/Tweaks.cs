using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public class Tweaks : MonoBehaviour
    {
        public UnityAction pressAction;
        public string name;
        public GUIContent content;
        public Tweaks(string name, UnityAction pressAction)
        {
            this.name = name;
            this.pressAction = pressAction;
            content = new GUIContent(name);
        }
        public float GetSize()
        {
            return GUI.skin.button.CalcSize(content).x + GUI.skin.button.margin.horizontal;
        }

        public bool OnGUI()
        {
            bool pressed = GUILayout.Button(name);
            if(pressed)
            {
                pressAction();
                return true;
            }

            return false;
        }
    }

    public static class Tweaker
    {
        public static List<Tweaks> DeleteSave()
        {
            var buttons = new List<Tweaks>();
            buttons.Add(new Tweaks("Delete all Save",
                () => { PlayerPrefs.DeleteAll(); }));
             return buttons;
        }
    }
}
