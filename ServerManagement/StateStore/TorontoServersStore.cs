namespace ServerManagement.StateStore
{
    public class TorontoServersStore : Observer
    {
        private int _serversOnline;

        public int GetServersOnline()
        {
            return _serversOnline;  
        }

        public void SetServersOnline(int number)
        {
            _serversOnline = number;
            base.BroadcastStateChange();
        }
    }
}
