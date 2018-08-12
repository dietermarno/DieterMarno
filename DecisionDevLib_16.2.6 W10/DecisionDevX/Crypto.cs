using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Decision.Library
{
    public static class Crypto
    {
        public static string EncryptString(string inputString)
        {
            //*********************************************************
            //* Utiliza procedimento de encrypatação do .NET Framework
            //*********************************************************
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = Encoding.UTF8.GetBytes(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateEncryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Convert.ToBase64String(memStream.ToArray());
        }

        public static string DecryptString(string inputString)
        {
            //************************************************************
            //* Utiliza procedimento de desencrypatação do .NET Framework
            //************************************************************
            MemoryStream memStream = null;
            try
            {
                byte[] key = { };
                byte[] IV = { 12, 21, 43, 17, 57, 35, 67, 27 };
                string encryptKey = "aXb2uy4z"; // MUST be 8 characters
                key = Encoding.UTF8.GetBytes(encryptKey);
                byte[] byteInput = new byte[inputString.Length];
                byteInput = Convert.FromBase64String(inputString);
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                memStream = new MemoryStream();
                ICryptoTransform transform = provider.CreateDecryptor(key, IV);
                CryptoStream cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cryptoStream.Write(byteInput, 0, byteInput.Length);
                cryptoStream.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                 return ex.Message;
            }

            Encoding encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }
    }
}