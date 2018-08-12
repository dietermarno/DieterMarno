using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DevExpress.Web.Classes;
using Decision.LoginManager;
using DevExpress.Web;
using Decision.Database;

namespace Decision 
{
    public partial class ChangePassword : System.Web.UI.Page 
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        protected void Page_Load(object sender, EventArgs e) 
        {
            //*************************
            //* Obtem dados de conexão
            //*************************
            if (Session["Decision_LoginInfo"] != null)
                oLogin = (Login_Manager)Session["Decision_LoginInfo"];
            else
                oLogin.LogOff();
        }
        protected void btnChangePassword_Click(object sender, EventArgs e) 
        {
            //**************************************
            //* Obtem retorno da tentativa de login
            //**************************************
            string Retorno = oLogin.PasswordUpdate(oLogin.LoginInfo.Master_Empresa, oLogin.LoginInfo.Usuario_ID, this.txtSenhaAtual.Text, this.txtSenhaNova.Text, DBConnection.GetMasterConnection());

            //****************************
            //* O login foi bem sucedido?
            //****************************
            if (Retorno != "Ok")
            {
                //*****************************
                //* Não. Exibe motivo da falha
                //*****************************
                this.txtSenhaAtual.ErrorText = oLogin.ErrorText;
                this.txtSenhaAtual.IsValid = false;
            }
            else
            {
                //****************************
                //* Salva informação de login
                //****************************
                Session["Decision_LoginInfo"] = oLogin;

                //******************************************************************************************
                //* Sim. Volta à página inicial, evitando falha de redirecionamento quando em CallBack Mode
                //******************************************************************************************
                if (!Page.IsCallback)
                    Response.Redirect("altera_senha_ok.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("altera_senha_ok.aspx");
            }
        }
    }
}