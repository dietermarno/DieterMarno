<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="empresas.aspx.cs" Inherits="Decision.Admin.empresas" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntConteudo" ContentPlaceHolderID="cphConteudo" runat="server">

    <script type="text/javascript">


        //***************************
        //* Dados de envio e retorno
        //***************************
        var oJSON =
            {
                "conexao_driver": "",
                "conexao_server": "",
                "conexao_database": "",
                "conexao_port": "",
                "conexao_user": "",
                "conexao_password": "",
                "operacao": "",
                "error": "",
                "errorText": ""
            };
        var ComboDriver = "";

        function AtualizarBanco_Click(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***********************
            //* Solicita confirmação
            //***********************
            popConfirmacao.Show();
        }

        function AtualizarBanco(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //**************************
            //* Define dados da chamada
            //**************************
            oJSON.conexao_driver = ComboDriver;
            oJSON.conexao_server = txtConexaoServer.GetValue();
            oJSON.conexao_database = txtConexaoDatabase.GetValue();
            oJSON.conexao_port = txtConexaoPort.GetValue();
            oJSON.conexao_user = txtConexaoUser.GetValue();
            oJSON.conexao_password = txtConexaoPassword.GetValue();
            oJSON.operacao = "Atualizar_Banco";
            oJSON.error = false;
            oJSON.errorText = "";

            //*******************
            //* Apresenta LOADER
            //*******************
            pnlLoader.SetText("Processando atualização...");
            pnlLoader.Show();

            //*******************
            //* Executa callback
            //*******************
            clbAtualizar.PerformCallback(JSON.stringify(oJSON));
        }

        function TestarConexao(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //**************************
            //* Define dados da chamada
            //**************************
            oJSON.conexao_driver = ComboDriver;
            oJSON.conexao_server = txtConexaoServer.GetValue();
            oJSON.conexao_database = txtConexaoDatabase.GetValue();
            oJSON.conexao_port = txtConexaoPort.GetValue();
            oJSON.conexao_user = txtConexaoUser.GetValue();
            oJSON.conexao_password = txtConexaoPassword.GetValue();
            oJSON.operacao = "Validar_Conexao";
            oJSON.error = false;
            oJSON.errorText = "";

            //*******************
            //* Executa callback
            //*******************
            clbAtualizar.PerformCallback(JSON.stringify(oJSON));
        }

        function RetornoCallback(s, e)
        {
            //*****************
            //* Esconde loader
            //*****************
            pnlLoader.Hide();

            //****************************************************
            //* Coleta retorno do callback e converte para objeto
            //****************************************************
            oJSON = JSON.parse(e.result);

            //************************************
            //* Executa retorno conforme operação
            //************************************
            switch (oJSON.operacao)
            {
                case "Validar_Conexao":

                    //***************************
                    //* Houve erro de validação?
                    //***************************
                    if (oJSON.error)
                        var Mensagem = "<br/><br/>" + oJSON.errorText + "<br/><br/>";
                    else
                        var Mensagem = "<br/><br/>Os dados de conexão são válidos.<br/><br/>";
                    jQuery("#divMensagem").attr('align', 'left');
                    jQuery("#divMensagem").html(Mensagem);
                    popMensagem.SetHeaderText("Validação de Conexao");
                    popMensagem.AdjustSize();
                    popMensagem.Show();
                    break;

                case "Atualizar_Banco":

                    //*************************
                    //* Exibe mensagem de erro
                    //*************************
                    var Mensagem = "<br/><br/>" + oJSON.errorText + "<br/><br/>";
                    jQuery("#divMensagem").attr('align', 'left');
                    jQuery("#divMensagem").html(Mensagem);
                    popMensagem.SetHeaderText("Atualização de Banco de Dados");
                    popMensagem.AdjustSize();
                    popMensagem.Show();
                    break;
            }
        }
    </script>

    <div align="center">
        <br />
        <div class="TextoCinza20" align="left" style="width: 95%;">
            Cadastro de Acessos de Empresas
        </div>
        <br />
        <dx:ASPxGridView ClientInstanceName="grvEmpresas" ID="grvEmpresas" runat="server" Theme="MetropolisBlue" AutoGenerateColumns="False"
            DataSourceID="dsEmpresas" EnableTheming="True" Width="95%" CssClass="Texto14" KeyFieldName="codigo" 
            OnCustomColumnDisplayText="grvEmpresas_CustomColumnDisplayText"
            OnSearchPanelEditorCreate="grvEmpresas_SearchPanelEditorCreate">
            <Styles>
                <Header Font-Bold="False" />
                <RowHotTrack BackColor="#A5C5FA" />
                <FilterRow CssClass="CampoSemBordas" />
                <Cell>
                    <BorderLeft BorderStyle="None" />
                    <BorderRight BorderStyle="None" />
                </Cell>
                <CommandColumn Spacing="5px" />
                <FilterCell CssClass="CampoSemBordas" />
                <FilterBar CssClass="CampoSemBordas" />
                <HeaderFilterItem CssClass="CampoSemBordas" />
            </Styles>
            <SettingsCookies CookiesID="Decision_Empresas" />
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image" />
                <HideAdaptiveDetailButton ButtonType="Image" />
                <NewButton>
                    <Styles Native="True">
                        <Style CssClass="BotaoLinkW60F14"></Style>
                    </Styles>
                </NewButton>
                <EditButton>
                    <Styles Native="True">
                        <Style CssClass="BotaoLinkW60F14"></Style>
                    </Styles>
                </EditButton>
                <DeleteButton>
                    <Styles Native="True">
                        <Style CssClass="BotaoLinkW60F14"></Style>
                    </Styles>
                </DeleteButton>
                <UpdateButton>
                    <Styles Native="True">
                        <Style CssClass="BotaoLinkW100F14"></Style>
                    </Styles>
                </UpdateButton>
                <CancelButton>
                    <Styles Native="True">
                        <Style CssClass="BotaoLinkW100F14"></Style>
                    </Styles>
                </CancelButton>
            </SettingsCommandButton>
            <Templates>
                <EditForm>
                    <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors" runat="server" />
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%">
                                <div align="right">
                                    <dx:ASPxGridViewTemplateReplacement ID="TemplateReplacementUpdate" ReplacementType="EditFormUpdateButton" runat="server" />
                                    &nbsp;
                                    <dx:ASPxGridViewTemplateReplacement ID="TemplateReplacementCancel" ReplacementType="EditFormCancelButton" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </EditForm>
            </Templates>
            <SettingsSearchPanel Visible="True" ShowClearButton="true" SearchInPreview="true" />
            <EditFormLayoutProperties ColCount="4">
                <Items>
                    <dx:GridViewColumnLayoutItem CssClass="TextoAzul16" ColSpan="4" ShowCaption="False">
                        <Template>
                            <span>Dados de conexão</span>
                            <br />
                            <br />
                        </Template>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_nome" Caption="ID Conex&#227;o Empresa" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_driver" Caption="Driver" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxComboBox CssClass="CampoSemBordas" ClientInstanceName="cboConexaoDriver" EncodeHtml="false" ID="cboConexaoDriver" runat="server" Value='<%# Bind("conexao_driver") %>' ClearButton-DisplayMode="Always" Width="100%">
                                <ClientSideEvents
                                    Init="function(s, e) { var ComboValue = s.GetValue(); if (ComboValue) ComboDriver = s.GetSelectedItem().value; }"
                                    SelectedIndexChanged="function(s, e) { var ComboValue = s.GetValue(); if (ComboValue) ComboDriver = s.GetSelectedItem().value; }" />
                                <Items>
                                    <dx:ListEditItem Text="<span class='Texto14'>MySQL ODBC 5.1 Driver</span>" Value="MySQL ODBC 5.1 Driver" />
                                    <dx:ListEditItem Text="<span class='Texto14'>MySQL ODBC 5.3 ANSI Driver</span>" Value="MySQL ODBC 5.3 ANSI Driver" />
                                </Items>
                            </dx:ASPxComboBox>
                        </Template>

                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_database" Caption="Nome do Database" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtConexaoDatabase" ClientInstanceName="txtConexaoDatabase" Value='<%# Bind("conexao_database") %>' />
                        </Template>
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_server" Caption="IP Servidor" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtConexaoServer" ClientInstanceName="txtConexaoServer" Value='<%# Bind("conexao_server") %>' />
                        </Template>
                        <Paddings PaddingBottom="10px"></Paddings>
                        <CaptionCellStyle CssClass="Texto16"></CaptionCellStyle>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_port" Caption="Porta de Conexao" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtConexaoPort" ClientInstanceName="txtConexaoPort" Value='<%# Bind("conexao_port") %>' />
                        </Template>
                        <Paddings PaddingBottom="10px"></Paddings>
                        <CaptionCellStyle CssClass="Texto16"></CaptionCellStyle>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem CssClass="Texto16" Caption="Usu&#225;rio" ColumnName="conexao_user">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtConexaoUser" ClientInstanceName="txtConexaoUser" Value='<%# Bind("conexao_user") %>' />
                        </Template>
                        <Paddings PaddingBottom="10px"></Paddings>
                        <CaptionCellStyle CssClass="Texto16"></CaptionCellStyle>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_password" Caption="Senha" CssClass="Texto16">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtConexaoPassword" ClientInstanceName="txtConexaoPassword" Value='<%# Bind("conexao_password") %>' OnDataBound="txtConexaoPassword_DataBound" />
                        </Template>
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="conexao_ativa" Caption="Ativa" CssClass="Texto16">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem Caption="Teste e atualiza&#231;&#227;o" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxButton ID="cmdTestarConexao" runat="server" Text="Testar Conexao" Theme="MetropolisBlue" Width="100px">
                                <ClientSideEvents Click="function(s, e) { TestarConexao(s, e); }" />
                            </dx:ASPxButton>
                            &nbsp;
                            <dx:ASPxButton ID="cmdAtualizar" runat="server" Text="Atualizar tabelas" Theme="MetropolisBlue" Width="100px">
                                <ClientSideEvents Click="function(s, e) { AtualizarBanco_Click(s, e); }" />
                            </dx:ASPxButton>
                        </Template>
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>
                    <dx:GridViewColumnLayoutItem CssClass="TextoAzul16" ColSpan="4" ShowCaption="False">
                        <Template>
                            <span>Nome, Razão Social e CNPJ/CPF</span>
                            <br />
                            <br />
                        </Template>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="nome_fantasia" Caption="Nome Fantasia" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="razao_social" Caption="Raz&#227;o Social" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px"></Paddings>
                        <CaptionCellStyle CssClass="Texto16"></CaptionCellStyle>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="cnpj_cpf" Caption="CNPJ ou CPF" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:EmptyLayoutItem ColSpan="2" />
                    <dx:EmptyLayoutItem ColSpan="4" />

                    <dx:GridViewColumnLayoutItem CssClass="TextoAzul16" ColSpan="4" ShowCaption="False">
                        <Template>
                            <span>Endereço</span>
                            <br />
                            <br />
                        </Template>
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="logradouro" Caption="Logradouro" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="numero" Caption="N&#250;mero" CssClass="Texto16">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="complemento" Caption="Complemento" CssClass="Texto16">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="cidade" Caption="Cidade" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="uf" Caption="UF" CssClass="Texto16" ColSpan="2">
                        <Template>
                            <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboTitular" runat="server" ValueType="System.String" Value='<%# Bind("uf") %>' ClearButton-DisplayMode="Always" Width="100%">
                                <Items>
                                    <dx:ListEditItem Text="<span class='Texto14'>AC - Acre</span>" Value="AC" />
                                    <dx:ListEditItem Text="<span class='Texto14'>AL - Alagoas</span>" Value="AL" />
                                    <dx:ListEditItem Text="<span class='Texto14'>AP - Amapá</span>" Value="AP" />
                                    <dx:ListEditItem Text="<span class='Texto14'>AM - Amazonas</span>" Value="AM" />
                                    <dx:ListEditItem Text="<span class='Texto14'>BA - Bahia</span>" Value="BA" />
                                    <dx:ListEditItem Text="<span class='Texto14'>CE - Ceará</span>" Value="CE" />
                                    <dx:ListEditItem Text="<span class='Texto14'>DF - Distrito Federal</span>" Value="DF" />
                                    <dx:ListEditItem Text="<span class='Texto14'>ES - Espírito Santo</span>" Value="ES" />
                                    <dx:ListEditItem Text="<span class='Texto14'>GO - Goiás</span>" Value="GO" />
                                    <dx:ListEditItem Text="<span class='Texto14'>MA - Maranhão</span>" Value="MA" />
                                    <dx:ListEditItem Text="<span class='Texto14'>MT - Mato Grosso</span>" Value="MT" />
                                    <dx:ListEditItem Text="<span class='Texto14'>MS - Mato Grosso do Sul</span>" Value="MS" />
                                    <dx:ListEditItem Text="<span class='Texto14'>MG - Minas Gerais</span>" Value="MG" />
                                    <dx:ListEditItem Text="<span class='Texto14'>PA - Pará</span>" Value="PA" />
                                    <dx:ListEditItem Text="<span class='Texto14'>PB - Paraíba</span>" Value="PB" />
                                    <dx:ListEditItem Text="<span class='Texto14'>PR - Paraná</span>" Value="PR" />
                                    <dx:ListEditItem Text="<span class='Texto14'>PE - Pernambuco</span>" Value="PE" />
                                    <dx:ListEditItem Text="<span class='Texto14'>PI - Piauí</span>" Value="PI" />
                                    <dx:ListEditItem Text="<span class='Texto14'>RJ - Rio de Janeiro</span>" Value="RJ" />
                                    <dx:ListEditItem Text="<span class='Texto14'>RN - Rio Grande do Norte</span>" Value="RN" />
                                    <dx:ListEditItem Text="<span class='Texto14'>RS - Rio Grande do Sul</span>" Value="RS" />
                                    <dx:ListEditItem Text="<span class='Texto14'>RO - Rondônia</span>" Value="RO" />
                                    <dx:ListEditItem Text="<span class='Texto14'>RR - Roraima</span>" Value="RR" />
                                    <dx:ListEditItem Text="<span class='Texto14'>SC - Santa Catarina</span>" Value="SC" />
                                    <dx:ListEditItem Text="<span class='Texto14'>SP - São Paulo</span>" Value="SP" />
                                    <dx:ListEditItem Text="<span class='Texto14'>SE - Sergipe</span>" Value="SE" />
                                    <dx:ListEditItem Text="<span class='Texto14'>TO - Tocantins</span>" Value="TO" />
                                </Items>
                            </dx:ASPxComboBox>

                        </Template>

                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem CssClass="Texto16" ColSpan="2" Caption="CEP" ColumnName="cep">
                        <Paddings PaddingBottom="10px"></Paddings>

                        <CaptionCellStyle CssClass="Texto16"></CaptionCellStyle>

                    </dx:GridViewColumnLayoutItem>
                    <dx:EmptyLayoutItem ColSpan="2"></dx:EmptyLayoutItem>
                    <dx:EmptyLayoutItem ColSpan="4"></dx:EmptyLayoutItem>


                    <dx:GridViewColumnLayoutItem CssClass="TextoAzul16" ColSpan="4" ShowCaption="False">
                        <Template>
                            <span>Informações de contato</span>
                            <br />
                            <br />

                        </Template>

                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="internet" Caption="Website" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="contato_nome" Caption="Contato" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="contato_email" Caption="E-mail" CssClass="Texto16" ColSpan="2">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem ColumnName="contato_fone_fixo" Caption="Fone Fixo" CssClass="Texto16">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:GridViewColumnLayoutItem Caption="Fone Celular" CssClass="Texto16" ColumnName="contato_fone_celular">
                        <Paddings PaddingBottom="10px" />
                        <CaptionCellStyle CssClass="Texto16" />
                    </dx:GridViewColumnLayoutItem>

                    <dx:EmptyLayoutItem ColSpan="4" />

                </Items>
                <SettingsItemCaptions Location="Left" />
            </EditFormLayoutProperties>
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True" />

                <dx:GridViewDataTextColumn FieldName="conexao_nome" Visible="False" VisibleIndex="16">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="conexao_driver" Visible="False" VisibleIndex="17">
                    <PropertiesTextEdit MaxLength="100" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="conexao_server" Visible="False" VisibleIndex="18">
                    <PropertiesTextEdit MaxLength="100" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="conexao_database" Visible="False" VisibleIndex="19">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataSpinEditColumn FieldName="conexao_port" Visible="False" VisibleIndex="20">
                    <PropertiesSpinEdit DecimalPlaces="0" DisplayFormatString="N0" NumberFormat="Number" DisplayFormatInEditMode="True" MaxLength="5" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesSpinEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataSpinEditColumn>

                <dx:GridViewDataTextColumn FieldName="conexao_user" Visible="False" VisibleIndex="21">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="conexao_password" Visible="False" VisibleIndex="22">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataCheckColumn FieldName="conexao_ativa" Visible="False" VisibleIndex="23" UnboundType="Integer">
                    <PropertiesCheckEdit ValueType="System.Int32" ValueChecked="1" ValueUnchecked="0"></PropertiesCheckEdit>

                    <EditFormSettings Visible="True">
                    </EditFormSettings>
                </dx:GridViewDataCheckColumn>

                <dx:GridViewDataTextColumn FieldName="razao_social" Caption="Raz&#227;o Social" VisibleIndex="1">
                    <PropertiesTextEdit MaxLength="60" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="true" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cnpj_cpf" Caption="CNPJ / CPF" VisibleIndex="2">
                    <PropertiesTextEdit MaxLength="18" NullText=" " Width="100%" ValidationSettings-Display="Dynamic" ConvertEmptyStringToNull="False">
                        <ValidationSettings Display="Dynamic"></ValidationSettings>
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cidade" VisibleIndex="3" Caption="Cidade">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="contato_email" VisibleIndex="5" Caption="E-mail">
                    <PropertiesTextEdit MaxLength="100" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="contato_fone_fixo" VisibleIndex="6" Caption="Fone Fixo">
                    <PropertiesTextEdit MaxLength="20" NullText=" " ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="contato_fone_celular" VisibleIndex="7" Caption="Fone Celular">
                    <PropertiesTextEdit MaxLength="20" NullText=" " ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="contato_nome" Caption="Contato" VisibleIndex="4">
                    <PropertiesTextEdit MaxLength="60" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" Visible="False" VisibleIndex="8">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="nome_fantasia" Visible="False" VisibleIndex="9">
                    <PropertiesTextEdit MaxLength="60" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="logradouro" Visible="False" VisibleIndex="10">
                    <PropertiesTextEdit MaxLength="60" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="numero" Visible="False" VisibleIndex="11">
                    <PropertiesTextEdit MaxLength="6" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="complemento" Visible="False" VisibleIndex="12">
                    <PropertiesTextEdit MaxLength="30" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cep" Visible="False" VisibleIndex="13">
                    <PropertiesTextEdit MaxLength="9" NullText=" " ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="uf" Visible="False" VisibleIndex="14">
                    <PropertiesTextEdit MaxLength="2" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="internet" Visible="False" VisibleIndex="15">
                    <PropertiesTextEdit MaxLength="150" ConvertEmptyStringToNull="False">
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>

            </Columns>
        </dx:ASPxGridView>
        <dx:ASPxPopupControl ID="popMensagem" runat="server" AllowDragging="True" AllowResize="False" 
            ViewStateMode="Disabled" CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter" Width="600px" MinWidth="600px" Height="200px" HeaderText="Mensagem de Sistema" 
            Theme="MetropolisBlue" ClientInstanceName="popMensagem" EnableHierarchyRecreation="False" Modal="true">
            <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div align="center">
                        <br />
                        <br />
                        <span class="TextoCinza16">
                            <div id="divMensagem" style="padding: 20px;">
                                &nbsp;
                            </div>
                        </span>
                        <br />
                        <br />
                        <br />
                        <dx:ASPxButton ID="cmdFechar" runat="server" Text="Fechar" Theme="MetropolisBlue" Width="100px">
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popMensagem.Hide(); }"></ClientSideEvents>
                        </dx:ASPxButton>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <dx:ASPxPopupControl ID="popConfirmacao" runat="server" AllowDragging="True" AllowResize="False" 
            ViewStateMode="Disabled" CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter" Width="300px" MinWidth="300px" Height="200px" HeaderText="Confirmação de Execução" 
            Theme="MetropolisBlue" ClientInstanceName="popConfirmacao" EnableHierarchyRecreation="False" Modal="true">
            <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div align="center">
                        <br />
                        <br />
                        <span class="TextoCinza16">Confirma a exeução do processo de atualização?</span>
                        <br />
                        <br />
                        <br />
                        <dx:ASPxButton ID="cmdAtualizar" runat="server" Text="Sim" Theme="MetropolisBlue" Width="100px">
                            <ClientSideEvents Click="function(s, e) { AtualizarBanco(s, e); popConfirmacao.Hide(); }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="cmdCancelar" runat="server" Text="Cancelar" Theme="MetropolisBlue" Width="100px">
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popConfirmacao.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <dx:ASPxCallback ID="clbAtualizar" ClientInstanceName="clbAtualizar" runat="server" OnCallback="clbAtualizar_Callback">
            <ClientSideEvents CallbackComplete="function(s, e) { RetornoCallback(s, e); }" />
        </dx:ASPxCallback>
        <dx:ASPxLoadingPanel ID="pnlLoader" runat="server" ClientInstanceName="pnlLoader" Modal="True" Theme="MetropolisBlue" />
    </div>

    <!-- *** Data source do menu de acesso *** -->
    <asp:XmlDataSource ID="XmlDataSourceHeader" runat="server" DataFile="~/App_Data/Admin.xml" XPath="/items/*" />
    <asp:SqlDataSource runat="server" OnInserting="dsEmpresas_Inserting" OnUpdating="dsEmpresas_Updating" ID="dsEmpresas"
        ProviderName='<%$ ConnectionStrings:DevArt_Master.ProviderName %>'
        SelectCommand="SELECT * FROM `agencias_cadastro`"
        UpdateCommand="UPDATE `agencias_cadastro` SET `nome_fantasia` = ?, `razao_social` = ?, `cnpj_cpf` = ?, `logradouro` = ?, `numero` = ?, `complemento` = ?, `cep` = ?, `cidade` = ?, `uf` = ?, `internet` = ?, `contato_nome` = ?, `contato_email` = ?, `contato_fone_fixo` = ?, `contato_fone_celular` = ?, `conexao_nome` = ?, `conexao_driver` = ?, `conexao_server` = ?, `conexao_database` = ?, `conexao_port` = ?, `conexao_user` = ?, `conexao_password` = ?, `conexao_ativa` = ? WHERE `codigo` = ?"
        InsertCommand="INSERT INTO `agencias_cadastro` (`codigo`, `nome_fantasia`, `razao_social`, `cnpj_cpf`, `logradouro`, `numero`, `complemento`, `cep`, `cidade`, `uf`, `internet`, `contato_nome`, `contato_email`, `contato_fone_fixo`, `contato_fone_celular`, `conexao_nome`, `conexao_driver`, `conexao_server`, `conexao_database`, `conexao_port`, `conexao_user`, `conexao_password`, `conexao_ativa`) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        DeleteCommand="DELETE FROM `agencias_cadastro` WHERE `codigo` = ?"
        ConnectionString='<%$ ConnectionStrings:DevArt_Master %>'>
        <UpdateParameters>
            <asp:Parameter Name="nome_fantasia" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="razao_social" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cnpj_cpf" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="logradouro" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="numero" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="complemento" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cep" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cidade" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="uf" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="internet" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_nome" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_email" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_fone_fixo" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_fone_celular" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_nome" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_driver" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_server" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_database" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_port" Type="Int32" DefaultValue="0"></asp:Parameter>
            <asp:Parameter Name="conexao_user" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_password" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_ativa" Type="Int32" DefaultValue="1"></asp:Parameter>
            <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="nome_fantasia" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="razao_social" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cnpj_cpf" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="logradouro" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="numero" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="complemento" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cep" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="cidade" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="uf" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="internet" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_nome" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_email" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_fone_fixo" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="contato_fone_celular" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_nome" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_driver" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_server" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_database" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_port" Type="Int32" DefaultValue="0"></asp:Parameter>
            <asp:Parameter Name="conexao_user" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_password" Type="String" DefaultValue=""></asp:Parameter>
            <asp:Parameter Name="conexao_ativa" Type="Int32" DefaultValue="1"></asp:Parameter>
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="codigo" Type="Int32"></asp:Parameter>
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>