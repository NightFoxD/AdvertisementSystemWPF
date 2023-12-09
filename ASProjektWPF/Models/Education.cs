using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Education
    {
        [PrimaryKey, AutoIncrement]
        public int EducationID { get; set; }
        public int UserID { get; set; }
        [MaxLength(50)]
        public string? ShoolName { get; set; }
        [MaxLength(50)]
        public string? Level { get; set; }
        [MaxLength(75)]
        public string? Direction { get; set; }
        public DateTime? StartPeriod { get; set; }
        public DateTime? EndPeriod { get; set; }

    }
}
