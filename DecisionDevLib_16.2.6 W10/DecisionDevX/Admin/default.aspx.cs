using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decision.Database;
using Decision.Extensions;
using DevExpress.Web;

namespace Decision.Admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConfigurationManager.ConnectionStrings["Master"].ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*******************
            //* Localiza usuário
            //*******************
            SQL = "SELECT * FROM administradores WHERE usuario = '" + this.txtUsuario.Text.SQLFilter() + "'";
            oTable = oDBManager.ExecuteQuery(SQL);

            //****************************
            //* O usuário foi encontrado?
            //****************************
            if (oTable.Rows.Count != 1)
            {
                //**********************
                //* Notifica e finaliza
                //**********************
                this.txtUsuario.ErrorText = "Usuário inexistente.";
                this.txtUsuario.IsValid = false;
                return;
            }

            //********************
            //* A senha é válida?
            //********************
            SQL = "SELECT * FROM administradores WHERE ";
            SQL += "usuario = '" + this.txtUsuario.Text.SQLFilter() + "' AND ";
            SQL += "senha = '" + Util.Crypto.EncryptString(this.txtSenha.Text).SQLFilter() + "'";
            oTable = oDBManager.ExecuteQuery(SQL);

            //****************************
            //* O usuário foi encontrado?
            //****************************
            if (oTable.Rows.Count != 1)
            {
                //**********************
                //* Notifica e finaliza
                //**********************
                this.txtSenha.ErrorText = "Senha inválida.";
                this.txtSenha.IsValid = false;
                return;
            }

            //*********************************
            //* Cria sessão com dados de login
            //*********************************
            Session["Decision_Admin_User"] = this.txtUsuario.Text.ToUpper();
            Session["Decision_Admin_Nome"] = oTable.Rows[0]["nome"];
            Session["Decision_Admin_Codigo"] = oTable.Rows[0]["codigo"];
            Session["Decision_Admin_Email"] = oTable.Rows[0]["email"];

            //**********************************************************
            //* Evita falha de redirecionamento quando em CallBack Mode
            //**********************************************************
            if (!Page.IsCallback)
                Response.Redirect("empresas.aspx", false);
            else
                ASPxWebControl.RedirectOnCallback("empresas.aspx");
        }
    }
}