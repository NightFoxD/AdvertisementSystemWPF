using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Classes
{
    public class Item
    {
        public string Content { get; set; }
        public Item(string content)
        {
            this.Content = content;
        }
    }
}
