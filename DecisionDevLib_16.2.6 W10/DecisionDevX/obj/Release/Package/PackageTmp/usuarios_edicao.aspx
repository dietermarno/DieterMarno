<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="usuarios_edicao.aspx.cs" Inherits="Decision.usuarios_edicao" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntUsuarios" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        //**************
        //* Declarações
        //**************
        var oJSON;

        function RetornaLista()
        {
            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            location.href = "usuarios.aspx";
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

        function CancelarUsuario(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            location.href = "usuarios.aspx";
        }

        function SalvarUsuario(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //********************************************
            //* O formulário foi corretamente preenchida?
            //********************************************
            if (ASPxClientEdit.ValidateGroup("Formulario"))
            {
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
        }

        function HabilitacaoSMTP(s, e)
        {
            //**********************************************
            //* O usuário informou algum parâmetro do SMTP?
            //**********************************************
            if (!chkSMTPPersonalizado.GetChecked())
            {
                //**************************
                //* Limpa configuração SMTP
                //**************************
                LimpaDadosSMTP(s, e);
            }

            //********************
            //* Controla ativação
            //********************
            chkSMTPAutenticacao.SetEnabled(chkSMTPPersonalizado.GetChecked());
            txtSMTPEndereco.SetEnabled(chkSMTPPersonalizado.GetChecked());
            txtSMTPPorta.SetEnabled(chkSMTPPersonalizado.GetChecked());
            txtSMTPUsuario.SetEnabled(chkSMTPPersonalizado.GetChecked());
            txtSMTPSenha.SetEnabled(chkSMTPPersonalizado.GetChecked());
            chkSMTPSSL.SetEnabled(chkSMTPPersonalizado.GetChecked());
            chkSMTPTLS.SetEnabled(chkSMTPPersonalizado.GetChecked());
            cmdTestarSMTP.SetEnabled(chkSMTPPersonalizado.GetChecked());
        }

        function ValidaSMTP(s, e)
        {
            //**********************************************
            //* O usuário informou algum parâmetro do SMTP?
            //**********************************************
            if (!chkSMTPPersonalizado.GetChecked())
            {
                //******************
                //* Dados em branco
                //******************
                e.isValid = true;
            }
            else
            {
                //*************************************
                //* O usuário selecionou autenticação?
                //*************************************
                if (!chkSMTPAutenticacao.GetChecked())
                {
                    //**********************************************
                    //* Força validade dos editores usuário e senha
                    //**********************************************
                    if (s.name.indexOf("txtSMTPUsuario")!=-1)
                        e.isValid = true;
                    if (s.name.indexOf("txtSMTPSenha")!=-1)
                        e.isValid = true;
                }
            }
        }

        function LimpaDados(s, e)
        {
            //*********************************
            //* Inicializa dados do formulário
            //*********************************
            cboPermissao.SetSelectedIndex(-1);
            cboPosto.SetSelectedIndex(-1);
            cboPromotor.SetSelectedIndex(-1);
            txtNomeCompleto.SetText("");
            txtUsuario.SetText("");
            txtSenha.SetText("");
            txtTelefone.SetText("");
            txtEmail.SetText("");
            chkRecebeEmail.SetChecked(false);
            chkAtivo.SetChecked(false);
            chkSupervisor.SetChecked(false);
            LimpaDadosSMTP(s, e)
        }

        function LimpaDadosSMTP(s, e)
        {
            //****************************************
            //* Inicializa dados da configuração SMTP
            //****************************************
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
            //****************************************************
            //* Coleta retorno do callback e converte para objeto
            //****************************************************
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
                case "Validar_Usuario":

                    //****************************************
                    //* O nome do usuário está em utilização?
                    //****************************************
                    if (oJSON.Error)
                    {
                        //******************
                        //* Impede gravação
                        //******************
                        txtUsuario.SetErrorText("Identificação já está em uso.")
                        txtUsuario.SetIsValid(false);
                    }

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

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
                    location.href = "usuarios.aspx";

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
            //* Código do promotor
            //*********************
            if (cboPromotor.GetSelectedIndex() != -1) {
                oJSON.Usuario_CodigoPromotor = cboPromotor.GetSelectedItem().value;
                oJSON.Usuario_NomePromotor = cboPromotor.GetSelectedItem().text;
            }
            else {
                oJSON.Usuario_CodigoPromotor = 0;
                oJSON.Usuario_NomePromotor = "";
            }

            //******************
            //* Código do posto 
            //******************
            if (cboPosto.GetSelectedIndex() != -1)
            {
                oJSON.Posto_Codigo = cboPosto.GetSelectedItem().value;
                oJSON.Posto_Nome = cboPosto.GetSelectedItem().text;
                oJSON.Posto_Descricao = "";
            }
            else
            {
                oJSON.Posto_Codigo = 0;
                oJSON.Posto_Nome = "";
                oJSON.Posto_Descricao = "";
            }

            //******************
            //* Código do grupo
            //******************
            if (cboPermissao.GetSelectedIndex() != -1)
            {
                oJSON.Usuario_CodigoGrupo = cboPermissao.GetSelectedItem().value;
                oJSON.Usuario_DescGrupo = cboPermissao.GetSelectedItem().text;
            }
            else
            {
                oJSON.Usuario_CodigoGrupo = 0;
                oJSON.Usuario_DescGrupo = "";
            }

            //*********************
            //* Obtem demais dados
            //*********************
            oJSON.Usuario_Nome = txtNomeCompleto.GetText();
            oJSON.Usuario_ID = txtUsuario.GetText();
            oJSON.Usuario_Senha = txtSenha.GetText();
            oJSON.Usuario_Telefone = txtTelefone.GetText();
            oJSON.Usuario_EmailEndereco = txtEmail.GetText();
            oJSON.Usuario_EmailCopia = chkRecebeEmail.GetChecked();
            oJSON.Usuario_Supervisor = chkSupervisor.GetChecked();
            oJSON.Usuario_Ativo = chkAtivo.GetChecked();
            oJSON.SMTP_autenticacao = chkSMTPAutenticacao.GetChecked();
            oJSON.SMTP_endereco = txtSMTPEndereco.GetText();
            oJSON.SMTP_porta = parseInt("0" + txtSMTPPorta.GetText());
            oJSON.SMTP_usuario = txtSMTPUsuario.GetText();
            oJSON.SMTP_senha = txtSMTPSenha.GetText();
            oJSON.SMTP_ssl = chkSMTPSSL.GetChecked();
            oJSON.SMTP_tls = chkSMTPTLS.GetChecked();
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
                if (oJSON.Usuario_CodigoPromotor != 0)
                    cboPromotor.SetValue(oJSON.Usuario_CodigoPromotor);
                else
                    cboPromotor.SetSelectedIndex(-1);

                //******************
                //* Código do posto 
                //******************
                if (oJSON.Posto_Codigo != 0)
                    cboPosto.SetValue(oJSON.Posto_Codigo);
                else
                    cboPosto.SetSelectedIndex(-1);

                //******************
                //* Código do grupo
                //******************
                if (oJSON.Usuario_CodigoGrupo != 0)
                    cboPermissao.SetValue(oJSON.Usuario_CodigoGrupo);
                else
                    cboPermissao.SetSelectedIndex(-1);

                //*********************
                //* Obtem demais dados
                //*********************
                if (oJSON.Usuario_Codigo == 0)
                    lblTitulo.SetText("Novo Cadastro de Usuário");
                else
                    lblTitulo.SetText("Alterando Cadastro do Usuário " + oJSON.Usuario_ID);

                txtNomeCompleto.SetText(oJSON.Usuario_Nome);
                txtUsuario.SetText(oJSON.Usuario_ID);
                txtSenha.SetText(oJSON.Usuario_Senha);
                txtTelefone.SetText(oJSON.Usuario_Telefone);
                txtEmail.SetText(oJSON.Usuario_EmailEndereco);
                chkRecebeEmail.SetChecked(oJSON.Usuario_EmailCopia);
                chkSupervisor.SetChecked(oJSON.Usuario_Supervisor);
                chkAtivo.SetChecked(oJSON.Usuario_Ativo);

                chkSMTPAutenticacao.SetChecked(oJSON.SMTP_autenticacao);
                txtSMTPEndereco.SetText(oJSON.SMTP_endereco);
                txtSMTPPorta.SetValue(parseInt(oJSON.SMTP_porta));
                txtSMTPUsuario.SetText(oJSON.SMTP_usuario);
                txtSMTPSenha.SetText(oJSON.SMTP_senha);
                chkSMTPSSL.SetChecked(oJSON.SMTP_ssl);
                chkSMTPTLS.SetChecked(oJSON.SMTP_tls);

                //**********************************************
                //* O usuário informou algum parâmetro do SMTP?
                //**********************************************
                if (!chkSMTPAutenticacao.GetChecked() && txtSMTPEndereco.GetText() == "" &&
                    parseInt("0" + txtSMTPPorta.GetText()) == 0 && txtSMTPUsuario.GetText() == "" &&
                    txtSMTPSenha.GetText() == "" && !chkSMTPSSL.GetChecked() && !chkSMTPTLS.GetChecked())
                    chkSMTPPersonalizado.SetChecked(false);
                else
                    chkSMTPPersonalizado.SetChecked(true);

                //****************************
                //* Controla habilitação SMTP
                //****************************
                HabilitacaoSMTP(s, e);
            }

            //*******************************
            //* Ocula painel de carregamento
            //*******************************
            pnlLoader.Hide();
        }

        function ValidarUsuario(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //*********************************
            //* Atualiza registro via callback
            //*********************************
            if (s.GetText() != "")
            {
                //***************************
                //* Atualiza dados no objeto
                //***************************
                AtualizaJSON(s, e);

                //*********************************
                //* Consulta existencia o username
                //*********************************
                oJSON.Parametros["Operacao"] = "Validar_Usuario";
                clbAtualizar.PerformCallback(JSON.stringify(oJSON));
            }
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

        <!-- Dados de identificação e acesso -->
        <div class="TextoCinza20" align="left" style="width: 95%;">
            Identificação e Acesso
        </div>
        <br />
        <dx:ASPxFormLayout CssClass="TextoCinza16" ID="layAbertura" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
            <Items>
                <dx:LayoutItem Caption="Vinculo com Promotor" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cboPromotor" ClientInstanceName="cboPromotor" DataSourceID="dsPromotores" TextField="nomepromotor" ValueField="codpromotor" runat="server" Theme="MetropolisBlue" Width="100%" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ValidationSettings-Display="Static" DropDownStyle="DropDownList" ValueType="System.Int32">
                                <ClearButton DisplayMode="Always" />
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Grupo de permissões" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cboPermissao" ClientInstanceName="cboPermissao" DataSourceID="dsGrupos" TextField="descgrupo" ValueField="codgrupo" runat="server" Theme="MetropolisBlue" Width="100%" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ValidationSettings-Display="Static" DropDownStyle="DropDownList" ValueType="System.Int32">
                                <ClearButton DisplayMode="Always" />
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Posto" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxComboBox ID="cboPosto" ClientInstanceName="cboPosto" DataSourceID="dsPostos" TextField="nomeposto" ValueField="postoven" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Theme="MetropolisBlue" Width="100%" ValueType="System.Int32" DropDownStyle="DropDownList">
                                <ClearButton DisplayMode="Always" />
                                <ClientSideEvents Validation="function(s, e) { e.isValid = s.GetSelectedIndex()==-1 ? false : true; }" />
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" EnableCustomValidation="true" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxComboBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Nome Completo" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtNomeCompleto" ClientInstanceName="txtNomeCompleto" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="60">
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="ID de Usuário" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtUsuario" ClientInstanceName="txtUsuario" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="50">
                                <ClientSideEvents Validation="function(s, e) { ValidarUsuario(s, e) }"></ClientSideEvents>
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Senha de acesso" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtSenha" ClientInstanceName="txtSenha" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="50" Password="true">
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Telefone Contato" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtTelefone" ClientInstanceName="txtTelefone" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" ValidationSettings-Display="Dynamic" MaxLength="20">
                                <MaskSettings Mask="(99) 9999-99999" PromptChar=" " />
                                <ValidationSettings Display="Dynamic"></ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Endereço de E-mail" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox ID="txtEmail" ClientInstanceName="txtEmail" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Formulario" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                    <RegularExpression ValidationExpression="^\w+([-+.'%]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorText="E-mail inválido" />
                                </ValidationSettings>
                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                            </dx:ASPxTextBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Recebe cópias por e-mail" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkRecebeEmail" ClientInstanceName="chkRecebeEmail" runat="server" CssClass="CampoSemBordas" Width="100%" />
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Usuário Ativo" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkAtivo" ClientInstanceName="chkAtivo" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" />
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Supervisor" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkSupervisor" ClientInstanceName="chkSupervisor" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" />
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
        <br />
        <br />
        <!-- Dados de transmissão de mensagens -->
        <div class="TextoCinza20" align="left" style="width: 95%;">
            Configurações para Envio de E-mails
        </div>
        <br />
        <dx:ASPxFormLayout CssClass="TextoCinza16" ID="layEnvioEmails" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
            <Items>
                <dx:LayoutItem Caption="Configuração de envio personalizada" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                    <LayoutItemNestedControlCollection>
                        <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxCheckBox ID="chkSMTPPersonalizado" ClientInstanceName="chkSMTPPersonalizado" runat="server" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" Width="100%" CheckState="Unchecked">
                                <ClientSideEvents ValueChanged="function(s, e) { HabilitacaoSMTP(s, e); }"></ClientSideEvents>
                                <ValidationSettings ValidationGroup="SMTP">
                                    <ErrorFrameStyle VerticalAlign="Bottom"></ErrorFrameStyle>
                                </ValidationSettings>
                            </dx:ASPxCheckBox>
                        </dx:LayoutItemNestedControlContainer>
                    </LayoutItemNestedControlCollection>
                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                    <CaptionCellStyle CssClass="TituloCampo"></CaptionCellStyle>
                </dx:LayoutItem>
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
            <ClientSideEvents Click="function(s, e) { SalvarUsuario(s, e); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="cmdCancelarUsuario" ClientInstanceName="cmdCancelarUsuario" runat="server" Text="Cancelar" Width="100px">
            <ClientSideEvents Click="function(s, e) { CancelarUsuario(s, e); }" />
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
    <asp:SqlDataSource ID="dsPostos" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT posto.PostoVen AS postoven, posto.nomeposto AS nomeposto FROM posto WHERE posto.postoven<>0 ORDER BY posto.descposto">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsGrupos" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT grupos.codgrupo, descgrupo AS descgrupo FROM grupos WHERE grupos.codgrupo<>0 ORDER BY grupos.descgrupo">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPromotores" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT promotor.codpromotor, promotor.nomepromotor FROM promotor WHERE promotor.codpromotor<>0 ORDER BY promotor.nomepromotor">
    </asp:SqlDataSource>
</asp:Content>
