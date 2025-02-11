namespace ServerManagement.StateStore
{
    public class Observer
    {
        protected Action? _listeners;
        
        public void AddStateChangeListener(Action? listener)
        {
            if(listener != null)
                _listeners += listener;
        }
        
        public void RemoveStateChangeListener(Action? listener)
        {
            if (listener != null)
                _listeners -= listener;
        }

        public void BroadcastStateChange()
        {
            _listeners?.Invoke();
        }

    }
}
