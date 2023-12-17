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
using Application = System.Windows.Application;

namespace ASProjektWPF
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserData LoginUserData;
        public Login()
        {
            InitializeComponent();
            LoginUserData = new UserData();
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
            Application.Current.Shutdown();
        }
        private void Btn_Register_Clicked(object sender, RoutedEventArgs e)
        {
            (new Register()).Show();
            this.Close();
        }

        private void Btn_Login_Clicked(object sender, RoutedEventArgs e)
        {
            if (CustomValidations.IsCorrectTextAndNumbers(TxtB_Login.Text) && CustomValidations.IsCorrectTextAndNumbers(PsB_Password.Password))
            {
                
                LoginUserData.Login = TxtB_Login.Text;
                LoginUserData.Password = HashPassword.Hash(PsB_Password.Password);
                Company? company = App.DataAccess.GetCompany(LoginUserData.Login, LoginUserData.Password);
                if (App.DataAccess.SearchUser(LoginUserData.Login, LoginUserData.Password) != null && Cb_Company.IsChecked == false)
                {
                    var MainWindow = new MainWindow(TxtB_Login.Text, true);
                    MainWindow.Show();
                    this.Close();
                }
                else if ( company!= null && Cb_Company.IsChecked == true)
                {
                    var MainWindow = new MainWindow(company, false);
                    MainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Podano błędny login lub hasło dane");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Podano błędny login lub hasło dane");
                return;
            }
            
        }
        private void Btn_GoToApp_Clicked(object sender, RoutedEventArgs e)
        {
            (new MainWindow()).Show();
            this.Close();
        }
        
    }
}
