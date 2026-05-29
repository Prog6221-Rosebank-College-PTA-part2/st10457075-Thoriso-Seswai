using Microsoft.VisualBasic.ApplicationServices;
using System.Media;


namespace Prog6221_Part_2_ST10457075_Thoriso_Seswai
{
    class Sound
    {
        public void PlayGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\OneDrive - ADvTECH Ltd\\Documents\\PROG6221_Part 2_ST10457075_Thoriso_Seswai\\Prog6221_Part 2_ST10457075_Thoriso_Seswai\\welcome.wav");

            player.Play();
        }
    }
}

