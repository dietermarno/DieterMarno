using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using Decision.Database;
using Decision.Extensions;
using Decision.Util;

namespace Decision.LoginManager
{
    public class PasswordRecoveryUserList
    {
        //********************************
        //* Dados de recuperação de senha
        //********************************
        private Int32 _Empresa_Codigo = 0;
        private Int32 _Posto_Codigo = 0;
        private string _Conexao_Nome = string.Empty;
        private string _Usuario_Nome = string.Empty;
        private string _Usuario_Email = string.Empty;
        private string _Usuario_ID = string.Empty;
        private string _Usuario_Senha = string.Empty;

        //*******************
        //* Membros públicos
        //*******************
        public Int32 Empresa_Codigo { get { return _Empresa_Codigo; } set { _Empresa_Codigo = value; } }
        public Int32 Posto_Codigo { get { return _Posto_Codigo; } set { _Posto_Codigo = value; } }
        public string Conexao_Nome { get { return _Conexao_Nome; } set { _Conexao_Nome = value; } }
        public string Usuario_Nome { get { return _Usuario_Nome; } set { _Usuario_Nome = value; } }
        public string Usuario_Email { get { return _Usuario_Email; } set { _Usuario_Email = value; } }
        public string Usuario_ID { get { return _Usuario_ID; } set { _Usuario_ID = value; } }
        public string Usuario_Senha { get { return _Usuario_Senha; } set { _Usuario_Senha = value; } }
        public PasswordRecoveryUserList()
        {
            //****************
            //* Inicialização
            //****************
            _Empresa_Codigo = 0;
            _Posto_Codigo = 0;
            _Conexao_Nome = string.Empty;
            _Usuario_Nome = string.Empty;
            _Usuario_Email = string.Empty;
            _Usuario_Senha = string.Empty;
        }
        public PasswordRecoveryUserList(Int32 CodigoEmpresa, Int32 CodigoPosto, string NomeConexao, string NomeUsuario,
                                        string EmailUsuario, string IDUsuario, string SenhaUsuario)
        {
            //****************
            //* Inicialização
            //****************
            _Empresa_Codigo = CodigoEmpresa;
            _Posto_Codigo = CodigoPosto;
            _Conexao_Nome = NomeConexao;
            _Usuario_Nome = NomeUsuario;
            _Usuario_Email = EmailUsuario;
            _Usuario_Senha = SenhaUsuario;
        }
    }
    public class Login_Fields
    {
        //***************************************
        //* Campos de dados do controle de login
        //***************************************
        private Int32 _Master_Codigo = 0;
        private string _Master_Empresa = string.Empty;
        private string _Master_ConexaoString = string.Empty;
        private string _Master_DevArtConexaoString = string.Empty;
        private Int32 _Posto_Codigo = 0;
        private string _Posto_Nome = string.Empty;
        private string _Posto_Descricao = string.Empty;
        private Bitmap _Posto_Logotipo = null;
        private Int32 _Usuario_Codigo = 0;
        private Int32 _Usuario_CodigoGrupo = 0;
        private string _Usuario_DescGrupo = string.Empty;
        private Int32 _Usuario_CodigoPromotor = 0;
        private string _Usuario_NomePromotor = string.Empty;
        private string _Usuario_Nome = string.Empty;
        private string _Usuario_ID = string.Empty;
        private string _Usuario_Senha = string.Empty;
        private string _Usuario_Telefone = string.Empty;
        private string _Usuario_EmailEndereco = string.Empty;
        private bool _Usuario_EmailCopia = false;
        private bool _Usuario_Supervisor = false;
        private bool _Usuario_Ativo = false;
        private bool _SMTP_autenticacao = false;
        private string _SMTP_endereco = string.Empty;
        private Int32 _SMTP_porta = 0;
        private string _SMTP_usuario = string.Empty;
        private string _SMTP_senha = string.Empty;
        private bool _SMTP_ssl = false;
        private bool _SMTP_tls = false;
        private bool _Error = false;
        private string _ErrorText = string.Empty;
        Dictionary<string, string> _Parametros = new Dictionary<string, string>();

        public Dictionary<string, string> Parametros { get { return _Parametros; } set { _Parametros = value; } }
        public bool Error { get { return _Error; } set { _Error = value; } }
        public string ErrorText { get { return _ErrorText; } set { _ErrorText = value; } }
        public Int32 Master_Codigo { get { return _Master_Codigo; } set { _Master_Codigo = value; } }
        public string Master_Empresa { get { return _Master_Empresa; } set { _Master_Empresa = value; } }
        public string Master_ConexaoString { get { return _Master_ConexaoString; } set { _Master_ConexaoString = value; } }
        public string Master_DevArtConexaoString { get { return _Master_DevArtConexaoString; } set { _Master_DevArtConexaoString = value; } }
        public Int32 Posto_Codigo { get { return _Posto_Codigo; } set { _Posto_Codigo = value; } }
        public string Posto_Nome { get { return _Posto_Nome; } set { _Posto_Nome = value; } }
        public string Posto_Descricao { get { return _Posto_Descricao; } set { _Posto_Descricao = value; } }
        public Bitmap Posto_Logotipo { get { return _Posto_Logotipo; } set { _Posto_Logotipo = value; } }
        public Int32 Usuario_Codigo { get { return _Usuario_Codigo; } set { _Usuario_Codigo = value; } }
        public Int32 Usuario_CodigoGrupo { get { return _Usuario_CodigoGrupo; } set { _Usuario_CodigoGrupo = value; } }
        public string Usuario_DescGrupo { get { return _Usuario_DescGrupo; } set { _Usuario_DescGrupo = value; } }
        public Int32 Usuario_CodigoPromotor { get { return _Usuario_CodigoPromotor; } set { _Usuario_CodigoPromotor = value; } }
        public string Usuario_NomePromotor { get { return _Usuario_NomePromotor; } set { _Usuario_NomePromotor = value; } }
        public string Usuario_Nome { get { return _Usuario_Nome; } set { _Usuario_Nome = value; } }
        public string Usuario_ID { get { return _Usuario_ID; } set { _Usuario_ID = value; } }
        public string Usuario_Senha { get { return _Usuario_Senha; } set { _Usuario_Senha = value; } }
        public string Usuario_Telefone { get { return _Usuario_Telefone; } set { _Usuario_Telefone = value; } }
        public string Usuario_EmailEndereco { get { return _Usuario_EmailEndereco; } set { _Usuario_EmailEndereco = value; } }
        public bool Usuario_EmailCopia { get { return _Usuario_EmailCopia; } set { _Usuario_EmailCopia = value; } }
        public bool Usuario_Supervisor { get { return _Usuario_Supervisor; } set { _Usuario_Supervisor = value; } }
        public bool Usuario_Ativo { get { return _Usuario_Ativo; } set { _Usuario_Ativo = value; } }
        public bool SMTP_autenticacao { get { return _SMTP_autenticacao; } set { _SMTP_autenticacao = value; } }
        public string SMTP_endereco { get { return _SMTP_endereco; } set { _SMTP_endereco = value; } }
        public Int32 SMTP_porta { get { return _SMTP_porta; } set { _SMTP_porta = value; } }
        public string SMTP_usuario { get { return _SMTP_usuario; } set { _SMTP_usuario = value; } }
        public string SMTP_senha { get { return _SMTP_senha; } set { _SMTP_senha = value; } }
        public bool SMTP_ssl { get { return _SMTP_ssl; } set { _SMTP_ssl = value; } }
        public bool SMTP_tls { get { return _SMTP_tls; } set { _SMTP_tls = value; } }
        public Login_Fields()
        {
            //****************
            //* Cancela login
            //****************
            _Error = false;
            _ErrorText = string.Empty;
            _Parametros = new Dictionary<string, string>();
            _Master_Codigo = 0;
            _Master_Empresa = string.Empty;
            _Master_ConexaoString = string.Empty;
            _Master_DevArtConexaoString = string.Empty;
            _Posto_Codigo = 0;
            _Posto_Nome = string.Empty;
            _Posto_Descricao = string.Empty;
            _Posto_Logotipo = null;
            _Usuario_Codigo = 0;
            _Usuario_CodigoGrupo = 0;
            _Usuario_DescGrupo = string.Empty;
            _Usuario_CodigoPromotor = 0;
            _Usuario_NomePromotor = string.Empty;
            _Usuario_Nome = string.Empty;
            _Usuario_ID = string.Empty;
            _Usuario_Senha = string.Empty;
            _Usuario_Telefone = string.Empty;
            _Usuario_EmailEndereco = string.Empty;
            _Usuario_EmailCopia = false;
            _Usuario_Supervisor = false;
            _Usuario_Ativo = false;
            _SMTP_autenticacao = false;
            _SMTP_endereco = string.Empty;
            _SMTP_porta = 0;
            _SMTP_usuario = string.Empty;
            _SMTP_senha = string.Empty;
            _SMTP_ssl = false;
            _SMTP_tls = false;
        }
    }
    public class Login_Manager
    {
        //*******************************
        //* Dados de formação de conexão
        //*******************************
        public Login_Fields LoginInfo = new Login_Fields();

        //*******************************
        //* Dados de formação de conexão
        //*******************************
        protected string conexao_driver = string.Empty;
        protected string conexao_server = string.Empty;
        protected string conexao_database = string.Empty;
        protected string conexao_port = string.Empty;
        protected string conexao_user = string.Empty;
        protected string conexao_password = string.Empty;

        //***************
        //* Propriedades
        //***************
        private bool _Error = false;
        private string _ErrorText = string.Empty;
        public bool Error { get { return _Error; } }
        public string ErrorText { get { return _ErrorText; } }
        protected string GetConnectionString(string Empresa, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
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
                SQL = "SELECT * FROM agencias_cadastro WHERE ";
                SQL += "conexao_nome = '" + Empresa.SQLFilter() + "'";
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
                    conexao_driver = oRow.Field<string>("conexao_driver");
                    conexao_server = oRow.Field<string>("conexao_server");
                    conexao_database = oRow.Field<string>("conexao_database");
                    conexao_port = oRow.Field<object>("conexao_port").ToString();
                    conexao_user = oRow.Field<string>("conexao_user");
                    conexao_password = Crypto.DecryptString(oRow.Field<string>("conexao_password"));

                    //*************************
                    //* Define nome da empresa
                    //*************************
                    LoginInfo.Master_Empresa = oRow.Field<string>("conexao_nome");

                    //**********************************
                    //* Define código master da empresa 
                    //**********************************
                    LoginInfo.Master_Codigo = Convert.ToInt32(oRow.Field<object>("codigo"));

                    //**************************************
                    //* Define string de conexão da empresa
                    //**************************************
                    LoginInfo.Master_ConexaoString = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                                                   conexao_driver, conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);

                    LoginInfo.Master_DevArtConexaoString = String.Format("Host={0};Database={1};Port={2};User Id={3};Password={4};persist security info=True;",
                                                                          conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);

                    //***********************************
                    //* Define conexão para continuidade 
                    //***********************************
                    oDB.SetConnection(LoginInfo.Master_ConexaoString);
                    oTable.Reset();

                    //*********************
                    //* A conexão é válida
                    //*********************
                    _ErrorText = "";
                    _Error = false;
                    return "Ok";
                }
                else
                {
                    //*********************
                    //* Realiza desconexão
                    //*********************
                    LogOff();

                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    _ErrorText = "Identificação de cliente inexistente.";
                    _Error = true;
                    return "Error";
                }
            }

            catch (Exception oException)
            {
                //*********************
                //* Realiza desconexão
                //*********************
                LogOff();

                //******************************
                //* Anula dados e retorna falha
                //******************************
                _ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                _Error = true;
                return "Error";
            }
        }
        public Login_Fields GetRecord(Int32 CodigoUsuario, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            Login_Fields oLoginFields = new Login_Fields();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                SQL = "SELECT ";
                SQL += "usuarios.codusuario,";
                SQL += "usuarios.codgrupo,";
                SQL += "usuarios.codposto,";
                SQL += "usuarios.codpromotor,";
                SQL += "usuarios.nome,";
                SQL += "usuarios.usuario,";
                SQL += "usuarios.senha,";
                SQL += "usuarios.supervisor,";
                SQL += "usuarios.telefone,";
                SQL += "usuarios.email_endereco,";
                SQL += "usuarios.email_copia,";
                SQL += "usuarios.ativo,";
                SQL += "posto.descposto,";
                SQL += "posto.nomeposto,";
                SQL += "grupos.descgrupo,";
                SQL += "promotor.nomepromotor,";
                SQL += "smtp_autenticacao,";
                SQL += "smtp_endereco,";
                SQL += "smtp_porta,";
                SQL += "smtp_usuario,";
                SQL += "smtp_senha,";
                SQL += "smtp_ssl,";
                SQL += "smtp_tls ";
                SQL += "FROM usuarios ";
                SQL += "LEFT JOIN grupos ON grupos.codgrupo = usuarios.codgrupo ";
                SQL += "LEFT JOIN posto ON posto.postoven = usuarios.codposto ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = usuarios.codpromotor ";
                SQL += "WHERE ";
                SQL += "codusuario = " + CodigoUsuario;
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count == 1)
                {
                    //************************
                    //* O usuário está ativo?
                    //************************
                    DataRow oRow = oTable.Rows[0];

                    //************************
                    //* Define dados do login
                    //************************
                    oLoginFields.Posto_Codigo = DBNull.Value.Equals(oRow["codposto"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codposto"));
                    oLoginFields.Posto_Descricao = DBNull.Value.Equals(oRow["descposto"]) ? string.Empty : oRow.Field<string>("descposto");
                    oLoginFields.Posto_Nome = DBNull.Value.Equals(oRow["nomeposto"]) ? string.Empty : oRow.Field<string>("nomeposto");
                    oLoginFields.Usuario_Codigo = DBNull.Value.Equals(oRow["codusuario"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codusuario"));
                    oLoginFields.Usuario_CodigoGrupo = DBNull.Value.Equals(oRow["codgrupo"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codgrupo"));
                    oLoginFields.Usuario_DescGrupo = DBNull.Value.Equals(oRow["descgrupo"]) ? string.Empty : oRow.Field<string>("descgrupo");
                    oLoginFields.Usuario_CodigoPromotor = DBNull.Value.Equals(oRow["codpromotor"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codpromotor"));
                    oLoginFields.Usuario_NomePromotor = DBNull.Value.Equals(oRow["nomepromotor"]) ? string.Empty : oRow.Field<string>("nomepromotor");
                    oLoginFields.Usuario_EmailEndereco = DBNull.Value.Equals(oRow["email_endereco"]) ? string.Empty : oRow.Field<string>("email_endereco").ToLower();
                    oLoginFields.Usuario_EmailCopia = DBNull.Value.Equals(oRow["email_copia"]) ? false : Convert.ToBoolean(oRow.Field<object>("email_copia"));
                    oLoginFields.Usuario_ID = DBNull.Value.Equals(oRow["usuario"]) ? string.Empty : oRow.Field<string>("usuario").ToLower();
                    oLoginFields.Usuario_Nome = DBNull.Value.Equals(oRow["nome"]) ? string.Empty : oRow.Field<string>("nome");
                    oLoginFields.Usuario_Senha = Crypto.DecryptString(DBNull.Value.Equals(oRow["senha"]) ? string.Empty : oRow.Field<string>("senha"));
                    oLoginFields.Usuario_Supervisor = DBNull.Value.Equals(oRow["supervisor"]) ? false : Convert.ToBoolean(oRow.Field<object>("supervisor"));
                    oLoginFields.Usuario_Telefone = DBNull.Value.Equals(oRow["telefone"]) ? string.Empty : oRow.Field<string>("telefone");
                    oLoginFields.Usuario_Ativo = DBNull.Value.Equals(oRow["ativo"]) ? false : Convert.ToBoolean(oRow.Field<object>("ativo"));
                    oLoginFields.SMTP_autenticacao = DBNull.Value.Equals(oRow["smtp_autenticacao"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_autenticacao"));
                    oLoginFields.SMTP_endereco = DBNull.Value.Equals(oRow["smtp_endereco"]) ? string.Empty : oRow.Field<string>("smtp_endereco");
                    oLoginFields.SMTP_porta = DBNull.Value.Equals(oRow["smtp_porta"]) ? 0 : Convert.ToInt32(oRow.Field<object>("smtp_porta"));
                    oLoginFields.SMTP_usuario = DBNull.Value.Equals(oRow["smtp_usuario"]) ? string.Empty : oRow.Field<string>("smtp_usuario");
                    oLoginFields.SMTP_senha = DBNull.Value.Equals(oRow["smtp_senha"]) ? string.Empty : Crypto.DecryptString(oRow.Field<string>("smtp_senha"));
                    oLoginFields.SMTP_ssl = DBNull.Value.Equals(oRow["smtp_ssl"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_ssl"));
                    oLoginFields.SMTP_tls = DBNull.Value.Equals(oRow["smtp_tls"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_tls"));

                    //********************
                    //* Retorna status OK
                    //********************
                    oLoginFields.ErrorText = string.Empty;
                    oLoginFields.Error = false;
                    return oLoginFields;
                }
                else
                {
                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    oLoginFields.ErrorText = "Usuário inexistente.";
                    oLoginFields.Error = true;
                    return oLoginFields;
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                oLoginFields.ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                oLoginFields.Error = true;
                return oLoginFields;
            }
        }
        public List<Login_Fields> GetGroupUsers(Int32 CodigoGrupo, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            List<Login_Fields> UserCollection = new List<Login_Fields>();
            Login_Fields oLoginFields = new Login_Fields();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                SQL = "SELECT ";
                SQL += "usuarios.codusuario,";
                SQL += "usuarios.codgrupo,";
                SQL += "usuarios.codposto,";
                SQL += "usuarios.codpromotor,";
                SQL += "usuarios.nome,";
                SQL += "usuarios.usuario,";
                SQL += "usuarios.senha,";
                SQL += "usuarios.supervisor,";
                SQL += "usuarios.telefone,";
                SQL += "usuarios.email_endereco,";
                SQL += "usuarios.email_copia,";
                SQL += "usuarios.ativo,";
                SQL += "posto.descposto,";
                SQL += "posto.nomeposto,";
                SQL += "grupos.descgrupo,";
                SQL += "promotor.nomepromotor,";
                SQL += "smtp_autenticacao,";
                SQL += "smtp_endereco,";
                SQL += "smtp_porta,";
                SQL += "smtp_usuario,";
                SQL += "smtp_senha,";
                SQL += "smtp_ssl,";
                SQL += "smtp_tls ";
                SQL += "FROM usuarios ";
                SQL += "LEFT JOIN grupos ON grupos.codgrupo = usuarios.codgrupo ";
                SQL += "LEFT JOIN posto ON posto.postoven = usuarios.codposto ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = usuarios.codpromotor ";
                SQL += "WHERE usuarios.codgrupo = " + CodigoGrupo + " ";
                SQL += "ORDER BY usuarios.usuario";
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count > 0)
                {
                    //************************
                    //* O usuário está ativo?
                    //************************
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        //************************
                        //* Define dados do login
                        //************************
                        oLoginFields = new Login_Fields();
                        oLoginFields.Posto_Codigo = DBNull.Value.Equals(oRow["codposto"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codposto"));
                        oLoginFields.Posto_Descricao = DBNull.Value.Equals(oRow["descposto"]) ? string.Empty : oRow.Field<string>("descposto");
                        oLoginFields.Posto_Nome = DBNull.Value.Equals(oRow["nomeposto"]) ? string.Empty : oRow.Field<string>("nomeposto");
                        oLoginFields.Usuario_Codigo = DBNull.Value.Equals(oRow["codusuario"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codusuario"));
                        oLoginFields.Usuario_CodigoGrupo = DBNull.Value.Equals(oRow["codgrupo"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codgrupo"));
                        oLoginFields.Usuario_DescGrupo = DBNull.Value.Equals(oRow["descgrupo"]) ? string.Empty : oRow.Field<string>("descgrupo");
                        oLoginFields.Usuario_CodigoPromotor = DBNull.Value.Equals(oRow["codpromotor"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codpromotor"));
                        oLoginFields.Usuario_NomePromotor = DBNull.Value.Equals(oRow["nomepromotor"]) ? string.Empty : oRow.Field<string>("nomepromotor");
                        oLoginFields.Usuario_EmailEndereco = DBNull.Value.Equals(oRow["email_endereco"]) ? string.Empty : oRow.Field<string>("email_endereco").ToLower();
                        oLoginFields.Usuario_EmailCopia = DBNull.Value.Equals(oRow["email_copia"]) ? false : Convert.ToBoolean(oRow.Field<object>("email_copia"));
                        oLoginFields.Usuario_ID = DBNull.Value.Equals(oRow["usuario"]) ? string.Empty : oRow.Field<string>("usuario").ToLower();
                        oLoginFields.Usuario_Nome = DBNull.Value.Equals(oRow["nome"]) ? string.Empty : oRow.Field<string>("nome");
                        oLoginFields.Usuario_Senha = Crypto.DecryptString(DBNull.Value.Equals(oRow["senha"]) ? string.Empty : oRow.Field<string>("senha"));
                        oLoginFields.Usuario_Supervisor = DBNull.Value.Equals(oRow["supervisor"]) ? false : Convert.ToBoolean(oRow.Field<object>("supervisor"));
                        oLoginFields.Usuario_Telefone = DBNull.Value.Equals(oRow["telefone"]) ? string.Empty : oRow.Field<string>("telefone");
                        oLoginFields.Usuario_Ativo = DBNull.Value.Equals(oRow["ativo"]) ? false : Convert.ToBoolean(oRow.Field<object>("ativo"));
                        oLoginFields.SMTP_autenticacao = DBNull.Value.Equals(oRow["smtp_autenticacao"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_autenticacao"));
                        oLoginFields.SMTP_endereco = DBNull.Value.Equals(oRow["smtp_endereco"]) ? string.Empty : oRow.Field<string>("smtp_endereco");
                        oLoginFields.SMTP_porta = DBNull.Value.Equals(oRow["smtp_porta"]) ? 0 : Convert.ToInt32(oRow.Field<object>("smtp_porta"));
                        oLoginFields.SMTP_usuario = DBNull.Value.Equals(oRow["smtp_usuario"]) ? string.Empty : oRow.Field<string>("smtp_usuario");
                        oLoginFields.SMTP_senha = DBNull.Value.Equals(oRow["smtp_senha"]) ? string.Empty : Crypto.DecryptString(oRow.Field<string>("smtp_senha"));
                        oLoginFields.SMTP_ssl = DBNull.Value.Equals(oRow["smtp_ssl"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_ssl"));
                        oLoginFields.SMTP_tls = DBNull.Value.Equals(oRow["smtp_tls"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_tls"));
                        UserCollection.Add(oLoginFields);
                    }

                    //********************
                    //* Retorna status OK
                    //********************
                    oLoginFields.ErrorText = string.Empty;
                    oLoginFields.Error = false;
                    return UserCollection;
                }
                else
                {
                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    oLoginFields.ErrorText = "Usuário inexistente.";
                    oLoginFields.Error = true;
                    return UserCollection;
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                oLoginFields.ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                oLoginFields.Error = true;
                return UserCollection;
            }
        }
        public List<Login_Fields> GetAdmins(string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            List<Login_Fields> AdminCollection = new List<Login_Fields>();
            Login_Fields oLoginFields = new Login_Fields();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                SQL = "SELECT ";
                SQL += "usuarios.codusuario,";
                SQL += "usuarios.codgrupo,";
                SQL += "usuarios.codposto,";
                SQL += "usuarios.codpromotor,";
                SQL += "usuarios.nome,";
                SQL += "usuarios.usuario,";
                SQL += "usuarios.senha,";
                SQL += "usuarios.supervisor,";
                SQL += "usuarios.telefone,";
                SQL += "usuarios.email_endereco,";
                SQL += "usuarios.email_copia,";
                SQL += "usuarios.ativo,";
                SQL += "posto.descposto,";
                SQL += "posto.nomeposto,";
                SQL += "grupos.descgrupo,";
                SQL += "promotor.nomepromotor,";
                SQL += "smtp_autenticacao,";
                SQL += "smtp_endereco,";
                SQL += "smtp_porta,";
                SQL += "smtp_usuario,";
                SQL += "smtp_senha,";
                SQL += "smtp_ssl,";
                SQL += "smtp_tls ";
                SQL += "FROM usuarios ";
                SQL += "LEFT JOIN grupos ON grupos.codgrupo = usuarios.codgrupo ";
                SQL += "LEFT JOIN posto ON posto.postoven = usuarios.codposto ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = usuarios.codpromotor ";
                SQL += "WHERE ";
                SQL += "supervisor <> 0 ";
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count > 0)
                {
                    //************************
                    //* O usuário está ativo?
                    //************************
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        //************************
                        //* Define dados do login
                        //************************
                        oLoginFields = new Login_Fields();
                        oLoginFields.Posto_Codigo = DBNull.Value.Equals(oRow["codposto"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codposto"));
                        oLoginFields.Posto_Descricao = DBNull.Value.Equals(oRow["descposto"]) ? string.Empty : oRow.Field<string>("descposto");
                        oLoginFields.Posto_Nome = DBNull.Value.Equals(oRow["nomeposto"]) ? string.Empty : oRow.Field<string>("nomeposto");
                        oLoginFields.Usuario_Codigo = DBNull.Value.Equals(oRow["codusuario"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codusuario"));
                        oLoginFields.Usuario_CodigoGrupo = DBNull.Value.Equals(oRow["codgrupo"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codgrupo"));
                        oLoginFields.Usuario_DescGrupo = DBNull.Value.Equals(oRow["descgrupo"]) ? string.Empty : oRow.Field<string>("descgrupo");
                        oLoginFields.Usuario_CodigoPromotor = DBNull.Value.Equals(oRow["codpromotor"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codpromotor"));
                        oLoginFields.Usuario_NomePromotor = DBNull.Value.Equals(oRow["nomepromotor"]) ? string.Empty : oRow.Field<string>("nomepromotor");
                        oLoginFields.Usuario_EmailEndereco = DBNull.Value.Equals(oRow["email_endereco"]) ? string.Empty : oRow.Field<string>("email_endereco").ToLower();
                        oLoginFields.Usuario_EmailCopia = DBNull.Value.Equals(oRow["email_copia"]) ? false : Convert.ToBoolean(oRow.Field<object>("email_copia"));
                        oLoginFields.Usuario_ID = DBNull.Value.Equals(oRow["usuario"]) ? string.Empty : oRow.Field<string>("usuario").ToLower();
                        oLoginFields.Usuario_Nome = DBNull.Value.Equals(oRow["nome"]) ? string.Empty : oRow.Field<string>("nome");
                        oLoginFields.Usuario_Senha = Crypto.DecryptString(DBNull.Value.Equals(oRow["senha"]) ? string.Empty : oRow.Field<string>("senha"));
                        oLoginFields.Usuario_Supervisor = DBNull.Value.Equals(oRow["supervisor"]) ? false : Convert.ToBoolean(oRow.Field<object>("supervisor"));
                        oLoginFields.Usuario_Telefone = DBNull.Value.Equals(oRow["telefone"]) ? string.Empty : oRow.Field<string>("telefone");
                        oLoginFields.Usuario_Ativo = DBNull.Value.Equals(oRow["ativo"]) ? false : Convert.ToBoolean(oRow.Field<object>("ativo"));
                        oLoginFields.SMTP_autenticacao = DBNull.Value.Equals(oRow["smtp_autenticacao"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_autenticacao"));
                        oLoginFields.SMTP_endereco = DBNull.Value.Equals(oRow["smtp_endereco"]) ? string.Empty : oRow.Field<string>("smtp_endereco");
                        oLoginFields.SMTP_porta = DBNull.Value.Equals(oRow["smtp_porta"]) ? 0 : Convert.ToInt32(oRow.Field<object>("smtp_porta"));
                        oLoginFields.SMTP_usuario = DBNull.Value.Equals(oRow["smtp_usuario"]) ? string.Empty : oRow.Field<string>("smtp_usuario");
                        oLoginFields.SMTP_senha = DBNull.Value.Equals(oRow["smtp_senha"]) ? string.Empty : Crypto.DecryptString(oRow.Field<string>("smtp_senha"));
                        oLoginFields.SMTP_ssl = DBNull.Value.Equals(oRow["smtp_ssl"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_ssl"));
                        oLoginFields.SMTP_tls = DBNull.Value.Equals(oRow["smtp_tls"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_tls"));
                        AdminCollection.Add(oLoginFields);
                    }

                    //********************
                    //* Retorna status OK
                    //********************
                    oLoginFields.ErrorText = string.Empty;
                    oLoginFields.Error = false;
                    return AdminCollection;
                }
                else
                {
                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    oLoginFields.ErrorText = "Usuário inexistente.";
                    oLoginFields.Error = true;
                    return AdminCollection;
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                oLoginFields.ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                oLoginFields.Error = true;
                return AdminCollection;
            }
        }
        public string ExistingDatabase(string Empresa, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************************
            //* Tenta obter conexão para a empresa atual
            //*******************************************
            if (GetConnectionString(Empresa, ConnectionString) != "Ok")
            {
                //***********************
                //* A empresa não existe
                //***********************
                return "false";
            }
            else
            {
                //*********************
                //* Empresa localizada
                //*********************
                return "true";
            }
        }
        public string ExistingUser(string Empresa, string Username, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************************
            //* Define conexão à base de dados da empresa
            //********************************************
            if (GetConnectionString(Empresa, oDB.ConnectionString) != "Ok")
            {
                //************************
                //* Usuário já cadastrado
                //************************
                return "false";
            }

            //*******************
            //* Redefine conexão
            //*******************
            oDB.SetConnection(LoginInfo.Master_ConexaoString);

            //**************************
            //* Tenta localizar usuário
            //**************************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                SQL = "SELECT usuarios.codusuario FROM usuarios ";
                SQL += "WHERE usuario = '" + Username.SQLFilter() + "'";
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count == 1)
                {
                    //**********************
                    //* Retorna status TRUE
                    //**********************
                    return "true";
                }
                else
                {
                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    return "false";
                }
            }
            catch
            {
                //******************************************
                //* Se houver falha, retorna como existente
                //******************************************
                return "true";
            }
        }
        public Login_Fields ExistingUser(Login_Fields oLoginInfo, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************************
            //* Tenta localizar usuário
            //**************************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                SQL = "SELECT usuarios.codusuario FROM usuarios WHERE ";
                SQL += "usuario = '" + oLoginInfo.Usuario_ID.SQLFilter() + "' ";
                if (oLoginInfo.Usuario_Codigo != 0)
                    SQL += "AND codusuario <> " + oLoginInfo.Usuario_Codigo;
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count == 1)
                {
                    //**********************
                    //* Retorna status ERRO
                    //**********************
                    oLoginInfo.ErrorText = "Usuário já cadastrado";
                    oLoginInfo.Error = true;
                    return oLoginInfo;
                }
                else
                {
                    //*************
                    //* Retorna OK
                    //*************
                    oLoginInfo.ErrorText = string.Empty;
                    oLoginInfo.Error = false;
                    return oLoginInfo;
                }
            }
            catch (Exception oException)
            {
                //****************************
                //* Retorna falha de execução
                //****************************
                oLoginInfo.ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                oLoginInfo.Error = true;
                return oLoginInfo;
            }
        }
        public Login_Fields ApplyRecord(Login_Fields oLoginInfo, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //***********************
                //* O usuário já existe?
                //***********************
                if (oLoginInfo.Usuario_Codigo == 0)
                {
                    //***************************
                    //* Cria registro do usuário
                    //***************************
                    SQL = "INSERT INTO usuarios (";
                    SQL += "codgrupo,";
                    SQL += "codposto,";
                    SQL += "codpromotor,";
                    SQL += "nome,";
                    SQL += "usuario,";
                    SQL += "senha,";
                    SQL += "supervisor,";
                    SQL += "telefone,";
                    SQL += "email_endereco,";
                    SQL += "email_copia,";
                    SQL += "ativo,";
                    SQL += "smtp_autenticacao,";
                    SQL += "smtp_endereco,";
                    SQL += "smtp_porta,";
                    SQL += "smtp_usuario,";
                    SQL += "smtp_senha,";
                    SQL += "smtp_ssl,";
                    SQL += "smtp_tls ";
                    SQL += ") VALUES (";
                    SQL += oLoginInfo.Usuario_CodigoGrupo + ",";
                    SQL += oLoginInfo.Posto_Codigo + ",";
                    SQL += oLoginInfo.Usuario_CodigoPromotor + ",";
                    SQL += "'" + oLoginInfo.Usuario_Nome.SQLFilter() + "',";
                    SQL += "'" + oLoginInfo.Usuario_ID.SQLFilter() + "',";
                    SQL += "'" + Crypto.EncryptString(oLoginInfo.Usuario_Senha.SQLFilter()) + "',";
                    SQL += Convert.ToInt16(oLoginInfo.Usuario_Supervisor) + ",";
                    SQL += "'" + oLoginInfo.Usuario_Telefone.SQLFilter() + "',";
                    SQL += "'" + oLoginInfo.Usuario_EmailEndereco.SQLFilter() + "',";
                    SQL += Convert.ToInt16(oLoginInfo.Usuario_EmailCopia) + ",";
                    SQL += Convert.ToInt16(oLoginInfo.Usuario_Ativo) + ",";
                    SQL += Convert.ToInt16(oLoginInfo.SMTP_autenticacao) + ",";
                    SQL += "'" + oLoginInfo.SMTP_endereco.SQLFilter() + "',";
                    SQL += Convert.ToInt32(oLoginInfo.SMTP_porta) + ",";
                    SQL += "'" + oLoginInfo.SMTP_usuario.SQLFilter() + "',";
                    SQL += "'" + Crypto.EncryptString(oLoginInfo.SMTP_senha).SQLFilter() + "',";
                    SQL += Convert.ToInt16(oLoginInfo.SMTP_ssl) + ",";
                    SQL += Convert.ToInt16(oLoginInfo.SMTP_tls) + ")";
                    oLoginInfo.Usuario_Codigo = oDB.ExecuteCommand(SQL);

                    //********************
                    //* Retorna status OK
                    //********************
                    oLoginInfo.ErrorText = string.Empty;
                    oLoginInfo.Error = false;
                    return oLoginInfo;
                }
                else
                {
                    //*******************************
                    //* Atualiza registro do usuário
                    //*******************************
                    SQL = "UPDATE usuarios SET ";
                    SQL += "codgrupo = " + oLoginInfo.Usuario_CodigoGrupo + ",";
                    SQL += "codposto = " + oLoginInfo.Posto_Codigo + ",";
                    SQL += "codpromotor = " + oLoginInfo.Usuario_CodigoPromotor + ",";
                    SQL += "nome = '" + oLoginInfo.Usuario_Nome.SQLFilter() + "',";
                    SQL += "usuario = '" + oLoginInfo.Usuario_ID.SQLFilter() + "',";
                    SQL += "senha = '" + Crypto.EncryptString(oLoginInfo.Usuario_Senha.SQLFilter()) + "',";
                    SQL += "supervisor = " + Convert.ToInt16(oLoginInfo.Usuario_Supervisor) + ",";
                    SQL += "telefone = '" + oLoginInfo.Usuario_Telefone.SQLFilter() + "',";
                    SQL += "email_endereco = '" + oLoginInfo.Usuario_EmailEndereco.SQLFilter() + "',";
                    SQL += "email_copia = " + Convert.ToInt16(oLoginInfo.Usuario_EmailCopia) + ",";
                    SQL += "ativo = " + Convert.ToInt16(oLoginInfo.Usuario_Ativo) + ",";
                    SQL += "smtp_autenticacao=" + Convert.ToInt16(oLoginInfo.SMTP_autenticacao) + ",";
                    SQL += "smtp_endereco='" + oLoginInfo.SMTP_endereco.SQLFilter() + "',";
                    SQL += "smtp_porta=" + Convert.ToInt32(oLoginInfo.SMTP_porta) + ",";
                    SQL += "smtp_usuario='" + oLoginInfo.SMTP_usuario.SQLFilter() + "',";
                    SQL += "smtp_senha='" + Crypto.EncryptString(oLoginInfo.SMTP_senha).SQLFilter() + "',";
                    SQL += "smtp_ssl=" + Convert.ToInt16(oLoginInfo.SMTP_ssl) + ",";
                    SQL += "smtp_tls=" + Convert.ToInt16(oLoginInfo.SMTP_tls) + " ";
                    SQL += "WHERE codusuario = " + oLoginInfo.Usuario_Codigo;
                    oDB.ExecuteCommand(SQL);

                    //********************
                    //* Retorna status OK
                    //********************
                    oLoginInfo.ErrorText = string.Empty;
                    oLoginInfo.Error = false;
                    return oLoginInfo;
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                oLoginInfo.ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                oLoginInfo.Error = true;
                return oLoginInfo;
            }
        }
        public Login_Fields DeleteUser(Int32 CodigoUsuario, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            Login_Fields oLoginFields = new Login_Fields();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //***********************
                //* O usuário já existe?
                //***********************
                SQL = "SELECT codusuario FROM usuarios WHERE ";
                SQL += "usuarios.codusuario = '" + CodigoUsuario + "'";
                oTable = oDB.ExecuteQuery(SQL);
                if (oTable.Rows.Count != 0)
                {
                    //***************************
                    //* Cria registro de usuário
                    //***************************
                    SQL = "DELETE FROM usuarios WHERE usuarios.codusuario = " + CodigoUsuario;
                    oDB.ExecuteCommand(SQL);

                    //********************
                    //* Retorna status OK
                    //********************
                    _ErrorText = string.Empty;
                    _Error = false;
                    return oLoginFields;
                }
                else
                {
                    //*************************
                    //* Usuário não localizado
                    //*************************
                    _ErrorText = "Usuário não localizado!";
                    _Error = true;
                    return oLoginFields;
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                _ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                _Error = true;
                return oLoginFields;
            }
        }
        public string CreateUser(string Empresa, string Usuario, string Senha, string Email, string Telefone, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************************
            //* Define conexão à base de dados da empresa
            //********************************************
            if (GetConnectionString(Empresa, ConnectionString) != "Ok")
            {
                //************************
                //* Usuário já cadastrado
                //************************
                _ErrorText = "Empresa não localizada";
                _Error = true;
                return "false";
            }

            //*******************
            //* Redefine conexão
            //*******************
            oDB.SetConnection(LoginInfo.Master_ConexaoString);

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //***********************
                //* O usuário já existe?
                //***********************
                SQL = "SELECT codusuario FROM usuarios WHERE ";
                SQL += "usuarios.usuario = '" + Usuario.SQLFilter() + "'";
                oTable = oDB.ExecuteQuery(SQL);
                if (oTable.Rows.Count == 0)
                {
                    //****************************
                    //* Cria registro de promotor
                    //****************************
                    SQL = "INSERT INTO promotor (";
                    SQL += "nomepromotor,";
                    SQL += "end,";
                    SQL += "fone1,";
                    SQL += "ramalfone1,";
                    SQL += "fone2,";
                    SQL += "ramalfone2,";
                    SQL += "fax,";
                    SQL += "ramalfax,";
                    SQL += "cep,";
                    SQL += "codcidade,";
                    SQL += "tipo,";
                    SQL += "email,";
                    SQL += "http,";
                    SQL += "obs,";
                    SQL += "status,";
                    SQL += "codrestrito";
                    SQL += ") VALUES (";
                    SQL += "'" + Usuario.SQLFilter() + "',";
                    SQL += "'',";
                    SQL += "'" + Telefone.SQLFilter() + "',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "0,";
                    SQL += "'',";
                    SQL += "'" + Email.SQLFilter() + "',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "0)";
                    Int32 CodigoPromotor = oDB.ExecuteCommand(SQL);

                    //***************************
                    //* Cria registro de usuário
                    //***************************
                    SQL = "INSERT INTO usuarios (";
                    SQL += "codgrupo,";
                    SQL += "codposto,";
                    SQL += "codpromotor,";
                    SQL += "nome,";
                    SQL += "usuario,";
                    SQL += "senha,";
                    SQL += "supervisor,";
                    SQL += "telefone,";
                    SQL += "email_endereco,";
                    SQL += "email_copia,";
                    SQL += "ativo,";
                    SQL += "smtp_autenticacao,";
                    SQL += "smtp_endereco,";
                    SQL += "smtp_porta,";
                    SQL += "smtp_usuario,";
                    SQL += "smtp_senha,";
                    SQL += "smtp_ssl,";
                    SQL += "smtp_tls ";
                    SQL += ") VALUES (";
                    SQL += "0,";
                    SQL += "1,";
                    SQL += CodigoPromotor + ",";
                    SQL += "'" + Usuario.SQLFilter() + "',";
                    SQL += "'" + Usuario.SQLFilter() + "',";
                    SQL += "'" + Crypto.EncryptString(Senha.SQLFilter()) + "',";
                    SQL += "0,";
                    SQL += "'" + Telefone.SQLFilter() + "',";
                    SQL += "'" + Email.SQLFilter() + "',";
                    SQL += "1,";
                    SQL += "1,";
                    SQL += "0,";
                    SQL += "'',";
                    SQL += "0,";
                    SQL += "'',";
                    SQL += "'',";
                    SQL += "0,";
                    SQL += "0)";
                    oDB.ExecuteCommand(SQL);

                    //********************
                    //* Retorna status OK
                    //********************
                    _ErrorText = string.Empty;
                    _Error = false;
                    return "true";
                }
                else
                {
                    //************************
                    //* Usuário já cadastrado
                    //************************
                    _ErrorText = "Usuário já cadastrado!";
                    _Error = true;
                    return "false";
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                _ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                _Error = true;
                return "false";
            }
        }
        public string PasswordUpdate(string Empresa, string Usuario, string SenhaAtual, string NovaSenha, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************************
            //* Define conexão à base de dados da empresa
            //********************************************
            if (GetConnectionString(Empresa, ConnectionString) != "Ok")
            {
                //************************
                //* Usuário já cadastrado
                //************************
                _ErrorText = "Empresa não localizada";
                _Error = true;
                return "Error";
            }

            //*******************
            //* Redefine conexão
            //*******************
            oDB.SetConnection(LoginInfo.Master_ConexaoString);

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //***********************
                //* O usuário já existe?
                //***********************
                SQL = "SELECT codusuario FROM usuarios WHERE ";
                SQL += "usuarios.usuario = '" + Usuario.SQLFilter() + "' AND ";
                SQL += "usuarios.senha = '" + Crypto.EncryptString(SenhaAtual).SQLFilter() + "'";
                oTable = oDB.ExecuteQuery(SQL);
                if (oTable.Rows.Count == 1)
                {
                    //****************
                    //* Obtem usuário
                    //****************
                    SQL = "UPDATE usuarios SET ";
                    SQL += "senha = '" + Crypto.EncryptString(NovaSenha).SQLFilter() + "' ";
                    SQL += "WHERE codusuario = " + oTable.Rows[0]["codusuario"];
                    oDB.ExecuteCommand(SQL);

                    //********************
                    //* Retorna status OK
                    //********************
                    _ErrorText = string.Empty;
                    _Error = false;
                    return "Ok";
                }
                else
                {
                    //************************
                    //* Usuário já cadastrado
                    //************************
                    _ErrorText = "A senha atual não está correta.";
                    _Error = true;
                    return "Error";
                }
            }
            catch (Exception oException)
            {
                //***************************
                //* Retorna falha de criação
                //***************************
                _ErrorText = "Falha de sistema: " + oException.Message + " / " + oException.Source;
                _Error = true;
                return "Error";
            }
        }
        public string PasswordRecovery(string Usuario, string Email, string ConnectionString, ref List<PasswordRecoveryUserList> oList)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDBMaster = new DBManager(ConnectionString);
            DBManager oDBEmpresa = new DBManager("");
            DataTable oTableEmpresas = new DataTable();
            DataTable oTableUsuarios = new DataTable();
            string SQL = string.Empty;
            bool Localizado = false;

            //*************
            //* Zera lista
            //*************
            oList.Clear();

            //***********************************
            //* O nome do usuário foi informado?
            //***********************************
            if (Usuario == string.Empty)
            {
                _ErrorText = "usuario: Usuáro não informado";
                _Error = true;
                return _ErrorText;
            }

            //**************************************
            //* O endereço de e-mail foi informado?
            //**************************************
            if (Email == string.Empty)
            {
                _ErrorText = "email: Endereço de e-mail não informado";
                _Error = true;
                return _ErrorText;
            }

            //*****************
            //* Controla erros
            //*****************
            try
            {

                //**************************
                //* Obtem lista de empresas
                //**************************
                SQL = "SELECT codigo, conexao_nome FROM agencias_cadastro;";
                oTableEmpresas = oDBMaster.ExecuteQuery(SQL);

                //*****************************
                //* Percorre lista de empresas
                //*****************************
                foreach (DataRow oRowEmpresa in oTableEmpresas.Rows)
                {
                    //*******************
                    //* Redefine conexao
                    //*******************
                    if (GetConnectionString(oRowEmpresa["conexao_nome"].ToString(), ConnectionString) == "Ok")
                    {
                        //**********************
                        //* Define nova conexão
                        //**********************
                        oDBEmpresa.SetConnection(LoginInfo.Master_ConexaoString);

                        //**********************************
                        //* Localiza nome e-mail do usuário
                        //**********************************
                        SQL = "SELECT codposto, nome, senha FROM usuarios WHERE ";
                        SQL += "usuario = '" + Usuario.SQLFilter() + "' AND ";
                        SQL += "email_endereco = '" + Email.SQLFilter() + "'";
                        oTableUsuarios = oDBEmpresa.ExecuteQuery(SQL);

                        //*****************************
                        //* Percorre lista de usuários
                        //*****************************
                        foreach (DataRow oRowUsuario in oTableUsuarios.Rows)
                        {
                            //**************************************
                            //* Envia comunicado para usuário atual
                            //**************************************
                            oList.Add(new PasswordRecoveryUserList(Convert.ToInt32(oRowEmpresa["codigo"]),
                                                                   Convert.ToInt32(oRowUsuario["codposto"].ToString()),
                                                                   oRowEmpresa["conexao_nome"].ToString(),
                                                                   oRowUsuario["nome"].ToString(),
                                                                   Email,
                                                                   Usuario,
                                                                   Crypto.DecryptString(oRowUsuario["senha"].ToString())));
                            //**********************
                            //* Define como enviado
                            //**********************
                            Localizado = true;
                        }
                    }
                }

                //******************************
                //* Os dados foram localizados?
                //******************************
                if (Localizado == true)
                {
                    //*************
                    //* Devolve OK
                    //*************
                    _ErrorText = string.Empty;
                    _Error = false;
                    return "Ok";
                }
                else
                {
                    //*****************
                    //* Não localizado
                    //*****************
                    _ErrorText = "usuario: Não foi possível localizar seus dados de acesso";
                    _Error = true;
                    return _ErrorText;
                }
            }
            catch (Exception oException)
            {
                //****************
                //* Devolve falha
                //****************
                _ErrorText = oException.Message;
                _Error = true;
                return _ErrorText;
            }
        }
        public string Login(string Empresa, string Usuario, string Senha, string ConnectionString)
        {
            //********************
            //* Declara variáveis
            //********************
            DBManager oDB = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            DataRow oRow;

            //********************************************
            //* Define conexão à base de dados da empresa
            //********************************************
            if (GetConnectionString(Empresa, ConnectionString) != "Ok")
            {
                //************************
                //* Usuário já cadastrado
                //************************
                if (Empresa != string.Empty)
                {
                    _ErrorText = "empresa: Empresa não localizada";
                    _Error = true;
                }
                else
                {
                    _ErrorText = "empresa: Informe o nome da empresa";
                    _Error = true;
                }
                return _ErrorText;
            }

            //*******************
            //* Redefine conexão
            //*******************
            oDB.SetConnection(LoginInfo.Master_ConexaoString);

            //***********************
            //* Tenta executar login
            //***********************
            try
            {
                //****************
                //* Obtem usuário
                //****************
                string SQL = "SELECT ";
                SQL += "usuarios.codusuario,";
                SQL += "usuarios.codgrupo,";
                SQL += "usuarios.codposto,";
                SQL += "usuarios.nome,";
                SQL += "usuarios.usuario,";
                SQL += "usuarios.senha,";
                SQL += "usuarios.supervisor,";
                SQL += "usuarios.telefone,";
                SQL += "usuarios.email_endereco,";
                SQL += "usuarios.email_copia,";
                SQL += "usuarios.ativo,";
                SQL += "smtp_autenticacao,";
                SQL += "smtp_endereco,";
                SQL += "smtp_porta,";
                SQL += "smtp_usuario,";
                SQL += "smtp_senha,";
                SQL += "smtp_ssl,";
                SQL += "smtp_tls,";
                SQL += "promotor.codpromotor,";
                SQL += "promotor.nomepromotor,";
                SQL += "posto.descposto,";
                SQL += "posto.nomeposto,";
                SQL += "posto.logotipo,";
                SQL += "grupos.descgrupo ";
                SQL += "FROM usuarios ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = usuarios.codpromotor ";
                SQL += "LEFT JOIN grupos ON grupos.codgrupo = usuarios.codgrupo ";
                SQL += "LEFT JOIN posto ON posto.postoven = usuarios.codposto ";
                SQL += "WHERE usuario = '" + Usuario.SQLFilter() + "'";
                oTable = oDB.ExecuteQuery(SQL);

                //********************
                //* O usuário existe?
                //********************
                if (oTable.Rows.Count == 1)
                {
                    //************************
                    //* O usuário está ativo?
                    //************************
                    oRow = oTable.Rows[0];
                    if (Convert.ToBoolean(oRow.Field<object>("ativo")))
                    {
                        //********************
                        //* A senha á válida?
                        //********************
                        if (oRow.Field<string>("senha") == Crypto.EncryptString(Senha))
                        {
                            //************************
                            //* Define dados do login
                            //************************
                            LoginInfo.Posto_Codigo = DBNull.Value.Equals(oRow["codposto"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codposto"));
                            LoginInfo.Posto_Descricao = DBNull.Value.Equals(oRow["descposto"]) ? string.Empty : oRow.Field<string>("descposto").ToLower();
                            LoginInfo.Posto_Nome = DBNull.Value.Equals(oRow["nomeposto"]) ? string.Empty : oRow.Field<string>("nomeposto").ToLower();
                            LoginInfo.Posto_Logotipo = DBNull.Value.Equals(oRow["logotipo"]) ? null : BitMapUtil.ByteToImage(oRow.Field<byte[]>("logotipo"));
                            LoginInfo.Usuario_Codigo = DBNull.Value.Equals(oRow["codusuario"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codusuario"));
                            LoginInfo.Usuario_CodigoGrupo = DBNull.Value.Equals(oRow["codgrupo"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codgrupo"));
                            LoginInfo.Usuario_DescGrupo = DBNull.Value.Equals(oRow["descgrupo"]) ? string.Empty : oRow.Field<string>("descgrupo").ToLower();
                            LoginInfo.Usuario_NomePromotor = DBNull.Value.Equals(oRow["nomepromotor"]) ? string.Empty : oRow.Field<string>("nomepromotor").ToLower();
                            LoginInfo.Usuario_CodigoPromotor = DBNull.Value.Equals(oRow["codpromotor"]) ? 0 : Convert.ToInt32(oRow.Field<object>("codpromotor"));
                            LoginInfo.Usuario_EmailEndereco = DBNull.Value.Equals(oRow["email_endereco"]) ? string.Empty : oRow.Field<string>("email_endereco").ToLower();
                            LoginInfo.Usuario_EmailCopia = DBNull.Value.Equals(oRow["email_copia"]) ? false : Convert.ToBoolean(oRow.Field<object>("email_copia"));
                            LoginInfo.Usuario_ID = DBNull.Value.Equals(oRow["usuario"]) ? string.Empty : oRow.Field<string>("usuario").ToLower();
                            LoginInfo.Usuario_Nome = DBNull.Value.Equals(oRow["nome"]) ? string.Empty : oRow.Field<string>("nome").ToLower();
                            LoginInfo.Usuario_Senha = DBNull.Value.Equals(oRow["senha"]) ? string.Empty : oRow.Field<string>("senha").ToLower();
                            LoginInfo.Usuario_Supervisor = DBNull.Value.Equals(oRow["supervisor"]) ? false : Convert.ToBoolean(oRow.Field<object>("supervisor"));
                            LoginInfo.Usuario_Telefone = DBNull.Value.Equals(oRow["telefone"]) ? string.Empty : oRow.Field<string>("telefone").ToLower();
                            LoginInfo.Usuario_Ativo = DBNull.Value.Equals(oRow["ativo"]) ? false : Convert.ToBoolean(oRow.Field<object>("ativo"));
                            LoginInfo.SMTP_autenticacao = DBNull.Value.Equals(oRow["smtp_autenticacao"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_autenticacao"));
                            LoginInfo.SMTP_endereco = DBNull.Value.Equals(oRow["smtp_endereco"]) ? string.Empty : oRow.Field<string>("smtp_endereco");
                            LoginInfo.SMTP_porta = DBNull.Value.Equals(oRow["smtp_porta"]) ? 0 : Convert.ToInt32(oRow.Field<object>("smtp_porta"));
                            LoginInfo.SMTP_usuario = DBNull.Value.Equals(oRow["smtp_usuario"]) ? string.Empty : oRow.Field<string>("smtp_usuario");
                            LoginInfo.SMTP_senha = DBNull.Value.Equals(oRow["smtp_senha"]) ? string.Empty : Crypto.DecryptString(oRow.Field<string>("smtp_senha"));
                            LoginInfo.SMTP_ssl = DBNull.Value.Equals(oRow["smtp_ssl"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_ssl"));
                            LoginInfo.SMTP_tls = DBNull.Value.Equals(oRow["smtp_tls"]) ? false : Convert.ToBoolean(oRow.Field<object>("smtp_tls"));

                            //********************
                            //* Retorna status OK
                            //********************
                            _ErrorText = string.Empty;
                            _Error = false;
                            return _ErrorText;
                        }
                        else
                        {
                            //******************************
                            //* Anula dados e retorna falha
                            //******************************
                            if (Senha != string.Empty)
                            {
                                _ErrorText = "senha: Senha inválida.";
                                _Error = true;
                            }
                            else
                            {
                                _ErrorText = "senha: Senha não informada.";
                                _Error = true;
                            }
                            LogOff();
                            return _ErrorText;
                        }
                    }
                    else
                    {
                        //******************************
                        //* Anula dados e retorna falha
                        //******************************
                        if (Usuario != string.Empty)
                        {
                            _ErrorText = "usuario: Usuário inativo.";
                            _Error = true;
                        }
                        else
                        {
                            _ErrorText = "usuario: Usuário não informado.";
                            _Error = true;
                        }
                        LogOff();
                        return _ErrorText;
                    }
                }
                else
                {
                    //******************************
                    //* Anula dados e retorna falha
                    //******************************
                    if (Usuario != string.Empty)
                    {
                        _ErrorText = "usuario: Usuário inexistente.";
                        _Error = true;
                    }
                    else
                    {
                        _ErrorText = "usuario: Usuário não informado.";
                        _Error = true;
                    }
                    LogOff();
                    return _ErrorText;
                }
            }
            catch (Exception oException)
            {
                //**************************
                //* Houve falha de conexão?
                //**************************
                if (oException.Message.IndexOf("object") != -1)
                {
                    _ErrorText = "sistema: Conexão incorretamente definida.";
                    _Error = true;
                }
                else
                {
                    _ErrorText = "sistema: " + oException.Message + "\r\n" + oException.Source;
                    _Error = true;
                }
                LogOff();
                return _ErrorText;
            }
        }
        public void LogOff()
        {
            //****************
            //* Cancela login
            //****************
            LoginInfo.Master_Codigo = 0;
            LoginInfo.Master_DevArtConexaoString = string.Empty;
            LoginInfo.Master_ConexaoString = string.Empty;
            LoginInfo.Master_Empresa = string.Empty;
            LoginInfo.Posto_Codigo = 0;
            LoginInfo.Posto_Descricao = string.Empty;
            LoginInfo.Posto_Nome = string.Empty;
            LoginInfo.Usuario_Codigo = 0;
            LoginInfo.Usuario_CodigoGrupo = 0;
            LoginInfo.Usuario_DescGrupo = string.Empty;
            LoginInfo.Usuario_EmailEndereco = string.Empty;
            LoginInfo.Usuario_EmailCopia = false;
            LoginInfo.Usuario_ID = string.Empty;
            LoginInfo.Usuario_Nome = string.Empty;
            LoginInfo.Usuario_Senha = string.Empty;
            LoginInfo.Usuario_Supervisor = false;
            LoginInfo.Usuario_Telefone = string.Empty;
            LoginInfo.Usuario_Ativo = false;
            LoginInfo.SMTP_autenticacao = false;
            LoginInfo.SMTP_endereco = string.Empty;
            LoginInfo.SMTP_porta = 0;
            LoginInfo.SMTP_usuario = string.Empty;
            LoginInfo.SMTP_senha = string.Empty;
            LoginInfo.SMTP_ssl = false;
            LoginInfo.SMTP_tls = false;
        }
    }
}