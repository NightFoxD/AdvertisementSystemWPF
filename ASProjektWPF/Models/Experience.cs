using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Experience
    {
        [PrimaryKey, AutoIncrement]
        public int ExperienceID { get; set; }
        public int UserID { get; set; }
        [MaxLength(75)]
        public string? Position { get; set; }
        [MaxLength(50)]
        public string? Company { get; set; }
        [MaxLength(35)]
        public string? Localization { get; set; }
        public DateTime? StartPayment { get; set; }
        public DateTime? EndPayment { get; set; }
        public string? Responsibilities { get; set; }
    }
}
