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
using Decision.Util;

namespace Decision
{
    public partial class recuperar_senha : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        protected void clbAtualizar_Callback(object source, CallbackEventArgs e)
        {
            //*************************
            //* Deserializa requisição
            //*************************
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            var oJSON = oSerializer.Deserialize<dynamic>(e.Parameter);
            List<PasswordRecoveryUserList> oList = new List<PasswordRecoveryUserList>();
            SendEmail oSendEmail = new SendEmail();
            
            //*****************************
            //* Define operação à executar
            //*****************************
            switch ((string)oJSON["operacao"])
            {
                case "Recuperar_Senha":

                    //********************
                    //* A empresa existe?
                    //********************
                    if (oLogin.PasswordRecovery(oJSON["usuario"], oJSON["email"], DBConnection.GetMasterConnection(), ref oList) == "Ok")
                    {
                        //***************************
                        //* Recuperação bem sucedida
                        //***************************
                        oJSON["errorText"] = string.Empty;
                        oJSON["error"] = false;

                        //********************************
                        //* Remete comunicados por e-mail
                        //********************************
                        foreach (PasswordRecoveryUserList oUserData in oList)
                        {
                            if (oSendEmail.EnviaRecuperacaoSenha(oUserData.Empresa_Codigo, oUserData.Conexao_Nome, 
                                                                 oUserData.Posto_Codigo, oUserData.Usuario_Nome, 
                                                                 oUserData.Usuario_Email, oUserData.Usuario_ID, 
                                                                 oUserData.Usuario_Senha) != "Ok")
                            {
                                oJSON["errorText"] = "Não foi possível enviar comunicado para um ou mais destinatários.";
                                oJSON["error"] = true;
                            }
                        }
                    }
                    else
                    {
                        //***********************
                        //* Falha na recuperação
                        //***********************
                        oJSON["errorText"] = oLogin.ErrorText;
                        oJSON["error"] = oLogin.Error;
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