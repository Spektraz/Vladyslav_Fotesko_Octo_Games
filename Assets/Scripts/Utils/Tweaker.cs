using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Utils
{
    public class TweakerWindow : EditorWindow
    {
        [MenuItem("Game/Tools/Tweaker")]
        public static void ShowWindow()
        {
            TweakerWindow wnd = (TweakerWindow)EditorWindow.GetWindow(typeof(TweakerWindow));
            wnd.Show();
        }

        List<Tweaks> buttons = new List<Tweaks>();

        void OnGUI()
        {
            if(buttons.Count == 0)
                InitButtons();
            
            ShowButtons();
        }

        void InitButtons()
        {
            buttons = new List<Tweaks>(Tweaker.DeleteSave());
        }

        void ShowButtons()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();

            float width = EditorGUIUtility.currentViewWidth;

            foreach (var button in buttons)
            {
                width -= button.GetSize();
                if (width < 0.0f)
                {
                    width = EditorGUIUtility.currentViewWidth - button.GetSize();
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }

                button.OnGUI();
            }

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
    }
}
