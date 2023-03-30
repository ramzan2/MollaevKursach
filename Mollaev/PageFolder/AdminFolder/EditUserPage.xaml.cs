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
using Mollaev.ClassFolder;
using Mollaev.DataFolder;

namespace Mollaev.PageFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {

        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;

            RoleCB.ItemsSource = DBEntities.GetContext()
                     .Role.ToList();

        }

        private void SaveUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = DBEntities.GetContext().User.
                FirstOrDefault(s => s.IdUser == VairableClass.UserId);
            user.IdRole = Int32.Parse(RoleCB.SelectedValue.ToString());
            user.LoginUser = LoginTB.Text;
            user.PasswordUser = PasswordPB.Text;
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Пользователь успешно отредактирован");
            NavigationService.Navigate(new ListUserPage());
        }
    }
}
