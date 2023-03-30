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
using Mollaev.DataFolder;
using Mollaev.WindoiwFolder.MenuAdminFolder;
using Mollaev.WindoiwFolder.MenuLandlordFolder;

namespace Mollaev.WindoiwFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }



        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }




        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MBClass.ErrorMB("Введите логин");
                txtLogin.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User.FirstOrDefault(u => u.LoginUser == txtLogin.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Пользователь не найден");
                        txtLogin.Focus();
                        return;
                    }
                    if (user.PasswordUser != txtPassword.Password)
                    {
                        MBClass.ErrorMB("Введен неправильный пароль");
                        txtPassword.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new MenuUserWindow().Show();
                                Close();
                                break;
                            case 2:
                                MBClass.InfoMB("Администратор системы");
                                new MenuAdminWindow().Show();
                                Close();
                                break;
                            case 3:
                                MBClass.InfoMB("Арендадатель");
                                new MenuLandlordWindow().Show();
                                Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {

                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left) 
            {
                this.DragMove();
            }
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && txtLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            Close();
        }
    }
}
