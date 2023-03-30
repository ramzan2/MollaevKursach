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
using System.Windows.Shapes;
using Mollaev.ClassFolder;

namespace Mollaev.WindoiwFolder.MenuLandlordFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuLandlordWindow.xaml
    /// </summary>
    public partial class MenuLandlordWindow : Window
    {
        public MenuLandlordWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.TenantFolder.ListStorageRoomsPage());
        }

 

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.TenantFolder.ListStorageRoomsPage() );
            StACpANEL.Visibility = Visibility.Visible;
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)

                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void ListClient_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.TenantFolder.ListTenantPage());
        }

        private void ListStorage_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.TenantFolder.ListStorageRoomsPage());
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddStorage_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.TenantFolder.AddStorageRoomsPage());
            StACpANEL.Visibility = Visibility.Hidden;
        }

        private void ListContract_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.TenantFolder.ListContractPage());
        }
    }
}
