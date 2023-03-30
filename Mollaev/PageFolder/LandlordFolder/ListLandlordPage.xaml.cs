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
using MaterialDesignThemes.Wpf;
using Mollaev.ClassFolder;
using Mollaev.DataFolder;

namespace Mollaev.PageFolder.LandlordFolder
{
    /// <summary>
    /// Логика взаимодействия для ListLandlordPage.xaml
    /// </summary>
    public partial class ListLandlordPage : Page
    {
        public ListLandlordPage()
        {
            InitializeComponent();
            ListReaderLB.ItemsSource = DBEntities.GetContext().StorageRooms.
                ToList().OrderBy(u => u.IdStorageRooms);


        }

        private void ListReaderLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddContractPage());
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListReaderLB.ItemsSource = DBEntities.GetContext()
               .StorageRooms.Where(u => u.Status.NameStatus
               .StartsWith(SearchTB.Text))
               .ToList().OrderBy(u => u.NameStorageRooms);
          
        }
    }
}
