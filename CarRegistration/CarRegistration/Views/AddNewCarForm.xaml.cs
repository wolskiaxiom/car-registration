using System.Windows;
using System.Windows.Controls;
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
                Car newCar = new Car(Vin.Text, CarName.Text);
                CarService.AddNewCar(newCar, OwnerName.Text);

                Vin.Text = "";
                OwnerName.Text = "";
                CarName.Text = "";
            }
        }

    }
}
