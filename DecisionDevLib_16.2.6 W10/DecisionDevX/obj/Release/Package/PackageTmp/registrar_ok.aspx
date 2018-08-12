<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Root.master" CodeBehind="registrar_ok.aspx.cs" Inherits="Decision.RegisterSuccess" %>

<asp:Content ID="cntRegistrar" ContentPlaceHolderID="cplCentral" runat="server">
    <div align="left" style="padding-left: 50px;">
        <br />
        <br />
        <table id="tblComandos" style="width: 600px; padding: 20px;">
            <tr>
                <td style="width: 100%; text-align: left; align-content:flex-start; padding-left: 50px;">
                    <div align="left">
                        <h2 class="TextoCinza20">Nova Conta</h2>
                        <p class="TextoCinza16">O registro foi realizado com sucesso! 
                            <br />
                            <br />
                            Obrigado por se registrar. </p>
                        <p class="TextoCinza16">Você será counicado por e-mail assim que seu acesso for liberado pelo administrador do sistema.</p>
                        <p>&nbsp;</p>
                        <p class="TextoCinza16">Para acessar a página de login 
                        <a href="conectar.aspx" class="LinkTextoF16">clique aqui</a>.</p>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>