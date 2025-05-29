using System;
using System.Windows.Forms;
using Microsoft.Owin.Hosting;

namespace APxCommander3.Backend
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            WebSocketHost.Start(); // Start Fleck WebSocket
            string baseUrl = "http://localhost:5000";
            WebApp.Start<Startup>(url: baseUrl); // Start REST API
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}