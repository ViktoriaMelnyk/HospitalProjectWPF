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
    /// Logika interakcji dla klasy VisitsWindow.xaml
    /// </summary>
    public partial class VisitsWindow : Window
    {
        public VisitsWindow()
        {
            InitializeComponent();
            visitsList();
        }

      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource przychodniaEntitiesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("przychodniaEntitiesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // przychodniaEntitiesViewSource.Źródło = [ogólne źródło danych]
            
        }
        void visitsList()
        {
            var db = new PrzychodniaEntities();
            visitsDataGrid.AutoGenerateColumns = false;
            var visitsTable = db.Visits.ToList().Select(a => new {
                idVis = a.idVis,
                idPat = a.idPat,
                idDoc = a.idDoc,
                DateOfVisit = a.DateOfVisit.Value.ToString("dd-MM-yyyy"),
                TimeOfVisit = a.TimeOfVisit.ToString(),
                Symptoms= a.Symptoms,
                Diagnosis= a.Diagnosis,
                idDis= a.idDis,
                idPrescr= a.idPrescr,
                sickLeave= a.sickLeave,
                recommendations= a.recommendations,
                }).ToList();
            visitsDataGrid.ItemsSource = visitsTable;
        }
        private void MainMenu_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu objMainMenu = new MainMenu();
            this.Visibility = Visibility.Hidden;
            objMainMenu.Show();
        }
    }
}
