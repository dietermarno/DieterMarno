using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.Lists;
using Decision.TableManager;
using DevExpress.Web;

namespace Decision
{
    public partial class oportunidades_exclusao : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de acesso
        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Delete = false;

        protected void Page_Init(object sender, EventArgs e)
        {
            //**************
            //* Declarações
            //**************
            Int32 Nro_Oportunidade = 0;

            //*********************************
            //* Tenta obter código do registro
            //*********************************
            if (Request.QueryString["codigo"] == null)
                Nro_Oportunidade = 0;
            else
                Nro_Oportunidade = Convert.ToInt32(Request.QueryString["codigo"]);

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
                if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
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
                if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                    Security_Delete = true;

                //*********************************
                //* Possui permissão para excluir?
                //*********************************
                if (!Security_Delete)
                {
                    //**********************************************************
                    //* Evita falha de redirecionamento quando em CallBack Mode
                    //**********************************************************
                    if (!Page.IsCallback)
                        Response.Redirect("~/abertura.aspx", false);
                    else
                        ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
                }

            #endregion

            //*********************************
            //* Obteve número da oportunidade?
            //*********************************
            if (Nro_Oportunidade != 0)
            {
                //*******************
                //* Executa exclusão
                //*******************
                Oportunidade_Manager oManager = new Oportunidade_Manager(oLogin.LoginInfo.Master_ConexaoString);
                Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
                oOportunidade.PK_nro_oportunidade = Nro_Oportunidade;
                oManager.DeleteRecord(oOportunidade);

                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/oportunidades.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/oportunidades.aspx");
            }
        }
    }
}