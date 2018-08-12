using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.Lists;

namespace Decision
{
    public partial class seguranca : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de acesso
        Security_Manager oSecurity = new Security_Manager();
        public bool Security_Insert = false;
        public bool Security_Update = false;
        public bool Security_Delete = false;

        protected void Page_Init(object sender, EventArgs e)
        {
            #region "Controle de login"

            //*************************
            //* Obtem dados de conexão
            //*************************
            if (Session["Decision_LoginInfo"] != null)
                oLogin = (Login_Manager)Session["Decision_LoginInfo"];
            else
                oLogin.LogOff();

            //***************
            //* Sem conexão?
            //***************
            if (oLogin.LoginInfo.Usuario_Codigo == 0)
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("conectar.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("conectar.aspx");
            }

            #endregion

            #region "Controle de segurança"

            //****************************************************
            //* Incializa segurança e verifica pemissão de acesso
            //****************************************************
            oSecurity.InitializeSecurity(oLogin);
            if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes))
            {
                //**********************************************************
                //* Evita falha de redirecionamento quando em CallBack Mode
                //**********************************************************
                if (!Page.IsCallback)
                    Response.Redirect("~/abertura.aspx", false);
                else
                    ASPxWebControl.RedirectOnCallback("~/abertura.aspx");
            }

            //*************************************************
            //* Define acesso à inclusão, alteração e exclusão
            //*************************************************
            if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes))
                Security_Insert = true;
            if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes))
                Security_Update = true;
            if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes))
                Security_Delete = true;

            #endregion

            //*****************************
            //* Atualiza string de conexão
            //*****************************
            dsSeguranca.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsPermissao.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsUsuarios.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsGrupo.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;

            //****************************************
            //* Atualiza BINDs somente na atualização
            //****************************************
            if (!IsPostBack && !IsCallback)
            {
                //***************************
                //* Define seleção de grupos
                //***************************
                string SQL = "SELECT codgrupo, descgrupo FROM grupos ORDER BY descgrupo";
                dsGrupo.SelectCommand = SQL;
                cboGrupo.DataBind();

                //***************************
                //* Existe seleção de grupo?
                //***************************
                if (cboGrupo.SelectedIndex == -1)
                {
                    //**************************************
                    //* Anula seleção e esconde componentes
                    //**************************************
                    Session["Decision_Permissoes_CodGrupo"] = 0;
                    grvSeguranca.Visible = false;
                    lblNomeGrupo.Visible = false;
                    grvUsuarios.Visible = false;
                }

                //*******************************
                //* Define seleção de permissões 
                //*******************************
                SQL = "SELECT permissoes.codpermissao, permissoes.descricaopermissao ";
                SQL += "FROM permissoes_opcoes ORDER BY permissoes.posicao";
                dsPermissao.SelectCommand = SQL;
                dsPermissao.DataBind();

                //*******************************
                //* Define seleção de permissões 
                //*******************************
                SQL = "SELECT ";
                SQL += "grupos.codgrupo,";
                SQL += "grupos.descgrupo,";
                SQL += "permissoes_opcoes.codpermissao,";
                SQL += "permissoes_opcoes.descricaopermissao,";
                SQL += "permissoes_grupos.codagrupamento,";
                SQL += "permissoes_grupos.acesso,";
                SQL += "permissoes_grupos.inclusao,";
                SQL += "permissoes_grupos.alteracao,";
                SQL += "permissoes_grupos.exclusao ";
                SQL += "FROM permissoes_grupos ";
                SQL += "LEFT JOIN permissoes_opcoes ON permissoes_opcoes.codpermissao = permissoes_grupos.codpermissao ";
                SQL += "LEFT JOIN grupos ON grupos.codgrupo = permissoes_grupos.codgrupo ";
                SQL += "WHERE grupos.codgrupo = ? ORDER BY posicao";
                dsSeguranca.SelectCommand = SQL;
                dsSeguranca.DataBind();

                //*********************************************
                //* Define segurança do cadastro de permissões
                //*********************************************
                grvSeguranca.SettingsDataSecurity.AllowInsert = oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes);
                grvSeguranca.SettingsDataSecurity.AllowEdit = oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes);
                grvSeguranca.SettingsDataSecurity.AllowDelete = oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes);
            }
        }
        protected void cboGrupo_ValueChanged(object sender, EventArgs e)
        {
            //*************************
            //* Define código do grupo
            //*************************
            ASPxComboBox oCombo = (ASPxComboBox)sender;
            Session["Decision_Permissoes_CodGrupo"] = oCombo.Value;
            lblNomeGrupo.Text = "Usuários pertencentes ao grupo " + oCombo.Text;

            //**********************************
            //* Deve exibir demais componentes?
            //**********************************
            if (cboGrupo.SelectedIndex != -1)
            {
                grvSeguranca.Visible = true;
                lblNomeGrupo.Visible = true;
                grvUsuarios.Visible = true;
            }

            //***************************
            //* Refaz conjuntos de dados
            //***************************
            grvSeguranca.DataBind();
            grvUsuarios.DataBind();
        }
        protected void grvSeguranca_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            //**************
            //* Declarações
            //**************
            string SQL = string.Empty;

            //*************************
            //* Inserção ou alteração?
            //*************************
            if (e.IsNewRow)
            {
                //****************************************************
                //* A permissão já foi cadastrada para o grupo atual?
                //****************************************************
                if (oSecurity.IsPermissionInGroup(oLogin, Convert.ToInt32(e.NewValues["codpermissao"]), Convert.ToInt32(cboGrupo.Value), 0))
                    e.Errors.Add(grvSeguranca.Columns["codpermissao"], "A permissão selecionada já foi existe no grupo atual.");
            }
            else
            {
                //****************************************************
                //* A permissão já foi cadastrada para o grupo atual?
                //****************************************************
                if (oSecurity.IsPermissionInGroup(oLogin, Convert.ToInt32(e.NewValues["codpermissao"]), Convert.ToInt32(cboGrupo.Value), Convert.ToInt32(e.Keys["codagrupamento"])))
                    e.Errors.Add(grvSeguranca.Columns["codpermissao"], "A permissão selecionada já existe no grupo atual.");
            }
        }
        protected void grvSeguranca_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            //***********************************
            //* Inclusão, alteração ou exclusão?
            //***********************************
            if (e.Column.FieldName == "inclusao" || e.Column.FieldName == "alteracao" || e.Column.FieldName == "exclusao")
            {
                //*************************************************
                //* Deve restringir acesso para permissão simples?
                //*************************************************
                if (oSecurity.IsSimpleGroupPermission(oLogin, Convert.ToInt32(e.KeyValue)))
                {
                    e.Editor.ReadOnly = true;
                    e.Editor.ClientEnabled = false;
                }
            }
        }
        protected void grvSeguranca_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            //**************************
            //* Permissão tipo SIMPLES?
            //**************************
            if (oSecurity.IsSimplePermission(oLogin, Convert.ToInt32(e.NewValues["codpermissao"])))
            {
                //**************************
                //* Anula demais permissões
                //**************************
                e.NewValues["inclusao"] = false;
                e.NewValues["alteracao"] = false;
                e.NewValues["exclusao"] = false;
            }
        }
    }
}