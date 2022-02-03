using System.Windows;
using System.Windows.Controls;
using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Services;

namespace CarRegistration.Views
{
    public partial class UpdateCarForm : UserControl 
    {
        private App currentApp;

        public UpdateCarForm()
        {
            InitializeComponent();
            currentApp = (App)App.Current;
        }

        private void OnFormSubmit(object sender, RoutedEventArgs e)
        {
            if (currentApp.role == Role.Clerk || currentApp.role == Role.Mechanic)
                //TODO: ADD SERVICE AND UPDATE ACTION

                Vin.Text = "";
                OwnerName.Text = "";
                CarName.Text = "";
                Mileage.Text = "";
            }
        }
    }
}
