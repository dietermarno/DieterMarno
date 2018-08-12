using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decision.Database;
using Decision.TableManager;
using DevExpress.Web;

namespace Decision
{
    public partial class oportunidades_boasvindas_email : System.Web.UI.Page
    {
        public Int32 CodigoMaster = 0;
        public Int32 CodigoPosto = 0;
        public Int32 CodigoOportunidade = 0;
        public Int32 CodigoOrcamento = 0;
        public string Conexao = string.Empty;
        public string HTML_Base = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Inicialização"

            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            HTML_Base = Properties.Settings.Default.html_base;

            //********************
            //* Declara variáveis
            //********************
            Oportunidade_Manager oOportunidadeManager;
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();

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
                    //**********************
                    //* Número do orçamento
                    //**********************
                    this.lblNroOrcamento.Text = "Oportunidade Nº " + oOportunidade.PK_nro_oportunidade;
                    this.lblNovoContato.Text = "Faremos contato em breve.";
                    if (oOportunidade.proximo_contato != null)
                        if (oOportunidade.proximo_contato > DateTime.Now)
                        {
                            //********************************************
                            //* Converte formato da data e altera retorno
                            //********************************************
                            DateTime Contato = (DateTime)oOportunidade.data_retorno;
                            this.lblNovoContato.Text = "Faremos contato até " + Contato.ToString("dd/MM/yyyy") + ".";
                        }
                }
            }

            #endregion
        }
    }
}