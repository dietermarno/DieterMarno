using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace Decision.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        //*** Dados de login
        public string UserLoginInfo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            //************************
            //* Há usuário conectado?
            //************************
            if (Session["Decision_Admin_Codigo"] ==  null)
            {
                //*******************
                //* Dados do usuário
                //*******************
                UserLoginInfo = string.Empty;

                //************************
                //* Não há usuário logado
                //************************
                this.divLoggedOff.Visible = true;
                this.divLoggedIn.Visible = false;

            }
            else
            {
                //*******************
                //* Dados do usuário
                //*******************
                UserLoginInfo = "Bem vindo, " + Session["Decision_Admin_Nome"].ToString().ToUpper() + "<br/>";
                UserLoginInfo += "Usuário administrador: " + Session["Decision_Admin_User"].ToString().ToUpper();

                //*********************
                //* Há operador logado
                //*********************
                this.divLoggedOff.Visible = false;
                this.divLoggedIn.Visible = true;
            }
        }
    }
}