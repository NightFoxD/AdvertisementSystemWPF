using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASProjektWPF.Classes
{
    public class HashPassword
    {
        public static string Hash(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.UTF8.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
