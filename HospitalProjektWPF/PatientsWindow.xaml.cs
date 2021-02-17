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
    /// Logika interakcji dla klasy PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        public PatientsWindow()
        {
            InitializeComponent();
            patientsList();
        }


        void Clear()
        {
            Name_input.Text = LastName_input.Text = PESEL_input.Text = Phone_input.Text = email_input.Text = PostalCode_input.Text = City_input.Text = Street_input.Text=Gender_input.Text = "";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
            System.Windows.Data.CollectionViewSource przychodniaEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("przychodniaEntitiesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // przychodniaEntitiesViewSource.Źródło = [ogólne źródło danych]
        }

        private void AddPatient_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new PrzychodniaEntities();
            PatInvalidData_box.Text = "";
            var patientsTable = db.Patients;
            string name = Name_input.Text;
            if (name == "")
            {
                PatInvalidData_box.Text = "Proszę podać imę!";
                return;
            }
            string lastName = LastName_input.Text;
            if (lastName == "")
            {
                PatInvalidData_box.Text = "Proszę podać nazwisko!";
                return;
            }
            string pesel = PESEL_input.Text;
            if (pesel == "" || pesel.Length != 11)
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy PESEL";
                return;
            }
            if (patientsTable.Where(d => d.PESEL == pesel).ToList().Count == 1)
            {
                PatInvalidData_box.Text = "Lekarz z takim numerem PESEL już jest w systemie";
                return;
            }
            string phone = Phone_input.Text;
            if (phone == "" || phone == "Phone")
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy numer telefonu";
                return;
            }
         

            Patients patient = new Patients()
            {
                FirstName = Name_input.Text,
                LastName = LastName_input.Text,
                PESEL = PESEL_input.Text,
                phoneNb = Phone_input.Text,
                mail = email_input.Text,
                gender = Gender_input.Text,
                city = City_input.Text,
                birthDate = PatBirthDate_picker.SelectedDate.Value,
                postalCode = PostalCode_input.Text,
                street_adress = Street_input.Text,

                
            };



            db.Patients.Add(patient);
            db.SaveChanges();
            Clear();
            patientsList();
            MessageBox.Show("Dodano nowego lekarza");
        }
        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }
        void patientsList()
        {
            var db = new PrzychodniaEntities();
            patientsDataGrid.AutoGenerateColumns = false;
            patientsDataGrid.ItemsSource = db.Patients.ToList();
        }
    }
}
