using System;
using System.Threading;

namespace PC_Alarm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 4;
            Console.WindowWidth = 60;
            Console.BufferHeight = 4;
            Console.BufferWidth = 60;


            InputType inputType;
            Console.Write("Alarm Type: ");
            string typeInput = Console.ReadLine();
            if (typeInput == "s")
            {
                Console.WriteLine("AlarmType: Space");
                inputType = InputType.space;
            }
            else
            {
                Console.WriteLine("AlarmType: Media Play");
                inputType = InputType.play;
            }
            Console.Write("Input Time to wake up: ");
            string dateInput = Console.ReadLine();
            DateTime parsedDate = DateTime.Parse(dateInput);
            Console.WriteLine(string.Format("time was setted at {0}", parsedDate));

            CountdownEvent countEventObject = new CountdownEvent(1);
            AlarmTimer alarmTimer = new AlarmTimer(parsedDate, countEventObject);
            if (inputType == InputType.play)
                alarmTimer.Alarm += AlarmTimer_Alarm;
            else
                alarmTimer.Alarm += AlarmTimer_SpaceAlarm;
            countEventObject.Wait();
            countEventObject.Dispose();
        }

        private static void AlarmTimer_Alarm(object sender, EventArgs e)
        {
            MusicKeyInput.PauseTrack();
        }
        private static void AlarmTimer_SpaceAlarm(object sender, EventArgs e)
        {
            MusicKeyInput.SpaceTrack();
        }
    }

    enum InputType
    {
        space,
        play
    }
}
