using System.Media;

namespace Clock
{
    class Utilities
    {
        static public void playSound(string fileName)
        {
            SoundPlayer simpleSound = new SoundPlayer(@fileName);
            simpleSound.Play();
        }

    }
}
