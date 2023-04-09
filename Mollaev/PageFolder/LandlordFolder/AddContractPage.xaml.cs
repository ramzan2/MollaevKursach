using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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

namespace Mollaev.PageFolder.LandlordFolder
{
    /// <summary>
    /// Логика взаимодействия для AddContractPage.xaml
    /// </summary>
    public partial class AddContractPage : Page
    {
        Contract contract = new Contract();
        Tenant tenant = new Tenant();
        Landlord landlord = new Landlord();
        int IdStorage;
        public AddContractPage()
        {
            InitializeComponent();
            IdRatesСB.ItemsSource = DBEntities.GetContext().Rates.ToList();
            IdStorageRoomsCb.ItemsSource = DBEntities.GetContext().StorageRooms.ToList();
        }

        private void ContractAddd()
        {
            var contractAdd = new Contract()
            {
                IdStorageRooms =IdStorage=  Int32.Parse(IdStorageRoomsCb.SelectedValue.ToString()),
                RentalType = RentalTypeTB.Text,
                DateOfConclusion = DateTime.Parse(DateOfConclusionTB.Text),
                EndDate = DateTime.Parse(EndDateTB.Text),
                IdLandlord = landlord.IdLandlord,
                IdTenant = tenant.IdTenant,
                IdRates = Int32.Parse(IdRatesСB.SelectedValue.ToString()),
                
            };
            DBEntities.GetContext().Contract.Add(contractAdd);
            DBEntities.GetContext().SaveChanges();
            contract.IdContract = contractAdd.IdContract;
        }

        private void TenantAdd()
        {
            var tenantAdd = new Tenant()
            {
                CompanyName = CompanyNameTB.Text,
                LastNameTenant = LastNameTenantTB.Text,
                FirstNameTenant = FirstNameTenantTB.Text,
                MiddleNameTenant = MiddleNameTenantTB.Text,
                Phone = PhoneTB.Text,
                Email = EmailTB.Text
            };
            DBEntities.GetContext().Tenant.Add(tenantAdd);
            DBEntities.GetContext().SaveChanges();
            tenant.IdTenant = tenantAdd.IdTenant;
        }

        private void LandlordAdd()
        {
            var landlordAdd = new Landlord()
            {
                LastNameLandlord = LastNameLandlordTB.Text,
                FirstNameLandlord = FirstNameLandlordDP.Text,
                MiddleNameLandlord = MiddleNameLandlord.Text,
                PhoneLandlord = PhoneLandlordTB.Text,
                EmailLandlord = EmailLandlordTB.Text,
                SerPass = SerPassTB.Text,
                NumberPass = NumberPassTB.Text           
            };
            DBEntities.GetContext().Landlord.Add(landlordAdd);
            DBEntities.GetContext().SaveChanges();
            landlord.IdLandlord = landlordAdd.IdLandlord;
        }

        private void PaymentAdd()
        {
            var paymentAdd = new Payment()
            {
                DateOfPayment = DateTime.Parse(DateOfPaymentTB.Text),
                AmountPayment = Int32.Parse(AmountPaymentTB.Text)
            };
            DBEntities.GetContext().Payment.Add(paymentAdd);
            DBEntities.GetContext().SaveChanges();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TenantAdd();
                LandlordAdd();
                ContractAddd();
                StorageRooms storageRooms = DBEntities.GetContext()
                    .StorageRooms.FirstOrDefault(u => u.IdStorageRooms == IdStorage);
                storageRooms.IdStatus = 2;
                DBEntities.GetContext().SaveChanges();
                MBClass.InfoMB("Контракт заключен");
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRatesPage());
        }
    }
}
