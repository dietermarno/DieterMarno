using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Serialization;
using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;
using Decision.Database;
using Decision.TableManager;
using Decision.Extensions;
using Decision.Lists;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.Util;

namespace Decision
{
    public partial class oportunidades_edicao : System.Web.UI.Page
    {
        //************************
        //* Declarações do módulo
        //************************
        Login_Manager oLogin = new Login_Manager();
        
        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Insert = false;
        public bool Security_Update = false;

        Oportunidade_JSON oJSON = new Oportunidade_JSON();
        DataTable oTableOportunidade = new DataTable();
        ASPxSpinEdit oSpin = new ASPxSpinEdit();
        ASPxComboBox oCombo = new ASPxComboBox();
        ASPxDateEdit oData = new ASPxDateEdit();
        ASPxTextBox oText = new ASPxTextBox();
        ASPxMemo oMemo = new ASPxMemo();
        ASPxButton oButton = new ASPxButton();

        protected void PopulaAbertura(Int32 Nro_Oportunidade)
        {
            #region "Definição de título"

                //****************
                //* Define título
                //****************
                if (Nro_Oportunidade == 0)
                    this.lblTitulo.Text = "CRIAÇÃO DE OPORTUNIDADE";
                else
                    this.lblTitulo.Text = "ALTERANDO DADOS DA OPORTUNIDADE Nº " + Nro_Oportunidade;
            #endregion

            #region "Situação da oportunidade"

                //********************************************************
                //* ABERTURA - Localiza combo da situação da oportunidade
                //********************************************************
                ASPxFormLayout oFormLayoutComando = nvbEtapas.Groups[0].FindControl("layComando") as ASPxFormLayout;
                if (oFormLayoutComando != null)
                {
                    //*****************************
                    //* Localiza combo da situação
                    //*****************************
                    ASPxComboBox oComboSituacao = oFormLayoutComando.FindControl("cboSituacao") as ASPxComboBox;
                    if (oComboSituacao != null)
                    {
                        //***************
                        //* Popula combo
                        //***************
                        ListLoader.Popula_CBO_OrcamentoSituacao(oComboSituacao);
                    }
                }

            #endregion

            #region "Etapa 1 (Abertura)"

                //*****************************
                //* ABERTURA - Localiza layout
                //*****************************
                ASPxFormLayout oFormLayoutAbertura = nvbEtapas.Groups[1].FindControl("layAbertura") as ASPxFormLayout;
                if (oFormLayoutAbertura != null)
                {
                    //*************************************
                    //* Localiza combo do canal de entrada 
                    //*************************************
                    ASPxComboBox oComboCanalEntrada = oFormLayoutAbertura.FindControl("cboCanalEntrada") as ASPxComboBox;
                    if (oComboCanalEntrada != null)
                    {
                        //***************
                        //* Popula combo
                        //***************
                        ListLoader.Popula_CBO_CanalEntrada(oComboCanalEntrada);
                    }

                    //*******************************
                    //* Localiza combo de atendentes
                    //*******************************
                    ASPxComboBox oComboAtendente = oFormLayoutAbertura.FindControl("cboAtendente") as ASPxComboBox;
                    if (oComboAtendente != null)
                    {
                        //***************
                        //* Popula combo
                        //***************
                        ListLoader.Popula_CBO_Atendentes(oComboAtendente, Session["Decision_LoginInfo"]);
                    }
                }

            #endregion

            #region "Etapa 2 (Orçamento)

                //****************************************
                //* ORÇAMENTO - Localiza layout de campos
                //****************************************
                ASPxFormLayout oFormLayoutOrcamento0 = nvbEtapas.Groups[2].FindControl("layOrcamento0") as ASPxFormLayout;
                if (oFormLayoutOrcamento0 != null)
                {
                    //*****************************************
                    //* Localiza combo de estágio de orçamento
                    //*****************************************
                    ASPxComboBox oComboEstagioOrcamento = oFormLayoutOrcamento0.FindControl("cboEstagioOrcamento") as ASPxComboBox;
                    if (oComboEstagioOrcamento != null)
                    {
                        //***************
                        //* Popula combo
                        //***************
                        ListLoader.Popula_CBO_EstagioOrcamento(oComboEstagioOrcamento);
                    }
                }

            #endregion
        }
        protected void PopulaJSON(Int32 Nro_Oportunidade)
        {
            //**************
            //* Declarações
            //**************
            Int32 COrcamento = 0;

            //*****************
            //* Dados de login
            //*****************
            Login_Manager oLogin = new Login_Manager();
            oLogin = (Login_Manager)Session["Decision_LoginInfo"];

            //***************
            //* Oportunidade
            //***************
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
            Oportunidade_Manager oManagerOportunidade;
            oManagerOportunidade = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));

            //************
            //* Orçamento
            //************
            List<Oportunidade_Orcamentos_Fields> oOrcamentos = new List<Oportunidade_Orcamentos_Fields>();
            Oportunidade_Orcamentos_Manager oManagerOrcamentos;
            oManagerOrcamentos = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));

            //********************
            //* Parâmetros comuns
            //********************
            oJSON.parametros.Add("CodigoMaster", "0" + oLogin.LoginInfo.Master_Codigo.ToString());
            oJSON.parametros.Add("CodigoPosto", "0" + oLogin.LoginInfo.Posto_Codigo.ToString());
            oJSON.parametros.Add("CodigoOportunidade", "0" + Nro_Oportunidade);
            oJSON.parametros.Add("CodigoOrcamento", "0");
            oJSON.parametros.Add("CodigoOrcamentoAceito", "0");
            oJSON.parametros.Add("IndiceOrcamento", "-1");
            oJSON.parametros.Add("Temporario", "");
            oJSON.parametros.Add("Funcao", "");
            oJSON.operacao = "Popular";

            //*********************************
            //* Obtém registro da oportunidade
            //*********************************
            oOportunidade = oManagerOportunidade.GetRecord(Nro_Oportunidade);
            oJSON.oportunidade = oOportunidade;

            //******************************************
            //* Obtém coleção de registros de orçamento
            //******************************************
            oOrcamentos = oManagerOrcamentos.GetRecords(Nro_Oportunidade);

            //******************************
            //* Gera cópia em formato array
            //******************************
            Oportunidade_Orcamentos_Fields[] oOrcamentosTemp = new Oportunidade_Orcamentos_Fields[0];
            Array.Resize<Oportunidade_Orcamentos_Fields>(ref oOrcamentosTemp, oOrcamentos.Count);
            foreach (Oportunidade_Orcamentos_Fields oOrcamento in oOrcamentos)
            {
                oOrcamentosTemp[COrcamento] = oOrcamento;
                if (oOrcamento.estagio_orcamento == (int)Lists.OptionLists.OrcamentoEstagio.Aceito)
                {
                    //**************************
                    //* Define orçamento aceito
                    //**************************
                    oJSON.parametros["CodigoOrcamento"] = oOrcamento.PK_cod_orcamento.ToString();
                    oJSON.parametros["IndiceOrcamento"] = COrcamento.ToString();
                }
                COrcamento++;
            }

            //******************************
            //* Retorna array de orçamentos
            //******************************
            oJSON.orcamentos = oOrcamentosTemp;

            //**************************************
            //* Deve atualizar código do orçamento?
            //**************************************
            if (oJSON.parametros["CodigoOrcamento"] == "0" && oOrcamentos.Count > 0)
            {
                oJSON.parametros["CodigoOrcamento"] = oOrcamentos[0].PK_cod_orcamento.ToString();
                oJSON.parametros["IndiceOrcamento"] = "0";
            }

            //**************************
            //* Deve sugerir atendente? 
            //**************************
            if (Nro_Oportunidade == 0)
                oJSON.oportunidade.cod_promotor = oLogin.LoginInfo.Usuario_CodigoPromotor;
        }
        protected string ExcluiOrcamento(Oportunidade_JSON oJSON)
        {
            //********************
            //* Declara variáveis
            //********************
            Oportunidade_Orcamentos_Manager oManager;
            oManager = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Int32 CodigoOrcamento = Convert.ToInt32(oJSON.parametros["CodigoOrcamento"]);

            //****************************
            //* Informa chave do registro
            //****************************
            if (oManager.DeleteRecord(CodigoOrcamento))
            {
                //**************
                //* Anula erros
                //**************
                oJSON.error = string.Empty;
            }
            else
            {
                //*****************************
                //* Retorna status da operação
                //*****************************
                oJSON.error = "Error ao excluir o orçamento " + CodigoOrcamento + ":" + oManager.ErrorText;
                if (!oManager.Error)
                {
                    oJSON.parametros["IndiceOrcamento"] = "0";
                    oJSON.error = "";
                    return "Ok";
                }
                else
                {
                    oJSON.error = oManager.ErrorText;
                    return oManager.ErrorText;
                }
            }

            //*******************************************
            //* Retorna novo ítem da lista de orçamentos
            //*******************************************
            return new JavaScriptSerializer().Serialize(oJSON);
        }
        protected string SalvaEtapa1(Oportunidade_JSON oJSON)
        {
            //********************
            //* Declara variáveis
            //********************
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
            Oportunidade_Manager oManager = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Int32 CodOportunidade = 0;

            Agenda_Apontamentos_Manager oAgendaManager;
            oAgendaManager = new Agenda_Apontamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Agenda_Apontamentos_Fields oAgenda = new Agenda_Apontamentos_Fields();

            string ItemText = string.Empty;

            //****************
            //* Associa dados
            //****************
            oOportunidade = oJSON.oportunidade;

            //*****************************************
            //* Executa inclusão e retorna novo código
            //*****************************************
            CodOportunidade = oManager.ApplyRecord(oOportunidade);
            oJSON.oportunidade.PK_nro_oportunidade = CodOportunidade;

            //*****************************
            //* Retorna status da operação
            //*****************************
            if (!oManager.Error)
            {
                //************************************
                //* Salva agendamento da oportunidade
                //************************************
                oAgendaManager = SalvaAgendamentoOportunidade(oOportunidade);

                //**************************
                //* Houve erro na operação?
                //**************************
                if (!oAgendaManager.Error)
                {
                    //*******************************
                    //* Deve agendar pré/pós viagem?
                    //*******************************
                    if (oOportunidade.cod_situacao == (int)Lists.OptionLists.OportunidadeStuacao.Ganhou)
                    {
                        //****************************************
                        //* Salva agendamento de pré e pós viagem
                        //****************************************
                        oAgendaManager = SalvaAgendamentoPrePosViagem(oOportunidade);

                        //**************************
                        //* Houve erro na operação?
                        //**************************
                        if (oAgendaManager.Error)
                        {
                            //***************
                            //* Retorna erro
                            //***************
                            oJSON.error = oAgendaManager.ErrorText;
                            return oAgendaManager.ErrorText + "|" + oManager.ErrorText;
                        }
                    }

                    //*****************
                    //* Não houve erro
                    //*****************
                    oJSON.error = "";
                    return "Ok";
                }
                else
                {
                    //***************
                    //* Retorna erro
                    //***************
                    oJSON.error = oAgendaManager.ErrorText;
                    return oAgendaManager.ErrorText + "|" + oManager.ErrorText;
                }
            }
            else
            {
                //***************
                //* Retorna erro
                //***************
                oJSON.error = oManager.ErrorText;
                return oManager.ErrorText;
            }
        }
        protected string SalvaEtapa2(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Manager oOportunidadeManager;
            oOportunidadeManager = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();

            Oportunidade_Orcamentos_Manager oOrcamentosManager;
            oOrcamentosManager = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();

            Agenda_Apontamentos_Manager oAgendaManager;

            Int32 IndiceOrcamento = Convert.ToInt32(oJSON.parametros["IndiceOrcamento"]);

            //****************
            //* Associa dados
            //****************
            oOportunidade = oJSON.oportunidade;
            oOrcamento = oJSON.orcamentos[IndiceOrcamento];

            //*********************************************
            //* Deve converter a situação da oportunidade?
            //*********************************************
            oOportunidade.PK_nro_oportunidade = oJSON.oportunidade.PK_nro_oportunidade;
            if (oOportunidade.cod_situacao == (int)Lists.OptionLists.OportunidadeStuacao.Qualificacao)
            {
                oOportunidade.cod_situacao = (int)Lists.OptionLists.OportunidadeStuacao.Analise;
                oJSON.oportunidade.cod_situacao = oOportunidade.cod_situacao;
            }

            //************************
            //* Atualiza oportunidade
            //************************
            oOportunidadeManager.UpdateStage2(oOportunidade);

            //********************
            //* Atualiza registro
            //********************
            if (oOrcamento.PK_cod_orcamento == 0)
            {
                oOrcamento.PK_cod_orcamento = oOrcamentosManager.ApplyRecord(oOrcamento);
                oJSON.orcamentos[IndiceOrcamento].PK_cod_orcamento = oOrcamento.PK_cod_orcamento;
                oJSON.orcamentos[IndiceOrcamento].nro_oportunidade = oJSON.oportunidade.PK_nro_oportunidade;
                oJSON.parametros["CodigoOrcamento"] = oOrcamento.PK_cod_orcamento.ToString();
                oJSON.parametros["IndiceOrcamento"] = "0";
            }
            else
            {
                //********************
                //* Executa alteração
                //********************
                oOrcamentosManager.ApplyRecord(oOrcamento);
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            if (!oOportunidadeManager.Error && !oOrcamentosManager.Error)
            {
                //*********************************
                //* Salva agendamento de orçamento
                //*********************************
                oAgendaManager = SalvaAgendamentoOrcamento(oOportunidade, oOrcamento);

                //**************************
                //* Houve erro na operação?
                //**************************
                if (oAgendaManager.Error)
                {
                    //***************
                    //* Retorna erro
                    //***************
                    oJSON.error = oAgendaManager.ErrorText;
                    return oAgendaManager.ErrorText + "|" + oOrcamentosManager.ErrorText;
                }

                //*******************************
                //* Deve agendar pré/pós viagem?
                //*******************************
                if (oOportunidade.cod_situacao == (int)Lists.OptionLists.OportunidadeStuacao.Ganhou)
                {
                    //****************************************
                    //* Salva agendamento de pré e pós viagem
                    //****************************************
                    oAgendaManager = SalvaAgendamentoPrePosViagem(oOportunidade);

                    //**************************
                    //* Houve erro na operação?
                    //**************************
                    if (oAgendaManager.Error)
                    {
                        //***************
                        //* Retorna erro
                        //***************
                        oJSON.error = oAgendaManager.ErrorText;
                        return oAgendaManager.ErrorText + "|" + oOrcamentosManager.ErrorText;
                    }
                }

                //*****************
                //* Não houve erro
                //*****************
                oJSON.error = "";
                return "Ok";
            }
            else
            {
                //***************
                //* Retorna erro
                //***************
                oJSON.error = oOportunidadeManager.ErrorText + " | " + oOrcamentosManager.ErrorText;
                return oOportunidadeManager.ErrorText + "|" + oOrcamentosManager.ErrorText;
            }
        }
        protected string SalvaEtapa3(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Manager oManagerOportunidades;
            oManagerOportunidades = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();

            Agenda_Apontamentos_Manager oAgendaManager;

            //****************
            //* Associa dados
            //****************
            oOportunidade = oJSON.oportunidade;

            //*****************************************************
            //* Atualiza dados do orçamento aceito na oportunidade
            //*****************************************************
            oManagerOportunidades.UpdateClosing(oOportunidade);

            //**************************
            //* Houve erro no processo?
            //**************************
            if (oManagerOportunidades.Error)
            {
                //***********************************
                //* Finaliza processo se houver erro
                //***********************************
                oJSON.error = oManagerOportunidades.ErrorText;
                return oManagerOportunidades.ErrorText;
            }

            //*******************************
            //* Deve agendar pré/pós viagem?
            //*******************************
            if (oOportunidade.cod_situacao == (int)Lists.OptionLists.OportunidadeStuacao.Ganhou)
            {
                //****************************************
                //* Salva agendamento de pré e pós viagem
                //****************************************
                oAgendaManager = SalvaAgendamentoPrePosViagem(oOportunidade);

                //**************************
                //* Houve erro na operação?
                //**************************
                if (oAgendaManager.Error)
                {
                    //***************
                    //* Retorna erro
                    //***************
                    oJSON.error = oAgendaManager.ErrorText;
                    return oAgendaManager.ErrorText + "|" + oManagerOportunidades.ErrorText;
                }
            }

            //*****************
            //* Não houve erro
            //*****************
            oJSON.error = "";
            return "Ok";
        }
        protected void SalvaComentarioInterno(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Orcamentos_Manager oOrcamentosManager;
            oOrcamentosManager = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();

            Int32 IndiceOrcamento = Convert.ToInt32(oJSON.parametros["IndiceOrcamento"]);

            //****************
            //* Associa dados
            //****************
            oOrcamento = oJSON.orcamentos[IndiceOrcamento];

            //********************
            //* Atualiza registro
            //********************
            if (oOrcamento.PK_cod_orcamento != 0)
                oOrcamentosManager.UpdateInternalNotes(oOrcamento);
        }
        protected Agenda_Apontamentos_Manager SalvaAgendamentoOportunidade(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            Agenda_Apontamentos_Manager oAgendaManager;
            oAgendaManager = new Agenda_Apontamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Agenda_Apontamentos_Fields oAgenda = new Agenda_Apontamentos_Fields();
            string ItemText = string.Empty;

            //***************************************
            //* Atualiza agendamento da oportunidade
            //***************************************
            oAgenda.PK_CodApontamento = 0;
            oAgenda.CodOportunidade = oOportunidade.PK_nro_oportunidade;
            oAgenda.CodOrcamento = 0;
            oAgenda.CodPromotor = oOportunidade.cod_promotor;
            oAgenda.Situacao = (int)Lists.OptionLists.AgendaStatus.Ocupado;
            oAgenda.Tipo = 0;
            oAgenda.Etiqueta = (int)Lists.OptionLists.AgendaEtiqueta.Oportunidade;
            oAgenda.Assunto = "Contato Oportunidade N° " + oOportunidade.PK_nro_oportunidade;
            ItemText = "Oportunidade N°: " + oOportunidade.PK_nro_oportunidade + "\r\n";
            ItemText += "Solicitante: " + oOportunidade.contato_nome + "\r\n";
            ItemText += "Telefone: " + oOportunidade.contato_telefone + "\r\n";
            ItemText += "Email: " + oOportunidade.contato_emails;
            oAgenda.Descricao = ItemText;
            oAgenda.Local = "Escritório";
            oAgenda.Recorrencia = string.Empty;
            oAgenda.Despertador = string.Empty;
            oAgenda.Inicio = oOportunidade.proximo_contato;
            oAgenda.Fim = oOportunidade.proximo_contato.Value.AddMinutes(30);
            oAgenda.Dia_Inteiro = false;
            oAgenda.Exportacao = true;
            oAgendaManager.ApplyOpportunityScheduler(oAgenda);
            return oAgendaManager;
        }
        protected Agenda_Apontamentos_Manager SalvaAgendamentoPrePosViagem(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            Agenda_Apontamentos_Manager oAgendaManager;
            oAgendaManager = new Agenda_Apontamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Agenda_Apontamentos_Fields oAgenda = new Agenda_Apontamentos_Fields();
            string ItemText = string.Empty;

            //*************************************
            //* Atualiza agendamento da pré-viagem
            //*************************************
            oAgenda.PK_CodApontamento = 0;
            oAgenda.CodOportunidade = oOportunidade.PK_nro_oportunidade;
            oAgenda.CodOrcamento = 0;
            oAgenda.CodPromotor = oOportunidade.cod_promotor;
            oAgenda.Situacao = (int)Lists.OptionLists.AgendaStatus.Ocupado;
            oAgenda.Tipo = 0;
            oAgenda.Etiqueta = (int)Lists.OptionLists.AgendaEtiqueta.Pre_Viagem;
            oAgenda.Assunto = "Pré-Viagem Oportunidade N° " + oOportunidade.PK_nro_oportunidade;
            ItemText = "Oportunidade N°: " + oOportunidade.PK_nro_oportunidade + "\r\n";
            ItemText += "Solicitante: " + oOportunidade.contato_nome + "\r\n";
            ItemText += "Telefone: " + oOportunidade.contato_telefone + "\r\n";
            ItemText += "Email: " + oOportunidade.contato_emails;
            oAgenda.Descricao = ItemText;
            oAgenda.Local = "Escritório";
            oAgenda.Recorrencia = string.Empty;
            oAgenda.Despertador = string.Empty;
            oAgenda.Inicio = Convert.ToDateTime(oOportunidade.data_saida.Value.AddDays(-2).ToString("yyyy-MM-dd") + " 09:00");
            oAgenda.Fim = oAgenda.Inicio.Value.AddMinutes(30);
            oAgenda.Dia_Inteiro = false;
            oAgenda.Exportacao = true;
            oAgendaManager.ApplyOpportunityScheduler(oAgenda);
            if (oAgendaManager.Error)
                return oAgendaManager;

            //*************************************
            //* Atualiza agendamento da pós-viagem
            //*************************************
            oAgenda.PK_CodApontamento = 0;
            oAgenda.CodOportunidade = oOportunidade.PK_nro_oportunidade;
            oAgenda.CodOrcamento = 0;
            oAgenda.CodPromotor = oOportunidade.cod_promotor;
            oAgenda.Situacao = (int)Lists.OptionLists.AgendaStatus.Ocupado;
            oAgenda.Tipo = 0;
            oAgenda.Etiqueta = (int)Lists.OptionLists.AgendaEtiqueta.Pos_Viagem;
            oAgenda.Assunto = "Pós-Viagem Oportunidade N° " + oOportunidade.PK_nro_oportunidade;
            ItemText = "Oportunidade N°: " + oOportunidade.PK_nro_oportunidade + "\r\n";
            ItemText += "Solicitante: " + oOportunidade.contato_nome + "\r\n";
            ItemText += "Telefone: " + oOportunidade.contato_telefone + "\r\n";
            ItemText += "Email: " + oOportunidade.contato_emails;
            oAgenda.Descricao = ItemText;
            oAgenda.Local = "Escritório";
            oAgenda.Recorrencia = string.Empty;
            oAgenda.Despertador = string.Empty;
            oAgenda.Inicio = Convert.ToDateTime(oOportunidade.data_retorno.Value.AddDays(2).ToString("yyyy-MM-dd") + " 09:00");
            oAgenda.Fim = oAgenda.Inicio.Value.AddMinutes(30);
            oAgenda.Dia_Inteiro = false;
            oAgenda.Exportacao = true;
            oAgendaManager.ApplyOpportunityScheduler(oAgenda);
            return oAgendaManager;
        }
        protected Agenda_Apontamentos_Manager SalvaAgendamentoOrcamento(Oportunidade_Fields oOportunidade, Oportunidade_Orcamentos_Fields oOrcamento)
        {
            //**************
            //* Declarações
            //**************
            Agenda_Apontamentos_Manager oAgendaManager;
            oAgendaManager = new Agenda_Apontamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
            Agenda_Apontamentos_Fields oAgenda = new Agenda_Apontamentos_Fields();
            string ItemText = string.Empty;

            //************************************
            //* Atualiza agendamento do orçamento
            //************************************
            oAgenda.PK_CodApontamento = 0;
            oAgenda.CodCliente = 0;
            oAgenda.CodOportunidade = oOportunidade.PK_nro_oportunidade;
            oAgenda.CodOrcamento = oOrcamento.PK_cod_orcamento;
            oAgenda.CodPromotor = oOportunidade.cod_promotor;
            oAgenda.Situacao = (int)Lists.OptionLists.AgendaStatus.Ocupado;
            oAgenda.Tipo = 0;
            oAgenda.Etiqueta = (int)Lists.OptionLists.AgendaEtiqueta.Cotacao;
            oAgenda.Assunto = "Contato Orçamento N° " + oOrcamento.PK_cod_orcamento + " " + oOrcamento.assunto;
            ItemText = "Oportunidade N°: " + oOportunidade.PK_nro_oportunidade + "\r\n";
            ItemText += "Contato Orçamento N°: " + oOrcamento.PK_cod_orcamento + "\r\n";
            ItemText += "Produto: " + oOrcamento.produto + "\r\n";
            ItemText += "Solicitante: " + oOportunidade.contato_nome + "\r\n";
            ItemText += "Telefone: " + oOportunidade.contato_telefone + "\r\n";
            ItemText += "Email: " + oOportunidade.contato_emails;
            oAgenda.Descricao = ItemText;
            oAgenda.Local = "Escritório";
            oAgenda.Recorrencia = string.Empty;
            oAgenda.Despertador = string.Empty;
            oAgenda.Inicio = oOrcamento.proximo_contato;
            oAgenda.Fim = oOrcamento.proximo_contato.Value.AddMinutes(30);
            oAgenda.Dia_Inteiro = false;
            oAgenda.Exportacao = true;
            oAgendaManager.ApplyBudgetScheduler(oAgenda);
            return oAgendaManager;
        }
        protected Oportunidade_JSON EnviaBoasVindas(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            SendEmail oMail = new SendEmail();

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oJSON = oMail.EnviaBoasVindas(oJSON);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
        protected Oportunidade_JSON EnviaOrcamento(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            SendEmail oMail = new SendEmail();

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oJSON = oMail.EnviaOrcamento(oJSON);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
        protected Oportunidade_JSON EnviaOrcamentosAceitos(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações
            //**************
            SendEmail oMail = new SendEmail();

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oJSON = oMail.EnviaOrcamentosAceitos(oJSON);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            //**************
            //* Declarações
            //**************
            Int32 Nro_Oportunidade = 0;

            //***************************
            //* Edição ou novo registro?
            //***************************
            if (Request.QueryString["codigo"] == null)
                Nro_Oportunidade = 0;
            else
                Nro_Oportunidade = Convert.ToInt32(Request.QueryString["codigo"]);

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
                if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                {
                    //**********************************************************
                    //* Evita falha de redirecionamento quando em CallBack Mode
                    //**********************************************************
                    if (!Page.IsCallback)
                        Response.Redirect("~/abertura.aspx", false);
                    else
                        ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
                }

                //*************************************************
                //* Define acesso à inclusão, alteração e exclusão
                //*************************************************
                if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                    Security_Insert = true;
                if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                    Security_Update = true;

                //************************************
                //* Possui permissão para a operação?
                //************************************
                if ((!Security_Insert && Nro_Oportunidade == 0) || (!Security_Update && Nro_Oportunidade != 0))
                {
                    //**********************************************************
                    //* Evita falha de redirecionamento quando em CallBack Mode
                    //**********************************************************
                    if (!Page.IsCallback)
                        Response.Redirect("abertura.aspx", false);
                    else
                        ASPxWebControl.RedirectOnCallback("abertura.aspx");
                }

            #endregion

            //**************************
            //* Popula listas de opções
            //**************************
            if (!IsCallback)
                PopulaAbertura(Nro_Oportunidade);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //*****************************************
            //* Apenas no Callback ou na Inicialização
            //*****************************************
            if (IsCallback || !IsPostBack)
            {
            }
        }
        protected void clbAtualizar_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            //**********************************
            //* É uma chamada de inicializãção?
            //**********************************
            if (e.Parameter == string.Empty)
            {
                //**************
                //* Declarações
                //**************
                Int32 Nro_Oportunidade = 0;

                //***************************
                //* Edição ou novo registro?
                //***************************
                if (Request.QueryString["codigo"] == null)
                    Nro_Oportunidade = 0;
                else
                    Nro_Oportunidade = Convert.ToInt32(Request.QueryString["codigo"]);

                //******************************
                //* Popula dados no objeto JSON
                //******************************
                PopulaJSON(Nro_Oportunidade);

                //*******************************
                //* Devolve estrutura JSON vazia
                //*******************************
                e.Result = new JavaScriptSerializer().Serialize(oJSON);
            }
            else
            {
                //*************************
                //* Deserializa requisição
                //*************************
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                oJSON = oSerializer.Deserialize<Oportunidade_JSON>(e.Parameter);

                //******************************
                //* Executa operação solicitada
                //******************************
                switch (oJSON.operacao)
                {
                    case "Salvar_Etapa1":

                        //*************************************
                        //* Coleta código da nova oportunidade
                        //*************************************
                        SalvaEtapa1(oJSON);

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Salvar_Etapa2":

                        //**********************************
                        //* Coleta código do novo orçamento
                        //**********************************
                        SalvaEtapa2(oJSON);

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Salvar_Etapa3":

                        //********************************
                        //* Atualiza dados da etapa final
                        //********************************
                        SalvaEtapa3(oJSON);

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Excluir_Orcamento":

                        //**********************************
                        //* Coleta código do novo orçamento
                        //**********************************
                        ExcluiOrcamento(oJSON);

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Enviar_Boas_Vindas":

                        //**********************************
                        //* Coleta código do novo orçamento
                        //**********************************
                        if (oJSON.oportunidade.PK_nro_oportunidade != 0)
                        {
                            //*****************
                            //* Obtem resposta
                            //*****************
                            oJSON = EnviaBoasVindas(oJSON);

                            //*************************
                            //* Devolve estrutura JSON
                            //*************************
                            e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        }
                        break;

                    case "Enviar_Orcamento":

                        //**********************************
                        //* Coleta código do novo orçamento
                        //**********************************
                        if (oJSON.orcamentos[0].PK_cod_orcamento != 0)
                        {
                            //*****************
                            //* Obtem resposta
                            //*****************
                            oJSON = EnviaOrcamento(oJSON);

                            //*************************
                            //* Devolve estrutura JSON 
                            //*************************
                            e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        }
                        break;

                    case "Enviar_Orcamentos_Aceitos":

                        //**********************************
                        //* Coleta código do novo orçamento
                        //**********************************
                        if (oJSON.orcamentos[0].PK_cod_orcamento != 0)
                        {
                            //*****************
                            //* Obtem resposta
                            //*****************
                            oJSON = EnviaOrcamentosAceitos(oJSON);

                            //*************************
                            //* Devolve estrutura JSON 
                            //*************************
                            e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        }
                        break;

                    case "Coletar_Resposta":

                        //**************
                        //* Declarações
                        //**************
                        Oportunidade_Orcamentos_Manager oManager;
                        oManager = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(Session["Decision_LoginInfo"]));
                        Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
                        Int32 IndiceOrcamento = 0;
                        Int32 CodOrcamento = 0;

                        //*********************************
                        //* Obtem dados do orçamento atual
                        //*********************************
                        CodOrcamento = Convert.ToInt32(oJSON.parametros["CodigoOrcamento"]);
                        oOrcamento = oManager.GetRecord(CodOrcamento);

                        //*******************************
                        //* Foi possível obter os dados?
                        //*******************************
                        if (!oManager.Error && oOrcamento.PK_cod_orcamento != 0)
                        {
                            //***********************
                            //* O cliente respondeu?
                            //***********************
                            if (oOrcamento.html_resposta != string.Empty)
                            {
                                //********************************
                                //* Desfaz pendência do orçamento
                                //********************************
                                oOrcamento.pendencia = false;
                                oManager.ApplyRecord(oOrcamento);

                                //*******************************
                                //* Devolve orçamento atualizado
                                //*******************************
                                for (IndiceOrcamento = 0; IndiceOrcamento < oJSON.orcamentos.Length; IndiceOrcamento++)
                                {
                                    if (oJSON.orcamentos[IndiceOrcamento].PK_cod_orcamento == oOrcamento.PK_cod_orcamento)
                                        oJSON.orcamentos[IndiceOrcamento] = oOrcamento;
                                }
                            }
                        }

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;

                    case "Salvar_Comentario_Interno":

                        //********************************
                        //* Atualiza dados da etapa final
                        //********************************
                        SalvaComentarioInterno(oJSON);

                        //*************************
                        //* Devolve estrutura JSON 
                        //*************************
                        e.Result = new JavaScriptSerializer().Serialize(oJSON);
                        break;
                }
            }
        }
        protected void cmdRetornar_Click(object sender, EventArgs e)
        {
            //***********************
            //* Obtem URL de retorno
            //***********************
            if (Request.QueryString["back"] != null)
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect(Request.QueryString["back"], false);
                else
                    ASPxWebControl.RedirectOnCallback(Request.QueryString["back"]);
            }
        }
    }
}