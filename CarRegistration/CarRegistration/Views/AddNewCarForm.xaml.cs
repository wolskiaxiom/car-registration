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
using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Services;

namespace CarRegistration.Views
{
    public partial class AddNewCarForm : UserControl
    {
        App currentApp;
        CarService CarService;

        public AddNewCarForm()
        {
            InitializeComponent();
            currentApp = (App)App.Current;
            CarService = new CarService();
        }

        private void OnFormSubmit(object sender, RoutedEventArgs e)
        {
            if (currentApp.role == Role.Producer)
            {
               
                if (String.IsNullOrEmpty(Vin.Text) || String.IsNullOrEmpty(OwnerName.Text) || String.IsNullOrEmpty(CarName.Text))
                {
                    StatusLabel.Content = "Coś poszło nie tak. Upewnij się, że wpisałeś wszystkie wartości.";
                    StatusLabel.Foreground = Brushes.Red;
                }
                else
                {
                    Car newCar = new Car(Vin.Text, CarName.Text);
                    CarService.AddNewCar(newCar, OwnerName.Text);
                    StatusLabel.Content = "Pomyślnie dodałeś samochód do bazy";
                    StatusLabel.Foreground = Brushes.Green;
                }
                Vin.Text = "";
                OwnerName.Text = "";
                CarName.Text = "";
            }
        }

    }
}
