using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Decision.Util
{
    public static class Crypto
    {
        public static string EncryptString(string inputString)
        {
            //**********************
            //* Trata retorno vazio
            //**********************
            if (inputString.Trim() == string.Empty)
                return string.Empty;

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
            catch
            {
                return inputString;
            }
            return Convert.ToBase64String(memStream.ToArray());
        }
        public static string DecryptString(string inputString)
        {
            //**********************
            //* Trata retorno vazio
            //**********************
            if (inputString.Trim() == string.Empty)
                return string.Empty;

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
            catch
            {
                return inputString;
            }

            Encoding encoding1 = Encoding.UTF8;
            return encoding1.GetString(memStream.ToArray());
        }
        public static string UpdatePwd(string OldPassword)
        {
            //**************
            //* Declarações
            //**************
            string OldPasswordOpened = string.Empty;
            string OldPasswordNormal = string.Empty;
            string[] OldPasswordBytes = {};

            //*************************************
            //* Desinverte texto da senha original
            //*************************************
            for (Int32 Posicao = OldPassword.Length - 1; Posicao >= 0; Posicao--)
                OldPasswordNormal += OldPassword.Substring(Posicao,1);

            //*****************************************************
            //* Separa códigos de caracteres e monta senha correta
            //*****************************************************
            for (Int32 Posicao = 0; Posicao < OldPasswordNormal.Length; Posicao += 3)
                OldPasswordOpened += Convert.ToChar(Convert.ToByte(OldPasswordNormal.Substring(Posicao,3)));

            //***************************
            //* Devolve senha encriptada
            //***************************
            return EncryptString(OldPasswordOpened);
        }
    }
}