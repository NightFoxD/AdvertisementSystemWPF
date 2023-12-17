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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for CommpanyAccountControl.xaml
    /// </summary>
    public partial class CommpanyAccountControl : Page
    {
        Frame currentPage;
        Company Company;
        public CommpanyAccountControl(Frame currentPage,Company company)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            Company = company;
        }
        private void Btn_AddAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            currentPage.Navigate(new Announcment_AddEdit(currentPage,Company));
        }        
        private void Btn_EditAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            Announcment? announcment = ((Button)sender).CommandParameter as Announcment;
            currentPage.Navigate(new CompanyAnnouncmentView(currentPage,Company));
        }
    }
}
