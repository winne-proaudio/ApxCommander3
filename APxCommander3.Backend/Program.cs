using System;
using System.Windows.Forms;

namespace APxCommander3.Backend
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // placeholder for actual UI
        }
    }
}