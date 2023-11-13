using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using ASProjektWPF.Pages;
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

namespace ASProjektWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess Database = new DataAccess(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "AdvirtisementSystemWPF.db3"));
        UserData LoggedUserData;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string Login)
        {
            InitializeComponent();
            GetUser(Login);
            MessageBox.Show(Login);
        }
        public async void GetUser(string Login)
        {
            LoggedUserData = await Database.GetUserFromLogin(Login);
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

        private void RB_Register_Click(object sender, RoutedEventArgs e)
        {
            Page.Navigate(new Profil(Page));
        }
    }
}
