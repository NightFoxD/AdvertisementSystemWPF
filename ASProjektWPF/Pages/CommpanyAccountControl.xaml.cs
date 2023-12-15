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
        public CommpanyAccountControl(Frame currentPage)
        {
            InitializeComponent();
            this.currentPage = currentPage;
        }

        private void Btn_AddCategory_Click(object sender, RoutedEventArgs e)
        {
            List<Category> itemlist = App.DataAccess.GetCategoryList();
            currentPage.Navigate(new Categories_Control(currentPage, itemlist));
        }
        private void Btn_AddPositionLevel_Click(object sender, RoutedEventArgs e)
        {
            List<PositionLevel> itemlist = App.DataAccess.GetPositionLevelList();
            currentPage.Navigate(new Categories_Control(currentPage, itemlist));
        }
        private void Btn_AddContractType_Click(object sender, RoutedEventArgs e)
        {
            List<ContractType> itemlist = App.DataAccess.GetContractList();
            currentPage.Navigate(new Categories_Control(currentPage, itemlist));
        }
        private void Btn_AddWorkTime_Click(object sender, RoutedEventArgs e)
        {
            List<WorkTime> itemlist = App.DataAccess.GetWorkTimeList();
            currentPage.Navigate(new Categories_Control(currentPage, itemlist));
        }
        private void Btn_AddWorkType_Click(object sender, RoutedEventArgs e)
        {
            List<WorkType> itemlist = App.DataAccess.GetWorkTypeList();
            currentPage.Navigate(new Categories_Control(currentPage, itemlist));
        }        
        private void Btn_AddAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            currentPage.Navigate(new Announcment_AddEdit(currentPage));
        }
    }
}
