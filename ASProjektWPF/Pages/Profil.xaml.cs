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
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        Frame CurrentPage;
        public Profil(Frame CurrentPage)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            CheckUserLanguage();
            CheckUserSkills();
            CheckUserLinks();
        }
        public void CheckUserLanguage()
        {
            if (Lv_UserLanguages.Items.Count == 0)
            {
                SP_UserLanguage.Visibility = Visibility.Collapsed;
                Lb_LanguageInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Lb_LanguageInfo.Visibility = Visibility.Collapsed;
            }
        }
        public void CheckUserSkills()
        {
            if (Lv_UserSkills.Items.Count == 0)
            {
                Lv_UserSkills.Visibility = Visibility.Collapsed;
            }
        }
        public void CheckUserLinks()
        {
            if (Lv_UserLinks.Items.Count == 0)
            {
                Lv_UserLinks.Visibility = Visibility.Collapsed;
            }
        }
        public void VisibleCollapseUserData(bool VisCol)
        {
            if (VisCol)
            {
                Lbl_Name.Visibility = Visibility.Visible;
                Lbl_Surname.Visibility = Visibility.Visible;
                Lbl_City.Visibility = Visibility.Visible;
                Lbl_Country.Visibility = Visibility.Visible;
                Lbl_CurrentOccupation.Visibility = Visibility.Visible;
            }
            else
            {
                Lbl_Name.Visibility = Visibility.Collapsed;
                Lbl_Surname.Visibility = Visibility.Collapsed;
                Lbl_City.Visibility = Visibility.Collapsed;
                Lbl_Country.Visibility = Visibility.Collapsed;
                Lbl_CurrentOccupation.Visibility = Visibility.Collapsed;
            }
        }
        public void VisibleCollapseContactData(bool VisCol)
        {
            if (VisCol)
            {
                TxtB_PhoneNumber.Visibility = Visibility.Visible;
                CB_Day.Visibility = Visibility.Visible;
                CB_Month.Visibility = Visibility.Visible;
                CB_Year.Visibility = Visibility.Visible;
            }
            else
            {
                TxtB_PhoneNumber.Visibility = Visibility.Collapsed;
                CB_Day.Visibility = Visibility.Collapsed;
                CB_Month.Visibility = Visibility.Collapsed;
                CB_Year.Visibility = Visibility.Collapsed;
            }
        }
        public void ColEditButton(Button edit, Button cancel, Button save)
        {
            edit.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
        }
        public void VisEditButton(Button edit, Button cancel, Button save)
        {
            cancel.Visibility = Visibility.Collapsed;
            save.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;
        }
        private void Btn_UserData_Edit_Click(object sender, RoutedEventArgs e)
        {
            ColEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
            VisibleCollapseUserData(true);
        }

        private void Btn_UserData_Cancel_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
            VisibleCollapseUserData(false);
        }

        private void Btn_UserData_Save_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
            VisibleCollapseUserData(false);
        }

        private void Btn_ContactData_Edit_Click(object sender, RoutedEventArgs e)
        {
            ColEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            VisibleCollapseContactData(true);
        }

        private void Btn_ContactData_Cancel_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            VisibleCollapseContactData(false);
        }

        private void Btn_ContactData_Save_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            VisibleCollapseContactData(false);
        }

        private void Btn_ExperienceWork_AddNew_Click(object sender, RoutedEventArgs e)
        {

            G_ExperienceWork.Visibility = Visibility.Visible;
            TxtB_ExperienceWork_Info.Visibility = Visibility.Collapsed;
        }

        private void Btn_ExperienceWork_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_ExperienceWork.Visibility = Visibility.Collapsed;
            TxtB_ExperienceWork_Info.Visibility = Visibility.Visible;
        }

        private void Btn_ExperienceWork_Save_Click(object sender, RoutedEventArgs e)
        {
            G_ExperienceWork.Visibility = Visibility.Collapsed;
            TxtB_ExperienceWork_Info.Visibility = Visibility.Visible;
        }

        private void Btn_Experience_AddNew_Click(object sender, RoutedEventArgs e)
        {
            G_Experience.Visibility = Visibility.Visible;
            TxtB_Experience_Info.Visibility = Visibility.Collapsed;
        }

        private void Btn_Experience_Save_Click(object sender, RoutedEventArgs e)
        {
            G_Experience.Visibility = Visibility.Collapsed;
            TxtB_Experience_Info.Visibility = Visibility.Visible;
        }

        private void Btn_Experience_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_Experience.Visibility = Visibility.Collapsed;
            TxtB_Experience_Info.Visibility = Visibility.Visible;
        }

        private void Btn_Language_Edit_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Visible;
            Btn_Language_Edit.Visibility = Visibility.Collapsed;
            Lb_LanguageInfo.Visibility = Visibility.Collapsed;
        }

        private void Btn_Language_Cancel_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Collapsed;
            Btn_Language_Edit.Visibility = Visibility.Visible;
        }

        private void Btn_Language_Save_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Collapsed;
            Btn_Language_Edit.Visibility = Visibility.Visible;
            CheckUserLanguage();
        }

        private void Btn_UserSkillsAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Link_Add_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Visible;
            Tb_Link_Info.Visibility = Visibility.Collapsed;
        }
        private void Btn_Link_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Collapsed;
            if (Lv_UserLinks.Items.Count != 0)
            {
                Tb_Link_Info.Visibility = Visibility.Collapsed;
            }
            else
            {
                Tb_Link_Info.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Link_Save_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Collapsed;
            if (Lv_UserLinks.Items.Count != 0)
            {
                Tb_Link_Info.Visibility = Visibility.Collapsed;
            }
            else
            {
                Tb_Link_Info.Visibility = Visibility.Visible;
            }
            CheckUserLinks();
        }
    }
}
