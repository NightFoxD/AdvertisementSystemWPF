using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public int UserDataID { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        [MaxLength(9)]
        public int TelephoneNumber { get; set; }
        public string? Pfp { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(50)]
        public string? CurrentOccupation { get; set; }
        public string? Summary { get; set; }

    }
}
