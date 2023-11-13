using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseID { get; set; }
        public int UserID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Organizer { get; set; }
        public DateTime? StartPeriod { get; set; }
        public DateTime? EndPeriod { get; set; }
    }
}
