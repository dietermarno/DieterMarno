<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="altera_senha.aspx.cs" Inherits="Decision.ChangePassword" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntAlterarSenha" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        function ValidaSenha(s, e)
        {
            //****************************
            //* Obtem senha e confirmação
            //****************************
            var Senha = txtSenhaAtual.GetText();
            var SenhaNova = txtSenhaNova.GetText();
            var SenhaNovaConfirmacao = s.GetText();

            //******************************************
            //* A senha possui pelo menos 6 caracteres?
            //******************************************
            if (SenhaNova.length < 6)
            {
                e.isValid = false;
                e.errorText = 'A nova senha deve possuir ao menos 6 caracteres.';
                return;
            }

            //*********************************************
            //* As senha e sua confirmação são diferentes?
            //*********************************************
            if (SenhaNova != SenhaNovaConfirmacao)
            {
                e.isValid = false;
                e.errorText = 'A nova senha e sua confirmação não são idênticas.';
            }
        }
    </script>
    
    <div align="left" style="padding-left: 50px;">
        <br />
        <br />
        <table id="tblComandos" style="width: 600px; padding: 20px;">
            <tr>
                <td style="width: 100%; padding-left: 50px;">
                    <div align="left">
                        <h2 class="TextoCinza20">Alteração de Senha</h2>
                        <p class="TextoCinza16">Utilize o formulário abaixo para modificar sua senha.</p>
                        <p class="TextoCinza16">As senhas precisam ter um tamnho mínimo de 6 caracteres.</p>
                        <br />
                        <dx:ASPxLabel ID="lblCurrentPassword" runat="server" AssociatedControlID="txtSenhaAtual" Text="Senha atual:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtSenhaAtual" ClientInstanceName="txtSenhaAtual" runat="server" Password="true" Width="200px" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup" Display="Dynamic" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="A senha anterior deve ser informada." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="txtSenhaNova" Text="Nova senha:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="txtSenhaNova" ClientInstanceName="txtSenhaNova" Password="true" runat="server" Width="200px" CssClass="TextoCinza16">
                            <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup" Display="Dynamic" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="A nova senha deve ser informada." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxLabel ID="lblConfirmPassword" runat="server" AssociatedControlID="tbConfirmPassword" Text="Confirmação:" CssClass="TextoCinza16" />
                        <dx:ASPxTextBox ID="tbConfirmPassword" Password="true" runat="server" Width="200px" CssClass="TextoCinza16">
                            <ClientSideEvents Validation="function(s, e) { ValidaSenha(s, e) }" />
                            <ValidationSettings ValidationGroup="ChangeUserPasswordValidationGroup" Display="Dynamic" ErrorTextPosition="Bottom">
                                <RequiredField ErrorText="A confirmação da nova senha deve ser informada." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                        <br />
                        <dx:ASPxButton ID="btnChangePassword" runat="server" Text="Alterar" ValidationGroup="ChangeUserPasswordValidationGroup" OnClick="btnChangePassword_Click" CssClass="BotaoLinkF16" Width="100px" />
                        &nbsp;
                        <dx:ASPxButton ID="cmdCancelar" runat="server" Text="Cancelar" CssClass="BotaoLinkF16" AutoPostBack="false" ClientSideEvents-Click="function () { location.href='abertura.aspx' }" Width="100px" />
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>