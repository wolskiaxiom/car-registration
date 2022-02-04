using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Car? Car;
        ObservableCollection<HistoryEntry> CarHistory;
        readonly CarService CarService = new CarService();
        readonly App current;
        
        public CarReportView()
        {
            InitializeComponent();
            current = (App)App.Current;
        }

        private void SearchCarHistory(object sender, RoutedEventArgs e)
        {
            string vin = VinTextBox.Text;
            Car = CarService.GetCarForVin(vin);
            CarHistory = new ObservableCollection<HistoryEntry>(CarService.GetHistoryForVin(vin));//CarService.GetHistoryForVin(vin).ToArray();
            if (Car is null)
            {
                VinLabel.Content = "";
                CarNameLabel.Content = "";
                SearchResultMessage.Content = "Nie udało się znaleźć pojazdu o podanym numerze VIN.";
                carHistoryListBinding.ItemsSource = System.Linq.Enumerable.Empty<HistoryEntry>();
                carHistoryListBinding.Visibility = Visibility.Collapsed;
                FormGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                VinLabel.Content = Car.Value.Vin;
                CarNameLabel.Content = Car.Value.Name;
                SearchResultMessage.Content = "";
                carHistoryListBinding.ItemsSource = CarHistory;
                carHistoryListBinding.Visibility = Visibility.Visible;
                if (current.role == Role.Mechanic)
                {
                    FormGrid.Visibility = Visibility.Visible;
                    ownerNameInput.Visibility = Visibility.Collapsed;
                    ownerNameLabel.Visibility = Visibility.Collapsed;
                } else if (current.role == Role.Clerk)
                {
                    FormGrid.Visibility = Visibility.Visible;
                }
            }
        }

        private void AddHistoryEntryClick(object sender, RoutedEventArgs e)
        {
            long mileageVal;
            try
            {
                 mileageVal = long.Parse(mileageInput.Text);
            } catch
            {
                return;
            }
            if (current.role == Role.Clerk)
            {
                string owner = ownerNameInput.Text;
                HistoryEntry newEntry = new HistoryEntry(Car.Value.Vin, owner, mileageVal);
                CarService.AddHistoryEntry(newEntry);
                CarHistory.Add(newEntry);
            } else if (current.role == Role.Mechanic)
            {
                HistoryEntry entry = CarHistory[^1];
                HistoryEntry newEntry = new HistoryEntry(entry.Vin, entry.OwnerName, mileageVal);
                CarService.AddHistoryEntry(newEntry);
                CarHistory.Add(newEntry);
            }
        }

        private void CarHistoryListBindingSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (current.role == Role.Clerk)
            {
                updateButton.Visibility = Visibility.Visible;
                if (CarHistory.Count > carHistoryListBinding.SelectedIndex && carHistoryListBinding.SelectedIndex > -1)
                {
                    ownerNameInput.Text = CarHistory[carHistoryListBinding.SelectedIndex].OwnerName;
                    mileageInput.Text = CarHistory[carHistoryListBinding.SelectedIndex].Mileage.ToString();
                }
            }
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = carHistoryListBinding.SelectedIndex;
            if (String.IsNullOrEmpty(mileageInput.Text))
            {
                return;
            }
            long mileageVal;
            try
            {
                mileageVal = long.Parse(mileageInput.Text);
            }
            catch
            {
                return;
            }
            if (selectedIndex < 0)
            {
                selectedIndex = 0;
            }
            HistoryEntry oldEntry = CarHistory[selectedIndex];
            HistoryEntry newEntry = new HistoryEntry(Car.Value.Vin, oldEntry.OwnerName, mileageVal);
            CarService.ReplaceHistoryEntry(oldEntry, newEntry);
            CarHistory.RemoveAt(selectedIndex);
            CarHistory.Insert(selectedIndex, newEntry);    
        }
    }
}
