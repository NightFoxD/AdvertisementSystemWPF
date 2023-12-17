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
using System.Windows.Threading;

namespace ASProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for Announcment_AddEdit.xaml
    /// </summary>
    
    public partial class Announcment_AddEdit : Page
    {
        Company Company;
        ObservableCollection<Item> itemsResponsibilities = new ObservableCollection<Item>();
        ObservableCollection<Item> itemsBenefits = new ObservableCollection<Item>();
        ObservableCollection<Item> itemsRequirements = new ObservableCollection<Item>();
        List<CheckedItem> itemsCategory = new List<CheckedItem>();
        Announcment? addEditAnnouncment;
        Frame currentPage;
        public Announcment_AddEdit(Frame currentPage, Company company)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            Company = company;
            foreach (var item in App.DataAccess.GetPositionLevelList())
            {
                CmB_PositionLevel.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetContractList())
            {
                CmB_ContractType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTypeList())
            {
                CmB_WorkType.Items.Add(item.Name);
            }
            foreach (var item in App.DataAccess.GetWorkTimeList())
            {
                CmB_WorkTime.Items.Add(item.Name);
            }
            foreach (Category category in App.DataAccess.GetCategoryList())
            {
                CheckedItem item = new CheckedItem();
                if (category.Name != null)
                {
                    item.Name = category.Name;
                    item.ID = category.CategoryID;
                }
                itemsCategory.Add(item);
            }
            IC_ItemsToChecked.ItemsSource = itemsCategory;
            Btn_AddUpdateAnnouncment.Content = "Dodaj ogłoszenie";
            
        }
        public Announcment_AddEdit(Frame currentPage, Announcment announcment, Company company)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            Company = company;
            addEditAnnouncment = announcment;
            TxtB_Name.Text = announcment.Name;
            TxtB_PositionName.Text = announcment.PositionName;
            foreach (var item in App.DataAccess.GetPositionLevelList())
            {
                CmB_PositionLevel.Items.Add(item.Name);
                if(announcment.PositionLevel == item.Name)
                {
                    CmB_PositionLevel.SelectedIndex = CmB_PositionLevel.Items.Count;
                }
            }
            foreach (var item in App.DataAccess.GetContractList())
            {
                CmB_ContractType.Items.Add(item.Name);
                if (announcment.ContractType == item.Name)
                {
                    CmB_ContractType.SelectedIndex = CmB_ContractType.Items.Count;
                }
            }
            foreach (var item in App.DataAccess.GetWorkTypeList())
            {
                CmB_WorkType.Items.Add(item.Name);
                if (announcment.WorkType == item.Name)
                {
                    CmB_WorkType.SelectedIndex = CmB_WorkType.Items.Count;
                }
            }
            foreach (var item in App.DataAccess.GetWorkTimeList())
            {
                CmB_WorkTime.Items.Add(item.Name);
                if (announcment.WorkingTime == item.Name)
                {
                    CmB_WorkTime.SelectedIndex = CmB_WorkTime.Items.Count;
                }
            }
            int[] selectedCategories = { };
            if (announcment.CategoryID!= null && announcment.CategoryID !="")
            {
                selectedCategories = announcment.CategoryID.Split(";").Select(int.Parse).ToArray();
            }
            foreach (Category category in App.DataAccess.GetCategoryList())
            {
                CheckedItem item = new CheckedItem();
                if (category.Name != null)
                {
                    item.Name = category.Name;
                    item.ID = category.CategoryID;
                    if (selectedCategories.Contains(category.CategoryID))
                    {
                        item.Checked = true;
                    }
                }
                itemsCategory.Add(item);
            }
            string[] announcmentRequirements = { };
            if (announcment.Requirements != null && announcment.Requirements!= "")
            {
                announcmentRequirements = announcment.Requirements.Split(";");
                foreach (var item in announcmentRequirements)
                {
                    itemsRequirements.Add(new Item(item));
                }
            }
            
            LV_Requirements.ItemsSource = itemsRequirements;
            string[] announcmentResponsibilities = { };
            if (announcment.Responsibilities != null && announcment.Responsibilities != "")
            {
                announcmentResponsibilities = announcment.Responsibilities.Split(";");
                foreach (var item in announcmentResponsibilities)
                {
                    itemsResponsibilities.Add(new Item(item));
                }
            }
            
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
            string[] announcmentBenefits = { };
            if (announcment.Benefits != null && announcment.Benefits != "")
            {
                announcmentBenefits = announcment.Benefits.Split(";");
                foreach (var item in announcmentBenefits)
                {
                    itemsBenefits.Add(new Item(item));
                }
            }
            
            LV_Benefits.ItemsSource = itemsBenefits;
            IC_ItemsToChecked.ItemsSource = itemsCategory;
            TxtB_Description.Text = announcment.Description;
            TxtB_City.Text = announcment.City;
            DP_EndDate.SelectedDate = announcment.EndDate;
            Btn_AddUpdateAnnouncment.Content = "Edytuj ogłoszenie";
        }
        public void Refresh()
        {
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
            LV_Requirements.ItemsSource = itemsRequirements;
            LV_Benefits.ItemsSource = itemsBenefits;
        }
        private void Btn_AddUpdateAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            if(addEditAnnouncment == null)
            {
                addEditAnnouncment = new Announcment();
                addEditAnnouncment.CompanyID = Company.CompanyID;
                addEditAnnouncment.Name = TxtB_Name.Text;
                addEditAnnouncment.Description = TxtB_Description.Text;
                addEditAnnouncment.CategoryID = string.Join(";", GetCheckedCategories().Select(items => items.ID));
                addEditAnnouncment.PositionName = TxtB_PositionName.Text;
                addEditAnnouncment.PositionLevel = CmB_PositionLevel.Text;
                addEditAnnouncment.ContractType = CmB_ContractType.Text;
                addEditAnnouncment.WorkType = CmB_WorkTime.Text;
                addEditAnnouncment.WorkingTime = CmB_WorkTime.Text;
                addEditAnnouncment.Requirements = string.Join(";", itemsRequirements.Select(item=>item.Content));
                addEditAnnouncment.Benefits = string.Join(";", itemsBenefits.Select(item=>item.Content));
                addEditAnnouncment.Responsibilities = string.Join(";", itemsResponsibilities.Select(item=>item.Content));
                addEditAnnouncment.StartDate = DateTime.Now;
                addEditAnnouncment.EndDate = DP_EndDate.SelectedDate;
                addEditAnnouncment.City = TxtB_City.Text;
                App.DataAccess.Add_Announcment(addEditAnnouncment);
                currentPage.GoBack();
            }
            else
            {
                addEditAnnouncment.Name = TxtB_Name.Text;
                addEditAnnouncment.Description = TxtB_Description.Text;
                addEditAnnouncment.CategoryID = string.Join(";", GetCheckedCategories().Select(items => items.ID));
                addEditAnnouncment.PositionName = TxtB_PositionName.Text;
                addEditAnnouncment.PositionLevel = CmB_PositionLevel.Text;
                addEditAnnouncment.ContractType = CmB_ContractType.Text;
                addEditAnnouncment.WorkType = CmB_WorkTime.Text;
                addEditAnnouncment.WorkingTime = CmB_WorkTime.Text;
                addEditAnnouncment.Requirements = string.Join(";", itemsRequirements.Select(item => item.Content));
                addEditAnnouncment.Benefits = string.Join(";", itemsBenefits.Select(item => item.Content));
                addEditAnnouncment.Responsibilities = string.Join(";", itemsResponsibilities.Select(item => item.Content));
                addEditAnnouncment.StartDate = DateTime.Now;
                addEditAnnouncment.EndDate = DP_EndDate.SelectedDate;
                addEditAnnouncment.City = TxtB_City.Text;
                App.DataAccess.Update_Announcment(addEditAnnouncment);
                currentPage.GoBack();
            }
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            currentPage.GoBack();
        }

        private void Btn_AddResponsibleItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item(TxtB_Responsibility_Content.Text);
            itemsResponsibilities.Add(item);
            TxtB_Responsibility_Content.Text = "";
            Refresh();
        }
        private void Btn_DeleteItemResponsibility_Click(object sender, RoutedEventArgs e)
        {
            Item? delItem = ((Button)sender).CommandParameter as Item;
            if (delItem != null)
            {
                itemsResponsibilities.Remove(delItem);
            }
            Refresh();
        }

        private void Btn_DeleteItemBenefit_Click(object sender, RoutedEventArgs e)
        {
            Item? delItem = ((Button)sender).CommandParameter as Item;
            if (delItem != null)
            {
                itemsBenefits.Remove(delItem);
            }
            Refresh();
        }

        private void Btn_DeleteItemRequirement_Click(object sender, RoutedEventArgs e)
        {
            Item? delItem = ((Button)sender).CommandParameter as Item;
            if (delItem != null)
            {
                itemsRequirements.Remove(delItem);
            }
            Refresh();
        }

        private void Btn_AddRequirementItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item(TxtB_Requirement_Content.Text);
            itemsRequirements.Add(item);
            TxtB_Requirement_Content.Text = "";
            Refresh();
        }

        private void Btn_AddBenefitItem_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item(TxtB_Benefit_Content.Text);
            itemsBenefits.Add(item);
            TxtB_Benefit_Content.Text = "";
            Refresh();
        }
        public List<CheckedItem> GetCheckedCategories()
        {
            var checkedItems = new List<CheckedItem>() { };

            foreach (CheckedItem item in IC_ItemsToChecked.Items)
            {
                if (item.Checked)
                    checkedItems.Add(item);
            }
            return checkedItems;
        }
    }
}
