using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ASProjektWPF.Classes
{
    public class AnnouncmentItem
    {
        public int AnnouncmentID { get; set; }
        public int? CompanyID { get; set; }
        public int? CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string? Name { get; set; }
        public ImageSource? PfpSource { get; set; }
        public string? PositionName { get; set; }
        public string? PositionLevel { get; set; }
        public string? ContractType { get; set; }
        public string? WorkingTime { get; set; }
        public string? WorkType { get; set; }
        public string? WorkHours { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Responsibilities { get; set; }
        public string? Requirements { get; set; }
        public string? Benefits { get; set; }
        public string? City { get; set; }
    }
}
