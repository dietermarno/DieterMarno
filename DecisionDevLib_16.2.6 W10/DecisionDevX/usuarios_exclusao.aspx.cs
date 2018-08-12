using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.Lists;
using Decision.Database;

namespace Decision
{
    public partial class usuarios_exclusao : System.Web.UI.Page
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
            Int32 CodigoUsuario = 0;

            //**********************************
            //* Pode obter o código do usuário?
            //**********************************
            if (Request.QueryString["codigo"] == null)
                CodigoUsuario = 0;
            else
                CodigoUsuario = Convert.ToInt32(Request.QueryString["codigo"]);

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
            if (CodigoUsuario != 0)
            {
                //*******************
                //* Executa exclusão
                //*******************
                oLogin.DeleteUser(CodigoUsuario, DBConnection.GetCurrentSessionConnection());

                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/usuarios.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/usuarios.aspx");
            }
        }
    }
}