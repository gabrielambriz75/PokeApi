using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Infrastructure
{
    public class Criptography
    {
        public static bool ValidacionPassword(string password,byte[] HashPassword,byte[] SaltPass)
        {
            using(var hmac =new System.Security.Cryptography.HMACSHA512(SaltPass))
            {
                var Computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < Computed.Length; i++)
                {
                    if (Computed[i] != HashPassword[i]) return false;
                }
            }
            return true;
        }

        public static void CrearPasswordEncriptado(string password,out byte[]HashPassword,out byte[] SaltPass)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                SaltPass = hmac.Key;
                HashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }



    }
}
