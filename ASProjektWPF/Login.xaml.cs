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
        DataAccess Database = new DataAccess(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "AdvirtisementSystemWPF.db3"));
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

        private void Btn_Login_Clicked(object sender, RoutedEventArgs e)
        {
            LoginUserData.Login = TxtB_Login.Text;
            LoginUserData.Password = PsB_Password.Password;
            MessageBox.Show(TxtB_Login.Text);
            if (Database.SearchUser(TxtB_Login.Text))
            {
                var MainWindow = new MainWindow(TxtB_Login.Text);
                MainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Podano niepoprawne dane");
            }
            
        }
    }
}
