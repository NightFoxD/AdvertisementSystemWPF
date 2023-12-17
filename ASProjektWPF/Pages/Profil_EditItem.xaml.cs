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
    /// Interaction logic for Profil_EditItem.xaml
    /// </summary>
    public partial class Profil_EditItem : Page
    {
        object? Item;
        Frame currentPage;
        public Profil_EditItem(Frame CurrentPage, object updateItem)
        {
            InitializeComponent();
            currentPage = CurrentPage;
            if(updateItem.GetType() == typeof(Experience))
            {
                Item = (Experience)updateItem;
                Experience_Item.DataContext = (Experience)Item;
                Experience_Item.Visibility = Visibility.Visible;
            }else if (updateItem.GetType() == typeof(Education))
            {
                Item = (Education)updateItem;
                G_Education.DataContext = ((Education)Item);
                G_Education.Visibility = Visibility.Visible;
            }else if(updateItem.GetType() == typeof(Language))
            {
                Item = (Language)updateItem;
                G_Language.DataContext = ((Language)Item);
                G_Language.Visibility = Visibility.Visible;
            }else if(updateItem.GetType() == typeof(Link))
            {
                Item = (Link)updateItem;
                G_Link.DataContext = ((Link)Item);
                G_Link.Visibility = Visibility.Visible;
            }
            
        }
        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            currentPage.GoBack();
        }
        public void Btn_Form_Cancel_Click(object sender, EventArgs e)
        {
            currentPage.GoBack();
            return;
        }
        public void Btn_Form_Update_Click(object sender, EventArgs e)
        {
            if(Item == null)
            {
                currentPage.GoBack();
                return;
            }
            if(Item.GetType() == typeof(Experience))
            {
                ((Experience)Item).Position = TxtB_Position.Text;
                ((Experience)Item).Localization = TxtB_Localization.Text;
                ((Experience)Item).Company = TxtB_Company.Text;
                ((Experience)Item).StartPayment = DP_StartPayment.SelectedDate;
                ((Experience)Item).EndPayment = DP_EndPayment.SelectedDate;
                ((Experience)Item).Responsibilities = TxtB_Responsibilities.Text;
                App.DataAccess.Update_Experience((Experience)Item);
            }else if (Item.GetType() == typeof(Education))
            {
                ((Education)Item).ShoolName = TxtB_Education_ShoolName.Text;
                ((Education)Item).Level = CB_Education_Level.Text;
                ((Education)Item).Direction = TxtB_Education_Direction.Text;
                ((Education)Item).StartPeriod = DP_Education_StartPeriod.SelectedDate;
                ((Education)Item).EndPeriod = DP_Education_EndPeriod.SelectedDate;
                App.DataAccess.Update_Education((Education)Item);
            }else if(Item.GetType() == typeof(Experience))
            {
                ((Language)Item).Name = CB_LanguageSelected.Text;
                ((Language)Item).Level = CB_LanguageLevel.Text;
                App.DataAccess.Update_Language((Language)Item);
            }else if(Item.GetType() == typeof(Link))
            {
                ((Link)Item).Name = TxtB_URL.Text;
                ((Link)Item).Type = CB_Type.Text;
                App.DataAccess.Update_Link((Link)Item);
            }
            currentPage.GoBack();
        }
    }
}
