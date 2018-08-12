<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="clientes.aspx.cs" Inherits="Decision.clientes" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="Devart.Data.MySql.Web, Version=8.8.862.0, Culture=neutral, PublicKeyToken=09af7300eec23701" Namespace="Devart.Data.MySql.Web" TagPrefix="cc1" %>

<asp:Content ID="cntCientes" ContentPlaceHolderID="cplCentral" runat="server">
    <script type="text/javascript">

        var Security_Insert = "<% Response.Write(Security_Insert.ToString().ToLower()); %>";
        var Security_Update = "<% Response.Write(Security_Update.ToString().ToLower()); %>";
        var Security_Delete = "<% Response.Write(Security_Delete.ToString().ToLower()); %>";

        var UltimoGrupo = null;

        function InicializaGrupo(s, e)
        {
            //**************************************************
            //* Altera grupo que está sendo visualizado/editado 
            //**************************************************
            //if (s.GetItemCount() > 0 && s.GetSelectedIndex() == -1)
            //    s.SetSelectedIndex(0);
        }

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
            var minRows = 1;
            var maxRows = 26;
            var t = s.GetInputElement();
            if (t.scrollTop == 0) t.scrollTop = 1;
            while (t.scrollTop == 0) {
                if (t.rows > minRows)
                    t.rows--; else
                    break;
                t.scrollTop = 1;
                if (t.rows < maxRows)
                    t.style.overflowY = "hidden";
                if (t.scrollTop > 0) {
                    t.rows++;
                    break;
                }
            }
            while (t.scrollTop > 0) {
                if (t.rows < maxRows) {
                    t.rows++;
                    if (t.scrollTop == 0) t.scrollTop = 1;
                } else {
                    t.style.overflowY = "auto";
                    break;
                }
            }
        }

    </script>
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%;">
        Cadastro de Clientes
    </div>
    <br />
    <div class="TextoCinza16" style="width: 95%; display:block;" align="left">
        <table>
            <tr>
                <td style="padding-right: 5px;">
                    Localizar:
                </td>
                <td style="padding-right: 5px;">
                    <dx:ASPxTextBox ClientInstanceName="txtLocalizar" ID="txtLocalizar" runat="server" Width="300px" CssClass="TextoCinza16" />
                </td>
            </tr>
        </table>        
    </div>
    <br />
    <dx:ASPxGridView ID="grvClientes" runat="server" Theme="MetropolisBlue" AutoGenerateColumns="False" 
        DataSourceID="dsClientes" EnableTheming="True" KeyFieldName="CodCli" Width="95%">
        <SettingsPopup>
            <EditForm Height="520px" HorizontalAlign="WindowCenter" MinHeight="520px" MinWidth="1024px" Modal="True" VerticalAlign="WindowCenter" Width="1024px" />
        </SettingsPopup>
        <SettingsSearchPanel Visible="True" ShowApplyButton="true" ShowClearButton="true" CustomEditorID="txtLocalizar" />
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <SettingsBehavior EnableRowHotTrack="True" />
        <SettingsCookies Enabled="True" CookiesID="Decision_Clientes" />
        <SettingsDataSecurity AllowInsert="False" AllowDelete="False" />
        <Styles>
            <Header CssClass="CampoSemBordas" Font-Bold="False" />
            <RowHotTrack BackColor="#A5C5FA" />
            <Cell>
                <BorderLeft BorderStyle="None" />
                <BorderRight BorderStyle="None" />
            </Cell>
            <Row CssClass="Texto14" />
            <CommandColumn Spacing="5px" />
            <SearchPanel CssClass="Texto16" />
        </Styles>
        <SettingsCommandButton>
            <ShowAdaptiveDetailButton ButtonType="Image" />
            <HideAdaptiveDetailButton ButtonType="Image" />
            <NewButton>
                <Styles Native="True">
                    <Style CssClass="BotaoLinkW60F14">
                </Style>
                </Styles>
            </NewButton>
            <EditButton>
                <Styles Native="True">
                    <Style CssClass="BotaoLinkW60F14">
                </Style>
                </Styles>
            </EditButton>
            <DeleteButton>
                <Styles Native="True">
                    <Style CssClass="BotaoLinkW60F14">
                </Style>
                </Styles>
            </DeleteButton>
            <UpdateButton>
                <Styles Native="True">
                    <Style CssClass="BotaoLinkW100F14">
                </Style>
                </Styles>
            </UpdateButton>
            <CancelButton>
                <Styles Native="True">
                    <Style CssClass="BotaoLinkW100F14">
                </Style>
                </Styles>
            </CancelButton>
        </SettingsCommandButton>
        <BorderLeft BorderStyle="None" />
        <BorderRight BorderStyle="None" />
        <SettingsText PopupEditFormCaption="Cadastro de Clientes" />
        <EditFormLayoutProperties ColCount="4">
            <Items>

                <dx:GridViewTabbedLayoutGroup ColSpan="4" Name="vtlGeral" Width="100%">
                    <Styles>
                        <ActiveTabStyle HoverStyle-Font-Size="16px">
                            <HoverStyle Font-Size="16px"></HoverStyle>
                        </ActiveTabStyle>
                        <ContentStyle Paddings-PaddingTop="25px">
                            <Paddings PaddingTop="25px"></Paddings>
                        </ContentStyle>
                        <TabStyle Font-Size="16px" />
                    </Styles>
                    <Items>

                        <dx:GridViewLayoutGroup Caption="Pessoais" ColCount="4" ColSpan="4" Name="vlgPessoais" Width="100%" Border-BorderWidth="1px" Border-BorderColor="#cccccc">
                            <Items>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="PessoaisV1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Nome e Classificação</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Pessoa" ColumnName="Pessoa">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboPessoa" runat="server" ValueType="System.String" Value='<%# Bind("TipoPessoa") %>' ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Física</span>" Value="F" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Jurídica</span>" Value="J" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColSpan="3" Caption="Nome" ColumnName="Nome">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboNomeCliente" runat="server" Value='<%# Bind("Nome") %>' DataSourceID="dsClientes" ValueField="Nome" TextField="Nome" Theme="MetropolisBlue" EnableTheming="True" Width="100%" DropDownStyle="DropDown" ValueType="System.String" ClearButton-DisplayMode="Always" MaxLength="40">
                                            <ItemStyle CssClass="Texto14" />
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Titular" ColumnName="Titular">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboTitular" runat="server" ValueType="System.String" Value='<%# Bind("Titular") %>' ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Titular</span>" Value="S" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Dependente</span>" Value="N" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Prospect</span>" Value="P" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColSpan="3" ColumnName="Fantasia">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColSpan="4" ColumnName="EMail" Caption="E-Mail">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="PessoaisV1">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="PessoaisV1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Endereço e Identificação</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="EndRes" Caption="Endereço">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="CodCidadeRes" Caption="Cidade/UF/País">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <CaptionStyle CssClass="TextoCinza14">
                                    </CaptionStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CEPRes" Caption="CEP">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Bairro">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CIC" Caption="CPF">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CGC" Caption="CNPJ">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="RG">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Orgao" Caption="Orgão Exp. RG">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="RGUF" Caption="UF Exp. RG">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="InscrMunicipal" Caption="Inscr. Municipal">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="InscrEstadual" Paddings-PaddingBottom="10px" Caption="Inscr. Estadual">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="DataNasc" Caption="Data Nasc." Paddings-PaddingBottom="10px">
                                    <Paddings PaddingBottom="10px" />
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Passaporte">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Val. Passaporte" ColumnName="ValidPassaporte">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="4" Name="PessoaisV2">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewLayoutGroup Caption="Telefones" Name="vlgFones" RowSpan="4">
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                    <GroupBoxStyle>
                                        <Caption CssClass="TextoAzul16">
                                            <Paddings PaddingTop="10px" PaddingBottom="10px" />
                                        </Caption>
                                        <BorderBottom BorderStyle="None" />
                                        <BorderLeft BorderStyle="None" />
                                        <BorderTop BorderStyle="None" />
                                    </GroupBoxStyle>
                                    <Items>
                                        <dx:GridViewColumnLayoutItem ColumnName="FoneRes" Caption="Residencial">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColumnName="FoneTrab" Caption="Comercial">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColumnName="FaxRes" Caption="Cel. 1 / Fax Res.">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColumnName="FaxTrab" Caption="Cel. 2 / Fax Com.">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>
                                    </Items>
                                </dx:GridViewLayoutGroup>

                                <dx:GridViewLayoutGroup Caption="Características" Name="vlgGerais" RowSpan="4">
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                    <GroupBoxStyle>
                                        <Caption CssClass="TextoAzul16">
                                            <Paddings PaddingTop="10px" PaddingBottom="10px" />
                                        </Caption>
                                        <BorderBottom BorderStyle="None" />
                                        <BorderLeft BorderStyle="None" />
                                        <BorderTop BorderStyle="None" />
                                    </GroupBoxStyle>
                                    <Items>

                                        <dx:GridViewColumnLayoutItem Caption="Assento" ColumnName="Assento">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                            <Template>
                                                <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboAssento" runat="server" ValueType="System.String" Value='<%# Bind("Assento") %>' Width="100%" ClearButton-DisplayMode="Always">
                                                    <Items>
                                                        <dx:ListEditItem Text="<span class='Texto16'>Corredor</span>" Value="C" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Meio</span>" Value="M" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Janela</span>" Value="J" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </Template>
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem Caption="Fumante" ColumnName="Fumante">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                            <Template>
                                                <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboFumante" runat="server" ValueType="System.String" Value='<%# Bind("Fumante") %>' Width="100%" ClearButton-DisplayMode="Always">
                                                    <Items>
                                                        <dx:ListEditItem Text="<span class='Texto16'>Sim</span>" Value="F" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Não</span>" Value="N" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </Template>
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="Sexo">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                            <Template>
                                                <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboSexo" runat="server" ValueType="System.String" Value='<%# Bind("Sexo") %>' Width="100%" ClearButton-DisplayMode="Always">
                                                    <Items>
                                                        <dx:ListEditItem Text="<span class='Texto16'>Masculino</span>" Value="M" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Feminino</span>" Value="F" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </Template>
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="EstadoCivil">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                            <Template>
                                                <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboEstadoCivil" runat="server" ValueType="System.String" Value='<%# Bind("EstadoCivil") %>' Width="100%" ClearButton-DisplayMode="Always">
                                                    <Items>
                                                        <dx:ListEditItem Text="<span class='Texto16'>Casado</span>" Value="C" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Desquitado</span>" Value="D" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Divorciado</span>" Value="I" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Separado</span>" Value="P" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Solteiro</span>" Value="S" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Viúvo</span>" Value="V" />
                                                        <dx:ListEditItem Text="<span class='Texto16'>Outros</span>" Value="O" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </Template>
                                        </dx:GridViewColumnLayoutItem>

                                    </Items>
                                </dx:GridViewLayoutGroup>

                                <dx:GridViewLayoutGroup Caption="Cartões de Milhagem" Name="vlgCartoesMilhagem" RowSpan="3" ColSpan="2" ColCount="2">
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                    <GroupBoxStyle>
                                        <Caption CssClass="TextoAzul16">
                                            <Paddings PaddingTop="10px" PaddingBottom="10px" />
                                        </Caption>
                                        <BorderBottom BorderStyle="None" />
                                        <BorderLeft BorderStyle="None" />
                                        <BorderRight BorderStyle="None" />
                                        <BorderTop BorderStyle="None" />
                                    </GroupBoxStyle>
                                    <Items>

                                        <dx:GridViewColumnLayoutItem ColumnName="Cia1" Caption="Companhia">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCia1" Caption="Número">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="Cia2" Caption="Companhia">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCia2" Caption="Nùmero">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="Cia3" Caption="Companhia">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCia3" Caption="Número">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="Cia4" Caption="Companhia">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCia4" Caption="Número">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                    </Items>
                                </dx:GridViewLayoutGroup>

                                <dx:GridViewLayoutGroup Caption="Vistos" Name="vlgVistos" RowSpan="3" ColSpan="4" ColCount="3">
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                    <GroupBoxStyle>
                                        <Caption CssClass="TextoAzul16">
                                            <Paddings PaddingTop="10px" PaddingBottom="10px" />
                                        </Caption>
                                        <BorderBottom BorderStyle="None" />
                                        <BorderLeft BorderStyle="None" />
                                        <BorderRight BorderStyle="None" />
                                        <BorderTop BorderStyle="None" />
                                    </GroupBoxStyle>
                                    <Items>

                                        <dx:GridViewColumnLayoutItem ColumnName="NomeVisto1" Caption="Nome">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="EmissVisto1" Caption="Emissão">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="ValidVisto1" Caption="Validade">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NomeVisto2" Caption="Nome">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="EmissVisto2" Caption="Emissão">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="ValidVisto2" Caption="Validade">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                    </Items>
                                </dx:GridViewLayoutGroup>

                            </Items>

                            <Border BorderColor="#CCCCCC" BorderWidth="1px"></Border>
                        </dx:GridViewLayoutGroup>

                        <dx:GridViewLayoutGroup Caption="Comerciais" ColCount="4" ColSpan="4" Name="vlgComerciais" Width="100%" Border-BorderWidth="1px" Border-BorderColor="#cccccc">
                            <Items>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="PessoaisV1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Informações Comerciais</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="LocalTrab" Caption="Empresa" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Funcao" Caption="Função" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="EMailNFSe" Caption="E-Mail para NFS-e" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="EndTrab" Caption="Endereço" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodCidadeTrab" Caption="Cidade / UF / Estado" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CEPTrab" Caption="CEP">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="TempoTrab" Caption="Tempo de empresa">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodBco" Caption="Tipo Cobrança">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="VlrTxBco" Caption="Tx. Cobrança Banco">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisV1">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisV2">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="4" Name="ComerciaisV3">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewLayoutGroup Caption="Cartões de Crédito" Name="vlgCartoesCredito" ColSpan="4" ColCount="6">
                                    <ParentContainerStyle>
                                        <Paddings Padding="0px" />
                                    </ParentContainerStyle>
                                    <GroupBoxStyle>
                                        <Caption CssClass="TextoAzul16">
                                            <Paddings PaddingTop="10px" PaddingBottom="10px" />
                                        </Caption>
                                        <BorderBottom BorderStyle="None" />
                                        <BorderLeft BorderStyle="None" />
                                        <BorderRight BorderStyle="None" />
                                        <BorderTop BorderStyle="None" />
                                    </GroupBoxStyle>
                                    <Items>

                                        <dx:GridViewColumnLayoutItem ColumnName="TitularCartao1" Caption="Titular" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CartaoCred1" Caption="Bandeira" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCartao1" Caption="Número" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="ValidCartao1" Caption="Validade" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="VenctoCartao1" Caption="Vencimento" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CSCartao1" Caption="Cod. Segurança" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="TitularCartao2" Caption="Titular" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CartaoCred2" Caption="Bandeira" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCartao2" Caption="Número" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="ValidCartao2" Caption="Validade" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="VenctoCartao2" Caption="Vencimento" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CSCartao2" Caption="Cod. Segurança" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="TitularCartao3" Caption="Titular" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CartaoCred3" Caption="Bandeira" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="NroCartao3" Caption="Número" Width="20%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="ValidCartao3" Caption="Validade" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="VenctoCartao3" Caption="Vencimento" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                        <dx:GridViewColumnLayoutItem ColumnName="CSCartao3" Caption="Cod. Segurança" Width="15%">
                                            <CaptionCellStyle CssClass="TituloCampo" />
                                            <Paddings PaddingBottom="10px" />
                                        </dx:GridViewColumnLayoutItem>

                                    </Items>
                                </dx:GridViewLayoutGroup>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="4" Name="ComerciaisV4">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisT1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Referências Comerciais e Bancárias</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="RefCom" Caption="Ref. Comercial" ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="FoneRefCom" Caption="Fone Ref. Comercial">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="RefBco" Caption="Ref. Bancárias" ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="FoneRefBco" Caption="Fone Ref. Bancárias">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="4" Name="ComerciaisV5">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="4" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisT2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Atualizações Cadastrais</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="DtUltimaAlteracao" Caption="Data Ult. Alteração">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="UltimaAlteracaoPor" Caption="Última Alteração Por">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisV6">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComerciaisV7">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                            </Items>

                            <Border BorderColor="#CCCCCC" BorderWidth="1px"></Border>
                        </dx:GridViewLayoutGroup>

                        <dx:GridViewLayoutGroup Caption="Marketing" ColCount="3" ColSpan="4" Name="vlgComerciais" Width="100%" Border-BorderWidth="1px" Border-BorderColor="#cccccc">
                            <Items>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingT1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Atendimento</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="PostoVen" Caption="Unidade Negócio">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ChaveLivre2" Caption="Grupo Corportativo">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ChaveLivre1" Caption="Chave Livre">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="TipoCli" Caption="Classificação">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="SitCli" Caption="Situação">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodProf" Caption="Profissão">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodEmissor" Caption="Atendente">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodPromotor" Caption="Promotor">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodTerceiro" Caption="Terceiro">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="3" Name="MarketingV1">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingT2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Limites e Fidelidade</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Renda" Caption="Lim. Crédido (R$)">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="LimiteUnit" Caption="Lim. Compra Unit. (R$)">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="DataCad" Caption="Cliente Desde">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Potencial Crescimento" ColumnName="Pot Cres">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboPotCres" runat="server" ValueType="System.String" Value='<%# Bind("PotCres") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Alto</span>" Value="A" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Médio</span>" Value="M" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Baixo</span>" Value="A" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Valor Estratégico" ColumnName="Val Estra">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboValEstra" runat="server" ValueType="System.String" Value='<%# Bind("ValEstra") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Alto</span>" Value="A" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Médio</span>" Value="M" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Baixo</span>" Value="A" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Situação Crédito" ColumnName="Sit Credito">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboSitCredito" runat="server" ValueType="System.String" Value='<%# Bind("SitCredito") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Liberado</span>" Value="L" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Bloqueado</span>" Value="B" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CreditoDinCC" Caption="Dinheiro / Cartão">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CreditoCheque" Caption="Cheque">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CreditoOutros" Caption="Outros">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="IndicePontosCli" Caption="Redutor">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="PercentPontosCli" Caption="Percentual">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingV2">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="3" Name="MarketingV3">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingT3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <span class="TextoAzul16">Status e Comunicação</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Status Cliente" ColumnName="Sit Cli">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboStatusCli" runat="server" ValueType="System.String" Value='<%# Bind("StatusCli") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Ativo</span>" Value="A" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Inativo</span>" Value="I" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AssinaNewsletter">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Formato Newsletter" ColumnName="Tipo Newsletter">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboTipoNewsletter" runat="server" ValueType="System.String" Value='<%# Bind("TipoNewsletter") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Texto</span>" Value="T" />
                                                <dx:ListEditItem Text="<span class='Texto16'>HTML</span>" Value="H" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Destino Correspondência" ColumnName="End Corresp">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboTipoNewsletter" runat="server" ValueType="System.String" Value='<%# Bind("EndCorresp") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Residencial</span>" Value="R" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Comercial</span>" Value="T" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Cobrança</span>" Value="C" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingV4">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="MarketingV5">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                            </Items>

                            <Border BorderColor="#CCCCCC" BorderWidth="1px"></Border>
                        </dx:GridViewLayoutGroup>

                        <dx:GridViewLayoutGroup Caption="Complementares" ColCount="3" ColSpan="4" Name="vlgComplementares" Width="100%" Border-BorderWidth="1px" Border-BorderColor="#cccccc">
                            <Items>
                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresT1">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Informações Cadastrais</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Contato" Caption="Contato / Att." ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="TituloMala" ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodContabil" Caption="Codigo Contábil">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="MneCli" Caption="Mnemônico">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="TempoRes" Caption="Tempo Residência">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Filiacao" Caption="Filiação" ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Nacionalidade">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="Naturalidade">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresV1">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="3" Name="ComplementaresV1">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresT2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Dados Administrativos</span>
                                    </Template>
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CartaoCred4" Caption="Data Última Viagem">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="NroCartao4" Caption="Destino Ult. Viagem">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ContaEBTA">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ContaVisa">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ContaCTA">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ItensFatura" Caption="Itens por Fatura">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresV2">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresV3">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="3" Name="ComplementaresV4">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresT3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Endereço de Cobrança</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="EndCobr" Caption="Endereço" ColSpan="3">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CodCidadeCobr" Caption="Cidade / UF / Estado" ColSpan="2">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="CEPCobr" Caption="CEP">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" ColSpan="3" Name="ComplementaresV5">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                                <dx:GridViewColumnLayoutItem ShowCaption="False" ColSpan="3" ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresT4">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Template>
                                        <span class="TextoAzul16">Controles Adicionais</span>
                                    </Template>

                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Frequência Faturamento" ColSpan="2" ColumnName="Periodo Fatura">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboPeriodoFatura" runat="server" ValueType="System.String" Value='<%# Bind("PeriodoFatura") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Diário</span>" Value="Diário" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Semanal</span>" Value="Semanal" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Decendial</span>" Value="Decendial" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Quinzenal</span>" Value="Quinzenal" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Mensal</span>" Value="Mensal" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaCodCtbForn" Caption="Agrupa Cód. Fornecedor">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaTipoCobra" Caption="Agrupa Tipo Cobrança">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaCatProd" Caption="Agrupa Categoria Produto">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaProd" Caption="Agrupa Produto">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaForn" Caption="Agrupa Fornecedor">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaCC" Caption="Agrupa Centro Custo">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaPax">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaReq" Caption="Agrupa Requisição">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="AgrupaReqCliente" Caption="Agrupa Requisição Cliente">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ObrigaCentroCusto" Caption="Obriga CC na Requisição">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="ObrigaObservacao" Caption="Obriga Obs. na Requisição">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem ColumnName="GeraFatPDF" Caption="Salva Boletos/Faturas em PDF">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                </dx:GridViewColumnLayoutItem>

                                <dx:GridViewColumnLayoutItem Caption="Retenção Lei Kandir">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                    <Paddings PaddingBottom="10px" />
                                    <Template>
                                        <dx:ASPxComboBox CssClass="CampoSemBordas" EncodeHtml="false" ID="cboLeiKandir" runat="server" ValueType="System.String" Value='<%# Bind("LeiKandir") %>' Width="100%" ClearButton-DisplayMode="Always">
                                            <Items>
                                                <dx:ListEditItem Text="<span class='Texto16'>Tarifa</span>" Value="S" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Tarifa + Acrésc. - Desc.</span>" Value="D" />
                                                <dx:ListEditItem Text="<span class='Texto16'>Tarifa</span>" Value="A" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </Template>
                                </dx:GridViewColumnLayoutItem>

                                <dx:EmptyLayoutItem ParentContainerStyle-Paddings-PaddingBottom="10px" Name="ComplementaresV7">
                                    <ParentContainerStyle>
                                        <Paddings PaddingBottom="10px"></Paddings>
                                    </ParentContainerStyle>
                                </dx:EmptyLayoutItem>

                            </Items>

                            <Border BorderColor="#CCCCCC" BorderWidth="1px"></Border>
                        </dx:GridViewLayoutGroup>

                        <dx:GridViewLayoutGroup Caption="Observações" ColCount="1" ColSpan="4" Name="vlgObservações" Width="100%" Height="100%" Border-BorderWidth="1px" Border-BorderColor="#cccccc">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="Observacoes" Width="100%" Height="100%" Caption="Observações">
                                    <CaptionCellStyle CssClass="TituloCampo" />
                                </dx:GridViewColumnLayoutItem>
                            </Items>

                            <Border BorderColor="#CCCCCC" BorderWidth="1px"></Border>
                        </dx:GridViewLayoutGroup>
                    </Items>

                </dx:GridViewTabbedLayoutGroup>
            </Items>

        </EditFormLayoutProperties>
        <Templates>
            <EditForm>
                <dx:ASPxGridViewTemplateReplacement ID="Editors" ReplacementType="EditFormEditors" runat="server" />
                <table style="width: 95%;">
                    <tr>
                        <td>
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
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="15%">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CodCli" ReadOnly="True" Visible="False" VisibleIndex="7">
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LocalTrab" VisibleIndex="8" Visible="False">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MneCli" Visible="False" VisibleIndex="16">
                <PropertiesTextEdit MaxLength="14">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LeiKandir" Visible="False" VisibleIndex="17">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Contato" Visible="False" VisibleIndex="35">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EndRes" VisibleIndex="37" Visible="False">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FoneRes" VisibleIndex="38" Visible="False">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FaxRes" Visible="False" VisibleIndex="39">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CEPRes" Visible="False" VisibleIndex="40">
                <PropertiesTextEdit MaxLength="9" NullDisplayText=" ">
                    <MaskSettings IncludeLiterals="None" Mask="99999-999" PromptChar=" " />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Filiacao" Visible="False" VisibleIndex="42">
                <PropertiesTextEdit MaxLength="70">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DataNasc" Visible="False" VisibleIndex="43">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="CIC" VisibleIndex="5" Caption="CPF" Width="10%">
                <PropertiesTextEdit MaxLength="14" DisplayFormatString="999.999.999-99" NullText=" ">
                    <MaskSettings IncludeLiterals="None" Mask="999,999,999-99" PromptChar=" " />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="BeginsWith" FilterMode="DisplayText" />
                <SettingsHeaderFilter>
                    <DateRangePickerSettings DisplayFormatString="" />
                </SettingsHeaderFilter>
                <EditFormSettings Visible="True" />
                <FilterCellStyle CssClass="CampoSemBordas">
                </FilterCellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RG" Visible="False" VisibleIndex="44">
                <PropertiesTextEdit MaxLength="11">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Orgao" Visible="False" VisibleIndex="45">
                <PropertiesTextEdit MaxLength="5">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RGUF" Visible="False" VisibleIndex="46">
                <PropertiesTextEdit MaxLength="2">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Nacionalidade" Visible="False" VisibleIndex="47">
                <PropertiesTextEdit MaxLength="25">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Naturalidade" Visible="False" VisibleIndex="48">
                <PropertiesTextEdit MaxLength="25">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="InscrEstadual" Visible="False" VisibleIndex="49">
                <PropertiesTextEdit MaxLength="14">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CGC" VisibleIndex="6" Caption="CNPJ" Width="10%">
                <PropertiesTextEdit MaxLength="14" DisplayFormatString="99.999.999/9999-99" NullText=" ">
                    <MaskSettings IncludeLiterals="None" Mask="99,999,999/9999-99" PromptChar=" " />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="BeginsWith" FilterMode="DisplayText" />
                <SettingsHeaderFilter>
                    <DateRangePickerSettings DisplayFormatString="" />
                </SettingsHeaderFilter>
                <EditFormSettings Visible="True" />
                <FilterCellStyle CssClass="CampoSemBordas">
                </FilterCellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EstadoCivil" Visible="False" VisibleIndex="50">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EMail" VisibleIndex="2" Caption="E-Mail" Width="20%">
                <PropertiesTextEdit MaxLength="60">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Passaporte" Visible="False" VisibleIndex="51">
                <PropertiesTextEdit MaxLength="10">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="ValidPassaporte" Visible="False" VisibleIndex="52">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="NomeVisto1" Visible="False" VisibleIndex="53">
                <PropertiesTextEdit MaxLength="10">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NomeVisto2" Visible="False" VisibleIndex="54">
                <PropertiesTextEdit MaxLength="10">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="ValidVisto1" Visible="False" VisibleIndex="55">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ValidVisto2" Visible="False" VisibleIndex="56">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EndTrab" VisibleIndex="57" Visible="False">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CEPTrab" Visible="False" VisibleIndex="59">
                <PropertiesTextEdit MaxLength="9" NullDisplayText=" ">
                    <MaskSettings IncludeLiterals="None" Mask="99999-999" PromptChar=" " />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FoneTrab" VisibleIndex="60" Visible="False">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FaxTrab" Visible="False" VisibleIndex="61">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RefCom" Visible="False" VisibleIndex="64">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FoneRefCom" Visible="False" VisibleIndex="65">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RefBco" Visible="False" VisibleIndex="66">
                <PropertiesTextEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FoneRefBco" Visible="False" VisibleIndex="67">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cia1" Visible="False" VisibleIndex="68">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCia1" Visible="False" VisibleIndex="69">
                <PropertiesTextEdit MaxLength="15">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cia2" Visible="False" VisibleIndex="70">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCia2" Visible="False" VisibleIndex="71">
                <PropertiesTextEdit MaxLength="15">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cia3" Visible="False" VisibleIndex="72">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCia3" Visible="False" VisibleIndex="73">
                <PropertiesTextEdit MaxLength="15">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cia4" Visible="False" VisibleIndex="74">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCia4" Visible="False" VisibleIndex="75">
                <PropertiesTextEdit MaxLength="15">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DataCad" Visible="False" VisibleIndex="76">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="CodContabil" Visible="False" VisibleIndex="77">
                <PropertiesTextEdit MaxLength="10">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Fumante" Visible="False" VisibleIndex="78">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Assento" Visible="False" VisibleIndex="79">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EndCobr" Visible="False" VisibleIndex="80">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CEPCobr" Visible="False" VisibleIndex="82">
                <PropertiesTextEdit MaxLength="9" NullDisplayText=" ">
                    <MaskSettings IncludeLiterals="None" Mask="99999-999" PromptChar=" " />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SitCredito" Visible="False" VisibleIndex="84">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CartaoCred1" Visible="False" VisibleIndex="86">
                <PropertiesTextEdit MaxLength="12">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CartaoCred2" Visible="False" VisibleIndex="87">
                <PropertiesTextEdit MaxLength="12">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CartaoCred3" Visible="False" VisibleIndex="88">
                <PropertiesTextEdit MaxLength="12">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCartao1" Visible="False" VisibleIndex="90">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCartao2" Visible="False" VisibleIndex="91">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCartao3" Visible="False" VisibleIndex="92">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NroCartao4" Visible="False" VisibleIndex="93">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TituloMala" Visible="False" VisibleIndex="98">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DtUltimaAlteracao" Visible="False" VisibleIndex="103">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="UltimaAlteracaoPor" Visible="False" VisibleIndex="104">
                <PropertiesTextEdit MaxLength="20">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EmissVisto1" Visible="False" VisibleIndex="105">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="EmissVisto2" Visible="False" VisibleIndex="106">
                <PropertiesDateEdit>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesDateEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Funcao" Visible="False" VisibleIndex="107">
                <PropertiesTextEdit MaxLength="30">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ChaveLivre1" Visible="False" VisibleIndex="108">
                <PropertiesTextEdit MaxLength="30">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ChaveLivre2" Visible="False" VisibleIndex="109">
                <PropertiesTextEdit MaxLength="30">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ContaEBTA" Visible="False" VisibleIndex="117">
                <PropertiesTextEdit MaxLength="16">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Fantasia" Visible="False" VisibleIndex="118">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Bairro" Visible="False" VisibleIndex="119">
                <PropertiesTextEdit MaxLength="25">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TitularCartao1" Visible="False" VisibleIndex="120">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TitularCartao2" Visible="False" VisibleIndex="121">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TitularCartao3" Visible="False" VisibleIndex="122">
                <PropertiesTextEdit MaxLength="40">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CSCartao1" Visible="False" VisibleIndex="123">
                <PropertiesTextEdit MaxLength="5">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CSCartao2" Visible="False" VisibleIndex="124">
                <PropertiesTextEdit MaxLength="5">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CSCartao3" Visible="False" VisibleIndex="125">
                <PropertiesTextEdit MaxLength="5">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ContaCTA" Visible="False" VisibleIndex="127">
                <PropertiesTextEdit MaxLength="16">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ContaVisa" Visible="False" VisibleIndex="128">
                <PropertiesTextEdit MaxLength="16">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="InscrMunicipal" Visible="False" VisibleIndex="132">
                <PropertiesTextEdit MaxLength="14">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EMailNFSe" Visible="False" VisibleIndex="133">
                <PropertiesTextEdit MaxLength="60">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodProf" Visible="False" VisibleIndex="9">
                <PropertiesComboBox DataSourceID="dsProfissao" TextField="Descricao" ValueField="CodProf">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodBco" Visible="False" VisibleIndex="10">
                <PropertiesComboBox DataSourceID="dsBanco" TextField="descbco" ValueField="codbco">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="TipoCli" Visible="False" VisibleIndex="11">
                <PropertiesComboBox DataSourceID="dsClassifica" TextField="desctipocli" ValueField="tipocli">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="SitCli" Visible="False" VisibleIndex="12">
                <PropertiesComboBox DataSourceID="dsSituacao" TextField="DescSitCli" ValueField="SitCli">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="PostoVen" Visible="False" VisibleIndex="13">
                <PropertiesComboBox DataSourceID="dsPosto" TextField="descposto" ValueField="postoven">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodPromotor" Visible="False" VisibleIndex="14">
                <PropertiesComboBox DataSourceID="dsPromotor" TextField="nomepromotor" ValueField="codpromotor">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="Titular" Visible="False" VisibleIndex="15">
                <PropertiesComboBox MaxLength="1">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="StatusCli" Visible="False" VisibleIndex="18">
                <PropertiesComboBox MaxLength="1">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodEmissor" Visible="False" VisibleIndex="21">
                <PropertiesComboBox DataSourceID="dsAtendente" TextField="nomepromotor" ValueField="codpromotor">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodTerceiro" Visible="False" VisibleIndex="22">
                <PropertiesComboBox DataSourceID="dsTerceiro" TextField="nomepromotor" ValueField="codpromotor">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaCodCtbForn" Visible="False" VisibleIndex="24">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaTipoCobra" Visible="False" VisibleIndex="25">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaCatProd" Visible="False" VisibleIndex="26">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaProd" Visible="False" VisibleIndex="27">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaForn" Visible="False" VisibleIndex="28">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaCC" Visible="False" VisibleIndex="29">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaPax" Visible="False" VisibleIndex="30">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaReq" Visible="False" VisibleIndex="31">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="AgrupaReqCliente" Visible="False" VisibleIndex="34">
                <PropertiesCheckEdit>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodCidadeTrab" Visible="False" VisibleIndex="58">
                <PropertiesComboBox DataSourceID="dsCidades" TextField="nomecidade" ValueField="codcidade" TextFormatString="{0}, {1}, {2}" NullText=" ">
                    <Columns>
                        <dx:ListBoxColumn Caption="Cidade" FieldName="nomecidade" Width="60%" />
                        <dx:ListBoxColumn Caption="UF" FieldName="uf" Width="20%" />
                        <dx:ListBoxColumn Caption="País" FieldName="descpais" Width="20%" />
                    </Columns>
                    <ClearButton DisplayMode="OnHover">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn FieldName="VlrTxBco" Visible="False" VisibleIndex="126">
                <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatString="C" NumberFormat="Custom" DisplayFormatInEditMode="True">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="IndicePontosCli" Visible="False" VisibleIndex="19">
                <PropertiesSpinEdit DecimalPlaces="4" DisplayFormatInEditMode="True" DisplayFormatString="{0}" NumberFormat="Custom">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="PercentPontosCli" Visible="False" VisibleIndex="20">
                <PropertiesSpinEdit DecimalPlaces="4" DisplayFormatInEditMode="True" DisplayFormatString="{0}%" NumberFormat="Percent">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="Renda" Visible="False" VisibleIndex="63">
                <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatInEditMode="True" DisplayFormatString="C" NumberFormat="Custom">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="LimiteUnit" Visible="False" VisibleIndex="131">
                <PropertiesSpinEdit DecimalPlaces="2" DisplayFormatInEditMode="True" DisplayFormatString="C" NumberFormat="Custom">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="VenctoCartao1" Visible="False" VisibleIndex="99">
                <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="g" MaxValue="30" MinValue="1" NumberType="Integer" MaxLength="2">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="VenctoCartao2" Visible="False" VisibleIndex="100">
                <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="g" MaxValue="30" MinValue="1" NumberType="Integer" MaxLength="2">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="VenctoCartao3" Visible="False" VisibleIndex="101">
                <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="g" MaxValue="30" MinValue="1" NumberType="Integer" MaxLength="2">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="VenctoCartao4" Visible="False" VisibleIndex="102">
                <PropertiesSpinEdit DisplayFormatInEditMode="True" DisplayFormatString="g" MaxValue="30" MinValue="1" NumberType="Integer" MaxLength="2">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataCheckColumn FieldName="CreditoDinCC" Visible="False" VisibleIndex="112">
                <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" ValueUnchecked="">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="CreditoCheque" Visible="False" VisibleIndex="113">
                <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" ValueUnchecked="">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="CreditoOutros" Visible="False" VisibleIndex="114">
                <PropertiesCheckEdit ValueChecked="1" ValueType="System.Byte" ValueUnchecked="">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="PotCres" Visible="False" VisibleIndex="115">
                <PropertiesComboBox>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn FieldName="ValEstra" Visible="False" VisibleIndex="116">
                <PropertiesComboBox>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="AssinaNewsletter" Visible="False" VisibleIndex="110">
                <PropertiesCheckEdit ValueChecked="S" ValueType="System.Char" ValueUnchecked="N">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="TipoNewsletter" Visible="False" VisibleIndex="111">
                <PropertiesComboBox MaxLength="1">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="ObrigaCentroCusto" Visible="False" VisibleIndex="129">
                <PropertiesCheckEdit ValueChecked="S" ValueType="System.Char" ValueUnchecked="N">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="ObrigaObservacao" Visible="False" VisibleIndex="130">
                <PropertiesCheckEdit ValueChecked="S" ValueType="System.Char" ValueUnchecked="N">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="EndCorresp" Visible="False" VisibleIndex="83">
                <PropertiesComboBox MaxLength="1">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn FieldName="TempoTrab" Visible="False" VisibleIndex="62">
                <PropertiesSpinEdit DisplayFormatString="g" MaxValue="99">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn FieldName="ValidCartao1" Visible="False" VisibleIndex="94">
                <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="MM/yy" MaxLength="6">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ValidCartao2" Visible="False" VisibleIndex="95">
                <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="MM/yy" MaxLength="6">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ValidCartao3" Visible="False" VisibleIndex="96">
                <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="MM/yy" MaxLength="6">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ValidCartao4" Visible="False" VisibleIndex="97">
                <PropertiesTextEdit DisplayFormatInEditMode="True" DisplayFormatString="MM/yy" MaxLength="6">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="Sexo" Visible="False" VisibleIndex="36">
                <PropertiesComboBox MaxLength="1">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn FieldName="CartaoCred4" Visible="False" VisibleIndex="89">
                <PropertiesTextEdit MaxLength="12">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="PeriodoFatura" Visible="False" VisibleIndex="32">
                <PropertiesComboBox MaxLength="20">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataCheckColumn FieldName="GeraFatPDF" Visible="False" VisibleIndex="23">
                <PropertiesCheckEdit ValueChecked="S" ValueType="System.Char" ValueUnchecked="N">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesCheckEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CodCidadeCobr" Visible="False" VisibleIndex="81">
                <PropertiesComboBox DataSourceID="dsCidades" TextField="nomecidade" ValueField="codcidade" TextFormatString="{0}, {1}, {2}" NullText=" ">
                    <Columns>
                        <dx:ListBoxColumn Caption="Cidade" FieldName="nomecidade" Width="60%" />
                        <dx:ListBoxColumn Caption="UF" FieldName="uf" Width="20%" />
                        <dx:ListBoxColumn Caption="País" FieldName="descpais" Width="20%" />
                    </Columns>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataSpinEditColumn FieldName="ItensFatura" Visible="False" VisibleIndex="33">
                <PropertiesSpinEdit DisplayFormatString="g" MaxValue="300">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataSpinEditColumn FieldName="TempoRes" Visible="False" VisibleIndex="41">
                <PropertiesSpinEdit DisplayFormatString="g" MaxValue="150">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesSpinEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataTextColumn FieldName="TipoPessoa" VisibleIndex="4" Caption="Pessoa" Width="5%">
                <PropertiesTextEdit MaxLength="1">
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesTextEdit>
                <Settings AutoFilterCondition="Equals" FilterMode="DisplayText" />
                <EditFormSettings Visible="True" />
                <FilterCellStyle CssClass="CampoSemBordas">
                </FilterCellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Nome" FieldName="Nome" VisibleIndex="1" Width="25%">
                <PropertiesComboBox ConvertEmptyStringToNull="False" DataSourceID="dsClientes" MaxLength="40" TextField="Nome" ValueField="Nome">
                    <ClearButton DisplayMode="Always" />
                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText">
                        <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                    </ValidationSettings>
                    <Style CssClass="CampoSemBordas" />
                </PropertiesComboBox>
                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                <EditFormSettings Visible="True" />
                <EditCellStyle Wrap="False">
                </EditCellStyle>
                <FilterCellStyle Wrap="False">
                </FilterCellStyle>
                <EditFormCaptionStyle Wrap="False">
                </EditFormCaptionStyle>
                <BatchEditModifiedCellStyle Wrap="False">
                </BatchEditModifiedCellStyle>
                <HeaderStyle Wrap="False" />
                <CellStyle Wrap="False">
                </CellStyle>
                <FooterCellStyle Wrap="False">
                </FooterCellStyle>
                <GroupFooterCellStyle Wrap="False">
                </GroupFooterCellStyle>
                <ExportCellStyle Wrap="False">
                </ExportCellStyle>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Cidade" FieldName="CodCidadeRes" VisibleIndex="3" Width="15%">
                <PropertiesComboBox DataSourceID="dsCidades" TextField="nomecidade" ValueField="codcidade" TextFormatString="{0}, {1}, {2}" NullText=" ">
                    <Columns>
                        <dx:ListBoxColumn Caption="Cidade" FieldName="nomecidade" />
                        <dx:ListBoxColumn Caption="UF" FieldName="uf" />
                        <dx:ListBoxColumn Caption="País" FieldName="descpais" />
                    </Columns>
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                    <Style CssClass="CampoSemBordas" />
                </PropertiesComboBox>
                <Settings AutoFilterCondition="Contains" FilterMode="DisplayText" />
                <EditFormSettings Visible="True" />
                <EditCellStyle Wrap="False">
                </EditCellStyle>
                <FilterCellStyle Wrap="False">
                </FilterCellStyle>
                <CellStyle Wrap="False">
                </CellStyle>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataMemoColumn FieldName="Observacoes" Visible="False" VisibleIndex="85">
                <PropertiesMemoEdit>
                    <ClientSideEvents GotFocus="function(s, e) { EscondeScrollVertical(s, e) }" Init="function(s, e) { EscondeScrollVertical(s, e) }" KeyUp="function(s, e) { AjustaAltura(s, e); }" />
                    <Style CssClass="CampoSemBordas">
                    </Style>
                </PropertiesMemoEdit>
                <EditFormSettings Visible="True" />
            </dx:GridViewDataMemoColumn>
        </Columns>
    </dx:ASPxGridView>

    <cc1:MySqlDataSource runat="server" ID="dsClientes" 
        ConnectionString='<%$ ConnectionStrings:Devart_Master %>' OldValuesParameterFormatString="Original_{0}" 
        ProviderName='<%$ ConnectionStrings:Devart_Master.ProviderName %>' 
        SelectCommand="clientes_select" SelectCommandType="StoredProcedure" 
        UpdateCommand="clientes_update" UpdateCommandType="StoredProcedure"
        InsertCommand="clientes_insert" InsertCommandType="StoredProcedure" 
        DeleteCommand="clientes_delete" DeleteCommandType="StoredProcedure">
        <UpdateParameters>
            <asp:Parameter Name="agrupacatprod" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupacc" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupacodctbforn" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupaforn" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupapax" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupaprod" Type="String"></asp:Parameter>
            <asp:Parameter Name="agrupareq" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupareqcliente" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupasolicitante" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupatipocobra" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="assento" Type="String"></asp:Parameter>
            <asp:Parameter Name="assinanewsletter" Type="String"></asp:Parameter>
            <asp:Parameter Name="bairro" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred3" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred4" Type="String"></asp:Parameter>
            <asp:Parameter Name="cepcobr" Type="String"></asp:Parameter>
            <asp:Parameter Name="cepres" Type="String"></asp:Parameter>
            <asp:Parameter Name="ceptrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="cgc" Type="String"></asp:Parameter>
            <asp:Parameter Name="chavelivre1" Type="String"></asp:Parameter>
            <asp:Parameter Name="chavelivre2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia3" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia4" Type="String"></asp:Parameter>
            <asp:Parameter Name="cic" Type="String"></asp:Parameter>
            <asp:Parameter Name="codbco" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidadecobr" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidaderes" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidadetrab" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcontabil" Type="String"></asp:Parameter>
            <asp:Parameter Name="codemissor" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codprof" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codpromotor" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codterceiro" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="contacta" Type="String"></asp:Parameter>
            <asp:Parameter Name="contaebta" Type="String"></asp:Parameter>
            <asp:Parameter Name="contato" Type="String"></asp:Parameter>
            <asp:Parameter Name="contavisa" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditocheque" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditodincc" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditooutros" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="datacad" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="datanasc" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="dtultimaalteracao" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="email" Type="String"></asp:Parameter>
            <asp:Parameter Name="emailnfse" Type="String"></asp:Parameter>
            <asp:Parameter Name="emissvisto1" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="emissvisto2" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="endcobr" Type="String"></asp:Parameter>
            <asp:Parameter Name="endcorresp" Type="String"></asp:Parameter>
            <asp:Parameter Name="endres" Type="String"></asp:Parameter>
            <asp:Parameter Name="endtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="estadocivil" Type="String"></asp:Parameter>
            <asp:Parameter Name="fantasia" Type="String"></asp:Parameter>
            <asp:Parameter Name="faxres" Type="String"></asp:Parameter>
            <asp:Parameter Name="faxtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="filiacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonerefbco" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonerefcom" Type="String"></asp:Parameter>
            <asp:Parameter Name="foneres" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonetrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="fumante" Type="String"></asp:Parameter>
            <asp:Parameter Name="funcao" Type="String"></asp:Parameter>
            <asp:Parameter Name="gerafatpdf" Type="String"></asp:Parameter>
            <asp:Parameter Name="indicepontoscli" Type="Double"></asp:Parameter>
            <asp:Parameter Name="inscrestadual" Type="String"></asp:Parameter>
            <asp:Parameter Name="inscrmunicipal" Type="String"></asp:Parameter>
            <asp:Parameter Name="itensfatura" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="leikandir" Type="String"></asp:Parameter>
            <asp:Parameter Name="limiteunit" Type="Double"></asp:Parameter>
            <asp:Parameter Name="localtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="mnecli" Type="String"></asp:Parameter>
            <asp:Parameter Name="nacionalidade" Type="String"></asp:Parameter>
            <asp:Parameter Name="naturalidade" Type="String"></asp:Parameter>
            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="nomevisto1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nomevisto2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia3" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia4" Type="String"></asp:Parameter>
            <asp:Parameter Name="obrigacentrocusto" Type="String"></asp:Parameter>
            <asp:Parameter Name="obrigaobservacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="observacoes" Type="String"></asp:Parameter>
            <asp:Parameter Name="orgao" Type="String"></asp:Parameter>
            <asp:Parameter Name="original_codcli" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="passaporte" Type="String"></asp:Parameter>
            <asp:Parameter Name="percentpontoscli" Type="Double"></asp:Parameter>
            <asp:Parameter Name="periodofatura" Type="String"></asp:Parameter>
            <asp:Parameter Name="postoven" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="potcres" Type="String"></asp:Parameter>
            <asp:Parameter Name="refbco" Type="String"></asp:Parameter>
            <asp:Parameter Name="refcom" Type="String"></asp:Parameter>
            <asp:Parameter Name="renda" Type="Double"></asp:Parameter>
            <asp:Parameter Name="rg" Type="String"></asp:Parameter>
            <asp:Parameter Name="rguf" Type="String"></asp:Parameter>
            <asp:Parameter Name="sexo" Type="String"></asp:Parameter>
            <asp:Parameter Name="sitcli" Type="String"></asp:Parameter>
            <asp:Parameter Name="sitcredito" Type="String"></asp:Parameter>
            <asp:Parameter Name="statuscli" Type="String"></asp:Parameter>
            <asp:Parameter Name="tempores" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="tempotrab" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="tipocli" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="tiponewsletter" Type="String"></asp:Parameter>
            <asp:Parameter Name="tipopessoa" Type="String"></asp:Parameter>
            <asp:Parameter Name="titular" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="titulomala" Type="String"></asp:Parameter>
            <asp:Parameter Name="ultimaalteracaopor" Type="String"></asp:Parameter>
            <asp:Parameter Name="valestra" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="validpassaporte" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="validvisto1" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="validvisto2" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="venctocartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="vlrtxbco" Type="Double"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="agrupacatprod" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupacc" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupacodctbforn" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupaforn" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupapax" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupaprod" Type="String"></asp:Parameter>
            <asp:Parameter Name="agrupareq" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupareqcliente" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupasolicitante" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="agrupatipocobra" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="assento" Type="String"></asp:Parameter>
            <asp:Parameter Name="assinanewsletter" Type="String"></asp:Parameter>
            <asp:Parameter Name="bairro" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred3" Type="String"></asp:Parameter>
            <asp:Parameter Name="cartaocred4" Type="String"></asp:Parameter>
            <asp:Parameter Name="cepcobr" Type="String"></asp:Parameter>
            <asp:Parameter Name="cepres" Type="String"></asp:Parameter>
            <asp:Parameter Name="ceptrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="cgc" Type="String"></asp:Parameter>
            <asp:Parameter Name="chavelivre1" Type="String"></asp:Parameter>
            <asp:Parameter Name="chavelivre2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia3" Type="String"></asp:Parameter>
            <asp:Parameter Name="cia4" Type="String"></asp:Parameter>
            <asp:Parameter Name="cic" Type="String"></asp:Parameter>
            <asp:Parameter Name="codbco" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidadecobr" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidaderes" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcidadetrab" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codcli" Type="Int32" DefaultValue="0"></asp:Parameter>
            <asp:Parameter Name="codcontabil" Type="String"></asp:Parameter>
            <asp:Parameter Name="codemissor" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codprof" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codpromotor" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="codterceiro" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="contacta" Type="String"></asp:Parameter>
            <asp:Parameter Name="contaebta" Type="String"></asp:Parameter>
            <asp:Parameter Name="contato" Type="String"></asp:Parameter>
            <asp:Parameter Name="contavisa" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditocheque" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditodincc" Type="String"></asp:Parameter>
            <asp:Parameter Name="creditooutros" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="cscartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="datacad" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="datanasc" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="dtultimaalteracao" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="email" Type="String"></asp:Parameter>
            <asp:Parameter Name="emailnfse" Type="String"></asp:Parameter>
            <asp:Parameter Name="emissvisto1" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="emissvisto2" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="endcobr" Type="String"></asp:Parameter>
            <asp:Parameter Name="endcorresp" Type="String"></asp:Parameter>
            <asp:Parameter Name="endres" Type="String"></asp:Parameter>
            <asp:Parameter Name="endtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="estadocivil" Type="String"></asp:Parameter>
            <asp:Parameter Name="fantasia" Type="String"></asp:Parameter>
            <asp:Parameter Name="faxres" Type="String"></asp:Parameter>
            <asp:Parameter Name="faxtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="filiacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonerefbco" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonerefcom" Type="String"></asp:Parameter>
            <asp:Parameter Name="foneres" Type="String"></asp:Parameter>
            <asp:Parameter Name="fonetrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="fumante" Type="String"></asp:Parameter>
            <asp:Parameter Name="funcao" Type="String"></asp:Parameter>
            <asp:Parameter Name="gerafatpdf" Type="String"></asp:Parameter>
            <asp:Parameter Name="indicepontoscli" Type="Double"></asp:Parameter>
            <asp:Parameter Name="inscrestadual" Type="String"></asp:Parameter>
            <asp:Parameter Name="inscrmunicipal" Type="String"></asp:Parameter>
            <asp:Parameter Name="itensfatura" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="leikandir" Type="String"></asp:Parameter>
            <asp:Parameter Name="limiteunit" Type="Double"></asp:Parameter>
            <asp:Parameter Name="localtrab" Type="String"></asp:Parameter>
            <asp:Parameter Name="mnecli" Type="String"></asp:Parameter>
            <asp:Parameter Name="nacionalidade" Type="String"></asp:Parameter>
            <asp:Parameter Name="naturalidade" Type="String"></asp:Parameter>
            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="nomevisto1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nomevisto2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia1" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia2" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia3" Type="String"></asp:Parameter>
            <asp:Parameter Name="nrocia4" Type="String"></asp:Parameter>
            <asp:Parameter Name="obrigacentrocusto" Type="String"></asp:Parameter>
            <asp:Parameter Name="obrigaobservacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="observacoes" Type="String"></asp:Parameter>
            <asp:Parameter Name="orgao" Type="String"></asp:Parameter>
            <asp:Parameter Name="passaporte" Type="String"></asp:Parameter>
            <asp:Parameter Name="percentpontoscli" Type="Double"></asp:Parameter>
            <asp:Parameter Name="periodofatura" Type="String"></asp:Parameter>
            <asp:Parameter Name="postoven" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="potcres" Type="String"></asp:Parameter>
            <asp:Parameter Name="refbco" Type="String"></asp:Parameter>
            <asp:Parameter Name="refcom" Type="String"></asp:Parameter>
            <asp:Parameter Name="renda" Type="Double"></asp:Parameter>
            <asp:Parameter Name="rg" Type="String"></asp:Parameter>
            <asp:Parameter Name="rguf" Type="String"></asp:Parameter>
            <asp:Parameter Name="sexo" Type="String"></asp:Parameter>
            <asp:Parameter Name="sitcli" Type="String"></asp:Parameter>
            <asp:Parameter Name="sitcredito" Type="String"></asp:Parameter>
            <asp:Parameter Name="statuscli" Type="String"></asp:Parameter>
            <asp:Parameter Name="tempores" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="tempotrab" Type="Int16"></asp:Parameter>
            <asp:Parameter Name="tipocli" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="tiponewsletter" Type="String"></asp:Parameter>
            <asp:Parameter Name="tipopessoa" Type="String"></asp:Parameter>
            <asp:Parameter Name="titular" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="titularcartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="titulomala" Type="String"></asp:Parameter>
            <asp:Parameter Name="ultimaalteracaopor" Type="String"></asp:Parameter>
            <asp:Parameter Name="valestra" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="validcartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="validpassaporte" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="validvisto1" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="validvisto2" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="venctocartao1" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao2" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao3" Type="String"></asp:Parameter>
            <asp:Parameter Name="venctocartao4" Type="String"></asp:Parameter>
            <asp:Parameter Name="vlrtxbco" Type="Double"></asp:Parameter>
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="codcli" Type="Int32"></asp:Parameter>
        </DeleteParameters>
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsCidades" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT cidade.codcidade, cidade.nomecidade, cidade.uf, pais.descpais FROM `cidade` LEFT JOIN pais ON pais.codpais = cidade.codpais">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsBanco" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT banco.codbco, banco.descbco FROM `banco`">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsPosto" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT posto.postoven, posto.descposto FROM `posto`">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsClassifica" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT classifica.tipocli, classifica.desctipocli FROM `classifica`">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsSituacao" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT situacao.SitCli, situacao.DescSitCli FROM `situacao`">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsProfissao" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT profissao.CodProf, profissao.Descricao FROM `profissao`">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsPromotor" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT * FROM promotor WHERE promotor.tipo = 'P' OR codpromotor=0">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsAtendente" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT * FROM promotor WHERE promotor.tipo = 'E' OR codpromotor=0">
    </cc1:MySqlDataSource>
    <cc1:MySqlDataSource ID="dsTerceiro" runat="server"
        ProviderName="<%$ ConnectionStrings:Devart_Master.ProviderName %>"
        ConnectionString="<%$ ConnectionStrings:Devart_Master %>"
        SelectCommand="SELECT * FROM promotor WHERE promotor.tipo = 'A' OR codpromotor=0">
    </cc1:MySqlDataSource>
</asp:Content>

