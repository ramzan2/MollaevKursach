using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using Microsoft.Win32;
using Mollaev.ClassFolder;
using Mollaev.DataFolder;
using Mollaev.PageFolder.AdminFolder;

namespace Mollaev.PageFolder.TenantFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStorageRoomsPage.xaml
    /// </summary>
    public partial class AddStorageRoomsPage : Page
    {
        Address address = new Address();
        StorageRooms storageRooms = new StorageRooms();
        public AddStorageRoomsPage()
        {
            InitializeComponent();
            RegionCB.ItemsSource = DBEntities.GetContext().Region.ToList();
            CityCB.ItemsSource = DBEntities.GetContext().City.ToList();
            StreetCB.ItemsSource = DBEntities.GetContext().Street.ToList();
            IdStatusCb.ItemsSource = DBEntities.GetContext().Status.ToList();
        }

        private void LoadIm_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddressAdd();
                StorageRoomsAdd();

                MBClass.InfoMB("Помещение добавленно");
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
               
            }
            NavigationService.Navigate(new PageFolder.TenantFolder.ListStorageRoomsPage());
        }

        private void AddressAdd()
        {
            var addressAdd = new Address()
            {
                IdRegion = Int32.Parse(RegionCB.SelectedValue.ToString()),
                IdCity = Int32.Parse(CityCB.SelectedValue.ToString()),
                IdStreet = Int32.Parse(StreetCB.SelectedValue.ToString()),
                HouseAddress = Int32.Parse(HouseTB.Text),
                HousingAddress = Int32.Parse(HousingTB.Text),
                FlatAddress = Int32.Parse(FlatTB.Text),
            };
            DBEntities.GetContext().Address.Add(addressAdd);
            DBEntities.GetContext().SaveChanges();
            address.IdAddress = addressAdd.IdAddress;
        }

        private void StorageRoomsAdd()
        {
            var storageRoomsAdd = new StorageRooms()
            {
                IdAddress = address.IdAddress,
                Area = AreaTb.Text,
                StorageСapacity = Int32.Parse(StorageСapacityTb.Text),
                NameStorageRooms = NameStorageRoomsTB.Text,
                ViewStorageRooms = ViewStorageRoomsTB.Text,
                IdStatus = Int32.Parse(IdStatusCb.SelectedValue.ToString()),
                PhotoStorageRooms = ImageClass.ConvertImageToByteArray(selectedFileName)
            };
            DBEntities.GetContext().StorageRooms.Add(storageRoomsAdd);
            DBEntities.GetContext().SaveChanges();
        }
        string selectedFileName = "";

        private void AddPhoto()
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                    "Portable Network Graphic (*.png)|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    storageRooms.PhotoStorageRooms = ImageClass.ConvertImageToByteArray(selectedFileName);
                    PhotoIm.Source = ImageClass.ConvertByteArrayToImage(storageRooms.PhotoStorageRooms);
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }

        }
    }
}
