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
using System.Text.RegularExpressions;
using System.Data.Entity;

namespace HospitalProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        Doctors doctor = new Doctors();

        public DoctorsWindow()
        {
            InitializeComponent();
            dostorsList();

        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }

        void Clear()
        {
            DocName_input.Text = DocLastName_input.Text = DocPESEL_input.Text = DocPhone_input.Text = DocEmail_input.Text = IdSpec_input.Text = "";
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void AddDoc_btn_Click(object sender, RoutedEventArgs e)
        {   

            doctor.FirstName = DocName_input.Text;
            doctor.LastName = DocLastName_input.Text;
            doctor.PESEL = DocPESEL_input.Text;
            doctor.phoneNb = DocPhone_input.Text;
            doctor.mail = DocEmail_input.Text;
            var idspec = IdSpec_input.Text;
            int idValue = int.Parse(idspec);
            doctor.specializations = idValue;

            using (PrzychodniaEntities db = new PrzychodniaEntities())
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
            MessageBox.Show("Dodano nowego lekarza");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource przychodniaEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("przychodniaEntitiesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // przychodniaEntitiesViewSource.Źródło = [ogólne źródło danych]
        }
        private void dostorsList()
        {
            using (PrzychodniaEntities db = new PrzychodniaEntities())
            {
                doctorsDataGrid.ItemsSource = db.Doctors.ToList();
            }
              
        }

    }
}
