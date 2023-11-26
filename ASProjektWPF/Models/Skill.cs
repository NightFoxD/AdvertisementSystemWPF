using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Models
{
    public class Skill
    {
        [PrimaryKey, AutoIncrement]
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public string? Name { get; set; }
    }
}
