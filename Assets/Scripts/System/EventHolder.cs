using Assets.Scripts.UI.Window;

namespace System
{
    public class EventHolder 
    {
        public Action<bool> OnSwitchAudioEvent;
        public void OnSwitchAudio(bool state)
        {
            var temp = OnSwitchAudioEvent;
            temp?.Invoke(state);
        }

        public Action<int> OnSwitchAdvertisingEvent;
        public void OnSwitchAdvertising(int count)
        {
            var temp = OnSwitchAdvertisingEvent;
            temp?.Invoke(count);
        }
        public Action<bool> OnStateAdvertisingEvent;
        public void OnStateAdvertising(bool count)
        {
            var temp = OnStateAdvertisingEvent;
            temp?.Invoke(count);
        }


#if true
        public Action<IWindow> OnChangeStateWindowEvent;

        public void OnChangeStateWindow(IWindow window)
        {
            var temp = OnChangeStateWindowEvent;
            if (temp != null)
            {
                temp(window);
            }
        }
      
        public Action<IWindow, bool> OnWindowCloseEvent;

        public void OnWindowClose(IWindow window, bool isShowPanel = true)
        {
            var temp = OnWindowCloseEvent;
            if (temp != null)
            {
                temp(window, isShowPanel);
            }
        }
#endif
    }
}
