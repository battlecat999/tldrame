using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace k_loger
{
    public class MD5
    {
        public string GetMd5Hash(string input)
        {
            StringBuilder PasConMd5 = new StringBuilder();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            byte[] bytValue;
            byte[] bytHash;
            int i;

            bytValue = System.Text.Encoding.UTF8.GetBytes(input);
            bytHash = md5.ComputeHash(bytValue);
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (i = 0; i < bytHash.Length; i++)
            {
                PasConMd5.Append(bytHash[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return PasConMd5.ToString();
        }
    }
}