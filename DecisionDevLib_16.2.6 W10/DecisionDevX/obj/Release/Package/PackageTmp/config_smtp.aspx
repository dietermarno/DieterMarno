<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="config_smtp.aspx.cs" Inherits="Decision.config_smtp" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntConfigEmail" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        //**************
        //* Declarações
        //**************
        var oJSON;

        function RetornaLista()
        {
            //********************
            //* Retorna para HOME
            //********************
            location.href = "abertura.aspx";
        }

        function InicializaJSON(s, e)
        {
            //*******************
            //* Apresenta LOADER
            //*******************
            pnlLoader.SetText("Carregando dados...");
            pnlLoader.Show();

            //***********************
            //* Solicita objeto JSON
            //***********************
            clbAtualizar.PerformCallback("");
        }

        function CancelarConfiguracao(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //********************
            //* Retorna para HOME
            //********************
            location.href = "abertura.aspx";
        }

        function SalvarConfiguracao(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("SMTP"))
            {
                //***************************
                //* Atualiza dados no objeto
                //***************************
                AtualizaJSON();

                //*********************************
                //* Atualiza registro via callback
                //*********************************
                oJSON.Parametros["Operacao"] = "Salvar_Registro";
                clbAtualizar.PerformCallback(JSON.stringify(oJSON));
            }
        }

        function ValidaSMTP(s, e)
        {
            //*************************************
            //* O usuário selecionou autenticação?
            //*************************************
            if (!chkSMTPAutenticacao.GetChecked()) 
            {
                //**********************************************
                //* Força validade dos editores usuário e senha
                //**********************************************
                if (s.name.indexOf("txtSMTPUsuario") != -1)
                    e.isValid = true;
                if (s.name.indexOf("txtSMTPSenha") != -1)
                    e.isValid = true;
            }
        }

        function LimpaDados(s, e)
        {
            //*********************************
            //* Inicializa dados do formulário
            //*********************************
            chkSMTPAutenticacao.SetChecked(false);
            txtSMTPEndereco.SetText("");
            txtSMTPPorta.SetText("");
            txtSMTPUsuario.SetText("");
            txtSMTPSenha.SetText("");
            chkSMTPSSL.SetChecked(false);
            chkSMTPTLS.SetChecked(false);
        }

        function RetornoCallback(s, e)
        {
            //***************************************************
            //* Coleta retorno do callback e coverte para objeto
            //***************************************************
            oJSON = JSON.parse(e.result);

            //*****************
            //* Esconde loader
            //*****************
            pnlLoader.Hide();

            //****************
            //* Trata retorno
            //****************
            switch (oJSON.Parametros["Operacao"])
            {
                case "Salvar_Registro":

                    //***********************
                    //* Exibe mensagem final
                    //***********************
                    if (oJSON.Error == "")
                        pnlLoader.SetText("Dados salvos com sucesso!");
                    else
                        pnlLoader.SetText("Falha ao salvar os dados!\n\n" + oJSON.error);

                    //*********************************
                    //* Retorna para lista de cadastro
                    //*********************************
                    location.href = "abertura.aspx";

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Popular":

                    //*********************
                    //* Atualiza interface
                    //*********************
                    ExibeJSON(s, e);

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Teste_SMTP":

                    //**************************
                    //* Exibe popup com retorno
                    //**************************
                    var Mensagem = "<br/><br/>Teste de envio realizado";
                    Mensagem += "<br/><br/>O retorno do servidor foi:";
                    if (!oJSON.Error)
                        Mensagem += "<br/><br/>Mensagem enviada com sucesso!";
                    else
                        Mensagem += "<br/><br/>" + oJSON.ErrorText;
                    jQuery("#divResposta").attr('align', 'center');
                    jQuery("#divResposta").html(Mensagem);
                    popRetornoSMTP.SetHeaderText("Teste Servidor SMTP");
                    popRetornoSMTP.Show();

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;
            }

            //********************************
            //* Anula último erro de operação
            //********************************
            oJSON.Parametros["Operacao"] = "";
            oJSON.ErrorText = "";
            oJSON.Error = false;

            //***********************************
            //* Remove loader modal em 1 segundo
            //***********************************
            setTimeout(function () { pnlLoader.Hide(); }, 500);
        }

        function AtualizaJSON(s, e)
        {
            //******************************************************
            //* Cancela processamento no server e notifica gravação
            //******************************************************
            pnlLoader.SetText("Executando solicitação...");
            pnlLoader.Show();

            //*********************
            //* Obtem demais dados
            //*********************
            oJSON.SMTP_Autenticacao = chkSMTPAutenticacao.GetChecked();
            oJSON.SMTP_Endereco = txtSMTPEndereco.GetText();
            oJSON.SMTP_porta = parseInt("0" + txtSMTPPorta.GetText());
            oJSON.SMTP_Usuario = txtSMTPUsuario.GetText();
            oJSON.SMTP_Senha = txtSMTPSenha.GetText();
            oJSON.SMTP_SSL = chkSMTPSSL.GetChecked();
            oJSON.SMTP_TLS = chkSMTPTLS.GetChecked();
        }

        function ExibeJSON(s, e)
        {
            //******************
            //* Limpa interface
            //******************
            LimpaDados();

            //**********************************************
            //* Reconstroi objetos a partir do retorno JSON
            //**********************************************
            if (!oJSON.Error)
            {
                //*********************
                //* Código do promotor
                //*********************
                chkSMTPAutenticacao.SetChecked(oJSON.SMTP_Autenticacao);
                txtSMTPEndereco.SetText(oJSON.SMTP_Endereco);
                txtSMTPPorta.SetValue(parseInt(oJSON.SMTP_Porta));
                txtSMTPUsuario.SetText(oJSON.SMTP_Usuario);
                txtSMTPSenha.SetText(oJSON.SMTP_Senha);
                chkSMTPSSL.SetChecked(oJSON.SMTP_SSL);
                chkSMTPTLS.SetChecked(oJSON.SMTP_TLS);
            }

            //*******************************
            //* Ocula painel de carregamento
            //*******************************
            pnlLoader.Hide();
        }

        function TestarEnvio(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("SMTP"))
            {
                //**************
                //* Exibe popup
                //**************
                popTesteSMTP.Show();
            }
        }

        function EnviaTeste(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;
            popTesteSMTP.Hide();

            //********************************************
            //* O formulário foi corretamente preenchido?
            //********************************************
            if (ASPxClientEdit.ValidateGroup("Teste"))
            {
                //***************************
                //* Atualiza dados no objeto
                //***************************
                AtualizaJSON();

                //********************************
                //* Nome e e-mail do destinatário
                //********************************
                oJSON.Parametros["NomeDestinatario"] = txtNomeDestinatario.GetText();
                oJSON.Parametros["EmailDestinatario"] = txtEmailDestinatario.GetText();

                //*********************************
                //* Atualiza registro via callback
                //*********************************
                oJSON.Parametros["Operacao"] = "Teste_SMTP";
                clbAtualizar.PerformCallback(JSON.stringify(oJSON));
            }
        }

    </script>
    <br />
    <div align="left" style="width: 95%;">
        <br />
        <a href="javascript:RetornaLista();" class="BotaoLinkW60F16">< Retornar</a>
    </div>
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%;">
        <dx:ASPxLabel ID="lblTitulo" ClientInstanceName="lblTitulo" CssClass="TextoCinza20" runat="server" Text="" />
    </div>
    <br />

    <!-- *********************** -->
    <!-- * CADASTRO DE USUÁRIO * -->
    <!-- *********************** -->
    <div align="left" style="width: 95%;">

        <!-- Dados de transmissão de mensagens -->
        <div class="TextoCinza20" align="left" style="width: 95%;">
            Configurações para Envio de E-mails
        </div>
        <br />
        <dx:ASPxFormLayout CssClass="TextoCinza16" ID="layEnvioEmails" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
            <Items>
                <dx:LayoutItem Caption="Autenticar envio (SMTP)" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkSMTPAutenticacao" ClientInstanceName="chkSMTPAutenticacao" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" >
                                <ValidationSettings ValidationGroup="SMTP">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                </ValidationSettings>
                            </dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Endereço do servidor" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSMTPEndereco" ClientInstanceName="txtSMTPEndereco" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                <ClientSideEvents Validation="function(s, e) { ValidaSMTP(s, e) }" />
                                <ValidationSettings EnableCustomValidation="True" ValidationGroup="SMTP" Display="Dynamic">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informe o endereço" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Porta do servidor" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSMTPPorta" ClientInstanceName="txtSMTPPorta" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                <MaskSettings Mask="99999" PromptChar=" " />
                                <ClientSideEvents Validation="function(s, e) { ValidaSMTP(s, e) }" />
                                <ValidationSettings EnableCustomValidation="True" ValidationGroup="SMTP" Display="Dynamic">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informe a porta de conexão" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Identificação do usuário" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSMTPUsuario" ClientInstanceName="txtSMTPUsuario" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                <ClientSideEvents Validation="function(s, e) { ValidaSMTP(s, e) }" />
                                <ValidationSettings EnableCustomValidation="True" ValidationGroup="SMTP" Display="Dynamic">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informe a ID do usuário" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Senha de conexão" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSMTPSenha" ClientInstanceName="txtSMTPSenha" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100" Password="true">
                                <ClientSideEvents Validation="function(s, e) { ValidaSMTP(s, e) }" />
                                <ValidationSettings EnableCustomValidation="True" ValidationGroup="SMTP" Display="Dynamic">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informe a senha de conexão" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Utilizar SSL" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkSMTPSSL" ClientInstanceName="chkSMTPSSL" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" >
                                <ValidationSettings ValidationGroup="SMTP">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                </ValidationSettings>
                            </dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Utilizar TLS/STARTTLS" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkSMTPTLS" ClientInstanceName="chkSMTPTLS" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" >
                                <ValidationSettings ValidationGroup="SMTP">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                </ValidationSettings>
                            </dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
            </Items>
            <SettingsItems ShowCaption="True"></SettingsItems>
            <Styles>
                <LayoutGroup>
                    <Cell>
                        <Paddings PaddingBottom="8px"></Paddings>
                    </Cell>
                </LayoutGroup>
            </Styles>
        </dx:ASPxFormLayout>
    </div>
    <div align="right" style="padding-right: 10px; width: 95%;">
        <dx:ASPxButton ID="cmdTestarSMTP" ClientInstanceName="cmdTestarSMTP" runat="server" Text="Testar Envio" Width="100px">
            <ClientSideEvents Click="function(s, e) { TestarEnvio(s, e); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="cmdSalvarUsuario" ClientInstanceName="cmdSalvarUsuario" runat="server" Text="Salvar" Width="100px">
            <ClientSideEvents Click="function(s, e) { SalvarConfiguracao(s, e); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="cmdCancelarUsuario" ClientInstanceName="cmdCancelarUsuario" runat="server" Text="Cancelar" Width="100px">
            <ClientSideEvents Click="function(s, e) { CancelarConfiguracao(s, e); }" />
        </dx:ASPxButton>
    </div>
    <dx:ASPxPopupControl ID="popTesteSMTP" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="720px" Height="320px" HeaderText="Teste de Servidor SMTP" Theme="Moderno" 
        CssClass="TextoCinza16" ClientInstanceName="popTesteSMTP" EnableHierarchyRecreation="True" Modal="true" 
        HeaderStyle-HorizontalAlign="Center">
        <HeaderStyle BackColor="#cccccc" ForeColor="#999999" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxFormLayout CssClass="TextoCinza16" ID="layTesteEmail" runat="server" ColCount="1" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                    <Items>
                        <dx:LayoutItem Caption="Nome do destinatário" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtNomeDestinatario" ClientInstanceName="txtNomeDestinatario" runat="server" Width="100%" CssClass="CampoSemBordas">
                                        <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Teste" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                            <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                            <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                        </ValidationSettings>
                                        <Paddings PaddingBottom="10px" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="E-mail do destinatário" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer runat="server">
                                    <dx:ASPxTextBox ID="txtEmailDestinatario" ClientInstanceName="txtEmailDestinatario" runat="server" Width="100%" CssClass="CampoSemBordas">
                                        <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Teste" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                            <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                            <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                            <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="E-mail inválido" />
                                        </ValidationSettings>
                                        <Paddings PaddingBottom="10px" />
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:ASPxFormLayout>
                <br />
                <br />
                <div align="right" style="width: 95%;">
                    <dx:ASPxButton ID="cmdEnviarTeste" runat="server" Text="Confirmar" Width="100px">
                        <ClientSideEvents Click="function(s, e) { e.processOnServer = false; EnviaTeste(s, e); }"></ClientSideEvents>
                    </dx:ASPxButton>
                    &nbsp;
                    <dx:ASPxButton ID="cmdCancelaTeste" runat="server" Text="Cancelar" Width="100px">
                        <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popTesteSMTP.Hide(); }"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popRetornoSMTP" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="520px" Height="320px" HeaderText="Teste de Servidor SMTP" Theme="Moderno" 
        CssClass="TextoCinza16" ClientInstanceName="popRetornoSMTP" EnableHierarchyRecreation="True" Modal="true" 
        HeaderStyle-HorizontalAlign="Center">
        <HeaderStyle BackColor="#cccccc" ForeColor="#999999" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div id="divResposta" align="center" style="width: 95%;">
                    &nbsp;
                </div>
                <br />
                <br />
                <div align="center" style="width: 95%;">
                    <dx:ASPxButton ID="cmdFechaRetornoSMTP" runat="server" Text="Fechar" Width="100px">
                        <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popRetornoSMTP.Hide(); }"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxCallback ID="clbAtualizar" ClientInstanceName="clbAtualizar" runat="server" OnCallback="clbAtualizar_Callback">
        <ClientSideEvents Init="function(s, e) { InicializaJSON(); }" CallbackComplete="function(s, e) { RetornoCallback(s, e); }" />
    </dx:ASPxCallback>
    <dx:ASPxLoadingPanel ID="pnlLoader" runat="server" ClientInstanceName="pnlLoader" Modal="True" Theme="MetropolisBlue" />
    <br />
    <br />
</asp:Content>
