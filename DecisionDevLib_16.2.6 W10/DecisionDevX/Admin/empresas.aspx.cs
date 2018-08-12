using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decision.Util;
using Decision.Extensions;
using Decision.Database;
using Decision.Secutiry;

namespace Decision.Admin
{
    public partial class empresas : System.Web.UI.Page
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
        protected void dsEmpresas_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
            //************************
            //* Elimina valores nulos
            //************************
            foreach (System.Data.Common.DbParameter oParameter in e.Command.Parameters)
                oParameter.Value = DBUtilities.ParseNullField(oParameter);

            //*****************
            //* Encripta senha
            //*****************
            e.Command.Parameters["conexao_password"].Value = Crypto.EncryptString(e.Command.Parameters["conexao_password"].Value.ToString());
        }
        protected void dsEmpresas_Updating(object sender, SqlDataSourceCommandEventArgs e)
        {
            //************************
            //* Elimina valores nulos
            //************************
            foreach (System.Data.Common.DbParameter oParameter in e.Command.Parameters)
                oParameter.Value = DBUtilities.ParseNullField(oParameter);

            //*****************
            //* Encripta senha
            //*****************
            e.Command.Parameters["conexao_password"].Value = Crypto.EncryptString(e.Command.Parameters["conexao_password"].Value.ToString());
        }
        protected void grvEmpresas_SearchPanelEditorCreate(object sender, ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            //***********************************
            //* Define estilo do painel de busca
            //***********************************
            e.EditorProperties.Style.CssClass = "Texto16";
        }
        protected void grvEmpresas_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

            //*******************
            //* Formata telefone
            //*******************
            if (e.Column.FieldName == "cnpj_cpf") 
            {
                if (e.Value.ToString().Length < 12)
                {
                    System.ComponentModel.MaskedTextProvider oMask = new System.ComponentModel.MaskedTextProvider(@"000\.000\.000-00");
                    oMask.Set(e.Value.ToString());
                    e.DisplayText = oMask.ToString();
                }
                else
                {
                    System.ComponentModel.MaskedTextProvider oMask = new System.ComponentModel.MaskedTextProvider(@"00\.000\.000-0000-00");
                    oMask.Set(e.Value.ToString());
                    e.DisplayText = oMask.ToString();
                }
            }

            if (e.Column.FieldName == "contato_fone_fixo" || e.Column.FieldName == "contato_fone_celular") 
            {
                System.ComponentModel.MaskedTextProvider oMask = new System.ComponentModel.MaskedTextProvider("(00) 000-000-000");
                oMask.Set(e.Value.ToString());
                e.DisplayText = oMask.ToString();
            }
        }
        protected void clbAtualizar_Callback(object source, CallbackEventArgs e)
        {
            //*************************
            //* Deserializa requisição
            //*************************
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            var oJSON = oSerializer.Deserialize<dynamic>(e.Parameter);
            string Conexao = string.Empty;

            //*****************************
            //* Define operação à executar
            //*****************************
            switch ((string)oJSON["operacao"])
            {
                case "Validar_Conexao":

                    //********************
                    //* Driver ODBC/MySQL
                    //********************
                    Conexao = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                            oJSON["conexao_driver"], oJSON["conexao_server"], oJSON["conexao_database"], 
                                            oJSON["conexao_port"], oJSON["conexao_user"], oJSON["conexao_password"]);

                    //********************************************
                    //* Obtem conexão a partir do nome da empresa
                    //********************************************
                    DBManager oDBManager = new DBManager(Conexao);

                    //***************************************************
                    //* Realiza operação de consulta para testar conexão
                    //***************************************************
                    oDBManager.ExecuteQuery("SELECT * FROM usuarios");

                    //****************************************
                    //* Retorna status da operação ao cliente
                    //****************************************
                    oJSON["errorText"] = oDBManager.ErrorMessage;
                    oJSON["error"] = oDBManager.Error;

                    //*****************
                    //* Libera objetos
                    //*****************
                    oDBManager.Dispose();
                    break;

                case "Atualizar_Banco":

                    //********************
                    //* Driver ODBC/MySQL
                    //********************
                    Conexao = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                            oJSON["conexao_driver"], oJSON["conexao_server"], oJSON["conexao_database"],
                                            oJSON["conexao_port"], oJSON["conexao_user"], oJSON["conexao_password"]);

                    //*****************************************************
                    //* Inicia atualização e retorna mensagem para cliente
                    //*****************************************************
                    Security_Manager oSecutiry = new Security_Manager();
                    oJSON["errorText"] = oSecutiry.DatabaseUpdate(Conexao, oJSON["conexao_database"]);
                    oJSON["error"] = false;
                    break;
            }

            //****************************
            //* Serializa dados e devolve
            //****************************
            e.Result = new JavaScriptSerializer().Serialize(oJSON);
        }
        protected void txtConexaoPassword_DataBound(object sender, EventArgs e)
        {
            //********************
            //* Desencripta senha
            //********************
            if (((ASPxTextBox)sender).Value != null)
                ((ASPxTextBox)sender).Value = Crypto.DecryptString(((ASPxTextBox)sender).Value.ToString());

        }
    }
}