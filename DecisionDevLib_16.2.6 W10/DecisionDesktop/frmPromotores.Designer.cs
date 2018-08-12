namespace DecisionDesktop
{
    partial class frmPromotores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPromotores));
            this.mySqlDataAdapter1 = new Devart.Data.MySql.MySqlDataAdapter();
            this.mySqlDeleteCommand1 = new Devart.Data.MySql.MySqlCommand();
            this.Devart__DecisionWeb_ = new Devart.Data.MySql.MySqlConnection();
            this.mySqlInsertCommand1 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlSelectCommand1 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlUpdateCommand1 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlCommand1 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlCommand2 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlCommand3 = new Devart.Data.MySql.MySqlCommand();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.mySqlDataTable1 = new Devart.Data.MySql.MySqlDataTable();
            this.mySqlDataTable1_CodPromotor = new System.Data.DataColumn();
            this.mySqlDataTable1_NomePromotor = new System.Data.DataColumn();
            this.mySqlDataTable1_End = new System.Data.DataColumn();
            this.mySqlDataTable1_Fone1 = new System.Data.DataColumn();
            this.mySqlDataTable1_RamalFone1 = new System.Data.DataColumn();
            this.mySqlDataTable1_Fone2 = new System.Data.DataColumn();
            this.mySqlDataTable1_RamalFone2 = new System.Data.DataColumn();
            this.mySqlDataTable1_Fax = new System.Data.DataColumn();
            this.mySqlDataTable1_RamalFax = new System.Data.DataColumn();
            this.mySqlDataTable1_CEP = new System.Data.DataColumn();
            this.mySqlDataTable1_CodCidade = new System.Data.DataColumn();
            this.mySqlDataTable1_Tipo = new System.Data.DataColumn();
            this.mySqlDataTable1_EMail = new System.Data.DataColumn();
            this.mySqlDataTable1_HTTP = new System.Data.DataColumn();
            this.mySqlDataTable1_Obs = new System.Data.DataColumn();
            this.mySqlDataTable1_Status = new System.Data.DataColumn();
            this.mySqlDataTable1_CodRestrito = new System.Data.DataColumn();
            this.mySqlDeleteCommand2 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlInsertCommand2 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlSelectCommand2 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlUpdateCommand2 = new Devart.Data.MySql.MySqlCommand();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodPromotor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomePromotor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRamalFone1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRamalFone2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRamalFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCEP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodCidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHTTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCodRestrito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mySqlCommand4 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlCommand5 = new Devart.Data.MySql.MySqlCommand();
            this.mySqlCommand6 = new Devart.Data.MySql.MySqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySqlDataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = this.mySqlDeleteCommand1;
            this.mySqlDataAdapter1.InsertCommand = this.mySqlInsertCommand1;
            this.mySqlDataAdapter1.SelectCommand = this.mySqlSelectCommand1;
            this.mySqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "promotor", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CodPromotor", "CodPromotor"),
                        new System.Data.Common.DataColumnMapping("NomePromotor", "NomePromotor"),
                        new System.Data.Common.DataColumnMapping("End", "End"),
                        new System.Data.Common.DataColumnMapping("Fone1", "Fone1"),
                        new System.Data.Common.DataColumnMapping("RamalFone1", "RamalFone1"),
                        new System.Data.Common.DataColumnMapping("Fone2", "Fone2"),
                        new System.Data.Common.DataColumnMapping("RamalFone2", "RamalFone2"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("RamalFax", "RamalFax"),
                        new System.Data.Common.DataColumnMapping("CEP", "CEP"),
                        new System.Data.Common.DataColumnMapping("CodCidade", "CodCidade"),
                        new System.Data.Common.DataColumnMapping("Tipo", "Tipo"),
                        new System.Data.Common.DataColumnMapping("EMail", "EMail"),
                        new System.Data.Common.DataColumnMapping("HTTP", "HTTP"),
                        new System.Data.Common.DataColumnMapping("Obs", "Obs"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("CodRestrito", "CodRestrito")})});
            this.mySqlDataAdapter1.UpdateCommand = this.mySqlUpdateCommand1;
            // 
            // mySqlDeleteCommand1
            // 
            this.mySqlDeleteCommand1.CommandText = "DELETE FROM dbturis_desktop.promotor WHERE ((CodPromotor = :Original_CodPromotor)" +
    ")";
            this.mySqlDeleteCommand1.Connection = this.Devart__DecisionWeb_;
            this.mySqlDeleteCommand1.Name = "mySqlDeleteCommand1";
            this.mySqlDeleteCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlDeleteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlDeleteCommand1.Owner = this;
            // 
            // Devart__DecisionWeb_
            // 
            this.Devart__DecisionWeb_.ConnectionString = "User Id=masterroot;Password=jfhmaster1@3;Host=127.0.0.1;Database=dbturis_desktop;" +
    "Unicode=True;Persist Security Info=True;";
            this.Devart__DecisionWeb_.Name = "Devart__DecisionWeb_";
            this.Devart__DecisionWeb_.Unicode = true;
            this.Devart__DecisionWeb_.Owner = this;
            // 
            // mySqlInsertCommand1
            // 
            this.mySqlInsertCommand1.CommandText = resources.GetString("mySqlInsertCommand1.CommandText");
            this.mySqlInsertCommand1.Connection = this.Devart__DecisionWeb_;
            this.mySqlInsertCommand1.Name = "mySqlInsertCommand1";
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlInsertCommand1.Owner = this;
            // 
            // mySqlSelectCommand1
            // 
            this.mySqlSelectCommand1.CommandText = "SELECT * FROM promotor WHERE promotor.codpromotor <> 0";
            this.mySqlSelectCommand1.Connection = this.Devart__DecisionWeb_;
            this.mySqlSelectCommand1.Name = "mySqlSelectCommand1";
            this.mySqlSelectCommand1.Owner = this;
            // 
            // mySqlUpdateCommand1
            // 
            this.mySqlUpdateCommand1.CommandText = resources.GetString("mySqlUpdateCommand1.CommandText");
            this.mySqlUpdateCommand1.Connection = this.Devart__DecisionWeb_;
            this.mySqlUpdateCommand1.Name = "mySqlUpdateCommand1";
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlUpdateCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlUpdateCommand1.Owner = this;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CommandText = resources.GetString("mySqlCommand1.CommandText");
            this.mySqlCommand1.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand1.Name = "mySqlCommand1";
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand1.Owner = this;
            // 
            // mySqlCommand2
            // 
            this.mySqlCommand2.CommandText = resources.GetString("mySqlCommand2.CommandText");
            this.mySqlCommand2.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand2.Name = "mySqlCommand2";
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlCommand2.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand2.Owner = this;
            // 
            // mySqlCommand3
            // 
            this.mySqlCommand3.CommandText = "DELETE FROM dbturis_desktop.promotor WHERE ((CodPromotor = :Original_CodPromotor)" +
    ")";
            this.mySqlCommand3.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand3.Name = "mySqlCommand3";
            this.mySqlCommand3.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlCommand3.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand3.Owner = this;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.mySqlDataTable1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 178);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.gridControl1.Size = new System.Drawing.Size(885, 351);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // mySqlDataTable1
            // 
            this.mySqlDataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.mySqlDataTable1_CodPromotor,
            this.mySqlDataTable1_NomePromotor,
            this.mySqlDataTable1_End,
            this.mySqlDataTable1_Fone1,
            this.mySqlDataTable1_RamalFone1,
            this.mySqlDataTable1_Fone2,
            this.mySqlDataTable1_RamalFone2,
            this.mySqlDataTable1_Fax,
            this.mySqlDataTable1_RamalFax,
            this.mySqlDataTable1_CEP,
            this.mySqlDataTable1_CodCidade,
            this.mySqlDataTable1_Tipo,
            this.mySqlDataTable1_EMail,
            this.mySqlDataTable1_HTTP,
            this.mySqlDataTable1_Obs,
            this.mySqlDataTable1_Status,
            this.mySqlDataTable1_CodRestrito});
            this.mySqlDataTable1.Connection = this.Devart__DecisionWeb_;
            this.mySqlDataTable1.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "CodPromotor"}, true)});
            this.mySqlDataTable1.DeleteCommand = this.mySqlDeleteCommand2;
            this.mySqlDataTable1.InsertCommand = this.mySqlInsertCommand2;
            this.mySqlDataTable1.Name = "mySqlDataTable1";
            this.mySqlDataTable1.PrimaryKey = new System.Data.DataColumn[] {
        this.mySqlDataTable1_CodPromotor};
            this.mySqlDataTable1.SelectCommand = this.mySqlSelectCommand2;
            this.mySqlDataTable1.TableName = "mySqlDataTable1";
            this.mySqlDataTable1.UpdateCommand = this.mySqlUpdateCommand2;
            this.mySqlDataTable1.Owner = this;
            this.mySqlDataTable1.TableMapping.DataSetTable = "mySqlDataTable1";
            this.mySqlDataTable1.TableMapping.SourceTable = "mySqlDataTable1";
            // 
            // mySqlDataTable1_CodPromotor
            // 
            this.mySqlDataTable1_CodPromotor.AllowDBNull = false;
            this.mySqlDataTable1_CodPromotor.AutoIncrement = true;
            this.mySqlDataTable1_CodPromotor.ColumnName = "CodPromotor";
            this.mySqlDataTable1_CodPromotor.DataType = typeof(int);
            // 
            // mySqlDataTable1_NomePromotor
            // 
            this.mySqlDataTable1_NomePromotor.ColumnName = "NomePromotor";
            // 
            // mySqlDataTable1_End
            // 
            this.mySqlDataTable1_End.ColumnName = "End";
            // 
            // mySqlDataTable1_Fone1
            // 
            this.mySqlDataTable1_Fone1.ColumnName = "Fone1";
            // 
            // mySqlDataTable1_RamalFone1
            // 
            this.mySqlDataTable1_RamalFone1.ColumnName = "RamalFone1";
            // 
            // mySqlDataTable1_Fone2
            // 
            this.mySqlDataTable1_Fone2.ColumnName = "Fone2";
            // 
            // mySqlDataTable1_RamalFone2
            // 
            this.mySqlDataTable1_RamalFone2.ColumnName = "RamalFone2";
            // 
            // mySqlDataTable1_Fax
            // 
            this.mySqlDataTable1_Fax.ColumnName = "Fax";
            // 
            // mySqlDataTable1_RamalFax
            // 
            this.mySqlDataTable1_RamalFax.ColumnName = "RamalFax";
            // 
            // mySqlDataTable1_CEP
            // 
            this.mySqlDataTable1_CEP.ColumnName = "CEP";
            // 
            // mySqlDataTable1_CodCidade
            // 
            this.mySqlDataTable1_CodCidade.ColumnName = "CodCidade";
            this.mySqlDataTable1_CodCidade.DataType = typeof(int);
            // 
            // mySqlDataTable1_Tipo
            // 
            this.mySqlDataTable1_Tipo.ColumnName = "Tipo";
            // 
            // mySqlDataTable1_EMail
            // 
            this.mySqlDataTable1_EMail.ColumnName = "EMail";
            // 
            // mySqlDataTable1_HTTP
            // 
            this.mySqlDataTable1_HTTP.ColumnName = "HTTP";
            // 
            // mySqlDataTable1_Obs
            // 
            this.mySqlDataTable1_Obs.ColumnName = "Obs";
            // 
            // mySqlDataTable1_Status
            // 
            this.mySqlDataTable1_Status.ColumnName = "Status";
            // 
            // mySqlDataTable1_CodRestrito
            // 
            this.mySqlDataTable1_CodRestrito.ColumnName = "CodRestrito";
            this.mySqlDataTable1_CodRestrito.DataType = typeof(int);
            // 
            // mySqlDeleteCommand2
            // 
            this.mySqlDeleteCommand2.CommandText = "DELETE FROM dbturis_desktop.promotor WHERE ((CodPromotor = :Original_CodPromotor)" +
    ")";
            this.mySqlDeleteCommand2.Connection = this.Devart__DecisionWeb_;
            this.mySqlDeleteCommand2.Name = "mySqlDeleteCommand2";
            this.mySqlDeleteCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlDeleteCommand2.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlDeleteCommand2.Owner = this;
            // 
            // mySqlInsertCommand2
            // 
            this.mySqlInsertCommand2.CommandText = resources.GetString("mySqlInsertCommand2.CommandText");
            this.mySqlInsertCommand2.Connection = this.Devart__DecisionWeb_;
            this.mySqlInsertCommand2.Name = "mySqlInsertCommand2";
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlInsertCommand2.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlInsertCommand2.Owner = this;
            // 
            // mySqlSelectCommand2
            // 
            this.mySqlSelectCommand2.CommandText = "select * from promotor where codpromotor <> 0";
            this.mySqlSelectCommand2.Connection = this.Devart__DecisionWeb_;
            this.mySqlSelectCommand2.Name = "mySqlSelectCommand2";
            this.mySqlSelectCommand2.Owner = this;
            // 
            // mySqlUpdateCommand2
            // 
            this.mySqlUpdateCommand2.CommandText = resources.GetString("mySqlUpdateCommand2.CommandText");
            this.mySqlUpdateCommand2.Connection = this.Devart__DecisionWeb_;
            this.mySqlUpdateCommand2.Name = "mySqlUpdateCommand2";
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlUpdateCommand2.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlUpdateCommand2.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlUpdateCommand2.Owner = this;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodPromotor,
            this.colNomePromotor,
            this.colEnd,
            this.colFone1,
            this.colRamalFone1,
            this.colFone2,
            this.colRamalFone2,
            this.colFax,
            this.colRamalFax,
            this.colCEP,
            this.colCodCidade,
            this.colTipo,
            this.colEMail,
            this.colHTTP,
            this.colObs,
            this.colStatus,
            this.colCodRestrito});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 640;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colCodPromotor
            // 
            this.colCodPromotor.FieldName = "CodPromotor";
            this.colCodPromotor.Name = "colCodPromotor";
            // 
            // colNomePromotor
            // 
            this.colNomePromotor.FieldName = "NomePromotor";
            this.colNomePromotor.Name = "colNomePromotor";
            this.colNomePromotor.OptionsEditForm.ColumnSpan = 3;
            this.colNomePromotor.Visible = true;
            this.colNomePromotor.VisibleIndex = 0;
            // 
            // colEnd
            // 
            this.colEnd.FieldName = "End";
            this.colEnd.Name = "colEnd";
            this.colEnd.Visible = true;
            this.colEnd.VisibleIndex = 1;
            // 
            // colFone1
            // 
            this.colFone1.FieldName = "Fone1";
            this.colFone1.Name = "colFone1";
            this.colFone1.Visible = true;
            this.colFone1.VisibleIndex = 2;
            // 
            // colRamalFone1
            // 
            this.colRamalFone1.FieldName = "RamalFone1";
            this.colRamalFone1.Name = "colRamalFone1";
            this.colRamalFone1.Visible = true;
            this.colRamalFone1.VisibleIndex = 3;
            // 
            // colFone2
            // 
            this.colFone2.FieldName = "Fone2";
            this.colFone2.Name = "colFone2";
            this.colFone2.Visible = true;
            this.colFone2.VisibleIndex = 4;
            // 
            // colRamalFone2
            // 
            this.colRamalFone2.FieldName = "RamalFone2";
            this.colRamalFone2.Name = "colRamalFone2";
            this.colRamalFone2.Visible = true;
            this.colRamalFone2.VisibleIndex = 5;
            // 
            // colFax
            // 
            this.colFax.FieldName = "Fax";
            this.colFax.Name = "colFax";
            this.colFax.Visible = true;
            this.colFax.VisibleIndex = 6;
            // 
            // colRamalFax
            // 
            this.colRamalFax.FieldName = "RamalFax";
            this.colRamalFax.Name = "colRamalFax";
            this.colRamalFax.Visible = true;
            this.colRamalFax.VisibleIndex = 7;
            // 
            // colCEP
            // 
            this.colCEP.FieldName = "CEP";
            this.colCEP.Name = "colCEP";
            this.colCEP.Visible = true;
            this.colCEP.VisibleIndex = 8;
            // 
            // colCodCidade
            // 
            this.colCodCidade.ColumnEdit = this.repositoryItemComboBox2;
            this.colCodCidade.FieldName = "CodCidade";
            this.colCodCidade.Name = "colCodCidade";
            this.colCodCidade.Visible = true;
            this.colCodCidade.VisibleIndex = 9;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            this.colTipo.Visible = true;
            this.colTipo.VisibleIndex = 10;
            // 
            // colEMail
            // 
            this.colEMail.FieldName = "EMail";
            this.colEMail.Name = "colEMail";
            this.colEMail.Visible = true;
            this.colEMail.VisibleIndex = 11;
            // 
            // colHTTP
            // 
            this.colHTTP.FieldName = "HTTP";
            this.colHTTP.Name = "colHTTP";
            this.colHTTP.Visible = true;
            this.colHTTP.VisibleIndex = 12;
            // 
            // colObs
            // 
            this.colObs.FieldName = "Obs";
            this.colObs.Name = "colObs";
            this.colObs.Visible = true;
            this.colObs.VisibleIndex = 13;
            // 
            // colStatus
            // 
            this.colStatus.ColumnEdit = this.repositoryItemComboBox1;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 14;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colCodRestrito
            // 
            this.colCodRestrito.FieldName = "CodRestrito";
            this.colCodRestrito.Name = "colCodRestrito";
            this.colCodRestrito.Visible = true;
            this.colCodRestrito.VisibleIndex = 15;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // mySqlCommand4
            // 
            this.mySqlCommand4.CommandText = resources.GetString("mySqlCommand4.CommandText");
            this.mySqlCommand4.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand4.Name = "mySqlCommand4";
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand4.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand4.Owner = this;
            // 
            // mySqlCommand5
            // 
            this.mySqlCommand5.CommandText = resources.GetString("mySqlCommand5.CommandText");
            this.mySqlCommand5.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand5.Name = "mySqlCommand5";
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("NomePromotor", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "NomePromotor", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("End", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "End", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone1", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone1", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFone2", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFone2", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Fax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("RamalFax", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "RamalFax", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CEP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CEP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodCidade", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodCidade", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Tipo", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Tipo", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("EMail", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("HTTP", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "HTTP", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Obs", Devart.Data.MySql.MySqlType.Text, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Obs", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Status", Devart.Data.MySql.MySqlType.Char, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("CodRestrito", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodRestrito", System.Data.DataRowVersion.Current, null));
            this.mySqlCommand5.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlCommand5.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand5.Owner = this;
            // 
            // mySqlCommand6
            // 
            this.mySqlCommand6.CommandText = "DELETE FROM dbturis_desktop.promotor WHERE ((CodPromotor = :Original_CodPromotor)" +
    ")";
            this.mySqlCommand6.Connection = this.Devart__DecisionWeb_;
            this.mySqlCommand6.Name = "mySqlCommand6";
            this.mySqlCommand6.Parameters.Add(new Devart.Data.MySql.MySqlParameter("Original_CodPromotor", Devart.Data.MySql.MySqlType.Int, 0, System.Data.ParameterDirection.Input, false, false, ((byte)(0)), ((byte)(0)), "CodPromotor", System.Data.DataRowVersion.Original, null));
            this.mySqlCommand6.UpdatedRowSource = System.Data.UpdateRowSource.None;
            this.mySqlCommand6.Owner = this;
            // 
            // frmPromotores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 529);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmPromotores";
            this.Text = "frmPromotores";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySqlDataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Devart.Data.MySql.MySqlDataAdapter mySqlDataAdapter1;
        private Devart.Data.MySql.MySqlCommand mySqlCommand1;
        private Devart.Data.MySql.MySqlConnection Devart__DecisionWeb_;
        private Devart.Data.MySql.MySqlCommand mySqlCommand2;
        private Devart.Data.MySql.MySqlCommand mySqlCommand3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCodPromotor;
        private DevExpress.XtraGrid.Columns.GridColumn colNomePromotor;
        private DevExpress.XtraGrid.Columns.GridColumn colEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colFone1;
        private DevExpress.XtraGrid.Columns.GridColumn colRamalFone1;
        private DevExpress.XtraGrid.Columns.GridColumn colFone2;
        private DevExpress.XtraGrid.Columns.GridColumn colRamalFone2;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colRamalFax;
        private DevExpress.XtraGrid.Columns.GridColumn colCEP;
        private DevExpress.XtraGrid.Columns.GridColumn colCodCidade;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colHTTP;
        private DevExpress.XtraGrid.Columns.GridColumn colObs;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCodRestrito;
        private Devart.Data.MySql.MySqlCommand mySqlDeleteCommand1;
        private Devart.Data.MySql.MySqlCommand mySqlInsertCommand1;
        private Devart.Data.MySql.MySqlCommand mySqlSelectCommand1;
        private Devart.Data.MySql.MySqlCommand mySqlUpdateCommand1;
        private Devart.Data.MySql.MySqlCommand mySqlCommand4;
        private Devart.Data.MySql.MySqlCommand mySqlCommand5;
        private Devart.Data.MySql.MySqlCommand mySqlCommand6;
        private Devart.Data.MySql.MySqlDataTable mySqlDataTable1;
        private System.Data.DataColumn mySqlDataTable1_CodPromotor;
        private System.Data.DataColumn mySqlDataTable1_NomePromotor;
        private System.Data.DataColumn mySqlDataTable1_End;
        private System.Data.DataColumn mySqlDataTable1_Fone1;
        private System.Data.DataColumn mySqlDataTable1_RamalFone1;
        private System.Data.DataColumn mySqlDataTable1_Fone2;
        private System.Data.DataColumn mySqlDataTable1_RamalFone2;
        private System.Data.DataColumn mySqlDataTable1_Fax;
        private System.Data.DataColumn mySqlDataTable1_RamalFax;
        private System.Data.DataColumn mySqlDataTable1_CEP;
        private System.Data.DataColumn mySqlDataTable1_CodCidade;
        private System.Data.DataColumn mySqlDataTable1_Tipo;
        private System.Data.DataColumn mySqlDataTable1_EMail;
        private System.Data.DataColumn mySqlDataTable1_HTTP;
        private System.Data.DataColumn mySqlDataTable1_Obs;
        private System.Data.DataColumn mySqlDataTable1_Status;
        private System.Data.DataColumn mySqlDataTable1_CodRestrito;
        private Devart.Data.MySql.MySqlCommand mySqlDeleteCommand2;
        private Devart.Data.MySql.MySqlCommand mySqlInsertCommand2;
        private Devart.Data.MySql.MySqlCommand mySqlSelectCommand2;
        private Devart.Data.MySql.MySqlCommand mySqlUpdateCommand2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;

    }
}