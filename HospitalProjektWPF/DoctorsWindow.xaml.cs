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
        void Clear()
        {
            DocName_input.Text = DocLastName_input.Text = DocPESEL_input.Text = DocPhone_input.Text = DocEmail_input.Text = IdSpec_input.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
            System.Windows.Data.CollectionViewSource przychodniaEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("przychodniaEntitiesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // przychodniaEntitiesViewSource.Źródło = [ogólne źródło danych]
        }

      

        private void AddDoc_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new PrzychodniaEntities();
            InvalidData_box.Text = "";
            var doctorsTable = db.Doctors;
            var specTable = db.Specializations;
            string name = DocName_input.Text;
            if (name == "")
            {
                InvalidData_box.Text = "Proszę podać imę!";
                return;
            }
            string lastName = DocLastName_input.Text;
            if (lastName == "")
            {
                InvalidData_box.Text = "Proszę podać nazwisko!";
                return;
            }
            string pesel = DocPESEL_input.Text;
            if (pesel == "" || pesel.Length != 11)
            {
                InvalidData_box.Text = "Proszę podać prawidłowy PESEL";
                return;
            }
            if (doctorsTable.Where(d => d.PESEL == pesel).ToList().Count == 1)
            {
                InvalidData_box.Text = "Lekarz z takim numerem PESEL już jest w systemie";
                return;
            }
            string phone = DocPhone_input.Text;
            if (phone == "" || phone == "Phone")
            {
                InvalidData_box.Text = "Proszę podać prawidłowy numer telefonu";
                return;
            }
            string idspec = IdSpec_input.Text;
            int idValue = int.Parse(idspec);
            if (specTable.Where(s => s.idSpec == idValue).ToList().Count != 1)
            {
                InvalidData_box.Text = "Nie ma takiej specjalizacj";
                return;
            }

            Doctors doctor = new Doctors()
            {
                FirstName = DocName_input.Text,
                LastName = DocLastName_input.Text,
                PESEL = DocPESEL_input.Text,
                phoneNb = DocPhone_input.Text,
                mail = DocEmail_input.Text,
                specializations = idValue
            };
            
           
            
            db.Doctors.Add(doctor);
            db.SaveChanges();
            Clear();
            dostorsList();
            MessageBox.Show("Dodano nowego lekarza");
        }


        private void dostorsList()
        {
            var db = new PrzychodniaEntities();
            doctorsDataGrid.AutoGenerateColumns = false;
            doctorsDataGrid.ItemsSource = db.Doctors.ToList();
        }

        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }


        //private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    DataGridRow row = sender as DataGridRow;
        //    var db = new PrzychodniaEntities();
        //    var doctor = new Doctors();
        //    doctor.idDoc = Convert.ToInt32(row.idDoc.value);
        //    doctor = db.Doctors.Where(d => d.idDoc == doctor.idDoc);
        //    DocName_input.Text = doctor.FirstName;
        //    DocLastName_input.Text = doctor.LastName;
        //    DocPESEL_input.Text = doctor.PESEL;
        //    DocPhone_input.Text = doctor.phoneNb;
        //    DocEmail_input.Text = doctor.mail;
        //    IdSpec_input.Text = doctor.specializations;



        //}
    }
}
