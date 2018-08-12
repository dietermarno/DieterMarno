using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using DevExpress.Web;
using Decision.Lists;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.TableManager;
using Decision.Util;

namespace Decision
{
    public partial class config_smtp : System.Web.UI.Page
    {
        //************************
        //* Declarações do módulo
        //************************
        Login_Manager oLogin = new Login_Manager();
        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Active = false;
        Config_Fields oJSON = new Config_Fields();

        protected void PopulaJSON()
        {
            //******************************
            //* Obtem dados da configuração 
            //******************************
            Config_Manager oManager = new Config_Manager(oLogin.LoginInfo.Master_ConexaoString);

            //****************************
            //* Obtém registro do usuário
            //****************************
            oJSON = oManager.GetRecord();

            //********************
            //* Parâmetros comuns
            //********************
            oJSON.Parametros.Add("Operacao", "Popular");
        }
        protected Config_Fields Salvar_Registro(Config_Fields oJSON)
        {
            //******************************
            //* Obtem dados da configuração 
            //******************************
            Config_Manager oManager = new Config_Manager(oLogin.LoginInfo.Master_ConexaoString);

            //*****************************************
            //* Executa inclusão e retorna novo código
            //*****************************************
            try
            {
                //*************************
                //* Salva dados do usuário 
                //*************************
                oManager.ApplyRecord(oJSON);

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
            if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Gerenciamento_Configuracoes))
                Security_Active = true;

            //************************************
            //* Possui permissão para a operação?
            //************************************
            if (!Security_Active)
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
                PopulaJSON();

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
                oJSON = oSerializer.Deserialize<Config_Fields>(e.Parameter);

                //******************************
                //* Realiza operação solicitada
                //******************************
                switch (oJSON.Parametros["Operacao"])
                {
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
        protected Config_Fields Teste_SMTP(Config_Fields oJSON)
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
                oJSON = oMail.EnviaTesteSMTP(oJSON, oLogin.LoginInfo.Master_Codigo, oLogin.LoginInfo.Posto_Codigo);
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