using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int CompanyID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(100)]
        public string? Adress { get; set; }
        public string? LocalizationLink { get; set; }
        public string? Description { get; set; }
    }
}
