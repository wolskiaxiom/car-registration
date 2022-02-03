﻿using CarRegistrationLibrary.Domain;
using CarRegistrationLibrary.Services;
using CarRegistrationLibrary.Utils;
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
    /// Interaction logic for AddNewUserForm.xaml
    /// </summary>
    public partial class AddNewUserForm : UserControl
    {
        UserService UserService;
        public AddNewUserForm()
        {
            InitializeComponent();
            UserService = new UserService();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Role role = RoleMapper.FromStringToRole(((ComboBoxItem)RoleSelection.SelectedItem).Content.ToString());
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            if (role == Role.User && String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password))
            {

            } else
            {
                UserService.AddNewUser(username, password, role);
            }
        }


    }
}