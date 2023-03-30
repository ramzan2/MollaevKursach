﻿using System;
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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            DgUser.ItemsSource = DBEntities.GetContext().User
                .ToList().OrderBy(u => u.LoginUser);
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            User user = DgUser.SelectedItem as User;

            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{user.LoginUser}?"))
                {
                    DBEntities.GetContext().User
                        .Remove(DgUser.SelectedItem as User);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь удален");
                    DgUser.ItemsSource = DBEntities.GetContext()
                        .User.ToList().OrderBy(u => u.LoginUser);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgUser.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                User user = DgUser.SelectedItem as User;
                VairableClass.UserId=user.IdUser;
                NavigationService.Navigate(
                    new EditUserPage(DgUser.SelectedItem as User));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgUser.ItemsSource = DBEntities.GetContext()
                           .User.Where(u => u.LoginUser
                           .StartsWith(SearchTB.Text))
                           .ToList().OrderBy(u => u.LoginUser);
            if (DgUser.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
