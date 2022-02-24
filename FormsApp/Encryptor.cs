
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FormsApp
{
    /// <summary>
    /// Ecryptor
    /// </summary>
    public static class Encryptor
    {
        //22
        #region MD5
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="clearText">Clear text</param>
        /// <returns>MD5 value</returns>
        public static string MD5(string clearText)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] input = Encoding.Default.GetBytes(clearText);
                byte[] output = md5.ComputeHash(input);
                return BitConverter.ToString(output).Replace("-", "");
            }
            catch(Exception ex)
            {
               
                return string.Empty;
            }
        }
        #endregion
    }
}
