<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Decision.Admin._default" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="cntConteudo" ContentPlaceHolderID="cphConteudo" runat="server">
    <div align="center">
        <dx:ASPxPopupControl ID="popResposta" ClientInstanceName="popResposta" runat="server" ViewStateMode="Disabled" ShowCloseButton="false"
            CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter"
            PopupVerticalAlign="WindowCenter" Width="400px" MaxHeight="600px" HeaderText="Acesso ao Sistema"
            Theme="MetropolisBlue" EnableHierarchyRecreation="false" Modal="true">
            <ClientSideEvents Init="function(s, e) { popResposta.Show(s, e); }" />
            <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div style="width: 320px;" align="left">
                        <h2 class="TextoCinza20">Administração</h2>
                        <p class="TextoCinza16">
                            Por favor, informe sua identificação e senha.<br />
                        </p>
                    </div>
                    <br />
                    <div style="width: 210px;" align="left">
                        <dx:ASPxTextBox ID="txtUsuario" Caption="Usuário" runat="server" Width="200px" MaxLength="20" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <CaptionSettings Position="Top" />
                            <CaptionStyle CssClass="TextoCinza16" />
                            <ValidationSettings ValidationGroup="Login" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" SetFocusOnError="true" EnableCustomValidation="true">
                                <RequiredField ErrorText="Informe a identificação de usuário." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </div>
                    <br />
                    <div style="width: 210px;" align="left">
                        <dx:ASPxTextBox ID="txtSenha" Caption="Senha" runat="server" Password="true" Width="200px" MaxLength="50" ValidationSettings-Display="Dynamic" CssClass="TextoCinza16">
                            <CaptionSettings Position="Top" />
                            <CaptionStyle CssClass="TextoCinza16" />
                            <ValidationSettings ValidationGroup="Login" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" SetFocusOnError="true" EnableCustomValidation="true">
                                <RequiredField ErrorText="Informe a senha de conexão." IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                    </div>
                    <br />
                    <br />
                    <dx:ASPxButton ID="cmdLogin" ClientInstanceName="cmdLogin" runat="server" Text="Conectar" ValidationGroup="Login" CssClass="BotaoLinkF16" CausesValidation="true"  OnClick="cmdLogin_Click" />
                    <br />
                    <br />
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</asp:Content>
