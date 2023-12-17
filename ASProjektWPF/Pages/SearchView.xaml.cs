using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : Page
    {
        Frame? CurrentPage;
        UserData? user;
        string? LastCategoryClick;
        List<CheckedItem> CheckedItems_PositionLevel = new List<CheckedItem>() { };
        List<CheckedItem> CheckedItems_ContractTypes = new List<CheckedItem>() { };
        List<CheckedItem> CheckedItems_WorkTime = new List<CheckedItem>() { };
        List<CheckedItem> CheckedItems_WorkType = new List<CheckedItem>() { };
        List<CheckedItem> ListItems_PositionLevel = new List<CheckedItem>() { };
        List<CheckedItem> ListItems_ContractTypes = new List<CheckedItem>() { };
        List<CheckedItem> ListItems_WorkTime = new List<CheckedItem>() { };
        List<CheckedItem> ListItems_WorkType = new List<CheckedItem>() { };
        public SearchView(Frame? currentPage, UserData user, string searchText, string category, string location)
        {
            InitializeComponent();
            TxtB_SearchBar.Text = searchText;
            TxtB_Localization.Text = location;
            CurrentPage = currentPage;
            this.user = user;
            Initialize(category);
        }
        public SearchView(Frame? currentPage, string searchText, string category, string location)
        {
            InitializeComponent();
            TxtB_SearchBar.Text = searchText;
            TxtB_Localization.Text = location;
            CurrentPage = currentPage;
            Initialize(category);
        }
        public void Initialize(string category)
        {
            foreach (var item in App.DataAccess.GetCategoryList())
            {
                CmB_Category.Items.Add(item.Name);
            }
            CmB_Category.Text = category;
            if (IC_ItemsToChecked.Items.Count <= 0)
                BR_Items.Visibility = Visibility.Collapsed;
            else
                BR_Items.Visibility = Visibility.Visible;
            foreach (PositionLevel itemFromDatabase in App.DataAccess.GetPositionLevelList())
            {
                CheckedItem item = new CheckedItem();
                item.ID = itemFromDatabase.ID;
                item.Name = itemFromDatabase.Name;
                ListItems_PositionLevel.Add(item);
            }
            foreach (ContractType itemFromDatabase in App.DataAccess.GetContractList())
            {
                CheckedItem item = new CheckedItem();
                item.ID = itemFromDatabase.ID;
                item.Name = itemFromDatabase.Name;
                ListItems_ContractTypes.Add(item);
            }
            foreach (WorkTime itemFromDatabase in App.DataAccess.GetWorkTimeList())
            {
                CheckedItem item = new CheckedItem();
                item.ID = itemFromDatabase.ID;
                item.Name = itemFromDatabase.Name;
                ListItems_WorkTime.Add(item);
            }
            foreach (WorkType itemFromDatabase in App.DataAccess.GetWorkTypeList())
            {
                CheckedItem item = new CheckedItem();
                item.ID = itemFromDatabase.ID;
                item.Name = itemFromDatabase.Name;
                ListItems_WorkType.Add(item);
            }
            ObservableCollection<AnnouncmentItem> announcments = new ObservableCollection<AnnouncmentItem>();
            foreach (Announcment item in App.DataAccess.GetAnnouncmentList())
            {
                announcments.Add(new AnnouncmentItem(item));
            }
            announcments = Sort(announcments);
            LV_Announcments.ItemsSource = announcments;
        }
        public List<CheckedItem> GetCheckedItems()
        {
            var checkedItems = new List<CheckedItem>() { };

            foreach (CheckedItem item in IC_ItemsToChecked.Items)
            {
                if (item.Checked)
                    checkedItems.Add(item);
            }
            return checkedItems;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string? btnContent = ((Button)sender).Name;
            switch (btnContent)
            {
                case "Btn_PositionLevel":
                    LastCategoryClick = "Btn_PositionLevel";
                    CheckedItems_PositionLevel = GetCheckedItems();
                    foreach (var item in ListItems_PositionLevel)
                    {
                        if (CheckedItems_PositionLevel.Contains(item))
                        {
                            item.Checked = true;
                        }
                    }
                    IC_ItemsToChecked.ItemsSource = ListItems_PositionLevel;
                    break;
                case "Btn_ContractType":
                    LastCategoryClick = "Btn_ContractType";
                    CheckedItems_ContractTypes = GetCheckedItems();
                    foreach (var item in ListItems_ContractTypes)
                    {
                        if (CheckedItems_ContractTypes.Contains(item))
                        {
                            item.Checked = true;
                        }
                    }
                    IC_ItemsToChecked.ItemsSource = ListItems_ContractTypes;
                    break;
                case "Btn_WorkTime":
                    LastCategoryClick = "Btn_WorkTime";
                    CheckedItems_WorkTime = GetCheckedItems();
                    foreach (var item in ListItems_WorkTime)
                    {
                        if (CheckedItems_WorkTime.Contains(item))
                        {
                            item.Checked = true;
                        }
                    }
                    IC_ItemsToChecked.ItemsSource = ListItems_WorkTime;
                    break;
                case "Btn_WorkType":
                    LastCategoryClick = "Btn_WorkType";
                    CheckedItems_WorkType = GetCheckedItems();
                    foreach (var item in ListItems_WorkType)
                    {
                        if (CheckedItems_WorkType.Contains(item))
                        {
                            item.Checked = true;
                        }
                    }
                    IC_ItemsToChecked.ItemsSource = ListItems_WorkType;
                    break;
                default:
                    break;
            }
            if (IC_ItemsToChecked.Items.Count <= 0)
                BR_Items.Visibility = Visibility.Collapsed;
            else
                BR_Items.Visibility = Visibility.Visible;
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentPage != null)
            {
                CurrentPage.GoBack();
            }
        }
        private void Btn_GoToAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            AnnouncmentItem? tmpItem = ((Button)sender).CommandParameter as AnnouncmentItem;
            if (tmpItem != null)
            {
                Announcment? item = tmpItem.Announcment;
                if (item != null && user != null && CurrentPage != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, user, item));
                }
                else if (item != null && CurrentPage != null)
                {
                    CurrentPage.Navigate(new AnnouncmentPage(CurrentPage, item));
                }
            }

        }

        private void Btn_SearchButton_Click(object sender, RoutedEventArgs e)
        {
            switch (LastCategoryClick)
            {
                case "Btn_PositionLevel":

                    CheckedItems_PositionLevel = GetCheckedItems();
                    break;
                case "Btn_ContractType":

                    CheckedItems_ContractTypes = GetCheckedItems();
                    break;
                case "Btn_WorkTime":

                    CheckedItems_WorkTime = GetCheckedItems();
                    break;
                case "Btn_WorkType":
                    CheckedItems_WorkType = GetCheckedItems();
                    break;
                default:
                    break;
            }
            ObservableCollection<AnnouncmentItem> announcments = new ObservableCollection<AnnouncmentItem>();
            foreach (Announcment item in App.DataAccess.GetAnnouncmentList())
            {
                announcments.Add(new AnnouncmentItem(item));
            }
            announcments = Sort(announcments);
            LV_Announcments.ItemsSource = announcments;
        }
        public bool CheckIfItemIsInCheckedList(string items,List<CheckedItem> itemsChecked)
        {
            foreach (var item in itemsChecked)
            {
                if(item.Name == items)
                {
                    return true;
                }
            }
            return false;
        }
        public ObservableCollection<AnnouncmentItem> Sort(ObservableCollection<AnnouncmentItem> tab)
        {
            ObservableCollection<AnnouncmentItem> newList = new ObservableCollection<AnnouncmentItem>();
            foreach (var item in tab)
            {
                string? name = item.Name;
                if(name != null)
                {
                    if (name.ToLower().StartsWith(TxtB_SearchBar.Text.ToLower())|| TxtB_SearchBar.Text == "")
                    {
                        foreach (var itemChecked in item.CategoryID)
                        {
                            if(CmB_Category.Text == itemChecked.Name)
                            {
                                string? city = item.City;
                                if(city != null)
                                {
                                    if (city.ToLower() == TxtB_Localization.Text.ToLower() || TxtB_Localization.Text == "")
                                    {
                                        string? contractType = item.ContractType;
                                        string? positionLevel = item.PositionLevel;
                                        string? workType = item.WorkType;
                                        string? workTime = item.WorkingTime;
                                        if(contractType != null && positionLevel != null && workType != null && workTime != null)
                                        {
                                            if (CheckedItems_ContractTypes.Any())
                                            {
                                                if (CheckIfItemIsInCheckedList(contractType, CheckedItems_ContractTypes))
                                                {
                                                    if (CheckedItems_PositionLevel.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(positionLevel, CheckedItems_PositionLevel))
                                                        {
                                                            if (CheckedItems_WorkType.Any())
                                                            {
                                                                if (CheckIfItemIsInCheckedList(workType, CheckedItems_WorkType))
                                                                {
                                                                    if (CheckedItems_WorkTime.Any())
                                                                    {
                                                                        if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                                        {
                                                                            newList.Add(item);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        newList.Add(item);
                                                                    }
                                                                }
                                                            }
                                                            else if (CheckedItems_WorkTime.Any())
                                                            {
                                                                if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                                {
                                                                    newList.Add(item);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                newList.Add(item);
                                                            }
                                                        }
                                                    }
                                                    else if (CheckedItems_WorkType.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(workType, CheckedItems_WorkType))
                                                        {
                                                            if (CheckedItems_WorkTime.Any())
                                                            {
                                                                if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                                {
                                                                    newList.Add(item);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                newList.Add(item);
                                                            }
                                                        }
                                                    }
                                                    else if (CheckedItems_WorkTime.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                        {
                                                            newList.Add(item);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        newList.Add(item);
                                                    }
                                                }
                                            }else if (CheckedItems_PositionLevel.Any())
                                            {
                                                if (CheckIfItemIsInCheckedList(positionLevel, CheckedItems_PositionLevel))
                                                {
                                                    if (CheckedItems_WorkType.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(workType, CheckedItems_WorkType))
                                                        {
                                                            if (CheckedItems_WorkTime.Any())
                                                            {
                                                                if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                                {
                                                                    newList.Add(item);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                newList.Add(item);
                                                            }
                                                        }
                                                    }
                                                    else if (CheckedItems_WorkTime.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                        {
                                                            newList.Add(item);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        newList.Add(item);
                                                    }
                                                }
                                            }else if (CheckedItems_WorkType.Any())
                                            {
                                                if (CheckIfItemIsInCheckedList(workType, CheckedItems_WorkType))
                                                {
                                                    if (CheckedItems_WorkTime.Any())
                                                    {
                                                        if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                        {
                                                            newList.Add(item);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        newList.Add(item);
                                                    }
                                                }
                                            }else if (CheckedItems_WorkTime.Any())
                                            {
                                                if (CheckIfItemIsInCheckedList(workTime, CheckedItems_WorkTime))
                                                {
                                                    newList.Add(item);
                                                }
                                            }
                                            else
                                            {
                                                newList.Add(item);
                                                
                                            }
                                        }
                                    }
                                }
                               
                            }
                        }
                    }
                }
            }
            return newList;
        }
        
    }
}
