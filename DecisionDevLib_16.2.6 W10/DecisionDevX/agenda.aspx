<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="Decision.agenda" %>
<%@ Register assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxScheduler" tagprefix="dxwschs" %>
<%@ Register assembly="DevExpress.XtraScheduler.v16.2.Core, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraScheduler" tagprefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="cntAgenda" ContentPlaceHolderID="cplCentral" runat="server">
    <div align="left">
        <dxwschs:ASPxDateNavigator ID="dteNavegador" ClientInstanceName="dteNavegador" runat="server" Width="100%" 
            ClientIDMode="AutoID" MasterControlID="schAgenda">
            <Properties Columns="3">
            </Properties>
        </dxwschs:ASPxDateNavigator>
    </div>
    <dxwschs:ASPxScheduler ID="schAgenda" ClientInstanceName="schAgenda" runat="server" ClientIDMode="AutoID" EnableViewState="False"
        CssClass="TextoCinza16" AppointmentDataSourceID="dsAgenda" Start="2017-01-03" Storage-Appointments-ResourceSharing="true"
        Width="100%">
        <Styles>
            <PopupForm>
                <Header BackColor="#cccccc" ForeColor="#ffffff" />
            </PopupForm>
        </Styles>
        <Storage>
            <Appointments AutoRetrieveId="True">
                <Mappings
                    ResourceId="recursos"
                    Status="situacao"
                    Type="tipo"
                    Label="etiqueta"
                    Subject="assunto"
                    Description="descricao"
                    Location="local"
                    RecurrenceInfo="recorrencia"
                    ReminderInfo="despertador"
                    Start="inicio"
                    End="fim"
                    AllDay="dia_inteiro"
                    AppointmentId="codapontamento" />
                <CustomFieldMappings>
                    <dxwschs:ASPxAppointmentCustomFieldMapping Member="codpromotor" Name="IDPromotor" ValueType="Integer" />
                    <dxwschs:ASPxAppointmentCustomFieldMapping Member="codoportunidade" Name="IDOportunidade" ValueType="Integer" />
                    <dxwschs:ASPxAppointmentCustomFieldMapping Member="codorcamento" Name="IDOrcamento" ValueType="Integer" />
                    <dxwschs:ASPxAppointmentCustomFieldMapping Member="codcliente" Name="IDCliente" ValueType="Integer" />
                </CustomFieldMappings>
            </Appointments>
            <Resources>
                <Mappings ResourceId="codpromotor" Caption="nomepromotor" />
            </Resources>
        </Storage>
        <OptionsForms AppointmentFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/AppointmentForm.ascx" 
                      AppointmentInplaceEditorFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/InplaceEditor.ascx" 
                      GotoDateFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/GotoDateForm.ascx" 
                      RecurrentAppointmentDeleteFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentDeleteForm.ascx" 
                      RecurrentAppointmentEditFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/RecurrentAppointmentEditForm.ascx" 
                      RemindersFormTemplateUrl="~/DevExpress/ASPxSchedulerForms/ReminderForm.ascx" />
        <Views>
            <DayView ShowWorkTimeOnly="true">
                <Templates>
                    <VerticalAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((VerticalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>" Enabled="<%# SchedulerSubjectLinkEnabled(Container) %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </VerticalAppointmentTemplate>
                </Templates>
                <WorkTime Start="06:00" End="22:00" />
                <TimeRulers>
                    <cc1:TimeRuler />
                </TimeRulers>
            </DayView>
            <WorkWeekView>
                <Templates>
                    <VerticalAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((VerticalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </VerticalAppointmentTemplate>
                </Templates>
                <WorkTime Start="06:00" End="22:00" />
                <TimeRulers>
                    <cc1:TimeRuler />
                </TimeRulers>
            </WorkWeekView>
            <WeekView>
                <Templates>
                    <HorizontalAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </HorizontalAppointmentTemplate>
                    <HorizontalSameDayAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </HorizontalSameDayAppointmentTemplate>
                </Templates>
            </WeekView>
            <MonthView>
                <Templates>
                    <HorizontalAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </HorizontalAppointmentTemplate>
                    <HorizontalSameDayAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </HorizontalSameDayAppointmentTemplate>
                </Templates>
            </MonthView>
            <TimelineView>
                <Templates>
                    <HorizontalAppointmentTemplate>
                        <table style="width: 100%; height: 100%;">
                            <tr>
                                <td style="width: 1%; background-color: <%# HTMLColor(((HorizontalAppointmentTemplateContainer)Container).Items.AppointmentStyle.BackColor) %>;">&nbsp;
                                </td>
                                <td style="width: 99%;">
                                    <dx:ASPxHyperLink ID="lnkAssunto" runat="server" CssClass="LinkAgendaF14" Style="padding: 5px;"
                                        Text="<%# Container.AppointmentViewInfo.Appointment.Subject %>"
                                        NavigateUrl="<%# SchedulerSubjectLink(Container) %>">
                                    </dx:ASPxHyperLink>
                                </td>
                            </tr>
                        </table>
                    </HorizontalAppointmentTemplate>
                </Templates>
                <WorkTime Start="06:00" End="22:00" />
            </TimelineView>

            <FullWeekView>
                <TimeRulers>
                    <cc1:TimeRuler></cc1:TimeRuler>
                </TimeRulers>
            </FullWeekView>
        </Views>
        <OptionsCookies CookiesID="Decision_Agenda" Enabled="true" />
        <OptionsToolTips AppointmentDragToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentDragToolTip.ascx" AppointmentToolTipUrl="~/DevExpress/ASPxSchedulerForms/AppointmentToolTip.ascx" SelectionToolTipUrl="~/DevExpress/ASPxSchedulerForms/SelectionToolTip.ascx" />
    </dxwschs:ASPxScheduler>
    <asp:SqlDataSource ID="dsAgenda" runat="server"
        ProviderName="<%$ ConnectionStrings:DBTuris.ProviderName %>" 
        ConnectionString="<%$ ConnectionStrings:DBTuris %>" 
        SelectCommand="SELECT * FROM agenda_apontamentos" 
        InsertCommand="INSERT INTO agenda_apontamentos (codpromotor, recursos, situacao, tipo, etiqueta, assunto, descricao, local, recorrencia, despertador, inicio, fim, dia_inteiro) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)" 
        UpdateCommand="UPDATE agenda_apontamentos SET recursos = ?, situacao = ?, tipo = ?, etiqueta = ?, assunto = ?, descricao = ?, local = ?, recorrencia = ?, despertador = ?, inicio = ?, fim = ?, dia_inteiro = ? WHERE codapontamento = ?"
        DeleteCommand="DELETE FROM agenda_apontamentos WHERE codapontamento = ?">
        <DeleteParameters>
            <asp:Parameter Name="codapontamento" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="codpromotor" SessionField="Decision_Agenda_Promotor" Type="Int32" />
            <asp:Parameter Name="recursos" Type="string" />
            <asp:Parameter Name="situacao" Type="Int32" />
            <asp:Parameter Name="tipo" Type="Int32" />
            <asp:Parameter Name="etiqueta" Type="String" />
            <asp:Parameter Name="assunto" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="local" Type="String" />
            <asp:Parameter Name="recorrencia" Type="String" />
            <asp:Parameter Name="despertador" Type="String" />
            <asp:Parameter Name="inicio" Type="DateTime" />
            <asp:Parameter Name="fim" Type="DateTime" />
            <asp:Parameter Name="dia_inteiro" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="recursos" Type="string" />
            <asp:Parameter Name="situacao" Type="Int32" />
            <asp:Parameter Name="tipo" Type="Int32" />
            <asp:Parameter Name="etiqueta" Type="String" />
            <asp:Parameter Name="assunto" Type="String" />
            <asp:Parameter Name="descricao" Type="String" />
            <asp:Parameter Name="local" Type="String" />
            <asp:Parameter Name="recorrencia" Type="String" />
            <asp:Parameter Name="despertador" Type="String" />
            <asp:Parameter Name="inicio" Type="DateTime" />
            <asp:Parameter Name="fim" Type="DateTime" />
            <asp:Parameter Name="dia_inteiro" Type="Boolean" />
            <asp:Parameter Name="codapontamento" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
