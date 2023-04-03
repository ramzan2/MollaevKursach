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

namespace Mollaev.PageFolder.TenantFolder
{
    /// <summary>
    /// Логика взаимодействия для ListContractPage.xaml
    /// </summary>
    public partial class ListContractPage : Page
    {
        public ListContractPage()
        {
            InitializeComponent();
            DgContract.ItemsSource = DBEntities.GetContext().Contract
               .ToList().OrderBy(u => u.IdContract);
         
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgContract.ItemsSource = DBEntities.GetContext()
                            .StorageRooms.Where(u => u.NameStorageRooms
                            .StartsWith(SearchTB.Text))
                            .ToList().OrderBy(u => u.NameStorageRooms);
            if (DgContract.Items.Count <= 0)
            {
                MBClass.ErrorMB("Данные не найдены");
            }
        }

        private void DeleteMI_Click(object sender, RoutedEventArgs e)
        {
            Contract contract = DgContract.SelectedItem as Contract;

            if (DgContract.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите контракт" +
                    " для удаления");
            }
            else
            {
                if (MBClass.QuestionMB("Удалить " +
                    $"контракт " +
                    $"{contract.RentalType}?"))
                {
                    DBEntities.GetContext().Contract
                        .Remove(DgContract.SelectedItem as Contract);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Контракт удален");
                    DgContract.ItemsSource = DBEntities.GetContext()
                        .Contract.ToList().OrderBy(u => u.RentalType);
                }

            }
        }
    }
}
