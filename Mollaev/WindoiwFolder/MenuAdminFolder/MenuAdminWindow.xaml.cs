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

namespace Mollaev.WindoiwFolder.MenuAdminFolder
{
    /// <summary>
    /// Логика взаимодействия для MenuAdminWindow.xaml
    /// </summary>
    public partial class MenuAdminWindow : Window
    {
        public MenuAdminWindow()
        {
            InitializeComponent();
            MaiFrame.Navigate(new PageFolder.AdminFolder.ListUserPage());
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.AdminFolder.ListUserPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaiFrame.Navigate(new PageFolder.AdminFolder.AddUserPage());
        }

        private void SmenUser_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            this.DragMove();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                MBClass.ExitMB();
            }
        }
    }
}
