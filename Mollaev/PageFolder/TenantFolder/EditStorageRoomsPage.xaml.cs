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

namespace Mollaev.PageFolder.TenantFolder
{
    /// <summary>
    /// Логика взаимодействия для EditStorageRoomsPage.xaml
    /// </summary>
    public partial class EditStorageRoomsPage : Page
    {
        StorageRooms storageRooms = new StorageRooms();
        Address address = new Address();
        public EditStorageRoomsPage(StorageRooms storageRooms)
        {


            InitializeComponent();

            DataContext = storageRooms;
            this.storageRooms = storageRooms;

            RegionCB.ItemsSource = DBEntities.GetContext().Region.ToList().OrderBy(u => u.IdRegion);
            CityCB.ItemsSource = DBEntities.GetContext().City.ToList().OrderBy(u => u.IdCity);
            StreetCB.ItemsSource = DBEntities.GetContext().Street.ToList().OrderBy(u => u.IdStreet);
             IdStatusCb.ItemsSource = DBEntities.GetContext().Status.ToList().OrderBy(u => u.IdStatus);
        }

        private void EditIm_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EditAddressStorageRooms();
            EditStorageRooms();
            NavigationService.Navigate(new PageFolder.TenantFolder.ListStorageRoomsPage());
        }

        string selectedFileName = "";
        private void AddPhoto()
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

        private void EditAddressStorageRooms()
        {
            try
            {
                address = DBEntities.GetContext().Address.FirstOrDefault(r => r.IdAddress == storageRooms.IdAddress);
                address.IdStreet = Int32.Parse(StreetCB.SelectedValue.ToString());
                address.HouseAddress = Int32.Parse(HouseTB.Text);
                address.FlatAddress = Int32.Parse(FlatTB.Text);
                address.HousingAddress = Int32.Parse(HousingTB.Text);
                address.IdCity = Int32.Parse(CityCB.SelectedValue.ToString());
                address.IdRegion = Int32.Parse(RegionCB.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Адресс изменен");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }

        private void EditStorageRooms()
        {
            try
            {
                if (selectedFileName == "")
                {
                    storageRooms = DBEntities.GetContext().StorageRooms.FirstOrDefault(r => r.IdStorageRooms == storageRooms.IdStorageRooms);
                    storageRooms.IdAddress = address.IdAddress;
                    storageRooms.Area = AreaTb.Text;
                    storageRooms.StorageСapacity = Int32.Parse(StorageСapacityTb.Text);
                    storageRooms.NameStorageRooms = NameStorageRoomsTB.Text;
                    storageRooms.ViewStorageRooms = ViewStorageRoomsTB.Text;
                    storageRooms.IdStatus = Int32.Parse(IdStatusCb.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();
                }
                else
                {
                    storageRooms = DBEntities.GetContext().StorageRooms.FirstOrDefault(r => r.IdStorageRooms == storageRooms.IdStorageRooms);
                    storageRooms.IdAddress = address.IdAddress;
                    storageRooms.Area = AreaTb.Text;
                    storageRooms.StorageСapacity = Int32.Parse(StorageСapacityTb.Text);
                    storageRooms.NameStorageRooms = NameStorageRoomsTB.Text;
                    storageRooms.ViewStorageRooms = ViewStorageRoomsTB.Text;
                    storageRooms.IdStatus = Int32.Parse(IdStatusCb.SelectedValue.ToString());
                    storageRooms.PhotoStorageRooms = ImageClass.ConvertImageToByteArray(selectedFileName);
                    DBEntities.GetContext().SaveChanges();
                }
                MBClass.InfoMB("Помещение измененно");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex.Message);
            }
        }
    }
}
