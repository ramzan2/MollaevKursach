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

namespace Mollaev.WindoiwFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == String.Empty)
            {
                MBClass.ErrorMB("Введите логин");
            }
            else if (txtPassword.Password == String.Empty)
            {
                MBClass.ErrorMB("Введите пароль");
            }
            else
            {
                AddUser();
                MBClass.InfoMB("Пользователь зарегистрирован");
                new AuthorizationWindow().Show();
                Close();
            }
        }
        private void AddUser()
        {
            DBEntities.GetContext().User.Add(new User()
            {
                LoginUser = txtLogin.Text,
                PasswordUser = txtPassword.Password,
                IdRole = 2
            });
            DBEntities.GetContext().SaveChanges();
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

        private void textDBPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtDBPassword.Focus();
        }

        private void txtDBPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDBPassword.Password) && txtDBPassword.Password.Length > 0)
            {
                textDBPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textDBPassword.Visibility = Visibility.Visible;
            }
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }
    }
}
