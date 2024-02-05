namespace System
{
    public class ApplicationContainer : Singleton<ApplicationContainer>
    {
        private EventHolder m_eventHolder = null;
        public EventHolder EventHolder
        {
            get { return m_eventHolder; }
        }

    
    

        private void Awake()
        {
            Construct(new EventHolder());
        }
        private void Construct(
            EventHolder eventHolder
        )
        {
            m_eventHolder = eventHolder;
        }
    }
}