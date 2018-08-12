<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="oportunidades_acompanhamento.aspx.cs" Inherits="Decision.oportunidades_acompanhamento" %>
<%@ Register assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<asp:Content ID="cntAcompanhamento" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        function RetornaLista()
        {
            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            location.href = "oportunidades.aspx";
        }

    </script>

    <div align="left" style="padding-left: 50px;">
        <br />
        <a href="javascript:RetornaLista();" class="BotaoLinkW60F14">< Retornar</a>
    </div>
    <br />
    <dx:ASPxDocumentViewer ID="rptRelatorio" runat="server" ReportTypeName="Decision.Reports.oportunidade_grafico">
    </dx:ASPxDocumentViewer>

</asp:Content>
