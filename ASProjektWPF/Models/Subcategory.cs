using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class SubCategory
    {
        [PrimaryKey, AutoIncrement]
        public int SubCategoryID { get; set; }
        public int? Category { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
