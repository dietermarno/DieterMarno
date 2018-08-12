using System;
using System.Data;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace Decision.Util
{
    public static class DBUtilities
    {
        public static object ParseNullField(System.Data.Common.DbParameter oParameter)
        {
            //**************************
            //* Atualiza parâmetro nulo
            //**************************
            if (!oParameter.SourceColumnNullMapping && oParameter.Value == null)
                switch (oParameter.DbType)
                {
                    case DbType.AnsiString:
                        oParameter.Value = string.Empty;
                        break;

                    case DbType.AnsiStringFixedLength:
                        oParameter.Value = string.Empty;
                        break;
                        
                    case DbType.Binary:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Boolean:
                        oParameter.Value = false;
                        break;
                        
                    case DbType.Byte:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Currency:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Date:
                        oParameter.Value = DateTime.Now;
                        break;
                        
                    case DbType.DateTime:
                        oParameter.Value = DateTime.Now;
                        break;
                        
                    case DbType.DateTime2:
                        oParameter.Value = DateTime.Now;
                        break;
                        
                    case DbType.DateTimeOffset:
                        oParameter.Value = DateTime.Now;
                        break;
                        
                    case DbType.Decimal:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Double:
                        oParameter.Value = 0;
                        break;
                    case DbType.Guid:
                        oParameter.Value = string.Empty;
                        break;

                    case DbType.Int16:
                        oParameter.Value = 0;
                        break;

                    case DbType.Int32:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Int64:
                        oParameter.Value = 0;
                        break;

                    case DbType.Object:
                        oParameter.Value = new object();
                        break;

                    case DbType.SByte:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.Single:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.String:
                        oParameter.Value = string.Empty;
                        break;
                        
                    case DbType.StringFixedLength:
                        oParameter.Value = string.Empty;
                        break;
                        
                    case DbType.Time:
                        oParameter.Value = DateTime.Now;
                        break;

                    case DbType.UInt16:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.UInt32:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.UInt64:
                        oParameter.Value = 0;
                        break;
                        
                    case DbType.VarNumeric:
                        oParameter.Value = 0;
                        break;

                    case DbType.Xml:
                        oParameter.Value = string.Empty;
                        break;
                }

            //*******************************************
            //* Retorna coleção de parâmetros atualizada
            //*******************************************
            return oParameter.Value;
        }
        public static object ParseNullField(TypeCode oType, string KeyName, object oValue, char Operation = 'U')
        {
            //**************************
            //* Atualiza parâmetro nulo
            //**************************
            if (oValue == null)
            {
                //********************
                //* Realiza conversão
                //********************
                switch (oType)
                {
                    case System.TypeCode.Boolean:
                        oValue = false;
                        break;

                    case System.TypeCode.Byte:
                        oValue = 0;
                        break;

                    case System.TypeCode.Char:
                        oValue = string.Empty;
                        break;

                    case System.TypeCode.DateTime:
                        oValue = string.Empty;
                        break;
                        
                    case System.TypeCode.DBNull:
                        oValue = null;
                        break;

                    case System.TypeCode.Decimal:
                        oValue = 0;
                        break;

                    case System.TypeCode.Double:
                        oValue = 0;
                        break;

                    case System.TypeCode.Empty:
                        oValue = string.Empty;
                        break;

                    case System.TypeCode.Int16:
                        oValue = 0;
                        break;

                    case System.TypeCode.Int32:
                        oValue = 0;
                        break;

                    case System.TypeCode.Int64:
                        oValue = 0;
                        break;

                    case System.TypeCode.Object:
                        oValue = new object();
                        break;

                    case System.TypeCode.SByte:
                        oValue = 0;
                        break;

                    case System.TypeCode.Single:
                        oValue = 0;
                        break;

                    case System.TypeCode.String:
                        oValue = string.Empty;
                        break;

                    case System.TypeCode.UInt16:
                        oValue = 0;
                        break;

                    case System.TypeCode.UInt32:
                        oValue = 0;
                        break;

                    case System.TypeCode.UInt64:
                        oValue = 0;
                        break;

                    default:
                        oValue = new object();
                        break;
                }
            }

            //****************************
            //* Retorna objeto convertido
            //****************************
            return oValue;
        }
    }
}