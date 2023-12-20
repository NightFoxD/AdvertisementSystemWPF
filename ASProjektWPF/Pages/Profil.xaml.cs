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
using System.Reflection;
using System.Collections.ObjectModel;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        Frame? CurrentPage;
        UserData? userData;
        User? user;
        List<string> countries = new List<string>();
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
        public void GetUserData()
        {
            if(userData != null)
            {
                user = App.DataAccess.GetUserInformations(userData);
            }
           
        }
        public void LoadInformations()
        {
            GetUserData();
            Load_UserData_Form();
            EnDis_TB_UserInformatoins(false);
            Load_ContactData_Form();
            EnDis_TB_ContactData(false);
            Load_UserExperienceWorkList();
            Load_UserEducationList();
            Load_UserLanguageList();
            Load_UserLinkList();
            Load_UserApplications();
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
                if(user != null)
                {
                    if (user.Pfp != null)
                    {
                        Btn_AddPfp.Content = "Edytuj";
                    }
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
            if(user == null)
            {
                return;
            }
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
            if (user == null)
            {
                return;
            }
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
            if (userData == null || user == null)
            {
                return;
            }
            TxtB_Email.Text = userData.Email;
            TxtB_PhoneNumber.Text = user.TelephoneNumber.ToString();
            DP_User.SelectedDate = user.BirthDate;
        }
        private void Update_ContactDataForm()
        {
            if (userData == null || user == null)
            {
                return;
            }
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
        public async void Load_UserExperienceWorkList()
        {
            if (user == null) return;
            LV_UserExperience.ItemsSource = await App.DataAccess.GetExperienceList(user);
            if (LV_UserExperience.ItemsSource is null || LV_UserExperience.Items.Count < 1)
            {
                TxtB_ExperienceWork_Info.Visibility = Visibility.Visible;
            }
            else
            {
                TxtB_ExperienceWork_Info.Visibility = Visibility.Collapsed;
            }
        }
        public void EnDis_TB_ExperienceWorktData(bool value, TextBox position, TextBox Localization, TextBox Company, DatePicker startPaymentDate, DatePicker endPaymentDate, TextBox responsibilities)
        {
            if (value)
            {
                position.IsEnabled = true;
                Localization.IsEnabled = true;
                Company.IsEnabled = true;
                startPaymentDate.IsEnabled = true;
                endPaymentDate.IsEnabled = true;
                responsibilities.IsEnabled = true;
            }
            else
            {
                position.IsEnabled = false;
                Localization.IsEnabled = false;
                Company.IsEnabled = false;
                startPaymentDate.IsEnabled = false;
                endPaymentDate.IsEnabled = false;
                responsibilities.IsEnabled = false;
            }
        }
        private void Btn_ExperienceWork_AddNew_Form_Click(object sender, RoutedEventArgs e)
        {
            G_ExperienceWork.Visibility = Visibility.Visible;
            Load_UserExperienceWorkList();
        }

        private void Btn_ExperienceWork_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_ExperienceWork.Visibility = Visibility.Collapsed;
            Load_UserExperienceWorkList() ;
        }

        private void Btn_ExperienceWork_AddNew_Click(object sender, RoutedEventArgs e)
        {
            Experience newExperience = new Experience();
            G_ExperienceWork.Visibility = Visibility.Collapsed;
            newExperience.Position = TxtB_Position.Text;
            newExperience.Localization = TxtB_Lokalization.Text;
            newExperience.Company = TxtB_Company.Text;
            newExperience.StartPayment = DP_startPaymentDate.SelectedDate;
            newExperience.EndPayment = DP_endPaymentDate.SelectedDate;
            newExperience.Responsibilities = TxtB_Responsibilities.Text;
            TxtB_Position.Text ="";
            TxtB_Lokalization.Text = "";
            TxtB_Company.Text = "";
            DP_startPaymentDate.SelectedDate = null;
            DP_endPaymentDate.SelectedDate = null;
            TxtB_Responsibilities.Text = "";
            if (user == null) return;
            App.DataAccess.Add_Experience(newExperience,user);
            Load_UserExperienceWorkList();
        }
        private void Btn_ExperienceWork_Delete_Click(object sender, RoutedEventArgs e)
        {
            Experience? deleteExperience = ((Button)sender).CommandParameter as Experience;
            if (deleteExperience == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                App.DataAccess.Delete_Experience(deleteExperience);
            }
            Load_UserExperienceWorkList();
        }
        private void Btn_ExperienceWork_EditAccExperience_Click(object sender, RoutedEventArgs e)
        {
            Experience? updateExperience = ((Button)sender).CommandParameter as Experience;
            if (updateExperience == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                if (CurrentPage == null) return;
                CurrentPage.Navigate(new Profil_EditItem(CurrentPage, updateExperience));
            }
        }
        public async void Load_UserEducationList()
        {
            if (user == null) return;
            Lv_UserEducationList.ItemsSource = await App.DataAccess.GetEducationList(user);
            if (Lv_UserEducationList.ItemsSource is null || Lv_UserEducationList.Items.Count < 1)
            {
                TxtB_Education_Info.Visibility = Visibility.Visible;
            }
            else
            {
                TxtB_Education_Info.Visibility = Visibility.Collapsed;
            }
        }
        private void Btn_Education_AddNewForm_Click(object sender, RoutedEventArgs e)
        {
            G_Education.Visibility = Visibility.Visible;
            TxtB_Education_Info.Visibility = Visibility.Collapsed;
            Load_UserEducationList();
        }
        private void Btn_Education_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_Education.Visibility = Visibility.Collapsed;
            Load_UserEducationList();
        }
        private void Btn_Experience_AddNew_Click(object sender, RoutedEventArgs e)
        {
            G_Education.Visibility = Visibility.Collapsed;
            Education newEducation = new Education();
            newEducation.ShoolName = TxtB_Education_ShoolName.Text;
            newEducation.Level = CB_Education_Level.Text;
            newEducation.Direction = TxtB_Education_Direction.Text;
            newEducation.StartPeriod = DP_Education_StartPeriod.SelectedDate;
            newEducation.EndPeriod = DP_Education_EndPeriod.SelectedDate;
            if (user == null) return;
            App.DataAccess.Add_Education(newEducation,user);
            Load_UserEducationList();
        }
        private void Btn_Education_Delete_Click(object sender, RoutedEventArgs e)
        {
            Education? updateEducation = ((Button)sender).CommandParameter as Education;
            if (updateEducation == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                App.DataAccess.Delete_Education(updateEducation);
            }
            Load_UserEducationList();
        }
        private void Btn_Education_Edit_Click(object sender, RoutedEventArgs e)
        {
            Education? updateEducation = ((Button)sender).CommandParameter as Education;
            if (updateEducation == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                if (CurrentPage == null) return;
                CurrentPage.Navigate(new Profil_EditItem(CurrentPage, updateEducation));
            }
        }
        private async void Load_UserLanguageList()
        {
            if (user == null) return;
            LV_UserLeagueList.ItemsSource = await App.DataAccess.GetLanguageList(user);
            if (LV_UserLeagueList.ItemsSource is null || LV_UserLeagueList.Items.Count < 1)
            {
                Lb_LanguageInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Lb_LanguageInfo.Visibility = Visibility.Collapsed;
            }
        }
        private void Btn_Language_AddForm_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Visible;
            Btn_Language_Edit.Visibility = Visibility.Collapsed;
            Load_UserLanguageList();
        }

        private void Btn_Language_Cancel_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Collapsed;
            Btn_Language_Edit.Visibility = Visibility.Visible;
            Load_UserLanguageList();
        }

        private void Btn_Language_Add_Click(object sender, RoutedEventArgs e)
        {
            SP_Language_Add.Visibility = Visibility.Collapsed;
            Btn_Language_Edit.Visibility = Visibility.Visible;
            Language newLanguage = new Language();
            newLanguage.Name = CB_LanguageSelected.Text;
            newLanguage.Level = CB_LanguageLevel.Text;
            if (user == null) return;
            App.DataAccess.Add_Language(newLanguage,user);
            Load_UserLanguageList();
        }
        private void Btn_Language_Delete_Click(object sender, RoutedEventArgs e)
        {
            Language? deleteLanguage = ((Button)sender).CommandParameter as Language;
            if (deleteLanguage == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                App.DataAccess.Delete_Language(deleteLanguage);
            }
            Load_UserLanguageList();
        }
        private void Btn_Language_Edit_Click(object sender, RoutedEventArgs e)
        {
            Language? updateLanguage = ((Button)sender).CommandParameter as Language;
            if (updateLanguage == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                if (CurrentPage == null) return;
                CurrentPage.Navigate(new Profil_EditItem(CurrentPage, updateLanguage));
            }
        }
        private async void Load_UserSkillList()
        {
            if (user == null) return;
            IC_UserSkills.ItemsSource = await App.DataAccess.GetSkillList(user);
            if (IC_UserSkills.ItemsSource is null || LV_UserLeagueList.Items.Count < 1)
            {
                Lb_LanguageInfo.Visibility = Visibility.Visible;
            }
            else
            {
                Lb_LanguageInfo.Visibility = Visibility.Collapsed;
            }
        }
        private void Btn_UserSkillsAdd_Click(object sender, RoutedEventArgs e)
        {
            Skill newSkill = new Skill();
            newSkill.Name = TxtB_SkillName.Text;
            if (user == null) return;
            App.DataAccess.Add_Skills(newSkill,user);
            TxtB_SkillName.Text = "";
            Load_UserSkillList();
        }
        private void Btn_Skill_Delete_Click(object sender, RoutedEventArgs e)
        {
            Skill? deleteSkill = ((Button) sender).CommandParameter as Skill;
            if (deleteSkill == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                App.DataAccess.Delete_Skills(deleteSkill);
            }
            Load_UserSkillList();
        }
        private async void Load_UserLinkList()
        {
            if (user == null) return;
            Lv_UserLinknList.ItemsSource = await App.DataAccess.GetLinkList(user);
            if (Lv_UserLinknList.ItemsSource is null || Lv_UserLinknList.Items.Count < 1)
            {
                Tb_Link_Info.Visibility = Visibility.Visible;
            }
            else
            {
                Tb_Link_Info.Visibility = Visibility.Collapsed;
            }
        }
        private void Btn_Link_AddForm_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Visible;
            Tb_Link_Info.Visibility = Visibility.Collapsed;
        }
        private void Btn_Link_Cancel_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Collapsed;
            Load_UserLinkList();
        }

        private void Btn_Link_AddNew_Click(object sender, RoutedEventArgs e)
        {
            G_AddLink.Visibility = Visibility.Collapsed;
            Link newLink = new Link();
            newLink.Name = TxtB_URL.Text;
            newLink.Type = CB_Type.Text;
            if (user == null) return;
            App.DataAccess.Add_Link(newLink,user);
            Load_UserLinkList();
        }
        private void Btn_Link_Delete_Click(object sender, RoutedEventArgs e)
        {
            Link? deleteLink = ((Button)sender).CommandParameter as Link;
            if (deleteLink == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                App.DataAccess.Delete_Link(deleteLink);
            }
            Load_UserLinkList();
        }
        private void Btn_Link_Edit_Click(object sender, RoutedEventArgs e)
        {
            Link? updateLink = ((Button)sender).CommandParameter as Link;
            if (updateLink == null)
            {
                MessageBox.Show("error", "Wystąpił błąd!");
            }
            else
            {
                if (CurrentPage == null) return;
                CurrentPage.Navigate(new Profil_EditItem(CurrentPage, updateLink));
            }
        }
        private void Btn_AddPfp_Click(object sender, RoutedEventArgs e)
        {
            Picture newPfp = PictureControl.GetPicture();
            if(user != null)
            {
                user.Pfp = newPfp.Name + newPfp.PictureFormat;
                I_UserPfp.Source = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + user.Pfp) as ImageSource;
            }

        }
        private void Btn_DeleteApplication(object sender, RoutedEventArgs e)
        {
            AnnouncmentItem? item = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (item != null)
            {
                Announcment? itemAnnouncment = item.Announcment;
                if (itemAnnouncment != null && user != null)
                {
                    List<Models.Application> list = App.DataAccess.GetApplicationList();
                    Models.Application application = new Models.Application();
                    foreach (var itemList in list)
                    {
                        if (itemList.UserID == user.UserDataID && itemList.AnnouncmentID == itemAnnouncment.AnnouncmentID)
                        {
                            application = itemList;
                            break;
                        }
                    }
                    App.DataAccess.Delete_Application(application);
                }
            }
            Load_UserApplications();
        }        
        public void Load_UserApplications()
        {
            ObservableCollection<AnnouncmentItem> list = new ObservableCollection<AnnouncmentItem>();
            if(user!= null)
            {
                foreach (var application in App.DataAccess.GetApplicationList(user))
                {
                    foreach (var announcment in App.DataAccess.GetAnnouncmentList())
                    {
                        if(application.AnnouncmentID == announcment.AnnouncmentID)
                        {
                            list.Add(new AnnouncmentItem(announcment));
                        }
                    }
                }
            }
            if(list.Count == 0)
            {
                TxtB_Application_Info.Visibility = Visibility.Visible;
                G_ApplicationInfo.Visibility = Visibility.Collapsed;
            }
            else
            {
                TxtB_Application_Info.Visibility = Visibility.Collapsed;
                G_ApplicationInfo.Visibility = Visibility.Visible;
            }
            LV_UserApplications.ItemsSource = list;
            
        }
        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            AnnouncmentItem? item = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (item != null)
            {
                Announcment? itemAnnouncment = item.Announcment;
                if (itemAnnouncment != null && userData != null && CurrentPage != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, userData, itemAnnouncment));
                }
            }
           
        }
    }
}
