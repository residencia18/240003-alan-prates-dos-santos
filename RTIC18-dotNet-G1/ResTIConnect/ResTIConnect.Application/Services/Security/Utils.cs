using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ResTIConnect.Application.Services.Security
{
    public static class Utils
    {
        
      public static string HashPassword(string password)
      {
         using (var sha256 = SHA256.Create())
         {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hash;
         }
      }

      public static bool VerifyPassword(string password, string hash)
      {
         return HashPassword(password) == hash;
      }
    }
}