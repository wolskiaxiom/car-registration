using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRegistration.Views
{
    /// <summary>
    /// Interaction logic for CarReportView.xaml
    /// </summary>
    public partial class CarReportView : UserControl
    {

        CarService CarService = new CarService();
        public CarReportView()
        {
            InitializeComponent();
        }

        private void SearchCarHistory(object sender, RoutedEventArgs e)
        {
            string vin = VinTextBox.Text;
            Car? Car = CarService.GetCarForVin(vin);
            List<HistoryEntry> CarHistory = CarService.GetHistoryForVin(vin);
            if (Car is null)
            {
                VinLabel.Content = "";
                CarNameLabel.Content = "";
                SearchResultMessage.Content = "Nie udało się znaleźć pojazdu o podanym numerze VIN.";
                carHistoryListBinding.ItemsSource = System.Linq.Enumerable.Empty<HistoryEntry>();
            }
            else
            {
                VinLabel.Content = Car.Value.Vin;
                CarNameLabel.Content = Car.Value.Name;
                SearchResultMessage.Content = "";
                carHistoryListBinding.ItemsSource = CarHistory;

            }
        }
    }
}
