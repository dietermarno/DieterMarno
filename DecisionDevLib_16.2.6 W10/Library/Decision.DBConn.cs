using System;
using System.Web;
using System.Text;
using System.Reflection;
using System.Configuration;
using Decision.LoginManager;
using Decision.Extensions;
using System.Data;

namespace Decision.Database
{
    //Extension methods must be defined in a static class
    public static class DBConnection
    {
        public static string GetMasterConnection()
        {
            //*************************
            //* Devolve conexão MASTER
            //*************************
            return ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
        }
        public static string GetConnectionFromMaster(string Nome_Empresa, bool DevArtConn = false)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConfigurationManager.ConnectionStrings["Master"].ConnectionString);
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;
            DataRow oRow;

            //*************************************
            //* Verifica a existência da instância
            //*************************************
            try
            {
                //******************
                //* Obtem instância
                //******************
                SQL = "SELECT * FROM agencias_cadastro WHERE conexao_nome = '" + Nome_Empresa.SQLFilter() + "'";
                oTable = oDB.ExecuteQuery(SQL);

                //**********************
                //* A instância existe?
                //**********************
                if (oTable.Rows.Count == 1)
                {
                    //*************************************************
                    //* Obtem dados de conexão para montagem da string
                    //*************************************************
                    oRow = oTable.Rows[0];
                    string conexao_driver = oRow.Field<string>("conexao_driver");
                    string conexao_server = oRow.Field<string>("conexao_server");
                    string conexao_database = oRow.Field<string>("conexao_database");
                    string conexao_port = oRow.Field<object>("conexao_port").ToString();
                    string conexao_user = oRow.Field<string>("conexao_user");
                    string conexao_password = Util.Crypto.DecryptString(oRow.Field<string>("conexao_password"));

                    //**************************
                    //* Monta string de conexão
                    //**************************
                    if (!DevArtConn)
                    {
                        //********************
                        //* Driver ODBC/MySQL
                        //********************
                        Conexao = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                                conexao_driver, conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);
                    }
                    else
                    {
                        //**********************
                        //* Driver DevArt MYSQL
                        //**********************
                        Conexao = String.Format("Host={1};Database={2};Port={3};User Id={4};Password={5};persist security info=True;",
                                                conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);

                    }

                    //******************************************
                    //* Retorna conexão para o banco da agência
                    //******************************************
                    return Conexao;
                }
                else
                {
                    //***************
                    //* Retorna erro
                    //***************
                    return "Error: Agência não encontrada.";
                }
            }

            catch (Exception oException)
            {
                //***************
                //* Retorna erro
                //***************
                return "Error: " + oException.Message;
            }
        }
        public static string GetConnectionFromMaster(Int32 Codigo_Empresa, bool DevArtConn = false)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConfigurationManager.ConnectionStrings["Master"].ConnectionString);
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;
            DataRow oRow;

            //*************************************
            //* Verifica a existência da instância
            //*************************************
            try
            {
                //******************
                //* Obtem instância
                //******************
                SQL = "SELECT * FROM agencias_cadastro WHERE codigo = '" + Codigo_Empresa + "'";
                oTable = oDB.ExecuteQuery(SQL);

                //**********************
                //* A instância existe?
                //**********************
                if (oTable.Rows.Count == 1)
                {
                    //*************************************************
                    //* Obtem dados de conexão para montagem da string
                    //*************************************************
                    oRow = oTable.Rows[0];
                    string conexao_driver = oRow.Field<string>("conexao_driver");
                    string conexao_server = oRow.Field<string>("conexao_server");
                    string conexao_database = oRow.Field<string>("conexao_database");
                    string conexao_port = oRow.Field<object>("conexao_port").ToString();
                    string conexao_user = oRow.Field<string>("conexao_user");
                    string conexao_password = Util.Crypto.DecryptString(oRow.Field<string>("conexao_password"));

                    //**************************
                    //* Monta string de conexão
                    //**************************
                    if (!DevArtConn)
                    {
                        //********************
                        //* Driver ODBC/MySQL
                        //********************
                        Conexao = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                                conexao_driver, conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);
                    }
                    else
                    {
                        //**********************
                        //* Driver DevArt MYSQL
                        //**********************
                        Conexao = String.Format("Host={1};Database={2};Port={3};User Id={4};Password={5};persist security info=True;",
                                                conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);

                    }

                    //******************************************
                    //* Retorna conexão para o banco da agência
                    //******************************************
                    return Conexao;
                }
                else
                {
                    //***************
                    //* Retorna erro
                    //***************
                    return "Error: Agência não encontrada.";
                }
            }

            catch (Exception oException)
            {
                //***************
                //* Retorna erro
                //***************
                return "Error: " + oException.Message;
            }
        }
        public static string GetCurrentSessionConnection()
        {
            //************************************************
            //* Tenta obter dados de login a partir da sessão
            //************************************************
            Login_Manager oLogin = new Login_Manager();
            try
            {
                oLogin = (Login_Manager)HttpContext.Current.Session["Decision_LoginInfo"];
            }
            catch
            {
                oLogin = null;
            }

            //****************************
            //* A sessão já foi definida?
            //****************************
            if (oLogin == null)
                return ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            else
                return oLogin.LoginInfo.Master_ConexaoString;
        }
        public static string GetConnectionFromSession(object SessionLoginInfo)
        {
            //**************
            //* Declarações
            //**************
            Login_Manager oLogin = new Login_Manager();

            //**********************************
            //* Converte objeto e obtem conexão
            //**********************************
            try { oLogin = (Login_Manager)SessionLoginInfo; } catch { }
            return oLogin.LoginInfo.Master_ConexaoString;
        }
    }
}