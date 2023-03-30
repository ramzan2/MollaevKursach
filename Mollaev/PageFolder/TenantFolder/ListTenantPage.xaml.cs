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
using Mollaev.PageFolder.AdminFolder;

namespace Mollaev.PageFolder.TenantFolder
{
    /// <summary>
    /// Логика взаимодействия для ListTenantPage.xaml
    /// </summary>
    public partial class ListTenantPage : Page
    {
        public ListTenantPage()
        {
            InitializeComponent();
            DgLandlord.ItemsSource = DBEntities.GetContext().Landlord
                .ToList().OrderBy(u => u.LastNameLandlord);
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Landlord landlord = DgLandlord.SelectedItem as Landlord;

            if (DgLandlord.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите пользователя" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"пользователя с логином " +
                    $"{landlord.LastNameLandlord}?"))
                {
                    DBEntities.GetContext().Landlord
                        .Remove(DgLandlord.SelectedItem as Landlord);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Пользователь удален");
                    DgLandlord.ItemsSource = DBEntities.GetContext()
                        .Landlord.ToList().OrderBy(u => u.LastNameLandlord);
                }

            }
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (DgLandlord.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");

            }
            else
            {
                Landlord landlord = DgLandlord.SelectedItem as Landlord;
                VairableClass.LandlordId = landlord.IdLandlord;
                this.NavigationService.Navigate(new EditLandlordPage(DgLandlord.SelectedItem as Landlord));
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgLandlord.ItemsSource = DBEntities.GetContext()
                .Landlord.Where(u => u.LastNameLandlord
                .StartsWith(SearchTB.Text))
                .ToList().OrderBy(u => u.LastNameLandlord);
            if (DgLandlord.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }
    }
}
