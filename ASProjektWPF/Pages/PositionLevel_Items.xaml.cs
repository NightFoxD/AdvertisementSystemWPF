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
    /// Interaction logic for PositionLevel_Items.xaml
    /// </summary>
    public partial class PositionLevel_Items : Page
    {
        Frame currentPage;
        List<object>? items;
        public PositionLevel_Items(Frame currentPage, List<object> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if(items.GetType() == typeof(List<Category>))
            {
                this.items = items;
                TB_Title.Text = "Nazwa poziomu stanowiska: ";
                Btn_AddItem.Content = "Dodaj poziom stanowiska";
            }
            Refresh();
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            currentPage.GoBack();
        }

        public void Btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).CommandParameter.GetType() == typeof(Category))
            {
                Category? item = ((Button)sender).CommandParameter as Category;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_Category(item);
            }
        }
        public void Refresh()
        {
            if (items == null)
            {
                return;
            }
            if (items.GetType() == typeof(List<Category>))
            {
                LV_Items.ItemsSource = App.DataAccess.GetCategoryList();
            }
        }
        private void Btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (items == null)
            {
                return;
            }
            if (items.GetType() == typeof(List<Category>))
            {
                Category newItem = new Category();
                newItem.Name = TB_Title.Text;
                App.DataAccess.Add_Category(newItem);
            }
            Refresh();
        }
    }
}
