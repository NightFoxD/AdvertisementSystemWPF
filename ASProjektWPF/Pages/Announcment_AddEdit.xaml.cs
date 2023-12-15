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
    /// Interaction logic for Announcment_AddEdit.xaml
    /// </summary>
    
    public partial class Announcment_AddEdit : Page
    {
        class Item
        {
            public string Content { get; set; }
            public Item(string content)
            {
                this.Content = content;
            }
        }
        List<Item> itemsResponsibilities = new List<Item>() { };
        Announcment? addEditAnnouncment;
        Frame currentPage;
        public Announcment_AddEdit(Frame currentPage)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            Btn_AddUpdateAnnouncment.Content = "Dodaj ogłoszenie";
            foreach(var item in App.DataAccess.GetPositionLevelList())
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
        }
        public Announcment_AddEdit(Frame currentPage, Announcment announcment)
        {
            InitializeComponent();
            this.currentPage = currentPage;
            addEditAnnouncment = announcment;
            Btn_AddUpdateAnnouncment.Content = "Edytuj ogłoszenie";
        }
        public void Refresh()
        {
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
        }
        private void Btn_AddUpdateAnnouncment_Click(object sender, RoutedEventArgs e)
        {
            if(addEditAnnouncment == null)
            {
                addEditAnnouncment = new Announcment();
                App.DataAccess.Add_Announcment(addEditAnnouncment);
                currentPage.GoBack();
            }
            else
            {
                App.DataAccess.Update_Announcment(addEditAnnouncment);
                currentPage.GoBack();
            }
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            currentPage.GoBack();
        }

        private void Btn_AddResponsible_Click(object sender, RoutedEventArgs e)
        {
            itemsResponsibilities.Add(new Item(TxtB_Responsibility_Content.Text));
            TxtB_Responsibility_Content.Text = "";
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
        }
        private void Btn_DeleteItemResponsibiliti_Click(object sender, RoutedEventArgs e)
        {
            Item? delItem = ((Button)sender).CommandParameter as Item;
            if (delItem != null)
            {
                itemsResponsibilities.Remove(delItem);
            }
            LV_Responsibilities.ItemsSource = itemsResponsibilities;
        }
    }
}
