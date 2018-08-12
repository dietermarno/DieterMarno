using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DevExpress.Web;
using Decision.Util;
using Decision.Database;
using Decision.Extensions;

namespace Decision.Admin
{
    public partial class administradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //******************************
            //* Há um administrador logado?
            //******************************
            if (Session["Decision_Admin_User"] == null || Session["Decision_Admin_Codigo"] == null)
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("default.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("default.aspx");
            }
        }
        protected void dsAdministradores_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            //************************
            //* Elimina valores nulos
            //************************
            foreach (System.Data.Common.DbParameter oParameter in e.Command.Parameters)
                oParameter.Value = DBUtilities.ParseNullField(oParameter);

            //*****************
            //* Encripta senha
            //*****************
            e.Command.Parameters["senha"].Value = Crypto.EncryptString(e.Command.Parameters["senha"].Value.ToString());
        }
        protected void dsAdministradores_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            //************************
            //* Elimina valores nulos
            //************************
            foreach (System.Data.Common.DbParameter oParameter in e.Command.Parameters)
                oParameter.Value = DBUtilities.ParseNullField(oParameter);

            //*****************
            //* Encripta senha
            //*****************
            e.Command.Parameters["senha"].Value = Crypto.EncryptString(e.Command.Parameters["senha"].Value.ToString());
        }
        protected void grvAdministradores_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            //***********************************
            //* Define estilo do painel de busca
            //***********************************
            e.EditorProperties.Style.CssClass = "Texto16";
        }
        protected void grvAdministradores_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            //*******************
            //* Formata telefone
            //*******************
            if (e.Column.FieldName != "telefone") return;

            System.ComponentModel.MaskedTextProvider oMask = new System.ComponentModel.MaskedTextProvider("(00) 000-000-000");
            oMask.Set(e.Value.ToString());
            e.DisplayText = oMask.ToString();
        }
        protected void grvAdministradores_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //**************
            //* Declarações
            //**************
            DBManager oManager = new DBManager(ConfigurationManager.ConnectionStrings["Master"].ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***************************
            //* É inclusão ou alteração?
            //***************************
            if (e.IsNewRow)
            {
                //******************************
                //* Inclusão, valida só usuário
                //******************************
                SQL = "SELECT Codigo FROM administradores WHERE usuario = '" + e.NewValues["usuario"] + "'";
            }
            else
            {
                //******************************************************
                //* Alteração, valida só usuário em conjunto com código
                //******************************************************
                SQL = "SELECT Codigo FROM administradores WHERE usuario = '" + e.NewValues["usuario"] + "' AND ";
                SQL += "Codigo <> " + e.Keys["codigo"];
            }

            //***********************
            //* Pesquisa redundância
            //***********************
            oTable = oManager.ExecuteQuery(SQL);

            //*****************************
            //* Existe usuário redundante?
            //*****************************
            if (oTable.Rows.Count > 0)
                e.Errors[this.grvAdministradores.Columns["usuario"]] = "Identificação em uso.";
        }
        protected void txtSenha_DataBound(object sender, EventArgs e)
        {
            //********************
            //* Desencripta senha
            //********************
            if (((ASPxTextBox)sender).Value != null)
                ((ASPxTextBox)sender).Value = Crypto.DecryptString(((ASPxTextBox)sender).Value.ToString());
        }
    }
}