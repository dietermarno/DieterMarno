<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="administradores.aspx.cs" Inherits="Decision.Admin.administradores" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="Devart.Data.MySql.Web, Version=8.8.862.0, Culture=neutral, PublicKeyToken=09af7300eec23701" Namespace="Devart.Data.MySql.Web" TagPrefix="cc1" %>

<asp:Content ID="cntConteudo" ContentPlaceHolderID="cphConteudo" runat="server">

    <div align="center">
        <br />
        <div class="TextoCinza20" align="left" style="width: 95%;">
            Cadastro de Administradores de Sistema
        </div>
        <br />
        <dx:ASPxGridView ID="grvAdministradores" runat="server" Theme="MetropolisBlue" AutoGenerateColumns="False"
            DataSourceID="dsAdministradores" EnableTheming="True" Width="95%" CssClass="Texto14" KeyFieldName="codigo"
            OnSearchPanelEditorCreate="grvAdministradores_SearchPanelEditorCreate"
            OnRowValidating="grvAdministradores_RowValidating" 
            OnCustomColumnDisplayText="grvAdministradores_CustomColumnDisplayText">
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
            <SettingsCookies CookiesID="Decision_Administradores" />
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
            <EditFormLayoutProperties ColCount="2">
                <Items>
                    <dx:GridViewColumnLayoutItem ColumnName="nome" CssClass="Texto16" ColSpan="2">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="usuario" CssClass="Texto16">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="senha" CssClass="Texto16">
                        <Template>
                            <dx:ASPxTextBox CssClass="CampoSemBordas" runat="server" Width="100%" ID="txtSenha" ClientInstanceName="txtSenha" Value='<%# Bind("senha") %>' OnDataBound="txtSenha_DataBound" />
                        </Template>
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="email" CssClass="Texto16" ColSpan="2">
                    </dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="telefone" CssClass="Texto16">
                    </dx:GridViewColumnLayoutItem>
                    <dx:EmptyLayoutItem>
                    </dx:EmptyLayoutItem>
                    <dx:EmptyLayoutItem ColSpan="2">
                    </dx:EmptyLayoutItem>
                    <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right" NestedControlCellStyle-CssClass="Texto14">
                        <NestedControlCellStyle CssClass="Texto14"></NestedControlCellStyle>
                    </dx:EditModeCommandLayoutItem>
                </Items>
            </EditFormLayoutProperties>
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="15%">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="codigo" ReadOnly="True" VisibleIndex="6" Visible="False">
                    <EditFormSettings Visible="False"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="nome" VisibleIndex="1" Caption="Nome" Width="25%">
                    <PropertiesTextEdit MaxLength="100" ConvertEmptyStringToNull="False">
                        <ValidationSettings ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                        </ValidationSettings>
                        <Style CssClass="CampoSemBordas">
                        </Style>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                    <CellStyle CssClass="Texto16">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="email" VisibleIndex="4" Caption="E-mail" Width="25%">
                    <PropertiesTextEdit MaxLength="100" ConvertEmptyStringToNull="False">
                        <ValidationSettings Display="Dynamic">
                        </ValidationSettings>
                        <Style CssClass="CampoSemBordas">
                        </Style>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                    <CellStyle CssClass="Texto16">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="telefone" VisibleIndex="5" Caption="Telefone" Width="20%">
                    <PropertiesTextEdit MaxLength="20">
                        <ValidationSettings ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="False" />
                        </ValidationSettings>
                        <Style CssClass="CampoSemBordas" />
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                    <CellStyle CssClass="Texto16">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="usuario" VisibleIndex="2" Caption="Usuário" Width="15%">
                    <PropertiesTextEdit MaxLength="20" ConvertEmptyStringToNull="False">
                        <ValidationSettings ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                        </ValidationSettings>
                        <Style CssClass="CampoSemBordas">
                        </Style>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                    <CellStyle CssClass="Texto16">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="senha" VisibleIndex="3" Visible="False" Caption="Senha">
                    <PropertiesTextEdit MaxLength="50" ConvertEmptyStringToNull="False">
                        <ValidationSettings ErrorDisplayMode="ImageWithText" Display="Dynamic">
                            <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                        </ValidationSettings>
                        <Style CssClass="CampoSemBordas">
                        </Style>
                    </PropertiesTextEdit>
                    <EditFormSettings Visible="True" />
                    <CellStyle CssClass="Texto16">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>

    </div>
    <cc1:MySqlDataSource runat="server" ID="dsAdministradores" OldValuesParameterFormatString="Original_{0}"
        OnInserting="dsAdministradores_Inserting" OnUpdating="dsAdministradores_Updating"
        ProviderName='<%$ ConnectionStrings:DevArt_Master.ProviderName %>'
        ConnectionString='<%$ ConnectionStrings:DevArt_Master %>' 
        SelectCommand="SELECT * FROM `administradores`"
        DeleteCommand="DELETE FROM master_data.administradores WHERE codigo = ?" 
        InsertCommand="INSERT INTO master_data.administradores (nome, email, telefone, usuario, senha) VALUES (?, ?, ?, ?, ?)" 
        UpdateCommand="UPDATE master_data.administradores SET nome = ?, email = ?, telefone = ?, usuario = ?, senha = ? WHERE codigo = ?">
        <UpdateParameters>
            <asp:Parameter Name="nome" Type="String" DefaultValue="" />
            <asp:Parameter Name="email" Type="String" DefaultValue="" />
            <asp:Parameter Name="telefone" Type="String" DefaultValue="" />
            <asp:Parameter Name="usuario" Type="String" DefaultValue="" />
            <asp:Parameter Name="senha" Type="String" DefaultValue="" />
            <asp:Parameter Name="codigo" Type="Int64" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="nome" Type="String" DefaultValue="" />
            <asp:Parameter Name="email" Type="String" DefaultValue="" />
            <asp:Parameter Name="telefone" Type="String" DefaultValue="" />
            <asp:Parameter Name="usuario" Type="String" DefaultValue="" />
            <asp:Parameter Name="senha" Type="String" DefaultValue="" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="codigo" Type="Int64" />
        </DeleteParameters>
    </cc1:MySqlDataSource>
</asp:Content>
