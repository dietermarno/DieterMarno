namespace Decision_DBClassesGen
{
    partial class frmDBClassGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBClassGenerator));
            this.trvFields = new DevExpress.XtraTreeList.TreeList();
            this.trcNome = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcTipo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcTamanho = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcAnulavel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcAutonumerado = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trcObrigatorio = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rpiCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.trcChaveUnica = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cboDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboTables = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.lblTable = new DevExpress.XtraEditors.LabelControl();
            this.txtNameSpace = new DevExpress.XtraEditors.TextEdit();
            this.lblNameSpace = new DevExpress.XtraEditors.LabelControl();
            this.lblNomeClasseDados = new DevExpress.XtraEditors.LabelControl();
            this.txtNomeClasseDados = new DevExpress.XtraEditors.TextEdit();
            this.lblNomeClasseGerenciamento = new DevExpress.XtraEditors.LabelControl();
            this.txtNomeClasseGerenciamento = new DevExpress.XtraEditors.TextEdit();
            this.cmdAnalisar = new DevExpress.XtraEditors.SimpleButton();
            this.lstIncludes = new DevExpress.XtraEditors.ListBoxControl();
            this.lblIncludes = new DevExpress.XtraEditors.LabelControl();
            this.cmdAdicionaInclude = new DevExpress.XtraEditors.SimpleButton();
            this.cmdDeleteInclude = new DevExpress.XtraEditors.SimpleButton();
            this.cmdExibir = new DevExpress.XtraEditors.SimpleButton();
            this.lblFields = new DevExpress.XtraEditors.LabelControl();
            this.cmdCopiar = new DevExpress.XtraEditors.SimpleButton();
            this.lblIDNameSpace = new DevExpress.XtraEditors.LabelControl();
            this.txtIDNameSpace = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblSubtitulo = new DevExpress.XtraEditors.LabelControl();
            this.grcVisualizacao = new DevExpress.XtraEditors.GroupControl();
            this.memVisualizacao = new DevExpress.XtraEditors.MemoEdit();
            this.cmdFecharVisualizador = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.trvFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTables.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeClasseDados.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeClasseGerenciamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIncludes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNameSpace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcVisualizacao)).BeginInit();
            this.grcVisualizacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memVisualizacao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // trvFields
            // 
            this.trvFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvFields.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trcNome,
            this.trcTipo,
            this.trcTamanho,
            this.trcAnulavel,
            this.trcAutonumerado,
            this.trcObrigatorio,
            this.trcChaveUnica});
            this.trvFields.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.trvFields.Location = new System.Drawing.Point(288, 76);
            this.trvFields.Name = "trvFields";
            this.trvFields.OptionsView.ShowIndicator = false;
            this.trvFields.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpiCheckBox});
            this.trvFields.Size = new System.Drawing.Size(599, 409);
            this.trvFields.TabIndex = 0;
            // 
            // trcNome
            // 
            this.trcNome.Caption = "Nome";
            this.trcNome.FieldName = "Nome";
            this.trcNome.Name = "trcNome";
            this.trcNome.OptionsColumn.AllowEdit = false;
            this.trcNome.OptionsColumn.AllowFocus = false;
            this.trcNome.OptionsColumn.FixedWidth = true;
            this.trcNome.OptionsColumn.ShowInCustomizationForm = false;
            this.trcNome.OptionsColumn.ShowInExpressionEditor = false;
            this.trcNome.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.trcNome.Visible = true;
            this.trcNome.VisibleIndex = 0;
            this.trcNome.Width = 133;
            // 
            // trcTipo
            // 
            this.trcTipo.Caption = "Tipo";
            this.trcTipo.FieldName = "Tipo";
            this.trcTipo.Name = "trcTipo";
            this.trcTipo.OptionsColumn.AllowEdit = false;
            this.trcTipo.OptionsColumn.FixedWidth = true;
            this.trcTipo.OptionsColumn.ShowInCustomizationForm = false;
            this.trcTipo.OptionsColumn.ShowInExpressionEditor = false;
            this.trcTipo.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.trcTipo.Visible = true;
            this.trcTipo.VisibleIndex = 1;
            this.trcTipo.Width = 100;
            // 
            // trcTamanho
            // 
            this.trcTamanho.Caption = "Tamanho";
            this.trcTamanho.FieldName = "Tamanho";
            this.trcTamanho.Name = "trcTamanho";
            this.trcTamanho.OptionsColumn.AllowEdit = false;
            this.trcTamanho.OptionsColumn.AllowFocus = false;
            this.trcTamanho.OptionsColumn.FixedWidth = true;
            this.trcTamanho.OptionsColumn.ShowInCustomizationForm = false;
            this.trcTamanho.OptionsColumn.ShowInExpressionEditor = false;
            this.trcTamanho.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.trcTamanho.Visible = true;
            this.trcTamanho.VisibleIndex = 2;
            this.trcTamanho.Width = 50;
            // 
            // trcAnulavel
            // 
            this.trcAnulavel.Caption = "Anulável";
            this.trcAnulavel.FieldName = "Anulável";
            this.trcAnulavel.Name = "trcAnulavel";
            this.trcAnulavel.OptionsColumn.AllowEdit = false;
            this.trcAnulavel.OptionsColumn.AllowFocus = false;
            this.trcAnulavel.OptionsColumn.FixedWidth = true;
            this.trcAnulavel.OptionsColumn.ShowInCustomizationForm = false;
            this.trcAnulavel.OptionsColumn.ShowInExpressionEditor = false;
            this.trcAnulavel.Visible = true;
            this.trcAnulavel.VisibleIndex = 3;
            this.trcAnulavel.Width = 50;
            // 
            // trcAutonumerado
            // 
            this.trcAutonumerado.Caption = "Autonumerado";
            this.trcAutonumerado.FieldName = "Autonumerado";
            this.trcAutonumerado.Name = "trcAutonumerado";
            this.trcAutonumerado.OptionsColumn.AllowEdit = false;
            this.trcAutonumerado.OptionsColumn.AllowFocus = false;
            this.trcAutonumerado.OptionsColumn.FixedWidth = true;
            this.trcAutonumerado.OptionsColumn.ShowInCustomizationForm = false;
            this.trcAutonumerado.OptionsColumn.ShowInExpressionEditor = false;
            this.trcAutonumerado.Visible = true;
            this.trcAutonumerado.VisibleIndex = 4;
            this.trcAutonumerado.Width = 80;
            // 
            // trcObrigatorio
            // 
            this.trcObrigatorio.Caption = "Obrigatório";
            this.trcObrigatorio.ColumnEdit = this.rpiCheckBox;
            this.trcObrigatorio.FieldName = "Obrigatório";
            this.trcObrigatorio.Name = "trcObrigatorio";
            this.trcObrigatorio.OptionsColumn.FixedWidth = true;
            this.trcObrigatorio.OptionsColumn.ShowInCustomizationForm = false;
            this.trcObrigatorio.OptionsColumn.ShowInExpressionEditor = false;
            this.trcObrigatorio.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            this.trcObrigatorio.Visible = true;
            this.trcObrigatorio.VisibleIndex = 5;
            this.trcObrigatorio.Width = 65;
            // 
            // rpiCheckBox
            // 
            this.rpiCheckBox.AutoHeight = false;
            this.rpiCheckBox.Name = "rpiCheckBox";
            // 
            // trcChaveUnica
            // 
            this.trcChaveUnica.Caption = "Chave Única";
            this.trcChaveUnica.ColumnEdit = this.rpiCheckBox;
            this.trcChaveUnica.FieldName = "Chave Única";
            this.trcChaveUnica.Name = "trcChaveUnica";
            this.trcChaveUnica.OptionsColumn.FixedWidth = true;
            this.trcChaveUnica.OptionsColumn.ShowInCustomizationForm = false;
            this.trcChaveUnica.OptionsColumn.ShowInExpressionEditor = false;
            this.trcChaveUnica.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean;
            this.trcChaveUnica.Visible = true;
            this.trcChaveUnica.VisibleIndex = 6;
            this.trcChaveUnica.Width = 72;
            // 
            // cboDatabase
            // 
            this.cboDatabase.EditValue = "";
            this.cboDatabase.Location = new System.Drawing.Point(12, 123);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDatabase.Size = new System.Drawing.Size(235, 20);
            this.cboDatabase.TabIndex = 1;
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            // 
            // cboTables
            // 
            this.cboTables.Location = new System.Drawing.Point(13, 170);
            this.cboTables.Name = "cboTables";
            this.cboTables.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTables.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTables.Size = new System.Drawing.Size(235, 20);
            this.cboTables.TabIndex = 2;
            this.cboTables.SelectedIndexChanged += new System.EventHandler(this.cboTables_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(13, 108);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(76, 13);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "Banco de dados";
            // 
            // lblTable
            // 
            this.lblTable.Location = new System.Drawing.Point(13, 155);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(32, 13);
            this.lblTable.TabIndex = 4;
            this.lblTable.Text = "Tabela";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.EditValue = "";
            this.txtNameSpace.Location = new System.Drawing.Point(13, 76);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(234, 20);
            this.txtNameSpace.TabIndex = 5;
            this.txtNameSpace.Leave += new System.EventHandler(this.txtNameSpace_Leave);
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.Location = new System.Drawing.Point(13, 61);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(59, 13);
            this.lblNameSpace.TabIndex = 6;
            this.lblNameSpace.Text = "Name Space";
            // 
            // lblNomeClasseDados
            // 
            this.lblNomeClasseDados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNomeClasseDados.Location = new System.Drawing.Point(13, 403);
            this.lblNomeClasseDados.Name = "lblNomeClasseDados";
            this.lblNomeClasseDados.Size = new System.Drawing.Size(121, 13);
            this.lblNomeClasseDados.TabIndex = 8;
            this.lblNomeClasseDados.Text = "Nome da classe de dados";
            // 
            // txtNomeClasseDados
            // 
            this.txtNomeClasseDados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNomeClasseDados.Location = new System.Drawing.Point(13, 418);
            this.txtNomeClasseDados.Name = "txtNomeClasseDados";
            this.txtNomeClasseDados.Size = new System.Drawing.Size(234, 20);
            this.txtNomeClasseDados.TabIndex = 7;
            // 
            // lblNomeClasseGerenciamento
            // 
            this.lblNomeClasseGerenciamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNomeClasseGerenciamento.Location = new System.Drawing.Point(13, 450);
            this.lblNomeClasseGerenciamento.Name = "lblNomeClasseGerenciamento";
            this.lblNomeClasseGerenciamento.Size = new System.Drawing.Size(163, 13);
            this.lblNomeClasseGerenciamento.TabIndex = 10;
            this.lblNomeClasseGerenciamento.Text = "Nome da classe de gerenciamento";
            // 
            // txtNomeClasseGerenciamento
            // 
            this.txtNomeClasseGerenciamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNomeClasseGerenciamento.Location = new System.Drawing.Point(13, 465);
            this.txtNomeClasseGerenciamento.Name = "txtNomeClasseGerenciamento";
            this.txtNomeClasseGerenciamento.Size = new System.Drawing.Size(234, 20);
            this.txtNomeClasseGerenciamento.TabIndex = 9;
            // 
            // cmdAnalisar
            // 
            this.cmdAnalisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdAnalisar.Location = new System.Drawing.Point(166, 501);
            this.cmdAnalisar.Name = "cmdAnalisar";
            this.cmdAnalisar.Size = new System.Drawing.Size(81, 28);
            this.cmdAnalisar.TabIndex = 11;
            this.cmdAnalisar.Text = "&Analisar >>";
            this.cmdAnalisar.Click += new System.EventHandler(this.cmdAnalisar_Click);
            // 
            // lstIncludes
            // 
            this.lstIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstIncludes.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstIncludes.Location = new System.Drawing.Point(14, 264);
            this.lstIncludes.Name = "lstIncludes";
            this.lstIncludes.Size = new System.Drawing.Size(233, 127);
            this.lstIncludes.TabIndex = 12;
            // 
            // lblIncludes
            // 
            this.lblIncludes.Location = new System.Drawing.Point(14, 249);
            this.lblIncludes.Name = "lblIncludes";
            this.lblIncludes.Size = new System.Drawing.Size(153, 13);
            this.lblIncludes.TabIndex = 13;
            this.lblIncludes.Text = "Classes e name spaces incluídos";
            // 
            // cmdAdicionaInclude
            // 
            this.cmdAdicionaInclude.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdAdicionaInclude.Image = ((System.Drawing.Image)(resources.GetObject("cmdAdicionaInclude.Image")));
            this.cmdAdicionaInclude.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdAdicionaInclude.Location = new System.Drawing.Point(253, 214);
            this.cmdAdicionaInclude.Name = "cmdAdicionaInclude";
            this.cmdAdicionaInclude.Size = new System.Drawing.Size(24, 24);
            this.cmdAdicionaInclude.TabIndex = 14;
            this.cmdAdicionaInclude.Click += new System.EventHandler(this.cmdAdicionaInclude_Click);
            // 
            // cmdDeleteInclude
            // 
            this.cmdDeleteInclude.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.cmdDeleteInclude.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteInclude.Image")));
            this.cmdDeleteInclude.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.cmdDeleteInclude.Location = new System.Drawing.Point(253, 263);
            this.cmdDeleteInclude.Name = "cmdDeleteInclude";
            this.cmdDeleteInclude.Size = new System.Drawing.Size(24, 24);
            this.cmdDeleteInclude.TabIndex = 15;
            this.cmdDeleteInclude.Click += new System.EventHandler(this.cmdDeleteInclude_Click);
            // 
            // cmdExibir
            // 
            this.cmdExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExibir.Location = new System.Drawing.Point(812, 501);
            this.cmdExibir.Name = "cmdExibir";
            this.cmdExibir.Size = new System.Drawing.Size(75, 28);
            this.cmdExibir.TabIndex = 16;
            this.cmdExibir.Text = "&Exibir >>";
            this.cmdExibir.Click += new System.EventHandler(this.cmdExibir_Click);
            // 
            // lblFields
            // 
            this.lblFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFields.Location = new System.Drawing.Point(289, 61);
            this.lblFields.Name = "lblFields";
            this.lblFields.Size = new System.Drawing.Size(86, 13);
            this.lblFields.TabIndex = 17;
            this.lblFields.Text = "Campos da tabela";
            // 
            // cmdCopiar
            // 
            this.cmdCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCopiar.Location = new System.Drawing.Point(287, 501);
            this.cmdCopiar.Name = "cmdCopiar";
            this.cmdCopiar.Size = new System.Drawing.Size(75, 28);
            this.cmdCopiar.TabIndex = 18;
            this.cmdCopiar.Text = "&Copiar";
            this.cmdCopiar.Click += new System.EventHandler(this.cmdCopiar_Click);
            // 
            // lblIDNameSpace
            // 
            this.lblIDNameSpace.Location = new System.Drawing.Point(13, 202);
            this.lblIDNameSpace.Name = "lblIDNameSpace";
            this.lblIDNameSpace.Size = new System.Drawing.Size(178, 13);
            this.lblIDNameSpace.TabIndex = 20;
            this.lblIDNameSpace.Text = "Identificação do Name Space à incluir";
            // 
            // txtIDNameSpace
            // 
            this.txtIDNameSpace.EditValue = "";
            this.txtIDNameSpace.Location = new System.Drawing.Point(13, 217);
            this.txtIDNameSpace.Name = "txtIDNameSpace";
            this.txtIDNameSpace.Size = new System.Drawing.Size(234, 20);
            this.txtIDNameSpace.TabIndex = 19;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(451, 25);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Gerador de Classes de Gerenciamento de Dados";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSubtitulo.Appearance.Options.UseForeColor = true;
            this.lblSubtitulo.Location = new System.Drawing.Point(12, 32);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(398, 13);
            this.lblSubtitulo.TabIndex = 22;
            this.lblSubtitulo.Text = "Criação de classes para gerenciamento de pesquisa, inclusão, alteração e exclusão" +
    "";
            // 
            // grcVisualizacao
            // 
            this.grcVisualizacao.Controls.Add(this.cmdFecharVisualizador);
            this.grcVisualizacao.Controls.Add(this.memVisualizacao);
            this.grcVisualizacao.Location = new System.Drawing.Point(526, 173);
            this.grcVisualizacao.Name = "grcVisualizacao";
            this.grcVisualizacao.Size = new System.Drawing.Size(254, 218);
            this.grcVisualizacao.TabIndex = 23;
            this.grcVisualizacao.Text = "Visualização do código";
            this.grcVisualizacao.Visible = false;
            // 
            // memVisualizacao
            // 
            this.memVisualizacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memVisualizacao.Location = new System.Drawing.Point(1, 20);
            this.memVisualizacao.Name = "memVisualizacao";
            this.memVisualizacao.Properties.Appearance.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memVisualizacao.Properties.Appearance.Options.UseFont = true;
            this.memVisualizacao.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memVisualizacao.Size = new System.Drawing.Size(252, 197);
            this.memVisualizacao.TabIndex = 0;
            // 
            // cmdFecharVisualizador
            // 
            this.cmdFecharVisualizador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFecharVisualizador.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cmdFecharVisualizador.Image = ((System.Drawing.Image)(resources.GetObject("cmdFecharVisualizador.Image")));
            this.cmdFecharVisualizador.Location = new System.Drawing.Point(229, 1);
            this.cmdFecharVisualizador.Name = "cmdFecharVisualizador";
            this.cmdFecharVisualizador.Size = new System.Drawing.Size(25, 16);
            this.cmdFecharVisualizador.TabIndex = 1;
            this.cmdFecharVisualizador.Click += new System.EventHandler(this.cmdFecharVisualizador_Click);
            // 
            // frmDBClassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 544);
            this.Controls.Add(this.grcVisualizacao);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblIDNameSpace);
            this.Controls.Add(this.txtIDNameSpace);
            this.Controls.Add(this.cmdCopiar);
            this.Controls.Add(this.lblFields);
            this.Controls.Add(this.cmdExibir);
            this.Controls.Add(this.cmdDeleteInclude);
            this.Controls.Add(this.cmdAdicionaInclude);
            this.Controls.Add(this.lblIncludes);
            this.Controls.Add(this.lstIncludes);
            this.Controls.Add(this.cmdAnalisar);
            this.Controls.Add(this.lblNomeClasseGerenciamento);
            this.Controls.Add(this.txtNomeClasseGerenciamento);
            this.Controls.Add(this.lblNomeClasseDados);
            this.Controls.Add(this.txtNomeClasseDados);
            this.Controls.Add(this.lblNameSpace);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.cboTables);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.trvFields);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDBClassGenerator";
            this.Text = "Gerador de Classes de Tabela de Dados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDBClassGenerator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trvFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpiCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTables.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameSpace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeClasseDados.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeClasseGerenciamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstIncludes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNameSpace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcVisualizacao)).EndInit();
            this.grcVisualizacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memVisualizacao.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trvFields;
        private DevExpress.XtraEditors.ComboBoxEdit cboDatabase;
        private DevExpress.XtraEditors.ComboBoxEdit cboTables;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private DevExpress.XtraEditors.LabelControl lblTable;
        private DevExpress.XtraEditors.TextEdit txtNameSpace;
        private DevExpress.XtraEditors.LabelControl lblNameSpace;
        private DevExpress.XtraEditors.LabelControl lblNomeClasseDados;
        private DevExpress.XtraEditors.TextEdit txtNomeClasseDados;
        private DevExpress.XtraEditors.LabelControl lblNomeClasseGerenciamento;
        private DevExpress.XtraEditors.TextEdit txtNomeClasseGerenciamento;
        private DevExpress.XtraEditors.SimpleButton cmdAnalisar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcNome;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcTipo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcTamanho;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcObrigatorio;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpiCheckBox;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcChaveUnica;
        private DevExpress.XtraEditors.ListBoxControl lstIncludes;
        private DevExpress.XtraEditors.LabelControl lblIncludes;
        private DevExpress.XtraEditors.SimpleButton cmdAdicionaInclude;
        private DevExpress.XtraEditors.SimpleButton cmdDeleteInclude;
        private DevExpress.XtraEditors.SimpleButton cmdExibir;
        private DevExpress.XtraEditors.LabelControl lblFields;
        private DevExpress.XtraEditors.SimpleButton cmdCopiar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcAnulavel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trcAutonumerado;
        private DevExpress.XtraEditors.LabelControl lblIDNameSpace;
        private DevExpress.XtraEditors.TextEdit txtIDNameSpace;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblSubtitulo;
        private DevExpress.XtraEditors.GroupControl grcVisualizacao;
        private DevExpress.XtraEditors.SimpleButton cmdFecharVisualizador;
        private DevExpress.XtraEditors.MemoEdit memVisualizacao;
    }
}

