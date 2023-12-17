using ASProjektWPF.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ASProjektWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static DataAccess? Database;
        
        public static DataAccess DataAccess
        {
            get
            {
                if (Database == null)
                {
                    Database = new DataAccess(Path.Combine(Directory.GetCurrentDirectory(), "AdvertisementSystem_WPF.db3"));
                }
                return Database;
            }
        }
    }
}
