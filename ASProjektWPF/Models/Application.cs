using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Application
    {
        [PrimaryKey, AutoIncrement]
        public int ApplicationID { get; set; }
        public int? AnnouncmentID { get; set; }
        public int? UserID { get; set; }
    }
}
