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
    /// Логика взаимодействия для ListStorageRoomsPage.xaml
    /// </summary>
    public partial class ListStorageRoomsPage : Page
    {
        public ListStorageRoomsPage()
        {
            InitializeComponent();
            ListStorageRoomsLB.ItemsSource = DBEntities.GetContext().StorageRooms.
                ToList().OrderBy(u => u.Area);
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (ListStorageRoomsLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите " +
                    "пользователя для редактирования");
            }
            else
            {
                NavigationService.Navigate(
                    new EditStorageRoomsPage(ListStorageRoomsLB.SelectedItem as StorageRooms));
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (ListStorageRoomsLB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника для удаления");
            }
            else
            {
                try
                {
                    StorageRooms storageRooms = ListStorageRoomsLB.SelectedItem as StorageRooms;
                    if (MBClass.QuestionMB($"Удалить выбраного сотрудника?"))
                    {
                        object []  contract = DBEntities.GetContext().Contract.ToArray();

                        for (int i = 0; i < contract.Length; i++) 
                        {
                            Contract contract1 = contract [i] as Contract;
                            if (contract1.IdStorageRooms == storageRooms.IdStorageRooms)
                            {
                                contract1.IdStorageRooms = null;

                                DBEntities.GetContext().SaveChanges();

                            }
                        }

                       
                        DBEntities.GetContext().SaveChanges();
                        DBEntities.GetContext().StorageRooms.Remove(storageRooms);

                        DBEntities.GetContext().SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                ListStorageRoomsLB.ItemsSource = DBEntities.GetContext().StorageRooms.ToList();
            }


        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
