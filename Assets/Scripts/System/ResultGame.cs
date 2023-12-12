namespace System
{
    public class ResultGame
    {
        private int m_winCount = 0;
        private string m_timeCount = string.Empty;
        private bool m_isRandom = false;
        private bool m_isWin = false;
        private bool m_isSave = false;
        private bool m_isLast = false;
        public int WinCount
        {
            get => m_winCount;
            set => m_winCount = value;
        }
        public bool IsLast
        {
            get => m_isLast;
            set => m_isLast = value;
        }
        public bool IsRandom
        {
            get => m_isRandom;
            set => m_isRandom = value;
        }
        public bool IsSave
        {
            get => m_isSave;
            set => m_isSave = value;
        }
        public bool IsWin
        {
            get => m_isWin;
            set => m_isWin = value;
        }
        public string TimeCount
        {
            get => m_timeCount;
            set => m_timeCount = value;
        }
    }
}
