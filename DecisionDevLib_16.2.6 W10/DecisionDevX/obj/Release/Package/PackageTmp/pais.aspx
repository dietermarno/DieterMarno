<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="pais.aspx.cs" Inherits="Decision.pais" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register TagPrefix="cc1" Namespace="Devart.Data.MySql.Web" Assembly="Devart.Data.MySql.Web, Version=8.8.862.0, Culture=neutral, PublicKeyToken=09af7300eec23701" %>

<asp:Content ID="cntPais" ContentPlaceHolderID="cplCentral" runat="server">
    <dx:ASPxGridView ID="grvPais" runat="server" AutoGenerateColumns="False" DataSourceID="dsPais" KeyFieldName="CodPais" Theme="MetropolisBlue" EnableTheming="True">

        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="DescPais" ColSpan="2"></dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right"></dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowDeleteButton="True"></dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CodPais" ReadOnly="True" VisibleIndex="1" Visible="False"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DescPais" VisibleIndex="2"></dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <cc1:MySqlDataSource runat="server" OldValuesParameterFormatString="Original_{0}" ID="dsPais" 
        ProviderName='<%$ ConnectionStrings:Devart_Master.ProviderName %>' 
        SelectCommand="pais_select" UpdateCommand="pais_update" InsertCommand="pais_insert" 
        ConnectionString='<%$ ConnectionStrings:Devart_Master %>' OnUpdating="dsPais_Updating"
        InsertCommandType="StoredProcedure" SelectCommandType="StoredProcedure" UpdateCommandType="StoredProcedure">
        <UpdateParameters>
            <asp:Parameter Name="codpais" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="descpais" Type="String"></asp:Parameter>
            <asp:Parameter Name="Original_codpais" Type="Int32"></asp:Parameter>
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="descpais" Type="String"></asp:Parameter>
        </InsertParameters>
    </cc1:MySqlDataSource>
</asp:Content>
