using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
namespace ASProjektWPF.Classes
{
    public class Picture
    {
        public string? Name { get; set; }
        public ImageSource? Source { get; set; }
        public string? PictureFormat { get; set; }
        public Image? Image { get; set; }
    }
}
