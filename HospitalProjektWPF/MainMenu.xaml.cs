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
using System.Windows.Shapes;

namespace HospitalProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWin.Show();
        }

        private void Doctors_btn_Click(object sender, RoutedEventArgs e)
        {
            DoctorsWindow objDocWin = new DoctorsWindow();
            this.Visibility = Visibility.Hidden;
            objDocWin.Show();
        }

        private void Patients_btn1_Click(object sender, RoutedEventArgs e)
        {
            PatientsWindow objPatWin = new PatientsWindow();
            this.Visibility = Visibility.Hidden;
            objPatWin.Show();
        }

        private void Visits_shedule_Click(object sender, RoutedEventArgs e)
        {
            Booking objBWin = new Booking();
            this.Visibility = Visibility.Hidden;
            objBWin.Show();
        }

        private void visit_Click(object sender, RoutedEventArgs e)
        {
            VisitsWindow objVisWin = new VisitsWindow();
            this.Visibility = Visibility.Hidden;
            objVisWin.Show();
        }
    }
}
