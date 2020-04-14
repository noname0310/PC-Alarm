using System;
using System.Threading;

namespace PC_Alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 2;
            Console.WindowWidth = 60;
            Console.BufferHeight = 2;
            Console.BufferWidth = 60;
            Console.Write("Input Time to wake up: ");
            string dateInput = Console.ReadLine();
            DateTime parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(string.Format("time was setted at {0}", parsedDate));

            CountdownEvent countEventObject = new CountdownEvent(1);
            AlarmTimer alarmTimer = new AlarmTimer(parsedDate, countEventObject);
            alarmTimer.Alarm += AlarmTimer_Alarm;
            countEventObject.Wait();
            countEventObject.Dispose();
        }

        private static void AlarmTimer_Alarm(object sender, EventArgs e)
        {
            MusicKeyInput.PauseTrack();
        }
    }
}
