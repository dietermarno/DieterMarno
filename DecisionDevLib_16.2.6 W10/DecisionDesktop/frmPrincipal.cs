using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Decision.LoginManager;
using Decision.Util;
using DevExpress.Utils;

namespace DecisionDesktop
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //********************************************
        //* Cria classe global para controle de login
        //********************************************
        public Login_Manager UserLogin = new Login_Manager();
        public Timer oTimer = new Timer();

        public frmPrincipal()
        {
            //************************
            //* Inicializa formulário
            //************************
            InitializeComponent();
        }
        private bool LoadLoginData()
        {
            //******************************
            //* Remove informações de login
            //******************************
            if (AppConfig.ReadSetting("Login_AutoLogin") == "True")
            {
                //****************
                //* Login ativado
                //****************
                this.txtEmpresa.Text = Crypto.DecryptString(AppConfig.ReadSetting("Login_Database"));
                this.txtUsuario.Text = Crypto.DecryptString(AppConfig.ReadSetting("Login_Username"));
                this.txtSenha.Text = Crypto.DecryptString(AppConfig.ReadSetting("Login_Password"));
                this.chkManterConectado.Checked = true;
                return true;
            }
            else
            {
                //*******************
                //* Login desativado
                //*******************
                return false;
            }
        }
        private void SaveLoginData()
        {
            //******************************
            //* Remove informações de login
            //******************************
            AppConfig.AddUpdateAppSettings("Login_AutoLogin", this.chkManterConectado.Checked.ToString());
            AppConfig.AddUpdateAppSettings("Login_Database", Crypto.EncryptString(this.txtEmpresa.Text.Trim()));
            AppConfig.AddUpdateAppSettings("Login_Username", Crypto.EncryptString(this.txtUsuario.Text.Trim()));
            AppConfig.AddUpdateAppSettings("Login_Password", Crypto.EncryptString(this.txtSenha.Text.Trim()));
        }
        private void ClearLoginData()
        {
            //******************************
            //* Remove informações de login
            //******************************
            AppConfig.RemoveSetting("Login_AutoLogin");
            AppConfig.RemoveSetting("Login_Database");
            AppConfig.RemoveSetting("Login_Username");
            AppConfig.RemoveSetting("Login_Password");
        }
        private void InterfaceAdjust(object sender, EventArgs e)
        {
            //***************************
            //* Nome e versão do produto
            //**************************
            this.Text = "DECISION - Travel Manager System - Versão " + Application.ProductVersion.ToString();

            //**************************
            //* Define tamanho do popup
            //**************************
            this.ppcMenuMDI.Size = new Size(450, 275);
            this.ppcMenuUsuario.Size = new Size(375, 220);

            //*************************************
            //* Atualiza posição do popup de login
            //*************************************
            this.popLogin.Location = new Point((this.Width - this.popLogin.Width) / 2, (this.Height - this.popLogin.Height) / 2);
        }
        private void InterfaceLogin(object sender, EventArgs e)
        {
            //*********************
            //* Deve exigir login?
            //*********************
            if (UserLogin.LoginInfo.Usuario_Codigo == 0)
            {
                //**************************************
                //* Realiza login, manual ou automático
                //**************************************
                if (LoadLoginData())
                {
                    //****************************
                    //* Executa login temporizado
                    //****************************
                    oTimer.Interval = 100;
                    oTimer.Tick += LoginHandler;
                    oTimer.Start();
                }
                else
                {
                    //***********************
                    //* Executa login manual
                    //***********************
                    this.popLogin.Show();
                }
            }
        }
        private void DoLogin()
        {
            //******************
            //* Força validação
            //******************
            if (!this.vprLogin.Validate())
            {
                this.popLogin.Show();
                return;
            }

            //****************
            //* Realiza login
            //****************
            string LoginResult = UserLogin.Login(this.txtEmpresa.Text, this.txtUsuario.Text, this.txtSenha.Text, CommonDesktop.GetMasterConnectionString());

            //****************************
            //* O login foi bem sucedido?
            //****************************
            if (LoginResult == string.Empty)
            {
                //************************
                //* Salva ou apaga dados?
                //************************
                if (this.chkManterConectado.Checked)
                    SaveLoginData();
                else
                    ClearLoginData();

                //***************************************
                //* Atualiza dados do usuário e finaliza
                //***************************************
                LoginInfoUpdate();
                popLogin.Hide();
                return;
            }

            //*************************************************
            //* Exibe falha de acordo com a mensagem - SISTEMA
            //*************************************************
            if (LoginResult.StartsWith("sistema:"))
            {
                this.txtEmpresa.ErrorText = LoginResult.Substring(8).Trim();
                this.txtEmpresa.ErrorIconAlignment = ErrorIconAlignment.MiddleLeft;
                this.txtEmpresa.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
                this.popLogin.Show();
                return;
            }

            //*************************************************
            //* Exibe falha de acordo com a mensagem - EMPRESA
            //*************************************************
            if (LoginResult.StartsWith("empresa:"))
            {
                this.txtEmpresa.ErrorText = LoginResult.Substring(9).Trim();
                this.txtEmpresa.ErrorIconAlignment = ErrorIconAlignment.MiddleLeft;
                this.txtEmpresa.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
                this.popLogin.Show();
                return;
            }

            //*************************************************
            //* Exibe falha de acordo com a mensagem - USUARIO
            //*************************************************
            if (LoginResult.StartsWith("usuario:"))
            {
                this.txtUsuario.ErrorText = LoginResult.Substring(8).Trim();
                this.txtUsuario.ErrorIconAlignment = ErrorIconAlignment.MiddleLeft;
                this.txtUsuario.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
                this.popLogin.Show();
                return;
            }

            //***********************************************
            //* Exibe falha de acordo com a mensagem - SENHA
            //***********************************************
            if (LoginResult.StartsWith("senha:"))
            {
                this.txtSenha.ErrorText = LoginResult.Substring(6).Trim();
                this.txtSenha.ErrorIconAlignment = ErrorIconAlignment.MiddleLeft;
                this.txtSenha.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
                this.popLogin.Show();
                return;
            }

            //*******************************************
            //* Houve falha de conexão ao banco de dados
            //*******************************************
            if (UserLogin.Error)
            {
                //**************************
                //* Exibe mensagem de falha
                //**************************
                string Message = "Ocorreu falha ao conectar ao banco de dados.\r\n\r\n";
                Message += "A mensagem retornar pelo sistema foi:\r\n";
                Message += UserLogin.ErrorText + "\r\n\r\n";
                Message += "O sessão será encerrada.";
                MessageBox.Show(Message, "Falha na inicialização", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmdSair.PerformClick();
            }
        }
        private void LoginInfoUpdate()
        {
            //********************
            //* Declara variáveis
            //********************
            SuperToolTip oUserLogin = new SuperToolTip();
            SuperToolTipSetupArgs oArgs = new SuperToolTipSetupArgs();
            string LoginData = string.Empty;

            //***********
            //* Logotipo
            //***********
            oArgs.Title.Image = UserLogin.LoginInfo.Posto_Logotipo;
            oArgs.Title.ImageAlign = ToolTipImageAlignment.Default;

            //*****************
            //* Dados do posto
            //*****************
            if (UserLogin.LoginInfo.Posto_Nome.Trim() != string.Empty)
                LoginData += "<b>Posto:</b> " + UserLogin.LoginInfo.Posto_Nome;
            if (UserLogin.LoginInfo.Posto_Nome.Trim() != string.Empty && UserLogin.LoginInfo.Posto_Descricao.Trim() != string.Empty) 
                LoginData += " (" + UserLogin.LoginInfo.Posto_Descricao + ")\r\n";
            else
                if (LoginData != string.Empty) 
                    LoginData+= "\r\n";

            //*******************
            //* Dados do usuário
            //*******************
            if (UserLogin.LoginInfo.Usuario_Nome.Trim() != string.Empty)
                LoginData += "<b>Usuário:</b> " + UserLogin.LoginInfo.Usuario_Nome;
            if (UserLogin.LoginInfo.Usuario_Nome.Trim() != string.Empty && UserLogin.LoginInfo.Usuario_DescGrupo.Trim() != string.Empty)
                LoginData += " (" + UserLogin.LoginInfo.Usuario_DescGrupo + ")\r\n";
            else
                if (LoginData != string.Empty)
                    LoginData += "<b>Usuário:</b> " + UserLogin.LoginInfo.Usuario_ID + "\r\n";

            oArgs.Contents.Text = LoginData;
            oUserLogin.Setup(oArgs);
            oUserLogin.AllowHtmlText = DefaultBoolean.True;
            bbiUser.SuperTip = oUserLogin;
        }
        private void LoginHandler(object sender, EventArgs e)
        {
            //***************************************
            //* Obtem estado dos controle inferiores
            //***************************************
            oTimer.Stop();
            DoLogin();
        }
        private void popLogin_VisibleChanged(object sender, EventArgs e)
        {
            //***************************************
            //* Obtem estado dos controle inferiores
            //***************************************
            bool ControlState = !((PopupContainerControl)sender).Visible;

            //*****************************************
            //* Define estado dos controles inferiores
            //*****************************************
            this.ricMenuMDI.Enabled = ControlState;
        }
        private void cmdSair_Click(object sender, EventArgs e)
        {
            //**********************
            //* Finaliza formulário
            //**********************
            string Message = "Confirma o encerramento desta sessão?";
            DialogResult result = MessageBox.Show(Message, "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }
        private void cmdConectar_Click(object sender, EventArgs e)
        {
            //****************
            //* Executa login 
            //****************
            DoLogin();
        }
        private void lnkAlterarSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void lnkEsqueci_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void chkManterConectado_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //******************
            //* Força validação
            //******************
            if (!this.vprLogin.Validate())
            {
                e.Cancel = true;
                return;
            }
        }
        private void cmdUserInfo_Click(object sender, EventArgs e)
        {
            //**************************
            //* Exibe edição do usuário
            //**************************
            this.ppcMenuUsuario.Top = this.ricMenuMDI.Top + this.ricMenuMDI.Height + 5;
            this.ppcMenuUsuario.Left = this.Width - this.ppcMenuUsuario.Width - 25;
            this.ppcMenuUsuario.Show();
        }
        private void cmdDesconectar_Click(object sender, EventArgs e)
        {
            //**********************************
            //* Desconecta usuário e abre login
            //**********************************
            this.ppcMenuUsuario.Hide();
            UserLogin.LogOff();
            this.popLogin.Show();
        }
        private void cmdSairUsuario_Click(object sender, EventArgs e)
        {
            //**********************
            //* Finaliza formulário
            //**********************
            string Message = "Confirma o encerramento desta sessão?";
            DialogResult result = MessageBox.Show(Message, "Confirmação", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
            }
        }
        private void tbcMenuSearch_ItemClick(object sender, DevExpress.XtraToolbox.ToolboxItemClickEventArgs e)
        {
            //************************************
            //* Abre gerenciamento de requisições
            //************************************
            frmRequisicoes oForm = new frmRequisicoes(UserLogin);
            oForm.MdiParent = this;
            oForm.WindowState = FormWindowState.Maximized;
            oForm.Show();
        }
        private void ricMenuMDI_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e)
        {
            //**********************************
            //* Desconecta usuário e abre login
            //**********************************
            ricMenuMDI.SelectedPage = e.MergedChild.SelectedPage;
        }
    }
}
