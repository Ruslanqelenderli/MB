using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.PasswordHasher
{
    public class Hasher
    {
        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray=Encoding.Default.GetBytes(password); 
            var hashedPassword=sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
