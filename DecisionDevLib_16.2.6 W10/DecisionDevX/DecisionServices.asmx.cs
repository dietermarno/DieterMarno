using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Services;
using Decision.Database;
using Decision.LoginManager;
using Decision.TableManager;
using Decision.Util;
using System.Xml.Serialization;

namespace Decision
{
    /// <summary>
    /// Summary description for DecisionServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RetornoWebService
    {
        //****************************************
        //* Relatório de resultados de importação
        //****************************************
        public List<string> ErrorList = new List<string>();
        public string XML = string.Empty;
        public bool Error = false;
        public Int32 Selected = 0;
        public Int32 Inserted = 0;
        public Int32 Updated = 0;
        public Int32 Errors = 0;
    }
    public class DecisionServices : System.Web.Services.WebService
    {
        [WebMethod()]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaPais(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Pais - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Pais_Manager oManager = new Pais_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Pais_Fields oFields = new Pais_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("CodPais") > -1)
                    oFields.PK_CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("DescPais") > -1)
                    oFields.DescPais = !DBNull.Value.Equals(oRow["DescPais"]) ? oRow["DescPais"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodPais)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Pais - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Pais - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaCidade(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Cidade - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Cidade_Manager oManager = new Cidade_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Cidade_Fields oFields = new Cidade_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("CodCidade") > -1)
                    oFields.PK_CodCidade = !DBNull.Value.Equals(oRow["CodCidade"]) ? Convert.ToInt32("0" + oRow["CodCidade"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("UF") > -1)
                    oFields.UF = !DBNull.Value.Equals(oRow["UF"]) ? oRow["UF"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NomeCidade") > -1)
                    oFields.NomeCidade = !DBNull.Value.Equals(oRow["NomeCidade"]) ? oRow["NomeCidade"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("DDD") > -1)
                    oFields.DDD = !DBNull.Value.Equals(oRow["DDD"]) ? oRow["DDD"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CodPais") > -1)
                    oFields.CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("Sigla") > -1)
                    oFields.Sigla = !DBNull.Value.Equals(oRow["Sigla"]) ? oRow["Sigla"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ObsCidade") > -1)
                    oFields.ObsCidade = !DBNull.Value.Equals(oRow["ObsCidade"]) ? oRow["ObsCidade"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CodIBGE") > -1)
                    oFields.CodIBGE = !DBNull.Value.Equals(oRow["CodIBGE"]) ? Convert.ToInt32("0" + oRow["CodIBGE"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodCidade)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Cidade - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Cidade - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaBanco(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Banco - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Banco_Manager oManager = new Banco_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Banco_Fields oFields = new Banco_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("CodBco") > -1)
                    oFields.PK_CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("DescBco") > -1)
                    oFields.DescBco = !DBNull.Value.Equals(oRow["DescBco"]) ? oRow["DescBco"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroDescBco") > -1)
                    oFields.NroDescBco = !DBNull.Value.Equals(oRow["NroDescBco"]) ? oRow["NroDescBco"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroAgencia") > -1)
                    oFields.NroAgencia = !DBNull.Value.Equals(oRow["NroAgencia"]) ? oRow["NroAgencia"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCedenteAg") > -1)
                    oFields.NroCedenteAg = !DBNull.Value.Equals(oRow["NroCedenteAg"]) ? oRow["NroCedenteAg"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroConvenio") > -1)
                    oFields.NroConvenio = !DBNull.Value.Equals(oRow["NroConvenio"]) ? oRow["NroConvenio"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCarteira") > -1)
                    oFields.NroCarteira = !DBNull.Value.Equals(oRow["NroCarteira"]) ? oRow["NroCarteira"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Instrucao") > -1)
                    oFields.Instrucao = !DBNull.Value.Equals(oRow["Instrucao"]) ? oRow["Instrucao"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Instrucao2") > -1)
                    oFields.Instrucao2 = !DBNull.Value.Equals(oRow["Instrucao2"]) ? oRow["Instrucao2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("DvNroAgencia") > -1)
                    oFields.DvNroAgencia = !DBNull.Value.Equals(oRow["DvNroAgencia"]) ? oRow["DvNroAgencia"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("RegistroCobranca") > -1)
                    oFields.RegistroCobranca = !DBNull.Value.Equals(oRow["RegistroCobranca"]) ? Convert.ToInt16("0" + oRow["RegistroCobranca"]) : (Int16)0;

                if (oData.Tables[0].Columns.IndexOf("SequenciaRemessa") > -1)
                    oFields.SequenciaRemessa = !DBNull.Value.Equals(oRow["SequenciaRemessa"]) ? Convert.ToInt32("0" + oRow["SequenciaRemessa"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("CodigoEmpresaBanco") > -1)
                    oFields.CodigoEmpresaBanco = !DBNull.Value.Equals(oRow["CodigoEmpresaBanco"]) ? oRow["CodigoEmpresaBanco"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodBco)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Banco - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Banco - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaProfissao(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Profissao - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Profissao_Manager oManager = new Profissao_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Profissao_Fields oFields = new Profissao_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("CodProf") > -1)
                    oFields.PK_CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("Descricao") > -1)
                    oFields.Descricao = !DBNull.Value.Equals(oRow["Descricao"]) ? oRow["Descricao"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodProf)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Profissao - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Profissao - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaPromotor(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Promotor - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Promotor_Manager oManager = new Promotor_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Promotor_Fields oFields = new Promotor_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("codpromotor") > -1)
                    oFields.PK_CodPromotor = !DBNull.Value.Equals(oRow["codpromotor"]) ? Convert.ToInt32("0" + oRow["codpromotor"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("nomepromotor") > -1)
                    oFields.NomePromotor = !DBNull.Value.Equals(oRow["nomepromotor"]) ? oRow["nomepromotor"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("end") > -1)
                    oFields.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ramalfone1") > -1)
                    oFields.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ramalfone1") > -1)
                    oFields.RamalFone1 = !DBNull.Value.Equals(oRow["ramalfone1"]) ? oRow["ramalfone1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("fone2") > -1)
                    oFields.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ramalfone2") > -1)
                    oFields.RamalFone2 = !DBNull.Value.Equals(oRow["ramalfone2"]) ? oRow["ramalfone2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("fax") > -1)
                    oFields.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ramalfax") > -1)
                    oFields.RamalFax = !DBNull.Value.Equals(oRow["ramalfax"]) ? oRow["ramalfax"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("cep") > -1)
                    oFields.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("codcidade") > -1)
                    oFields.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("tipo") > -1)
                    oFields.Tipo = !DBNull.Value.Equals(oRow["tipo"]) ? oRow["tipo"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("email") > -1)
                    oFields.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("http") > -1)
                    oFields.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("obs") > -1)
                    oFields.Obs = !DBNull.Value.Equals(oRow["obs"]) ? oRow["obs"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("status") > -1)
                    oFields.Status = !DBNull.Value.Equals(oRow["status"]) ? oRow["status"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("codrestrito") > -1)
                    oFields.CodRestrito = !DBNull.Value.Equals(oRow["codrestrito"]) ? Convert.ToInt32("0" + oRow["codrestrito"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodPromotor)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Promotor - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Promotor - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaPosto(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Posto - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Posto_Manager oManager = new Posto_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Posto_Fields oFields = new Posto_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("postoven") > -1)
                    oFields.PK_PostoVen = !DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("codcidade") > -1)
                    oFields.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("descposto") > -1)
                    oFields.DescPosto = !DBNull.Value.Equals(oRow["descposto"]) ? oRow["descposto"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("end") > -1)
                    oFields.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("cep") > -1)
                    oFields.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("fone1") > -1)
                    oFields.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("fone2") > -1)
                    oFields.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("fax") > -1)
                    oFields.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("email") > -1)
                    oFields.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("nomeposto") > -1)
                    oFields.NomePosto = !DBNull.Value.Equals(oRow["nomeposto"]) ? oRow["nomeposto"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("cgc") > -1)
                    oFields.CGC = !DBNull.Value.Equals(oRow["cgc"]) ? oRow["cgc"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("inscrmun") > -1)
                    oFields.InscrMun = !DBNull.Value.Equals(oRow["inscrmun"]) ? oRow["inscrmun"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("embratur") > -1)
                    oFields.Embratur = !DBNull.Value.Equals(oRow["embratur"]) ? oRow["embratur"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("iata") > -1)
                    oFields.Iata = !DBNull.Value.Equals(oRow["iata"]) ? oRow["iata"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("http") > -1)
                    oFields.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("restringecontas") > -1)
                    oFields.RestringeContas = !DBNull.Value.Equals(oRow["restringecontas"]) ? oRow["restringecontas"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("postoven") > -1)
                    oFields.LogoTipo = oManager.GetPicture(!DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0);

                if (oData.Tables[0].Columns.IndexOf("codempintctb") > -1)
                    oFields.CodEmpIntCtb = !DBNull.Value.Equals(oRow["codempintctb"]) ? oRow["codempintctb"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ultimanfposto") > -1)
                    oFields.UltimaNFPosto = !DBNull.Value.Equals(oRow["ultimanfposto"]) ? Convert.ToInt32("0" + oRow["ultimanfposto"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("ultimafaturaposto") > -1)
                    oFields.UltimaFaturaPosto = !DBNull.Value.Equals(oRow["ultimafaturaposto"]) ? Convert.ToInt32("0" + oRow["ultimafaturaposto"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("ultimreciboposto") > -1)
                    oFields.UltimReciboPosto = !DBNull.Value.Equals(oRow["ultimreciboposto"]) ? Convert.ToInt32("0" + oRow["ultimreciboposto"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("ultimanfpostofreta") > -1)
                    oFields.UltimaNFPostoFreta = !DBNull.Value.Equals(oRow["ultimanfpostofreta"]) ? Convert.ToInt32("0" + oRow["ultimanfpostofreta"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("omitenronfrodape") > -1)
                    oFields.OmiteNroNFRodape = !DBNull.Value.Equals(oRow["omitenronfrodape"]) ? oRow["omitenronfrodape"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("codempnfe") > -1)
                    oFields.CodEmpNfe = !DBNull.Value.Equals(oRow["codempnfe"]) ? Convert.ToInt32("0" + oRow["codempnfe"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("chaveprivadanfe") > -1)
                    oFields.ChavePrivadaNfe = !DBNull.Value.Equals(oRow["chaveprivadanfe"]) ? oRow["chaveprivadanfe"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("chaveacessonfe") > -1)
                    oFields.ChaveAcessoNfe = !DBNull.Value.Equals(oRow["chaveacessonfe"]) ? oRow["chaveacessonfe"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("regimeesptributa") > -1)
                    oFields.RegimeEspTributa = !DBNull.Value.Equals(oRow["regimeesptributa"]) ? Convert.ToInt32("0" + oRow["regimeesptributa"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("optantesimplesnac") > -1)
                    oFields.OptanteSimplesNac = !DBNull.Value.Equals(oRow["optantesimplesnac"]) ? Convert.ToInt32("0" + oRow["optantesimplesnac"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("tributomunicipio") > -1)
                    oFields.TributoMunicipio = !DBNull.Value.Equals(oRow["tributomunicipio"]) ? Convert.ToInt32("0" + oRow["tributomunicipio"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("serierps") > -1)
                    oFields.SerieRPS = !DBNull.Value.Equals(oRow["serierps"]) ? oRow["serierps"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("tiporps") > -1)
                    oFields.TipoRPS = !DBNull.Value.Equals(oRow["tiporps"]) ? oRow["tiporps"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("naturezaoperacao") > -1)
                    oFields.NaturezaOperacao = !DBNull.Value.Equals(oRow["naturezaoperacao"]) ? Convert.ToInt32("0" + oRow["naturezaoperacao"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("incentivadorcultural") > -1)
                    oFields.IncentivadorCultural = !DBNull.Value.Equals(oRow["incentivadorcultural"]) ? Convert.ToInt32("0" + oRow["incentivadorcultural"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("aliquotaiss") > -1)
                    oFields.AliquotaISS = !DBNull.Value.Equals(oRow["aliquotaiss"]) ? Convert.ToInt32("0" + oRow["aliquotaiss"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("cnae") > -1)
                    oFields.CNAE = !DBNull.Value.Equals(oRow["cnae"]) ? Convert.ToInt32("0" + oRow["cnae"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_PostoVen)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Posto - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Posto - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaSituacao(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Situacao - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Situacao_Manager oManager = new Situacao_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Situacao_Fields oFields = new Situacao_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("SitCli") > -1)
                    oFields.PK_SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("DescSitCli") > -1)
                    oFields.DescSitCli = !DBNull.Value.Equals(oRow["DescSitCli"]) ? oRow["DescSitCli"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_SitCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Situacao - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Situacao - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaClassifica(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Classifica - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Classifica_Manager oManager = new Classifica_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Classifica_Fields oFields = new Classifica_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("TipoCli") > -1)
                    oFields.PK_TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("DescTipoCli") > -1)
                    oFields.DescTipoCli = !DBNull.Value.Equals(oRow["DescTipoCli"]) ? oRow["DescTipoCli"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_TipoCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Classifica - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Classifica - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ImportaClientes(string Empresa, string Usuario, string Senha, string XML)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);
            XML = Crypto.DecryptString(XML);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Clientes - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(XML));

            //*********************
            //* Define gerenciador
            //*********************
            Cliente_Manager oManager = new Cliente_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Cliente_Fields oFields = new Cliente_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach(DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                if (oData.Tables[0].Columns.IndexOf("CodCli") > -1)
                    oFields.PK_CodCli = !DBNull.Value.Equals(oRow["CodCli"]) ? Convert.ToInt32("0" + oRow["CodCli"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("Nome") > -1)
                    oFields.Nome = !DBNull.Value.Equals(oRow["Nome"]) ? oRow["Nome"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("LocalTrab") > -1)
                    oFields.LocalTrab = !DBNull.Value.Equals(oRow["LocalTrab"]) ? oRow["LocalTrab"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CodProf") > -1)
                    oFields.CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("CodBco") > -1)
                    oFields.CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("TipoCli") > -1)
                    oFields.TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("SitCli") > -1)
                    oFields.SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("PostoVen") > -1)
                    oFields.PostoVen = !DBNull.Value.Equals(oRow["PostoVen"]) ? Convert.ToInt32("0" + oRow["PostoVen"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("CodPromotor") > -1)
                    oFields.CodPromotor = !DBNull.Value.Equals(oRow["CodPromotor"]) ? Convert.ToInt32("0" + oRow["CodPromotor"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("Titular") > -1)
                    oFields.Titular = !DBNull.Value.Equals(oRow["Titular"]) ? oRow["Titular"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("MneCli") > -1)
                    oFields.MneCli = !DBNull.Value.Equals(oRow["MneCli"]) ? oRow["MneCli"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("LeiKandir") > -1)
                    oFields.LeiKandir = !DBNull.Value.Equals(oRow["LeiKandir"]) ? oRow["LeiKandir"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("StatusCli") > -1)
                    oFields.StatusCli = !DBNull.Value.Equals(oRow["StatusCli"]) ? oRow["StatusCli"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("IndicePontosCli") > -1)
                    oFields.IndicePontosCli = !DBNull.Value.Equals(oRow["IndicePontosCli"]) ? Convert.ToDouble("0" + oRow["IndicePontosCli"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("PercentPontosCli") > -1)
                    oFields.PercentPontosCli = !DBNull.Value.Equals(oRow["PercentPontosCli"]) ? Convert.ToDouble("0" + oRow["PercentPontosCli"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("CodEmissor") > -1)
                    oFields.CodEmissor = !DBNull.Value.Equals(oRow["CodEmissor"]) ? Convert.ToInt32("0" + oRow["CodEmissor"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("CodTerceiro") > -1)
                    oFields.CodTerceiro = !DBNull.Value.Equals(oRow["CodTerceiro"]) ? Convert.ToInt32("0" + oRow["CodTerceiro"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("GeraFatPDF") > -1)
                    oFields.GeraFatPDF = !DBNull.Value.Equals(oRow["GeraFatPDF"]) ? oRow["GeraFatPDF"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaCodCtbForn") > -1)
                    oFields.AgrupaCodCtbForn = !DBNull.Value.Equals(oRow["AgrupaCodCtbForn"]) ? Convert.ToInt16("0" + oRow["AgrupaCodCtbForn"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaTipoCobra") > -1)
                    oFields.AgrupaTipoCobra = !DBNull.Value.Equals(oRow["AgrupaTipoCobra"]) ? Convert.ToInt16("0" + oRow["AgrupaTipoCobra"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaCatProd") > -1)
                    oFields.AgrupaCatProd = !DBNull.Value.Equals(oRow["AgrupaCatProd"]) ? Convert.ToInt16("0" + oRow["AgrupaCatProd"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaProd") > -1)
                    oFields.AgrupaProd = !DBNull.Value.Equals(oRow["AgrupaProd"]) ? Convert.ToInt16("0" + oRow["AgrupaProd"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaForn") > -1)
                    oFields.AgrupaForn = !DBNull.Value.Equals(oRow["AgrupaForn"]) ? Convert.ToInt16("0" + oRow["AgrupaForn"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaCC") > -1)
                    oFields.AgrupaCC = !DBNull.Value.Equals(oRow["AgrupaCC"]) ? Convert.ToInt16("0" + oRow["AgrupaCC"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaPax") > -1)
                    oFields.AgrupaPax = !DBNull.Value.Equals(oRow["AgrupaPax"]) ? Convert.ToInt16("0" + oRow["AgrupaPax"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaReq") > -1)
                    oFields.AgrupaReq = !DBNull.Value.Equals(oRow["AgrupaReq"]) ? Convert.ToInt16("0" + oRow["AgrupaReq"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("PeriodoFatura") > -1)
                    oFields.PeriodoFatura = !DBNull.Value.Equals(oRow["PeriodoFatura"]) ? oRow["PeriodoFatura"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ItensFatura") > -1)
                    oFields.ItensFatura = !DBNull.Value.Equals(oRow["ItensFatura"]) ? Convert.ToInt16("0" + oRow["ItensFatura"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("AgrupaReqCliente") > -1)
                    oFields.AgrupaReqCliente = !DBNull.Value.Equals(oRow["AgrupaReqCliente"]) ? Convert.ToInt16("0" + oRow["AgrupaReqCliente"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("Contato") > -1)
                    oFields.Contato = !DBNull.Value.Equals(oRow["Contato"]) ? oRow["Contato"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Sexo") > -1)
                    oFields.Sexo = !DBNull.Value.Equals(oRow["Sexo"]) ? oRow["Sexo"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("EndRes") > -1)
                    oFields.EndRes = !DBNull.Value.Equals(oRow["EndRes"]) ? oRow["EndRes"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("FoneRes") > -1)
                    oFields.FoneRes = !DBNull.Value.Equals(oRow["FoneRes"]) ? oRow["FoneRes"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("FaxRes") > -1)
                    oFields.FaxRes = !DBNull.Value.Equals(oRow["FaxRes"]) ? oRow["FaxRes"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CodCidadeRes") > -1)
                    oFields.CodCidadeRes = !DBNull.Value.Equals(oRow["CodCidadeRes"]) ? Convert.ToInt32("0" + oRow["CodCidadeRes"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("CEPRes") > -1)
                    oFields.CEPRes = !DBNull.Value.Equals(oRow["CEPRes"]) ? oRow["CEPRes"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("TempoRes") > -1)
                    oFields.TempoRes = !DBNull.Value.Equals(oRow["TempoRes"]) ? Convert.ToInt16("0" + oRow["TempoRes"]) : (Int16)0;
                
                if (oData.Tables[0].Columns.IndexOf("Filiacao") > -1)
                    oFields.Filiacao = !DBNull.Value.Equals(oRow["Filiacao"]) ? oRow["Filiacao"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("DataNasc") > -1)
                    if (!DBNull.Value.Equals(oRow["DataNasc"]))
                        oFields.DataNasc = Convert.ToDateTime(oRow["DataNasc"]);
                
                if (oData.Tables[0].Columns.IndexOf("CIC") > -1)
                    oFields.CIC = !DBNull.Value.Equals(oRow["CIC"]) ? oRow["CIC"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("RG") > -1)
                    oFields.RG = !DBNull.Value.Equals(oRow["RG"]) ? oRow["RG"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Orgao") > -1)
                    oFields.Orgao = !DBNull.Value.Equals(oRow["Orgao"]) ? oRow["Orgao"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("RGUF") > -1)
                    oFields.RGUF = !DBNull.Value.Equals(oRow["RGUF"]) ? oRow["RGUF"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Nacionalidade") > -1)
                    oFields.Nacionalidade = !DBNull.Value.Equals(oRow["Nacionalidade"]) ? oRow["Nacionalidade"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Naturalidade") > -1)
                    oFields.Naturalidade = !DBNull.Value.Equals(oRow["Naturalidade"]) ? oRow["Naturalidade"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("InscrEstadual") > -1)
                    oFields.InscrEstadual = !DBNull.Value.Equals(oRow["InscrEstadual"]) ? oRow["InscrEstadual"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CGC") > -1)
                    oFields.CGC = !DBNull.Value.Equals(oRow["CGC"]) ? oRow["CGC"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("EstadoCivil") > -1)
                    oFields.EstadoCivil = !DBNull.Value.Equals(oRow["EstadoCivil"]) ? oRow["EstadoCivil"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("EMail") > -1)
                    oFields.EMail = !DBNull.Value.Equals(oRow["EMail"]) ? oRow["EMail"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Passaporte") > -1)
                    oFields.Passaporte = !DBNull.Value.Equals(oRow["Passaporte"]) ? oRow["Passaporte"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ValidPassaporte") > -1)
                    if (!DBNull.Value.Equals(oRow["ValidPassaporte"]))
                        oFields.ValidPassaporte = Convert.ToDateTime(oRow["ValidPassaporte"]);
                
                if (oData.Tables[0].Columns.IndexOf("NomeVisto1") > -1)
                    oFields.NomeVisto1 = !DBNull.Value.Equals(oRow["NomeVisto1"]) ? oRow["NomeVisto1"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NomeVisto2") > -1)
                    oFields.NomeVisto2 = !DBNull.Value.Equals(oRow["NomeVisto2"]) ? oRow["NomeVisto2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ValidVisto1") > -1)
                    if (!DBNull.Value.Equals(oRow["ValidVisto1"]))
                        oFields.ValidVisto1 = Convert.ToDateTime(oRow["ValidVisto1"]);
                
                if (oData.Tables[0].Columns.IndexOf("ValidVisto2") > -1)
                    if (!DBNull.Value.Equals(oRow["ValidVisto2"]))
                        oFields.ValidVisto2 = Convert.ToDateTime(oRow["ValidVisto2"]);

                if (oData.Tables[0].Columns.IndexOf("EndTrab") > -1)
                    oFields.EndTrab = !DBNull.Value.Equals(oRow["EndTrab"]) ? oRow["EndTrab"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("CodCidadeTrab") > -1)
                    oFields.CodCidadeTrab = !DBNull.Value.Equals(oRow["CodCidadeTrab"]) ? Convert.ToInt32("0" + oRow["CodCidadeTrab"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("CEPTrab") > -1)
                    oFields.CEPTrab = !DBNull.Value.Equals(oRow["CEPTrab"]) ? oRow["CEPTrab"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("FoneTrab") > -1)
                    oFields.FoneTrab = !DBNull.Value.Equals(oRow["FoneTrab"]) ? oRow["FoneTrab"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("FaxTrab") > -1)
                    oFields.FaxTrab = !DBNull.Value.Equals(oRow["FaxTrab"]) ? oRow["FaxTrab"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("TempoTrab") > -1)
                    oFields.TempoTrab = !DBNull.Value.Equals(oRow["TempoTrab"]) ? Convert.ToInt16("0" + oRow["TempoTrab"]) : (Int16)0;

                if (oData.Tables[0].Columns.IndexOf("Renda") > -1)
                    oFields.Renda = !DBNull.Value.Equals(oRow["Renda"]) ? Convert.ToInt32("0" + oRow["Renda"]) : 0;

                if (oData.Tables[0].Columns.IndexOf("RefCom") > -1)
                    oFields.RefCom = !DBNull.Value.Equals(oRow["RefCom"]) ? oRow["RefCom"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("FoneRefCom") > -1)
                    oFields.FoneRefCom = !DBNull.Value.Equals(oRow["FoneRefCom"]) ? oRow["FoneRefCom"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("RefBco") > -1)
                    oFields.RefBco = !DBNull.Value.Equals(oRow["RefBco"]) ? oRow["RefBco"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("FoneRefBco") > -1)
                    oFields.FoneRefBco = !DBNull.Value.Equals(oRow["FoneRefBco"]) ? oRow["FoneRefBco"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Cia1") > -1)
                    oFields.Cia1 = !DBNull.Value.Equals(oRow["Cia1"]) ? oRow["Cia1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCia1") > -1)
                    oFields.NroCia1 = !DBNull.Value.Equals(oRow["NroCia1"]) ? oRow["NroCia1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Cia2") > -1)
                    oFields.Cia2 = !DBNull.Value.Equals(oRow["Cia2"]) ? oRow["Cia2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCia2") > -1)
                    oFields.NroCia2 = !DBNull.Value.Equals(oRow["NroCia2"]) ? oRow["NroCia2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Cia3") > -1)
                    oFields.Cia3 = !DBNull.Value.Equals(oRow["Cia3"]) ? oRow["Cia3"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCia3") > -1)
                    oFields.NroCia3 = !DBNull.Value.Equals(oRow["NroCia3"]) ? oRow["NroCia3"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Cia4") > -1)
                    oFields.Cia4 = !DBNull.Value.Equals(oRow["Cia4"]) ? oRow["Cia4"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("NroCia4") > -1)
                    oFields.NroCia4 = !DBNull.Value.Equals(oRow["NroCia4"]) ? oRow["NroCia4"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("DataCad") > -1)
                    if (!DBNull.Value.Equals(oRow["DataCad"]))
                        oFields.DataCad = Convert.ToDateTime(oRow["DataCad"]);

                if (oData.Tables[0].Columns.IndexOf("CodContabil") > -1)
                    oFields.CodContabil = !DBNull.Value.Equals(oRow["CodContabil"]) ? oRow["CodContabil"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Fumante") > -1)
                    oFields.Fumante = !DBNull.Value.Equals(oRow["Fumante"]) ? oRow["Fumante"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Assento") > -1)
                    oFields.Assento = !DBNull.Value.Equals(oRow["Assento"]) ? oRow["Assento"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("EndCobr") > -1)
                    oFields.EndCobr = !DBNull.Value.Equals(oRow["EndCobr"]) ? oRow["EndCobr"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("CodCidadeCobr") > -1)
                    oFields.CodCidadeCobr = !DBNull.Value.Equals(oRow["CodCidadeCobr"]) ? Convert.ToInt32("0" + oRow["CodCidadeCobr"]) : (Int16)0;

                if (oData.Tables[0].Columns.IndexOf("CEPCobr") > -1)
                    oFields.CEPCobr = !DBNull.Value.Equals(oRow["CEPCobr"]) ? oRow["CEPCobr"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("EndCorresp") > -1)
                    oFields.EndCorresp = !DBNull.Value.Equals(oRow["EndCorresp"]) ? oRow["EndCorresp"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("SitCredito") > -1)
                    oFields.SitCredito = !DBNull.Value.Equals(oRow["SitCredito"]) ? oRow["SitCredito"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("Observacoes") > -1)
                    oFields.Observacoes = !DBNull.Value.Equals(oRow["Observacoes"]) ? oRow["Observacoes"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("CartaoCred1") > -1)
                    oFields.CartaoCred1 = !DBNull.Value.Equals(oRow["CartaoCred1"]) ? oRow["CartaoCred1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("CartaoCred2") > -1)
                    oFields.CartaoCred2 = !DBNull.Value.Equals(oRow["CartaoCred2"]) ? oRow["CartaoCred2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CartaoCred3") > -1)
                    oFields.CartaoCred3 = !DBNull.Value.Equals(oRow["CartaoCred3"]) ? oRow["CartaoCred3"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CartaoCred4") > -1)
                    oFields.CartaoCred4 = !DBNull.Value.Equals(oRow["CartaoCred4"]) ? oRow["CartaoCred4"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NroCartao1") > -1)
                    oFields.NroCartao1 = !DBNull.Value.Equals(oRow["NroCartao1"]) ? oRow["NroCartao1"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NroCartao2") > -1)
                    oFields.NroCartao2 = !DBNull.Value.Equals(oRow["NroCartao2"]) ? oRow["NroCartao2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NroCartao3") > -1)
                    oFields.NroCartao3 = !DBNull.Value.Equals(oRow["NroCartao3"]) ? oRow["NroCartao3"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("NroCartao4") > -1)
                    oFields.NroCartao4 = !DBNull.Value.Equals(oRow["NroCartao4"]) ? oRow["NroCartao4"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ValidCartao1") > -1)
                    oFields.ValidCartao1 = !DBNull.Value.Equals(oRow["ValidCartao1"]) ? oRow["ValidCartao1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ValidCartao2") > -1)
                    oFields.ValidCartao2 = !DBNull.Value.Equals(oRow["ValidCartao2"]) ? oRow["ValidCartao2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ValidCartao3") > -1)
                    oFields.ValidCartao3 = !DBNull.Value.Equals(oRow["ValidCartao3"]) ? oRow["ValidCartao3"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("ValidCartao4") > -1)
                    oFields.ValidCartao4 = !DBNull.Value.Equals(oRow["ValidCartao4"]) ? oRow["ValidCartao4"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("TituloMala") > -1)
                    oFields.TituloMala = !DBNull.Value.Equals(oRow["TituloMala"]) ? oRow["TituloMala"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("TipoPessoa") > -1)
                    oFields.TipoPessoa = !DBNull.Value.Equals(oRow["TipoPessoa"]) ? oRow["TipoPessoa"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("VenctoCartao1") > -1)
                    oFields.VenctoCartao1 = !DBNull.Value.Equals(oRow["VenctoCartao1"]) ? oRow["VenctoCartao1"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("VenctoCartao2") > -1)
                    oFields.VenctoCartao2 = !DBNull.Value.Equals(oRow["VenctoCartao2"]) ? oRow["VenctoCartao2"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("VenctoCartao3") > -1)
                    oFields.VenctoCartao3 = !DBNull.Value.Equals(oRow["VenctoCartao3"]) ? oRow["VenctoCartao3"].ToString() : string.Empty;

                if (oData.Tables[0].Columns.IndexOf("VenctoCartao4") > -1)
                    oFields.VenctoCartao4 = !DBNull.Value.Equals(oRow["VenctoCartao4"]) ? oRow["VenctoCartao4"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("DtUltimaAlteracao") > -1)
                    if (!DBNull.Value.Equals(oRow["DtUltimaAlteracao"]))
                        oFields.DtUltimaAlteracao = Convert.ToDateTime(oRow["DtUltimaAlteracao"]);
                
                if (oData.Tables[0].Columns.IndexOf("UltimaAlteracaoPor") > -1)
                    oFields.UltimaAlteracaoPor = !DBNull.Value.Equals(oRow["UltimaAlteracaoPor"]) ? oRow["UltimaAlteracaoPor"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("EmissVisto1") > -1)
                    if (!DBNull.Value.Equals(oRow["EmissVisto1"]))
                        oFields.EmissVisto1 = Convert.ToDateTime(oRow["EmissVisto1"]);
                
                if (oData.Tables[0].Columns.IndexOf("EmissVisto2") > -1)
                    if (!DBNull.Value.Equals(oRow["EmissVisto2"]))
                        oFields.EmissVisto2 = Convert.ToDateTime(oRow["EmissVisto2"]);

                if (oData.Tables[0].Columns.IndexOf("Funcao") > -1)
                    oFields.Funcao = !DBNull.Value.Equals(oRow["Funcao"]) ? oRow["Funcao"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ChaveLivre1") > -1)
                    oFields.ChaveLivre1 = !DBNull.Value.Equals(oRow["ChaveLivre1"]) ? oRow["ChaveLivre1"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ChaveLivre2") > -1)
                    oFields.ChaveLivre2 = !DBNull.Value.Equals(oRow["ChaveLivre2"]) ? oRow["ChaveLivre2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("AssinaNewsletter") > -1)
                    oFields.AssinaNewsletter = !DBNull.Value.Equals(oRow["AssinaNewsletter"]) ? oRow["AssinaNewsletter"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("TipoNewsletter") > -1)
                    oFields.TipoNewsletter = !DBNull.Value.Equals(oRow["TipoNewsletter"]) ? oRow["TipoNewsletter"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CreditoDinCC") > -1)
                    oFields.CreditoDinCC = !DBNull.Value.Equals(oRow["CreditoDinCC"]) ? oRow["CreditoDinCC"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CreditoCheque") > -1)
                    oFields.CreditoCheque = !DBNull.Value.Equals(oRow["CreditoCheque"]) ? oRow["CreditoCheque"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CreditoOutros") > -1)
                    oFields.CreditoOutros = !DBNull.Value.Equals(oRow["CreditoOutros"]) ? oRow["CreditoOutros"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("PotCres") > -1)
                    oFields.PotCres = !DBNull.Value.Equals(oRow["PotCres"]) ? oRow["PotCres"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ValEstra") > -1)
                    oFields.ValEstra = !DBNull.Value.Equals(oRow["ValEstra"]) ? oRow["ValEstra"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ContaEBTA") > -1)
                    oFields.ContaEBTA = !DBNull.Value.Equals(oRow["ContaEBTA"]) ? oRow["ContaEBTA"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Fantasia") > -1)
                    oFields.Fantasia = !DBNull.Value.Equals(oRow["Fantasia"]) ? oRow["Fantasia"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("Bairro") > -1)
                    oFields.Bairro = !DBNull.Value.Equals(oRow["Bairro"]) ? oRow["Bairro"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("TitularCartao1") > -1)
                    oFields.TitularCartao1 = !DBNull.Value.Equals(oRow["TitularCartao1"]) ? oRow["TitularCartao1"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("TitularCartao2") > -1)
                    oFields.TitularCartao2 = !DBNull.Value.Equals(oRow["TitularCartao2"]) ? oRow["TitularCartao2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("TitularCartao3") > -1)
                    oFields.TitularCartao3 = !DBNull.Value.Equals(oRow["TitularCartao3"]) ? oRow["TitularCartao3"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CSCartao1") > -1)
                    oFields.CSCartao1 = !DBNull.Value.Equals(oRow["CSCartao1"]) ? oRow["CSCartao1"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CSCartao2") > -1)
                    oFields.CSCartao2 = !DBNull.Value.Equals(oRow["CSCartao2"]) ? oRow["CSCartao2"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("CSCartao3") > -1)
                    oFields.CSCartao3 = !DBNull.Value.Equals(oRow["CSCartao3"]) ? oRow["CSCartao3"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("VlrTxBco") > -1)
                    oFields.VlrTxBco = !DBNull.Value.Equals(oRow["VlrTxBco"]) ? Convert.ToDouble("0" + oRow["VlrTxBco"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("ContaCTA") > -1)
                    oFields.ContaCTA = !DBNull.Value.Equals(oRow["ContaCTA"]) ? oRow["ContaCTA"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ContaVisa") > -1)
                    oFields.ContaVisa = !DBNull.Value.Equals(oRow["ContaVisa"]) ? oRow["ContaVisa"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ObrigaCentroCusto") > -1)
                    oFields.ObrigaCentroCusto = !DBNull.Value.Equals(oRow["ObrigaCentroCusto"]) ? oRow["ObrigaCentroCusto"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("ObrigaObservacao") > -1)
                    oFields.ObrigaObservacao = !DBNull.Value.Equals(oRow["ObrigaObservacao"]) ? oRow["ObrigaObservacao"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("LimiteUnit") > -1)
                    oFields.LimiteUnit = !DBNull.Value.Equals(oRow["LimiteUnit"]) ? Convert.ToDouble("0" + oRow["LimiteUnit"]) : 0;
                
                if (oData.Tables[0].Columns.IndexOf("InscrMunicipal") > -1)
                    oFields.InscrMunicipal = !DBNull.Value.Equals(oRow["InscrMunicipal"]) ? oRow["InscrMunicipal"].ToString() : string.Empty;
                
                if (oData.Tables[0].Columns.IndexOf("EMailNFSe") > -1)
                    oFields.EMailNFSe = !DBNull.Value.Equals(oRow["EMailNFSe"]) ? oRow["EMailNFSe"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Clientes - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Clientes - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //***********************************
            //* Devolve resultados da importação
            //***********************************
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaPais(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Pais - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM pais WHERE codpais > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("País - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaCidade(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Cidade - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM cidade WHERE codcidade > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Cidade - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }
        
        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaBanco(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Banco - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM banco WHERE codbco > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Banco - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaProfissao(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Profissao - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM profissao WHERE codprof > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Profissao - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaPromotor(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Promotor - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            SQL = "SELECT * FROM promotor WHERE codpromotor > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Promotor - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaPosto(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Posto - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM posto WHERE postoven > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Posto - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        static public RetornoWebService ExportaSituacao(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Situacao - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM situacao WHERE sitcli > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Situacao - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaClassifica(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Classifica - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM classifica WHERE tipocli > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Classifica - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }

        [WebMethod]
        [XmlInclude(typeof(RetornoWebService))]
        public RetornoWebService ExportaClientes(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            RetornoWebService oResultado = new RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //***************************
            //* A autenticação é válida?
            //***************************
            Login_Manager oLogin = new Login_Manager();
            if (oLogin.Login(Empresa, Usuario, Senha, DBConnection.GetCurrentSessionConnection()) != string.Empty)
            {
                //*****************************************
                //* Falha na obtenção da string de conexão
                //*****************************************
                oResultado.ErrorList.Add("Clientes - Falha no login: " + oLogin.ErrorText);
                oResultado.Error = true;
                oResultado.Errors = 1;
                oLogin.LogOff();
                return oResultado;
            }

            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM clientes WHERE codcli > 0";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            StringWriter oXMLWriter = new StringWriter();
            oTable.WriteXml(oXMLWriter);

            //**************************
            //* Define dados do retorno
            //**************************
            if (oDBManager.Error) oResultado.ErrorList.Add("Clientes - Seleção de dados:" + oDBManager.ErrorMessage);
            oResultado.XML = Crypto.EncryptString(oXMLWriter.ToString());
            oResultado.Selected = oTable.Rows.Count;
            oResultado.Error = oDBManager.Error;
            return oResultado;
        }
    }
}
