<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oportunidades_orcamento_email.aspx.cs" Inherits="Decision.oportunidades_email" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxSpellChecker" Assembly="DevExpress.Web.ASPxSpellChecker.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remessa de Orçamento</title>
    <base href="<%# Eval(HTML_Base)%>/" target="_blank" />
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.12.3.min.js"></script>
    <script type="text/javascript">

        function EscondeScrollVertical(s, e)
        {
            //**************************
            //* Esconde scroll vertical
            //**************************
            s.GetInputElement().style.overflowY = 'hidden';
            AjustaAltura(s, e);
        }

        function AjustaAltura(s, e)
        {
            //*************************
            //* Ajusta altura do campo
            //*************************
            var line_height = 15;
            textArea = s.GetInputElement();
            if (textArea.scrollHeight > s.GetHeight())
                s.SetHeight(textArea.scrollHeight);
            if (textArea.scrollHeight < s.GetHeight())
                if (textArea.scrollHeight - line_height >= line_height)
                    s.SetHeight(textArea.scrollHeight - line_height);
        }

        function SalvaResposta(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //******************************************************
            //* Cancela processamento no server e notifica gravação
            //******************************************************
            pnlLoader.SetText("Salvando dados...");
            pnlLoader.Show();

            //*********************************
            //* Atualiza registro via callback
            //*********************************
            var callBackData = "";
            htmResposta.PerformDataCallback(callBackData, FinalizaGravacao);
        }

        function FinalizaGravacao(s, e)
        {
            //************************
            //* Esconde painel LOADER
            //************************
            pnlLoader.Hide();

            //******************
            //* Define mensagem
            //******************
            if (e == "Ok")
                jQuery("#spnDialogo").text("Resposta enviada com sucesso!");
            else
                jQuery("#spnDialogo").text("Falha ao enviar sua resposta!");

            //****************
            //* Exibe diálogo
            //****************
            popMensagem.Show();
        }

    </script>
</head>
<body id="Body">
    <form id="frmPrincipal" runat="server">
        <div align="center" style="height: 100%">
            <br />
            <br />
            <input type="hidden" runat="server" id="txtCodigoMaster" />
            <input type="hidden" runat="server" id="txtCodigoPosto" />
            <input type="hidden" runat="server" id="txtCodigoOportunidade" />
            <input type="hidden" runat="server" id="txtCodigoOrcamento" />

            <table style="width: 1000px; border: 1px solid #808080; background-color: #ffffff;">
                <tr>
                    <td style="width: 10%; padding-top: 20px; padding-bottom: 20px;">
                        <dx:ASPxBinaryImage ID="imgLogotipo" runat="server" />
                    </td>
                    <td style="width: 90%; padding-top: 20px; padding-bottom: 20px; padding-left: 15px;">
                        <dx:ASPxLabel ID="lblNroOrcamento" CssClass="TextoCinza20" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblNomePosto" CssClass="TextoCinza20" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblEndereco" CssClass="TextoCinza16" runat="server" Text="" /><br />
                        <dx:ASPxLabel ID="lblContato" CssClass="TextoCinza16" runat="server" Text="" />
                    </td>
                </tr>
            </table>
            <table style="width: 1000px; border: 1px solid #808080; border-top: 0px solid; background-color: #ffffff;">
                <tr>
                    <td style="width: 100%;">

                        <!-- ********************* -->
                        <!-- * DADOS DE ABERTURA * -->
                        <!-- ********************* -->
                        <br />
                        <br />
                        <dx:ASPxFormLayout ID="layAbertura" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True">
                            <Items>
                                <dx:LayoutItem ColSpan="2" Width="100%" Caption="Destino" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtDestino" runat="server" Width="100%" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem ColSpan="2" Width="100%" Caption="Descrição" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxMemo CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="memDescricao" runat="server" Height="20px" Width="100%" AutoResizeWithContainer="true" ReadOnly="true">
                                                <ClientSideEvents Init="function(s, e) { EscondeScrollVertical(s, e) }" />
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Data da saída" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ClientInstanceName="dteSaida" ID="dteSaida" runat="server" Width="100%" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Data da retorno" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ClientInstanceName="dteRetorno" ID="dteRetorno" runat="server" Width="100%" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Qtde de Adultos" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtAdultos" runat="server" Width="100%" ReadOnly="true" >
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Qtde de Crianças" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtCriancas" runat="server" Width="100%" ReadOnly="true" >
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Produto" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtProduto" runat="server" Width="100%" ReadOnly="true" >
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Assunto" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtAssunto" runat="server" Width="100%" ReadOnly="true" >
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Valor do Orçamento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtValorOrcamento" runat="server" Width="100%" DisplayFormatString="C" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                        <br />
                        <br />

                        <!-- ************************* -->
                        <!-- * DADOS DE ENCERRAMENTO * -->
                        <!-- ************************* -->
                        <dx:ASPxFormLayout ID="layEncerramento" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True">
                            <Items>
                                <dx:LayoutItem Width="50%" Caption="Valor Fechado" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="txtValorEncerramento" ClientInstanceName="txtValorEncerramento" runat="server" Width="100%" DisplayFormatString="C" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="50%" Caption="Data do Encerramento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ID="dteEncerramento" ClientInstanceName="dteEncerramento" runat="server" Width="100%" AllowNull="true" ReadOnly="true" />
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                    </td>
                </tr>
            </table>
            <table style="width: 1000px; border: 1px solid #808080; border-top: 0px solid; background-color: #ffffff;">
                <tr>
                    <td colspan="4" style="vertical-align: top; width: 100%; padding: 15px;" class="TextoCinza20">
                        <span class="TextoCinza20">
                            DADOS DO ORÇAMENTO:
                        </span>
                        <div style="width: 100%; padding: 15px;" runat="server" id="divOrcamento">
                        </div>
                    </td>
                </tr>
            </table>
            <table style="width: 1000px; border: 1px solid #808080; border-top: 0px solid; background-color: #ffffff;">
                <tr>
                    <td colspan="4" style="vertical-align: top; width: 100%; padding: 15px;" class="TextoCinza20">
                        <span class="TextoCinza20">
                            SUA RESPOSTA:
                        </span>
                        <br />
                        <br />
                        <dx:ASPxHtmlEditor ID="htmResposta" runat="server" ClientInstanceName="htmResposta" Width="100%" Height="432px" 
                            FocusedStyle-CssClass="CampoSemBordasFocus" Settings-AllowHtmlView="False" Settings-AllowDesignView="True" 
                            Settings-AllowPreview="False" OnCustomDataCallback="htmResposta_CustomDataCallback">
                            <ClientSideEvents BeginCallback="function(s, e) { pnlLoader.Show(); }" EndCallback="function(s, e) { pnlLoader.Hide(); }" />
                        </dx:ASPxHtmlEditor>
                        <br />
                        <div align="right" style="padding-right: 15px;">
                            <dx:ASPxButton ID="cmdEnviarResposta" ClientInstanceName="cmdEnviarResposta" runat="server" Text="Enviar" Width="100px">
                                <ClientSideEvents Click="function(s, e) { SalvaResposta(s, e); }" />
                            </dx:ASPxButton>
                        </div>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
        <dx:ASPxLoadingPanel ID="pnlLoader" runat="server" ClientInstanceName="pnlLoader" Modal="True" Theme="MetropolisBlue" />
        <dx:ASPxPopupControl ID="popMensagem" runat="server" AllowDragging="True" AllowResize="False" ViewStateMode="Disabled"
            CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter" Width="300px" Height="200px" HeaderText="Orçamento" Theme="MetropolisBlue"
            ClientInstanceName="popMensagem" EnableHierarchyRecreation="False" Modal="true">
            <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div align="center">
                        <br />
                        <br />
                        <span class="TextoCinza20" id="spnDialogo"></span>
                        <br />
                        <br />
                        <br />
                        <dx:ASPxButton ID="cmdFechar" runat="server" Text="Ok" Theme="MetropolisBlue" Width="100px">
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popMensagem.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </form>
</body>
</html>
