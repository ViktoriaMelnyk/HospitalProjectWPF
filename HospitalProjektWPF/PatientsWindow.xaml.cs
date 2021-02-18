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

namespace HospitalProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
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
            if (PatBirthDate_picker.SelectedDate == null)
            {
                PatInvalidData_box.Text = "Proszę podać datę urodzenia";
                return;
            }
            string pesel = PESEL_input.Text;
            if (pesel == "" || pesel.Length != 11)
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy PESEL";
                return;
            }
            if (patientsTable.Where(p => p.PESEL == pesel).ToList().Count == 1)
            {
                PatInvalidData_box.Text = "Pacjent z takim numerem PESEL już jest w systemie";
                return;
            }
            string gender = Gender_input.Text;
            if (gender == "" || gender.Length != 1)
            {
                PatInvalidData_box.Text = "Proszę prawidłowo wpisać płeć K lub M";
                return;
            }
            string postalCode = PostalCode_input.Text;
            if (postalCode == "" || postalCode.Length != 5)
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy kod pocztowy";
                return;
            }
            string city = City_input.Text;
            if (city == "")
            {
                PatInvalidData_box.Text = "Proszę podać miasto";
                return;
            }
            string adress = Street_input.Text;
            if (adress == "")
            {
                PatInvalidData_box.Text = "Proszę podać adres";
                return;
            }

            string phone = Phone_input.Text;
            if (phone == "" || phone.Length != 9)
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy numer telefonu";
                return;
            }
            if (patientsTable.Where(d => d.phoneNb == phone).ToList().Count == 1)
            {
                PatInvalidData_box.Text = "Lekarz z takim numerem telefonu już jest w systemie";
                return;
            }

            if (email_input.Text.Length == 0 || !Regex.IsMatch(email_input.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                PatInvalidData_box.Text = "Proszę podać prawidłowy adres mailowy";
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
            MessageBox.Show("Dodano nowego pacjenta");
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
            var tmp = db.Patients.ToList().Select(a => new {
                idPat =a.idPat,
                FirstName = a.FirstName,
                LastName = a.LastName,
                PESEL = a.PESEL,
                phoneNb = a.phoneNb,
                mail = a.mail,
                gender = a.gender,
                city = a.city,
                postalCode = a.postalCode,
                street_adress = a.street_adress,
                birthDate = a.birthDate.ToString("yyyy-MM-dd")
            }).ToList();
            patientsDataGrid.ItemsSource = tmp;
        }
        private void Aktualizuj(object a, EventArgs e)
        {
            int tmp = (int)((Button)a).CommandParameter;
            var db = new PrzychodniaEntities();
            var patient = db.Patients.FirstOrDefault(p => p.idPat == tmp);

            UpdateId.Text = tmp.ToString();
            Name_input.Text = patient.FirstName;
            LastName_input.Text = patient.LastName;
            PESEL_input.Text = patient.PESEL;
            Phone_input.Text = patient.phoneNb;
            email_input.Text = patient.mail;
            Gender_input.Text = patient.gender;
            City_input.Text = patient.city;
            PostalCode_input.Text = patient.postalCode;
            Street_input.Text = patient.street_adress;
            PatBirthDate_picker.Text = patient.birthDate.ToString();
        }

        private void UpdatePanient_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new PrzychodniaEntities();
            var tmp = int.Parse(UpdateId.Text);
            var patient = db.Patients.First(a => a.idPat == tmp);
            db.Patients.Attach(patient);
            patient.FirstName = Name_input.Text;
            patient.LastName = LastName_input.Text;
            patient.PESEL = PESEL_input.Text;
            patient.phoneNb = Phone_input.Text;
            patient.mail = email_input.Text;
            patient.gender = Gender_input.Text;
            patient.city = City_input.Text;
            patient.birthDate = PatBirthDate_picker.SelectedDate.Value;
            patient.postalCode = PostalCode_input.Text;
            patient.street_adress = Street_input.Text;

            db.SaveChanges();
            Clear();
            patientsList();
            MessageBox.Show("Dane zaktualizowano");
        }

        private void DeletePat_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy jesteś pewny?", "VITAMEDICAL", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var db = new PrzychodniaEntities();
                var tmp = int.Parse(UpdateId.Text);
                var patient = db.Patients.First(a => a.idPat == tmp);
                db.Patients.Remove(patient);
                db.SaveChanges();
                Clear();
                patientsList();
                MessageBox.Show("Pomyślnie");
            }
        }
    }
}
