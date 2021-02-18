using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace HospitalProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {

        Doctors doctor = new Doctors();
        /// <summary>
        /// Konstruktor
        /// </summary>
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
            if (phone == "" || phone.Length != 9)
            {
                InvalidData_box.Text = "Proszę podać prawidłowy numer telefonu";
                return;
            }
            if (doctorsTable.Where(d => d.phoneNb == phone).ToList().Count == 1)
            {
                InvalidData_box.Text = "Lekarz z takim numerem telefonu już jest w systemie";
                return;
            }
            
            if (DocEmail_input.Text.Length == 0||!Regex.IsMatch(DocEmail_input.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                InvalidData_box.Text = "Proszę podać prawidłowy adres mailowy";
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
                specializations = idValue,
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

        private void Aktualizuj(object o, EventArgs e)
        {
            int tmp = (int)((Button)o).CommandParameter;
            var db = new PrzychodniaEntities();
            var doctor = db.Doctors.FirstOrDefault(a => a.idDoc == tmp);

            UpdateId.Text = tmp.ToString();
            DocName_input.Text = doctor.FirstName;
            DocLastName_input.Text = doctor.LastName;
            DocPESEL_input.Text = doctor.PESEL;
            DocPhone_input.Text = doctor.phoneNb;
            DocEmail_input.Text = doctor.mail;
            IdSpec_input.Text = doctor.specializations.ToString();

        }
        private void UpdateDoc_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new PrzychodniaEntities();
            var tmp = int.Parse(UpdateId.Text);
            var doctor = db.Doctors.First(a => a.idDoc == tmp);
            db.Doctors.Attach(doctor);
            doctor.FirstName = DocName_input.Text;
            doctor.LastName = DocLastName_input.Text;
            doctor.PESEL = DocPESEL_input.Text;
            doctor.phoneNb = DocPhone_input.Text;
            doctor.mail = DocEmail_input.Text;
            doctor.specializations = int.Parse(IdSpec_input.Text);

            db.SaveChanges();
            Clear();
            dostorsList();
            MessageBox.Show("Dane zaktualizowano");
        }

        private void DeleteDoc_btn_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy jesteś pewny?", "VITAMEDICAL", MessageBoxButton.OKCancel)== MessageBoxResult.OK)
            {
                var db = new PrzychodniaEntities();
                var tmp = int.Parse(UpdateId.Text);
                var doctor = db.Doctors.First(a => a.idDoc == tmp);
                db.Doctors.Remove(doctor);
                db.SaveChanges();
                Clear();
                dostorsList();
                MessageBox.Show("Pomyślnie");
            }
         
        }
    }
}
