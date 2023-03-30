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
using Mollaev.PageFolder.LandlordFolder;

namespace Mollaev.WindoiwFolder.MenuAdminFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuUserWindow.xaml
    /// </summary>
    public partial class MenuUserWindow : Window
    {
        public MenuUserWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.LandlordFolder.ListLandlordPage());
        }


        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
               if(e.LeftButton == MouseButtonState.Pressed)
            
                this.DragMove();
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {

            MaiFrame.Navigate(new ListLandlordPage());

        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                MBClass.ExitMB();
            }
        }

        private void CheckContract_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new ListContractPage());
        }
    }
}
