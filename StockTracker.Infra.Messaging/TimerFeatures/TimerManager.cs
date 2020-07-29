using System;
using System.Threading;

namespace StockTracker.Infra.Messaging.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimerStartedAt { get; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 10000);
            TimerStartedAt = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();

            if((DateTime.Now - TimerStartedAt).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
