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
        object item;
        Frame currentPage;
        public Profil_EditItem(Frame CurrentPage, object updateItem)
        {
            InitializeComponent();
            currentPage = CurrentPage;
            if(updateItem.GetType() == typeof(Experience))
            {
                item = (Experience)updateItem;
                Experience_Item.DataContext = (Experience)item;
                Experience_Item.Visibility = Visibility.Visible;
            }else if (updateItem.GetType() == typeof(Education))
            {
                item = (Education)updateItem;
                G_Education.DataContext = ((Education)item);
                G_Education.Visibility = Visibility.Visible;
            }else if(updateItem.GetType() == typeof(Language))
            {
                item = (Language)updateItem;
                G_Language.DataContext = ((Language)item);
                G_Language.Visibility = Visibility.Visible;
            }else if(updateItem.GetType() == typeof(Link))
            {
                item = (Link)updateItem;
                G_Link.DataContext = ((Link)item);
                G_Link.Visibility = Visibility.Visible;
            }
            
        }
        public void Btn_Form_Cancel_Click(object sender, EventArgs e)
        {
            currentPage.GoBack();
        }
        public void Btn_Form_Update_Click(object sender, EventArgs e)
        {
            if(item.GetType() == typeof(Experience))
            {
                ((Experience)item).Position = TxtB_Position.Text;
                ((Experience)item).Localization = TxtB_Localization.Text;
                ((Experience)item).Company = TxtB_Company.Text;
                ((Experience)item).StartPayment = DP_StartPayment.SelectedDate;
                ((Experience)item).EndPayment = DP_EndPayment.SelectedDate;
                ((Experience)item).Responsibilities = TxtB_Responsibilities.Text;
                App.DataAccess.Update_Experience((Experience)item);
            }else if (item.GetType() == typeof(Education))
            {
                ((Education)item).ShoolName = TxtB_Education_ShoolName.Text;
                ((Education)item).Level = CB_Education_Level.Text;
                ((Education)item).Direction = TxtB_Education_Direction.Text;
                ((Education)item).StartPeriod = DP_Education_StartPeriod.SelectedDate;
                ((Education)item).EndPeriod = DP_Education_EndPeriod.SelectedDate;
                App.DataAccess.Update_Education((Education)item);
            }else if(item.GetType() == typeof(Experience))
            {
                ((Language)item).Name = CB_LanguageSelected.Text;
                ((Language)item).Level = CB_LanguageLevel.Text;
                App.DataAccess.Update_Language((Language)item);
            }else if(item.GetType() == typeof(Link))
            {
                ((Link)item).Name = TxtB_URL.Text;
                ((Link)item).Type = CB_Type.Text;
                App.DataAccess.Update_Link((Link)item);
            }
            currentPage.GoBack();
        }
    }
}
