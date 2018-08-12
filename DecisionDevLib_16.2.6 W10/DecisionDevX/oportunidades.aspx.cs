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
using Decision.Extensions;

namespace Decision
{
    public partial class oportunidades : System.Web.UI.Page
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
            if (!oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
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
            if (oSecurity.CanInsert(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                Security_Insert = true;
            if (oSecurity.CanUpdate(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                Security_Update = true;
            if (oSecurity.CanDelete(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
                Security_Delete = true;

            //****************************
            //* Há restrição de conteúdo?
            //****************************
            if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade_Restringir))
            {
                //*****************************
                //* Cria seleção com restrição
                //*****************************
                string SQL = "SELECT ";
                SQL += "oportunidade.valor_estimado,";
                SQL += "oportunidade.valor_fechado,";
                SQL += "oportunidade.nro_oportunidade AS numero,";
                SQL += "oportunidade.data_operacao,";
                SQL += "oportunidade.contato_nome AS contato_nome,";
                SQL += "oportunidade.destino AS destino,";
                SQL += "oportunidade_situacao.descricao AS situacao,";
                SQL += "promotor.NomePromotor AS nomepromotor,";
                SQL += "oportunidade.proximo_contato ";
                SQL += "FROM oportunidade ";
                SQL += "LEFT JOIN promotor ON promotor.CodPromotor = oportunidade.cod_promotor ";
                SQL += "LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao ";
                SQL += "WHERE oportunidade.cod_promotor = " + oLogin.LoginInfo.Usuario_CodigoPromotor + " ";
                SQL += "ORDER BY oportunidade.nro_oportunidade DESC";
                dsOportunidades.SelectCommand = SQL;
            }

            #endregion

            //*****************************
            //* Atualiza string de conexão
            //*****************************
            dsOportunidades.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
            dsOportunidades.DataBind();
            grvOportunidades.DataBind();
        }
        protected void grvOportunidades_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            //***********************
            //* Dados indisponiveis?
            //***********************
            if (e.RowType != GridViewRowType.Data)
                return;

            //***************************
            //* Obtem código da situação
            //***************************
            string Situacao = e.GetValue("situacao").ToString();

            //*******************************
            //* Qualificação = Linha Amarela
            //*******************************
            if (Situacao == OptionLists.OportunidadeStuacao.Qualificacao.GetDescription())
                e.Row.BackColor = System.Drawing.Color.LightYellow;

            //***********************
            //* Análise = Linha Azul
            //***********************
            if (Situacao == OptionLists.OportunidadeStuacao.Analise.GetDescription())
                e.Row.BackColor = System.Drawing.Color.Lavender;
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            gveOportunidades.WritePdfToResponse();
        }
    }
}