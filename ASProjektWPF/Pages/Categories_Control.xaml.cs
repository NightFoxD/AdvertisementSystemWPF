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
    /// Interaction logic for Categories_Control.xaml
    /// </summary>
    public partial class Categories_Control : Page
    {
        Frame currentPage;
        List<Category>? itemsCategory;
        List<PositionLevel>? itemsPositionLevel;
        List<ContractType>? itemsContractType;
        List<WorkTime>? itemsWorkTime;
        List<WorkType>? itemsWorkType;
        public Categories_Control(Frame currentPage, List<Category> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if(items == null)
            {
                itemsCategory = new List<Category>() {  };
            }
            else
            {
                itemsCategory = items;
            }
            TxtB_CategoryName.Text = "Kategorie";
            TB_Title.Text = "Nazwa kategori: ";
            Btn_AddItem.Content = "Dodaj kategorie";
            Refresh();
        }
        public Categories_Control(Frame currentPage, List<PositionLevel> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if (items == null)
            {
                itemsPositionLevel = new List<PositionLevel>() { };
            }
            else
            {
                itemsPositionLevel = items;
            }
            TxtB_CategoryName.Text = "Poziom stanowiska";
            TB_Title.Text = "Nazwa poziomu stanowiska: ";
            Btn_AddItem.Content = "Dodaj poziom stanowiska";
            Refresh();
        }
        public Categories_Control(Frame currentPage, List<ContractType> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if (items == null)
            {
                itemsContractType = new List<ContractType>() { };
            }
            else
            {
                itemsContractType = items;
            }
            TxtB_CategoryName.Text = "Rodzaj umowy";
            TB_Title.Text = "Nazwa rodzaju umowy: ";
            Btn_AddItem.Content = "Dodaj rodzaj umowy";
            Refresh();
        }
        public Categories_Control(Frame currentPage, List<WorkTime> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if (items == null)
            {
                itemsWorkTime = new List<WorkTime>() { };
            }
            else
            {
                itemsWorkTime = items;
            }
            TxtB_CategoryName.Text = "Wymiar pracy";
            TB_Title.Text = "Nazwa wymiaru pracy: ";
            Btn_AddItem.Content = "Dodaj wymiar pracy";
            Refresh();
        } 
        public Categories_Control(Frame currentPage, List<WorkType> items)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            if (items == null)
            {
                itemsWorkType = new List<WorkType>() { };
            }
            else
            {
                itemsWorkType = items;
            }
            TxtB_CategoryName.Text = "Tryb pracy";
            TB_Title.Text = "Nazwa trybu pracy: ";
            Btn_AddItem.Content = "Dodaj tryb stanowiska";
            Refresh();
        }
        public void Btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            Type itemType = ((Button)sender).CommandParameter.GetType();
            if (itemType == typeof(Category))
            {
                Category? item = ((Button)sender).CommandParameter as Category;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_Category(item);
            }
            else if (itemType == typeof(PositionLevel))
            {
                PositionLevel? item = ((Button)sender).CommandParameter as PositionLevel;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_PositionLevel(item);
            }else if (itemType == typeof(ContractType))
            {
                ContractType? item = ((Button)sender).CommandParameter as ContractType;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_ContractType(item);
            }else if (itemType == typeof(WorkTime))
            {
                WorkTime? item = ((Button)sender).CommandParameter as WorkTime;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_WorkTime(item);
            }else if (itemType == typeof(WorkType))
            {
                WorkType? item = ((Button)sender).CommandParameter as WorkType;
                if (item == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK);
                    return;
                }
                App.DataAccess.Delete_WorkType(item);
            }
            Refresh();
        }
        public void Refresh()
        {
            if(itemsCategory != null)
            {
                LV_Items.ItemsSource = App.DataAccess.GetCategoryList();
            }else if(itemsContractType != null)
            {
                LV_Items.ItemsSource = App.DataAccess.GetContractList();
            }else if(itemsPositionLevel != null)
            {
                LV_Items.ItemsSource = App.DataAccess.GetPositionLevelList();
            }else if(itemsWorkTime != null)
            {
                LV_Items.ItemsSource = App.DataAccess.GetWorkTimeList();
            }else if(itemsWorkType != null)
            {
                LV_Items.ItemsSource = App.DataAccess.GetWorkTypeList();
            }
        }
        private void Btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (itemsCategory != null)
            {
                Category newItem = new Category();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_Category(newItem);
            }
            else if (itemsContractType != null)
            {
                ContractType newItem = new ContractType();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_ContractType(newItem);
            }
            else if (itemsPositionLevel != null)
            {
                PositionLevel newItem = new PositionLevel();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_PositionLevel(newItem);
            }
            else if (itemsWorkTime != null)
            {
                WorkTime newItem = new WorkTime();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_WorkTime(newItem);
            }
            else if (itemsWorkType != null)
            {
                WorkType newItem = new WorkType();
                newItem.Name = Text_Item_Content.Text;
                App.DataAccess.Add_WorkType(newItem);
            }
            Refresh();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            currentPage.GoBack();
        }
    }
}
