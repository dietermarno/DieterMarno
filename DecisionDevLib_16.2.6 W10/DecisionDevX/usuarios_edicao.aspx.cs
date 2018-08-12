using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;
using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;
using Decision.Database;
using Decision.TableManager;
using Decision.Extensions;
using Decision.Lists;
using Decision.LoginManager;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using Decision.Secutiry;
using Decision.Util;

namespace Decision
{
    public partial class usuarios_edicao : System.Web.UI.Page
    {
        //************************
        //* Declarações do módulo
        //************************
        Login_Manager oLogin = new Login_Manager();

        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Insert = false;
        public bool Security_Update = false;

        Login_Fields oJSON = new Login_Fields();
        DataTable oTableUsuarios = new DataTable();

        protected void PopulaJSON(Int32 CodigoUsuario)
        {
            //********************************************************
            //* Dados de login e manipulador de registros de usuários
            //********************************************************
            oLogin = (Login_Manager)Session["Decision_LoginInfo"];

            //****************************
            //* Obtém registro do usuário
            //****************************
            oJSON = oLogin.GetRecord(CodigoUsuario, DBConnection.GetCurrentSessionConnection());

            //********************
            //* Parâmetros comuns
            //********************
            oJSON.Parametros.Add("Operacao", "Popular");
        }
        protected Login_Fields Salvar_Registro(Login_Fields oJSON)
        {
            //*****************************************
            //* Executa inclusão e retorna novo código
            //*****************************************
            try
            {
                //*************************
                //* Salva dados do usuário 
                //*************************
                oJSON = oLogin.ApplyRecord(oJSON, DBConnection.GetCurrentSessionConnection());

                //*****************************
                //* Retorna status da operação
                //*****************************
                return oJSON;
            }
            catch (Exception oException)
            {
                //******************************
                //* Retorna erro no manupulador
                //******************************
                oJSON.ErrorText = oException.Message;
                oJSON.Error = true;
                return oJSON;
            }
        }
        protected Login_Fields Validar_Usuario(Login_Fields oJSON)
        {
            //*****************************************
            //* Executa inclusão e retorna novo código
            //*****************************************
            try
            {
                //*************************
                //* Salva dados do usuário 
                //*************************
                oJSON = oLogin.ExistingUser(oJSON, DBConnection.GetCurrentSessionConnection());

                //*****************************
                //* Retorna status da operação
                //*****************************
                return oJSON;
            }
            catch (Exception oException)
            {
                //******************************
                //* Retorna erro no manupulador
                //******************************
                oJSON.ErrorText = oException.Message;
                oJSON.Error = true;
                return oJSON;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Código do registro"

            //**************
            //* Declarações
            //**************
            Int32 CodigoUsuario = 0;

            //***************************
            //* Edição ou novo registro?
            //***************************
            if (Request.QueryString["codigo"] == null)
                CodigoUsuario = 0;
            else
                CodigoUsuario = Convert.ToInt32(Request.QueryString["codigo"]);
            #endregion

            #region "Controle de login"

            //*************************
            //* Obtem dados de conexão
            //*************************
            if (Session["Decision_LoginInfo"] != null)
                oLogin = (Login_Manager)Session["Decision_LoginInfo"];
            else
                oLogin.LogOff();

            //***************
            //* Sem conexão?
            //***************
            if (oLogin.LoginInfo.Usuario_Codigo == 0)
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("conectar.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("conectar.aspx");
            }

            #endregion

            #region "Controle de segurança"

            //****************************************************
            //* Incializa segurança e verifica pemissão de acesso
            //****************************************************
            oSecurity.InitializeSecurity(oLogin);
            if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/abertura.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
            }

            //*************************************************
            //* Define acesso à inclusão, alteração e exclusão
            //*************************************************
            if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
                Security_Insert = true;
            if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
                Security_Update = true;

            //************************************
            //* Possui permissão para a operação?
            //************************************
            if ((!Security_Insert && CodigoUsuario == 0) || (!Security_Update && CodigoUsuario != 0))
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("abertura.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("abertura.aspx");
            }

            #endregion

            #region "Inicialização de datasets e dados da edição"

            //*****************
            //* Define conexão
            //*****************
            dsPromotores.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsGrupos.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsPostos.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;

            #endregion
        }
        protected void clbAtualizar_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            //**********************************
            //* É uma chamada de inicializãção?
            //**********************************
            if (e.Parameter == string.Empty)
            {
                //**************
                //* Declarações
                //**************
                Int32 CodigoUsuario = 0;

                //***************************
                //* Edição ou novo registro?
                //***************************
                if (Request.QueryString["codigo"] == null)
                    CodigoUsuario = 0;
                else
                    CodigoUsuario = Convert.ToInt32(Request.QueryString["codigo"]);

                //******************************
                //* Popula dados no objeto JSON
                //******************************
                if (CodigoUsuario != 0)
                    PopulaJSON(CodigoUsuario);

                //*******************************
                //* Devolve estrutura JSON vazia
                //*******************************
                e.Result = new JavaScriptSerializer().Serialize(oJSON);
            }
            else
            {
                //*************************
                //* Deserializa requisição
                //*************************
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                oJSON = oSerializer.Deserialize<Login_Fields>(e.Parameter);

                //****************************
                //* Localiza container NAVBAR
                //****************************
                switch (oJSON.Parametros["Operacao"])
                {
                    case "Validar_Usuario":

                        //*************************************
                        //* Coleta código da nova oportunidade
                        //*************************************
                        oJSON = Validar_Usuario(oJSON);

                        //*******************************
                        //* Devolve estrutura JSON vazia
                        //*******************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Salvar_Registro":

                        //*************************************
                        //* Coleta código da nova oportunidade
                        //*************************************
                        oJSON = Salvar_Registro(oJSON);

                        //*******************************
                        //* Devolve estrutura JSON vazia
                        //*******************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Teste_SMTP":

                        //*************************************
                        //* Coleta código da nova oportunidade
                        //*************************************
                        oJSON = Salvar_Registro(oJSON);

                        //*************************************
                        //* Coleta código da nova oportunidade
                        //*************************************
                        oJSON = Teste_SMTP(oJSON);

                        //*******************************
                        //* Devolve estrutura JSON vazia
                        //*******************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;
                }
            }
        }
        protected Login_Fields Teste_SMTP(Login_Fields oJSON)
        {
            //**************
            //* Declarações
            //**************
            SendEmail oMail = new SendEmail();

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oJSON = oMail.EnviaTesteSMTP(oJSON, oLogin.LoginInfo.Master_Codigo);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.ErrorText = "Erro ao enviar mensagem: " + oException.Message;
                oJSON.Error = true;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
    }
}