<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="registrar.aspx.cs" Inherits="Decision.Register" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:content id="cntRegistrar" contentplaceholderid="cplCentral" runat="server">

    <script type="text/javascript">

        //***************************
        //* Dados de envio e retorno
        //***************************
        var oJSON = {
            "empresa": "",
            "usuario": "",
            "senha": "",
            "email": "",
            "operacao": "",
            "error": "",
            "errorText": ""
        };

        function ValidaSenha(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //****************************
            //* Obtem senha e confirmação
            //****************************
            var Senha = txtSenha.GetText();
            var Confirmacao = s.GetText();

            //******************************************
            //* A senha possui pelo menos 6 caracteres?
            //******************************************
            if (Senha.length < 6)
            {
                e.errorText = 'A senha deve possuir ao menos 6 caracteres.';
                e.isValid = false;
                return;
            }

            //*********************************************
            //* As senha e sua confirmação são diferentes?
            //*********************************************
            if (Senha != Confirmacao)
            {
                e.errorText = 'A senha e sua confirmação não são idênticas.';
                e.isValid = false;
            }
        }

        function CadastraUsuario(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //**************************
            //* Cria estrutura de dados
            //**************************
            oJSON.empresa = txtDatabase.GetText();
            oJSON.usuario = txtUsuario.GetText();
            oJSON.email = txtEmail.GetText();
            oJSON.telefone = txtTelefone.GetText();
            oJSON.senha = txtSenha.GetText();
            oJSON.operacao = "Cadastra_Usuario";
            oJSON.error = false;
            oJSON.errorText = "";

            //*****************************
            //* Executa criação de usuário
            //*****************************
            clbAtualizar.PerformCallback(JSON.stringify(oJSON));
        }

        function RetornoCallback(s, e)
        {
            //****************************************************
            //* Coleta retorno do callback e converte para objeto
            //****************************************************
            oJSON = JSON.parse(e.result);

            //************************************
            //* Executa retorno conforme operação
            //************************************
            switch (oJSON.operacao)
            {
                case "Cadastra_Usuario":

                    //***************************
                    //* Houve erro de validação?
                    //***************************
                    if (oJSON.error)
                    {
                        //************************************
                        //* Separa destino do erro e mensagem
                        //************************************
                        var errorParts = oJSON.errorText.split('|');

                        //******************************************
                        //* Define mensagem no campo correspondente
                        //******************************************
                        if (errorParts[0] == "U") {
                            txtUsuario.SetErrorText(errorParts[1]);
                            txtUsuario.SetIsValid(false);
                        }
                        else
                        {
                            txtDatabase.SetErrorText(errorParts[1]);
                            txtDatabase.SetIsValid(false);
                        }
                    }
                    else
                    {
                        //*********************************
                        //* Cadastro realizado com sucesso
                        //*********************************
                        location.href = "registrar_ok.aspx";
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
                        <h2 class="TextoCinza20">Nova Conta</h2>
                        <p class="TextoCinza16">Utilize o formulário abaixo para criar uma nova conta.</p>
                        <p class="TextoCinza16">As senhas precisam ter um tamnho mínimo de 6 caracteres.</p>
                        <br />
                        <dx:ASPxLabel ID="lblEmpresa" runat="server" AssociatedControlID="txtDatabase" Text="Empresa:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtDatabase" ClientInstanceName="txtDatabase" runat="server" Width="200px" MaxLength="30" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="Informe o nome da empresa." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
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
                        <dx:ASPxLabel ID="lblTelefone" runat="server" AssociatedControlID="txtTelefone" Text="Telefone:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtTelefone" ClientInstanceName="txtTelefone" runat="server" Width="200px" MaxLength="20" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <MaskSettings Mask="(99) 9999-99999" IncludeLiterals="None" PromptChar=" " />
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="Informe seu telefone." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="txtSenha" Text="Senha:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtSenha" ClientInstanceName="txtSenha" Password="true" runat="server" Width="200px" MaxLength="50" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" ValidationSettings-EnableCustomValidation="False" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="Informe sua senha de conexão." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxLabel ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmacao" Text="Confirme a senha:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtConfirmacao" ClientInstanceName="txtConfirmacao" Password="True" runat="server" Width="200px" MaxLength="50" ValidationSettings-ErrorDisplayMode="ImageWithText" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <ClientSideEvents Validation="function(s, e) { ValidaSenha(s, e) }"></ClientSideEvents>
                            <ValidationSettings ValidationGroup="Formulario" ErrorTextPosition="Bottom" EnableCustomValidation="true">
                                <RequiredField ErrorText="Informe a confirmação de sua senha." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxButton ID="cmdCriarUsuario" ClientInstanceName="cmdCriarUsuario" runat="server" Text="Criar" ValidationGroup="Formulario" CssClass="BotaoLinkF16" Width="100px">
                            <ClientSideEvents Click="function (s, e) { CadastraUsuario(s, e); }" />
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
</asp:content>