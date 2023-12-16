using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public CompanyProfile(Frame currentPage, Company company, bool editFlag)
        {
            InitializeComponent();
            CurrentPage = currentPage;
            this.company = company;
            ImageSource? pfp;

            if (company.CompanyImage == null)
            {
                pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultCompany.png") as ImageSource;
            }
            else
            {
                if (!File.Exists("../../../Images/Uploads/" + company.CompanyImage))
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultCompany.png") as ImageSource;
                }
                else
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + company.CompanyImage) as ImageSource;
                }

            }
            I_ComapnyImage.Source = pfp;
            if (LV_ComapnyAnnouncments.ItemsSource == null || LV_ComapnyAnnouncments.Items.Count == 0)
            {
                List<AnnouncmentItem> items = new List<AnnouncmentItem>();
                foreach (var item in App.DataAccess.GetAnnouncmentList().Where(item => item.CompanyID == company.CompanyID))
                {
                    items.Add(new AnnouncmentItem(item));
                }
                LV_ComapnyAnnouncments.ItemsSource = items;
            }
            if (editFlag)
            {
                SP_CompanyMenu.Visibility = Visibility.Visible;
                Btn_Back.Visibility = Visibility.Collapsed;
                Btn_SaveEditedCompany.Visibility = Visibility.Collapsed;
            }
            else
            {
                SP_CompanyMenu.Visibility = Visibility.Hidden;
                Btn_Back.Visibility = Visibility.Visible;
            }
            Lbl_Jobs.Content = $"{App.DataAccess.GetAnnouncmentList().Where(item => item.CompanyID == company.CompanyID).ToList().Count} ogłoszeń o pracę";
            Lbl_Company.Content = company.Name;
            Lbl_Adress.Content = company.Adress;
            Lbl_Email.Content = company.Email;
            int count = App.DataAccess.GetAnnouncmentList(company).Count;
            if (count == 1)
            {
                Lbl_Jobs.Content = count + " Oferta pracy";
            }else if (count <4 && count >1)
            {
                Lbl_Jobs.Content = count + " Oferty pracy";
            }
            else
            {
                Lbl_Jobs.Content = count + " Ofert pracy";
            }
            
        }

        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {

            AnnouncmentItem? tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (tmpItem != null)
            {
                Announcment? item = tmpItem.Announcment;
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
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentPage != null)
            {
                CurrentPage.GoBack();
            }
        }

        private void Btn_EditCompany_Click(object sender, RoutedEventArgs e)
        {
            string? content = Btn_EditCompany.Content.ToString();
            if(content == "Anuluj")
            {
                Lbl_Company.Visibility = Visibility.Visible;
                TxtB_CompanyEdit.Visibility = Visibility.Collapsed;
                Lbl_Adress.Visibility = Visibility.Visible;
                TxtB_Adress_Edit.Visibility = Visibility.Collapsed;
                Lbl_Email.Visibility = Visibility.Visible;
                TxtB_Email_Edit.Visibility = Visibility.Collapsed;
                Btn_EditCompanyPfp.Visibility = Visibility.Collapsed;
                Btn_EditCompany.Content = "Edytuj";
            }
            else
            {
                Lbl_Company.Visibility = Visibility.Collapsed;
                TxtB_CompanyEdit.Visibility = Visibility.Visible;
                Lbl_Adress.Visibility = Visibility.Collapsed;
                TxtB_Adress_Edit.Visibility = Visibility.Visible;
                Lbl_Email.Visibility = Visibility.Collapsed;
                TxtB_Email_Edit.Visibility = Visibility.Visible;
                Btn_EditCompanyPfp.Visibility = Visibility.Visible;
                Btn_EditCompany.Content = "Anuluj";
            }
            Btn_SaveEditedCompany.Visibility = Visibility.Visible;
        }

        private void Btn_SaveCompany_Click(object sender, RoutedEventArgs e)
        {
            if(company != null) 
            {
                company.Name = TxtB_CompanyEdit.Text;
                company.Adress = TxtB_Adress_Edit.Text;
                company.Email = TxtB_Email_Edit.Text;
                App.DataAccess.Update_Company(company);
                company = App.DataAccess.GetCompanyFromID(company.CompanyID);
                Lbl_Company.Content = company.Name;
                Lbl_Adress.Content = company.Adress;
                Lbl_Email.Content = company.Email;
                Lbl_Company.Visibility = Visibility.Visible;
                TxtB_CompanyEdit.Visibility = Visibility.Collapsed;
                Lbl_Adress.Visibility = Visibility.Visible;
                TxtB_Adress_Edit.Visibility = Visibility.Collapsed;
                Lbl_Email.Visibility = Visibility.Visible;
                TxtB_Email_Edit.Visibility = Visibility.Collapsed;
                Btn_EditCompanyPfp.Visibility = Visibility.Collapsed;
                Btn_EditCompany.Content = "Edytuj";
            }
        }

        private void Btn_EditCompanyPfp_Click(object sender, RoutedEventArgs e)
        {
            Picture newPfp = PictureControl.GetPicture();
            if(company != null)
            {
                company.CompanyImage = newPfp.Name + newPfp.PictureFormat;
                I_ComapnyImage.Source = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + company.CompanyImage) as ImageSource;
            }
        }
    }
}
