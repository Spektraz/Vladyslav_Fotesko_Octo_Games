using Ui;
using UnityEngine;

namespace Assets.Scripts.UI.Window
{
    public interface IWindow : IUIElement
    {
        Transform transform { get; }
        bool IsModal { get; }
    }
}