using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Classes
{
    public class CheckedItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public bool Checked { get; set; }
        public int Count { get; set; }
        public CheckedItem(string name) { Name = name; }
        public CheckedItem() {}
    }
}
