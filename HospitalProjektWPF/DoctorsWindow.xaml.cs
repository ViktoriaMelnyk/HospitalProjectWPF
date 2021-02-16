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
    /// Logika interakcji dla klasy DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        public DoctorsWindow()
        {
            InitializeComponent();
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }
    }
}
