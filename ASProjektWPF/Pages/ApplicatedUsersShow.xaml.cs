using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ApplicatedUsersShow.xaml
    /// </summary>
    public partial class ApplicatedUsersShow : Page
    {
        Frame? CurrentPage;
        Company? CurrentCompany;
        public ApplicatedUsersShow(Frame currentPage, Company company)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            CurrentCompany = company;
            Load_UserApplications();
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentPage != null)
            {
                CurrentPage.GoBack();
            }
        }
        public void Load_UserApplications()
        {
            ObservableCollection<ApplicationItem> list = new ObservableCollection<ApplicationItem>();
            if (CurrentCompany != null)
            {
                foreach (var application in App.DataAccess.GetApplicationList())
                {
                    foreach (var announcment in App.DataAccess.GetAnnouncmentList())
                    {
                        if (application.AnnouncmentID == announcment.AnnouncmentID)
                        {
                            if(new AnnouncmentItem(announcment).CompanyID == CurrentCompany.CompanyID)
                            {
                                AnnouncmentItem? item = new AnnouncmentItem(announcment);
                                
                                list.Add(new ApplicationItem(item,application.UserID));
                            }
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                TxtB_Application_Info.Visibility = Visibility.Visible;
                G_TitlesList.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtB_Application_Info.Visibility = Visibility.Collapsed;
                G_TitlesList.Visibility = Visibility.Visible;
            }
            LV_CompanyApplications.ItemsSource = list;
        }
        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            Announcment? itemAnnouncment = ((Button)sender).CommandParameter as Announcment;
            if (itemAnnouncment != null && CurrentPage != null)
            {
                CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, itemAnnouncment));
            }
        }
        private void Btn_DeleteApplication(object sender, RoutedEventArgs e)
        {
            ApplicationItem? applicationItem = ((Button)sender).CommandParameter as ApplicationItem;
            if (applicationItem != null)
            {
                foreach (var item in App.DataAccess.GetApplicationList())
                {
                    if(applicationItem.User != null && applicationItem.Announcment!= null)
                    {
                        if (applicationItem.User.UserDataID == item.UserID && applicationItem.Announcment.AnnouncmentID == item.AnnouncmentID)
                        {
                            App.DataAccess.Delete_Application(item);
                            break;
                        }
                    }
                    
                }
            }
            Load_UserApplications();

        }

    }
}
