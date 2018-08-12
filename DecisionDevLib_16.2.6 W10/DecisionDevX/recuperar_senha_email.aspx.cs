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
    public partial class recuperar_senha_email : System.Web.UI.Page
    {
        public Int32 CodigoMaster = 0;
        public Int32 CodigoPosto = 0;
        public string Conexao = string.Empty;
        public string HTML_Base = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Inicialização"

            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            HTML_Base = Properties.Settings.Default.html_base;

            #endregion

            #region "Conexao"

            //***********************************************
            //* Os códigos do master e do posto são válidos?
            //***********************************************
            if (Request.QueryString["CMA"] != null && Request.QueryString["CPO"] != null)
            {
                //********************************************
                //* Coleta códigos (master, posto e proposta)
                //********************************************
                CodigoMaster = Convert.ToInt32("0" + Request.QueryString["CMA"]);
                this.txtCodigoMaster.Value = txtCodigoMaster.ToString();

                CodigoPosto = Convert.ToInt32("0" + Request.QueryString["CPO"]);
                this.txtCodigoPosto.Value = txtCodigoPosto.ToString();

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

            #region "Dados de recuperação de senha"

            //***************************
            //* A nova conexão é válida?
            //***************************
            if (Conexao.IndexOf("Error") == -1)
            {
                //**************************************************
                //* O nome da empresa, usuario e senha são válidos?
                //**************************************************
                if (Request.QueryString["empresa"] != null && Request.QueryString["email"] != null &&
                    Request.QueryString["usuario"] != null && Request.QueryString["senha"] != null)
                {
                    lblEmpresa.Text = Request.QueryString["empresa"];
                    lblUsuario.Text = Request.QueryString["usuario"];
                    lblSenha.Text = Request.QueryString["senha"];
                }
            }

            #endregion
        }
    }
}