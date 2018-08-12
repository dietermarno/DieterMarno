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

namespace Decision
{
    public partial class usuarios : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de acesso
        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Insert = false;
        public bool Security_Update = false;
        public bool Security_Delete = false;

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
            if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
                Security_Insert = true;
            if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
                Security_Update = true;
            if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario))
                Security_Delete = true;

            #endregion

            //*****************************
            //* Atualiza string de conexão
            //*****************************
            dsUsuarios.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsGrupos.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsPostos.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
        }
        protected void grvUsuarios_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e)
        {
            //***********************************
            //* Ajusta altura da linha de filtro
            //***********************************
            //if (e.RowType == DevExpress.Web.GridViewRowType.Filter)
            //    e.Row.Height = Unit.Pixel(50);
        }
    }
}