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
    /// Interaction logic for AnnouncmentPage.xaml
    /// </summary>
    public partial class AnnouncmentPage : Page
    {
        AnnouncmentItem? item; 
        Frame CurrentPage;
        UserData? User;
        public AnnouncmentPage(Frame currentPage, UserData user, Announcment announcment)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            User = user;
            item = new AnnouncmentItem(announcment);
            G_Page.DataContext = item;
            LV_Responsibilities.ItemsSource = item.Responsibilities;
            LV_Requirements.ItemsSource = item.Requirements;
            IC_Benefits.ItemsSource = item.Benefits;
            Lbl_Adress.Content = item.City;
            DateTime? date = item.EndDate;
            if (date != null)
            {
                Lbl_EndDate.Content = $"Do: {date.Value.Day}.{date.Value.Month}.{date.Value.Year}";
            }
            Lbl_Position.Content = item.PositionName;
            Lbl_WorkTime.Content = item.WorkingTime;
            Lbl_PositionLevel.Content = item.PositionLevel;
            Lbl_WorkType.Content = item.WorkType;
            
            if(App.DataAccess.GetApplicationList().Where(item => item.AnnouncmentID == announcment.AnnouncmentID).Any())
            {
                int? id = App.DataAccess.GetApplicationList().Where(item => item.AnnouncmentID == announcment.AnnouncmentID).First().UserID;
                if (id != null && id == user.UserDataID)
                {
                    Br_Application.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Br_Application.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (user.AccountTypeID == 1)
                {
                    Br_Application.Visibility = Visibility.Visible;
                }
                
            }
           
            
        }
        public AnnouncmentPage(Frame currentPage, Announcment announcment)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            item = new AnnouncmentItem(announcment);
            G_Page.DataContext = item;
            LV_Responsibilities.ItemsSource = item.Responsibilities;
            LV_Requirements.ItemsSource = item.Requirements;
            IC_Benefits.ItemsSource = item.Benefits;
            Lbl_Adress.Content = item.City;
            DateTime? date = item.EndDate;
            if (date != null)
            {
                Lbl_EndDate.Content = $"Do: {date.Value.Day}.{date.Value.Month}.{date.Value.Year}";
            }
            Lbl_Position.Content = item.PositionName;
            Lbl_WorkTime.Content = item.WorkingTime;
            Lbl_PositionLevel.Content = item.PositionLevel;
            Lbl_WorkType.Content = item.WorkType;
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage.GoBack();
        }

        private void Btn_Application_Click(object sender, RoutedEventArgs e)
        {
            if(User != null && this.item != null)
            {
                Models.Application item = new Models.Application();
                item.AnnouncmentID = this.item.AnnouncmentID;
                item.UserID = User.UserDataID;
                App.DataAccess.Add_Application(item);
                MessageBox.Show("Zaaplikowałeś się do ogłoszenia!");
                Btn_Application.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
