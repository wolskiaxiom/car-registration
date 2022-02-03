using System.Windows;
using CarRegistration.ViewModels;
using CarRegistrationLibrary.Domain;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarRegistration
{
    public partial class MainWindow : INotifyPropertyChanged
    {

        private Visibility IsLoginEnabled;
        public Visibility isLoginEnabled
        {
            get { return IsLoginEnabled; }
            set
            {
                if(IsLoginEnabled != value)
                {
                    IsLoginEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility IsUpdateCarFormEnabled;
        public Visibility isUpdateCarFormEnabled
        {
            get { return IsUpdateCarFormEnabled; }
            set
            {
                if (IsUpdateCarFormEnabled != value)
                {
                    IsUpdateCarFormEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility IsAddNewCarFormEnabled;
        public Visibility isAddNewCarFormEnabled
        {
            get { return IsAddNewCarFormEnabled; }
            set
            {
                if (IsAddNewCarFormEnabled != value)
                {
                    IsAddNewCarFormEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public Visibility IsAddNewUserFormEnabled;
        public Visibility isAddNewUserFormEnabled
        {
            get { return IsAddNewUserFormEnabled; }
            set
            {
                if (IsAddNewUserFormEnabled != value)
                {
                    IsAddNewUserFormEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private Visibility IsFullFormEnabled;
        public Visibility isFullFormEnabled
        {
            get { return IsFullFormEnabled; }
            set
            {
                if (IsFullFormEnabled != value)
                {
                    IsFullFormEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            App current = (App)App.Current;

            Role userRole = current.role;
            isLoginEnabled = userRole == Role.User ? Visibility.Visible : Visibility.Collapsed;
            isUpdateCarFormEnabled = userRole == Role.Mechanic || userRole == Role.Clerk ? Visibility.Visible : Visibility.Collapsed;
            isAddNewCarFormEnabled = userRole == Role.Producer ? Visibility.Visible : Visibility.Collapsed;
            isAddNewUserFormEnabled = userRole == Role.Clerk ? Visibility.Visible : Visibility.Collapsed;
            isFullFormEnabled = userRole == Role.Clerk ? Visibility.Visible : Visibility.Collapsed;

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NavigateToNewCarForm(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNewCarFormViewModel();
        }

        private void NavigateToUpdateCarForm(object sender, RoutedEventArgs e)
        {
            DataContext = new UpdateCarFormViewModel();
        }
    }
}
