<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="permissoes.aspx.cs" Inherits="Decision.seguranca" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntSeguranca" ContentPlaceHolderID="cplCentral" runat="server">

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

    </script>
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%;">
        Gerenciamento de Grupos de Segurança
    </div>
    <br />
    <div align="center">
        <table style="width: 95%">
            <tr>
                <td align="left">
                    <span class="TextoCinza16"></span>
                    <br />
                    <dx:ASPxComboBox Caption="Grupo de permissões:" ItemStyle-Font-Size="16px" CaptionCellStyle-CssClass="TextoCinza16" CssClass="TextoCinza16" ID="cboGrupo" ClientInstanceName="cboGrupo" runat="server" ValueType="System.Int32" DataSourceID="dsGrupo" TextField="descgrupo" ValueField="codgrupo" Theme="MetropolisBlue" OnValueChanged="cboGrupo_ValueChanged" AutoPostBack="true" Width="200px">
                        <ClientSideEvents Init="function(s, e) { InicializaGrupo(s, e); }"></ClientSideEvents>
                    </dx:ASPxComboBox>
                    <br />
                </td>
            </tr>
        </table>
        <dx:ASPxGridView CssClass="TextoCinza16" ID="grvSeguranca" runat="server" AutoGenerateColumns="False" ClientInstanceName="grvSeguranca" DataSourceID="dsSeguranca" EnableTheming="True" KeyFieldName="codagrupamento" Theme="MetropolisBlue" Width="95%" OnRowValidating="grvSeguranca_RowValidating" OnCellEditorInitialize="grvSeguranca_CellEditorInitialize" OnRowInserting="grvSeguranca_RowInserting">
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="15%" ShowNewButtonInHeader="True" ButtonType="Button" ShowClearFilterButton="true">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataComboBoxColumn Caption="Permissão" FieldName="codpermissao" VisibleIndex="1" Width="45%" UnboundType="Integer" Name="colPermissao">
                    <PropertiesComboBox DataSourceID="dsPermissao" TextField="descricaopermissao" ValueField="codpermissao" ValueType="System.Int32" DropDownStyle="DropDownList">
                        <ValidationSettings ErrorDisplayMode="ImageWithText" Display="Dynamic" ErrorTextPosition="Bottom">
                            <RequiredField IsRequired="True" ErrorText="Por favor, selecione a permiss&#227;o"></RequiredField>
                        </ValidationSettings>
                    </PropertiesComboBox>
                    <Settings AutoFilterCondition="Contains" AllowHeaderFilter="True" />
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataCheckColumn Caption="Acesso" FieldName="acesso" VisibleIndex="2" Width="10%" Name="colAcesso">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Inclusão" FieldName="inclusao" VisibleIndex="3" Width="10%" Name="colInclusao">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Alteração" FieldName="alteracao" VisibleIndex="4" Width="10%" Name="colAlteracao">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataCheckColumn Caption="Exclusão" FieldName="exclusao" VisibleIndex="5" Width="10%" Name="colExclusao">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataCheckColumn>
                <dx:GridViewDataTextColumn Caption="Codigo Grupo" FieldName="codgrupo" Visible="False" VisibleIndex="6" Name="colCodigoGrupo">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Codigo Permissao" FieldName="codpermissao" Visible="False" VisibleIndex="7" Name="colCodigoPermissao">
                </dx:GridViewDataTextColumn>
            </Columns>
            <Settings ShowFilterRow="True" UseFixedTableLayout="True" />
            <SettingsEditing Mode="Inline" />
            <SettingsBehavior EnableRowHotTrack="True" />
            <SettingsCookies Enabled="True" CookiesID="Decision_Seguranca" />
            <Styles>
                <CommandColumn Spacing="3px" />
                <CommandColumnItem CssClass="BotaoLinkW60F14" />
                <Header Font-Bold="False" />
                <RowHotTrack BackColor="#A5C5FA" />
                <Cell>
                    <BorderLeft BorderStyle="None" />
                    <BorderRight BorderStyle="None" />
                </Cell>
            </Styles>
            <BorderLeft BorderStyle="None" />
            <BorderRight BorderStyle="None" />
        </dx:ASPxGridView>
    </div>
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%;">
        <dx:ASPxLabel ID="lblNomeGrupo" CssClass="TextoCinza16" runat="server" />
    </div>
    <br />
    <dx:ASPxGridView CssClass="TextoCinza16" ID="grvUsuarios" ClientInstanceName="grvUsuarios" KeyFieldName="codusuario" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarios" Theme="MetropolisBlue" EnableTheming="True" Width="95%" ShowClearFilterButton="true">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="nome" VisibleIndex="1" Caption="Nome" Width="25%">
                <CellStyle Wrap="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Usuario" VisibleIndex="2" Caption="Usu&#225;rio" Width="10%">
                <CellStyle Wrap="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="telefone" VisibleIndex="3" Caption="Telefone" Width="10%">
                <CellStyle Wrap="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="email_endereco" VisibleIndex="4" Caption="E-mail" Width="15%">
                <CellStyle Wrap="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DescricaoGrupo" UnboundType="String" Width="10%" Caption="Grupo" VisibleIndex="5">
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NomePosto" Width="20%" Caption="Raz&#227;o Social" VisibleIndex="6">
                <CellStyle Wrap="False"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DescricaoPosto" VisibleIndex="7" Caption="Desc. Posto" Width="10%" UnboundType="String">
                <CellStyle Wrap="False" />
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior EnableRowHotTrack="True" />
        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
        <Styles>
            <Header Font-Bold="False" CssClass="TextoCinza16">
            </Header>
            <RowHotTrack BackColor="#A5C5FA">
            </RowHotTrack>
            <Cell>
                <BorderLeft BorderStyle="None" />
                <BorderRight BorderStyle="None" />
            </Cell>
        </Styles>
        <BorderLeft BorderStyle="None" />
        <BorderRight BorderStyle="None" />
    </dx:ASPxGridView>
    <br />
    <asp:SqlDataSource runat="server" ID="dsSeguranca" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT 
                       grupos.codgrupo,
                       grupos.descgrupo,
                       permissoes_opcoes.codpermissao,
                       permissoes_opcoes.descricaopermissao,
                       permissoes_grupos.codagrupamento,
                       permissoes_grupos.acesso,
                       permissoes_grupos.inclusao,
                       permissoes_grupos.alteracao,
                       permissoes_grupos.exclusao
                       FROM permissoes_grupos
                       LEFT JOIN permissoes_opcoes ON permissoes_opcoes.codpermissao = permissoes_grupos.codpermissao
                       LEFT JOIN grupos ON grupos.codgrupo = permissoes_grupos.codgrupo
                       WHERE grupos.codgrupo = ? ORDER BY posicao" 
        UpdateCommand="UPDATE permissoes_grupos SET 
                       acesso = ?, inclusao = ?, alteracao = ?, exclusao = ?, codpermissao = ? 
                       WHERE codagrupamento= ?"
        DeleteCommand="DELETE FROM permissoes_grupos WHERE codagrupamento = ?" 
        InsertCommand="INSERT INTO permissoes_grupos 
                       (acesso, inclusao, alteracao, exclusao, codpermissao, codgrupo) VALUES (?, ?, ?, ?, ?, ?)">
        <SelectParameters>
            <asp:SessionParameter Type="Int32" Name="codgrupo" DefaultValue="0" SessionField="Decision_Permissoes_CodGrupo" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Type="Boolean" Name="acesso" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="inclusao" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="alteracao" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="exclusao" DefaultValue="false" />
            <asp:Parameter Type="Int32" Name="codpermissao" DefaultValue="0" />
            <asp:SessionParameter Type="Int32" Name="codgrupo" SessionField="Decision_Permissoes_CodGrupo" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Type="Boolean" Name="acesso" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="inclusao" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="alteracao" DefaultValue="false" />
            <asp:Parameter Type="Boolean" Name="exclusao" DefaultValue="false" />
            <asp:Parameter Type="Int32" Name="codpermissao" DefaultValue="0" />
            <asp:Parameter Type="Int32" Name="codagrupamento" DefaultValue="0" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Type="Int32" Name="codagrupamento" DefaultValue="0" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPermissao" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT codpermissao, descricaopermissao FROM permissoes_opcoes ORDER BY posicao">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsGrupo" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT codgrupo, descgrupo FROM grupos ORDER BY descgrupo">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsUsuarios" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBTuris %>" 
        ProviderName="<%$ ConnectionStrings:DBTuris.ProviderName %>" 
        SelectCommand="SELECT usuarios.*,
                       posto.postoven AS CodigoPosto,
                       posto.DescPosto AS DescricaoPosto,
                       posto.NomePosto AS NomePosto,
                       grupos.DescGrupo AS DescricaoGrupo
                       FROM usuarios
                       LEFT JOIN grupos ON grupos.CodGrupo = usuarios.CodGrupo 
                       LEFT JOIN posto ON posto.PostoVen = usuarios.CodPosto
                       WHERE usuarios.codgrupo = ?  
                       ORDER BY usuarios.nome">
        <SelectParameters>
            <asp:SessionParameter Type="Int32" Name="codgrupo" DefaultValue="0" SessionField="Decision_Permissoes_CodGrupo" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
