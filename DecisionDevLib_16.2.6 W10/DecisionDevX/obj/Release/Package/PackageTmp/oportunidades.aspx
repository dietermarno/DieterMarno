<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="oportunidades.aspx.cs" Inherits="Decision.oportunidades" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="Devart.Data.MySql.Web, Version=8.8.862.0, Culture=neutral, PublicKeyToken=09af7300eec23701" Namespace="Devart.Data.MySql.Web" TagPrefix="cc1" %>

<asp:Content ID="cntOportunidades" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        var Security_Insert = "<% Response.Write(Security_Insert.ToString().ToLower()); %>";
        var Security_Update = "<% Response.Write(Security_Update.ToString().ToLower()); %>";
        var Security_Delete = "<% Response.Write(Security_Delete.ToString().ToLower()); %>";

        function Inclusao(Codigo) {
            //*******************************************
            //* Possui permissão para a função inclusao?
            //*******************************************
            if (Security_Insert != "true") {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("INCLUSÃO");
                popSeguranca.Show();
            }
            else {
                //****************************
                //* Abre inclusão de registro
                //****************************
                location.href = "oportunidades_edicao.aspx?Codigo=0&back=oportunidades.aspx";
            }
        }

        function Alteracao(Codigo) {
            //********************************************
            //* Possui permissão para a função alteração?
            //********************************************
            if (Security_Update != "true") {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("ALTERAÇÃO");
                popSeguranca.Show();
            }
            else {
                //*****************************
                //* Abre alteração de registro
                //*****************************
                location.href = "oportunidades_edicao.aspx?Codigo=" + Codigo + "&back=oportunidades.aspx";
            }
        }

        function Exclusao(Codigo) {
            //*******************************************
            //* Possui permissão para a função exclusão?
            //*******************************************
            if (Security_Delete != "true") {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("EXCLUSÃO");
                popSeguranca.Show();
            }
            else {
                //*******************************************
                //* Abre confirmação de exclusão de registro
                //*******************************************
                lblNumeroOportunidade.SetText(Codigo);
                popExclusao.Show();
            }
        }

        function ExecutaExclusao(s, e) {
            //**********************************
            //* Recupera código da oportunidade 
            //**********************************
            var Codigo = lblNumeroOportunidade.GetText();
            popExclusao.Hide();

            //*******************
            //* Executa exclusão
            //*******************
            location.href = "oportunidades_exclusao.aspx?Codigo=" + Codigo;
        }

        function GerarAcompanhamento(s, e) {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //**********************************
            //* Recupera código da oportunidade 
            //**********************************
            var DataI = dteDataInicial.GetValue();
            var DataF = dteDataFinal.GetValue();

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("Acompanhamento")) {
                //*******************
                //* Executa exclusão
                //*******************
                location.href = "oportunidades_acompanhamento.aspx?DI=" + DataI + "&DF=" + DataF;
            }
        }

        function ValidaFaixaDatas(s, e) {
            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            var startDateEdit = ASPxClientDateEdit.Cast(dteDataInicial);
            var startDate = startDateEdit.GetValue();

            var endDateEdit = ASPxClientDateEdit.Cast(dteDataFinal);
            var endDate = endDateEdit.GetValue();

            if (startDate > endDate) {
                //***********
                //* Notifica
                //***********
                e.isValid = false;
                e.errorText = "Data final inferior à inicial";
            }
        }

    </script>

    <dx:ASPxPopupControl ID="popSeguranca" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="400px" Height="240px" HeaderText="Permissão de acesso" Theme="Moderno" CssClass="TextoCinza16"
        ClientInstanceName="popSeguranca" EnableHierarchyRecreation="True" Modal="true" HeaderStyle-HorizontalAlign="Center">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div>
                    Você não possui permissão para a função  
                    <dx:ASPxLabel ID="lblOperacao" ClientInstanceName="lblOperacao" runat="server" Text="" />
                    <br />
                    <br />
                    Se precisa realizar esta operação, entre em contato com o administrador de sistema e solicie a liberação desta função.
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
    <dx:ASPxPopupControl ID="popExclusao" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="400px" Height="240px" HeaderText="Confirmação de Exclusão" Theme="Moderno" CssClass="TextoCinza16"
        ClientInstanceName="popExclusao" EnableHierarchyRecreation="True" Modal="true" HeaderStyle-HorizontalAlign="Center">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div>
                    Você solicitou a exclusão da oportunidade Nº 
                    <dx:ASPxLabel ID="lblNumeroOportunidade" ClientInstanceName="lblNumeroOportunidade" runat="server" Text="" />
                    <br />
                    <br />
                    A exclusão de um oportunidade implica na perda os orçamentos a ela vinculados.
                    <br />
                    <br />
                    Confirma a operação?
                    <br />
                    <br />
                    <br />
                    <div align="center" style="width: 100%;">
                        <dx:ASPxButton ID="cmdConfirmaExclusao" runat="server" Text="Confirmar" Width="100px">
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; ExecutaExclusao(s, e); }"></ClientSideEvents>
                        </dx:ASPxButton>
                        &nbsp;
                        <dx:ASPxButton ID="cmdCancelaExclusao" runat="server" Text="Cancelar" Width="100px">
                            <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popExclusao.Hide(); }"></ClientSideEvents>
                        </dx:ASPxButton>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <br />
    <div class="TextoCinza20" align="left" style="width: 95%;">
        Gerenciamento de Oportunidades
    </div>
    <br />

    <dx:ASPxGridView CssClass="TextoCinza16" ID="grvOportunidades" runat="server" Theme="MetropolisBlue" AutoGenerateColumns="False" EnableTheming="True" Width="95%" SettingsPager-PageSize="5" OnHtmlRowPrepared="grvOportunidades_HtmlRowPrepared" DataSourceID="dsOportunidades">
        <Columns>
            <dx:GridViewDataColumn VisibleIndex="0" MinWidth="450">
                <HeaderStyle HorizontalAlign="Center">
                </HeaderStyle>
                <CellStyle Wrap="False" HorizontalAlign="Center" />
                <HeaderTemplate>
                    <div style="text-align: center;">
                        <a onclick="Inclusao('0');" href="javascript:void(0);" style="text-decoration: none">
                            <span class="BotaoLinkW60F14">Novo</span>
                        </a>
                    </div>
                </HeaderTemplate>
                <FilterTemplate>
                    <div style="text-align: center;">
                        Filtrar por:
                    </div>
                </FilterTemplate>
                <DataItemTemplate>
                    <a onclick="Alteracao('<%# Eval("numero") %>');" href="javascript:void(0);" style="text-decoration: none">
                        <span class="BotaoLinkW60F14">Editar</span>
                    </a>
                    <a onclick="Exclusao('<%# Eval("numero") %>');" href="javascript:void(0);" style="text-decoration: none;">
                        <span class="BotaoLinkW60F14">Excluir</span>
                    </a>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataTextColumn FieldName="nomepromotor" VisibleIndex="1" Caption="Atendente">
                <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="data_operacao" VisibleIndex="2" Caption="Data">
                <PropertiesDateEdit DisplayFormatString="dd/MM/yy HH:mm"></PropertiesDateEdit>
                <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="situacao" VisibleIndex="3" Caption="Situa&#231;&#227;o">
                <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="contato_nome" VisibleIndex="4" Caption="Contato">
                <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="destino" VisibleIndex="5" Caption="Destino">
                <CellStyle Wrap="False" HorizontalAlign="Left"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="valor_estimado" VisibleIndex="6" Caption="Estimado">
                <PropertiesTextEdit DisplayFormatString="n2"></PropertiesTextEdit>
                <CellStyle Wrap="False" HorizontalAlign="Right"></CellStyle>
                <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="valor_fechado" VisibleIndex="7" Caption="Fechado">
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

    <dx:ASPxGridViewExporter ID="gveOportunidades" runat="server" GridViewID="grvOportunidades" />
    <br />
    <br />
    <asp:SqlDataSource ID="dsOportunidades" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT
                       promotor.nomepromotor,
                       oportunidade.nro_oportunidade AS numero,
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
