using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DIDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Op deze plek beslis ik welke logger ik gebruik:
            // Hier gebeurt de injection:


            // Lees bijvoorbeeld een config file uit en kies de juiste logger
            // De keuze voor de juiste concrete logger ligt niet in een van de windows
            // Die keuze wordt op een centrale plek gemaakt
            // Bijvoorbeeld bij het opstarten van de applicatie
            // Bijvoorbeeld door een config file uit te lezen

            string omgeving = "Test";

            if (omgeving == "Production")
            {
                var window = new MainWindow(new FileLogger());
                window.Show();
            }

            if (omgeving == "Development")
            {
                var window = new MainWindow(new ConsoleLogger());
                window.Show();
            }

            if (omgeving == "Test")
            {
                var window = new MainWindow();
                window.Show();
            }

        }
    }
}
