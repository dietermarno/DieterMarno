<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperar_senha_email.aspx.cs" Inherits="Decision.recuperar_senha_email" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Decision - Solicitação de Recuperação de Senha</title>
    <base href="<%# Eval(HTML_Base)%>/" target="_blank">
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.12.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="padding-top: 10px;">

            <input type="hidden" runat="server" id="txtCodigoMaster" />
            <input type="hidden" runat="server" id="txtCodigoPosto" />

            <table style="width: 800px; border: 1px solid #808080;">
                <tr>
                    <td style="width: 10%; padding-top: 15px;">
                        <img src="<%=HTML_Base%>/exibe_logo_posto.ashx?CMA=<%=CodigoMaster%>&CPO=<%=CodigoPosto%>" style="width: 200px;" />
                    </td>
                    <td style="width: 90%; padding: 15px;">
                        <dx:ASPxLabel ID="lblNroOrcamento" CssClass="TextoCinza20" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblNomePosto" CssClass="TextoCinza20" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblEndereco" CssClass="TextoCinza16" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblContato" CssClass="TextoCinza16" runat="server" Text="" />
                    </td>
                </tr>
            </table>
            <table style="width: 800px; border: 1px solid #808080; border-top: 0px solid;">
                <tr>
                    <td style="width: 100%; padding: 15px;">
                        Recuperação de senha
                        <br />
                        <br />
                        Conforme solicitado, segue a baixo seus dados para acesso ao sistema:
                        <br />
                        <br />
                        Empresa: <dx:ASPxLabel ID="lblEmpresa" CssClass="TextoCinza16" runat="server" Text="" /><br />
                        Usuario: <dx:ASPxLabel ID="lblUsuario" CssClass="TextoCinza16" runat="server" Text="" /><br />
                        Senha: <dx:ASPxLabel ID="lblSenha" CssClass="TextoCinza16" runat="server" Text="" /><br />
                        <br />
                        <br />
                        Para sua segurança, recomendamos que você altere sua senha de acesso periodicamente.
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
