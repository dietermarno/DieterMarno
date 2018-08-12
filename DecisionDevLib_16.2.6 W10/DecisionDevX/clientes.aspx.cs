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
using Decision.Util;

namespace Decision
{
    public partial class clientes : System.Web.UI.Page
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
            Session["CodCli"] = 0;

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
            if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes))
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
            if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes))
                Security_Insert = true;
            if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes))
                Security_Update = true;
            if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes))
                Security_Delete = true;

            #endregion

            //*****************************
            //* Atualiza string de conexão
            //*****************************
            dsClientes.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsCidades.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsBanco.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsPosto.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsClassifica.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsSituacao.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsProfissao.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsPromotor.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsAtendente.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;
            dsTerceiro.ConnectionString = oLogin.LoginInfo.Master_DevArtConexaoString;

            //****************************************
            //* Atualiza BINDs somente na atualização
            //****************************************
            if (!IsPostBack && !IsCallback)
            {
                //*********************************************
                //* Define segurança do cadastro de permissões
                //*********************************************
                grvClientes.SettingsDataSecurity.AllowInsert = oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes);
                grvClientes.SettingsDataSecurity.AllowEdit = oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes);
                grvClientes.SettingsDataSecurity.AllowDelete = oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes);
            }
        }
    }
}