namespace DecisionDesktop
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.ricMenuMDI = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiMenu = new DevExpress.XtraBars.BarButtonItem();
            this.ppcMenuMDI = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.mclWindows = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConfig = new DevExpress.XtraBars.BarButtonItem();
            this.ppcMenuConfig = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.bbiUser = new DevExpress.XtraBars.BarButtonItem();
            this.ppcMenuUsuario = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.cmdSairUsuario = new DevExpress.XtraEditors.SimpleButton();
            this.cmdDesconectar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTituloControleLogin = new DevExpress.XtraEditors.LabelControl();
            this.rbpMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgMenu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bdcMenuControler = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            this.tbcMenuSearch = new DevExpress.XtraToolbox.ToolboxControl();
            this.toolboxGroup1 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolboxItem1 = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolboxItem2 = new DevExpress.XtraToolbox.ToolboxItem();
            this.tbiRequisicoes = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolboxItem4 = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolboxGroup2 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolboxItem5 = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolboxItem6 = new DevExpress.XtraToolbox.ToolboxItem();
            this.popLogin = new DevExpress.XtraEditors.PopupContainerControl();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new DevExpress.XtraEditors.TextEdit();
            this.lblLoginTitulo = new DevExpress.XtraEditors.LabelControl();
            this.cmdSair = new DevExpress.XtraEditors.SimpleButton();
            this.cmdConectar = new DevExpress.XtraEditors.SimpleButton();
            this.pnlComandos = new DevExpress.XtraEditors.PanelControl();
            this.lnkAlterarSenha = new System.Windows.Forms.LinkLabel();
            this.lnkEsqueci = new System.Windows.Forms.LinkLabel();
            this.chkManterConectado = new DevExpress.XtraEditors.CheckEdit();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtSenha = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.vprLogin = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            ((System.ComponentModel.ISupportInitialize)(this.ricMenuMDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuMDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuUsuario)).BeginInit();
            this.ppcMenuUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popLogin)).BeginInit();
            this.popLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlComandos)).BeginInit();
            this.pnlComandos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkManterConectado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vprLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // ricMenuMDI
            // 
            this.ricMenuMDI.ExpandCollapseItem.Id = 0;
            this.ricMenuMDI.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ricMenuMDI.ExpandCollapseItem,
            this.bbiMenu,
            this.mclWindows,
            this.barButtonItem1,
            this.barStaticItem1,
            this.barButtonItem2,
            this.bbiConfig,
            this.bbiUser});
            this.ricMenuMDI.Location = new System.Drawing.Point(0, 0);
            this.ricMenuMDI.MaxItemId = 11;
            this.ricMenuMDI.Name = "ricMenuMDI";
            this.ricMenuMDI.PageHeaderItemLinks.Add(this.bbiConfig);
            this.ricMenuMDI.PageHeaderItemLinks.Add(this.bbiUser);
            this.ricMenuMDI.PageHeaderItemLinks.Add(this.mclWindows);
            this.ricMenuMDI.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpMenu});
            this.ricMenuMDI.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ricMenuMDI.Size = new System.Drawing.Size(980, 133);
            this.ricMenuMDI.Merge += new DevExpress.XtraBars.Ribbon.RibbonMergeEventHandler(this.ricMenuMDI_Merge);
            // 
            // bbiMenu
            // 
            this.bbiMenu.ActAsDropDown = true;
            this.bbiMenu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.bbiMenu.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiMenu.Caption = "Menu auxiliar";
            this.bbiMenu.DropDownControl = this.ppcMenuMDI;
            this.bbiMenu.Id = 1;
            this.bbiMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiMenu.ImageOptions.Image")));
            this.bbiMenu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiMenu.ImageOptions.LargeImage")));
            this.bbiMenu.Name = "bbiMenu";
            this.bbiMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            toolTipItem1.Text = "Menu de acesso direto";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiMenu.SuperTip = superToolTip1;
            // 
            // ppcMenuMDI
            // 
            this.ppcMenuMDI.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ppcMenuMDI.Appearance.Options.UseBackColor = true;
            this.ppcMenuMDI.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ppcMenuMDI.Location = new System.Drawing.Point(271, 150);
            this.ppcMenuMDI.LookAndFeel.SkinName = "Office 2013";
            this.ppcMenuMDI.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.ppcMenuMDI.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ppcMenuMDI.Name = "ppcMenuMDI";
            this.ppcMenuMDI.Ribbon = this.ricMenuMDI;
            this.ppcMenuMDI.Size = new System.Drawing.Size(178, 34);
            this.ppcMenuMDI.TabIndex = 1;
            this.ppcMenuMDI.Visible = false;
            // 
            // mclWindows
            // 
            this.mclWindows.Caption = "Janelas ativas";
            this.mclWindows.Id = 1;
            this.mclWindows.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mclWindows.ImageOptions.Image")));
            this.mclWindows.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mclWindows.ImageOptions.LargeImage")));
            this.mclWindows.Name = "mclWindows";
            this.mclWindows.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            toolTipItem2.Text = "Lista de janelas abertas\r\n";
            superToolTip2.Items.Add(toolTipItem2);
            this.mclWindows.SuperTip = superToolTip2;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 7;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 8;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbiConfig
            // 
            this.bbiConfig.ActAsDropDown = true;
            this.bbiConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiConfig.Caption = "Configurações";
            this.bbiConfig.DropDownControl = this.ppcMenuConfig;
            this.bbiConfig.Id = 9;
            this.bbiConfig.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiConfig.ImageOptions.Image")));
            this.bbiConfig.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiConfig.ImageOptions.LargeImage")));
            this.bbiConfig.Name = "bbiConfig";
            // 
            // ppcMenuConfig
            // 
            this.ppcMenuConfig.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ppcMenuConfig.Appearance.Options.UseBackColor = true;
            this.ppcMenuConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ppcMenuConfig.Location = new System.Drawing.Point(271, 190);
            this.ppcMenuConfig.LookAndFeel.SkinName = "Office 2013";
            this.ppcMenuConfig.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.ppcMenuConfig.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ppcMenuConfig.Name = "ppcMenuConfig";
            this.ppcMenuConfig.Ribbon = this.ricMenuMDI;
            this.ppcMenuConfig.Size = new System.Drawing.Size(178, 73);
            this.ppcMenuConfig.TabIndex = 3;
            this.ppcMenuConfig.Visible = false;
            // 
            // bbiUser
            // 
            this.bbiUser.ActAsDropDown = true;
            this.bbiUser.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.bbiUser.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiUser.Caption = "Sua conta";
            this.bbiUser.DropDownControl = this.ppcMenuUsuario;
            this.bbiUser.Id = 10;
            this.bbiUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUser.ImageOptions.Image")));
            this.bbiUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUser.ImageOptions.LargeImage")));
            this.bbiUser.Name = "bbiUser";
            // 
            // ppcMenuUsuario
            // 
            this.ppcMenuUsuario.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.ppcMenuUsuario.Appearance.Options.UseBackColor = true;
            this.ppcMenuUsuario.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.ppcMenuUsuario.Controls.Add(this.cmdSairUsuario);
            this.ppcMenuUsuario.Controls.Add(this.cmdDesconectar);
            this.ppcMenuUsuario.Controls.Add(this.lblTituloControleLogin);
            this.ppcMenuUsuario.Location = new System.Drawing.Point(271, 269);
            this.ppcMenuUsuario.LookAndFeel.SkinName = "Office 2013";
            this.ppcMenuUsuario.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.ppcMenuUsuario.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ppcMenuUsuario.Name = "ppcMenuUsuario";
            this.ppcMenuUsuario.Ribbon = this.ricMenuMDI;
            this.ppcMenuUsuario.Size = new System.Drawing.Size(178, 37);
            this.ppcMenuUsuario.TabIndex = 2;
            this.ppcMenuUsuario.Visible = false;
            // 
            // cmdSairUsuario
            // 
            this.cmdSairUsuario.CausesValidation = false;
            this.cmdSairUsuario.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSairUsuario.Location = new System.Drawing.Point(275, 179);
            this.cmdSairUsuario.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdSairUsuario.Name = "cmdSairUsuario";
            this.cmdSairUsuario.Size = new System.Drawing.Size(87, 30);
            this.cmdSairUsuario.TabIndex = 10;
            this.cmdSairUsuario.Text = "Sair";
            this.cmdSairUsuario.Click += new System.EventHandler(this.cmdSairUsuario_Click);
            // 
            // cmdDesconectar
            // 
            this.cmdDesconectar.CausesValidation = false;
            this.cmdDesconectar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDesconectar.Location = new System.Drawing.Point(182, 179);
            this.cmdDesconectar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdDesconectar.Name = "cmdDesconectar";
            this.cmdDesconectar.Size = new System.Drawing.Size(87, 30);
            this.cmdDesconectar.TabIndex = 9;
            this.cmdDesconectar.Text = "Desconectar";
            this.cmdDesconectar.Click += new System.EventHandler(this.cmdDesconectar_Click);
            // 
            // lblTituloControleLogin
            // 
            this.lblTituloControleLogin.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lblTituloControleLogin.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTituloControleLogin.Appearance.Options.UseBackColor = true;
            this.lblTituloControleLogin.Appearance.Options.UseForeColor = true;
            this.lblTituloControleLogin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTituloControleLogin.Location = new System.Drawing.Point(0, 1);
            this.lblTituloControleLogin.Name = "lblTituloControleLogin";
            this.lblTituloControleLogin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTituloControleLogin.Size = new System.Drawing.Size(375, 37);
            this.lblTituloControleLogin.TabIndex = 1;
            this.lblTituloControleLogin.Text = "Controle de Login";
            // 
            // rbpMenu
            // 
            this.rbpMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgMenu});
            this.rbpMenu.Name = "rbpMenu";
            this.rbpMenu.Text = "Menu";
            // 
            // rpgMenu
            // 
            this.rpgMenu.ItemLinks.Add(this.bbiMenu);
            this.rpgMenu.Name = "rpgMenu";
            this.rpgMenu.Text = "Menu";
            // 
            // bdcMenuControler
            // 
            this.bdcMenuControler.Controller.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.bdcMenuControler.Controller.LookAndFeel.UseDefaultLookAndFeel = false;
            this.bdcMenuControler.Controller.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.bdcMenuControler.Controller.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // tbcMenuSearch
            // 
            this.tbcMenuSearch.Caption = "Menu de acesso rápido";
            this.tbcMenuSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbcMenuSearch.Groups.Add(this.toolboxGroup1);
            this.tbcMenuSearch.Groups.Add(this.toolboxGroup2);
            this.tbcMenuSearch.Location = new System.Drawing.Point(0, 133);
            this.tbcMenuSearch.Name = "tbcMenuSearch";
            this.tbcMenuSearch.OptionsBehavior.AllowSmoothScrolling = true;
            this.tbcMenuSearch.OptionsView.ColumnCount = 1;
            this.tbcMenuSearch.OptionsView.MenuButtonCaption = "Acesso rápido";
            this.tbcMenuSearch.OptionsView.MoreItemsButtonImage = ((System.Drawing.Image)(resources.GetObject("tbcMenuSearch.OptionsView.MoreItemsButtonImage")));
            this.tbcMenuSearch.OptionsView.ShowMenuButton = false;
            this.tbcMenuSearch.OptionsView.ShowToolboxCaption = true;
            this.tbcMenuSearch.Size = new System.Drawing.Size(250, 511);
            this.tbcMenuSearch.TabIndex = 0;
            this.tbcMenuSearch.Text = "Menu de acesso rápido";
            this.tbcMenuSearch.ItemClick += new DevExpress.XtraToolbox.ToolboxItemClickEventHandler(this.tbcMenuSearch_ItemClick);
            // 
            // toolboxGroup1
            // 
            this.toolboxGroup1.BeginGroup = false;
            this.toolboxGroup1.BeginGroupCaption = "";
            this.toolboxGroup1.Caption = "Cadastros";
            this.toolboxGroup1.Items.Add(this.toolboxItem1);
            this.toolboxGroup1.Items.Add(this.toolboxItem2);
            this.toolboxGroup1.Items.Add(this.tbiRequisicoes);
            this.toolboxGroup1.Items.Add(this.toolboxItem4);
            this.toolboxGroup1.Name = "toolboxGroup1";
            // 
            // toolboxItem1
            // 
            this.toolboxItem1.BeginGroup = false;
            this.toolboxItem1.BeginGroupCaption = null;
            this.toolboxItem1.Caption = "Cadastro de clientes";
            this.toolboxItem1.Name = "toolboxItem1";
            // 
            // toolboxItem2
            // 
            this.toolboxItem2.BeginGroup = false;
            this.toolboxItem2.BeginGroupCaption = null;
            this.toolboxItem2.Caption = "Relatório de clientes";
            this.toolboxItem2.Name = "toolboxItem2";
            // 
            // tbiRequisicoes
            // 
            this.tbiRequisicoes.BeginGroup = false;
            this.tbiRequisicoes.BeginGroupCaption = null;
            this.tbiRequisicoes.Caption = "Cadastro de requisições";
            this.tbiRequisicoes.Name = "tbiRequisicoes";
            // 
            // toolboxItem4
            // 
            this.toolboxItem4.BeginGroup = false;
            this.toolboxItem4.BeginGroupCaption = null;
            this.toolboxItem4.Caption = "Requisições Vouchers";
            this.toolboxItem4.Name = "toolboxItem4";
            // 
            // toolboxGroup2
            // 
            this.toolboxGroup2.BeginGroup = false;
            this.toolboxGroup2.BeginGroupCaption = "";
            this.toolboxGroup2.Caption = "Movimentos";
            this.toolboxGroup2.Items.Add(this.toolboxItem5);
            this.toolboxGroup2.Items.Add(this.toolboxItem6);
            this.toolboxGroup2.Name = "toolboxGroup2";
            // 
            // toolboxItem5
            // 
            this.toolboxItem5.BeginGroup = false;
            this.toolboxItem5.BeginGroupCaption = null;
            this.toolboxItem5.Caption = "toolboxItem5";
            this.toolboxItem5.Name = "toolboxItem5";
            // 
            // toolboxItem6
            // 
            this.toolboxItem6.BeginGroup = false;
            this.toolboxItem6.BeginGroupCaption = null;
            this.toolboxItem6.Caption = "toolboxItem6";
            this.toolboxItem6.Name = "toolboxItem6";
            // 
            // popLogin
            // 
            this.popLogin.Controls.Add(this.lblEmpresa);
            this.popLogin.Controls.Add(this.txtEmpresa);
            this.popLogin.Controls.Add(this.lblLoginTitulo);
            this.popLogin.Controls.Add(this.cmdSair);
            this.popLogin.Controls.Add(this.cmdConectar);
            this.popLogin.Controls.Add(this.pnlComandos);
            this.popLogin.Controls.Add(this.lblSenha);
            this.popLogin.Controls.Add(this.lblUsuario);
            this.popLogin.Controls.Add(this.txtSenha);
            this.popLogin.Controls.Add(this.txtUsuario);
            this.popLogin.Location = new System.Drawing.Point(493, 150);
            this.popLogin.Name = "popLogin";
            this.popLogin.Size = new System.Drawing.Size(461, 288);
            this.popLogin.TabIndex = 15;
            this.popLogin.VisibleChanged += new System.EventHandler(this.popLogin_VisibleChanged);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblEmpresa.Location = new System.Drawing.Point(218, 56);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(48, 13);
            this.lblEmpresa.TabIndex = 1;
            this.lblEmpresa.Text = "Empresa";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.EditValue = "";
            this.txtEmpresa.Location = new System.Drawing.Point(221, 71);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.Properties.Appearance.Options.UseFont = true;
            this.txtEmpresa.Properties.AutoHeight = false;
            this.txtEmpresa.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtEmpresa.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtEmpresa.Properties.MaxLength = 30;
            this.txtEmpresa.Size = new System.Drawing.Size(198, 24);
            this.txtEmpresa.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Por favor, informe o nome da empresa";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = "";
            this.vprLogin.SetValidationRule(this.txtEmpresa, conditionValidationRule1);
            // 
            // lblLoginTitulo
            // 
            this.lblLoginTitulo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lblLoginTitulo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblLoginTitulo.Appearance.Options.UseBackColor = true;
            this.lblLoginTitulo.Appearance.Options.UseForeColor = true;
            this.lblLoginTitulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLoginTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblLoginTitulo.Name = "lblLoginTitulo";
            this.lblLoginTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblLoginTitulo.Size = new System.Drawing.Size(461, 37);
            this.lblLoginTitulo.TabIndex = 0;
            this.lblLoginTitulo.Text = "Login - Informe seu usuário e senha";
            // 
            // cmdSair
            // 
            this.cmdSair.CausesValidation = false;
            this.cmdSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSair.Location = new System.Drawing.Point(339, 234);
            this.cmdSair.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdSair.Name = "cmdSair";
            this.cmdSair.Size = new System.Drawing.Size(80, 30);
            this.cmdSair.TabIndex = 8;
            this.cmdSair.Text = "Sair";
            this.cmdSair.Click += new System.EventHandler(this.cmdSair_Click);
            // 
            // cmdConectar
            // 
            this.cmdConectar.Location = new System.Drawing.Point(221, 234);
            this.cmdConectar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmdConectar.Name = "cmdConectar";
            this.cmdConectar.Size = new System.Drawing.Size(80, 30);
            this.cmdConectar.TabIndex = 7;
            this.cmdConectar.Text = "Conectar";
            this.cmdConectar.Click += new System.EventHandler(this.cmdConectar_Click);
            // 
            // pnlComandos
            // 
            this.pnlComandos.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlComandos.Appearance.Options.UseBackColor = true;
            this.pnlComandos.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlComandos.Controls.Add(this.lnkAlterarSenha);
            this.pnlComandos.Controls.Add(this.lnkEsqueci);
            this.pnlComandos.Controls.Add(this.chkManterConectado);
            this.pnlComandos.Location = new System.Drawing.Point(0, 0);
            this.pnlComandos.LookAndFeel.SkinName = "Office 2013";
            this.pnlComandos.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlComandos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Size = new System.Drawing.Size(163, 288);
            this.pnlComandos.TabIndex = 17;
            // 
            // lnkAlterarSenha
            // 
            this.lnkAlterarSenha.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lnkAlterarSenha.AutoSize = true;
            this.lnkAlterarSenha.CausesValidation = false;
            this.lnkAlterarSenha.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkAlterarSenha.Location = new System.Drawing.Point(13, 133);
            this.lnkAlterarSenha.Name = "lnkAlterarSenha";
            this.lnkAlterarSenha.Size = new System.Drawing.Size(135, 13);
            this.lnkAlterarSenha.TabIndex = 4;
            this.lnkAlterarSenha.TabStop = true;
            this.lnkAlterarSenha.Text = "Quero alterar minha senha";
            this.lnkAlterarSenha.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.lnkAlterarSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlterarSenha_LinkClicked);
            // 
            // lnkEsqueci
            // 
            this.lnkEsqueci.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199)))));
            this.lnkEsqueci.AutoSize = true;
            this.lnkEsqueci.CausesValidation = false;
            this.lnkEsqueci.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkEsqueci.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkEsqueci.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lnkEsqueci.Location = new System.Drawing.Point(13, 107);
            this.lnkEsqueci.Name = "lnkEsqueci";
            this.lnkEsqueci.Size = new System.Drawing.Size(103, 13);
            this.lnkEsqueci.TabIndex = 3;
            this.lnkEsqueci.TabStop = true;
            this.lnkEsqueci.Text = "Esqueci meus dados";
            this.lnkEsqueci.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.lnkEsqueci.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEsqueci_LinkClicked);
            // 
            // chkManterConectado
            // 
            this.chkManterConectado.CausesValidation = false;
            this.chkManterConectado.Location = new System.Drawing.Point(16, 240);
            this.chkManterConectado.MenuManager = this.ricMenuMDI;
            this.chkManterConectado.Name = "chkManterConectado";
            this.chkManterConectado.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkManterConectado.Properties.Appearance.Options.UseForeColor = true;
            this.chkManterConectado.Properties.Caption = "Manter conectado";
            this.chkManterConectado.Size = new System.Drawing.Size(113, 17);
            this.chkManterConectado.TabIndex = 2;
            this.chkManterConectado.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.chkManterConectado_EditValueChanging);
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblSenha.Location = new System.Drawing.Point(218, 162);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(37, 13);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblUsuario.Location = new System.Drawing.Point(218, 109);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtSenha
            // 
            this.txtSenha.EditValue = "";
            this.txtSenha.Location = new System.Drawing.Point(221, 177);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Properties.Appearance.Options.UseFont = true;
            this.txtSenha.Properties.AutoHeight = false;
            this.txtSenha.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtSenha.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSenha.Properties.MaxLength = 50;
            this.txtSenha.Properties.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(198, 24);
            this.txtSenha.TabIndex = 6;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Por favor, informe sua senha de acesso";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule2.Value1 = "";
            this.vprLogin.SetValidationRule(this.txtSenha, conditionValidationRule2);
            // 
            // txtUsuario
            // 
            this.txtUsuario.EditValue = "";
            this.txtUsuario.Location = new System.Drawing.Point(221, 124);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Properties.AutoHeight = false;
            this.txtUsuario.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.txtUsuario.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtUsuario.Properties.MaxLength = 50;
            this.txtUsuario.Size = new System.Drawing.Size(198, 24);
            this.txtUsuario.TabIndex = 4;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "Por favor, informe sua identidade de usuário";
            conditionValidationRule3.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.vprLogin.SetValidationRule(this.txtUsuario, conditionValidationRule3);
            // 
            // vprLogin
            // 
            this.vprLogin.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(250, 133);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 644);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ppcMenuConfig);
            this.Controls.Add(this.ppcMenuUsuario);
            this.Controls.Add(this.popLogin);
            this.Controls.Add(this.tbcMenuSearch);
            this.Controls.Add(this.ppcMenuMDI);
            this.Controls.Add(this.ricMenuMDI);
            this.DoubleBuffered = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPrincipal";
            this.Ribbon = this.ricMenuMDI;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DECISION - Travel Manager System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.InterfaceLogin);
            this.SizeChanged += new System.EventHandler(this.InterfaceAdjust);
            ((System.ComponentModel.ISupportInitialize)(this.ricMenuMDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuMDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppcMenuUsuario)).EndInit();
            this.ppcMenuUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdcMenuControler.Controller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popLogin)).EndInit();
            this.popLogin.ResumeLayout(false);
            this.popLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlComandos)).EndInit();
            this.pnlComandos.ResumeLayout(false);
            this.pnlComandos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkManterConectado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vprLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ricMenuMDI;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgMenu;
        private DevExpress.XtraBars.DefaultBarAndDockingController bdcMenuControler;
        private DevExpress.XtraBars.BarButtonItem bbiMenu;
        private DevExpress.XtraBars.PopupControlContainer ppcMenuMDI;
        private DevExpress.XtraToolbox.ToolboxControl tbcMenuSearch;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup1;
        private DevExpress.XtraToolbox.ToolboxItem toolboxItem1;
        private DevExpress.XtraToolbox.ToolboxItem toolboxItem2;
        private DevExpress.XtraToolbox.ToolboxItem tbiRequisicoes;
        private DevExpress.XtraToolbox.ToolboxItem toolboxItem4;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup2;
        private DevExpress.XtraToolbox.ToolboxItem toolboxItem5;
        private DevExpress.XtraToolbox.ToolboxItem toolboxItem6;
        private DevExpress.XtraBars.BarMdiChildrenListItem mclWindows;
        private DevExpress.XtraEditors.PopupContainerControl popLogin;
        private System.Windows.Forms.Label lblEmpresa;
        private DevExpress.XtraEditors.TextEdit txtEmpresa;
        private DevExpress.XtraEditors.LabelControl lblLoginTitulo;
        private DevExpress.XtraEditors.SimpleButton cmdSair;
        private DevExpress.XtraEditors.SimpleButton cmdConectar;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblUsuario;
        private DevExpress.XtraEditors.TextEdit txtSenha;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.PanelControl pnlComandos;
        private DevExpress.XtraEditors.CheckEdit chkManterConectado;
        private System.Windows.Forms.LinkLabel lnkAlterarSenha;
        private System.Windows.Forms.LinkLabel lnkEsqueci;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider vprLogin;
        private DevExpress.XtraBars.PopupControlContainer ppcMenuUsuario;
        private DevExpress.XtraBars.PopupControlContainer ppcMenuConfig;
        private DevExpress.XtraEditors.SimpleButton cmdDesconectar;
        private DevExpress.XtraEditors.LabelControl lblTituloControleLogin;
        private DevExpress.XtraEditors.SimpleButton cmdSairUsuario;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bbiConfig;
        private DevExpress.XtraBars.BarButtonItem bbiUser;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}