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
using Mollaev.DataFolder;

namespace Mollaev.PageFolder.LandlordFolder
{
    /// <summary>
    /// Логика взаимодействия для AddRatesPage.xaml
    /// </summary>
    public partial class AddRatesPage : Page
    {
        public AddRatesPage()
        {
            InitializeComponent();
            DgRates.ItemsSource = DBEntities.GetContext().Rates
                .ToList().OrderBy(u => u.IdRates);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddContractPage());
            
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
