using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public string? ContractType { get; set; }
        public string? WorkingTime { get; set; }
        public string? WorkType { get; set; }
        public DateTime? StartDate { get; set; }
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
            if (item.CategoryID != null && item.CategoryID != "")
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
            ContractType = item.ContractType;
            
            WorkingTime = item.WorkingTime;
            WorkType = item.WorkType;
           
            EndDate = item.EndDate;
            if (item.Responsibilities != null && item.Responsibilities !="")
            {
                table = item.Responsibilities.Split(";");
                foreach (var itemResponsibility in table)
                {
                    Responsibilities.Add(new Item(itemResponsibility));
                }
            }
            if (item.Requirements != null && item.Requirements != "")
            {
                table = item.Requirements.Split(";");
                foreach (var itemResponsibility in table)
                {
                    Requirements.Add(new Item(itemResponsibility));
                }
            }
            if (item.Benefits != null && item.Benefits !="")
            {
                table = item.Benefits.Split(";");
                foreach (var itemBenefit in table)
                {
                    Benefits.Add(new Item(itemBenefit));
                }
            }
            
            City = item.City;
            CompanyName = App.DataAccess.GetCompanyFromID(item.CompanyID).Name;
            Company = App.DataAccess.GetCompanyFromID(item.CompanyID);
            ImageSource? pfp;

            if (Company.CompanyImage == null)
            {
                pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultCompany.png") as ImageSource;
            }
            else
            {
                if (!File.Exists("../../../Images/Uploads/" + Company.CompanyImage))
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/App/DefaultCompany.png") as ImageSource;
                }
                else
                {
                    pfp = new ImageSourceConverter().ConvertFromString("../../../Images/Uploads/" + Company.CompanyImage) as ImageSource;
                }

            }
            CompanyImage = pfp;

        }
    }
}
