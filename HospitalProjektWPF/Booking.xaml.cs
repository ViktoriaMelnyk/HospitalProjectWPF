using System;
using System.Linq;
using System.Windows;

namespace HospitalProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy Booking.xaml
    /// </summary>
    public partial class Booking : Window
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public Booking()
        {
            InitializeComponent();
            reservationsList();
        }
        void Clear()
        {
            IdPat_input.Text = IdDoc_input.Text = dateOfVisit.Text = TimeOfVisit.Text = "";
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
            System.Windows.Data.CollectionViewSource przychodniaEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("przychodniaEntitiesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // przychodniaEntitiesViewSource.Źródło = [ogólne źródło danych]
        }
        void reservationsList()
        {
            var db = new PrzychodniaEntities();
            bookingVisitDataGrid.AutoGenerateColumns = false;
            var reservationsTable = db.BookingVisit.ToList().Select(a => new
            {
                idBV = a.idBV,
                idDoc = a.idDoc,
                idPat = a.idPat,
                dateOfReserv = a.dateOfReserv.Value.ToString("dd-MM-yyyy"),
                timeOfVisit = a.timeOfVisit.ToString(),
            }).ToList();
            bookingVisitDataGrid.ItemsSource = reservationsTable;
        }
        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }

        private void Reserv_btn_Click(object sender, RoutedEventArgs e)
        {
            var db = new PrzychodniaEntities();
            ReservInvalidData_box.Text = "";



            string idPat = IdPat_input.Text;
            int idValue = int.Parse(idPat);
            if (idPat == "")
            {
                ReservInvalidData_box.Text = "Proszę podać id pacjenta";
                return;
            }
            if (db.Patients.Where(i => i.idPat == idValue).ToList().Count != 1)
            {
                ReservInvalidData_box.Text = "Pacjent z takim id nie jest zarejestrowany";
                return;
            }
            string idDoc = IdDoc_input.Text;
            int idValue2 = int.Parse(idDoc);
            if (idDoc == "")
            {
                ReservInvalidData_box.Text = "Proszę podać id lekarza";
                return;
            }
            var doctors = db.Doctors.Where(d => d.idDoc == idValue2).ToList();
            var wszyscy = db.Doctors.ToList();
            if (doctors.Count() != 1)
            {
                ReservInvalidData_box.Text = "Lekarz z takiem id nie pracuje w tej przychodni";
                return;
            }
            if (dateOfVisit.SelectedDate == null)
            {
                ReservInvalidData_box.Text = "Proszę podać datę wizyty";
                return;
            }
            string time = TimeOfVisit.Text;
            if (time == "")
            {
                ReservInvalidData_box.Text = "Proszę podać godzinę wizyty";
                return;
            }

            DateTime dt = (dateOfVisit.SelectedDate is null) ? new DateTime(0, 0, 0) : (DateTime)dateOfVisit.SelectedDate;
            dt += TimeSpan.Parse(time);
            int doc = int.Parse(idDoc);

            var from = dt - new TimeSpan(0, 15, 0);
            var to = dt + new TimeSpan(0, 15, 0);
            var exist = db.BookingVisit
                .ToList()
                .Where(a =>
                    a.idDoc == doc &&
                    a.dateOfReserv + a.timeOfVisit > from &&
                    a.dateOfReserv + a.timeOfVisit < to
                );

            if (exist.FirstOrDefault() != null)
            {
                ReservInvalidData_box.Text = "Lekarz z takim id już jest zajęty w tym terminie";
                return;
            }





            BookingVisit reservation = new BookingVisit()
            {
                idPat = int.Parse(IdPat_input.Text),
                idDoc = int.Parse(IdDoc_input.Text),
                dateOfReserv = dateOfVisit.SelectedDate.Value,
                timeOfVisit = TimeSpan.Parse(TimeOfVisit.Text),


            };



            db.BookingVisit.Add(reservation);
            db.SaveChanges();
            Clear();
            reservationsList();
            MessageBox.Show("Zarezerwowano");
        }
    }
}
