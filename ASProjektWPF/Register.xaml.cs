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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace ASProjektWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void SP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
                else
                {
                    WindowState = WindowState.Maximized;
                }
            }
        }

        private void Btn_MinimalizeApp_Clicked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Btn_FullscreanApp_Clicked(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void Btn_CloseApp_Clicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            if (!CustomValidations.IsCorrectTextAndNumbers(TxB_Login.Text) && Cb_Company.IsChecked == false)
            {
                MessageBox.Show("Error", "Niepoprawny login", MessageBoxButton.OK);
                return;
            }
            if (!CustomValidations.IsCorrectTextAndNumbers(TxB_Login.Text) && Cb_Company.IsChecked == true)
            {
                MessageBox.Show("Error", "Nazwa firmy nie może zawierać liczb", MessageBoxButton.OK);
                return;
            }
            if (!CustomValidations.IsCorrectTextAndNumbers(PsB_Password_1.Password) && !CustomValidations.IsCorrectTextAndNumbers(PsB_Password_1.Password)
                && PsB_Password_1.Password != PsB_Password_2.Password)
            {
                MessageBox.Show("Error", "Hasła są niepoprawne albo różnią się od siebie", MessageBoxButton.OK);
                return;
            }
            if (Cb_Company.IsChecked == true && CB_Admin.IsChecked == true)
            {
                MessageBox.Show("Error", "Nie można mieć zaznaczone 'Firma' i 'Admin' jednocześnie", MessageBoxButton.OK);
                return;
            }
            if(Cb_Company.IsChecked == true)
            {
                Company company = new Company();
                company.Login = TxB_Login.Text;
                company.Password = HashPassword.Hash(PsB_Password_1.Password);
                if(App.DataAccess.GetCompany(company.Login) == null)
                {
                    App.DataAccess.Add_Company(company);
                }
                else
                {
                    MessageBox.Show("Error", "Taka firma już istnieje", MessageBoxButton.OK);
                    return;
                }

            }
            else
            {
                UserData NewUserData = new UserData();
                NewUserData.Login = TxB_Login.Text;
                NewUserData.Password = HashPassword.Hash(PsB_Password_1.Password);
                NewUserData.AccountTypeID = 1;
                if (CB_Admin.IsChecked == true)
                {
                    NewUserData.AccountTypeID = 2;
                }
                if(App.DataAccess.GetUserFromLogin(NewUserData.Login) == null)
                {
                    App.DataAccess.InsertUserData(NewUserData);
                    NewUserData = App.DataAccess.GetUserFromLogin(NewUserData.Login);
                    App.DataAccess.InserUser(NewUserData);
                }
                else
                {
                    MessageBox.Show("Error", "Taki użytkownik już istnieje",MessageBoxButton.OK);
                    return;
                }
                
            }
            (new Login()).Show();
            this.Close();
        }

        private void Btn_BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            (new Login()).Show();
            this.Close();
        }
    }
}
