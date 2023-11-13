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
        DataAccess Database = new DataAccess(Path.Combine(Directory.GetCurrentDirectory(), "AdvirtisementSystemWPF.db3"));
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
            UserData NewUserData = new UserData();
            NewUserData.Login = TxB_Login.Text;
            NewUserData.Password = PsB_Password_1.Password;
            NewUserData.AccountTypeID = 1;
            Database.InsertUserData(NewUserData);
        }
    }
}
