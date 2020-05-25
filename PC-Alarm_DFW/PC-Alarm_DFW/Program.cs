using System;
using System.Threading;

namespace PC_Alarm
{
    class Program
    {
        static InputType inputType;
        static void Main(string[] args)
        {
            Console.WindowHeight = 4;
            Console.WindowWidth = 60;
            Console.BufferHeight = 4;
            Console.BufferWidth = 60;


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
            alarmTimer.Alarm += AlarmTimer_Alarm;
            countEventObject.Wait();
            countEventObject.Dispose();
        }

        private static void AlarmTimer_Alarm(object sender, EventArgs e)
        {
            if (inputType == InputType.play)
                MusicKeyInput.PauseTrack();
            else
                MusicKeyInput.SpaceTrack();
        }
    }

    enum InputType
    {
        space,
        play
    }
}
