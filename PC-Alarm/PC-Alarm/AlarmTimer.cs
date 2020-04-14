using System;
using System.Threading;
using System.Timers;

namespace PC_Alarm
{
    class AlarmTimer
    {
        private EventHandler AlarmEvent;
        private System.Timers.Timer CheckTimer;
        private DateTime AlarmTime;
        private bool Enabled;
        private CountdownEvent CountdownEvent;

        public event EventHandler Alarm
        {
            add { AlarmEvent += value; }
            remove { AlarmEvent -= value; }
        }

        public AlarmTimer(DateTime alarmTime, CountdownEvent countdownEvent)
        {
            AlarmTime = alarmTime;
            CountdownEvent = countdownEvent;

            CheckTimer = new System.Timers.Timer();
            CheckTimer.Elapsed += timer_Elapsed;
            CheckTimer.Interval = 1000;
            CheckTimer.Start();

            Enabled = true;
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Enabled && AlarmTime <= DateTime.Now)
            {
                Enabled = false;
                AlarmEvent?.Invoke(this, EventArgs.Empty);
                CheckTimer.Stop();
                CountdownEvent.Signal();
            }
        }
    }
}
