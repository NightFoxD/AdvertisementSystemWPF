using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int UserDataID { get; set; }
        public int? AccountTypeID { get; set; }
        [MaxLength(50)]
        public string? Login { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? Password { get; set; }
    }
}
