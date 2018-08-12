using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using Decision.LoginManager;
using Decision.Database;

namespace DecisionDesktop
{
    public partial class frmRequisicoes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //********************************************
        //* Cria classe global para controle de login
        //********************************************
        public Login_Manager UserLogin = new Login_Manager();
        public void PopulaRequisicoes()
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(UserLogin.LoginInfo.Master_DevArtConexaoString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT ";
            SQL += "requisicao.NroProcesso,";
            SQL += "posto.NomePosto,";
            SQL += "clientes1.Nome AS cliente,";
            SQL += "requisicao.NroRequis,";
            SQL += "requisicao.Status,";
            SQL += "produtos.DescProd AS produto,";
            SQL += "consolidador.Nome AS consolidador,";
            SQL += "fornecedor.Nome AS fornecedor,";
            SQL += "requisicao.NroTkt,";
            SQL += "requisicao.CentroCusto,";
            SQL += "requisicao.Pax,";
            SQL += "requisicao.Trecho,";
            SQL += "emissor.NomePromotor AS Emissor,";
            SQL += "grupo.DescAgrup,";
            SQL += "evento.DescEvento,";
            SQL += "requisicao.Obs1 AS observacoes,";
            SQL += "requisicao.DtLanctoReq AS Abertura,";
            SQL += "requisicao.Emissao,";
            SQL += "requisicao.NumVoucher,";
            SQL += "requisicao.DtViagem AS Saida,";
            SQL += "requisicao.DtRetorno AS Retorno,";
            SQL += "requisicao.NroFatura,";
            SQL += "requisicao.DtVencto AS Vencimento,";
            SQL += "requisicao.NossaNFCli,";
            SQL += "requisicao.DoctoBaixa,";
            SQL += "requisicao.NossaNF AS NossaNFFor ";
            SQL += "FROM requisicao ";
            SQL += "LEFT JOIN posto ON posto.PostoVen = requisicao.CodPosto ";
            SQL += "LEFT JOIN clientes2 ON clientes2.CodCli = requisicao.CodCli ";
            SQL += "LEFT JOIN clientes1 ON clientes1.CodCli = clientes2.CodCli ";
            SQL += "LEFT JOIN produtos ON produtos.CodProd = requisicao.CodProduto ";
            SQL += "LEFT JOIN fornecedor AS consolidador ON consolidador.CodFornec = requisicao.CodConsolidador ";
            SQL += "LEFT JOIN fornecedor AS fornecedor ON fornecedor.CodFornec = requisicao.CodFornec ";
            SQL += "LEFT JOIN promotor AS emissor ON emissor.CodPromotor = requisicao.CodEmissor ";
            SQL += "LEFT JOIN agrupamento AS grupo ON grupo.CodAgrup = requisicao.CodAgrup ";
            SQL += "LEFT JOIN evento ON evento.CodEvento = requisicao.CodEvento";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        this.grcRequisicoes.DataSource = oTable;
        }
        public frmRequisicoes(Login_Manager LoginData)
        {
            //***********************
            //* Inicializa interface
            //***********************
            InitializeComponent();

            //*******************************
            //* Instancia login publicamente
            //*******************************
            UserLogin = LoginData;
        }
        private void bbiExibirFiltro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //***************
            //* Exibe filtro
            //***************
            grvRequisicoes.ShowFilterEditor(grvRequisicoes.Columns["Pax"]);
        }
        private void bbiEliminarFiltro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //****************
            //* Anula filtros
            //****************
            grvRequisicoes.ActiveFilter.Clear();
        }
        private void grcRequisicoes_DoubleClick(object sender, EventArgs e)
        {
            //*****************************
            //* Obtem registro selecionado
            //*****************************
            System.Data.DataRowView oRow = (System.Data.DataRowView)this.grvRequisicoes.GetFocusedRow();

            //******************
            //* Existe seleção?
            //******************
            if (oRow != null)
            {
                //*****************************
                //* Exibe edição da requisição
                //*****************************
                frmRequisicaoEdicao2 oForm = new frmRequisicaoEdicao2(UserLogin);
                oForm.Text = "Alteração da Requisição Nº " + oRow["NroRequis"];
                oForm.Tag = oRow;
                oForm.MdiParent = this.MdiParent;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.Show();
            }
        }
        private void bbiIncluir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //*******************************
            //* Exibe inclusão da requisição
            //*******************************
            frmRequisicaoEdicao2 oForm = new frmRequisicaoEdicao2(UserLogin);
            oForm.Text = "Inclusão de Requisição";
            oForm.Tag = null;
            oForm.MdiParent = this.MdiParent;
            oForm.WindowState = FormWindowState.Maximized;
            oForm.Show();
        }
        private void bbiAlterar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //*****************************
            //* Obtem registro selecionado
            //*****************************
            Devart.Common.DbDataRowView oRow = (Devart.Common.DbDataRowView)this.grvRequisicoes.GetFocusedRow();

            //******************
            //* Existe seleção?
            //******************
            if (oRow != null)
            {
                //*****************************
                //* Exibe edição da requisição
                //*****************************
                frmRequisicaoEdicao2 oForm = new frmRequisicaoEdicao2(UserLogin);
                oForm.Text = "Alteração da Requisição Nº " + oRow["NroRequis"];
                oForm.Tag = oRow["NroRequis"];
                oForm.MdiParent = this.MdiParent;
                oForm.WindowState = FormWindowState.Maximized;
                oForm.Show();
            }
        }
        private void frmRequisicoes_Activated(object sender, EventArgs e)
        {
            //***************
            //* Popula lista
            //***************
            PopulaRequisicoes();
        }
    }
}
