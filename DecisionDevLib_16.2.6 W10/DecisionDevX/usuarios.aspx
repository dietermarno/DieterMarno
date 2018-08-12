<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="Decision.usuarios" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntUsuarios" ContentPlaceHolderID="cplCentral" runat="server">
    <script type="text/javascript">

        var Security_Insert = "<% Response.Write(Security_Insert.ToString().ToLower()); %>";
        var Security_Update = "<% Response.Write(Security_Update.ToString().ToLower()); %>";
        var Security_Delete = "<% Response.Write(Security_Delete.ToString().ToLower()); %>";
        var CodigoUsuario = 0;

        function Inclusao(Codigo)
        {
            //*******************************************
            //* Possui permissão para a função inclusao?
            //*******************************************
            if (Security_Insert != "true")
            {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("INCLUSÃO");
                popSeguranca.Show();
            }
            else
            {
                //****************************
                //* Abre inclusão de registro
                //****************************
                location.href = "usuarios_edicao.aspx?Codigo=0";
            }
        }

        function Alteracao(Codigo)
        {
            //********************************************
            //* Possui permissão para a função alteração?
            //********************************************
            if (Security_Update != "true")
            {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("ALTERAÇÃO");
                popSeguranca.Show();
            }
            else
            {
                //*****************************
                //* Abre alteração de registro
                //*****************************
                location.href = "usuarios_edicao.aspx?Codigo=" + Codigo;
            }
        }

        function Exclusao(Codigo, Usuario)
        {
            //*******************************************
            //* Possui permissão para a função exclusão?
            //*******************************************
            if (Security_Delete != "true")
            {
                //**************
                //* Exibe popup
                //**************
                lblOperacao.SetText("EXCLUSÃO");
                popSeguranca.Show();
            }
            else
            {
                //*******************************************
                //* Abre confirmação de exclusão de registro
                //*******************************************
                CodigoUsuario = Codigo;
                lblUsuario.SetText(Usuario);
                popExclusao.Show();
            }
        }

        function ExecutaExclusao(s, e)
        {
            //*****************************
            //* Recupera código do usuário 
            //*****************************
            popExclusao.Hide();

            //*******************
            //* Executa exclusão
            //*******************
            location.href = "usuarios_exclusao.aspx?Codigo=" + CodigoUsuario;
        }

    </script>

    <dx:ASPxPopupControl ID="popSeguranca" runat="server" AllowDragging="True" AllowResize="True" ContentStyle-VerticalAlign="Middle"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" ContentStyle-HorizontalAlign="Center"
        PopupVerticalAlign="WindowCenter" Width="400px" Height="240px" HeaderText="Permissão de acesso" Theme="Moderno" CssClass="TextoCinza16"
        ClientInstanceName="popSeguranca" EnableHierarchyRecreation="True" Modal="true" HeaderStyle-HorizontalAlign="Center">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="TextoCinza16">
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
                <div class="TextoCinza16">
                    Você solicitou a exclusão do usuário  
                    <dx:ASPxLabel ID="lblUsuario" ClientInstanceName="lblUsuario" Theme="Moderno" runat="server" Text="" />
                    <br />
                    <br />
                    O vínculo eventual entre o promotor e o usuário será desfeito.
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
        Gerenciamento de Usuários
    </div>
    <br />
    <div align="center">
        <dx:ASPxGridView CssClass="TextoCinza16" ID="grvUsuarios" ClientInstanceName="grvUsuarios" KeyFieldName="codusuario" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarios" Theme="MetropolisBlue" EnableTheming="True" Width="95%" OnHtmlRowCreated="grvUsuarios_HtmlRowCreated" ShowClearFilterButton="true">
            <ClientSideEvents FocusedRowChanged ="function(s, e) { ObtemSelecao(s, e); }"></ClientSideEvents>
            <Columns>
                <dx:GridViewDataColumn VisibleIndex="0" Width="150px" MinWidth="150" FixedStyle="Left">
                    <HeaderStyle HorizontalAlign="Center">
                        <Border BorderStyle="None" />
                    </HeaderStyle>
                    <CellStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        <div style="text-align: center;">
                            <a onclick="Inclusao('0');" href="javascript:void(0);" style="text-decoration: none">
                                <span class="BotaoLinkW60F14" style="display: inline-block; margin-top: 5px;">Novo</span>
                            </a>
                        </div>
                    </HeaderTemplate>
                    <FilterTemplate>
                        <div style="text-align: center;">
                            Filtrar por:
                        </div>
                    </FilterTemplate>
                    <FilterCellStyle>
                        <Border BorderStyle="None" />
                    </FilterCellStyle>
                    <DataItemTemplate>
                        <a onclick="Alteracao('<%# Eval("codusuario") %>');" href="javascript:void(0);" style="text-decoration: none">
                            <span class="BotaoLinkW60F14">Alterar</span>
                        </a>
                        <a onclick="Exclusao('<%# Eval("codusuario") %>','<%# Eval("Usuario") %>');" href="javascript:void(0);" style="text-decoration: none;">
                            <span class="BotaoLinkW60F14">Excluir</span>
                        </a>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn FieldName="nome" VisibleIndex="1" Caption="Nome" Width="25%">
                    <CellStyle Wrap="False" />
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Usuario" VisibleIndex="2" Caption="Usu&#225;rio" Width="10%">
                    <CellStyle Wrap="False" />
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="telefone" VisibleIndex="3" Caption="Telefone" Width="10%">
                    <CellStyle Wrap="False" />
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="email_endereco" VisibleIndex="4" Caption="E-mail" Width="15%">
                    <CellStyle Wrap="False" />
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DescricaoGrupo" UnboundType="String" Width="10%" Caption="Grupo" VisibleIndex="5">
                    <CellStyle Wrap="False"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NomePosto" Width="20%" Caption="Raz&#227;o Social" VisibleIndex="6">
                    <CellStyle Wrap="False"></CellStyle>
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DescricaoPosto" VisibleIndex="7" Caption="Desc. Posto" Width="10%" UnboundType="String">
                    <CellStyle Wrap="False" />
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior EnableRowHotTrack="True" />
            <Settings ShowFilterRow="True" UseFixedTableLayout="True"></Settings>
            <SettingsCookies Enabled="True" CookiesID="Decision_Usuarios" />
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
    </div>
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
                       ORDER BY usuarios.nome">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsPostos" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT DISTINCT(descposto) AS descposto FROM posto WHERE posto.postoven<>0 ORDER BY posto.descposto">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsGrupos" runat="server" 
        ConnectionString='<%$ ConnectionStrings:DBTuris %>' 
        ProviderName='<%$ ConnectionStrings:DBTuris.ProviderName %>' 
        SelectCommand="SELECT DISTINCT(descgrupo) AS descgrupo FROM grupos WHERE grupos.codgrupo<>0 ORDER BY grupos.descgrupo">
    </asp:SqlDataSource>
</asp:Content>
