using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DIDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tight coupling:
        //ConsoleLogger myLogger = new ConsoleLogger();
        //FileLogger myLogger = new FileLogger();

        // Loose Coupling:
        ILogger myLogger = null;



        // De injection gebeurt in de constructor:
        // De logger komt van buitenaf. Where?
        public MainWindow(ILogger logger = null)
        {
            InitializeComponent();

            myLogger = logger;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int getal1 = int.Parse(txtGetal1.Text);
                int getal2 = int.Parse(txtGetal2.Text);

                int antwoord = getal1 / getal2;

                MessageBox.Show($"Het antwoord is {antwoord}.");
            }
            catch (Exception ex)
            {
                // Hier log ik een message. De logger kan null zijn daarom de ?.
                myLogger?.LogMessage(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Log het aanmaken van dit Window!
            myLogger?.LogMessage("Het MainWindow is opgestart!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new SecondWindow(myLogger);
            win.Show();
        }
    }
}
