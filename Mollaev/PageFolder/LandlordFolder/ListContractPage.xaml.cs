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
    /// Логика взаимодействия для ListContractPage.xaml
    /// </summary>
    public partial class ListContractPage : Page
    {
        public ListContractPage()
        {
            InitializeComponent();
            DgContract.ItemsSource = DBEntities.GetContext().Contract
                .ToList().OrderBy(u => u.IdContract);
            //DgContract.ItemsSource = DBEntities.GetContext().Landlord
            //   .ToList().OrderBy(u => u.IdLandlord);
            //DgContract.ItemsSource = DBEntities.GetContext().Landlord
             //  .ToList().OrderBy(u => u.LastNameLandlord);
            //DgContract.ItemsSource = DBEntities.GetContext().Tenant
            //    .ToList().OrderBy(u => u.IdTenant);
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgContract.ItemsSource = DBEntities.GetContext()
             .Contract.Where(u => u.StorageRooms.NameStorageRooms
             .StartsWith(SearchTB.Text))
             .ToList().OrderBy(u => u.IdStorageRooms);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageFolder.LandlordFolder.ListLandlordPage());
        }
    }
}
