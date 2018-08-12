using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Script.Serialization;
using DevExpress.Web.Classes;
using Decision.LoginManager;
using DevExpress.Web;
using Decision.Database;

namespace Decision 
{
    public partial class Login : System.Web.UI.Page 
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        protected void Page_Load(object sender, EventArgs e)
        {
            //**************************
            //* Existe cookie anterior?
            //**************************
            if (Request.Cookies["Decision_Login"] != null)
            {
                //********************************
                //* Obtem cookie e exclui valores
                //********************************
                cmdLogin.JSProperties.Clear();
                HttpCookie oCookie = Request.Cookies["Decision_Login"];
                cmdLogin.JSProperties.Add("cp_empresa", oCookie.Values["empresa"]);
                cmdLogin.JSProperties.Add("cp_usuario", oCookie.Values["usuario"]);
                cmdLogin.JSProperties.Add("cp_senha", oCookie.Values["senha"]);
                cmdLogin.JSProperties.Add("cp_manter", oCookie.Values["manter"]);
                if (Request.QueryString["autologin"] != null)
                {
                    if (Request.QueryString["autologin"] == "False")
                        cmdLogin.JSProperties.Add("cp_autologin", "False");
                    else
                        cmdLogin.JSProperties.Add("cp_autologin", "True");
                }
                else
                {
                    if (oCookie.Values["manter"] == "True")
                        cmdLogin.JSProperties.Add("cp_autologin", "True");
                    else
                        cmdLogin.JSProperties.Add("cp_autologin", "False");
                }
            }
        }
        protected void clbValidar_Callback(object source, CallbackEventArgs e)
        {
            //*************************
            //* Deserializa requisição
            //*************************
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            var oJSON = oSerializer.Deserialize<dynamic>(e.Parameter);

            //**************************************
            //* Obtem retorno da tentativa de login
            //**************************************
            string Retorno = oLogin.Login(oJSON["empresa"], oJSON["usuario"], oJSON["senha"], DBConnection.GetMasterConnection());

            //****************************
            //* O login foi bem sucedido?
            //****************************
            if (Retorno != string.Empty)
            {
                //***********************
                //* Houve erro no login?
                //***********************
                if (oLogin.Error)
                {
                    //**************************
                    //* Retorna motivo da falha
                    //**************************
                    oJSON["error"] = oLogin.ErrorText;
                    oJSON["field"] = "Conexao";

                    //****************************
                    //* Anula informação de login
                    //****************************
                    HttpCookie oCookie = new HttpCookie("Decision_Login");
                    oCookie.Values.Clear();
                    Response.Cookies.Set(oCookie);
                    cmdLogin.JSProperties["cp_autologin"] = "False";
                }
            }
            else
            {
                //***************
                //* Anula falhas
                //***************
                oJSON["error"] = "";
                oJSON["field"] = "";

                //*********************************************
                //* Deve criar cookie com informação de login?
                //*********************************************
                if (oJSON["manter"])
                {
                    //*****************************
                    //* Salva informações de login
                    //*****************************
                    HttpCookie oCookie = new HttpCookie("Decision_Login");
                    oCookie.Values.Clear();
                    oCookie.Values["empresa"] = oJSON["empresa"];
                    oCookie.Values["usuario"] = oJSON["usuario"];
                    oCookie.Values["senha"] = oJSON["senha"];
                    oCookie.Values["manter"] = Convert.ToString(oJSON["manter"]);
                    oCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(oCookie);
                }
                else
                {
                    //**************************
                    //* Existe cookie anterior?
                    //**************************
                    if (Request.Cookies["Decision_Login"] != null)
                    {
                        //********************************
                        //* Obtem cookie e exclui valores
                        //********************************
                        HttpCookie oCookie = Request.Cookies["Decision_Login"];
                        oCookie.Expires = DateTime.Now.AddDays(-1);
                        oCookie.Values.Clear();
                        Response.Cookies.Set(oCookie);
                    }
                }

                //****************************
                //* Salva informação de login
                //****************************
                Session["Decision_LoginInfo"] = oLogin;

                //******************************************************************************************
                //* Sim. Volta à página inicial, evitando falha de redirecionamento quando em CallBack Mode
                //******************************************************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/abertura.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
            }

            //*******************************
            //* Devolve estrutura JSON vazia
            //*******************************
            e.Result = new JavaScriptSerializer().Serialize(oJSON);
        }
    }
}