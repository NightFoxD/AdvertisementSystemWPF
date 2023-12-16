using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ASProjektWPF.Models
{
    public class Announcment
    {
        [PrimaryKey, AutoIncrement]
        public int AnnouncmentID { get; set; }
        public int CompanyID { get; set; }
        public string? CategoryID { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        public string? PositionName { get; set; }
        [MaxLength(50)]
        public string? PositionLevel { get; set; }
        [MaxLength(50)]
        public string? ContractType { get; set; }
        [MaxLength(50)]
        public string? WorkingTime { get; set; }
        [MaxLength(50)]
        public string? WorkType { get; set; }
        [MaxLength(50)]
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public string? Benefits { get; set; }
        public string? City { get; set; }
    }
}
