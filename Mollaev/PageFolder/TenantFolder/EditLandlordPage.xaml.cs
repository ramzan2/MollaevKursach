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
using Mollaev.PageFolder.LandlordFolder;

namespace Mollaev.PageFolder.TenantFolder
{
    /// <summary>
    /// Логика взаимодействия для EditLandlordPage.xaml
    /// </summary>
    public partial class EditLandlordPage : Page
    {

        public EditLandlordPage(Landlord landlord)
        {
            InitializeComponent();

            DataContext = landlord;

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Landlord landlord = DBEntities.GetContext().Landlord.
                FirstOrDefault(s => s.IdLandlord == VairableClass.LandlordId);
            landlord.LastNameLandlord = LastNameLandlordTbB.Text;
            landlord.FirstNameLandlord = FirstNameLandlordTb.Text;
            landlord.MiddleNameLandlord = MiddleNameLandlordTb.Text;
            landlord.PhoneLandlord = PhoneLandlordTb.Text;
            landlord.SerPass = SerPassTb.Text;
            landlord.NumberPass = NumberPassTb.Text;
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Поользователь успешно отредактирован");
            NavigationService.Navigate(new ListTenantPage());
        }
    }
}
