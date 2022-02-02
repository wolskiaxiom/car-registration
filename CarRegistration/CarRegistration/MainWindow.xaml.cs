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
        public MainWindow()
        {
            InitializeComponent();
            App current = (App) App.Current;
        }

        private void NavigateToNewCarForm(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNewCarFormViewModel();
        }

        private void NavigateToUpdateCarForm(object sender, RoutedEventArgs e)
        {
            DataContext = new UpdateCarFormViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //(new LoginWindow()).Show();
            LoginWindow lc = new LoginWindow();
            lc.Owner = this;
            lc.Show();
        }
    }
}
