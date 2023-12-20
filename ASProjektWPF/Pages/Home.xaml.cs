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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Frame CurrentPage;
        UserData? user;
        Company? Company;
        public Home(Frame CurrentPage)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            Initialize();
        }
        public Home(Frame CurrentPage,UserData user)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            this.user = user;
            Initialize();
        }
        public Home(Frame CurrentPage, Company company)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            this.Company = company;
            Initialize();
        }
        public List<AnnouncmentItem> GetAnnouncmentAllInformations()
        {
            List<AnnouncmentItem> items = new List<AnnouncmentItem>();
            foreach (var item in App.DataAccess.GetAnnouncmentList())
            {
                items.Add(new AnnouncmentItem(item));
            }
            return items;
        }
        public void Initialize()
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
            IC_Companies.ItemsSource = App.DataAccess.GetCompanyList();
            foreach (var item in App.DataAccess.GetCategoryList())
            {
                CmB_Category.Items.Add(item.Name);
            }
        }

        private void Btn_NewOfferts_Click(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = GetAnnouncmentAllInformations();
        }
        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            double scrollAmount = 410;
            imageScrollView.ScrollToHorizontalOffset(imageScrollView.HorizontalOffset - scrollAmount);
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            double scrollAmount = 410;
            imageScrollView.ScrollToHorizontalOffset(imageScrollView.HorizontalOffset + scrollAmount);
        }

        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            AnnouncmentItem? tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if(tmpItem != null)
            {
                Announcment? item = tmpItem.Announcment;
                if (item != null && user != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, user, item));
                }
                else if (item != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, item));
                }
            }
           
        }

        private void Btn_GoToCompanyProfile_Click(object sender, RoutedEventArgs e)
        {
            Company? item = ((Button)sender).CommandParameter as Company;
            if(item != null)
            {
                CurrentPage.Navigate(new CompanyProfile(CurrentPage,item, false));
            }
        }
        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                CurrentPage.Navigate(new SearchView(CurrentPage, user, TxtB_SearchBar.Text, CmB_Category.Text, TxtB_Localization.Text));
            }
            else
            {
                CurrentPage.Navigate(new SearchView(CurrentPage, TxtB_SearchBar.Text, CmB_Category.Text, TxtB_Localization.Text));
            }
        }

        private void Btn_WatchMore(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                CurrentPage.Navigate(new SearchView(CurrentPage, user, TxtB_SearchBar.Text, CmB_Category.Text, TxtB_Localization.Text));
            }
            else
            {
                CurrentPage.Navigate(new SearchView(CurrentPage, TxtB_SearchBar.Text, CmB_Category.Text, TxtB_Localization.Text));
            }
        }
    }
}
