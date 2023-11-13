using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Saved
    {
        [PrimaryKey, AutoIncrement]
        public int SavedID { get; set; }
        public int? Company { get; set; }
        public int? User { get; set; }
    }
}
