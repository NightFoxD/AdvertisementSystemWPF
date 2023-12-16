using ASProjektWPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ASProjektWPF.Classes
{
    public static class PictureControl
    {
        private static Picture Picture = new Picture();
        public static string path = "../../../Images/Uploads/";
        public static Picture GetPicture()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif";
            if (file.ShowDialog() == true)
            {
                GetPictureInformation(file.FileName);
                
                if (!File.Exists(path + Picture.Name + Picture.PictureFormat))
                {
                    Picture.Image.Save(path + Picture.Name + Picture.PictureFormat);
                }
            }
            return Picture;
        }
        public static void GetPictureInformation(string FileName)
        {
            Picture.Source = new BitmapImage(new Uri(FileName));
            Picture.Name = Path.GetFileNameWithoutExtension(FileName);
            Picture.PictureFormat = Path.GetExtension(FileName);
            Picture.Image = System.Drawing.Image.FromFile(FileName);
        }
    }
}
