using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Classes;
using DevExpress.Web;
using Decision.LoginManager;
using Decision.Secutiry;

namespace Decision 
{
    public partial class RootMaster : System.Web.UI.MasterPage 
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de seguran�a e acesso
        Security_Manager oSecurity = new Security_Manager();

        //*** Dados de login
        public string UserLoginInfo = string.Empty;
        protected void DadosLoginUsuario()
        {
            //********************
            //* H� dados de login
            //********************
            if (oLogin.LoginInfo.Usuario_Codigo == 0)
            {
                //************************************
                //* Exibe pedido de cadastro ou login
                //************************************
                this.divLoggedIn.Visible = false;
                this.divLoggedOff.Visible = true;
                this.navMenu.Enabled = false;
                this.pnlEsquerdo.Visible = false;
                this.pnlTopo.Visible = false;

                //*************************
                //* Oculta nome do usu�rio
                //*************************
                this.lblUsuario.Text = string.Empty;
                UserLoginInfo = "DECISION - Travel Manager System";
            }
            else
            {
                //***********************************
                //* Exibe dados do usu�rio conectado
                //***********************************
                this.divLoggedIn.Visible = true;
                this.divLoggedOff.Visible = false;
                this.navMenu.Enabled = true;
                this.pnlEsquerdo.Visible = true;
                this.pnlTopo.Visible = true;

                //************************
                //* Exibe nome do usu�rio
                //************************
                this.lblUsuario.Text = "Bem Vindo " + oLogin.LoginInfo.Usuario_ID.ToUpper();

                //**************************
                //* Define daods da empresa
                //**************************
                string Empresa = oLogin.LoginInfo.Posto_Descricao.ToUpper();
                if (Empresa != string.Empty && oLogin.LoginInfo.Master_Empresa.ToUpper() != string.Empty)
                    Empresa += " - ";
                Empresa += oLogin.LoginInfo.Master_Empresa.ToUpper();
                this.lblEmpresa.Text += Empresa;
                UserLoginInfo = oLogin.LoginInfo.Posto_Nome.ToUpper();

                //*****************************************
                //* Define situa��o de seguran�a dos menus
                //*****************************************
                oSecurity.InitializeSecurity(oLogin);
            }
        }
        protected void Page_Load(object sender, EventArgs e) 
        {
            //*************************
            //* Obtem dados de conex�o
            //*************************
            if (Session["Decision_LoginInfo"] != null)
                oLogin = (Login_Manager)Session["Decision_LoginInfo"];
            else
                oLogin.LogOff();
            
            //***************************
            //* Define situa��o de login
            //***************************
            DadosLoginUsuario();
        }
        protected void navMenu_PreRender(object sender, EventArgs e)
        {
            //*****************************
            //* Atualiza seguran�a do menu 
            //*****************************
            oSecurity.MenuSecurity(oLogin, (ASPxNavBar)sender);
        }
    }
}