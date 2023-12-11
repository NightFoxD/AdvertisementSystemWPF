using ASProjektWPF.Classes;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Frame page;
        List<CheckedItem> checkedItems_PositionLevel = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_ContractTypes = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_WorkTime = new List<CheckedItem>() { };
        List<CheckedItem> checkedItems_WorkType = new List<CheckedItem>() { };
        List<CheckedItem> workTypes = new List<CheckedItem>
        {
            new CheckedItem { Checked = true, Name = "Kierownik/Koordynator",Count = 10},
            new CheckedItem { Checked = false, Name = "2",Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
            new CheckedItem { Checked = true, Name = "3", Count = 10},
        };
        List<AnnouncmentItem> list = new List<AnnouncmentItem>()
        {
            new AnnouncmentItem{ PositionName = "1",  Name = "1", City = "city" },
            new AnnouncmentItem{ PositionName = "2", Name = "2", City = "city" },
            new AnnouncmentItem{ PositionName = "3", Name = "3", City = "city" },
            new AnnouncmentItem{ PositionName = "4", Name = "4", City = "city" },
            new AnnouncmentItem{ PositionName = "5", Name = "5", City = "city" },
            new AnnouncmentItem{ PositionName = "6", Name = "6", City = "city" },
            new AnnouncmentItem{ PositionName = "7", Name = "7", City = "city" },
            new AnnouncmentItem{ PositionName = "8", Name = "8", City = "city" },
            new AnnouncmentItem{ PositionName = "9", Name = "9", City = "city" },
            new AnnouncmentItem{ PositionName = "10", Name = "0", City = "city" },
            new AnnouncmentItem{ PositionName = "11", Name = "11", City = "city" },
        };
        List<AnnouncmentItem> list2 = new List<AnnouncmentItem>()
        {
            new AnnouncmentItem{ PositionName = "name1",  Name = "asdf", City = "city" },
           new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
        };
        List<AnnouncmentItem> list3 = new List<AnnouncmentItem>()
        {
            new AnnouncmentItem{ PositionName = "name1",  Name = "asdf", City = "city" },
            new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
            new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
        };
        List<AnnouncmentItem> list4 = new List<AnnouncmentItem>()
        {
            new AnnouncmentItem{ PositionName = "name1",  Name = "asdf", City = "city" },
            new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
            new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
            new AnnouncmentItem{ PositionName = "name1", Name = "asdf", City = "city" },
        };
        public Home(Frame CurrentPage)
        {
            InitializeComponent();
            page = CurrentPage;
            Announcments.ItemsSource = list;
            sadf.ItemsSource = list;
        }
        public List<CheckedItem> GetCheckedTypeWork()
        {
            var checkedItems = new List<CheckedItem>() { };

            foreach (CheckedItem item in IC_ItemsToChecked.Items)
            {
                if(item.Checked)
                checkedItems.Add(item as CheckedItem);
            }
            return checkedItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = checkedItems_WorkType;
            string? btnContent = ((Button)sender).Name;
            switch (btnContent)
            {
                case "Btn_PositionLevel":
                    checkedItems_PositionLevel = GetCheckedTypeWork();
                    list = checkedItems_PositionLevel;
                    IC_ItemsToChecked.ItemsSource = workTypes;
                    break;
                case "Btn_ContractType":
                    checkedItems_ContractTypes = GetCheckedTypeWork();
                    list = checkedItems_ContractTypes;
                    IC_ItemsToChecked.ItemsSource = list2;
                    break;
                case "Btn_WorkTime":
                    checkedItems_WorkTime = GetCheckedTypeWork();
                    list = checkedItems_WorkTime;
                    IC_ItemsToChecked.ItemsSource = list3;
                    break;
                case "Btn_WorkType":
                    checkedItems_WorkType = GetCheckedTypeWork();
                    list = checkedItems_WorkType;
                    IC_ItemsToChecked.ItemsSource = list4;
                    break;
                default:
                    checkedItems_WorkType = GetCheckedTypeWork();
                    list = checkedItems_WorkType;
                    IC_ItemsToChecked.ItemsSource = workTypes;
                    break;
            }
            string txt = "";
            foreach(CheckedItem item in list)
            {
                txt += item.Name;
            }
            MessageBox.Show("error",txt,MessageBoxButton.OK);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = list2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Announcments.ItemsSource = list3;
        }
        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            // Przewijamy w lewo
            double scrollAmount = 410;
            imageScrollView.ScrollToHorizontalOffset(imageScrollView.HorizontalOffset - scrollAmount);
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            double scrollAmount = 410;
            imageScrollView.ScrollToHorizontalOffset(imageScrollView.HorizontalOffset + scrollAmount);
        }
    }
}
