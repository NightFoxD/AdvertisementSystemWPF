using ASProjektWPF.Classes;
using ASProjektWPF.Models;
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

namespace ASProjektWPF
{
    /// <summary>
    /// Interaction logic for UsersInfo.xaml
    /// </summary>
    public partial class UsersInfo : Window
    {
        public UsersInfo()
        {
            InitializeComponent();
            GetInformations();
        }
        public async void GetInformations()
        {
            DG_UserData.ItemsSource = await App.DataAccess.GetUserDataList();
            DG_User.ItemsSource = await App.DataAccess.GetUserList();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            GetInformations();
        }
        private void Btn_DelUserData_Clicked(object sender, RoutedEventArgs e)
        {
            if(DG_UserData.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.DelUserData((UserData)DG_UserData.SelectedItem);
            GetInformations();
        }
        private void Btn_DelUser_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_User.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.DelUser((User)DG_User.SelectedItem);
            GetInformations();
        }
    }
}
