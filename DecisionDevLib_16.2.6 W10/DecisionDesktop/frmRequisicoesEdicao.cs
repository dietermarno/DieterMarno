using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Decision.LoginManager;
using Decision.TableManager;
using Decision.Lists;

namespace DecisionDesktop
{
    public partial class frmRequisicaoEdicao2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //********************************************
        //* Cria classe global para controle de login
        //********************************************
        public Login_Manager UserLogin = new Login_Manager();

        //**********************
        //* Dados da requisição
        //**********************
        Requisicao_Fields oRequisicao = new Requisicao_Fields();
        private void PopulaListaRequisicoes(Int32 NroProcesso, Int32 NroRequisicao)
        {
            //**************
            //* Declarações
            //**************
            Requisicao_Manager oRequisicaoManager = new Requisicao_Manager(UserLogin.LoginInfo.Master_DevArtConexaoString);
            DevExpress.XtraTreeList.Nodes.TreeListNode oRootNode = null;
            DevExpress.XtraTreeList.Nodes.TreeListNode oNode = null;

            //***********************
            //* Anula lista anterior
            //***********************
            this.trvProdutos.BeginUpdate();
            this.trvProdutos.Nodes.Clear();
            
            //***********************************************
            //* Obtem lista de requisições do processo atual
            //***********************************************
            List<Lista_Requesicoes_Fields> oRequisicoes = oRequisicaoManager.GetReqsFromProcess(NroProcesso);

            //****************************
            //* Insere registros na lista
            //****************************
            foreach (Lista_Requesicoes_Fields oRequisicao in oRequisicoes)
            {
                //**************************************
                //* Insere ítem na lista de requisições
                //**************************************
                oNode = this.trvProdutos.AppendNode(new object[] { oRequisicao.NroRequis,
                                                                   oRequisicao.Produto,
                                                                   oRequisicao.Pax,
                                                                   oRequisicao.DataIn,
                                                                   oRequisicao.DataOut }, 
                                                                   oRootNode);
                //*************************************
                //* Deve selecionar a requsição atual?
                //*************************************
                if (oRequisicao.NroRequis == NroRequisicao)
                    oNode.Selected = true;
            }

            //**********************
            //* Conclui atualização
            //**********************
            this.trvProdutos.EndUpdate();
        }
        private void PopulaComboCliente()
        {
            //***************************
            //* Popula lista de clientes
            //***************************
            List<ComboDataList> oCliente = ComboBinder.ComboClientes(UserLogin.LoginInfo.Master_DevArtConexaoString);
            this.cboCliente.Properties.DataSource = oCliente;
            this.cboCliente.Properties.ValueMember = "ID";
            this.cboCliente.Properties.DisplayMember = "Column1";
        }
        private void PopulaComboUnidadeNegocio()
        {
            //***************************
            //* Popula lista de clientes
            //***************************
            List<ComboDataList> oUnidade = ComboBinder.ComboUnidadeNegocio(UserLogin.LoginInfo.Master_DevArtConexaoString);
            this.cboUnidade.Properties.DataSource = oUnidade;
            this.cboUnidade.Properties.ValueMember = "ID";
            this.cboUnidade.Properties.DisplayMember = "Column1";
        }
        private void PopulaProcesso(Int32 CodProcesso, Int32 CodRequisicao)
        {
            //******************************
            //* Popula lista de requisições
            //******************************
            PopulaListaRequisicoes(CodProcesso, CodRequisicao);

            //***********************
            //* Popula demais campos
            //***********************
            this.txtNroProcesso.EditValue = oRequisicao.NroProcesso;
            this.dteAbertura.EditValue = oRequisicao.DtLanctoReq;
            this.cboCliente.EditValue = oRequisicao.CodCli;
            this.cboUnidade.EditValue = oRequisicao.CodPosto;
        }
        public frmRequisicaoEdicao2(Login_Manager LoginData)
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
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //**********************
            //* Finaliza formulário
            //**********************
            this.Dispose();
        }
        private void frmRequisicaoEdicao_Activated(object sender, EventArgs e)
        {
            //*****************************
            //* Obtem registro selecionado
            //*****************************
            System.Data.DataRowView oRowRequisicao = (System.Data.DataRowView)this.Tag;

            //**********************************
            //* Obtem dados da requisição atual
            //**********************************
            Requisicao_Manager oManagerRequisicao = new Requisicao_Manager(UserLogin.LoginInfo.Master_DevArtConexaoString);
            oRequisicao = oManagerRequisicao.GetRecord(Convert.ToInt32(oRowRequisicao["NroRequis"]));

            //**************************************
            //* Popula lista de unidades de negócio
            //**************************************
            PopulaComboUnidadeNegocio();

            //***************************
            //* Popula lista de clientes
            //***************************
            PopulaComboCliente();

            //***************************
            //* Popula dados do processo
            //***************************
            PopulaProcesso(Convert.ToInt32(oRowRequisicao["NroProcesso"]), Convert.ToInt32(oRowRequisicao["NroRequis"]));
        }
        private void bbiExcluirProduto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show(this.cboCliente.EditValue.ToString());
            MessageBox.Show(this.cboUnidade.EditValue.ToString());
        }
        private void bbiAdicionarProduto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.gpcEdicao.Enabled = true;
            this.gpcEdicao.Visible = true;
        }
    }
}
