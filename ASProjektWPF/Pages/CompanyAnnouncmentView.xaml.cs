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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for CompanyAnnouncmentView.xaml
    /// </summary>
    public partial class CompanyAnnouncmentView : Page
    {
        Frame CurrentPage;
        Company Company;
        public CompanyAnnouncmentView(Frame currentPage, Company company)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            Company = company;
            Refresh();
        }
        private void Refresh()
        {
            LV_CompanyAnnouncment.ItemsSource = App.DataAccess.GetAnnouncmentList().Where(item=>item.CompanyID == Company.CompanyID);
        }
        private void Btn_DeleteAnnouncment_Clicked(object sender, RoutedEventArgs e)
        {
            Announcment? item = ((Button)sender).CommandParameter as Announcment;
            if (item == null)
            {
                MessageBox.Show("error");
                return;
            }
            App.DataAccess.Delete_Announcment(item);
            Refresh();
        }

        private void Btn_EditAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            Announcment? item = ((Button)sender).CommandParameter as Announcment;
            if (item == null)
            {
                MessageBox.Show("error");
                return;
            }
           CurrentPage.Navigate(new Announcment_AddEdit(CurrentPage,item,Company));
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.GoBack();
        }

    }
}
