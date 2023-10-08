using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer.Utilities
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string username,string password, out byte[] userNameHash, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                userNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
            }
        }
        public static bool VerifyAdminHash(string username, string password, byte[] userNameHash, 
            byte[] passwordHash,  byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                var computedUsernameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
                for(int i=0; i < computedUsernameHash.Length; i++)
                {
                    if (computedUsernameHash[i] != userNameHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
