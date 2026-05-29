using System;
using System.Windows.Forms;

namespace Prog6221_Part_2_ST10457075_Thoriso_Seswai
{
    static class Program1 
        
    {
        [STAThread]

        static void Main()
        {
            Sound wav = new Sound();
            wav.PlayGreeting();

            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}


