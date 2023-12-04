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
            DG_AccountType.ItemsSource = await App.DataAccess.GetAccountTypeList();
            DG_Announcment.ItemsSource = await App.DataAccess.GetAnnouncmentList();
            DG_Application.ItemsSource = await App.DataAccess.GetApplicationList();
            DG_Category.ItemsSource = await App.DataAccess.GetCategoryList();
            DG_Company.ItemsSource = await App.DataAccess.GetCompanyList();
            DG_Education.ItemsSource = await App.DataAccess.GetEducationList();
            DG_Experience.ItemsSource = await App.DataAccess.GetExperienceList();
            DG_Language.ItemsSource = await App.DataAccess.GetLanguageList();
            DG_Link.ItemsSource = await App.DataAccess.GetLinkList();
            DG_Saved.ItemsSource = await App.DataAccess.GetSavedList();
            DG_Skill.ItemsSource = await App.DataAccess.GetSkillList();
            DG_SubCategory.ItemsSource = await App.DataAccess.GetSubcategoryList();
            DG_User.ItemsSource = await App.DataAccess.GetUserList();
            DG_UserData.ItemsSource = await App.DataAccess.GetUserDataList();
            DG_WorkingDays.ItemsSource = await App.DataAccess.GetWorkingDaysList();
            
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
        private void Btn_DelAccountType_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_AccountType.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_AccountType((AccountType)DG_AccountType.SelectedItem);
            GetInformations();
        }
        private void Btn_DelAnnouncment_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Announcment.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Announcment((Announcment)DG_Announcment.SelectedItem);
            GetInformations();
        }
        private void Btn_DelApplication_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Application.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Application((Models.Application)DG_Application.SelectedItem);
            GetInformations();
        }
        private void Btn_DelCategory_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Category.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Category((Category)DG_Category.SelectedItem);
            GetInformations();
        }
        private void Btn_DelCompany_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Company.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Company((Company)DG_Company.SelectedItem);
            GetInformations();
        }
        private void Btn_DelCourse_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Course.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Course((Course)DG_Course.SelectedItem);
            GetInformations();
        }
        private void Btn_DelEducation_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Education.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Education((Education)DG_Education.SelectedItem);
            GetInformations();
        }
        private void Btn_DelExperience_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Experience.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Experience((Experience)DG_Experience.SelectedItem);
            GetInformations();
        }
        private void Btn_DelLanguage_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Language.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Language((Language)DG_Language.SelectedItem);
            GetInformations();
        }
        private void Btn_DelLink_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Link.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Link((Link)DG_Link.SelectedItem);
            GetInformations();
        }
        private void Btn_DelSaved_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Saved.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Saved((Saved)DG_Saved.SelectedItem);
            GetInformations();
        }
        private void Btn_DelSkill_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_Skill.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_Skills((Skill)DG_Skill.SelectedItem);
            GetInformations();
        }
        private void Btn_DelSubCategory_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_SubCategory.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_SubCategory((SubCategory)DG_SubCategory.SelectedItem);
            GetInformations();
        }
        private void Btn_DelWorkingDays_Clicked(object sender, RoutedEventArgs e)
        {
            if (DG_WorkingDays.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczonno");
                return;
            }
            App.DataAccess.Delete_WorkingDays((WorkingDays)DG_WorkingDays.SelectedItem);
            GetInformations();
        }
    }
}
