using System.Linq;
using System.Text;
using System;
using System.Reflection;
using System.ComponentModel;
using System.Net.Mail;

namespace Decision.Extensions
{
    public static class ByteExtensios
    {
        public static string ToHexString(this byte[] hex)
        {
            if (hex == null) return "null";
            if (hex.Length == 0) return string.Empty;

            var s = new StringBuilder();
            foreach (byte b in hex)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
    }
    public static class NumericExtensions
    {
        public static string ToDBNumeric(this double dblValue, int Decimals)
        {
            return dblValue.ToString("F" + Decimals).Replace(",", ".");
        }
    }
    public static class DateExtensions
    {
        public static string ToDBDate(this DateTime? dteValue)
        {
            if (dteValue == null)
                return "null";
            else
                return "'" + dteValue.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }
    }
    public static class StringExtensions
    {
        public static bool IsBase64(this string base64String)
        {
            // Credit: oybek http://stackoverflow.com/users/794764/oybek
            if (base64String == null || base64String.Length == 0 || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {
                // Handle the exception
            }
            return false;
        }
        public static string GetNumeric(this string strValue)
        {
            //***********************************
            //* Para conteúdo vazio retorna zero
            //***********************************
            if (strValue.Trim() == "")
                return "0";

            //**********************************************
            //* Monta número até encontrar primeiro literal
            //**********************************************
            char[] cRec = strValue.ToCharArray();
            string sNum = string.Empty;
            for (int i = 0; i < cRec.Length; i++)
            {
                if (char.IsNumber(cRec[i]) || cRec[i] == ',')
                    sNum += cRec[i];
            }

            //********************
            //* Retorna numéricos
            //********************
            return sNum;
        }
        public static string ToDBNumeric(this string strValue)
        {
            //***********************************
            //* Para conteúdo vazio retorna zero
            //***********************************
            if (strValue.Trim() == "")
                return "0";

            //**********************************************
            //* Monta número até encontrar primeiro literal
            //**********************************************
            char[] cRec = strValue.ToCharArray();
            string sNum = string.Empty;
            for (int i = 0; i < cRec.Length; i++)
            {
                if (char.IsNumber(cRec[i]))
                    sNum += cRec[i];
                else
                    break;
            }

            //****************************************************
            //* Tenta retornar valor, se houver erro retorna zero
            //****************************************************
            if (sNum != "")
            {
                try
                {
                    return Convert.ToDouble(sNum).ToString();
                }
                catch
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
        public static string ToDBCurrency(this string strValue)
        {
            //***********************************
            //* Para conteúdo vazio retorna zero
            //***********************************
            if (strValue.Trim() == "")
                return "0";

            //**********************************************
            //* Monta número até encontrar primeiro literal
            //**********************************************
            char[] cRec = strValue.ToCharArray();
            string sNum = string.Empty;
            for (int i = 0; i < cRec.Length; i++)
            {
                if (char.IsNumber(cRec[i]) || cRec[i] == ',')
                    sNum += cRec[i];
                else
                    break;
            }

            //*****************************
            //* Converte separador decimal
            //*****************************
            sNum = sNum.Replace(',', '.');

            //****************************************************
            //* Tenta retornar valor, se houver erro retorna zero
            //****************************************************
            if (sNum != "")
                return sNum;
            else
                return "0.00";
        }
        public static string Left(this string strValue, int Length)
        {
            if (string.IsNullOrEmpty(strValue)) return strValue;
            Length = Math.Abs(Length);
            return (strValue.Length <= Length ? strValue : strValue.Substring(0, Length));
        }
        public static string Right(this string strValue, int Length)
        {
            if (string.IsNullOrEmpty(strValue)) return strValue;
            Length = Math.Abs(Length);
            return (strValue.Length >= Length) ? strValue.Substring(strValue.Length - Length, Length) : strValue;
        }
        public static bool IsDate(this string strDateTime)
        {
            //*****************************************************
            //* Verifica se pode converter a string em data válida
            //*****************************************************
            try
            {
                DateTime strDate = DateTime.Parse(strDateTime);
                if (strDate != DateTime.MinValue && strDate != DateTime.MaxValue)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            //**************************************************
            //* Executa reposição apenas na primeira ocorrência
            //**************************************************
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        public static string SQLFilter(this string StringSQL)
        {
            //************************************************
            //* Filtra caracteres inválidos em comandos MYSQL
            //************************************************
            string ReturnString = StringSQL.Replace("\\", "\\\\");
            ReturnString = ReturnString.Replace("'", "\\'");
            return ReturnString;
        }
        public static bool ValidaCPF(this string CPF)
        {
            //*********************************************************************************
            //* Realiza cálculo dos dígitos (módulo 11) e confere com dígitos do CPF informado
            //*********************************************************************************
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            tempCpf = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }
        public static bool ValidaCNPJ(this string CNPJ)
        {
            //**********************************************************************************
            //* Realiza cálculo dos dígitos (módulo 11) e confere com dígitos do CNPJ informado
            //**********************************************************************************
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            CNPJ = CNPJ.Trim();
            CNPJ = CNPJ.Replace(".", "").Replace("-", "").Replace("/", "");
            if (CNPJ.Length != 14)
                return false;
            tempCnpj = CNPJ.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CNPJ.EndsWith(digito);
        }
        public static bool ValidaEmail(this string Email)
            {
                //**************************
                //* Endereço não informado?
                //**************************
                if (Email == string.Empty)
                    return false;

                //****************************
                //* Valida endereço de e-mail
                //****************************
                try
                {
                    MailAddress oEmail = new MailAddress(Email);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
        public static string MultiSeparator2Comma(this string strValue)
        {
            //*****************************************
            //* Converte multi seprarador para vírgula
            //*****************************************
            var delimiters = new[] { '|', '\\', '/', ',', ';' };
            var addresses = strValue.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(",", addresses);
        }
    }
    public static class EnumExtesions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if(attribs.Length > 0)
            {
                return ((DescriptionAttribute)attribs[0]).Description;
            }
            return string.Empty;
        }
    }
}
