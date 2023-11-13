using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int LanguageID { get; set; }
        public int? UserID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Level { get; set; }
    }
}
