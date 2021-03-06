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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarRegistration.ViewModels;

namespace CarRegistration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly App current;
        public MainWindow()
        {
            InitializeComponent();
            current = (App)App.Current;
        }

        private void NavigateToNewCarForm(object sender, RoutedEventArgs e)
        {
            RoleWarning.Text = String.Empty;
            AddNewCarFormViewModel viewModel = new AddNewCarFormViewModel();
            if (viewModel.CheckPrivileges(current.role))
            {
                DataContext = viewModel;
            }
            else
            {
                RoleWarning.Text = "Nie masz wystarczających uprawnień, aby dodać nowy samochód!";
            }
        }

        private void NavigateToLoginPage(object sender, RoutedEventArgs e)
        {
            RoleWarning.Text = String.Empty;
            DataContext = new LoginPageViewModel();
        }

        private void NavigateToBrowseCars(object sender, RoutedEventArgs e)
        {
            RoleWarning.Text = String.Empty;
            DataContext = new CarReportViewModel();
        }

        private void NavigateToNewUserForm(object sender, RoutedEventArgs e)
        {
            RoleWarning.Text = String.Empty;
            AddNewUserFormViewModel viewModel = new AddNewUserFormViewModel();
            if (viewModel.CheckPrivileges(current.role)) {
                DataContext = viewModel;
            } else
            {
                RoleWarning.Text = "Nie masz wystarczających uprawnień, aby dodać użytkownika!";
            }
        }
    }
}
