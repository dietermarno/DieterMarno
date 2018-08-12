<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="abertura.aspx.cs" Inherits="Decision._default" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.XtraCharts.v16.2.Web, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<asp:Content ID="cntDefault" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        var SemPermissoes = "<% Response.Write(SemPermissoes.ToString().ToLower()); %>";

        function ExibePopup(s, e)
        {
            //*******************
            //* Deve exibe popup
            //*******************
            if (SemPermissoes != "false")
                popSeguranca.Show();
        }

    </script>

    <dx:ASPxPopupControl ID="popSeguranca" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="400px" Height="240px" HeaderText="Permissão de acesso" Theme="Moderno" CssClass="TextoCinza16"
        ClientInstanceName="popSeguranca" EnableHierarchyRecreation="True" Modal="true" HeaderStyle-HorizontalAlign="Center">
        <ClientSideEvents Init="function(s, e) { ExibePopup(s, e); }"></ClientSideEvents>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div>
                    Você ainda não possui configuração de permissões para acessar as funções do sistema.
                    <br />
                    <br />
                    Entre em contato o administrador de sistema para solicitar a liberação das funções necessárias
                    <dx:ASPxHyperLink ID="lnkAdmin" ClientInstanceName="lnkAdmin" Theme="Moderno" runat="server" Text=" clicando aqui" Visible="false" />.
                    <br />
                    <br />
                    <div align="center" style="width: 100%;">
                        <dx:ASPxButton ID="cmdFechar" runat="server" Text="Fechar" Width="100px" >
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popSeguranca.Hide(); }"></ClientSideEvents>
                        </dx:ASPxButton>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <br />
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%" id="divGrafico" runat="server">
        <table style="width: 100%; background-color: #f0f0f0;">
            <tr>
                <td style="width: 80%; vertical-align: middle; padding-top: 15px; padding-bottom: 15px; padding-left: 15px; text-align: left;">
                    Evolução de Oportunidades
                </td>
                <td style="width: 10%; vertical-align: bottom; padding-top: 15px; padding-bottom: 15px;">
                    <div align="right">
                        &nbsp;
                    </div>
                </td>
                <td style="width: 10%; padding-left: 10px; padding-top: 15px; padding-bottom: 15px; vertical-align: bottom;">
                        &nbsp;
                </td>
            </tr>
        </table>
        <dxchartsui:WebChartControl ID="wccTodos" runat="server" CrosshairEnabled="True" DataSourceID="dsOportunidadeTotal" Height="350px" Width="650px">
            <DiagramSerializable>
                <cc1:XYDiagram3D PerspectiveAngle="0" PlaneDepthFixed="10" RotationMatrixSerializable="0.766044443118978;-0.219846310392954;0.604022773555054;0;0;0.939692620785908;0.342020143325669;0;-0.642787609686539;-0.262002630229385;0.719846310392954;0;0;0;0;1" ZoomPercent="120">
                </cc1:XYDiagram3D>
            </DiagramSerializable>
            <Legend Name="Default Legend"></Legend>
            <SeriesSerializable>
                <cc1:Series ArgumentDataMember="nomepromotor" ArgumentScaleType="Qualitative" Name="Qualificação" DataFiltersConjunctionMode="Or" SummaryFunction="COUNT()">
                    <DataFilters>
                        <cc1:DataFilter ColumnName="cod_situacao" DataType="System.Int16" InvariantValueSerializable="2" />
                        <cc1:DataFilter ColumnName="cod_situacao" DataType="System.Int16" InvariantValueSerializable="1" />
                    </DataFilters>
                    <ViewSerializable>
                        <cc1:SideBySideBar3DSeriesView Color="79, 129, 189">
                        </cc1:SideBySideBar3DSeriesView>
                    </ViewSerializable>
                </cc1:Series>
                <cc1:Series ArgumentDataMember="nomepromotor" ArgumentScaleType="Qualitative" Name="Ganhou" SummaryFunction="COUNT()">
                    <DataFilters>
                        <cc1:DataFilter ColumnName="cod_situacao" DataType="System.Int16" InvariantValueSerializable="3" />
                    </DataFilters>
                    <ViewSerializable>
                        <cc1:SideBySideBar3DSeriesView Color="155, 187, 89">
                        </cc1:SideBySideBar3DSeriesView>
                    </ViewSerializable>
                </cc1:Series>
                <cc1:Series ArgumentDataMember="nomepromotor" ArgumentScaleType="Qualitative" Name="Perdeu" DataFiltersConjunctionMode="Or" SummaryFunction="COUNT()">
                    <DataFilters>
                        <cc1:DataFilter ColumnName="cod_situacao" DataType="System.Int16" InvariantValueSerializable="4" />
                    </DataFilters>
                    <ViewSerializable>
                        <cc1:SideBySideBar3DSeriesView Color="150, 0, 1">
                        </cc1:SideBySideBar3DSeriesView>
                    </ViewSerializable>
                </cc1:Series>
            </SeriesSerializable>
            <SeriesTemplate>
                <ViewSerializable>
                    <cc1:SideBySideBar3DSeriesView>
                    </cc1:SideBySideBar3DSeriesView>
                </ViewSerializable>
            </SeriesTemplate>
        </dxchartsui:WebChartControl>
        <dxchartsui:WebChartControl ID="wccUsuario" runat="server" CrosshairEnabled="True" DataSourceID="dsOportunidadeUsuario" Height="200px" Width="650px">
            <DiagramSerializable>
                <cc1:SimpleDiagram3D RotationMatrixSerializable="1;0;0;0;0;0.5;-0.866025403784439;0;0;0.866025403784439;0.5;0;0;0;0;1" ZoomPercent="120">
                </cc1:SimpleDiagram3D>
            </DiagramSerializable>
            <Legend Name="Default Legend"></Legend>
            <SeriesSerializable>
                <cc1:Series ArgumentDataMember="descricao" ArgumentScaleType="Qualitative" LegendText="xxx" LegendTextPattern="{A} ({V})" Name="Situação" SummaryFunction="COUNT()">
                    <ViewSerializable>
                        <cc1:Doughnut3DSeriesView SizeAsPercentage="100" SweepDirection="Counterclockwise">
                        </cc1:Doughnut3DSeriesView>
                    </ViewSerializable>
                </cc1:Series>
            </SeriesSerializable>
            <SeriesTemplate ArgumentDataMember="descricao" ArgumentScaleType="Qualitative" SummaryFunction="COUNT()" ColorDataMember="cod_situacao">
                <ViewSerializable>
                    <cc1:Doughnut3DSeriesView SizeAsPercentage="100" SweepDirection="Counterclockwise">
                    </cc1:Doughnut3DSeriesView>
                </ViewSerializable>
            </SeriesTemplate>
        </dxchartsui:WebChartControl>
    </div>
    <br />
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%" id="divAgenda" runat="server">
        <table style="width: 100%; background-color: #f0f0f0;">
            <tr>
                <td style="width: 80%; vertical-align: middle; padding-top: 15px; padding-bottom: 15px; padding-left: 15px; text-align: left;">
                    Compromissos agendados
                </td>
                <td style="width: 10%; vertical-align: bottom; padding-top: 15px; padding-bottom: 15px;">
                    <div align="right">
                        <dx:ASPxComboBox Caption="Formato de exportação:" ID="cboExportacaoAgenda" runat="server" ValueType="System.String" Width="250px" ShowImageInEditBox="True" CssClass="TextoCinza14" ItemStyle-Font-Size="14px" CaptionCellStyle-CssClass="TextoCinza14" CaptionSettings-Position="Top">
                            <Items>
                                <dx:ListEditItem ImageUrl="Images/pdf.png" Text="Adobe Acrobat (PDF)" Value="PDF" Selected="true" />
                                <dx:ListEditItem ImageUrl="Images/xls.png" Text="Microsoft Excel (XLS)" Value="XLS" />
                                <dx:ListEditItem ImageUrl="Images/xlsx.png" Text="Microsoft Excel (XLSX)" Value="XLSX" />
                                <dx:ListEditItem ImageUrl="Images/rtf.png" Text="Microsoft Word (RTF)" Value="RTF" />
                                <dx:ListEditItem ImageUrl="Images/csv.png" Text="Delimitado por vírgula (CSV)" Value="CSV" />
                            </Items>
                        </dx:ASPxComboBox>
                    </div>
                </td>
                <td style="width: 10%; padding-left: 10px; padding-top: 15px; padding-bottom: 15px; vertical-align: bottom;">
                    <dx:ASPxButton ID="cmdExportacaoAgenda" runat="server" Text="Exportar" Width="100px" Height="30px" OnClick="cmdExportacaoAgenda_Click" />
                </td>
            </tr>
        </table>
        <dx:ASPxGridView CssClass="TextoCinza16" ID="grvAgenda" runat="server" DataSourceID="dsAgenda" AutoGenerateColumns="False" Theme="MetropolisBlue" EnableTheming="True" Width="100%" SettingsPager-PageSize="5">
            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" HideDataCellsAtWindowInnerWidth="1024" />
            <Columns>
                <dx:GridViewDataColumn VisibleIndex="0" Width="100px" MinWidth="100" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center">
                    </HeaderStyle>
                    <CellStyle HorizontalAlign="Center" />
                    <FilterTemplate>
                        <div style="text-align: center;">
                            Filtrar por:
                        </div>
                    </FilterTemplate>
                    <DataItemTemplate>
                        <%# OpportunityLink(Eval("codoportunidade")) %>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Width="150px" Caption="Atendente" VisibleIndex="1" FieldName="promotor">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Width="70px" Caption="Data" VisibleIndex="2" FieldName="inicio">
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yy HH:mm"></PropertiesDateEdit>
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Width="150px" Caption="Local" VisibleIndex="3" FieldName="local">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="100px" Caption="Situa&#231;&#227;o" VisibleIndex="4" FieldName="situacao">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="150px" Caption="Estágio" VisibleIndex="5" FieldName="estagio">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="150px" Caption="Origem" VisibleIndex="6" FieldName="etiqueta">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Assunto" FieldName="assunto" VisibleIndex="7" >
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Contato" FieldName="contato" VisibleIndex="8" AdaptivePriority="1">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager PageSize="5" />
            <SettingsBehavior EnableRowHotTrack="True" />
            <Settings ShowFilterRow="True" />
            <SettingsCookies Enabled="True" CookiesID="Decision_Agenda"/>
            <Styles>
                <Header Font-Bold="False">
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
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            </SettingsCommandButton>
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False" />
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="gveAgenda" runat="server" GridViewID="grvAgenda" PaperKind="A4" Landscape="true" ReportHeader="{\rtf1\ansi\ansicpg1252\deff0\deflang1046{\fonttbl{\f0\fnil\fcharset0 Tahoma;}{\f1\fnil\fcharset0 Times New Roman;}}
\viewkind4\uc1\pard\f0\fs32 Compromissos agendados\fs20\par
Exporta\'e7\'e3o r\'e1pida de registros\par
\par
\par
\f1\par
}
">
            <PageHeader>
                <Font Size="16px" />
            </PageHeader>
            <PageFooter>
                <Font Size="16px" />
            </PageFooter>
        </dx:ASPxGridViewExporter>
    </div>
    <br />
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%" id="divOportunidades" runat="server">
        <table style="width: 100%; background-color: #f0f0f0;">
            <tr>
                <td style="width: 80%; vertical-align: middle; padding-top: 15px; padding-bottom: 15px; padding-left: 15px; text-align: left;">
                    Oportunidades recentes
                </td>
                <td style="width: 10%; vertical-align: bottom; padding-top: 15px; padding-bottom: 15px;">
                    <div align="right">
                        <dx:ASPxComboBox Caption="Formato de exportação:" ID="cboExportacaoOportunidades" runat="server" ValueType="System.String" Width="250px" ShowImageInEditBox="True" CssClass="TextoCinza14" ItemStyle-Font-Size="14px" CaptionCellStyle-CssClass="TextoCinza14" CaptionSettings-Position="Top">
                            <Items>
                                <dx:ListEditItem ImageUrl="Images/pdf.png" Text="Adobe Acrobat (PDF)" Value="PDF" Selected="true" />
                                <dx:ListEditItem ImageUrl="Images/xls.png" Text="Microsoft Excel (XLS)" Value="XLS" />
                                <dx:ListEditItem ImageUrl="Images/xlsx.png" Text="Microsoft Excel (XLSX)" Value="XLSX" />
                                <dx:ListEditItem ImageUrl="Images/rtf.png" Text="Microsoft Word (RTF)" Value="RTF" />
                                <dx:ListEditItem ImageUrl="Images/csv.png" Text="Delimitado por vírgula (CSV)" Value="CSV" />
                            </Items>
                        </dx:ASPxComboBox>
                    </div>
                </td>
                <td style="width: 10%; padding-left: 10px; padding-top: 15px; padding-bottom: 15px; vertical-align: bottom;">
                    <dx:ASPxButton ID="cmdExportacaoOportunidades" runat="server" Text="Exportar" Width="100px" Height="30px" OnClick="cmdExportacaoOportunidades_Click" />
                </td>
            </tr>
        </table>
        <dx:ASPxGridView CssClass="TextoCinza16" ID="grvOportunidades" runat="server" Theme="MetropolisBlue" AutoGenerateColumns="False" EnableTheming="True" Width="100%" DataSourceID="dsOportunidades" SettingsPager-PageSize="5" OnHtmlRowPrepared="grvOportunidades_HtmlRowPrepared">
            <SettingsAdaptivity AdaptivityMode="HideDataCells" AllowOnlyOneAdaptiveDetailExpanded="true" HideDataCellsAtWindowInnerWidth="1024" />
            <Columns>
                <dx:GridViewDataColumn VisibleIndex="0" Width="100px" MinWidth="100" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center">
                    </HeaderStyle>
                    <CellStyle HorizontalAlign="Center" />
                    <FilterTemplate>
                        <div style="text-align: center;">
                            Filtrar por:
                        </div>
                    </FilterTemplate>
                    <DataItemTemplate>
                        <%# OpportunityLink(Eval("codoportunidade")) %>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Width="150px" FieldName="nomepromotor" VisibleIndex="1" Caption="Atendente">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Width="70px" FieldName="data_operacao" VisibleIndex="2" Caption="Data">
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yy HH:mm"></PropertiesDateEdit>
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn Width="80px" FieldName="situacao" VisibleIndex="3" Caption="Situa&#231;&#227;o">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="150px" FieldName="contato_nome" VisibleIndex="4" Caption="Contato" AdaptivePriority="1">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="150px" FieldName="destino" VisibleIndex="5" Caption="Destino" AdaptivePriority="1">
                    <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="100px" FieldName="valor_estimado" VisibleIndex="6" Caption="Estimado" AdaptivePriority="2">
                    <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                    <CellStyle Wrap="False" HorizontalAlign="Right"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Width="100px" FieldName="valor_fechado" VisibleIndex="7" Caption="Fechado" AdaptivePriority="2">
                    <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                    <CellStyle Wrap="False" HorizontalAlign="Right"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsPager PageSize="5" />
            <SettingsBehavior EnableRowHotTrack="True" />
            <Settings ShowFilterRow="True" />
            <SettingsCookies Enabled="True" CookiesID="Decision_Abertura_Oportunidades" />
            <Styles>
                <Header Font-Bold="False">
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
            <SettingsCommandButton>
                <ShowAdaptiveDetailButton ButtonType="Image"></ShowAdaptiveDetailButton>
                <HideAdaptiveDetailButton ButtonType="Image"></HideAdaptiveDetailButton>
            </SettingsCommandButton>
            <SettingsDataSecurity AllowEdit="False" AllowDelete="False" AllowInsert="False"></SettingsDataSecurity>
        </dx:ASPxGridView>
        <dx:ASPxGridViewExporter ID="gveOportunidades" runat="server" GridViewID="grvOportunidades" PaperKind="A4" ReportHeader="{\rtf1\ansi\ansicpg1252\deff0\deflang1046{\fonttbl{\f0\fnil\fcharset0 Tahoma;}{\f1\fnil\fcharset0 Times New Roman;}}
\viewkind4\uc1\pard\f0\fs32 Oportunidades Recentes\fs20\par
Exporta\'e7\'e3o r\'e1pida de registros\par
\par
\par
\f1\par
}
">
            <PageHeader>
                <Font Size="16px" />
            </PageHeader>
            <PageFooter>
                <Font Size="16px" />
            </PageFooter>
        </dx:ASPxGridViewExporter>
    </div>
    <br />
    <br />

    <!-- *** Atualiza o tamanho do container *** -->
    <script type="text/javascript">
        // <![CDATA[
        ASPxClientControl.GetControlCollection().ControlsInitialized.AddHandler(function (s, e) {
            AtualizaTamanhoDIV();
        });
        ASPxClientControl.GetControlCollection().BrowserWindowResized.AddHandler(function (s, e) {
            AtualizaTamanhoDIV();
        });
        // ]]> 
    </script>

    <asp:SqlDataSource ID="dsOportunidadeTotal" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBTuris %>" 
        ProviderName="<%$ ConnectionStrings:DBTuris.ProviderName %>" 
        SelectCommand="SELECT 
                       promotor.nomepromotor,
                       oportunidade.cod_situacao
                       FROM oportunidade
                       LEFT JOIN promotor ON promotor.codpromotor = oportunidade.cod_promotor
                       ORDER BY promotor.nomepromotor">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsOportunidadeUsuario" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBTuris %>" 
        ProviderName="<%$ ConnectionStrings:DBTuris.ProviderName %>" 
        SelectCommand="SELECT 
                       oportunidade_situacao.descricao,
                       oportunidade.cod_situacao
                       FROM oportunidade
                       LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao
                       ORDER BY oportunidade_situacao.descricao, oportunidade.proximo_contato DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsAgenda" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT
                       agenda_apontamentos.codoportunidade,
                       IF(NOT ISNULL(promotor.nomepromotor),promotor.nomepromotor,'-') AS `promotor`,
                       agenda_apontamentos.inicio,
                       IF(NOT ISNULL(oportunidade.destino), oportunidade.destino, agenda_apontamentos.`local`) AS `local`,
                       IF(NOT ISNULL(oportunidade_situacao.descricao), oportunidade_situacao.descricao, agenda_status.descricao) AS `situacao`,
                       IF(NOT ISNULL(oportunidade_estagio.descricao), oportunidade_estagio.descricao, '-') AS estagio,
                       agenda_etiqueta.descricao AS `etiqueta`,
                       agenda_apontamentos.assunto, 
                       oportunidade.contato_nome AS `contato`
                       FROM agenda_apontamentos
                       LEFT JOIN promotor ON promotor.codpromotor = agenda_apontamentos.codpromotor
                       LEFT JOIN oportunidade ON oportunidade.nro_oportunidade = agenda_apontamentos.codoportunidade  
                       LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao  
                       LEFT JOIN oportunidade_orcamentos ON oportunidade_orcamentos.cod_orcamento = agenda_apontamentos.codorcamento
                       LEFT JOIN oportunidade_estagio ON oportunidade_estagio.codigo = oportunidade_orcamentos.estagio_orcamento
                       LEFT JOIN agenda_etiqueta ON agenda_etiqueta.codetiqueta = agenda_apontamentos.etiqueta
                       LEFT JOIN agenda_status ON agenda_status.codstatus = agenda_apontamentos.situacao
                       ORDER BY agenda_apontamentos.inicio DESC">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsOportunidades" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT
                       promotor.nomepromotor,
                       oportunidade.data_operacao,
                       oportunidade_situacao.descricao AS 'situacao',
                       oportunidade.contato_nome,
                       oportunidade.destino,
                       oportunidade.valor_estimado,  
                       oportunidade.valor_fechado 
                       FROM oportunidade
                       LEFT JOIN promotor ON promotor.codpromotor = oportunidade.cod_promotor
                       LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao
                       ORDER BY oportunidade_situacao.descricao, oportunidade.proximo_contato DESC">
    </asp:SqlDataSource>
</asp:Content>
