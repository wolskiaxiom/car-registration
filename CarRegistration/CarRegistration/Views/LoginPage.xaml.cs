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
    public partial class LoginPage : UserControl
    {
        App currentApp;
        UserService UserService;

        public LoginPage()
        {
            InitializeComponent();
            UserService = new UserService();
            currentApp = (App)App.Current;
            ShowComponents();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Role role = UserService.CheckLogin(UserNameTextBox.Text, PasswordBox.Password);
            currentApp.role = role;
            if (role != Role.User)
            {
                LoginErrorMessage.Visibility = Visibility.Hidden;
                ShowComponents();
            }
            else
            {
                LoginErrorMessage.Visibility = Visibility.Visible;
            }
        }

        private void ShowComponents()
        {
            if (currentApp.role != Role.User)
            {
                LoggedInLabel.Content = String.Format("Jesteś zalogowany jako: {0}", currentApp.role);
                LoggedInGrid.Visibility = Visibility.Visible;
                NotLoggedInGrid.Visibility = Visibility.Hidden;
            } else
            {
                LoggedInGrid.Visibility = Visibility.Hidden;
                NotLoggedInGrid.Visibility = Visibility.Visible;
            }
        }

        private bool IsLogged()
        {
            return currentApp.role != Role.User;
        }
    }
}
