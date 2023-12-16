using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ASProjektWPF.Classes
{
    public class AnnouncmentItem
    {
        public int AnnouncmentID { get; set; }
        public Announcment? Announcment { get; set; }
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public ImageSource? CompanyImage { get; set; }
        public Company? Company { get; set; }
        public List<CheckedItem> CategoryID = new List<CheckedItem>() { };
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PositionName { get; set; }
        public string? PositionLevel { get; set; }
        public List<Item> ContractType = new List<Item> { };
        public List<Item> WorkingTime = new List<Item> { };
        public List<Item> WorkType = new List<Item> { };
        public DateTime? EndDate { get; set; }
        public List<Item> Responsibilities = new List<Item> { };
        public List<Item> Requirements = new List<Item> { };
        public List<Item> Benefits = new List<Item> { };
        public string? City { get; set; }
        public AnnouncmentItem() { }
        public AnnouncmentItem(Announcment item)
        {
            AnnouncmentID = item.AnnouncmentID;
            Announcment = item;
            CompanyID = item.CompanyID;
            int[] selectedCategories = { };
            if (item.CategoryID != null)
            {
                selectedCategories = item.CategoryID.Split(";").Select(int.Parse).ToArray();
            }
            foreach (Category category in App.DataAccess.GetCategoryList())
            {
                CheckedItem itemCheckedItem = new CheckedItem();
                if (category.Name != null)
                {
                    if (selectedCategories.Contains(category.CategoryID))
                    {
                        itemCheckedItem.Name = category.Name;
                        itemCheckedItem.ID = category.CategoryID;
                        itemCheckedItem.Checked = true;
                    }
                }
                CategoryID.Add(itemCheckedItem);
            }
            Name = item.Name;
            Description = item.Description;
            PositionName = item.PositionName;
            PositionLevel = item.PositionLevel;
            string[] table = { };
            if (item.Requirements != null)
            {
                table = item.Requirements.Split(";");
            }
            foreach (var itemRequirement in table)
            {
                ContractType.Add(new Item(itemRequirement));
            }
            if (item.WorkingTime != null)
            {
                table = item.WorkingTime.Split(";");
            }
            foreach (var itemWorkingTime in table)
            {
                WorkingTime.Add(new Item(itemWorkingTime));
            }
            if (item.WorkType != null)
            {
                table = item.WorkType.Split(";");
            }
            foreach (var itemWorkType in table)
            {
                WorkType.Add(new Item(itemWorkType));
            }
            EndDate = item.EndDate;
            if (item.Responsibilities != null)
            {
                table = item.Responsibilities.Split(";");
            }
            foreach (var itemResponsibility in table)
            {
                Responsibilities.Add(new Item(itemResponsibility));
            }
            if (item.Requirements != null)
            {
                table = item.Requirements.Split(";");
            }
            foreach (var itemRequirement in table)
            {
                Requirements.Add(new Item(itemRequirement));
            }
            if (item.Benefits != null)
            {
                table = item.Benefits.Split(";");
            }
            foreach (var itemBenefit in table)
            {
                Benefits.Add(new Item(itemBenefit));
            }
            City = item.City;
            CompanyName = App.DataAccess.GetCompanyFromID(item.CompanyID).Name;
            Company = App.DataAccess.GetCompanyFromID(item.CompanyID);
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri("../../../Images/Uploads/Company"+ App.DataAccess.GetCompanyFromID(item.CompanyID).CompanyImage, UriKind.Relative);
                bitmapImage.EndInit();
                CompanyImage = bitmapImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error", "Wystapił błąd: " + ex);
                CompanyImage = null;
            }
            
        }
    }
}
