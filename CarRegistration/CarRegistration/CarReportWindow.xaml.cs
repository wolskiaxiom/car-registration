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
    /// <summary>
    /// Interaction logic for CarReportWindow.xaml
    /// </summary>
    public partial class CarReportWindow : Window
    {
        CarService CarService = new CarService();
        public CarReportWindow()
        {
            InitializeComponent();
            carHistoryListBinding.ItemsSource = CarService.GetAllCarsWithHistory()[0].Item2;
        }
    }
}
