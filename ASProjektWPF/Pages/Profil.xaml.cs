using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Globalization;
using System.Drawing;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        Frame CurrentPage;
        UserData userData;
        User user;
        Experience experience;
        List<string> countries = new List<string>();
        List<string> months = new List<string>();
        List<string> days = new List<string>();
        List<string> years = new List<string>();
        List<string> imagesToDel = new List<string>(); 
        public Profil(Frame CurrentPage, UserData LoginUserData)
        {
            InitializeComponent();
            this.CurrentPage = CurrentPage;
            this.userData = LoginUserData;
            countries = GetListOfCountries();
            countries.Sort();
            foreach (string country in countries)
            {
                CB_Country.Items.Add(country);
            }
            CheckAll();
            LoadInformations();
        }
        private List<string> GetListOfCountries()
        {
            List<string> countries = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo region = new RegionInfo(ci.Name);
                string countryName = region.DisplayName;

                if (!countries.Contains(countryName))
                {
                    countries.Add(countryName);
                }
            }
            return countries;
        }
        public async void GetUserData()
        {
            user = await App.DataAccess.GetUserInformations(userData);
            //experience = await App.DataAccess.GetExperienceList().Result.Where(item => item.UserID == this.user.UserID).First;
        }
        public void LoadInformations()
        {
            GetUserData();
            Load_UserData_Form();
            EnDis_TB_UserInformatoins(false);
            Load_ContactData_Form();
            EnDis_TB_ContactData(false);
        }
        public void CheckAll()
        {
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
        //public void VisibleCollapseContactData(bool VisCol)
        //{
        //    if (VisCol)
        //    {
        //        TxtB_PhoneNumber.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        TxtB_PhoneNumber.Visibility = Visibility.Collapsed;
        //    }
        //}
        public void ColEditButton(Button edit, Button cancel, Button save)
        {
            edit.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Visible;
            
        }
        public void EnDis_TB_UserInformatoins(bool value)
        {
            if (value)
            {
                TxtB_Name.IsEnabled = true;
                TxtB_Surname.IsEnabled = true;
                TxtB_City.IsEnabled = true;
                TxtB_CurrentOccupation.IsEnabled = true;
                Lbl_Country.IsEnabled = true;
                CB_Country.IsEnabled = true;
                Btn_AddPfp.Visibility = Visibility.Visible;
                if(user.Pfp != null)
                {
                    Btn_AddPfp.Content = "Edytuj";
                }
            }
            else
            {
                TxtB_Name.IsEnabled = false;
                TxtB_Surname.IsEnabled = false;
                TxtB_City.IsEnabled = false;
                TxtB_CurrentOccupation.IsEnabled = false;
                CB_Country.IsEnabled = false;
                Btn_AddPfp.Visibility = Visibility.Collapsed;
            }
        }
        public void VisEditButton(Button edit, Button cancel, Button save)
        {
            cancel.Visibility = Visibility.Collapsed;
            save.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;
        }
        public void Load_UserData_Form()
        {
            TxtB_Name.Text = user.Name;
            TxtB_Surname.Text = user.Surname;
            TxtB_City.Text = user.City;
            TxtB_CurrentOccupation.Text = user.CurrentOccupation;
            if(user.Country != null)
            {
                CB_Country.SelectedItem = user.Country;
            }
            else
            {
                CB_Country.SelectedIndex = 0;
            }
            
            ImageSource? pfp;
            
            if (user.Pfp == null)
            {
                pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultPfp.png") as ImageSource;
            }
            else
            {
                if(!File.Exists("../../../Images/Uploads/" + user.Pfp))
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultPfp.png") as ImageSource;
                }
                else
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + user.Pfp) as ImageSource;
                }
                
            }
            I_UserPfp.Source = pfp;
        }
        public void Update_UserDataForm()
        {
            user.Name = TxtB_Name.Text;
            user.Surname = TxtB_Surname.Text;
            user.City = TxtB_City.Text;
            user.CurrentOccupation = TxtB_CurrentOccupation.Text;
            user.Country = CB_Country.SelectedItem.ToString();
            App.DataAccess.UpdateUser(user);
            Load_UserData_Form();
        }
        private void Btn_UserData_Edit_Click(object sender, RoutedEventArgs e)
        {
            ColEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
            VisibleCollapseUserData(true);
            EnDis_TB_UserInformatoins(true);
        }

        private void Btn_UserData_Cancel_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
            Load_UserData_Form();
            VisibleCollapseUserData(false);
            EnDis_TB_UserInformatoins(false);
        }

        private void Btn_UserData_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CB_Country.SelectedItem == null)
            {
                MessageBox.Show("Nie zaznaczono miasta!", "Error", MessageBoxButton.OK);
                return;
            }
            if(CustomValidations.IsCorrectText(TxtB_Name.Text) && CustomValidations.IsCorrectText(TxtB_Name.Text) && CustomValidations.IsCorrectText(TxtB_City.Text))
            {
                VisEditButton(Btn_UserData_Edit, Btn_UserData_Cancel, Btn_UserData_Save);
                Update_UserDataForm();
                VisibleCollapseUserData(false);
                EnDis_TB_UserInformatoins(false);
            }
            else
            {
                MessageBox.Show("Wprowadzono niepoprawne dane!", "Error", MessageBoxButton.OK);
            }
            
        }
        public void EnDis_TB_ContactData(bool value)
        {
            if (value)
            {
                TxtB_Email.IsEnabled = true;
                TxtB_PhoneNumber.IsEnabled = true;
                DP_User.IsEnabled = true;
            }
            else
            {
                TxtB_Email.IsEnabled = false;
                TxtB_PhoneNumber.IsEnabled = false;
                DP_User.IsEnabled = false;
            }
        }
        private void Load_ContactData_Form()
        {
            TxtB_Email.Text = userData.Email;
            TxtB_PhoneNumber.Text = user.TelephoneNumber.ToString();
            DP_User.SelectedDate = user.BirthDate;
        }
        private void Update_ContactDataForm()
        {
            userData.Email = TxtB_Email.Text;
            user.TelephoneNumber = int.Parse(TxtB_PhoneNumber.Text);
            user.BirthDate = DP_User.SelectedDate;
            App.DataAccess.UpdateUser(user);
            App.DataAccess.UpdateUserData(userData);
        }
        private void Btn_ContactData_Edit_Click(object sender, RoutedEventArgs e)
        {
            ColEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            EnDis_TB_ContactData(true);
            //VisibleCollapseContactData(true);
        }

        private void Btn_ContactData_Cancel_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            Load_ContactData_Form();
            EnDis_TB_ContactData(false);
            //VisibleCollapseContactData(false);
        }

        private void Btn_ContactData_Save_Click(object sender, RoutedEventArgs e)
        {
            VisEditButton(Btn_ContactData_Edit, Btn_ContactData_Cancel, Btn_ContactData_Save);
            Update_ContactDataForm();
            Load_ContactData_Form();
            EnDis_TB_ContactData(false);
           // VisibleCollapseContactData(false);
        }
        public void EnDis_TB_ExperienceWorktData(bool value)
        {
            if (value)
            {
                TxtB_Position.IsEnabled = true;
                TxtB_Lokalization.IsEnabled = true;
                TxtB_Company.IsEnabled = true;
                CB_StartPayment_Month.IsEnabled = true;
                CB_StartPayment_Year.IsEnabled = true;
                CB_EndPayment_month.IsEnabled = true;
                CB_EndPayment_year.IsEnabled = true;
                TxtB_Responsibilities.IsEnabled = true;
            }
            else
            {
                TxtB_Position.IsEnabled = false;
                TxtB_Lokalization.IsEnabled = false;
                TxtB_Company.IsEnabled = false;
                CB_StartPayment_Month.IsEnabled = false;
                CB_StartPayment_Year.IsEnabled = false;
                CB_EndPayment_month.IsEnabled = false;
                CB_EndPayment_year.IsEnabled = false;
                TxtB_Responsibilities.IsEnabled = false;
            }
        }
        private void Load_ExperienceWork_Form()
        {
            TxtB_Position.IsEnabled = false;
            TxtB_Lokalization.IsEnabled = false;
            TxtB_Company.IsEnabled = false;
            CB_StartPayment_Month.IsEnabled = false;
            CB_StartPayment_Year.IsEnabled = false;
            CB_EndPayment_month.IsEnabled = false;
            CB_EndPayment_year.IsEnabled = false;
            TxtB_Responsibilities.IsEnabled = false;
        }
        private void Update_ExperienceWork_Form()
        {
            TxtB_Position.IsEnabled = false;
            TxtB_Lokalization.IsEnabled = false;
            TxtB_Company.IsEnabled = false;
            CB_StartPayment_Month.IsEnabled = false;
            CB_StartPayment_Year.IsEnabled = false;
            CB_EndPayment_month.IsEnabled = false;
            CB_EndPayment_year.IsEnabled = false;
            TxtB_Responsibilities.IsEnabled = false;
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

        private void Btn_AddPfp_Click(object sender, RoutedEventArgs e)
        {
            Picture newPfp = PictureControl.GetPicture("Uploads");
            user.Pfp = newPfp.Name + newPfp.PictureFormat;
            I_UserPfp.Source = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + user.Pfp) as ImageSource;
        }

    }
}
