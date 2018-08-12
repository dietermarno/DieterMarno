using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Data.Common;
using Decision.Extensions;
using Devart.Data.MySql;

namespace Decision.Database
{
    public class DBManager
    {
        //***********************************
        //* Estrutura de contole de execução
        //***********************************
        Boolean _Error = false;
        string _ErrorMessage = string.Empty;
        string _ErrorSource = string.Empty;
        Int32 _LastInsertID = 0;
        DataTable _Data = new DataTable();
        string _ConnectionString = string.Empty;

        public Boolean Error { get { return _Error; }}
        public string ErrorMessage { get { return _ErrorMessage; }}
        public string ErrorSource { get { return _ErrorSource; }}
        public Int32 LastInsertID { get { return _LastInsertID; } }
        public DataTable Data { get { return _Data; } }
        public string ConnectionString { get { return _ConnectionString; } set { _ConnectionString = value; } }
        public DBManager(string DBConnection)
        {
            //*********************************
            //* Inicializa controles da classe
            //*********************************
            _ConnectionString = DBConnection;
            _Error = false;
            _ErrorMessage = string.Empty;
            _ErrorSource = string.Empty;
            _LastInsertID = 0;
            _Data = new DataTable();
        }
        public void SetConnection(string ConnectionString)
        {
            //*****************************
            //* Atualiza string de conexão
            //*****************************
            _ConnectionString = ConnectionString;
        }
        public Int32 ExecuteCommand(string SQLCommand, bool DisableForeignKeyChecks = false)
        {
            //********************
            //* Cria objetos ODBC
            //********************
            OdbcConnection oConnectionODBC = new OdbcConnection();
            if (_ConnectionString.IndexOf("ODBC") > -1) oConnectionODBC.ConnectionString = _ConnectionString;
            OdbcCommand oCommandODBC = new OdbcCommand("", oConnectionODBC);

            //**********************
            //* Cria objetos DEVART
            //**********************
            MySqlConnection oConnectionDEVART = new MySqlConnection();
            if (_ConnectionString.IndexOf("ODBC") == -1) oConnectionDEVART.ConnectionString = _ConnectionString;
            MySqlCommand oCommandDEVART = new MySqlCommand("", oConnectionDEVART);

            //***************
            //* Define query
            //***************
            string SQLQuery = "SELECT last_insert_id()";
            Int32 LastID = 0;

            //************************************
            //* Cria controle de erro de execução
            //************************************
            try
            {
                //***************
                //* Abre conexão
                //***************
                if (_ConnectionString.IndexOf("ODBC") > -1)
                    oCommandODBC.Connection.Open();
                else
                    oCommandDEVART.Connection.Open();

                //***********************************************************
                //* Desativa verificação de chave extrangeira em importações
                //***********************************************************
                if (DisableForeignKeyChecks)
                {
                    //******************
                    //* DEVART ou ODBC?
                    //******************
                    if (_ConnectionString.IndexOf("ODBC") > -1)
                    {
                        //********************
                        //* Desativa FK CHECK
                        //********************
                        oCommandODBC.CommandText = "SET FOREIGN_KEY_CHECKS=0";
                        oCommandODBC.CommandTimeout = 120;
                        oCommandODBC.ExecuteNonQuery();
                    }
                    else
                    {
                        //********************
                        //* Desativa FK CHECK
                        //********************
                        oCommandDEVART.CommandText = "SET FOREIGN_KEY_CHECKS=0";
                        oCommandDEVART.CommandTimeout = 120;
                        oCommandDEVART.ExecuteNonQuery();
                    }
                }

                //******************
                //* DEVART ou ODBC?
                //******************
                if (_ConnectionString.IndexOf("ODBC") > -1)
                {
                    //****************************
                    //* Conecta e executa comando
                    //****************************
                    oCommandODBC.CommandText = SQLCommand;
                    oCommandODBC.CommandTimeout = 120;
                    oCommandODBC.ExecuteNonQuery();

                    //*********************************************
                    //* A instrução realizou inclusão de registro?
                    //*********************************************
                    oCommandODBC.CommandText = SQLQuery;
                    LastID = Convert.ToInt32(oCommandODBC.ExecuteScalar());
                }
                else
                {
                    //****************************
                    //* Conecta e executa comando
                    //****************************
                    oCommandDEVART.CommandText = SQLCommand;
                    oCommandDEVART.CommandTimeout = 120;
                    oCommandDEVART.ExecuteNonQuery();

                    //*********************************************
                    //* A instrução realizou inclusão de registro?
                    //*********************************************
                    oCommandDEVART.CommandText = SQLQuery;
                    LastID = Convert.ToInt32(oCommandDEVART.ExecuteScalar());
                }


                //**********************************************************
                //* Reativa verificação de chave extrangeira em importações
                //**********************************************************
                if (DisableForeignKeyChecks)
                {
                    //******************
                    //* DEVART ou ODBC?
                    //******************
                    if (_ConnectionString.IndexOf("ODBC") > -1)
                    {
                        //********************
                        //* Desativa FK CHECK
                        //********************
                        oCommandODBC.CommandText = "SET FOREIGN_KEY_CHECKS=1";
                        oCommandODBC.CommandTimeout = 120;
                        oCommandODBC.ExecuteNonQuery();
                    }
                    else
                    {
                        //********************
                        //* Desativa FK CHECK
                        //********************
                        oCommandDEVART.CommandText = "SET FOREIGN_KEY_CHECKS=1";
                        oCommandDEVART.CommandTimeout = 120;
                        oCommandDEVART.ExecuteNonQuery();
                    }
                }

                //**********************************
                //* Retorna informações de inclusão
                //**********************************
                _Error = false;
                _ErrorMessage = string.Empty;
                _ErrorSource = string.Empty;
                _LastInsertID = LastID;
                _Data = null;
                if (_ConnectionString.IndexOf("ODBC") > -1) 
                    oConnectionODBC.Close(); 
                else 
                    oConnectionDEVART.Close();
                return LastID;
            }
            catch (Exception oException)
            {
                //*******************************************
                //* Retorna informações sobre falha ocorrida
                //*******************************************
                _Error = true;
                _ErrorMessage = oException.Message;
                _ErrorSource = oException.Source;
                _LastInsertID = 0;
                _Data = null;
                if (_ConnectionString.IndexOf("ODBC") > -1) 
                    oConnectionODBC.Close(); 
                else 
                    oConnectionDEVART.Close();
                return 0;
            }
        }
        public DataTable ExecuteQuery(string SQLQuery) 
        {
            //********************
            //* Cria objetos ODBC
            //********************
            OdbcConnection oConnectionODBC = new OdbcConnection();
            if (_ConnectionString.IndexOf("ODBC") > -1) oConnectionODBC.ConnectionString = _ConnectionString;
            OdbcDataAdapter oDataAdapterODBC = new OdbcDataAdapter("", oConnectionODBC);

            //**********************
            //* Cria objetos DEVART
            //**********************
            MySqlConnection oConnectionDEVART = new MySqlConnection();
            if (_ConnectionString.IndexOf("ODBC") == -1) oConnectionDEVART.ConnectionString = _ConnectionString;
            MySqlDataAdapter oDataAdapterDEVART = new MySqlDataAdapter("", oConnectionDEVART);

            //**********************
            //* Cria objeto DATASET
            //**********************
            DataSet oDataSet = new DataSet();

            //************************************
            //* Cria controle de erro de execução
            //************************************
            try
            {
                //**************************************
                //* Conecta e obtem retorno da pesquisa
                //**************************************
                if (_ConnectionString.IndexOf("ODBC") > -1)
                {
                    oDataAdapterODBC.SelectCommand.CommandText = SQLQuery;
                    oDataAdapterODBC.SelectCommand.CommandTimeout = 120;
                    oDataAdapterODBC.Fill(oDataSet, "ResultTable");
                }
                else
                {
                    oDataAdapterDEVART.SelectCommand.CommandText = SQLQuery;
                    oDataAdapterDEVART.SelectCommand.CommandTimeout = 120;
                    oDataAdapterDEVART.Fill(oDataSet, "ResultTable");
                }

                //**********************************
                //* Retorna informações de pesquisa
                //**********************************
                _Error = false;
                _ErrorMessage = string.Empty;
                _ErrorSource = string.Empty;
                _LastInsertID = 0;
                _Data = oDataSet.Tables["ResultTable"].Copy();
                oDataAdapterODBC.Dispose();
                oConnectionODBC.Close();
                return _Data;
            }
            catch (Exception oException)
            {
                //*******************************************
                //* Retorna informações sobre falha ocorrida
                //*******************************************
                _Error = true;
                _ErrorMessage = oException.Message;
                _ErrorSource = oException.Source;
                _LastInsertID = 0;
                _Data = null;
                oDataAdapterODBC.Dispose();
                oConnectionODBC.Close();
                return null;
            }
        }
        public Int32 SaveSQLCommand(System.Data.Common.DbCommand SQLCommand, string Username)
        {
            //********************
            //* Declara variáveis
            //********************
            OdbcConnection oConnection = new OdbcConnection(_ConnectionString);
            OdbcCommand oCommand = new OdbcCommand("", oConnection);
            string SQLQuery = "SELECT last_insert_id()";
            Int32 LastID = 0;

            //************************************
            //* Cria controle de erro de execução
            //************************************
            try
            {
                //**********************************
                //* Define comando de armazenamento
                //**********************************
                string SQLInsert = "INSERT INTO logbanco (";
                SQLInsert += "data,";
                SQLInsert += "usuario,";
                SQLInsert += "tabela,";
                SQLInsert += "operacao,";
                SQLInsert += "comando";
                SQLInsert += ") VALUES (";
                SQLInsert += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',";
                SQLInsert += "'" + Username.SQLFilter() + "',";
                SQLInsert += "'" + GetSQLTable(SQLCommand.CommandText).SQLFilter() + "',";
                SQLInsert += "'" + GetSQLCommand(SQLCommand.CommandText).SQLFilter() + "',";
                SQLInsert += "'" + GetSQLFinal(SQLCommand).SQLFilter() + "')";

                //**********************
                //* Conecta e salva log
                //**********************
                oCommand.CommandText = SQLInsert;
                oCommand.CommandTimeout = 120;
                oCommand.Connection.Open();
                oCommand.ExecuteNonQuery();

                //*********************************************
                //* A instrução realizou inclusão de registro?
                //*********************************************
                oCommand.CommandText = SQLQuery;
                LastID = Convert.ToInt32(oCommand.ExecuteScalar());

                //**********************************
                //* Retorna informações de inclusão
                //**********************************
                _Error = false;
                _ErrorMessage = string.Empty;
                _ErrorSource = string.Empty;
                _LastInsertID = LastID;
                _Data = null;
                return LastID;
            }
            catch (Exception oException)
            {
                //*******************************************
                //* Retorna informações sobre falha ocorrida
                //*******************************************
                _Error = true;
                _ErrorMessage = oException.Message;
                _ErrorSource = oException.Source;
                _LastInsertID = 0;
                _Data = null;
                return 0;
            }
        }
        public void Dispose()
        {
            //******************
            //* Destroi objetos
            //******************
            _ConnectionString = string.Empty;
            _ErrorMessage = string.Empty;
            _ErrorSource = string.Empty;
            _LastInsertID = 0;
            _Error = false;
            _Data = null;
        }
        public string GetSQLCommand(string SQL)
        {
            //***************************
            //* O comando foi informado?
            //***************************
            SQL = SQL.Replace("(", " ");
            SQL = SQL.Replace(")", " ");
            SQL = SQL.Replace("  ", " ");
            if (SQL.Trim() == "")
                return "";

            //*******************
            //* Decompõe comando
            //*******************
            string[] CommandArray = SQL.Split(' ');

            //***************************
            //* Possui o tamanho mínimo?
            //***************************
            if (CommandArray.Length >= 3)
                {
                //******************
                //* Retorna comando
                //******************
                return CommandArray[0].ToUpper().Trim();
                }
            else
                {
                //*******************
                //* Tamanho inválido
                //*******************
                return "";
                }
        }
        public string GetSQLTable(string SQL) 
        {
            //***************************
            //* O comando foi informado?
            //***************************
            SQL = SQL.Replace("(", " ");
            SQL = SQL.Replace(")", " ");
            SQL = SQL.Replace("  ", " ");
            if (SQL.Trim() == "")
                return "";

            //*******************
            //* Decompõe comando
            //*******************
            string[] CommandArray = SQL.Split(' ');

            //***************************
            //* Possui o tamanho mínimo?
            //***************************
            if (CommandArray.Length >= 3) 
            {
                //*********************************
                //* INSERT[0] INTO[1] tablename[2]
                //* DELETE[0] FROM[1] tablename[2]
                //* UPDATE[0] tablename[1]
                //*********************************
                switch (CommandArray[0].ToUpper().Trim())
                {
                    case "INSERT":
                        return CommandArray[2].ToUpper().Trim();

                    case "DELETE":
                        return CommandArray[2].ToUpper().Trim();

                    case "UPDATE":
                        return CommandArray[1].ToUpper().Trim();

                    default:
                        return string.Empty;
                }
            }
            else
            {
                //*******************
                //* Tamanho inválido
                //*******************
                return "";
            }
        }
        public string GetSQLFinal(System.Data.Common.DbCommand SQLCommand)
        {
            //**********************************
            //* Insere valores no comando final
            //**********************************
            string FinalSQL = SQLCommand.CommandText;
            foreach (System.Data.Odbc.OdbcParameter oParameter in SQLCommand.Parameters)
            {
                FinalSQL = FinalSQL.ReplaceFirst("?", GetDBFieldValue(oParameter));
            }        

            //**********************************
            //* Insere valores no comando final
            //**********************************
            return FinalSQL;
        }
        public string GetDBFieldValue(System.Data.Common.DbParameter oParameter)
        {
            //*************************************************
            //* Devolve valor acompanhado por prefixo e sufixo
            //*************************************************
            switch (oParameter.DbType.ToString())
            {
                case "AnsiString":
                    return "'" + oParameter.Value.ToString() + "'";
                case "AnsiStringFixedLength":
                    return "'" + oParameter.Value.ToString() + "'";
                case "Binary":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Boolean":
                    return oParameter.Value.ToString();
                case "Byte":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Currency":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Date":
                    if (oParameter.Value.ToString().IsDate())
                        return "'" + DateTime.Parse(oParameter.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        return "null";
                case "DateTime":
                    if (oParameter.Value.ToString().IsDate())
                        return "'" + DateTime.Parse(oParameter.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        return "null";
                case "DateTime2":
                    if (oParameter.Value.ToString().IsDate())
                        return "'" + DateTime.Parse(oParameter.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        return "null";
                case "DateTimeOffset":
                    if (oParameter.Value.ToString().IsDate())
                        return "'" + DateTime.Parse(oParameter.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                    else
                        return "null";
                case "Decimal":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Double":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Guid":
                    return "'" + oParameter.Value.ToString() + "'";
                case "Int16":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Int32":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Int64":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Object":
                    return "'" + oParameter.Value.ToString().ToDBNumeric() + "'";
                case "SByte":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Single":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "String":
                    return "'" + oParameter.Value.ToString() + "'";
                case "StringFixedLength":
                    return "'" + oParameter.Value.ToString() + "'";
                case "Time":
                    return "'" + oParameter.Value.ToString() + "'";
                case "UInt16":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "UInt32":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "UInt64":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "VarNumeric":
                    return oParameter.Value.ToString().ToDBNumeric();
                case "Xml":
                    return "'" + oParameter.Value.ToString() + "'";
                default:
                    return "''";
            }
        }
    }
}