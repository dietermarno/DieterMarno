using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;
using Decision.Util;

namespace Decision.TableManager
{
    public class Config_Fields
    {
        //*******************
        //* Campos da tabela
        //*******************
        private bool _SMTP_Autenticacao = false;
        private string _SMTP_Endereco = string.Empty;
        private Int32 _SMTP_Porta = 0;
        private string _SMTP_Usuario = string.Empty;
        private string _SMTP_Senha = string.Empty;
        private bool _SMTP_SSL = false;
        private bool _SMTP_TLS = false;
        private bool _Error = false;
        private string _ErrorText = string.Empty;
        private Dictionary<string, string> _Parametros = new Dictionary<string, string>();
        public Dictionary<string, string> Parametros { get { return _Parametros; } set { _Parametros = value; } }
        public bool Error { get { return _Error; } set { _Error = value; } }
        public string ErrorText { get { return _ErrorText; } set { _ErrorText = value; } }
        public bool SMTP_Autenticacao { get { return _SMTP_Autenticacao; } set { _SMTP_Autenticacao = value; } }
        public string SMTP_Endereco { get { return _SMTP_Endereco; } set { _SMTP_Endereco = value; } }
        public Int32 SMTP_Porta { get { return _SMTP_Porta; } set { _SMTP_Porta = value; } }
        public string SMTP_Usuario { get { return _SMTP_Usuario; } set { _SMTP_Usuario = value; } }
        public string SMTP_Senha { get { return _SMTP_Senha; } set { _SMTP_Senha = value; } }
        public bool SMTP_SSL { get { return _SMTP_SSL; } set { _SMTP_SSL = value; } }
        public bool SMTP_TLS { get { return _SMTP_TLS; } set { _SMTP_TLS = value; } }
        public Config_Fields()
        {
            //****************
            //* Inicialização
            //****************
            _Error = false;
            _ErrorText = string.Empty;
            _Parametros = new Dictionary<string, string>();
            _SMTP_Autenticacao = false;
            _SMTP_Endereco = string.Empty;
            _SMTP_Porta = 0;
            _SMTP_Usuario = string.Empty;
            _SMTP_Senha = string.Empty;
            _SMTP_SSL = false;
            _SMTP_TLS = false;
        }
    }
    public class Config_Manager
    {
        //***************
        //* Propriedades
        //***************
        private bool _Error = false;
        private string _ErrorText = string.Empty;
        private string _ConnectionString;
        public bool Error { get { return _Error; } }
        public string ErrorText { get { return _ErrorText; } }
        public string ConnectionString { get { return _ConnectionString; } }
        public Config_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Config_Fields GetRecord()
        {
            //**************
            //* Declarações
            //**************
            Config_Fields oConfig = new Config_Fields();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //*****************
                //* Obtem registro
                //*****************
                SQL = "SELECT * FROM config WHERE codigo = 1";
                oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*********************************
            //* A pesquisa retornou registros?
            //*********************************
            if (oTable != null)
            {
                //***********************************
                //* A pesquisa localizou o registro?
                //***********************************
                if (oTable.Rows.Count == 1)
                {
                    //*******************************
                    //* Copia dados para a estrutura
                    //*******************************
                    DataRow oRow = oTable.Rows[0];
                    oConfig.SMTP_Autenticacao = !DBNull.Value.Equals(oRow["smtp_autenticacao"]) ? Convert.ToBoolean(oRow["smtp_autenticacao"]) : false;
                    oConfig.SMTP_Endereco = !DBNull.Value.Equals(oRow["smtp_endereco"]) ? oRow["smtp_endereco"].ToString() : string.Empty;
                    oConfig.SMTP_Porta = !DBNull.Value.Equals(oRow["smtp_porta"]) ? Convert.ToInt32("0" + oRow["smtp_porta"]) : 0;
                    oConfig.SMTP_Usuario = !DBNull.Value.Equals(oRow["smtp_usuario"]) ? oRow["smtp_usuario"].ToString() : string.Empty;
                    oConfig.SMTP_Senha = !DBNull.Value.Equals(oRow["smtp_senha"]) ?  Crypto.DecryptString(oRow["smtp_senha"].ToString()) : string.Empty;
                    oConfig.SMTP_SSL = !DBNull.Value.Equals(oRow["smtp_ssl"]) ? Convert.ToBoolean(oRow["smtp_ssl"]) : false;
                    oConfig.SMTP_TLS = !DBNull.Value.Equals(oRow["smtp_tls"]) ? Convert.ToBoolean(oRow["smtp_tls"]) : false;
                }
            }
            else
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = "O Resultado da pesquisa retornou nulo";
                _Error = true;
            }

            //****************
            //* Retorna dados
            //****************
            return oConfig;
        }
        public bool ApplyRecord(Config_Fields oConfig)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //*****************
                //* Obtem registro
                //*****************
                SQL = "SELECT * FROM config ORDER BY codigo DESC";
                oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*********************************
            //* A pesquisa retornou registros?
            //*********************************
            if (oTable != null)
            {
                //***********************************
                //* A pesquisa localizou o registro?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //****************
                    //* Cria registro
                    //****************
                    SQL = "INSERT INTO config (";
                    SQL += "codigo,";
                    SQL += "smtp_autenticacao,";
                    SQL += "smtp_endereco,";
                    SQL += "smtp_porta,";
                    SQL += "smtp_usuario,";
                    SQL += "smtp_senha,";
                    SQL += "smtp_ssl,";
                    SQL += "smtp_tls";
                    SQL += ") VALUES (";
                    SQL += "1,";
                    SQL += Convert.ToInt16(oConfig.SMTP_Autenticacao) + ",";
                    SQL += "'" + oConfig.SMTP_Endereco.SQLFilter() + "',";
                    SQL += oConfig.SMTP_Porta + ",";
                    SQL += "'" + oConfig.SMTP_Usuario.SQLFilter() + "',";
                    SQL += "'" + Crypto.EncryptString(oConfig.SMTP_Senha).SQLFilter() + "',";
                    SQL += Convert.ToInt16(oConfig.SMTP_SSL) + ",";
                    SQL += Convert.ToInt16(oConfig.SMTP_TLS) + ")";
                }
                else
                {
                    //***************************
                    //* Obtem código do registro
                    //***************************
                    DataRow oRow = oTable.Rows[0];

                    //********************
                    //* Atualiza registro
                    //********************
                    SQL = "UPDATE config (";
                    SQL += "smtp_autenticacao = " + Convert.ToInt16(oConfig.SMTP_Autenticacao) + ",";
                    SQL += "smtp_endereco = '" + oConfig.SMTP_Endereco.SQLFilter() + "',";
                    SQL += "smtp_porta = " + oConfig.SMTP_Porta + ",";
                    SQL += "smtp_usuario = '" + oConfig.SMTP_Usuario.SQLFilter() + "',";
                    SQL += "smtp_senha = '" + Crypto.EncryptString(oConfig.SMTP_Senha).SQLFilter() + "',";
                    SQL += "smtp_ssl = " + Convert.ToInt16(oConfig.SMTP_SSL) + ",";
                    SQL += "smtp_tls = " + Convert.ToInt16(oConfig.SMTP_TLS) + " ";
                    SQL += "WHERE config.codigo = " + oRow["codigo"];
                }
            }

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*****************************
            //* Retorna estado de execução
            //*****************************
            return !oDBManager.Error;
        }
        public bool DeleteRecord()
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //************************************************
            //* Exclui orçamentos relacionados à configuração
            //************************************************
            try
            {
                //**********************
                //* Exclui configuração
                //**********************
                SQL = "DELETE FROM config";
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*****************************
            //* Retorna estado de execução
            //*****************************
            return !oDBManager.Error;
        }
    }
}
