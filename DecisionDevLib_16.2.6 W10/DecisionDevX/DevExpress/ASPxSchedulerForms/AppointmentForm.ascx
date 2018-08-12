<%@ Control Language="C#" AutoEventWireup="true" Inherits="AppointmentForm" Codebehind="AppointmentForm.ascx.cs" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>

<div runat="server" id="ValidationContainer">
    <table style="width: 100%; height: 450px;">
    <tr>
        <td colspan="2">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%;" class="TituloCampo">
                        <dx:ASPxLabel ID="lblSubject" runat="server" AssociatedControlID="tbSubject" Width="100%" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 80%;" class="CampoSemBordas">
                        <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Subject %>' CssClass="CamposSemBordaInferior" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr> 
        <td style="width: 50%; padding-right: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 40%;" class="TituloCampo">
                        <dx:ASPxLabel ID="lblLocation" runat="server" AssociatedControlID="tbLocation" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 60%;" class="CampoSemBordas">
                        <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.Location %>' CssClass="CamposSemBordaInferior" />
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 50%; padding-left: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 40%;" class="TituloCampo">
                        <dx:ASPxLabel ID="lblLabel" runat="server" AssociatedControlID="edtLabel" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 60%;" class="CampoSemBordas">
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).LabelDataSource %>' CssClass="CamposSemBordaInferior" ItemStyle-Font-Size="14px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="width: 50%; padding-right: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 40%;" class="TituloCampo">
                        <dx:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Wrap="false" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td style="width: 40%; text-align:left;" class="CampoSemBordas">
                        <dx:ASPxDateEdit ID="edtStartDate" runat="server" Width="100%" Date='<%# ((AppointmentFormTemplateContainer)Container).Start %>' EditFormat="Date" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" CssClass="CamposSemBordaInferior">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 20%;" class="CampoSemBordas" ID="edtStartTimeLayoutRoot">
                        <dx:ASPxTimeEdit ID="edtStartTime" runat="server" Width="100%" DateTime='<%# ((AppointmentFormTemplateContainer)Container).Start %>' DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" CssClass="CamposSemBordaInferior">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxTimeEdit>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 50%; padding-left: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 40%;" class="TituloCampo">
                        <dx:ASPxLabel runat="server" ID="lblEndDate" Wrap="false" AssociatedControlID="edtEndDate" CssClass="TextoCinza16" />
                    </td>
                    <td style="width: 40%; text-align:left;" class="CampoSemBordas">
                        <dx:ASPxDateEdit id="edtEndDate" runat="server" Date='<%# ((AppointmentFormTemplateContainer)Container).End %>' EditFormat="Date" Width="100%" DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" CssClass="CamposSemBordaInferior">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 20%;" class="CampoSemBordas" ID="edtEndTimeLayoutRoot">
                        <dx:ASPxTimeEdit ID="edtEndTime" runat="server" Width="100%" DateTime='<%# ((AppointmentFormTemplateContainer)Container).End %>' DateOnError="Undo" AllowNull="false" EnableClientSideAPI="true" HelpTextSettings-PopupMargins-MarginLeft="50" CssClass="CamposSemBordaInferior">
                            <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ValidateOnLeave="false" EnableCustomValidation="True" Display="Dynamic"
                                ValidationGroup="DateValidatoinGroup">
                            </ValidationSettings>
                        </dx:ASPxTimeEdit>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
<% if (TimeZonesEnabled) { %>
    <tr>
        <td class="dxscSingleCell">
            <table style="width: 100%;">
                <tr>
                    <td class="TituloCampo">
                        <dx:ASPxLabel ID="lblTimeZone" runat="server" AssociatedControlID="edtStatus" Wrap="false" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td class="CampoSemBordas">
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="cbTimeZone" runat="server" Width="100%" CssClass="CampoSemBordas"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
<% } %>
    <tr>
        <td style="width: 50%; padding-right: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td class="TituloCampo" style="width: 40%;">
                        <dx:ASPxLabel ID="lblStatus" runat="server" AssociatedControlID="edtStatus" Wrap="false" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td class="CampoSemBordas" style="width: 60%;">
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).StatusDataSource %>' CssClass="CamposSemBordaInferior"/>
                    </td>
                </tr>
            </table>
        </td>
        <td style="width: 50%; padding-left: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td class="TituloCampo" style="width: 40%;">
                        <dx:ASPxLabel ID="lblAllDay" runat="server" AssociatedControlID="chkAllDay" CssClass="TextoCinza16" />
                    </td>
                    <td class="CampoSemBordas" style="width: 60%;">
                        <dx:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" Checked='<%# ((AppointmentFormTemplateContainer)Container).Appointment.AllDay %>' CssClass="CamposSemBordaInferior">
                        </dx:ASPxCheckBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
<% if(CanShowReminders) { %>
        <td style="width: 50%; padding-right: 5px;">
<% } else { %>
        <td style="width: 50%; padding-right: 5px;" colspan="2">
<% } %>
            <table style="width: 100%;">
                <tr>
                    <td class="TituloCampo" style="width: 40%;">
                        <dx:ASPxLabel ID="lblResource" runat="server" AssociatedControlID="edtResource" CssClass="TextoCinza16">
                        </dx:ASPxLabel>
                    </td>
                    <td class="CampoSemBordas" style="width: 60%;">
<% if(ResourceSharing) { %>
                        <dx:ASPxDropDownEdit CssClass="CamposSemBordaInferior" id="ddResource" runat="server" Width="100%" ClientInstanceName="ddResource" Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanEditResource %>' AllowUserInput="false">
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox id="edtMultiResource" runat="server" width="100%" SelectionMode="CheckColumn" DataSource='<%# ResourceDataSource %>' Border-BorderWidth="0" CssClass="CamposSemBordaInferior" ItemStyle-Font-Size="14px" />
                            </DropDownWindowTemplate>
                        </dx:ASPxDropDownEdit>                        
<% } else { %>           
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtResource" runat="server" Width="100%" DataSource='<%# ResourceDataSource %> ' Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanEditResource %>' CssClass="CamposSemBordaInferior" ItemStyle-Font-Size="14px" />
<% } %>             
                    </td>

                </tr>
            </table>
        </td>
<% if(CanShowReminders) { %>
        <td style="width: 50%; padding-left: 5px;">
            <table style="width: 100%;">
                <tr>
                    <td style="padding-left: 2px; width: 40%;" class="TituloCampo">
                        <dx:ASPxLabel ID="lblReminder" runat="server" AssociatedControlID="chkReminder" CssClass="TextoCinza16" />
                    </td>
                    <td style="width: 20%; height: 20px;" class="CampoSemBordas">
                        <dx:ASPxCheckBox ID="chkReminder" runat="server" CssClass="CamposSemBordaInferior"> 
                        </dx:ASPxCheckBox>
                    </td>
                    <td style="width: 40%;" Class="CampoSemBordas">
                        <dx:ASPxComboBox ID="cbReminder" runat="server" Width="100%" DataSource='<%# ((AppointmentFormTemplateContainer)Container).ReminderDataSource %>' CssClass="CamposSemBordaInferior" ItemStyle-Font-Size="14px" />
                    </td>
                </tr>
            </table>
        </td>
<% } %>
    </tr>
    <tr>
        <td colspan="2">
            <table style="width: 100%;">
                <tr>
                    <td style="width: 20%; vertical-align: top;" class="TituloCampo">
                        <span class="TextoCinza16">Descrição:</span>
                    </td>
                    <td style="width: 80%; vertical-align: top;" class="CampoSemBordas">
                        <dx:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" Rows="5" runat="server" Width="100%" Text='<%# ((AppointmentFormTemplateContainer)Container).Appointment.Description %>' CssClass="CamposSemBordaInferior" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</div>

<div style="display: none; visibility: hidden;">
    <dxsc:AppointmentRecurrenceForm ID="AppointmentRecurrenceForm1" runat="server" Visible="false" Enabled="false"
        IsRecurring='<%# ((AppointmentFormTemplateContainer)Container).Appointment.IsRecurring %>' 
        DayNumber='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceDayNumber %>' 
        End='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceEnd %>' 
        Month='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceMonth %>' 
        OccurrenceCount='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceOccurrenceCount %>' 
        Periodicity='<%# ((AppointmentFormTemplateContainer)Container).RecurrencePeriodicity %>' 
        RecurrenceRange='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceRange %>' 
        Start='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceStart %>' 
        WeekDays='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekDays %>' 
        WeekOfMonth='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceWeekOfMonth %>' 
        RecurrenceType='<%# ((AppointmentFormTemplateContainer)Container).RecurrenceType %>'
        IsFormRecreated='<%# ((AppointmentFormTemplateContainer)Container).IsFormRecreated %>' >
    </dxsc:AppointmentRecurrenceForm>
</div>                   

<table <%= DevExpress.Web.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%; height: 35px;">
    <tr>
        <td class="dx-ac" style="width: 100%; height: 100%;" <%= DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(this, "center", null) %>>
            <table class="dxscButtonTable" style="height: 100%">
                <tr>
                    <td class="dxscCellWithPadding">
                        <dx:ASPxButton runat="server" ID="btnOk" UseSubmitBehavior="false" AutoPostBack="false" 
                            EnableViewState="false" Width="91px" EnableClientSideAPI="true"/>
                    </td>
                    <td class="dxscCellWithPadding">
                        <dx:ASPxButton runat="server" ID="btnCancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false" 
                            Width="91px" CausesValidation="False" EnableClientSideAPI="true" />
                    </td>
                    <td class="dxscCellWithPadding">
                        <dx:ASPxButton runat="server" ID="btnDelete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%# ((AppointmentFormTemplateContainer)Container).CanDeleteAppointment %>'
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table <%= DevExpress.Web.Internal.RenderUtils.GetTableSpacings(this, 0, 0) %> style="width: 100%;">
    <tr>
        <td class="dx-al" style="width: 100%;"  <%= DevExpress.Web.Internal.RenderUtils.GetAlignAttributes(this, "left", null) %>>
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlId='<%# ((DevExpress.Web.ASPxScheduler.AppointmentFormTemplateContainer)Container).ControlId %>' />
        </td>
    </tr>
</table>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
    ASPxAppointmentForm = ASPx.CreateClass(ASPxClientFormBase, {
        Initialize: function () {
            this.isValid = true;
            this.isRecurrenceValid = true;
            this.controls.edtStartDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtStartDateValidate, this));
            this.controls.edtEndDate.Validation.AddHandler(ASPx.CreateDelegate(this.OnEdtEndDateValidate, this));
            this.controls.edtStartDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
            this.controls.edtEndDate.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
            this.controls.edtStartTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateStartDateTimeValue, this));
            this.controls.edtEndTime.ValueChanged.AddHandler(ASPx.CreateDelegate(this.OnUpdateEndDateTimeValue, this));
            this.controls.chkAllDay.CheckedChanged.AddHandler(ASPx.CreateDelegate(this.OnChkAllDayCheckedChanged, this));
            this.controls.btnOk.Click.AddHandler(ASPx.CreateDelegate(this.OnBtnOk, this));
            if (this.controls.AppointmentRecurrenceForm1)
                this.controls.AppointmentRecurrenceForm1.ValidationCompleted.AddHandler(ASPx.CreateDelegate(this.OnRecurrenceRangeControlValidationCompleted, this));
            this.UpdateTimeEditorsVisibility();
            if (this.controls.chkReminder)
                this.controls.chkReminder.CheckedChanged.AddHandler(ASPx.CreateDelegate(this.OnChkReminderCheckedChanged, this));
            if (this.controls.edtMultiResource)
                this.controls.edtMultiResource.SelectedIndexChanged.AddHandler(ASPx.CreateDelegate(this.OnEdtMultiResourceSelectedIndexChanged, this));
            var start = this.controls.edtStartDate.GetValue();
            var end = this.controls.edtEndDate.GetValue();
            var duration = ASPxClientTimeInterval.CalculateDuration(start, end);
            this.appointmentInterval = new ASPxClientTimeInterval(start, duration);
            this.appointmentInterval.SetAllDay(this.controls.chkAllDay.GetValue());
            this.primaryIntervalJson = ASPx.Json.ToJson(this.appointmentInterval);
            this.UpdateDateTimeEditors();
        },
        OnBtnOk: function (s, e) {
            e.processOnServer = false;
            var formOwner = this.GetFormOwner();
            if (!formOwner)
                return;
            if (this.controls.AppointmentRecurrenceForm1 && this.IsRecurrenceChainRecreationNeeded() && this.cpHasExceptions) {
                formOwner.ShowMessageBox(this.localization.SchedulerLocalizer.Msg_Warning, this.localization.SchedulerLocalizer.Msg_RecurrenceExceptionsWillBeLost, this.OnWarningExceptionWillBeLostOk.aspxBind(this));
            } else {
                formOwner.AppointmentFormSave();
            }
        },
        IsRecurrenceChainRecreationNeeded: function () {
            var isIntervalChanged = this.primaryIntervalJson != ASPx.Json.ToJson(this.appointmentInterval);
            return isIntervalChanged || this.controls.AppointmentRecurrenceForm1.IsChanged();
        },
        OnWarningExceptionWillBeLostOk: function () {
            this.GetFormOwner().AppointmentFormSave();
        },
        OnEdtMultiResourceSelectedIndexChanged: function (s, e) {
            var resourceNames = new Array();
            var items = s.GetSelectedItems();
            var count = items.length;
            if (count > 0) {
                for (var i = 0; i < count; i++)
                    resourceNames.push(items[i].text);
            }
            else
                resourceNames.push(ddResource.cp_Caption_ResourceNone);
            ddResource.SetValue(resourceNames.join(', '));
        },
        OnEdtStartDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnEdtEndDateValidate: function (s, e) {
            if (!e.isValid)
                return;
            var startDate = this.controls.edtStartDate.GetDate();
            var endDate = this.controls.edtEndDate.GetDate();
            e.isValid = startDate == null || endDate == null || startDate <= endDate;
            e.errorText = "The Start Date must precede the End Date.";
        },
        OnUpdateEndDateTimeValue: function (s, e) {
            var isAllDay = this.controls.chkAllDay.GetValue();
            var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtEndDate.GetDate());
            if (isAllDay)
                date = ASPxSchedulerDateTimeHelper.AddDays(date, 1);
            var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtEndTime.GetDate());
            var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
            this.appointmentInterval.SetEnd(dateTime);
            this.UpdateDateTimeEditors();
            this.Validate();
        },
        OnUpdateStartDateTimeValue: function (s, e) {
            var date = ASPxSchedulerDateTimeHelper.TruncToDate(this.controls.edtStartDate.GetDate());
            var time = ASPxSchedulerDateTimeHelper.ToDayTime(this.controls.edtStartTime.GetDate());
            var dateTime = ASPxSchedulerDateTimeHelper.AddTimeSpan(date, time);
            this.appointmentInterval.SetStart(dateTime);
            this.UpdateDateTimeEditors();
            if (this.controls.AppointmentRecurrenceForm1)
                this.controls.AppointmentRecurrenceForm1.SetStart(dateTime);
            this.Validate();
        },
        OnChkReminderCheckedChanged: function (s, e) {
            var isReminderEnabled = this.controls.chkReminder.GetValue();
            if (isReminderEnabled)
                this.controls.cbReminder.SetSelectedIndex(3);
            else
                this.controls.cbReminder.SetSelectedIndex(-1);
            this.controls.cbReminder.SetEnabled(isReminderEnabled);
        },
        OnChkAllDayCheckedChanged: function (s, e) {
            this.UpdateTimeEditorsVisibility();
            var isAllDay = this.controls.chkAllDay.GetValue();
            this.appointmentInterval.SetAllDay(isAllDay);
            this.UpdateDateTimeEditors();
        },
        UpdateDateTimeEditors: function () {
            var isAllDay = this.controls.chkAllDay.GetValue();
            this.controls.edtStartDate.SetValue(this.appointmentInterval.GetStart());
            var end = this.appointmentInterval.GetEnd();
            if (isAllDay) {
                end = ASPxSchedulerDateTimeHelper.AddDays(end, -1);
            }
            this.controls.edtEndDate.SetValue(end);
            this.controls.edtStartTime.SetValue(this.appointmentInterval.GetStart());
            this.controls.edtEndTime.SetValue(end);
        },
        UpdateTimeEditorsVisibility: function () {
            var isAllDay = this.controls.chkAllDay.GetValue();
            var visible = (isAllDay) ? "none" : "";
            var startRoot = ASPx.GetParentById(this.controls.edtStartTime.GetMainElement(), "edtStartTimeLayoutRoot");
            var endRoot = ASPx.GetParentById(this.controls.edtEndTime.GetMainElement(), "edtEndTimeLayoutRoot");
            startRoot.style.display = visible;
            endRoot.style.display = visible;
        },
        Validate: function () {
            this.isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
            this.controls.btnOk.SetEnabled(this.isValid && this.isRecurrenceValid);
        },
        OnRecurrenceRangeControlValidationCompleted: function (s, e) {
            if (!this.controls.AppointmentRecurrenceForm1)
                return;
            this.isRecurrenceValid = this.controls.AppointmentRecurrenceForm1.IsValid();
            this.controls.btnOk.SetEnabled(this.isValid && this.isRecurrenceValid);
        }
    });
</script>