<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="conectar.aspx.cs" Inherits="Decision.Login" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cplCentral" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">
        
        function AutoLogin(s, e)
        {
            //*****************************
            //* Obtem informações de login
            //*****************************
            if (typeof cmdLogin.cp_empresa != "undefined")
                txtDatabase.SetText(cmdLogin.cp_empresa);

            if (typeof cmdLogin.cp_usuario != "undefined")
                txtUsuario.SetText(cmdLogin.cp_usuario);

            if (typeof cmdLogin.cp_senha != "undefined")
                txtSenha.SetText(cmdLogin.cp_senha);

            if (typeof cmdLogin.cp_manter != "undefined")
                if (cmdLogin.cp_manter == "True")
                    chkPermanecerConectado.SetChecked(true);

            if (typeof cmdLogin.cp_autologin != "undefined")
                if (cmdLogin.cp_autologin == "True")
                    cmdLogin.DoClick();
                else
                    popResposta.Show(s, e);
            else
                popResposta.Show(s, e);
        }

        function ValidaLogin(s, e)
        {
            //******************************
            //* Valida informações de login
            //******************************
            if (txtDatabase.GetText() != "" && txtUsuario.GetText() != "" && txtSenha.GetText() != "")
            {
                var oJSON = {
                    "empresa": txtDatabase.GetText(),
                    "usuario": txtUsuario.GetText(),
                    "senha": txtSenha.GetText(),
                    "manter": chkPermanecerConectado.GetChecked(),
                    "error": "",
                    "field": ""
                };
                clbValidar.PerformCallback(JSON.stringify(oJSON));
            }
            else
                s.SetIsValid(false);
        }

        function RetornoCallback(s, e)
        {
            //****************************************************
            //* Coleta retorno do callback e converte para objeto
            //****************************************************
            var oJSON = JSON.parse(e.result);

            //**************
            //* Houve erro?
            //**************
            if (oJSON.error != "")
            {
                //***********************
                //* Exibe falha de login
                //***********************
                switch (oJSON.field)
                {
                    case "empresa":
                        txtDatabase.SetErrorText(oJSON.error)
                        txtDatabase.SetIsValid(false);
                        break;

                    case "usuario":
                        txtUsuario.SetErrorText(oJSON.error)
                        txtUsuario.SetIsValid(false);
                        break;

                    case "senha":
                        txtSenha.SetErrorText(oJSON.error)
                        txtSenha.SetIsValid(false);
                        break;

                    default:
                        txtSenha.SetErrorText(oJSON.error)
                        txtSenha.SetIsValid(false);
                }
            }
        }

        function Conectar(s, e)
        {
            //********************************************
            //* O formulário foi corretamente preenchido?
            //********************************************
            e.processOnServer = false;

            //******************************
            //* Valida informações de login
            //******************************
            ValidaLogin(s, e);
        }

    </script>

    <dx:ASPxPopupControl ID="popResposta" ClientInstanceName="popResposta" runat="server" 
    AllowDragging="False" AllowResize="False" ViewStateMode="Disabled" ShowCloseButton="false"
    CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter"
    PopupVerticalAlign="WindowCenter" Width="400px" MaxHeight="600px" HeaderText="Acesso ao Sistema" 
    Theme="MetropolisBlue" EnableHierarchyRecreation="false" Modal="true">
    <ClientSideEvents Init="function (s, e) { AutoLogin(s, e); }" />
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div style="width: 320px;" align="left">
                    <h2 class="TextoCinza20">Log In</h2>
                    <p class="TextoCinza16">
                        Por favor, informe sua identificação e senha.<br />
                    </p>
                </div>
                <div style="width: 210px;" align="left">
                    <dx:ASPxTextBox ID="txtDatabase" ClientInstanceName="txtDatabase" Caption="Empresa" runat="server" Width="200px" MaxLength="30" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                        <CaptionSettings Position="Top" />
                        <CaptionStyle CssClass="TextoCinza16" />
                        <ValidationSettings ValidationGroup="Login" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" SetFocusOnError="true" EnableCustomValidation="true">
                            <RequiredField ErrorText="Informe a identificação da empresa." IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
                <br />
                <div style="width: 210px;" align="left">
                    <dx:ASPxTextBox ID="txtUsuario" ClientInstanceName="txtUsuario" Caption="Usuário" runat="server" Width="200px" MaxLength="50" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                        <CaptionSettings Position="Top" />
                        <CaptionStyle CssClass="TextoCinza16" />
                        <ValidationSettings ValidationGroup="Login" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" SetFocusOnError="true" EnableCustomValidation="true">
                            <RequiredField ErrorText="Informe a identificação de usuário." IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
                <br />
                <div style="width: 210px;" align="left">
                    <dx:ASPxTextBox ID="txtSenha" ClientInstanceName="txtSenha" Caption="Senha" runat="server" Password="true" Width="200px" MaxLength="50" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                        <CaptionSettings Position="Top" />
                        <CaptionStyle CssClass="TextoCinza16" />
                        <ValidationSettings ValidationGroup="Login" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" SetFocusOnError="true" EnableCustomValidation="true">
                            <RequiredField ErrorText="Informe a senha de conexão." IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                    <dx:ASPxCheckBox ID="chkPermanecerConectado" ClientInstanceName="chkPermanecerConectado" Text="Permanecer conectado" runat="server" CssClass="TextoCinza14" />
                </div>
                <br />
                <dx:ASPxButton ID="cmdLogin" ClientInstanceName="cmdLogin" runat="server" Text="Conectar" ValidationGroup="Login" CssClass="BotaoLinkF16" CausesValidation="true">
                    <ClientSideEvents Click="function(s, e) { Conectar(s, e); }" />
                </dx:ASPxButton>
                <br />
                <br />
                <div style="width: 380px;" align="center" class="TextoCinza14">
                    Não sei minha senha: <a href="recuperar_senha.aspx" class="LinkTextoF14">recuperar</a> senha.<br />
                    Não tenho acesso: <a href="registrar.aspx" class="LinkTextoF14">criar</a> uma conta<br />
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxCallback ID="clbValidar" ClientInstanceName="clbValidar" runat="server" OnCallback="clbValidar_Callback">
        <ClientSideEvents CallbackComplete="function(s, e) { RetornoCallback(s, e); }" />
    </dx:ASPxCallback>
</asp:Content>