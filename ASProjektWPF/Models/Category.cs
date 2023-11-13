using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
