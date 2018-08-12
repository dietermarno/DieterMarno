<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="recuperar_senha_ok.aspx.cs" Inherits="Decision.recuperar_senha_ok" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplCentral" runat="server">
    <div align="left" style="padding-left: 50px;">
        <br />
        <br />
        <table id="tblComandos" style="width: 600px; padding: 20px;">
            <tr>
                <td style="width: 100%; text-align: left; align-content:flex-start; padding-left: 50px;">
                    <div align="left">
                        <h2 class="TextoCinza20">Recuperação de senha</h2>
                        <p class="TextoCinza16">A recuperação de senha foi realizada com sucesso
                            <br />
                            <br />
                            Verifique a mensagem em seu e-mail. </p>
                        <p class="TextoCinza16">Recomensamos que você altere sua senha após este processo.</p>
                        <p>&nbsp;</p>
                        <p class="TextoCinza16">Para acessar a página de login 
                        <a href="conectar.aspx" class="LinkTextoF16">clique aqui</a>.</p>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
