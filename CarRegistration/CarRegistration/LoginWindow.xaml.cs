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
using System.Windows.Shapes;

namespace CarRegistration
{
    public partial class LoginWindow : Window
    {
        App currentApp;
        UserService UserService;

        TextBox UsernameTextBox;
        PasswordBox PasswordBoxValue;

        public LoginWindow()
        {
            InitializeComponent();
            UserService = new UserService();
            currentApp = (App)App.Current;
            UsernameTextBox = (TextBox) this.FindName("UserNameTextBox");
            PasswordBoxValue = (PasswordBox)this.FindName("PasswordBox");
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Role role = UserService.CheckLogin(UsernameTextBox.Text, PasswordBoxValue.Password);
            currentApp.role = role;
            if (role != Role.User)
            {
                LoginErrorMessage.Visibility = Visibility.Hidden;

                // move to main screen
            }
            else
            {
                LoginErrorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
