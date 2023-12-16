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
    /// Interaction logic for CompanyProfile.xaml
    /// </summary>
    public partial class CompanyProfile : Page
    {
        Frame? CurrentPage;
        Company? company;
        UserData? user;
        public CompanyProfile(Frame currentPage, Company company)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            this.company = company;
            if (App.DataAccess.GetAnnouncmentList(company).Any())
            {
                LV_ComapnyAnnouncments.ItemsSource = App.DataAccess.GetAnnouncmentList(company);
            }
            Lbl_Company.Content = company.Name;
            Lbl_Adress.Content = company.Adress;
            Lbl_Email.Content = company.Email;
            Lbl_Jobs.Content = App.DataAccess.GetAnnouncmentList(company).Count + "Ofert pracy";
        }

        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            Announcment? item = ((Button)sender).CommandParameter as Announcment;
            if (item != null && user != null && CurrentPage != null)
            {
                CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, user, item));
            }
            else if (item != null && CurrentPage != null)
            {
                CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, item));
            }
        }
    }
}
