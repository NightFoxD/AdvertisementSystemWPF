using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Announcment
    {
        [PrimaryKey, AutoIncrement]
        public int AnnouncmentID { get; set; }
        public int? CompanyID { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        [MaxLength(50)]
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
        public string? WorkHours { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public string? Benefits { get; set; }
    }
}
