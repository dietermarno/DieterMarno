using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using Decision.Database;
using Decision.TableManager;
using DevExpress.Web;
using DevExpress.Web.ASPxHtmlEditor;

namespace Decision
{
    public partial class oportunidades_email : System.Web.UI.Page
    {
        public string HTML_Base = string.Empty;
        public string Conexao = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Inicialização"

            //********************
            //* Declara variáveis
            //********************
            Oportunidade_Orcamentos_Manager oOrcamentosManager;
            Oportunidade_Manager oOportunidadeManager;
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
            ASPxSpinEdit oSpin = new ASPxSpinEdit();
            ASPxComboBox oCombo = new ASPxComboBox();
            ASPxDateEdit oData = new ASPxDateEdit();
            ASPxTextBox oText = new ASPxTextBox();
            ASPxMemo oMemo = new ASPxMemo();
            ASPxButton oButton = new ASPxButton();
            Int32 CodigoMaster = 0;
            Int32 CodigoPosto = 0;
            Int32 CodigoOportunidade = 0;
            Int32 CodigoOrcamento = 0;

            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            HTML_Base = Properties.Settings.Default.html_base;

            #endregion

            #region "Conexao"

            //*************************************************
            //* O código da agência e da proposta são válidos?
            //*************************************************
            if (Request.QueryString["CMA"] != null && Request.QueryString["CPO"] != null &&
                Request.QueryString["COP"] != null && Request.QueryString["COR"] != null)
                {
                    //********************************************
                    //* Coleta códigos (master, posto e proposta)
                    //********************************************
                    CodigoMaster = Convert.ToInt32("0" + Request.QueryString["CMA"]);
                    this.txtCodigoMaster.Value = txtCodigoMaster.ToString();

                    CodigoPosto = Convert.ToInt32("0" + Request.QueryString["CPO"]);
                    this.txtCodigoPosto.Value = txtCodigoPosto.ToString();

                    CodigoOportunidade = Convert.ToInt32("0" + Request.QueryString["COP"]);
                    this.txtCodigoOportunidade.Value = txtCodigoOportunidade.ToString();

                    CodigoOrcamento = Convert.ToInt32("0" + Request.QueryString["COR"]);
                    this.txtCodigoOrcamento.Value = txtCodigoOrcamento.ToString();
                
                    //**************************
                    //* Obtém string de conexão
                    //**************************
                    Conexao = DBConnection.GetConnectionFromMaster(CodigoMaster);
                }
                else
                {
                    //********************************
                    //* Rediciona para página de erro
                    //********************************
                    Response.Redirect("http://www.presser.com.br", false);
                }
            
            #endregion

            #region "Dados da agência"

            //***************************
            //* A nova conexão é válida?
            //***************************
            if (Conexao.IndexOf("Error") == -1)
            {
                //********************************************************
                //* Inicia gerenciador da tabela posto com a nova conexão
                //********************************************************
                Posto_Manager oPostoManager = new Posto_Manager(Conexao);
                Posto_Fields oPosto = new Posto_Fields();

                //****************************
                //* Exibe logotipo da agência
                //****************************
                imgLogotipo.Value = oPostoManager.GetPicture(CodigoPosto);

                //***********************
                //* Obtém dados do posto
                //***********************
                oPosto = oPostoManager.Get_Posto(CodigoPosto);

                //*********************
                //* Executou sem erro?
                //*********************
                if (!oPostoManager.Error)
                {
                    //**************************
                    //* Popula dados da agência
                    //**************************
                    this.lblNomePosto.Text = oPosto.NomePosto;
                    if (this.lblNomePosto.Text != "" && oPosto.DescPosto != "")
                        this.lblNomePosto.Text += " (" + oPosto.DescPosto + ")";

                    this.lblEndereco.Text = oPosto.End;
                    if (this.lblEndereco.Text != "" && oPosto._NomeCidade != "")
                        this.lblEndereco.Text += " - " + oPosto._NomeCidade;
                    else
                        this.lblEndereco.Text += oPosto._NomeCidade;

                    if (this.lblEndereco.Text != "" && oPosto._UF != "")
                        this.lblEndereco.Text += " - " + oPosto._UF;
                    else
                        this.lblEndereco.Text += oPosto._UF;

                    if (this.lblEndereco.Text != "" && oPosto.CEP != "")
                        this.lblEndereco.Text += " - " + oPosto.CEP;
                    else
                        this.lblEndereco.Text += oPosto.CEP;

                    if (oPosto.HTTP != "")
                        this.lblContato.Text = "Internet: " + oPosto.HTTP;

                    if (this.lblContato.Text != "" && oPosto.EMail != "")
                        this.lblContato.Text += "\nE-mail: " + oPosto.EMail;
                    else
                        this.lblContato.Text += "E-mail: " + oPosto.EMail;

                    if (this.lblContato.Text != "" && oPosto.Fone1 != "")
                        this.lblContato.Text += "\nFone: " + oPosto.Fone1;
                    else
                        this.lblContato.Text += "Fone: " + oPosto.Fone1;

                    if (this.lblContato.Text != "" && oPosto.Fone2 != "")
                        this.lblContato.Text += " / " + oPosto.Fone2;
                    else
                        this.lblContato.Text += oPosto.Fone2;
                }
            }

            #endregion

            #region "Dados da oportunidade"

            //***************************
            //* A nova conexão é válida?
            //***************************
            if (Conexao.IndexOf("Error") == -1)
            {
                //*******************************
                //* Inicializa string de conexão
                //*******************************
                oOportunidadeManager = new Oportunidade_Manager(Conexao);

                //******************************
                //* Obtém dados da oportunidade
                //******************************
                oOportunidade = oOportunidadeManager.GetRecord(CodigoOportunidade);

                //****************************
                //* Encontrou a oportunidade?
                //****************************
                if (oOportunidade.PK_nro_oportunidade != 0)
                {
                    //*********************************
                    //* Obtém registro e popula campos
                    //*********************************
                    oText = this.layAbertura.FindControl("txtDestino") as ASPxTextBox;
                    oText.Text = oOportunidade.destino;

                    oData = this.layAbertura.FindControl("dteSaida") as ASPxDateEdit;
                    oData.Value = oOportunidade.data_saida;

                    oData = this.layAbertura.FindControl("dteRetorno") as ASPxDateEdit;
                    oData.Value = oOportunidade.data_retorno;

                    oText = this.layAbertura.FindControl("txtAdultos") as ASPxTextBox;
                    oText.Value = oOportunidade.quantidade_adultos;

                    oText = this.layAbertura.FindControl("txtCriancas") as ASPxTextBox;
                    oText.Value = oOportunidade.quantidade_criancas;

                    oMemo = this.layAbertura.FindControl("memDescricao") as ASPxMemo;
                    oMemo.Text = oOportunidade.descricao;

                    //******************************
                    //* O orçamento está encerrado?
                    //******************************
                    if (oOrcamento.estagio_orcamento == (int)Lists.OptionLists.OrcamentoEstagio.Aceito)
                    {
                        //*************************************************
                        //* Apresenta grupo de informações de encerramento
                        //*************************************************
                        this.layEncerramento.Visible = true;

                        //************************************
                        //* Exibe informações de encerramento
                        //************************************
                        oSpin = this.layEncerramento.FindControl("txtValorEncerramento") as ASPxSpinEdit;
                        oSpin.Value = oOportunidade.valor_fechado;

                        oData = this.layEncerramento.FindControl("dteEncerramento") as ASPxDateEdit;
                        oData.Value = oOportunidade.data_encerramento;
                    }
                    else
                    {
                        //**********************************************
                        //* Oculta grupo de informações de encerramento
                        //**********************************************
                        this.layEncerramento.Visible = false;
                    }
                }
            }

            #endregion

            #region "Dados do orçamento"

            //*******************************
            //* Inicializa string de conexão
            //*******************************
            oOrcamentosManager = new Oportunidade_Orcamentos_Manager(Conexao);

            //***************************
            //* A nova conexão é válida?
            //***************************
            if (Conexao.IndexOf("Error") == -1)
            {
                //***************************
                //* Obtém dados do orçamento
                //***************************
                oOrcamento = oOrcamentosManager.GetRecord(CodigoOrcamento);

                //*********************************
                //* Obtém registro e popula campos
                //*********************************
                oText = this.layAbertura.FindControl("txtProduto") as ASPxTextBox;
                oText.Text = oOrcamento.produto;

                oText = this.layAbertura.FindControl("txtAssunto") as ASPxTextBox;
                oText.Text = oOrcamento.assunto;

                oSpin = this.layAbertura.FindControl("txtValorOrcamento") as ASPxSpinEdit;
                oSpin.Value = oOrcamento.valor;

                //******************************
                //* O orçamento foi localizado?
                //******************************
                if (oOrcamento.PK_cod_orcamento != 0)
                {
                    //**********************
                    //* Número do orçamento
                    //**********************
                    this.lblNroOrcamento.Text = "Oportunidade Nº " + oOrcamento.nro_oportunidade + " - ";
                    this.lblNroOrcamento.Text += "Orçamento Nº " + oOrcamento.PK_cod_orcamento.ToString();
                    this.divOrcamento.InnerHtml = oOrcamento.html_orcamento;
                    this.htmResposta.Html = oOrcamento.html_resposta;
                }
            }

            #endregion
        }
        protected void htmResposta_CustomDataCallback(object sender, DevExpress.Web.CustomDataCallbackEventArgs e)
        {
            //**************
            //* Declarações
            //**************
            Agenda_Apontamentos_Manager oAgendaManager = new Agenda_Apontamentos_Manager(Conexao);
            Agenda_Apontamentos_Fields oAgenda = new Agenda_Apontamentos_Fields();
            Oportunidade_Manager oOportunidadeManager = new Oportunidade_Manager(Conexao);
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
            Oportunidade_Orcamentos_Manager oOrcamentosManager = new Oportunidade_Orcamentos_Manager(Conexao);
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
            string[] Parameters = e.Parameter.Split('|');
            string ItemText = string.Empty;
            Int32 CodigoMaster = 0;
            Int32 CodigoPosto = 0;
            Int32 CodigoOportunidade = 0;
            Int32 CodigoOrcamento = 0;

            //*************************************************
            //* O código da agência e da proposta são válidos?
            //*************************************************
            if (Request.QueryString["CMA"] != null && Request.QueryString["CPO"] != null &&
                Request.QueryString["COP"] != null && Request.QueryString["COR"] != null)
            {
                //********************************************
                //* Coleta códigos (master, posto e proposta)
                //********************************************
                CodigoMaster = Convert.ToInt32("0" + Request.QueryString["CMA"]);
                CodigoPosto = Convert.ToInt32("0" + Request.QueryString["CPO"]);
                CodigoOportunidade = Convert.ToInt32("0" + Request.QueryString["COP"]);
                CodigoOrcamento = Convert.ToInt32("0" + Request.QueryString["COR"]);
            }

            //**************************************
            //* Executa atualização da oportunidade
            //**************************************
            oOportunidade = oOportunidadeManager.GetRecord(CodigoOportunidade);
            oOportunidade.cod_situacao = (int)Lists.OptionLists.OportunidadeStuacao.Analise;
            oOportunidadeManager.ApplyRecord(oOportunidade);

            //***********************************
            //* Executa atualização do orçamento
            //***********************************
            oOrcamento.html_resposta = this.htmResposta.Html;
            oOrcamento.PK_cod_orcamento = CodigoOrcamento;
            if (oOrcamentosManager.UpdateBudgetAnswer(oOrcamento))
            {
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
                oAgenda.Assunto = "Resposta Orçamento N° " + oOrcamento.PK_cod_orcamento + " " + oOrcamento.assunto;
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
                oAgenda.Inicio = DateTime.Now.AddDays(1);
                oAgenda.Fim = oAgenda.Inicio.Value.AddMinutes(30);
                oAgenda.Dia_Inteiro = false;
                oAgenda.Exportacao = true;
                oAgendaManager.ApplyBudgetScheduler(oAgenda);

                //**************************
                //* Houve erro na operação?
                //**************************
                if (!oAgendaManager.Error)
                {
                    //*****************
                    //* Não houve erro
                    //*****************
                    e.Result = "Ok";
                }
                else
                {
                    //***************
                    //* Retorna erro
                    //***************
                    e.Result = oAgendaManager.ErrorText;
                }
            }
            else
            {
                //********
                //* Falha
                //********
                e.Result = "Error";
            }
        }
    }
}