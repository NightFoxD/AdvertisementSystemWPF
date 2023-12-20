using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ASProjektWPF.Classes
{
    public class ApplicationItem
    {
        public User? User { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public Announcment? Announcment { get; set; }
        public string? AnnouncmentName { get; set; }
        public string? PositionName { get; set; }
        
        public ApplicationItem(AnnouncmentItem announcmentItem, int? user)
        {
            User? User  = App.DataAccess.GetUserFromDataID(user);
            this.User = User;
            Announcment = announcmentItem.Announcment;
            if (User.Name != null)
            {
                UserName = User.Name;
            }
            if (User.Surname != null)
            {
                UserSurname = User.Surname;
            }
            if(announcmentItem.Name != null)
            {
                AnnouncmentName = announcmentItem.Name;
            }
            if (announcmentItem.PositionName != null)
            {
                PositionName = announcmentItem.PositionName;
            }
        }
    }
}
