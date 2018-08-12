<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="recuperar_senha.aspx.cs" Inherits="Decision.recuperar_senha" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntRecuperarSenha" ContentPlaceHolderID="cplCentral" runat="server">
    <script type="text/javascript">

        //***************************
        //* Dados de envio e retorno
        //***************************
        var oJSON = {
            "usuario": "",
            "email": "",
            "operacao": "",
            "error": "",
            "errorText": ""
        };

        function ObterSenha(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;
            cmdRecuperarSenha.SetEnabled(false);

            //**************************
            //* Cria estrutura de dados
            //**************************
            oJSON.usuario = txtUsuario.GetText();
            oJSON.email = txtEmail.GetText();
            oJSON.operacao = "Recuperar_Senha";
            oJSON.error = false;
            oJSON.errorText = "";

            //*******************************
            //* Executa recuperação de senha
            //*******************************
            clbAtualizar.PerformCallback(JSON.stringify(oJSON));
        }

        function RetornoCallback(s, e)
        {
            //****************************************************
            //* Coleta retorno do callback e converte para objeto
            //****************************************************
            oJSON = JSON.parse(e.result);
            cmdRecuperarSenha.SetEnabled(true);

            //************************************
            //* Executa retorno conforme operação
            //************************************
            switch (oJSON.operacao)
            {
                case "Recuperar_Senha":

                    //***************************
                    //* Houve erro de validação?
                    //***************************
                    if (oJSON.error)
                    {
                        //************************************
                        //* Separa destino do erro e mensagem
                        //************************************
                        var errorParts = oJSON.errorText.split(':');

                        //******************************************
                        //* Define mensagem no campo correspondente
                        //******************************************
                        if (errorParts[0] == "usuario")
                        {
                            txtUsuario.SetErrorText(errorParts[1]);
                            txtUsuario.SetIsValid(false);
                        }
                        else
                        {
                            txtEmail.SetErrorText(errorParts[1]);
                            txtEmail.SetIsValid(false);
                        }
                    }
                    else
                    {
                        //*********************************
                        //* Cadastro realizado com sucesso
                        //*********************************
                        location.href = "recuperar_senha_ok.aspx";
                    }
                    break;
            }
        }

    </script>

    <div align="left" style="padding-left: 50px;">
        <br />
        <br />
        <table id="tblComandos" style="width: 600px; padding: 20px;">
            <tr>
                <td style="width: 100%; text-align: left; align-content:flex-start; padding-left: 50px;">
                    <div align="left">
                        <h2 class="TextoCinza20">Recuperação de senha</h2>
                        <p class="TextoCinza16">Utilize o formulário abaixo para recuperar sua senha.</p>
                        <p class="TextoCinza16">Informe seu ID de usuario e seu endereço e-mail, definidos na criação de sua conta.</p>
                        <br />
                        <dx:ASPxLabel ID="lblUserName" runat="server" AssociatedControlID="txtUsuario" Text="Usuário:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtUsuario" ClientInstanceName="txtUsuario" runat="server" Width="200px" MaxLength="50" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="Informe seu nome de usuário." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxLabel ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="E-mail:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtEmail" ClientInstanceName="txtEmail" runat="server" Width="200px" MaxLength="50" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="Informe seu endereço de e-mail." IsRequired="true" />
                                <RegularExpression ErrorText="O e-mail informado é inválido." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <br />
                        <dx:ASPxButton ID="cmdRecuperarSenha" ClientInstanceName="cmdRecuperarSenha" runat="server" Text="Recuperar" ValidationGroup="Formulario" CssClass="BotaoLinkF16" Width="100px">
                            <ClientSideEvents Click="function (s, e) { ObterSenha(s, e); }" />
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="BotaoLinkF16" AutoPostBack="false" Width="100px">
                            <ClientSideEvents Click="function () { location.href='conectar.aspx' }" />
                        </dx:ASPxButton>
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <dx:ASPxCallback ID="clbAtualizar" ClientInstanceName="clbAtualizar" runat="server" OnCallback="clbAtualizar_Callback">
        <ClientSideEvents CallbackComplete="function(s, e) { RetornoCallback(s, e); }" />
    </dx:ASPxCallback>

</asp:Content>
