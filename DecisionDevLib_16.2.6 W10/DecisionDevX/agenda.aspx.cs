using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using DevExpress.Web;
using DevExpress.XtraScheduler;
using Decision.LoginManager;
using Decision.TableManager;
using Decision.Secutiry;
using Decision.Lists;
using DevExpress.Web.ASPxScheduler;

namespace Decision
{
    public partial class agenda : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de acesso
        Security_Manager oSecurity = new Security_Manager();

        public string HTMLColor(Color oColor)
        {
            //***************************
            //* Converte a cor para HTML
            //***************************
            return ColorTranslator.ToHtml(oColor);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Controle de login"

            //*************************
            //* Obtem dados de conexão
            //*************************
            if (Session["Decision_LoginInfo"] != null)
                oLogin = (Login_Manager)Session["Decision_LoginInfo"];
            else
                oLogin.LogOff();

            //***************
            //* Sem conexão?
            //***************
            if (oLogin.LoginInfo.Usuario_Codigo == 0)
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("conectar.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("conectar.aspx");
            }

            #endregion

            #region "Controle de segurança"

            //****************************************************
            //* Incializa segurança e verifica pemissão de acesso
            //****************************************************
            oSecurity.InitializeSecurity(oLogin);
            if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda))
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/abertura.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
            }

            #endregion

            //**************************
            //* Apenas se houver acesso
            //**************************
            if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda))
            {
                //*****************************
                //* Atualiza string de conexão
                //*****************************
                dsAgenda.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;

                //******************************************************
                //* Apenas na inicialização (evita CallBack e PostBack)
                //******************************************************
                if (!IsCallback && !IsPostBack)
                {
                    //*********************************************
                    //* Define segurança da agenda de apontamentos
                    //*********************************************
                    if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda))
                        schAgenda.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.All;
                    else
                        schAgenda.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;

                    if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda))
                        schAgenda.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.All;
                    else
                        schAgenda.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;

                    if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda))
                        schAgenda.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.All;
                    else
                        schAgenda.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;

                    //*******************************************
                    //* Deve restringir agendamentos ao usuário?
                    //*******************************************
                    if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda_Restingir))
                    {
                        //*******************************************
                        //* Deve restringir agendamentos ao usuário?
                        //*******************************************
                        string SQL = "SELECT * FROM agenda_apontamentos WHERE ";
                        SQL += "agenda_apontamentos.codpromotor = " + oLogin.LoginInfo.Usuario_CodigoPromotor + " OR ";
                        SQL += "agenda_apontamentos.codpromotor = 0 OR ISNULL(agenda_apontamentos.codpromotor)";
                        dsAgenda.SelectCommand = SQL;
                    }
                }

                //**************************************************
                //* Cria variável de sessão para código do promotor
                //**************************************************
                Session["Decision_Agenda_Promotor"] = oLogin.LoginInfo.Usuario_CodigoPromotor;

                //***************************
                //* Atualiza lista de labels
                //***************************
                BuildCustomLabels();

                //******************************
                //* Atualiza lista de resources
                //******************************
                BuildCustomResources();

                //****************
                //* Atualiza bind
                //****************
                schAgenda.DataBind();

                //*************************
                //* Avança para data atual
                //*************************
                schAgenda.GoToToday();
            }
        }
        public string SchedulerSubjectLink(AppointmentTemplateContainer oContainer)
        {
            //**************
            //* Declarações
            //**************
            string URL = string.Empty;

            //*****************************
            //* Existe oportunidade válida
            //*****************************
            if (Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDOportunidade"]) > 0 ||
                Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDOrcamento"]) > 0)
            {
                //*********************************************************
                //* O operador possui acesso ao cadastro de oportunidades?
                //*********************************************************
                if (oSecurity.IsActive(oLogin,(int)OptionLists.Seguranca.Cadastro_Oportunidade))
                {
                    //*************************************
                    //* Link para oportunidade e orçamento
                    //*************************************
                    URL += "oportunidades_edicao.aspx?Codigo=";
                    URL += oContainer.AppointmentViewInfo.Appointment.CustomFields["IDOportunidade"].ToString();
                    URL += "&back=agenda.aspx";
                }
                else
                {
                    //***********
                    //* Sem link
                    //***********
                    URL = "#";
                }
                return URL;
            }
            else if (Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDCliente"]) > 0)
            {
                //****************************************************
                //* O operador possui acesso ao cadastro de clientes?
                //****************************************************
                if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes))
                {
                    //********************
                    //* Link para cliente
                    //********************
                    URL += "clientes_edicao.aspx?Codigo=";
                    URL += oContainer.AppointmentViewInfo.Appointment.CustomFields["IDCliente"].ToString();
                    URL += "&back=agenda.aspx";
                }
                else
                {
                    //***********
                    //* Sem link
                    //***********
                    URL = "#";
                }
                return URL;
            }
            else
            {
                //***********
                //* Sem link
                //***********
                return "#";
            }
        }
        public bool SchedulerSubjectLinkEnabled(AppointmentTemplateContainer oContainer)
        {
            //**************
            //* Declarações
            //**************
            string URL = string.Empty;

            //*****************************
            //* Existe oportunidade válida
            //*****************************
            if (Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDOportunidade"]) > 0 ||
                Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDOrcamento"]) > 0)
            {
                //*********************************************************
                //* O operador possui acesso ao cadastro de oportunidades?
                //*********************************************************
                if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                {
                    //*************************************
                    //* Link para oportunidade e orçamento
                    //*************************************
                    return true;
                }
                else
                {
                    //***********
                    //* Sem link
                    //***********
                    return false;
                }
            }
            else if (Convert.ToInt32(oContainer.AppointmentViewInfo.Appointment.CustomFields["IDCliente"]) > 0)
            {
                //****************************************************
                //* O operador possui acesso ao cadastro de clientes?
                //****************************************************
                if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes))
                {
                    //********************
                    //* Link para cliente
                    //********************
                    return true;
                }
                else
                {
                    //***********
                    //* Sem link
                    //***********
                    return false;
                }
            }
            else
            {
                //***********
                //* Sem link
                //***********
                return false;
            }
        }
        protected void BuildCustomLabels()
        {
            //**************
            //* Declarações
            //**************
            Agenda_Etiqueta_Manager oManager = new Agenda_Etiqueta_Manager(oLogin.LoginInfo.Master_ConexaoString);
            List<Agenda_Etiqueta_Fields> oEtiquetas = oManager.GetSchedulerCustomLabels();
            System.Drawing.Color oColor;

            //*************************
            //* Anula coleção anterior
            //*************************
            schAgenda.Storage.BeginUpdate();
            schAgenda.Storage.Appointments.Labels.Clear();

            //********************
            //* Cria nova coleção
            //********************
            foreach (Agenda_Etiqueta_Fields oEtiqueta in oEtiquetas)
            {
                oColor = Color.FromArgb(oEtiqueta.Cor_RED, oEtiqueta.Cor_GREEN, oEtiqueta.Cor_BLUE);
                schAgenda.Storage.Appointments.Labels.Add(oColor, oEtiqueta.Descricao);
            }
            schAgenda.Storage.EndUpdate();
        }
        protected void BuildCustomResources()
        {
            //**************
            //* Declarações
            //**************
            Promotor_Manager oManager = new Promotor_Manager(oLogin.LoginInfo.Master_ConexaoString);
            List<Promotor_Fields> oPromotores = oManager.Get_NomePromotor_Like("%");

            //*************************
            //* Anula coleção anterior
            //*************************
            schAgenda.Storage.BeginUpdate(); 
            schAgenda.Storage.Resources.Clear();

            //********************
            //* Cria nova coleção
            //********************
            foreach (Promotor_Fields oPromotor in oPromotores)
                schAgenda.Storage.Resources.Items.Add(oPromotor.PK_CodPromotor, oPromotor.NomePromotor);
            schAgenda.Storage.EndUpdate();
        }
    }
}