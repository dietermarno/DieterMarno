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
using Decision.Database;
using DevExpress.Web;

namespace Decision 
{
    public partial class Register : System.Web.UI.Page 
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        protected void clbAtualizar_Callback(object source, CallbackEventArgs e)
        {
            //*************************
            //* Deserializa requisi��o
            //*************************
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            var oJSON = oSerializer.Deserialize<dynamic>(e.Parameter);

            //*****************************
            //* Define opera��o � executar
            //*****************************
            switch((string)oJSON["operacao"])
            {
                case "Cadastra_Usuario":

                    //********************
                    //* A empresa existe?
                    //********************
                    if (oLogin.ExistingDatabase(oJSON["empresa"], DBConnection.GetMasterConnection()) == "true")
                    {
                        //***********************
                        //* O usu�rio j� esiste?
                        //***********************
                        if (oLogin.ExistingUser(oJSON["empresa"], oJSON["usuario"], DBConnection.GetMasterConnection()) == "false")
                        {
                            //*************************************
                            //* O cadastro foi criado com sucesso?
                            //*************************************
                            if (oLogin.CreateUser(oJSON["empresa"], oJSON["usuario"], oJSON["senha"], oJSON["email"], oJSON["telefone"], DBConnection.GetMasterConnection()) == "true")
                            {
                                //*************************************
                                //* O cadastro foi criado com sucesso?
                                //*************************************
                                oJSON["errorText"] = "0|";
                                oJSON["error"] = false;
                            }
                            else
                            {
                                //***********************************
                                //* Houve erro na cria��o do usu�rio
                                //***********************************
                                oJSON["errorText"] = "U|Falha na cria��o do usu�rio.";
                                oJSON["error"] = true;
                            }
                        }
                        else
                        {
                            //***********************************
                            //* Houve erro na cria��o do usu�rio
                            //***********************************
                            if (oJSON["usuario"] == string.Empty)
                                oJSON["errorText"] = "U|Informe seu nome de usu�rio.";
                            else
                                oJSON["errorText"] = "U|Identifica��o de usu�rio j� existe.";
                            oJSON["error"] = true;
                        }
                    }
                    else
                    {
                        //***********************************
                        //* Houve erro na cria��o do usu�rio
                        //***********************************
                        if (oJSON["empresa"] == string.Empty)
                            oJSON["errorText"] = "E|Informe o nome da empresa.";
                        else
                            oJSON["errorText"] = "E|Empresa inexistente.";
                        oJSON["error"] = true;
                    }
                    break;
            }

            //****************************
            //* Serializa dados e devolve
            //****************************
            e.Result = new JavaScriptSerializer().Serialize(oJSON);
        }
    }
}