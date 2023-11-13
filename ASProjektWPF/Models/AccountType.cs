using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class AccountType
    {
        [PrimaryKey, AutoIncrement]
        public int AccountTypeID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
