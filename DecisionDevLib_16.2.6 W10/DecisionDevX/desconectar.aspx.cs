using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Decision.LoginManager;

namespace Decision.Account
{
    public partial class Logoff : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            //*********************
            //* Executa desconexão
            //*********************
            oLogin.LogOff();

            //***************
            //* Anula sessão
            //***************
            Session.Abandon();

            //*************************************************************************************
            //* Volta à página inicial, evitando falha de redirecionamento quando em CallBack Mode
            //*************************************************************************************
            if (!Page.IsCallback)
                Response.Redirect("~/conectar.aspx?autologin=False", false);
            else
                ASPxWebControl.RedirectOnCallback("~/conectar.aspx?autologin=False");
        }
    }
}