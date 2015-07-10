using System;
using System.Media;

namespace Clock
{
    class Utilities
    {
        static public bool itsQuietTime = false;

        static public void playSound(string fileName)
        {
            SoundPlayer simpleSound = new SoundPlayer(@fileName);
            simpleSound.Play();
        }

        static public bool isQuietTime(DateTime timeQuiet)
        {
            DateTime quietStartTime = Properties.Settings.Default.quietStart;
            DateTime quietEndTime = Properties.Settings.Default.quietEnd;

            itsQuietTime = false;

            if (!Properties.Settings.Default.quietTime) return false;

            if (quietStartTime.TimeOfDay < quietEndTime.TimeOfDay) // if the start time is before the end time on the same day
            {
                Console.WriteLine("A - End time is after start time on same day");
                if ((timeQuiet.TimeOfDay >= quietStartTime.TimeOfDay) && (timeQuiet.TimeOfDay <= quietEndTime.TimeOfDay))
                {
                    Console.WriteLine("1 : It's quiet time, time now is " + timeQuiet.TimeOfDay.ToString()
                        + ", quiet time is " + quietStartTime.TimeOfDay.ToString() + " until " + quietEndTime.TimeOfDay.ToString());
                    itsQuietTime = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("2 : It's not quiet time, time now is " + timeQuiet.TimeOfDay.ToString()
                        + ", quiet time is " + quietStartTime.TimeOfDay.ToString() + " until " + quietEndTime.TimeOfDay.ToString());
                    return false;
                }
            }
            else // the end time appears to be earlier than the start, so it must end on a new day
            {
                Console.WriteLine("B - End time is after start time on different day");

                if (timeQuiet.TimeOfDay >= quietStartTime.TimeOfDay)
                {
                    Console.WriteLine("3 : It's quiet time, time now is " + timeQuiet.TimeOfDay.ToString()
                        + ", quiet time is " + quietStartTime.TimeOfDay.ToString() + " until " + quietEndTime.TimeOfDay.ToString());
                    itsQuietTime = true;
                    return true;
                }
                else if (timeQuiet.TimeOfDay <= quietEndTime.TimeOfDay)
                {
                    Console.WriteLine("4 : It's still quiet time but probably after midnight, time now is " + timeQuiet.TimeOfDay.ToString()
                        + ", quiet time is " + quietStartTime.TimeOfDay.ToString() + " until " + quietEndTime.TimeOfDay.ToString());
                    itsQuietTime = true;
                    return true;
                }
            }
            return false;
        }


    }
}
