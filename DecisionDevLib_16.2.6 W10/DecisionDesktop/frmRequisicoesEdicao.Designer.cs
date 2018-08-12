namespace DecisionDesktop
{
    partial class frmRequisicaoEdicao2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequisicaoEdicao2));
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            this.mrcMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.popSalvar = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAdicionarProduto = new DevExpress.XtraBars.BarButtonItem();
            this.popProdutos = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiAereo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHospedagem = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLocacao = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTransfer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCruzeiro = new DevExpress.XtraBars.BarButtonItem();
            this.bbiServicos = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAlterarProduto = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExcluirProduto = new DevExpress.XtraBars.BarButtonItem();
            this.rpgMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSalvar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgAcoesProdutos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSelecaoProdutos = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bdcMenuControler = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            this.txtNroProcesso = new DevExpress.XtraEditors.TextEdit();
            this.dteAbertura = new DevExpress.XtraEditors.DateEdit();
            this.trvProdutos = new DevExpress.XtraTreeList.TreeList();
            this.colNroRequisicao = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colProduto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPassageiro = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDataIn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDataOut = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gpcResumoRequisicao = new DevExpress.XtraEditors.GroupControl();
            this.gpcResumoProcesso = new DevExpress.XtraEditors.GroupControl();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.lblNroProcesso = new DevExpress.XtraEditors.LabelControl();
            this.lblAbertura = new DevExpress.XtraEditors.LabelControl();
            this.lblUnidade = new DevExpress.XtraEditors.LabelControl();
            this.gpcDadosProcesso = new DevExpress.XtraEditors.GroupControl();
            this.cboCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.cboUnidade = new DevExpress.XtraEditors.LookUpEdit();
            this.sctDivisorGeral = new DevExpress.XtraEditors.SplitContainerControl();
            this.sctResumos = new DevExpress.XtraEditors.SplitContainerControl();
            this.gpcEdicao = new DevExpress.XtraEditors.GroupControl();
            this.layFormulario = new DevExpress.XtraLayout.LayoutControl();
            this.txtNroVoucher = new DevExpress.XtraEditors.TextEdit();
            this.txtConversaoLiquido = new DevExpress.XtraEditors.TextEdit();
            this.dteDataRetorno = new DevExpress.XtraEditors.DateEdit();
            this.txtConversaoCambio = new DevExpress.XtraEditors.TextEdit();
            this.dteDataSaida = new DevExpress.XtraEditors.DateEdit();
            this.txtLiquido = new DevExpress.XtraEditors.TextEdit();
            this.txtEntradaCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtAcrescimo = new DevExpress.XtraEditors.TextEdit();
            this.txtDesconto = new DevExpress.XtraEditors.TextEdit();
            this.txtSinalFornecedor = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxaAdministrativa = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxaIntermediacao = new DevExpress.XtraEditors.TextEdit();
            this.txtTaxasExtras = new DevExpress.XtraEditors.TextEdit();
            this.txtTarifaUtilizada = new DevExpress.XtraEditors.TextEdit();
            this.txtTarifaCheia = new DevExpress.XtraEditors.TextEdit();
            this.cboVendaMoeda = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboVendaFormaPagamento = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboVendaTipo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memObservacao = new DevExpress.XtraEditors.MemoEdit();
            this.cboEvento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboGrupo = new DevExpress.XtraEditors.LookUpEdit();
            this.cboEmissor = new DevExpress.XtraEditors.LookUpEdit();
            this.memTrechoPeriodo = new DevExpress.XtraEditors.MemoEdit();
            this.memPAX = new DevExpress.XtraEditors.MemoEdit();
            this.cboCentroCusto = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTKTStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTKTNumero = new DevExpress.XtraEditors.TextEdit();
            this.txtProdutoQuantidade = new DevExpress.XtraEditors.TextEdit();
            this.cboFornecedor = new DevExpress.XtraEditors.LookUpEdit();
            this.cboConsolidador = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProduto = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRLOCAtt = new DevExpress.XtraEditors.TextEdit();
            this.cboRequisicaoStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNroRequisicao = new DevExpress.XtraEditors.TextEdit();
            this.dteDataEmissao = new DevExpress.XtraEditors.DateEdit();
            this.lcgFrontOfficeVendas = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciDataEmissao = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRequisicaoStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNroRequisicao = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciProduto = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciRLOCAtt = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciProdutoQuantidade = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPAX = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCentroCusto = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEvento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGrupo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciObservacao = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciReservaVoucher = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmissor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTrechoPeriodo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConsolidador = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFornecedor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTKTNumero = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTKTNumerok = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVendaFormaPagamento = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVendaTipo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTotalTarifaCheia = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTotalTarifaUtilizada = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTotalTaxasExtras = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTaxaIntermediacao = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciTaxaAdministrativa = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSinalFornecedor = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDesconto = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAcrescimo = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEntradaCliente = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLiquido = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciVendaMoeda = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDataSaida = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConversaoCambio = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDataRetorno = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConversaoLiquido = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Root2 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.mrcMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroProcesso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteAbertura.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteAbertura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResumoRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResumoProcesso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcDadosProcesso)).BeginInit();
            this.gpcDadosProcesso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sctDivisorGeral)).BeginInit();
            this.sctDivisorGeral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sctResumos)).BeginInit();
            this.sctResumos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEdicao)).BeginInit();
            this.gpcEdicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layFormulario)).BeginInit();
            this.layFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroVoucher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConversaoLiquido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataRetorno.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataRetorno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConversaoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataSaida.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataSaida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntradaCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcrescimo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinalFornecedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxaAdministrativa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxaIntermediacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxasExtras.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaUtilizada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaCheia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaMoeda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaFormaPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memObservacao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEvento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmissor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memTrechoPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPAX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCentroCusto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTKTStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKTNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdutoQuantidade.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFornecedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboConsolidador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRLOCAtt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequisicaoStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRequisicao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataEmissao.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataEmissao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrontOfficeVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataEmissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRequisicaoStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRLOCAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProdutoQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCentroCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEvento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciObservacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReservaVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmissor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTrechoPeriodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConsolidador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTKTNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTKTNumerok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaFormaPagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTarifaCheia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTarifaUtilizada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTaxasExtras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTaxaIntermediacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTaxaAdministrativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSinalFornecedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAcrescimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEntradaCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLiquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaMoeda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataSaida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConversaoCambio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataRetorno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConversaoLiquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root2)).BeginInit();
            this.SuspendLayout();
            // 
            // mrcMenu
            // 
            this.mrcMenu.ExpandCollapseItem.Id = 0;
            this.mrcMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mrcMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mrcMenu.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.bbiAdicionarProduto,
            this.bbiAlterarProduto,
            this.bbiExcluirProduto,
            this.bbiAereo,
            this.bbiHospedagem,
            this.bbiLocacao,
            this.bbiTransfer,
            this.bbiCruzeiro,
            this.bbiServicos});
            this.mrcMenu.Location = new System.Drawing.Point(0, 0);
            this.mrcMenu.MaxItemId = 49;
            this.mrcMenu.Name = "mrcMenu";
            this.mrcMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpgMenu});
            this.mrcMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.mrcMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mrcMenu.Size = new System.Drawing.Size(889, 146);
            this.mrcMenu.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiSave.Caption = "Salvar";
            this.bbiSave.DropDownControl = this.popSalvar;
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // popSalvar
            // 
            this.popSalvar.ItemLinks.Add(this.bbiSaveAndClose);
            this.popSalvar.ItemLinks.Add(this.bbiSaveAndNew);
            this.popSalvar.Name = "popSalvar";
            this.popSalvar.Ribbon = this.mrcMenu;
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Salvar e fechar";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem1.Text = "Salvar e fechar";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiSaveAndClose.SuperTip = superToolTip1;
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Salvar e incluir";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem2.Text = "Salvar e incluir nova requisição\r\n";
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiSaveAndNew.SuperTip = superToolTip2;
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Desfazer";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem3.Text = "Desfazer alteações";
            superToolTip3.Items.Add(toolTipItem3);
            this.bbiReset.SuperTip = superToolTip3;
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Excluir";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem4.Text = "Excluir requisição";
            superToolTip4.Items.Add(toolTipItem4);
            this.bbiDelete.SuperTip = superToolTip4;
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Fechar";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem5.Text = "Encerrar edição sem salvar";
            superToolTip5.Items.Add(toolTipItem5);
            this.bbiClose.SuperTip = superToolTip5;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // bbiAdicionarProduto
            // 
            this.bbiAdicionarProduto.ActAsDropDown = true;
            this.bbiAdicionarProduto.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiAdicionarProduto.Caption = "Incluir";
            this.bbiAdicionarProduto.DropDownControl = this.popProdutos;
            this.bbiAdicionarProduto.Id = 36;
            this.bbiAdicionarProduto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiAdicionarProduto.ImageOptions.SvgImage")));
            this.bbiAdicionarProduto.Name = "bbiAdicionarProduto";
            this.bbiAdicionarProduto.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem6.Text = "Incluir produto no processo atual";
            superToolTip6.Items.Add(toolTipItem6);
            this.bbiAdicionarProduto.SuperTip = superToolTip6;
            this.bbiAdicionarProduto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdicionarProduto_ItemClick);
            // 
            // popProdutos
            // 
            this.popProdutos.ItemLinks.Add(this.bbiAereo);
            this.popProdutos.ItemLinks.Add(this.bbiHospedagem);
            this.popProdutos.ItemLinks.Add(this.bbiLocacao);
            this.popProdutos.ItemLinks.Add(this.bbiTransfer);
            this.popProdutos.ItemLinks.Add(this.bbiCruzeiro);
            this.popProdutos.ItemLinks.Add(this.bbiServicos);
            this.popProdutos.Name = "popProdutos";
            this.popProdutos.Ribbon = this.mrcMenu;
            // 
            // bbiAereo
            // 
            this.bbiAereo.Caption = "Aéreo";
            this.bbiAereo.Id = 39;
            this.bbiAereo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAereo.ImageOptions.Image")));
            this.bbiAereo.Name = "bbiAereo";
            // 
            // bbiHospedagem
            // 
            this.bbiHospedagem.Caption = "Hospedagem";
            this.bbiHospedagem.Id = 40;
            this.bbiHospedagem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiHospedagem.ImageOptions.Image")));
            this.bbiHospedagem.Name = "bbiHospedagem";
            // 
            // bbiLocacao
            // 
            this.bbiLocacao.Caption = "Locação";
            this.bbiLocacao.Id = 41;
            this.bbiLocacao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiLocacao.ImageOptions.Image")));
            this.bbiLocacao.Name = "bbiLocacao";
            // 
            // bbiTransfer
            // 
            this.bbiTransfer.Caption = "Transfer";
            this.bbiTransfer.Id = 42;
            this.bbiTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiTransfer.ImageOptions.Image")));
            this.bbiTransfer.Name = "bbiTransfer";
            // 
            // bbiCruzeiro
            // 
            this.bbiCruzeiro.Caption = "Cruzeiro";
            this.bbiCruzeiro.Id = 43;
            this.bbiCruzeiro.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCruzeiro.ImageOptions.Image")));
            this.bbiCruzeiro.Name = "bbiCruzeiro";
            // 
            // bbiServicos
            // 
            this.bbiServicos.Caption = "Serviços";
            this.bbiServicos.Id = 45;
            this.bbiServicos.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiServicos.ImageOptions.Image")));
            this.bbiServicos.Name = "bbiServicos";
            // 
            // bbiAlterarProduto
            // 
            this.bbiAlterarProduto.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiAlterarProduto.Caption = "Alterar";
            this.bbiAlterarProduto.Id = 37;
            this.bbiAlterarProduto.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiAlterarProduto.ImageOptions.SvgImage")));
            this.bbiAlterarProduto.Name = "bbiAlterarProduto";
            this.bbiAlterarProduto.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem7.Text = "Alterar produto selecionado";
            superToolTip7.Items.Add(toolTipItem7);
            this.bbiAlterarProduto.SuperTip = superToolTip7;
            // 
            // bbiExcluirProduto
            // 
            this.bbiExcluirProduto.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbiExcluirProduto.Caption = "Excluir";
            this.bbiExcluirProduto.Id = 38;
            this.bbiExcluirProduto.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiExcluirProduto.Name = "bbiExcluirProduto";
            this.bbiExcluirProduto.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            toolTipItem8.Text = "Excluir produto selecionado";
            superToolTip8.Items.Add(toolTipItem8);
            this.bbiExcluirProduto.SuperTip = superToolTip8;
            this.bbiExcluirProduto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExcluirProduto_ItemClick);
            // 
            // rpgMenu
            // 
            this.rpgMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSalvar,
            this.rpgAcoesProdutos,
            this.rpgSelecaoProdutos});
            this.rpgMenu.MergeOrder = 0;
            this.rpgMenu.Name = "rpgMenu";
            this.rpgMenu.Text = "Menu";
            // 
            // rpgSalvar
            // 
            this.rpgSalvar.AllowTextClipping = false;
            this.rpgSalvar.ImageUri.Uri = "Save;Office2013";
            this.rpgSalvar.ItemLinks.Add(this.bbiSave);
            this.rpgSalvar.ItemLinks.Add(this.bbiDelete);
            this.rpgSalvar.ItemLinks.Add(this.bbiReset);
            this.rpgSalvar.ItemLinks.Add(this.bbiClose);
            this.rpgSalvar.Name = "rpgSalvar";
            this.rpgSalvar.ShowCaptionButton = false;
            toolTipItem9.Text = "Edição de registros";
            superToolTip9.Items.Add(toolTipItem9);
            this.rpgSalvar.SuperTip = superToolTip9;
            this.rpgSalvar.Text = "Edição de registros";
            // 
            // rpgAcoesProdutos
            // 
            this.rpgAcoesProdutos.ItemLinks.Add(this.bbiAdicionarProduto);
            this.rpgAcoesProdutos.ItemLinks.Add(this.bbiAlterarProduto);
            this.rpgAcoesProdutos.ItemLinks.Add(this.bbiExcluirProduto);
            this.rpgAcoesProdutos.Name = "rpgAcoesProdutos";
            this.rpgAcoesProdutos.Text = "Ações";
            // 
            // rpgSelecaoProdutos
            // 
            this.rpgSelecaoProdutos.Name = "rpgSelecaoProdutos";
            this.rpgSelecaoProdutos.Text = "Tipos de produto";
            // 
            // bdcMenuControler
            // 
            this.bdcMenuControler.Controller.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.bdcMenuControler.Controller.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bdcMenuControler.Controller.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.bdcMenuControler.Controller.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // txtNroProcesso
            // 
            this.txtNroProcesso.EditValue = 0;
            this.txtNroProcesso.Location = new System.Drawing.Point(13, 61);
            this.txtNroProcesso.MenuManager = this.mrcMenu;
            this.txtNroProcesso.Name = "txtNroProcesso";
            this.txtNroProcesso.Size = new System.Drawing.Size(78, 20);
            this.txtNroProcesso.TabIndex = 1;
            // 
            // dteAbertura
            // 
            this.dteAbertura.EditValue = null;
            this.dteAbertura.Location = new System.Drawing.Point(97, 61);
            this.dteAbertura.MenuManager = this.mrcMenu;
            this.dteAbertura.Name = "dteAbertura";
            this.dteAbertura.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteAbertura.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteAbertura.Size = new System.Drawing.Size(100, 20);
            this.dteAbertura.TabIndex = 3;
            // 
            // trvProdutos
            // 
            this.trvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvProdutos.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colNroRequisicao,
            this.colProduto,
            this.colPassageiro,
            this.colDataIn,
            this.colDataOut});
            this.trvProdutos.Cursor = System.Windows.Forms.Cursors.Default;
            this.trvProdutos.Location = new System.Drawing.Point(13, 87);
            this.trvProdutos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.trvProdutos.Name = "trvProdutos";
            this.trvProdutos.OptionsView.ShowIndicator = false;
            this.trvProdutos.OptionsView.ShowRoot = false;
            this.trvProdutos.Size = new System.Drawing.Size(700, 254);
            this.trvProdutos.TabIndex = 34;
            // 
            // colNroRequisicao
            // 
            this.colNroRequisicao.Caption = "Nº Requisição";
            this.colNroRequisicao.FieldName = "NroRequis";
            this.colNroRequisicao.Name = "colNroRequisicao";
            this.colNroRequisicao.OptionsColumn.AllowEdit = false;
            this.colNroRequisicao.OptionsColumn.AllowFocus = false;
            this.colNroRequisicao.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colNroRequisicao.OptionsColumn.FixedWidth = true;
            this.colNroRequisicao.OptionsColumn.ShowInCustomizationForm = false;
            this.colNroRequisicao.Visible = true;
            this.colNroRequisicao.VisibleIndex = 0;
            this.colNroRequisicao.Width = 82;
            // 
            // colProduto
            // 
            this.colProduto.Caption = "Produto";
            this.colProduto.FieldName = "Produto";
            this.colProduto.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProduto.Name = "colProduto";
            this.colProduto.OptionsColumn.AllowEdit = false;
            this.colProduto.OptionsColumn.AllowFocus = false;
            this.colProduto.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colProduto.OptionsColumn.ShowInCustomizationForm = false;
            this.colProduto.Visible = true;
            this.colProduto.VisibleIndex = 1;
            this.colProduto.Width = 231;
            // 
            // colPassageiro
            // 
            this.colPassageiro.Caption = "Passageiro";
            this.colPassageiro.FieldName = "Passageiro";
            this.colPassageiro.Name = "colPassageiro";
            this.colPassageiro.OptionsColumn.AllowEdit = false;
            this.colPassageiro.OptionsColumn.AllowFocus = false;
            this.colPassageiro.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colPassageiro.OptionsColumn.ShowInCustomizationForm = false;
            this.colPassageiro.Visible = true;
            this.colPassageiro.VisibleIndex = 2;
            this.colPassageiro.Width = 238;
            // 
            // colDataIn
            // 
            this.colDataIn.Caption = "Data In";
            this.colDataIn.FieldName = "Data In";
            this.colDataIn.Format.FormatString = "d";
            this.colDataIn.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDataIn.Name = "colDataIn";
            this.colDataIn.OptionsColumn.AllowEdit = false;
            this.colDataIn.OptionsColumn.AllowFocus = false;
            this.colDataIn.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colDataIn.OptionsColumn.FixedWidth = true;
            this.colDataIn.OptionsColumn.ShowInCustomizationForm = false;
            this.colDataIn.Visible = true;
            this.colDataIn.VisibleIndex = 3;
            this.colDataIn.Width = 92;
            // 
            // colDataOut
            // 
            this.colDataOut.Caption = "Data Out";
            this.colDataOut.FieldName = "DataOut";
            this.colDataOut.Format.FormatString = "d";
            this.colDataOut.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDataOut.Name = "colDataOut";
            this.colDataOut.OptionsColumn.AllowEdit = false;
            this.colDataOut.OptionsColumn.AllowFocus = false;
            this.colDataOut.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colDataOut.OptionsColumn.FixedWidth = true;
            this.colDataOut.OptionsColumn.ShowInCustomizationForm = false;
            this.colDataOut.Visible = true;
            this.colDataOut.VisibleIndex = 4;
            this.colDataOut.Width = 92;
            // 
            // gpcResumoRequisicao
            // 
            this.gpcResumoRequisicao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpcResumoRequisicao.CaptionImage = ((System.Drawing.Image)(resources.GetObject("gpcResumoRequisicao.CaptionImage")));
            this.gpcResumoRequisicao.CaptionImagePadding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.gpcResumoRequisicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcResumoRequisicao.Location = new System.Drawing.Point(0, 0);
            this.gpcResumoRequisicao.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpcResumoRequisicao.Name = "gpcResumoRequisicao";
            this.gpcResumoRequisicao.Size = new System.Drawing.Size(152, 219);
            this.gpcResumoRequisicao.TabIndex = 36;
            this.gpcResumoRequisicao.Text = "Resumo da Requisição";
            // 
            // gpcResumoProcesso
            // 
            this.gpcResumoProcesso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpcResumoProcesso.CaptionImage = ((System.Drawing.Image)(resources.GetObject("gpcResumoProcesso.CaptionImage")));
            this.gpcResumoProcesso.CaptionImagePadding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.gpcResumoProcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcResumoProcesso.Location = new System.Drawing.Point(0, 0);
            this.gpcResumoProcesso.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpcResumoProcesso.Name = "gpcResumoProcesso";
            this.gpcResumoProcesso.Size = new System.Drawing.Size(152, 122);
            this.gpcResumoProcesso.TabIndex = 37;
            this.gpcResumoProcesso.Text = "Resumo do Processo";
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(474, 46);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(33, 13);
            this.lblCliente.TabIndex = 6;
            this.lblCliente.Text = "Cliente";
            // 
            // lblNroProcesso
            // 
            this.lblNroProcesso.Location = new System.Drawing.Point(13, 46);
            this.lblNroProcesso.Name = "lblNroProcesso";
            this.lblNroProcesso.Size = new System.Drawing.Size(58, 13);
            this.lblNroProcesso.TabIndex = 0;
            this.lblNroProcesso.Text = "Nº Processo";
            // 
            // lblAbertura
            // 
            this.lblAbertura.Location = new System.Drawing.Point(97, 46);
            this.lblAbertura.Name = "lblAbertura";
            this.lblAbertura.Size = new System.Drawing.Size(83, 13);
            this.lblAbertura.TabIndex = 2;
            this.lblAbertura.Text = "Data de abertura";
            // 
            // lblUnidade
            // 
            this.lblUnidade.Location = new System.Drawing.Point(203, 46);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(94, 13);
            this.lblUnidade.TabIndex = 4;
            this.lblUnidade.Text = "Unidade de negócio";
            // 
            // gpcDadosProcesso
            // 
            this.gpcDadosProcesso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpcDadosProcesso.CaptionImage = ((System.Drawing.Image)(resources.GetObject("gpcDadosProcesso.CaptionImage")));
            this.gpcDadosProcesso.CaptionImagePadding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.gpcDadosProcesso.Controls.Add(this.cboCliente);
            this.gpcDadosProcesso.Controls.Add(this.cboUnidade);
            this.gpcDadosProcesso.Controls.Add(this.txtNroProcesso);
            this.gpcDadosProcesso.Controls.Add(this.lblUnidade);
            this.gpcDadosProcesso.Controls.Add(this.dteAbertura);
            this.gpcDadosProcesso.Controls.Add(this.trvProdutos);
            this.gpcDadosProcesso.Controls.Add(this.lblAbertura);
            this.gpcDadosProcesso.Controls.Add(this.lblNroProcesso);
            this.gpcDadosProcesso.Controls.Add(this.lblCliente);
            this.gpcDadosProcesso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcDadosProcesso.Location = new System.Drawing.Point(0, 0);
            this.gpcDadosProcesso.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpcDadosProcesso.Name = "gpcDadosProcesso";
            this.gpcDadosProcesso.Size = new System.Drawing.Size(725, 353);
            this.gpcDadosProcesso.TabIndex = 0;
            this.gpcDadosProcesso.Text = "Dados do Processo";
            // 
            // cboCliente
            // 
            this.cboCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCliente.EditValue = 0;
            this.cboCliente.Location = new System.Drawing.Point(474, 61);
            this.cboCliente.MenuManager = this.mrcMenu;
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCliente.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column1", "Cliente")});
            this.cboCliente.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboCliente.Properties.PopupWidth = 400;
            this.cboCliente.Size = new System.Drawing.Size(239, 20);
            this.cboCliente.TabIndex = 7;
            // 
            // cboUnidade
            // 
            this.cboUnidade.EditValue = 0;
            this.cboUnidade.Location = new System.Drawing.Point(203, 61);
            this.cboUnidade.MenuManager = this.mrcMenu;
            this.cboUnidade.Name = "cboUnidade";
            this.cboUnidade.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUnidade.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column1", 124, "Unidade"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Column2", 125, "Endereço")});
            this.cboUnidade.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cboUnidade.Properties.PopupWidth = 400;
            this.cboUnidade.Size = new System.Drawing.Size(265, 20);
            this.cboUnidade.TabIndex = 5;
            // 
            // sctDivisorGeral
            // 
            this.sctDivisorGeral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sctDivisorGeral.Location = new System.Drawing.Point(0, 146);
            this.sctDivisorGeral.Name = "sctDivisorGeral";
            this.sctDivisorGeral.Panel1.Controls.Add(this.gpcDadosProcesso);
            this.sctDivisorGeral.Panel1.Text = "Produtos";
            this.sctDivisorGeral.Panel2.Controls.Add(this.sctResumos);
            this.sctDivisorGeral.Panel2.Text = "Resumos";
            this.sctDivisorGeral.Size = new System.Drawing.Size(889, 353);
            this.sctDivisorGeral.SplitterPosition = 725;
            this.sctDivisorGeral.TabIndex = 39;
            this.sctDivisorGeral.Text = "splitContainerControl1";
            // 
            // sctResumos
            // 
            this.sctResumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sctResumos.Horizontal = false;
            this.sctResumos.Location = new System.Drawing.Point(0, 0);
            this.sctResumos.Name = "sctResumos";
            this.sctResumos.Panel1.Controls.Add(this.gpcResumoRequisicao);
            this.sctResumos.Panel1.Text = "ResumoProcesso";
            this.sctResumos.Panel2.Controls.Add(this.gpcResumoProcesso);
            this.sctResumos.Panel2.Text = "ResumoRequisicao";
            this.sctResumos.Size = new System.Drawing.Size(152, 353);
            this.sctResumos.SplitterPosition = 219;
            this.sctResumos.TabIndex = 38;
            this.sctResumos.Text = "splitContainerControl1";
            // 
            // gpcEdicao
            // 
            this.gpcEdicao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpcEdicao.CaptionImage = ((System.Drawing.Image)(resources.GetObject("gpcEdicao.CaptionImage")));
            this.gpcEdicao.CaptionImagePadding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.gpcEdicao.Controls.Add(this.layFormulario);
            this.gpcEdicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcEdicao.Enabled = false;
            this.gpcEdicao.Location = new System.Drawing.Point(0, 146);
            this.gpcEdicao.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gpcEdicao.Name = "gpcEdicao";
            this.gpcEdicao.Size = new System.Drawing.Size(889, 353);
            this.gpcEdicao.TabIndex = 0;
            this.gpcEdicao.Text = "Edição de requisição";
            this.gpcEdicao.Visible = false;
            // 
            // layFormulario
            // 
            this.layFormulario.Controls.Add(this.txtNroVoucher);
            this.layFormulario.Controls.Add(this.txtConversaoLiquido);
            this.layFormulario.Controls.Add(this.dteDataRetorno);
            this.layFormulario.Controls.Add(this.txtConversaoCambio);
            this.layFormulario.Controls.Add(this.dteDataSaida);
            this.layFormulario.Controls.Add(this.txtLiquido);
            this.layFormulario.Controls.Add(this.txtEntradaCliente);
            this.layFormulario.Controls.Add(this.txtAcrescimo);
            this.layFormulario.Controls.Add(this.txtDesconto);
            this.layFormulario.Controls.Add(this.txtSinalFornecedor);
            this.layFormulario.Controls.Add(this.txtTaxaAdministrativa);
            this.layFormulario.Controls.Add(this.txtTaxaIntermediacao);
            this.layFormulario.Controls.Add(this.txtTaxasExtras);
            this.layFormulario.Controls.Add(this.txtTarifaUtilizada);
            this.layFormulario.Controls.Add(this.txtTarifaCheia);
            this.layFormulario.Controls.Add(this.cboVendaMoeda);
            this.layFormulario.Controls.Add(this.cboVendaFormaPagamento);
            this.layFormulario.Controls.Add(this.cboVendaTipo);
            this.layFormulario.Controls.Add(this.memObservacao);
            this.layFormulario.Controls.Add(this.cboEvento);
            this.layFormulario.Controls.Add(this.cboGrupo);
            this.layFormulario.Controls.Add(this.cboEmissor);
            this.layFormulario.Controls.Add(this.memTrechoPeriodo);
            this.layFormulario.Controls.Add(this.memPAX);
            this.layFormulario.Controls.Add(this.cboCentroCusto);
            this.layFormulario.Controls.Add(this.cboTKTStatus);
            this.layFormulario.Controls.Add(this.txtTKTNumero);
            this.layFormulario.Controls.Add(this.txtProdutoQuantidade);
            this.layFormulario.Controls.Add(this.cboFornecedor);
            this.layFormulario.Controls.Add(this.cboConsolidador);
            this.layFormulario.Controls.Add(this.cboProduto);
            this.layFormulario.Controls.Add(this.txtRLOCAtt);
            this.layFormulario.Controls.Add(this.cboRequisicaoStatus);
            this.layFormulario.Controls.Add(this.txtNroRequisicao);
            this.layFormulario.Controls.Add(this.dteDataEmissao);
            this.layFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layFormulario.Location = new System.Drawing.Point(2, 33);
            this.layFormulario.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.layFormulario.Name = "layFormulario";
            this.layFormulario.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(555, 241, 450, 400);
            this.layFormulario.Root = this.lcgFrontOfficeVendas;
            this.layFormulario.Size = new System.Drawing.Size(885, 318);
            this.layFormulario.TabIndex = 0;
            this.layFormulario.Text = "layoutControl1";
            // 
            // txtNroVoucher
            // 
            this.txtNroVoucher.Location = new System.Drawing.Point(131, 484);
            this.txtNroVoucher.MenuManager = this.mrcMenu;
            this.txtNroVoucher.Name = "txtNroVoucher";
            this.txtNroVoucher.Size = new System.Drawing.Size(358, 20);
            this.txtNroVoucher.StyleController = this.layFormulario;
            this.txtNroVoucher.TabIndex = 39;
            // 
            // txtConversaoLiquido
            // 
            this.txtConversaoLiquido.Location = new System.Drawing.Point(468, 334);
            this.txtConversaoLiquido.MenuManager = this.mrcMenu;
            this.txtConversaoLiquido.Name = "txtConversaoLiquido";
            this.txtConversaoLiquido.Size = new System.Drawing.Size(215, 20);
            this.txtConversaoLiquido.StyleController = this.layFormulario;
            this.txtConversaoLiquido.TabIndex = 38;
            // 
            // dteDataRetorno
            // 
            this.dteDataRetorno.EditValue = null;
            this.dteDataRetorno.Location = new System.Drawing.Point(120, 334);
            this.dteDataRetorno.MenuManager = this.mrcMenu;
            this.dteDataRetorno.Name = "dteDataRetorno";
            this.dteDataRetorno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataRetorno.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataRetorno.Size = new System.Drawing.Size(233, 20);
            this.dteDataRetorno.StyleController = this.layFormulario;
            this.dteDataRetorno.TabIndex = 37;
            // 
            // txtConversaoCambio
            // 
            this.txtConversaoCambio.Location = new System.Drawing.Point(468, 304);
            this.txtConversaoCambio.MenuManager = this.mrcMenu;
            this.txtConversaoCambio.Name = "txtConversaoCambio";
            this.txtConversaoCambio.Size = new System.Drawing.Size(215, 20);
            this.txtConversaoCambio.StyleController = this.layFormulario;
            this.txtConversaoCambio.TabIndex = 36;
            // 
            // dteDataSaida
            // 
            this.dteDataSaida.EditValue = null;
            this.dteDataSaida.Location = new System.Drawing.Point(120, 304);
            this.dteDataSaida.MenuManager = this.mrcMenu;
            this.dteDataSaida.Name = "dteDataSaida";
            this.dteDataSaida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataSaida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataSaida.Size = new System.Drawing.Size(233, 20);
            this.dteDataSaida.StyleController = this.layFormulario;
            this.dteDataSaida.TabIndex = 35;
            // 
            // txtLiquido
            // 
            this.txtLiquido.Location = new System.Drawing.Point(798, 334);
            this.txtLiquido.MenuManager = this.mrcMenu;
            this.txtLiquido.Name = "txtLiquido";
            this.txtLiquido.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtLiquido.Properties.Appearance.Options.UseBackColor = true;
            this.txtLiquido.Size = new System.Drawing.Size(55, 20);
            this.txtLiquido.StyleController = this.layFormulario;
            this.txtLiquido.TabIndex = 34;
            // 
            // txtEntradaCliente
            // 
            this.txtEntradaCliente.Location = new System.Drawing.Point(798, 304);
            this.txtEntradaCliente.MenuManager = this.mrcMenu;
            this.txtEntradaCliente.Name = "txtEntradaCliente";
            this.txtEntradaCliente.Size = new System.Drawing.Size(55, 20);
            this.txtEntradaCliente.StyleController = this.layFormulario;
            this.txtEntradaCliente.TabIndex = 33;
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.Location = new System.Drawing.Point(798, 274);
            this.txtAcrescimo.MenuManager = this.mrcMenu;
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.Size = new System.Drawing.Size(55, 20);
            this.txtAcrescimo.StyleController = this.layFormulario;
            this.txtAcrescimo.TabIndex = 32;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(798, 244);
            this.txtDesconto.MenuManager = this.mrcMenu;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(55, 20);
            this.txtDesconto.StyleController = this.layFormulario;
            this.txtDesconto.TabIndex = 31;
            // 
            // txtSinalFornecedor
            // 
            this.txtSinalFornecedor.Location = new System.Drawing.Point(798, 214);
            this.txtSinalFornecedor.MenuManager = this.mrcMenu;
            this.txtSinalFornecedor.Name = "txtSinalFornecedor";
            this.txtSinalFornecedor.Size = new System.Drawing.Size(55, 20);
            this.txtSinalFornecedor.StyleController = this.layFormulario;
            this.txtSinalFornecedor.TabIndex = 30;
            // 
            // txtTaxaAdministrativa
            // 
            this.txtTaxaAdministrativa.Location = new System.Drawing.Point(798, 184);
            this.txtTaxaAdministrativa.MenuManager = this.mrcMenu;
            this.txtTaxaAdministrativa.Name = "txtTaxaAdministrativa";
            this.txtTaxaAdministrativa.Size = new System.Drawing.Size(55, 20);
            this.txtTaxaAdministrativa.StyleController = this.layFormulario;
            this.txtTaxaAdministrativa.TabIndex = 29;
            // 
            // txtTaxaIntermediacao
            // 
            this.txtTaxaIntermediacao.Location = new System.Drawing.Point(798, 154);
            this.txtTaxaIntermediacao.MenuManager = this.mrcMenu;
            this.txtTaxaIntermediacao.Name = "txtTaxaIntermediacao";
            this.txtTaxaIntermediacao.Size = new System.Drawing.Size(55, 20);
            this.txtTaxaIntermediacao.StyleController = this.layFormulario;
            this.txtTaxaIntermediacao.TabIndex = 28;
            // 
            // txtTaxasExtras
            // 
            this.txtTaxasExtras.Location = new System.Drawing.Point(798, 124);
            this.txtTaxasExtras.MenuManager = this.mrcMenu;
            this.txtTaxasExtras.Name = "txtTaxasExtras";
            this.txtTaxasExtras.Size = new System.Drawing.Size(55, 20);
            this.txtTaxasExtras.StyleController = this.layFormulario;
            this.txtTaxasExtras.TabIndex = 27;
            // 
            // txtTarifaUtilizada
            // 
            this.txtTarifaUtilizada.Location = new System.Drawing.Point(798, 94);
            this.txtTarifaUtilizada.MenuManager = this.mrcMenu;
            this.txtTarifaUtilizada.Name = "txtTarifaUtilizada";
            this.txtTarifaUtilizada.Size = new System.Drawing.Size(55, 20);
            this.txtTarifaUtilizada.StyleController = this.layFormulario;
            this.txtTarifaUtilizada.TabIndex = 26;
            // 
            // txtTarifaCheia
            // 
            this.txtTarifaCheia.Location = new System.Drawing.Point(798, 64);
            this.txtTarifaCheia.MenuManager = this.mrcMenu;
            this.txtTarifaCheia.Name = "txtTarifaCheia";
            this.txtTarifaCheia.Size = new System.Drawing.Size(55, 20);
            this.txtTarifaCheia.StyleController = this.layFormulario;
            this.txtTarifaCheia.TabIndex = 25;
            // 
            // cboVendaMoeda
            // 
            this.cboVendaMoeda.Location = new System.Drawing.Point(798, 34);
            this.cboVendaMoeda.MenuManager = this.mrcMenu;
            this.cboVendaMoeda.Name = "cboVendaMoeda";
            this.cboVendaMoeda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendaMoeda.Size = new System.Drawing.Size(55, 20);
            this.cboVendaMoeda.StyleController = this.layFormulario;
            this.cboVendaMoeda.TabIndex = 24;
            // 
            // cboVendaFormaPagamento
            // 
            this.cboVendaFormaPagamento.Location = new System.Drawing.Point(120, 274);
            this.cboVendaFormaPagamento.MenuManager = this.mrcMenu;
            this.cboVendaFormaPagamento.Name = "cboVendaFormaPagamento";
            this.cboVendaFormaPagamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendaFormaPagamento.Size = new System.Drawing.Size(233, 20);
            this.cboVendaFormaPagamento.StyleController = this.layFormulario;
            this.cboVendaFormaPagamento.TabIndex = 23;
            // 
            // cboVendaTipo
            // 
            this.cboVendaTipo.Location = new System.Drawing.Point(468, 274);
            this.cboVendaTipo.MenuManager = this.mrcMenu;
            this.cboVendaTipo.Name = "cboVendaTipo";
            this.cboVendaTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendaTipo.Size = new System.Drawing.Size(215, 20);
            this.cboVendaTipo.StyleController = this.layFormulario;
            this.cboVendaTipo.TabIndex = 22;
            // 
            // memObservacao
            // 
            this.memObservacao.Location = new System.Drawing.Point(604, 394);
            this.memObservacao.MenuManager = this.mrcMenu;
            this.memObservacao.Name = "memObservacao";
            this.memObservacao.Size = new System.Drawing.Size(238, 110);
            this.memObservacao.StyleController = this.layFormulario;
            this.memObservacao.TabIndex = 21;
            // 
            // cboEvento
            // 
            this.cboEvento.Location = new System.Drawing.Point(131, 424);
            this.cboEvento.MenuManager = this.mrcMenu;
            this.cboEvento.Name = "cboEvento";
            this.cboEvento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEvento.Size = new System.Drawing.Size(358, 20);
            this.cboEvento.StyleController = this.layFormulario;
            this.cboEvento.TabIndex = 20;
            // 
            // cboGrupo
            // 
            this.cboGrupo.Location = new System.Drawing.Point(131, 454);
            this.cboGrupo.MenuManager = this.mrcMenu;
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGrupo.Size = new System.Drawing.Size(358, 20);
            this.cboGrupo.StyleController = this.layFormulario;
            this.cboGrupo.TabIndex = 19;
            // 
            // cboEmissor
            // 
            this.cboEmissor.Location = new System.Drawing.Point(120, 124);
            this.cboEmissor.MenuManager = this.mrcMenu;
            this.cboEmissor.Name = "cboEmissor";
            this.cboEmissor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmissor.Size = new System.Drawing.Size(233, 20);
            this.cboEmissor.StyleController = this.layFormulario;
            this.cboEmissor.TabIndex = 18;
            // 
            // memTrechoPeriodo
            // 
            this.memTrechoPeriodo.Location = new System.Drawing.Point(120, 154);
            this.memTrechoPeriodo.MenuManager = this.mrcMenu;
            this.memTrechoPeriodo.MinimumSize = new System.Drawing.Size(0, 32);
            this.memTrechoPeriodo.Name = "memTrechoPeriodo";
            this.memTrechoPeriodo.Size = new System.Drawing.Size(233, 110);
            this.memTrechoPeriodo.StyleController = this.layFormulario;
            this.memTrechoPeriodo.TabIndex = 17;
            // 
            // memPAX
            // 
            this.memPAX.Location = new System.Drawing.Point(468, 154);
            this.memPAX.MenuManager = this.mrcMenu;
            this.memPAX.MinimumSize = new System.Drawing.Size(0, 32);
            this.memPAX.Name = "memPAX";
            this.memPAX.Size = new System.Drawing.Size(215, 110);
            this.memPAX.StyleController = this.layFormulario;
            this.memPAX.TabIndex = 16;
            // 
            // cboCentroCusto
            // 
            this.cboCentroCusto.Location = new System.Drawing.Point(131, 394);
            this.cboCentroCusto.MenuManager = this.mrcMenu;
            this.cboCentroCusto.Name = "cboCentroCusto";
            this.cboCentroCusto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCentroCusto.Size = new System.Drawing.Size(358, 20);
            this.cboCentroCusto.StyleController = this.layFormulario;
            this.cboCentroCusto.TabIndex = 15;
            // 
            // cboTKTStatus
            // 
            this.cboTKTStatus.Location = new System.Drawing.Point(631, 121);
            this.cboTKTStatus.MenuManager = this.mrcMenu;
            this.cboTKTStatus.Name = "cboTKTStatus";
            this.cboTKTStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTKTStatus.Size = new System.Drawing.Size(55, 20);
            this.cboTKTStatus.StyleController = this.layFormulario;
            this.cboTKTStatus.TabIndex = 14;
            // 
            // txtTKTNumero
            // 
            this.txtTKTNumero.Location = new System.Drawing.Point(468, 124);
            this.txtTKTNumero.MenuManager = this.mrcMenu;
            this.txtTKTNumero.Name = "txtTKTNumero";
            this.txtTKTNumero.Size = new System.Drawing.Size(51, 20);
            this.txtTKTNumero.StyleController = this.layFormulario;
            this.txtTKTNumero.TabIndex = 13;
            // 
            // txtProdutoQuantidade
            // 
            this.txtProdutoQuantidade.Location = new System.Drawing.Point(468, 64);
            this.txtProdutoQuantidade.MenuManager = this.mrcMenu;
            this.txtProdutoQuantidade.Name = "txtProdutoQuantidade";
            this.txtProdutoQuantidade.Size = new System.Drawing.Size(215, 20);
            this.txtProdutoQuantidade.StyleController = this.layFormulario;
            this.txtProdutoQuantidade.TabIndex = 12;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.Location = new System.Drawing.Point(468, 94);
            this.cboFornecedor.MenuManager = this.mrcMenu;
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFornecedor.Size = new System.Drawing.Size(215, 20);
            this.cboFornecedor.StyleController = this.layFormulario;
            this.cboFornecedor.TabIndex = 10;
            // 
            // cboConsolidador
            // 
            this.cboConsolidador.Location = new System.Drawing.Point(120, 94);
            this.cboConsolidador.MenuManager = this.mrcMenu;
            this.cboConsolidador.Name = "cboConsolidador";
            this.cboConsolidador.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboConsolidador.Size = new System.Drawing.Size(233, 20);
            this.cboConsolidador.StyleController = this.layFormulario;
            this.cboConsolidador.TabIndex = 9;
            // 
            // cboProduto
            // 
            this.cboProduto.Location = new System.Drawing.Point(120, 64);
            this.cboProduto.MenuManager = this.mrcMenu;
            this.cboProduto.Name = "cboProduto";
            this.cboProduto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProduto.Size = new System.Drawing.Size(233, 20);
            this.cboProduto.StyleController = this.layFormulario;
            this.cboProduto.TabIndex = 8;
            // 
            // txtRLOCAtt
            // 
            this.txtRLOCAtt.Location = new System.Drawing.Point(633, 34);
            this.txtRLOCAtt.MenuManager = this.mrcMenu;
            this.txtRLOCAtt.Name = "txtRLOCAtt";
            this.txtRLOCAtt.Size = new System.Drawing.Size(50, 20);
            this.txtRLOCAtt.StyleController = this.layFormulario;
            this.txtRLOCAtt.TabIndex = 3;
            // 
            // cboRequisicaoStatus
            // 
            this.cboRequisicaoStatus.Location = new System.Drawing.Point(468, 34);
            this.cboRequisicaoStatus.MenuManager = this.mrcMenu;
            this.cboRequisicaoStatus.Name = "cboRequisicaoStatus";
            this.cboRequisicaoStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRequisicaoStatus.Size = new System.Drawing.Size(50, 20);
            this.cboRequisicaoStatus.StyleController = this.layFormulario;
            this.cboRequisicaoStatus.TabIndex = 2;
            // 
            // txtNroRequisicao
            // 
            this.txtNroRequisicao.Location = new System.Drawing.Point(303, 34);
            this.txtNroRequisicao.MenuManager = this.mrcMenu;
            this.txtNroRequisicao.Name = "txtNroRequisicao";
            this.txtNroRequisicao.Size = new System.Drawing.Size(50, 20);
            this.txtNroRequisicao.StyleController = this.layFormulario;
            this.txtNroRequisicao.TabIndex = 1;
            // 
            // dteDataEmissao
            // 
            this.dteDataEmissao.EditValue = null;
            this.dteDataEmissao.Location = new System.Drawing.Point(120, 34);
            this.dteDataEmissao.MenuManager = this.mrcMenu;
            this.dteDataEmissao.Name = "dteDataEmissao";
            this.dteDataEmissao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataEmissao.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDataEmissao.Size = new System.Drawing.Size(68, 20);
            this.dteDataEmissao.StyleController = this.layFormulario;
            this.dteDataEmissao.TabIndex = 0;
            // 
            // lcgFrontOfficeVendas
            // 
            this.lcgFrontOfficeVendas.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcgFrontOfficeVendas.AppearanceGroup.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lcgFrontOfficeVendas.AppearanceGroup.Options.UseFont = true;
            this.lcgFrontOfficeVendas.AppearanceGroup.Options.UseForeColor = true;
            this.lcgFrontOfficeVendas.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcgFrontOfficeVendas.AppearanceItemCaption.Options.UseFont = true;
            this.lcgFrontOfficeVendas.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgFrontOfficeVendas.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgFrontOfficeVendas.CustomizationFormText = "Front Office - Vendas";
            this.lcgFrontOfficeVendas.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgFrontOfficeVendas.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciDataEmissao,
            this.lciRequisicaoStatus,
            this.lciNroRequisicao,
            this.lciProduto,
            this.lciRLOCAtt,
            this.lciProdutoQuantidade,
            this.lciPAX,
            this.Root1,
            this.lciEmissor,
            this.lciTrechoPeriodo,
            this.lciConsolidador,
            this.lciFornecedor,
            this.lciTKTNumero,
            this.lciTKTNumerok,
            this.lciVendaFormaPagamento,
            this.lciVendaTipo,
            this.lciTotalTarifaCheia,
            this.lciTotalTarifaUtilizada,
            this.lciTotalTaxasExtras,
            this.lciTaxaIntermediacao,
            this.lciTaxaAdministrativa,
            this.lciSinalFornecedor,
            this.lciDesconto,
            this.lciAcrescimo,
            this.lciEntradaCliente,
            this.lciLiquido,
            this.lciVendaMoeda,
            this.lciDataSaida,
            this.lciConversaoCambio,
            this.lciDataRetorno,
            this.lciConversaoLiquido,
            this.Root3,
            this.Root4,
            this.Root5,
            this.Root6,
            this.Root7,
            this.Root8,
            this.Root9,
            this.Root10,
            this.Root11,
            this.Root2});
            this.lcgFrontOfficeVendas.Location = new System.Drawing.Point(0, 0);
            this.lcgFrontOfficeVendas.Name = "Root";
            this.lcgFrontOfficeVendas.Size = new System.Drawing.Size(868, 940);
            this.lcgFrontOfficeVendas.Text = "Front Office - Vendas (1.0 e 1.1)";
            // 
            // lciDataEmissao
            // 
            this.lciDataEmissao.Control = this.dteDataEmissao;
            this.lciDataEmissao.CustomizationFormText = "lciDataEmissao";
            this.lciDataEmissao.Location = new System.Drawing.Point(0, 0);
            this.lciDataEmissao.Name = "lciDataEmissao";
            this.lciDataEmissao.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDataEmissao.Size = new System.Drawing.Size(183, 30);
            this.lciDataEmissao.Text = "Data de Emissão";
            this.lciDataEmissao.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciRequisicaoStatus
            // 
            this.lciRequisicaoStatus.Control = this.cboRequisicaoStatus;
            this.lciRequisicaoStatus.Location = new System.Drawing.Point(348, 0);
            this.lciRequisicaoStatus.Name = "lciRequisicaoStatus";
            this.lciRequisicaoStatus.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciRequisicaoStatus.Size = new System.Drawing.Size(165, 30);
            this.lciRequisicaoStatus.Text = "Status Requisição";
            this.lciRequisicaoStatus.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciNroRequisicao
            // 
            this.lciNroRequisicao.Control = this.txtNroRequisicao;
            this.lciNroRequisicao.Location = new System.Drawing.Point(183, 0);
            this.lciNroRequisicao.Name = "lciNroRequisicao";
            this.lciNroRequisicao.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciNroRequisicao.Size = new System.Drawing.Size(165, 30);
            this.lciNroRequisicao.Text = "Nº Requisição";
            this.lciNroRequisicao.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciProduto
            // 
            this.lciProduto.Control = this.cboProduto;
            this.lciProduto.Location = new System.Drawing.Point(0, 30);
            this.lciProduto.Name = "lciProduto";
            this.lciProduto.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciProduto.Size = new System.Drawing.Size(348, 30);
            this.lciProduto.Text = "Produto";
            this.lciProduto.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciRLOCAtt
            // 
            this.lciRLOCAtt.Control = this.txtRLOCAtt;
            this.lciRLOCAtt.Location = new System.Drawing.Point(513, 0);
            this.lciRLOCAtt.Name = "lciRLOCAtt";
            this.lciRLOCAtt.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciRLOCAtt.Size = new System.Drawing.Size(165, 30);
            this.lciRLOCAtt.Text = "RLOC/Att.";
            this.lciRLOCAtt.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciProdutoQuantidade
            // 
            this.lciProdutoQuantidade.Control = this.txtProdutoQuantidade;
            this.lciProdutoQuantidade.Location = new System.Drawing.Point(348, 30);
            this.lciProdutoQuantidade.Name = "lciProdutoQuantidade";
            this.lciProdutoQuantidade.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciProdutoQuantidade.Size = new System.Drawing.Size(330, 30);
            this.lciProdutoQuantidade.Text = "Qtde. Produto";
            this.lciProdutoQuantidade.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciPAX
            // 
            this.lciPAX.Control = this.memPAX;
            this.lciPAX.Location = new System.Drawing.Point(348, 120);
            this.lciPAX.Name = "lciPAX";
            this.lciPAX.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciPAX.Size = new System.Drawing.Size(330, 120);
            this.lciPAX.Text = "PAX";
            this.lciPAX.TextSize = new System.Drawing.Size(102, 13);
            // 
            // Root1
            // 
            this.Root1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Root1.AppearanceGroup.Options.UseFont = true;
            this.Root1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Root1.AppearanceItemCaption.Options.UseFont = true;
            this.Root1.CustomizationFormText = "Root";
            this.Root1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root1.ExpandButtonVisible = true;
            this.Root1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCentroCusto,
            this.lciEvento,
            this.lciGrupo,
            this.lciObservacao,
            this.lciReservaVoucher});
            this.Root1.Location = new System.Drawing.Point(0, 330);
            this.Root1.Name = "Root1";
            this.Root1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root1.Size = new System.Drawing.Size(848, 161);
            this.Root1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root1.Text = "Back Office - Informações Adicionais (3.0)";
            // 
            // lciCentroCusto
            // 
            this.lciCentroCusto.Control = this.cboCentroCusto;
            this.lciCentroCusto.Location = new System.Drawing.Point(0, 0);
            this.lciCentroCusto.Name = "lciCentroCusto";
            this.lciCentroCusto.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciCentroCusto.Size = new System.Drawing.Size(473, 30);
            this.lciCentroCusto.Text = "Centro de Custo";
            this.lciCentroCusto.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciEvento
            // 
            this.lciEvento.Control = this.cboEvento;
            this.lciEvento.Location = new System.Drawing.Point(0, 30);
            this.lciEvento.Name = "lciEvento";
            this.lciEvento.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciEvento.Size = new System.Drawing.Size(473, 30);
            this.lciEvento.Text = "Evento";
            this.lciEvento.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciGrupo
            // 
            this.lciGrupo.Control = this.cboGrupo;
            this.lciGrupo.Location = new System.Drawing.Point(0, 60);
            this.lciGrupo.Name = "lciGrupo";
            this.lciGrupo.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciGrupo.Size = new System.Drawing.Size(473, 30);
            this.lciGrupo.Text = "Grupo";
            this.lciGrupo.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciObservacao
            // 
            this.lciObservacao.Control = this.memObservacao;
            this.lciObservacao.Location = new System.Drawing.Point(473, 0);
            this.lciObservacao.Name = "lciObservacao";
            this.lciObservacao.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciObservacao.Size = new System.Drawing.Size(353, 120);
            this.lciObservacao.Text = "Observação";
            this.lciObservacao.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciReservaVoucher
            // 
            this.lciReservaVoucher.Control = this.txtNroVoucher;
            this.lciReservaVoucher.Location = new System.Drawing.Point(0, 90);
            this.lciReservaVoucher.Name = "lciReservaVoucher";
            this.lciReservaVoucher.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciReservaVoucher.Size = new System.Drawing.Size(473, 30);
            this.lciReservaVoucher.Text = "Nº Voucher";
            this.lciReservaVoucher.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciEmissor
            // 
            this.lciEmissor.Control = this.cboEmissor;
            this.lciEmissor.Location = new System.Drawing.Point(0, 90);
            this.lciEmissor.Name = "lciEmissor";
            this.lciEmissor.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciEmissor.Size = new System.Drawing.Size(348, 30);
            this.lciEmissor.Text = "Emissor";
            this.lciEmissor.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTrechoPeriodo
            // 
            this.lciTrechoPeriodo.Control = this.memTrechoPeriodo;
            this.lciTrechoPeriodo.Location = new System.Drawing.Point(0, 120);
            this.lciTrechoPeriodo.Name = "lciTrechoPeriodo";
            this.lciTrechoPeriodo.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTrechoPeriodo.Size = new System.Drawing.Size(348, 120);
            this.lciTrechoPeriodo.Text = "Trecho/Período";
            this.lciTrechoPeriodo.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciConsolidador
            // 
            this.lciConsolidador.Control = this.cboConsolidador;
            this.lciConsolidador.Location = new System.Drawing.Point(0, 60);
            this.lciConsolidador.Name = "lciConsolidador";
            this.lciConsolidador.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciConsolidador.Size = new System.Drawing.Size(348, 30);
            this.lciConsolidador.Text = "Consolidador";
            this.lciConsolidador.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciFornecedor
            // 
            this.lciFornecedor.Control = this.cboFornecedor;
            this.lciFornecedor.Location = new System.Drawing.Point(348, 60);
            this.lciFornecedor.Name = "lciFornecedor";
            this.lciFornecedor.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciFornecedor.Size = new System.Drawing.Size(330, 30);
            this.lciFornecedor.Text = "Fornecedor";
            this.lciFornecedor.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTKTNumero
            // 
            this.lciTKTNumero.Control = this.txtTKTNumero;
            this.lciTKTNumero.Location = new System.Drawing.Point(348, 90);
            this.lciTKTNumero.Name = "lciTKTNumero";
            this.lciTKTNumero.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTKTNumero.Size = new System.Drawing.Size(166, 30);
            this.lciTKTNumero.Text = "Nº TKT";
            this.lciTKTNumero.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTKTNumerok
            // 
            this.lciTKTNumerok.Control = this.cboTKTStatus;
            this.lciTKTNumerok.Location = new System.Drawing.Point(514, 90);
            this.lciTKTNumerok.Name = "lciTKTNumerok";
            this.lciTKTNumerok.Size = new System.Drawing.Size(164, 30);
            this.lciTKTNumerok.Text = "Status TKT";
            this.lciTKTNumerok.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciVendaFormaPagamento
            // 
            this.lciVendaFormaPagamento.Control = this.cboVendaFormaPagamento;
            this.lciVendaFormaPagamento.Location = new System.Drawing.Point(0, 240);
            this.lciVendaFormaPagamento.Name = "lciVendaFormaPagamento";
            this.lciVendaFormaPagamento.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciVendaFormaPagamento.Size = new System.Drawing.Size(348, 30);
            this.lciVendaFormaPagamento.Text = "Forma de Pagamento";
            this.lciVendaFormaPagamento.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciVendaTipo
            // 
            this.lciVendaTipo.Control = this.cboVendaTipo;
            this.lciVendaTipo.Location = new System.Drawing.Point(348, 240);
            this.lciVendaTipo.Name = "lciVendaTipo";
            this.lciVendaTipo.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciVendaTipo.Size = new System.Drawing.Size(330, 30);
            this.lciVendaTipo.Text = "Tipo de venda";
            this.lciVendaTipo.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTotalTarifaCheia
            // 
            this.lciTotalTarifaCheia.Control = this.txtTarifaCheia;
            this.lciTotalTarifaCheia.Location = new System.Drawing.Point(678, 30);
            this.lciTotalTarifaCheia.Name = "lciTotalTarifaCheia";
            this.lciTotalTarifaCheia.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTotalTarifaCheia.Size = new System.Drawing.Size(170, 30);
            this.lciTotalTarifaCheia.Text = "Total Tarifa Cheia";
            this.lciTotalTarifaCheia.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTotalTarifaUtilizada
            // 
            this.lciTotalTarifaUtilizada.Control = this.txtTarifaUtilizada;
            this.lciTotalTarifaUtilizada.Location = new System.Drawing.Point(678, 60);
            this.lciTotalTarifaUtilizada.Name = "lciTotalTarifaUtilizada";
            this.lciTotalTarifaUtilizada.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTotalTarifaUtilizada.Size = new System.Drawing.Size(170, 30);
            this.lciTotalTarifaUtilizada.Text = "Total Tarifa Utilizada";
            this.lciTotalTarifaUtilizada.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTotalTaxasExtras
            // 
            this.lciTotalTaxasExtras.Control = this.txtTaxasExtras;
            this.lciTotalTaxasExtras.Location = new System.Drawing.Point(678, 90);
            this.lciTotalTaxasExtras.Name = "lciTotalTaxasExtras";
            this.lciTotalTaxasExtras.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTotalTaxasExtras.Size = new System.Drawing.Size(170, 30);
            this.lciTotalTaxasExtras.Text = "Total Taxas Extras";
            this.lciTotalTaxasExtras.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTaxaIntermediacao
            // 
            this.lciTaxaIntermediacao.Control = this.txtTaxaIntermediacao;
            this.lciTaxaIntermediacao.Location = new System.Drawing.Point(678, 120);
            this.lciTaxaIntermediacao.Name = "lciTaxaIntermediacao";
            this.lciTaxaIntermediacao.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTaxaIntermediacao.Size = new System.Drawing.Size(170, 30);
            this.lciTaxaIntermediacao.Text = "Taxa Intermediacao";
            this.lciTaxaIntermediacao.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciTaxaAdministrativa
            // 
            this.lciTaxaAdministrativa.Control = this.txtTaxaAdministrativa;
            this.lciTaxaAdministrativa.Location = new System.Drawing.Point(678, 150);
            this.lciTaxaAdministrativa.Name = "lciTaxaAdministrativa";
            this.lciTaxaAdministrativa.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciTaxaAdministrativa.Size = new System.Drawing.Size(170, 30);
            this.lciTaxaAdministrativa.Text = "Taxa Administrativa";
            this.lciTaxaAdministrativa.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciSinalFornecedor
            // 
            this.lciSinalFornecedor.Control = this.txtSinalFornecedor;
            this.lciSinalFornecedor.Location = new System.Drawing.Point(678, 180);
            this.lciSinalFornecedor.Name = "lciSinalFornecedor";
            this.lciSinalFornecedor.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciSinalFornecedor.Size = new System.Drawing.Size(170, 30);
            this.lciSinalFornecedor.Text = "Sinal Fornecedor";
            this.lciSinalFornecedor.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciDesconto
            // 
            this.lciDesconto.Control = this.txtDesconto;
            this.lciDesconto.Location = new System.Drawing.Point(678, 210);
            this.lciDesconto.Name = "lciDesconto";
            this.lciDesconto.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDesconto.Size = new System.Drawing.Size(170, 30);
            this.lciDesconto.Text = "Desconto";
            this.lciDesconto.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciAcrescimo
            // 
            this.lciAcrescimo.Control = this.txtAcrescimo;
            this.lciAcrescimo.Location = new System.Drawing.Point(678, 240);
            this.lciAcrescimo.Name = "lciAcrescimo";
            this.lciAcrescimo.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciAcrescimo.Size = new System.Drawing.Size(170, 30);
            this.lciAcrescimo.Text = "Acréscimo";
            this.lciAcrescimo.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciEntradaCliente
            // 
            this.lciEntradaCliente.Control = this.txtEntradaCliente;
            this.lciEntradaCliente.Location = new System.Drawing.Point(678, 270);
            this.lciEntradaCliente.Name = "lciEntradaCliente";
            this.lciEntradaCliente.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciEntradaCliente.Size = new System.Drawing.Size(170, 30);
            this.lciEntradaCliente.Text = "Entrada Cliente";
            this.lciEntradaCliente.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciLiquido
            // 
            this.lciLiquido.Control = this.txtLiquido;
            this.lciLiquido.Location = new System.Drawing.Point(678, 300);
            this.lciLiquido.Name = "lciLiquido";
            this.lciLiquido.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciLiquido.Size = new System.Drawing.Size(170, 30);
            this.lciLiquido.Text = "Líquido";
            this.lciLiquido.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciVendaMoeda
            // 
            this.lciVendaMoeda.Control = this.cboVendaMoeda;
            this.lciVendaMoeda.Location = new System.Drawing.Point(678, 0);
            this.lciVendaMoeda.Name = "lciVendaMoeda";
            this.lciVendaMoeda.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciVendaMoeda.Size = new System.Drawing.Size(170, 30);
            this.lciVendaMoeda.Text = "Moeda";
            this.lciVendaMoeda.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciDataSaida
            // 
            this.lciDataSaida.Control = this.dteDataSaida;
            this.lciDataSaida.Location = new System.Drawing.Point(0, 270);
            this.lciDataSaida.Name = "lciDataSaida";
            this.lciDataSaida.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDataSaida.Size = new System.Drawing.Size(348, 30);
            this.lciDataSaida.Text = "Data de saída";
            this.lciDataSaida.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciConversaoCambio
            // 
            this.lciConversaoCambio.Control = this.txtConversaoCambio;
            this.lciConversaoCambio.Location = new System.Drawing.Point(348, 270);
            this.lciConversaoCambio.Name = "lciConversaoCambio";
            this.lciConversaoCambio.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciConversaoCambio.Size = new System.Drawing.Size(330, 30);
            this.lciConversaoCambio.Text = "Câmbio";
            this.lciConversaoCambio.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciDataRetorno
            // 
            this.lciDataRetorno.Control = this.dteDataRetorno;
            this.lciDataRetorno.Location = new System.Drawing.Point(0, 300);
            this.lciDataRetorno.Name = "lciDataRetorno";
            this.lciDataRetorno.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciDataRetorno.Size = new System.Drawing.Size(348, 30);
            this.lciDataRetorno.Text = "Data de retorno";
            this.lciDataRetorno.TextSize = new System.Drawing.Size(102, 13);
            // 
            // lciConversaoLiquido
            // 
            this.lciConversaoLiquido.Control = this.txtConversaoLiquido;
            this.lciConversaoLiquido.Location = new System.Drawing.Point(348, 300);
            this.lciConversaoLiquido.Name = "lciConversaoLiquido";
            this.lciConversaoLiquido.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.lciConversaoLiquido.Size = new System.Drawing.Size(330, 30);
            this.lciConversaoLiquido.Text = "Liquido (BRL)";
            this.lciConversaoLiquido.TextSize = new System.Drawing.Size(102, 13);
            // 
            // Root3
            // 
            this.Root3.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root3.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root3.CustomizationFormText = "Root";
            this.Root3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root3.ExpandButtonVisible = true;
            this.Root3.Location = new System.Drawing.Point(0, 532);
            this.Root3.Name = "Root3";
            this.Root3.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root3.Size = new System.Drawing.Size(848, 41);
            this.Root3.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root3.Text = "Back Office - Informações Adicionais";
            // 
            // Root4
            // 
            this.Root4.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root4.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root4.CustomizationFormText = "Root";
            this.Root4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root4.ExpandButtonVisible = true;
            this.Root4.Location = new System.Drawing.Point(0, 573);
            this.Root4.Name = "Root4";
            this.Root4.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root4.Size = new System.Drawing.Size(848, 41);
            this.Root4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root4.Text = "Back Office - Informações Adicionais";
            // 
            // Root5
            // 
            this.Root5.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root5.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root5.CustomizationFormText = "Root";
            this.Root5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root5.ExpandButtonVisible = true;
            this.Root5.Location = new System.Drawing.Point(0, 614);
            this.Root5.Name = "Root5";
            this.Root5.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root5.Size = new System.Drawing.Size(848, 41);
            this.Root5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root5.Text = "Back Office - Informações Adicionais";
            // 
            // Root6
            // 
            this.Root6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root6.CustomizationFormText = "Root";
            this.Root6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root6.ExpandButtonVisible = true;
            this.Root6.Location = new System.Drawing.Point(0, 655);
            this.Root6.Name = "Root6";
            this.Root6.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root6.Size = new System.Drawing.Size(848, 41);
            this.Root6.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root6.Text = "Back Office - Informações Adicionais";
            // 
            // Root7
            // 
            this.Root7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root7.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root7.CustomizationFormText = "Root";
            this.Root7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root7.ExpandButtonVisible = true;
            this.Root7.Location = new System.Drawing.Point(0, 696);
            this.Root7.Name = "Root7";
            this.Root7.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root7.Size = new System.Drawing.Size(848, 41);
            this.Root7.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root7.Text = "Back Office - Informações Adicionais";
            // 
            // Root8
            // 
            this.Root8.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root8.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root8.CustomizationFormText = "Root";
            this.Root8.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root8.ExpandButtonVisible = true;
            this.Root8.Location = new System.Drawing.Point(0, 737);
            this.Root8.Name = "Root8";
            this.Root8.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root8.Size = new System.Drawing.Size(848, 41);
            this.Root8.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root8.Text = "Back Office - Informações Adicionais";
            // 
            // Root9
            // 
            this.Root9.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root9.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root9.CustomizationFormText = "Root";
            this.Root9.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root9.ExpandButtonVisible = true;
            this.Root9.Location = new System.Drawing.Point(0, 778);
            this.Root9.Name = "Root9";
            this.Root9.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root9.Size = new System.Drawing.Size(848, 41);
            this.Root9.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root9.Text = "Back Office - Informações Adicionais";
            // 
            // Root10
            // 
            this.Root10.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root10.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root10.CustomizationFormText = "Root";
            this.Root10.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root10.ExpandButtonVisible = true;
            this.Root10.Location = new System.Drawing.Point(0, 819);
            this.Root10.Name = "Root10";
            this.Root10.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root10.Size = new System.Drawing.Size(848, 41);
            this.Root10.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root10.Text = "Back Office - Informações Adicionais";
            // 
            // Root11
            // 
            this.Root11.AppearanceItemCaption.Options.UseTextOptions = true;
            this.Root11.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Root11.CustomizationFormText = "Root";
            this.Root11.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root11.ExpandButtonVisible = true;
            this.Root11.Location = new System.Drawing.Point(0, 860);
            this.Root11.Name = "Root11";
            this.Root11.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root11.Size = new System.Drawing.Size(848, 41);
            this.Root11.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root11.Text = "Back Office - Informações Adicionais";
            // 
            // Root2
            // 
            this.Root2.CustomizationFormText = "Root";
            this.Root2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root2.ExpandButtonVisible = true;
            this.Root2.Location = new System.Drawing.Point(0, 491);
            this.Root2.Name = "Root2";
            this.Root2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.Root2.Size = new System.Drawing.Size(848, 41);
            this.Root2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root2.Text = "Back Office - Informações Adicionais";
            // 
            // frmRequisicaoEdicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(889, 499);
            this.Controls.Add(this.gpcEdicao);
            this.Controls.Add(this.sctDivisorGeral);
            this.Controls.Add(this.mrcMenu);
            this.Name = "frmRequisicaoEdicao";
            this.Ribbon = this.mrcMenu;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmRequisicaoEdicao_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.mrcMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroProcesso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteAbertura.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteAbertura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResumoRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResumoProcesso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcDadosProcesso)).EndInit();
            this.gpcDadosProcesso.ResumeLayout(false);
            this.gpcDadosProcesso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sctDivisorGeral)).EndInit();
            this.sctDivisorGeral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sctResumos)).EndInit();
            this.sctResumos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcEdicao)).EndInit();
            this.gpcEdicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layFormulario)).EndInit();
            this.layFormulario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNroVoucher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConversaoLiquido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataRetorno.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataRetorno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConversaoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataSaida.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataSaida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLiquido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntradaCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcrescimo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSinalFornecedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxaAdministrativa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxaIntermediacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxasExtras.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaUtilizada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarifaCheia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaMoeda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaFormaPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendaTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memObservacao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEvento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGrupo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmissor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memTrechoPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memPAX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCentroCusto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTKTStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTKTNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdutoQuantidade.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFornecedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboConsolidador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRLOCAtt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequisicaoStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRequisicao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataEmissao.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDataEmissao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgFrontOfficeVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataEmissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRequisicaoStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNroRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRLOCAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciProdutoQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCentroCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEvento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciObservacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciReservaVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmissor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTrechoPeriodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConsolidador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTKTNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTKTNumerok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaFormaPagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTarifaCheia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTarifaUtilizada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTotalTaxasExtras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTaxaIntermediacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTaxaAdministrativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSinalFornecedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAcrescimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEntradaCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLiquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciVendaMoeda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataSaida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConversaoCambio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDataRetorno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConversaoLiquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl mrcMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpgMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSalvar;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.DefaultBarAndDockingController bdcMenuControler;
        private DevExpress.XtraBars.PopupMenu popProdutos;
        private DevExpress.XtraBars.PopupMenu popSalvar;
        private DevExpress.XtraEditors.TextEdit txtNroProcesso;
        private DevExpress.XtraEditors.DateEdit dteAbertura;
        private DevExpress.XtraTreeList.TreeList trvProdutos;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProduto;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNroRequisicao;
        private DevExpress.XtraEditors.GroupControl gpcResumoRequisicao;
        private DevExpress.XtraEditors.GroupControl gpcResumoProcesso;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.LabelControl lblNroProcesso;
        private DevExpress.XtraEditors.LabelControl lblAbertura;
        private DevExpress.XtraEditors.LabelControl lblUnidade;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPassageiro;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDataIn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDataOut;
        private DevExpress.XtraEditors.GroupControl gpcDadosProcesso;
        private DevExpress.XtraBars.BarButtonItem bbiAdicionarProduto;
        private DevExpress.XtraBars.BarButtonItem bbiAlterarProduto;
        private DevExpress.XtraBars.BarButtonItem bbiExcluirProduto;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgAcoesProdutos;
        private DevExpress.XtraEditors.LookUpEdit cboUnidade;
        private DevExpress.XtraEditors.LookUpEdit cboCliente;
        private DevExpress.XtraEditors.SplitContainerControl sctDivisorGeral;
        private DevExpress.XtraEditors.SplitContainerControl sctResumos;
        private DevExpress.XtraBars.BarButtonItem bbiAereo;
        private DevExpress.XtraBars.BarButtonItem bbiHospedagem;
        private DevExpress.XtraBars.BarButtonItem bbiLocacao;
        private DevExpress.XtraBars.BarButtonItem bbiTransfer;
        private DevExpress.XtraBars.BarButtonItem bbiCruzeiro;
        private DevExpress.XtraBars.BarButtonItem bbiServicos;
        private DevExpress.XtraEditors.GroupControl gpcEdicao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSelecaoProdutos;
        private DevExpress.XtraLayout.LayoutControl layFormulario;
        private DevExpress.XtraLayout.LayoutControlGroup lcgFrontOfficeVendas;
        private DevExpress.XtraEditors.DateEdit dteDataEmissao;
        private DevExpress.XtraLayout.LayoutControlItem lciDataEmissao;
        private DevExpress.XtraEditors.ComboBoxEdit cboRequisicaoStatus;
        private DevExpress.XtraEditors.TextEdit txtNroRequisicao;
        private DevExpress.XtraLayout.LayoutControlItem lciRequisicaoStatus;
        private DevExpress.XtraLayout.LayoutControlItem lciNroRequisicao;
        private DevExpress.XtraEditors.TextEdit txtProdutoQuantidade;
        private DevExpress.XtraEditors.LookUpEdit cboFornecedor;
        private DevExpress.XtraEditors.LookUpEdit cboConsolidador;
        private DevExpress.XtraEditors.LookUpEdit cboProduto;
        private DevExpress.XtraEditors.TextEdit txtRLOCAtt;
        private DevExpress.XtraLayout.LayoutControlItem lciProduto;
        private DevExpress.XtraLayout.LayoutControlItem lciConsolidador;
        private DevExpress.XtraLayout.LayoutControlItem lciFornecedor;
        private DevExpress.XtraLayout.LayoutControlItem lciRLOCAtt;
        private DevExpress.XtraLayout.LayoutControlItem lciProdutoQuantidade;
        private DevExpress.XtraEditors.LookUpEdit cboCentroCusto;
        private DevExpress.XtraEditors.ComboBoxEdit cboTKTStatus;
        private DevExpress.XtraEditors.TextEdit txtTKTNumero;
        private DevExpress.XtraLayout.LayoutControlItem lciCentroCusto;
        private DevExpress.XtraLayout.LayoutControlItem lciTKTNumerok;
        private DevExpress.XtraLayout.LayoutControlItem lciTKTNumero;
        private DevExpress.XtraEditors.MemoEdit memTrechoPeriodo;
        private DevExpress.XtraEditors.MemoEdit memPAX;
        private DevExpress.XtraLayout.LayoutControlItem lciPAX;
        private DevExpress.XtraLayout.LayoutControlItem lciTrechoPeriodo;
        private DevExpress.XtraEditors.LookUpEdit cboEmissor;
        private DevExpress.XtraLayout.LayoutControlGroup Root1;
        private DevExpress.XtraLayout.LayoutControlItem lciEmissor;
        private DevExpress.XtraEditors.MemoEdit memObservacao;
        private DevExpress.XtraEditors.LookUpEdit cboEvento;
        private DevExpress.XtraEditors.LookUpEdit cboGrupo;
        private DevExpress.XtraLayout.LayoutControlItem lciEvento;
        private DevExpress.XtraLayout.LayoutControlItem lciGrupo;
        private DevExpress.XtraLayout.LayoutControlItem lciObservacao;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendaMoeda;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendaFormaPagamento;
        private DevExpress.XtraEditors.ComboBoxEdit cboVendaTipo;
        private DevExpress.XtraLayout.LayoutControlItem lciVendaTipo;
        private DevExpress.XtraLayout.LayoutControlItem lciVendaFormaPagamento;
        private DevExpress.XtraLayout.LayoutControlItem lciVendaMoeda;
        private DevExpress.XtraEditors.TextEdit txtLiquido;
        private DevExpress.XtraEditors.TextEdit txtEntradaCliente;
        private DevExpress.XtraEditors.TextEdit txtAcrescimo;
        private DevExpress.XtraEditors.TextEdit txtDesconto;
        private DevExpress.XtraEditors.TextEdit txtSinalFornecedor;
        private DevExpress.XtraEditors.TextEdit txtTaxaAdministrativa;
        private DevExpress.XtraEditors.TextEdit txtTaxaIntermediacao;
        private DevExpress.XtraEditors.TextEdit txtTaxasExtras;
        private DevExpress.XtraEditors.TextEdit txtTarifaUtilizada;
        private DevExpress.XtraEditors.TextEdit txtTarifaCheia;
        private DevExpress.XtraLayout.LayoutControlItem lciTotalTarifaCheia;
        private DevExpress.XtraLayout.LayoutControlItem lciTotalTarifaUtilizada;
        private DevExpress.XtraLayout.LayoutControlItem lciTotalTaxasExtras;
        private DevExpress.XtraLayout.LayoutControlItem lciTaxaIntermediacao;
        private DevExpress.XtraLayout.LayoutControlItem lciTaxaAdministrativa;
        private DevExpress.XtraLayout.LayoutControlItem lciSinalFornecedor;
        private DevExpress.XtraLayout.LayoutControlItem lciDesconto;
        private DevExpress.XtraLayout.LayoutControlItem lciAcrescimo;
        private DevExpress.XtraLayout.LayoutControlItem lciEntradaCliente;
        private DevExpress.XtraLayout.LayoutControlItem lciLiquido;
        private DevExpress.XtraEditors.TextEdit txtNroVoucher;
        private DevExpress.XtraEditors.TextEdit txtConversaoLiquido;
        private DevExpress.XtraEditors.DateEdit dteDataRetorno;
        private DevExpress.XtraEditors.TextEdit txtConversaoCambio;
        private DevExpress.XtraEditors.DateEdit dteDataSaida;
        private DevExpress.XtraLayout.LayoutControlItem lciReservaVoucher;
        private DevExpress.XtraLayout.LayoutControlItem lciDataSaida;
        private DevExpress.XtraLayout.LayoutControlItem lciConversaoCambio;
        private DevExpress.XtraLayout.LayoutControlItem lciDataRetorno;
        private DevExpress.XtraLayout.LayoutControlItem lciConversaoLiquido;
        private DevExpress.XtraLayout.LayoutControlGroup Root2;
        private DevExpress.XtraLayout.LayoutControlGroup Root3;
        private DevExpress.XtraLayout.LayoutControlGroup Root4;
        private DevExpress.XtraLayout.LayoutControlGroup Root5;
        private DevExpress.XtraLayout.LayoutControlGroup Root6;
        private DevExpress.XtraLayout.LayoutControlGroup Root7;
        private DevExpress.XtraLayout.LayoutControlGroup Root8;
        private DevExpress.XtraLayout.LayoutControlGroup Root9;
        private DevExpress.XtraLayout.LayoutControlGroup Root10;
        private DevExpress.XtraLayout.LayoutControlGroup Root11;
    }
}