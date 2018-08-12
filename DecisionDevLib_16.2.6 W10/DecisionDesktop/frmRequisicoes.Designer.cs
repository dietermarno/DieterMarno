namespace DecisionDesktop
{
    partial class frmRequisicoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequisicoes));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.mscInsert = new Devart.Data.MySql.MySqlCommand();
            this.mscUpdate = new Devart.Data.MySql.MySqlCommand();
            this.mscDelete = new Devart.Data.MySql.MySqlCommand();
            this.grcRequisicoes = new DevExpress.XtraGrid.GridControl();
            this.grvRequisicoes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNroProcesso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroRequis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomePosto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colconsolidador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFornecedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroTkt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCentroCusto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrecho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmissor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescAgrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescEvento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacoes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbertura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmissao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumVoucher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRetorno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNroFatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVencimento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNossaNFCli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctoBaixa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNossaNFFor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ricRequisicao = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiIncluir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExcluir = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAlterar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExibirFiltro = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEliminarFiltro = new DevExpress.XtraBars.BarButtonItem();
            this.rpgRequisicao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgManutencao = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgLocalizar = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bdcMenuControler = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grcRequisicoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequisicoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).BeginInit();
            this.SuspendLayout();
            // 
            // mscInsert
            // 
            this.mscInsert.CommandText = resources.GetString("mscInsert.CommandText");
            this.mscInsert.Name = "mscInsert";
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Emissao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Emissao", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Localizador", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Localizador", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodPosto", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPosto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("TipoVenda", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "TipoVenda", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Moeda", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Moeda", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodProduto", Devart.Data.MySql.MySqlType.SmallInt, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodProduto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodFornec", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroTkt", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroTkt", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitTkt", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitTkt", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCli", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CentroCusto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CentroCusto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Pax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Pax", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Trecho", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Trecho", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs1", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTotal", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTotal", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTaxas", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTaxas", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAdmin", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAdmin", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrSinal", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrSinal", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrDesc", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrDesc", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAcres", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAcres", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrEntrada", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrEntrada", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCambio", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCambio", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("FormaRecbto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "FormaRecbto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtVencto", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtVencto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodBco", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodBco", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroFatura", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroFatura", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroRecibo", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroRecibo", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VenctoFornec", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VenctoFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodIncent", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodIncent", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodAgencia", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcAgencia", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcAgencia", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncAgencia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodEmissor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DescCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DescCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumOp", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumOp", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumVoucher", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumVoucher", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodAgrup", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodAgrup", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodEvento", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodEvento", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodContaDestino", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodContaDestino", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodContaOrigem", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodContaOrigem", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuFatura", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuFatura", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuRecibo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuRecibo", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuBloqueto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuBloqueto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtQuitaFatura", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtQuitaFatura", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtQuitaFornecedor", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtQuitaFornecedor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs2", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs2", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtViagem", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtViagem", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("MoedaRecebto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "MoedaRecebto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtRetorno", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtRetorno", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("AbateComissTer", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "AbateComissTer", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataRecebe", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataRecebe", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DescSobre", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DescSobre", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndicePontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndicePontos", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercentPontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercentPontos", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("QtdePontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "QtdePontos", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtUltimaAlteracao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtUltimaAlteracao", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("UltimaAlteracaoPor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "UltimaAlteracaoPor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NossaNF", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NossaNF", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrFaturaFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrFaturaFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrDoctoFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrDoctoFornec", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisEmissor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisPromotor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisTerceiro", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisTerceiro", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAcresFatCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAcresFatCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrISS", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrISS", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrIR", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrIR", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCPMF", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCPMF", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SituacaoRequisicao", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SituacaoRequisicao", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidadeReq", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidadeReq", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTarifaCheia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTarifaCheia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataFatura", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataFatura", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercLeiKandir", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercLeiKandir", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrLeiKandirTarifa", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrLeiKandirTarifa", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrLeiKandirTaxa", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrLeiKandirTaxa", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtEncaminha", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtEncaminha", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtRecRetencao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtRecRetencao", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroProcesso", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroProcesso", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseDesc", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseDesc", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercLeiKandirTx", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercLeiKandirTx", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodConsolidador", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodConsolidador", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("AbateComissFor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "AbateComissFor", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DoctoBaixa", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DoctoBaixa", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("MoedaPagto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "MoedaPagto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCambioPagto", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCambioPagto", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumCotiza", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumCotiza", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTxIntermedia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTxIntermedia", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercDesRepasse", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercDesRepasse", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrRepasse", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrRepasse", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtLanctoReq", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtLanctoReq", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTxOutras", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTxOutras", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs3", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs3", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroProtocoloCli", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroProtocoloCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataEncProtCli", Devart.Data.MySql.MySqlType.Date, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataEncProtCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataRecDarfCli", Devart.Data.MySql.MySqlType.Date, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataRecDarfCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroCarta", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroCarta", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NossaNFCli", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NossaNFCli", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("QtdeProd", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "QtdeProd", System.Data.DataRowVersion.Current, null));
            this.mscInsert.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrAutorizacao", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrAutorizacao", System.Data.DataRowVersion.Current, null));
            this.mscInsert.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mscInsert.Owner = this;
            // 
            // mscUpdate
            // 
            this.mscUpdate.CommandText = resources.GetString("mscUpdate.CommandText");
            this.mscUpdate.Name = "mscUpdate";
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Emissao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Emissao", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Localizador", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Localizador", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodPosto", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPosto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("TipoVenda", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "TipoVenda", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Moeda", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Moeda", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodProduto", Devart.Data.MySql.MySqlType.SmallInt, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodProduto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodFornec", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroTkt", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroTkt", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitTkt", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitTkt", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCli", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CentroCusto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CentroCusto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Pax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Pax", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Trecho", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Trecho", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs1", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTotal", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTotal", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTaxas", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTaxas", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAdmin", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAdmin", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrSinal", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrSinal", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrDesc", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrDesc", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAcres", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAcres", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrEntrada", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrEntrada", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCambio", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCambio", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("FormaRecbto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "FormaRecbto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtVencto", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtVencto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodBco", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodBco", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroFatura", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroFatura", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroRecibo", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroRecibo", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VenctoFornec", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VenctoFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodIncent", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodIncent", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodAgencia", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcAgencia", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcAgencia", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncAgencia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncAgencia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncPromotor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodEmissor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseCalcEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseCalcEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncEmissor", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ComissFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ComissFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValComFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValComFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CalcFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CalcFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncFornec", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DescCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DescCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IncentCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IncentCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("ValIncCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "ValIncCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumOp", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumOp", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumVoucher", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumVoucher", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodAgrup", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodAgrup", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodEvento", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodEvento", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodContaDestino", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodContaDestino", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodContaOrigem", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodContaOrigem", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuFatura", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuFatura", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuRecibo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuRecibo", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EmitiuBloqueto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EmitiuBloqueto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtQuitaFatura", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtQuitaFatura", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtQuitaFornecedor", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtQuitaFornecedor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs2", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs2", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtViagem", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtViagem", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("MoedaRecebto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "MoedaRecebto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtRetorno", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtRetorno", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("AbateComissTer", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "AbateComissTer", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataRecebe", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataRecebe", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DescSobre", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DescSobre", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("IndicePontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "IndicePontos", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercentPontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercentPontos", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("QtdePontos", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "QtdePontos", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtUltimaAlteracao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtUltimaAlteracao", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("UltimaAlteracaoPor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "UltimaAlteracaoPor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NossaNF", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NossaNF", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrFaturaFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrFaturaFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrDoctoFornec", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrDoctoFornec", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisEmissor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisEmissor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisPromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisPromotor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SitComisTerceiro", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SitComisTerceiro", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrAcresFatCli", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrAcresFatCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrISS", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrISS", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrIR", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrIR", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCPMF", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCPMF", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("SituacaoRequisicao", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "SituacaoRequisicao", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidadeReq", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidadeReq", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTarifaCheia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTarifaCheia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataFatura", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataFatura", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercLeiKandir", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercLeiKandir", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrLeiKandirTarifa", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrLeiKandirTarifa", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrLeiKandirTaxa", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrLeiKandirTaxa", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtEncaminha", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtEncaminha", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtRecRetencao", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtRecRetencao", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroProcesso", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroProcesso", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("BaseDesc", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "BaseDesc", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercLeiKandirTx", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercLeiKandirTx", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodConsolidador", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodConsolidador", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("AbateComissFor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "AbateComissFor", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DoctoBaixa", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DoctoBaixa", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("MoedaPagto", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "MoedaPagto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrCambioPagto", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrCambioPagto", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NumCotiza", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NumCotiza", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTxIntermedia", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTxIntermedia", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("PercDesRepasse", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "PercDesRepasse", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrRepasse", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrRepasse", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DtLanctoReq", Devart.Data.MySql.MySqlType.DateTime, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DtLanctoReq", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("VlrTxOutras", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "VlrTxOutras", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs3", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs3", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroProtocoloCli", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroProtocoloCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataEncProtCli", Devart.Data.MySql.MySqlType.Date, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataEncProtCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("DataRecDarfCli", Devart.Data.MySql.MySqlType.Date, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "DataRecDarfCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NroCarta", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroCarta", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NossaNFCli", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NossaNFCli", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("QtdeProd", Devart.Data.MySql.MySqlType.Double, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "QtdeProd", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NrAutorizacao", Devart.Data.MySql.MySqlType.VarChar, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NrAutorizacao", System.Data.DataRowVersion.Current, null));
            this.mscUpdate.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_NroRequis", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroRequis", System.Data.DataRowVersion.Original, null));
            this.mscUpdate.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mscUpdate.Owner = this;
            // 
            // mscDelete
            // 
            this.mscDelete.CommandText = "DELETE FROM dbturis_desktop.requisicao WHERE ((NroRequis = :Original_NroRequis))";
            this.mscDelete.Name = "mscDelete";
            this.mscDelete.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_NroRequis", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NroRequis", System.Data.DataRowVersion.Original, null));
            this.mscDelete.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mscDelete.Owner = this;
            // 
            // grcRequisicoes
            // 
            this.grcRequisicoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcRequisicoes.Location = new System.Drawing.Point(0, 146);
            this.grcRequisicoes.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.grcRequisicoes.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grcRequisicoes.MainView = this.grvRequisicoes;
            this.grcRequisicoes.Name = "grcRequisicoes";
            this.grcRequisicoes.Size = new System.Drawing.Size(907, 399);
            this.grcRequisicoes.TabIndex = 1;
            this.grcRequisicoes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRequisicoes});
            this.grcRequisicoes.DoubleClick += new System.EventHandler(this.grcRequisicoes_DoubleClick);
            // 
            // grvRequisicoes
            // 
            this.grvRequisicoes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNroProcesso,
            this.colNroRequis,
            this.colNomePosto,
            this.colCliente,
            this.colPax,
            this.colStatus,
            this.colProduto,
            this.colconsolidador,
            this.colFornecedor,
            this.colNroTkt,
            this.colCentroCusto,
            this.colTrecho,
            this.colEmissor,
            this.colDescAgrup,
            this.colDescEvento,
            this.colObservacoes,
            this.colAbertura,
            this.colEmissao,
            this.colNumVoucher,
            this.colSaida,
            this.colRetorno,
            this.colNroFatura,
            this.colVencimento,
            this.colNossaNFCli,
            this.colDoctoBaixa,
            this.colNossaNFFor});
            this.grvRequisicoes.GridControl = this.grcRequisicoes;
            this.grvRequisicoes.Name = "grvRequisicoes";
            this.grvRequisicoes.OptionsFind.AlwaysVisible = true;
            this.grvRequisicoes.OptionsView.ShowIndicator = false;
            // 
            // colNroProcesso
            // 
            this.colNroProcesso.Caption = "Nº Proc.";
            this.colNroProcesso.FieldName = "NroProcesso";
            this.colNroProcesso.Name = "colNroProcesso";
            this.colNroProcesso.OptionsColumn.AllowFocus = false;
            this.colNroProcesso.OptionsColumn.AllowSize = false;
            this.colNroProcesso.OptionsColumn.FixedWidth = true;
            this.colNroProcesso.OptionsEditForm.ColumnSpan = 2;
            this.colNroProcesso.Visible = true;
            this.colNroProcesso.VisibleIndex = 0;
            this.colNroProcesso.Width = 60;
            // 
            // colNroRequis
            // 
            this.colNroRequis.Caption = "Nº Req.";
            this.colNroRequis.FieldName = "NroRequis";
            this.colNroRequis.Name = "colNroRequis";
            this.colNroRequis.OptionsColumn.AllowFocus = false;
            this.colNroRequis.OptionsColumn.AllowSize = false;
            this.colNroRequis.OptionsColumn.FixedWidth = true;
            this.colNroRequis.Visible = true;
            this.colNroRequis.VisibleIndex = 1;
            this.colNroRequis.Width = 60;
            // 
            // colNomePosto
            // 
            this.colNomePosto.Caption = "Unidade";
            this.colNomePosto.FieldName = "NomePosto";
            this.colNomePosto.Name = "colNomePosto";
            this.colNomePosto.OptionsColumn.AllowFocus = false;
            this.colNomePosto.Width = 64;
            // 
            // colCliente
            // 
            this.colCliente.Caption = "Cliente";
            this.colCliente.FieldName = "cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.OptionsColumn.AllowFocus = false;
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 3;
            this.colCliente.Width = 112;
            // 
            // colPax
            // 
            this.colPax.Caption = "Pax";
            this.colPax.FieldName = "Pax";
            this.colPax.Name = "colPax";
            this.colPax.OptionsColumn.AllowFocus = false;
            this.colPax.Visible = true;
            this.colPax.VisibleIndex = 2;
            this.colPax.Width = 121;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Situação";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 7;
            this.colStatus.Width = 60;
            // 
            // colProduto
            // 
            this.colProduto.Caption = "Produto";
            this.colProduto.FieldName = "produto";
            this.colProduto.Name = "colProduto";
            this.colProduto.OptionsColumn.AllowFocus = false;
            this.colProduto.Visible = true;
            this.colProduto.VisibleIndex = 4;
            this.colProduto.Width = 108;
            // 
            // colconsolidador
            // 
            this.colconsolidador.Caption = "Consolidador";
            this.colconsolidador.FieldName = "consolidador";
            this.colconsolidador.Name = "colconsolidador";
            this.colconsolidador.OptionsColumn.AllowFocus = false;
            this.colconsolidador.Width = 68;
            // 
            // colFornecedor
            // 
            this.colFornecedor.Caption = "Fornecedor";
            this.colFornecedor.FieldName = "fornecedor";
            this.colFornecedor.Name = "colFornecedor";
            this.colFornecedor.OptionsColumn.AllowFocus = false;
            this.colFornecedor.Visible = true;
            this.colFornecedor.VisibleIndex = 5;
            this.colFornecedor.Width = 119;
            // 
            // colNroTkt
            // 
            this.colNroTkt.Caption = "Nº TKT";
            this.colNroTkt.FieldName = "NroTkt";
            this.colNroTkt.Name = "colNroTkt";
            this.colNroTkt.OptionsColumn.AllowFocus = false;
            this.colNroTkt.OptionsColumn.AllowSize = false;
            this.colNroTkt.Width = 54;
            // 
            // colCentroCusto
            // 
            this.colCentroCusto.Caption = "C.C.";
            this.colCentroCusto.FieldName = "CentroCusto";
            this.colCentroCusto.Name = "colCentroCusto";
            this.colCentroCusto.OptionsColumn.AllowFocus = false;
            // 
            // colTrecho
            // 
            this.colTrecho.Caption = "Trecho";
            this.colTrecho.FieldName = "Trecho";
            this.colTrecho.Name = "colTrecho";
            this.colTrecho.OptionsColumn.AllowFocus = false;
            // 
            // colEmissor
            // 
            this.colEmissor.Caption = "Emissor";
            this.colEmissor.FieldName = "Emissor";
            this.colEmissor.Name = "colEmissor";
            this.colEmissor.OptionsColumn.AllowFocus = false;
            this.colEmissor.Visible = true;
            this.colEmissor.VisibleIndex = 6;
            this.colEmissor.Width = 127;
            // 
            // colDescAgrup
            // 
            this.colDescAgrup.Caption = "Grupo";
            this.colDescAgrup.FieldName = "DescAgrup";
            this.colDescAgrup.Name = "colDescAgrup";
            this.colDescAgrup.OptionsColumn.AllowFocus = false;
            this.colDescAgrup.Width = 71;
            // 
            // colDescEvento
            // 
            this.colDescEvento.Caption = "Evento";
            this.colDescEvento.FieldName = "DescEvento";
            this.colDescEvento.Name = "colDescEvento";
            this.colDescEvento.OptionsColumn.AllowFocus = false;
            // 
            // colObservacoes
            // 
            this.colObservacoes.Caption = "Observações";
            this.colObservacoes.FieldName = "observacoes";
            this.colObservacoes.Name = "colObservacoes";
            this.colObservacoes.OptionsColumn.AllowFocus = false;
            // 
            // colAbertura
            // 
            this.colAbertura.Caption = "Abertura";
            this.colAbertura.FieldName = "Abertura";
            this.colAbertura.Name = "colAbertura";
            this.colAbertura.OptionsColumn.AllowFocus = false;
            // 
            // colEmissao
            // 
            this.colEmissao.Caption = "Emissão";
            this.colEmissao.FieldName = "Emissao";
            this.colEmissao.Name = "colEmissao";
            this.colEmissao.OptionsColumn.AllowFocus = false;
            // 
            // colNumVoucher
            // 
            this.colNumVoucher.Caption = "Nº Voucher";
            this.colNumVoucher.FieldName = "NumVoucher";
            this.colNumVoucher.Name = "colNumVoucher";
            this.colNumVoucher.OptionsColumn.AllowFocus = false;
            // 
            // colSaida
            // 
            this.colSaida.Caption = "Saida";
            this.colSaida.FieldName = "Saida";
            this.colSaida.Name = "colSaida";
            this.colSaida.OptionsColumn.AllowFocus = false;
            this.colSaida.OptionsColumn.AllowSize = false;
            this.colSaida.OptionsColumn.FixedWidth = true;
            this.colSaida.Visible = true;
            this.colSaida.VisibleIndex = 8;
            this.colSaida.Width = 70;
            // 
            // colRetorno
            // 
            this.colRetorno.Caption = "Retorno";
            this.colRetorno.FieldName = "Retorno";
            this.colRetorno.Name = "colRetorno";
            this.colRetorno.OptionsColumn.AllowFocus = false;
            this.colRetorno.OptionsColumn.AllowSize = false;
            this.colRetorno.OptionsColumn.FixedWidth = true;
            this.colRetorno.Visible = true;
            this.colRetorno.VisibleIndex = 9;
            this.colRetorno.Width = 70;
            // 
            // colNroFatura
            // 
            this.colNroFatura.Caption = "Nº Fatura";
            this.colNroFatura.FieldName = "NroFatura";
            this.colNroFatura.Name = "colNroFatura";
            this.colNroFatura.OptionsColumn.AllowFocus = false;
            // 
            // colVencimento
            // 
            this.colVencimento.Caption = "Vencimento";
            this.colVencimento.FieldName = "Vencimento";
            this.colVencimento.Name = "colVencimento";
            this.colVencimento.OptionsColumn.AllowFocus = false;
            // 
            // colNossaNFCli
            // 
            this.colNossaNFCli.Caption = "NF.Cliente";
            this.colNossaNFCli.FieldName = "NossaNFCli";
            this.colNossaNFCli.Name = "colNossaNFCli";
            this.colNossaNFCli.OptionsColumn.AllowFocus = false;
            // 
            // colDoctoBaixa
            // 
            this.colDoctoBaixa.Caption = "Doc.Baixa";
            this.colDoctoBaixa.FieldName = "DoctoBaixa";
            this.colDoctoBaixa.Name = "colDoctoBaixa";
            this.colDoctoBaixa.OptionsColumn.AllowFocus = false;
            // 
            // colNossaNFFor
            // 
            this.colNossaNFFor.Caption = "NF.Fornecedor";
            this.colNossaNFFor.FieldName = "NossaNFFor";
            this.colNossaNFFor.Name = "colNossaNFFor";
            this.colNossaNFFor.OptionsColumn.AllowFocus = false;
            // 
            // ricRequisicao
            // 
            this.ricRequisicao.ExpandCollapseItem.Id = 0;
            this.ricRequisicao.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ricRequisicao.ExpandCollapseItem,
            this.bbiIncluir,
            this.bbiExcluir,
            this.bbiAlterar,
            this.bbiExibirFiltro,
            this.bbiEliminarFiltro});
            this.ricRequisicao.Location = new System.Drawing.Point(0, 0);
            this.ricRequisicao.MaxItemId = 2;
            this.ricRequisicao.Name = "ricRequisicao";
            this.ricRequisicao.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpgRequisicao});
            this.ricRequisicao.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ricRequisicao.Size = new System.Drawing.Size(907, 146);
            // 
            // bbiIncluir
            // 
            this.bbiIncluir.Caption = "Nova";
            this.bbiIncluir.Id = 2;
            this.bbiIncluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiIncluir.ImageOptions.SvgImage")));
            this.bbiIncluir.LargeWidth = 48;
            this.bbiIncluir.Name = "bbiIncluir";
            this.bbiIncluir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipItem1.Text = "Nova requisição";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiIncluir.SuperTip = superToolTip1;
            this.bbiIncluir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiIncluir_ItemClick);
            // 
            // bbiExcluir
            // 
            this.bbiExcluir.Caption = "Excluir";
            this.bbiExcluir.Id = 3;
            this.bbiExcluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExcluir.ImageOptions.SvgImage")));
            this.bbiExcluir.LargeWidth = 48;
            this.bbiExcluir.Name = "bbiExcluir";
            this.bbiExcluir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bbiAlterar
            // 
            this.bbiAlterar.Caption = "Editar";
            this.bbiAlterar.Id = 4;
            this.bbiAlterar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiAlterar.ImageOptions.SvgImage")));
            this.bbiAlterar.LargeWidth = 48;
            this.bbiAlterar.Name = "bbiAlterar";
            this.bbiAlterar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiAlterar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAlterar_ItemClick);
            // 
            // bbiExibirFiltro
            // 
            this.bbiExibirFiltro.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiExibirFiltro.Caption = "Filtro";
            this.bbiExibirFiltro.Id = 5;
            this.bbiExibirFiltro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiExibirFiltro.ImageOptions.SvgImage")));
            this.bbiExibirFiltro.LargeWidth = 48;
            this.bbiExibirFiltro.Name = "bbiExibirFiltro";
            this.bbiExibirFiltro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExibirFiltro_ItemClick);
            // 
            // bbiEliminarFiltro
            // 
            this.bbiEliminarFiltro.Caption = "Anular";
            this.bbiEliminarFiltro.Id = 6;
            this.bbiEliminarFiltro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEliminarFiltro.ImageOptions.SvgImage")));
            this.bbiEliminarFiltro.LargeWidth = 48;
            this.bbiEliminarFiltro.Name = "bbiEliminarFiltro";
            this.bbiEliminarFiltro.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEliminarFiltro_ItemClick);
            // 
            // rpgRequisicao
            // 
            this.rpgRequisicao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgManutencao,
            this.rpgLocalizar});
            this.rpgRequisicao.Name = "rpgRequisicao";
            this.rpgRequisicao.Text = "Menu";
            // 
            // rbgManutencao
            // 
            this.rbgManutencao.ItemLinks.Add(this.bbiIncluir);
            this.rbgManutencao.ItemLinks.Add(this.bbiAlterar);
            this.rbgManutencao.ItemLinks.Add(this.bbiExcluir);
            this.rbgManutencao.Name = "rbgManutencao";
            this.rbgManutencao.ShowCaptionButton = false;
            this.rbgManutencao.Text = "Cadastro";
            // 
            // rpgLocalizar
            // 
            this.rpgLocalizar.ItemLinks.Add(this.bbiExibirFiltro);
            this.rpgLocalizar.ItemLinks.Add(this.bbiEliminarFiltro);
            this.rpgLocalizar.Name = "rpgLocalizar";
            this.rpgLocalizar.ShowCaptionButton = false;
            this.rpgLocalizar.Text = "Localização";
            // 
            // bdcMenuControler
            // 
            this.bdcMenuControler.Controller.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.bdcMenuControler.Controller.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bdcMenuControler.Controller.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.bdcMenuControler.Controller.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // frmRequisicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 545);
            this.Controls.Add(this.grcRequisicoes);
            this.Controls.Add(this.ricRequisicao);
            this.Name = "frmRequisicoes";
            this.Ribbon = this.ricRequisicao;
            this.Text = "Manutenção de Requisições de Produtos e Serviços";
            this.Activated += new System.EventHandler(this.frmRequisicoes_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grcRequisicoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRequisicoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Devart.Data.MySql.MySqlCommand mscInsert;
        private Devart.Data.MySql.MySqlCommand mscUpdate;
        private Devart.Data.MySql.MySqlCommand mscDelete;
        private DevExpress.XtraGrid.GridControl grcRequisicoes;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRequisicoes;
        private DevExpress.XtraGrid.Columns.GridColumn colNroProcesso;
        private DevExpress.XtraGrid.Columns.GridColumn colNomePosto;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNroRequis;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProduto;
        private DevExpress.XtraGrid.Columns.GridColumn colconsolidador;
        private DevExpress.XtraGrid.Columns.GridColumn colFornecedor;
        private DevExpress.XtraGrid.Columns.GridColumn colNroTkt;
        private DevExpress.XtraGrid.Columns.GridColumn colCentroCusto;
        private DevExpress.XtraGrid.Columns.GridColumn colPax;
        private DevExpress.XtraGrid.Columns.GridColumn colTrecho;
        private DevExpress.XtraGrid.Columns.GridColumn colEmissor;
        private DevExpress.XtraGrid.Columns.GridColumn colDescAgrup;
        private DevExpress.XtraGrid.Columns.GridColumn colDescEvento;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacoes;
        private DevExpress.XtraGrid.Columns.GridColumn colAbertura;
        private DevExpress.XtraGrid.Columns.GridColumn colEmissao;
        private DevExpress.XtraGrid.Columns.GridColumn colNumVoucher;
        private DevExpress.XtraGrid.Columns.GridColumn colSaida;
        private DevExpress.XtraGrid.Columns.GridColumn colRetorno;
        private DevExpress.XtraGrid.Columns.GridColumn colNroFatura;
        private DevExpress.XtraGrid.Columns.GridColumn colVencimento;
        private DevExpress.XtraGrid.Columns.GridColumn colNossaNFCli;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctoBaixa;
        private DevExpress.XtraGrid.Columns.GridColumn colNossaNFFor;
        private DevExpress.XtraBars.Ribbon.RibbonControl ricRequisicao;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpgRequisicao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgManutencao;
        private DevExpress.XtraBars.BarButtonItem bbiIncluir;
        private DevExpress.XtraBars.BarButtonItem bbiExcluir;
        private DevExpress.XtraBars.BarButtonItem bbiAlterar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgLocalizar;
        private DevExpress.XtraBars.BarButtonItem bbiExibirFiltro;
        private DevExpress.XtraBars.BarButtonItem bbiEliminarFiltro;
        private DevExpress.XtraBars.DefaultBarAndDockingController bdcMenuControler;
    }
}