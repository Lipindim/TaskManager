using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using TaskManager.Client.Windows;

namespace TaskManager.Client
{
    public class MyApp: Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            MyApp app = new MyApp();
            app.Startup += App_Startup;
            app.DispatcherUnhandledException += App_DispatcherUnhandledException;
            app.Run();
        }

        private static void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private static void App_Startup(object sender, StartupEventArgs e)
        {
            //MainWindow mainWindow = new GUI.MainWindow();
            //mainWindow.Show();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
