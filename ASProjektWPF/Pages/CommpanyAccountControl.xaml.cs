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
    /// Interaction logic for CommpanyAccountControl.xaml
    /// </summary>
    public partial class CommpanyAccountControl : Page
    {
        Frame CurrentPage;
        Company Company;
        public CommpanyAccountControl(Frame currentPage,Company company)
        {
            InitializeComponent();
            this.CurrentPage = currentPage;
            Company = company;
        }
        private void Btn_AddAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(new Announcment_AddEdit(CurrentPage,Company));
        }        
        private void Btn_EditAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            Announcment? announcment = ((Button)sender).CommandParameter as Announcment;
            CurrentPage.Navigate(new CompanyAnnouncmentView(CurrentPage,Company));
        }        
        private void Btn_ShowUsersApplications_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.Navigate(new ApplicatedUsersShow(CurrentPage, Company));
        }
    }
}
