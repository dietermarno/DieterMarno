using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using DevExpress.Web;
using Decision.LoginManager;
using Decision.Secutiry;
using Decision.Lists;
using Decision.Extensions;
using Decision.Database;

namespace Decision
{
    public partial class _default : System.Web.UI.Page
    {
        //*** Controle de login
        Login_Manager oLogin = new Login_Manager();

        //*** Controle de acesso
        Security_Manager oSecurity = new Security_Manager();
        public bool SemPermissoes = false;

        protected void Page_Init(object sender, EventArgs e)
        {
            //**************
            //* Declarações
            //**************
            string SQL = string.Empty;
            
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
            else
            {
                //*********************************
                //* Obtem lista de administradores
                //*********************************
                List<Login_Fields> AdminCollection = oLogin.GetAdmins(oLogin.LoginInfo.Master_ConexaoString);
                if (AdminCollection.Count > 0)
                {
                    //**************************************
                    //* O e-mail do administrador é válido?
                    //**************************************
                    if (AdminCollection[0].Usuario_EmailEndereco.ValidaEmail())
                    {
                        //*************
                        //* Exibe link
                        //*************
                        lnkAdmin.Value = "mailto:" + AdminCollection[0].Usuario_EmailEndereco;
                        lnkAdmin.Visible = true;
                    }
                }
            }

            #endregion

            #region "Controle de segurança"

            //****************************************************
            //* Incializa segurança e verifica pemissão de acesso
            //****************************************************
            oSecurity.InitializeSecurity(oLogin);

            //*****************************************************
            //* Existem permissões definidas para o usuário atual?
            //*****************************************************
            if (oSecurity.Permissions.Count == 0)
                SemPermissoes = true;
            else
                SemPermissoes = false;

            //*****************
            //* Sem permissão?
            //*****************
            if (SemPermissoes)
            {
                //****************************
                //* Oculta todos os controles
                //****************************
                divGrafico.Visible = false;
                divAgenda.Visible = false;
                divOportunidades.Visible = false;
            }
            else
            {
                //******************************
                //* Atualiza strings de conexão
                //******************************
                dsOportunidades.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
                dsAgenda.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
                dsOportunidadeTotal.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;
                dsOportunidadeUsuario.ConnectionString = oLogin.LoginInfo.Master_ConexaoString;

                //*******************************************************
                //* Gráfico: define visibilidade de acordo com restrição
                //*******************************************************
                bool RestricaoOportunidade = oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade_Restringir);
                wccUsuario.Visible = RestricaoOportunidade;
                wccTodos.Visible = !RestricaoOportunidade;

                //********************************************************
                //* Oportunidades: gráfico individual, filtro por usuário
                //********************************************************
                SQL = "SELECT ";
                SQL += "oportunidade_situacao.descricao,";
                SQL += "oportunidade.cod_situacao ";
                SQL += "FROM oportunidade ";
                SQL += "LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao ";
                SQL += "WHERE oportunidade.cod_promotor = " + oLogin.LoginInfo.Usuario_CodigoPromotor + " ";
                SQL += "ORDER BY oportunidade_situacao.descricao, oportunidade.proximo_contato DESC ";
                dsOportunidadeUsuario.SelectCommand = SQL;
                wccUsuario.DataBind();

                //*************************************************************
                //* Oportunidades: lista oportunidades de acordo com restrição
                //*************************************************************
                SQL = "SELECT ";
                SQL += "oportunidade.nro_oportunidade AS `codoportunidade`,";
                SQL += "promotor.nomepromotor,";
                SQL += "oportunidade.data_operacao,";
                SQL += "oportunidade_situacao.descricao AS `situacao`,";
                SQL += "oportunidade.contato_nome,";
                SQL += "oportunidade.destino,";
                SQL += "oportunidade.valor_estimado,";
                SQL += "oportunidade.valor_fechado ";
                SQL += "FROM oportunidade ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = oportunidade.cod_promotor ";
                SQL += "LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao ";
                if (RestricaoOportunidade)
                    SQL += "WHERE promotor.codpromotor = " + oLogin.LoginInfo.Usuario_CodigoPromotor + " ";
                SQL += "ORDER BY oportunidade_situacao.descricao, oportunidade.proximo_contato DESC";
                dsOportunidades.SelectCommand = SQL;
                grvOportunidades.DataBind();

                //*****************************************************
                //* Agenda: lista apontamentos de acordo com restrição
                //*****************************************************
                bool RestricaoAgenda = oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda_Restingir);
                SQL = "SELECT ";
                SQL += "agenda_apontamentos.codoportunidade,";
                SQL += "IF(NOT ISNULL(promotor.nomepromotor),promotor.nomepromotor,'-') AS `promotor`,";
                SQL += "agenda_apontamentos.inicio,";
                SQL += "IF(NOT ISNULL(oportunidade.destino), oportunidade.destino, agenda_apontamentos.`local`) AS `local`,";
                SQL += "IF(NOT ISNULL(oportunidade_situacao.descricao), oportunidade_situacao.descricao, agenda_status.descricao) AS `situacao`,";
                SQL += "IF(NOT ISNULL(oportunidade_estagio.descricao), oportunidade_estagio.descricao, '-') AS estagio,";
                SQL += "agenda_etiqueta.descricao AS `etiqueta`,";
                SQL += "agenda_apontamentos.assunto,";
                SQL += "oportunidade.contato_nome AS `contato` ";
                SQL += "FROM agenda_apontamentos ";
                SQL += "LEFT JOIN promotor ON promotor.codpromotor = agenda_apontamentos.codpromotor ";
                SQL += "LEFT JOIN oportunidade ON oportunidade.nro_oportunidade = agenda_apontamentos.codoportunidade ";
                SQL += "LEFT JOIN oportunidade_situacao ON oportunidade_situacao.codigo = oportunidade.cod_situacao ";
                SQL += "LEFT JOIN oportunidade_orcamentos ON oportunidade_orcamentos.cod_orcamento = agenda_apontamentos.codorcamento ";
                SQL += "LEFT JOIN oportunidade_estagio ON oportunidade_estagio.codigo = oportunidade_orcamentos.estagio_orcamento ";
                SQL += "LEFT JOIN agenda_etiqueta ON agenda_etiqueta.codetiqueta = agenda_apontamentos.etiqueta ";
                SQL += "LEFT JOIN agenda_status ON agenda_status.codstatus = agenda_apontamentos.situacao ";
                if (RestricaoAgenda)
                    SQL += "WHERE promotor.codpromotor = " + oLogin.LoginInfo.Usuario_CodigoPromotor + " ";
                SQL += "ORDER BY agenda_apontamentos.inicio DESC";
                dsAgenda.SelectCommand = SQL;
                grvAgenda.DataBind();
            }

            #endregion
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
        public string OpportunityLink(object CodOportunidade)
        {
            //**************
            //* Declarações
            //**************
            string HTML = string.Empty;

            //*******************************
            //* Código de oportunidade nulo?
            //*******************************
            if (CodOportunidade.Equals(null))
                return "<span class=\"BotaoLinkW60F14_OFF\">Abrir</span></a>";

            //*******************************
            //* Código de oportunidade nulo?
            //*******************************
            if (Convert.ToInt32(CodOportunidade).Equals(0))
                return "<span class=\"BotaoLinkW60F14_OFF\">Abrir</span></a>";

            //******************************************************
            //* O operador tem acesso ao cadastro de oportunidades?
            //******************************************************
            if (oSecurity.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade))
            {
                //***************
                //* Devolve link
                //***************
                HTML = "<a href=\"oportunidades_edicao.aspx?Codigo=";
                HTML += Convert.ToInt32(CodOportunidade) + "&back=abertura.aspx";
                HTML += "\" target=\"_self\" style=\"text-decoration: none\">";
                HTML += "<span class=\"BotaoLinkW60F14\">Abrir</span></a>";
            }
            else
            {
                //***********************
                //* Devolve link inativo
                //***********************
                HTML = "<span class=\"BotaoLinkW60F14_OFF\">Abrir</span></a>";
            }
            return HTML;
        }
        protected void cmdExportacaoAgenda_Click(object sender, EventArgs e)
        {
            //****************************
            //* Esconde coluna de comando
            //****************************
            grvAgenda.Columns[0].Visible = false;
            grvAgenda.DataBind();

            //******************
            //* Existe seleção?
            //******************
            if (cboExportacaoAgenda.SelectedIndex > -1)
            {
                //******************************
                //* Realiza exportação da grade
                //******************************
                switch (cboExportacaoAgenda.SelectedItem.Value.ToString())
                {
                    case "PDF":
                        gveAgenda.WritePdfToResponse("Agenda.pdf");
                        break;
                    case "RTF":
                        gveAgenda.WriteRtfToResponse("Agenda.rtf");
                        break;
                    case "CSV":
                        gveAgenda.WriteCsvToResponse("Agenda.csv");
                        break;
                    case "XLS":
                        gveAgenda.WriteXlsToResponse("Agenda.xls");
                        break;
                    case "XLSX":
                        gveAgenda.WriteXlsxToResponse("Agenda.xlsx");
                        break;
                }
            }
        }
        protected void cmdExportacaoOportunidades_Click(object sender, EventArgs e)
        {
            //****************************
            //* Esconde coluna de comando
            //****************************
            grvOportunidades.Columns[0].Visible = false;
            grvOportunidades.DataBind();

            //******************
            //* Existe seleção?
            //******************
            if (cboExportacaoOportunidades.SelectedIndex > -1)
            {
                //******************************
                //* Realiza exportação da grade
                //******************************
                switch (cboExportacaoOportunidades.SelectedItem.Value.ToString())
                {
                    case "PDF":
                        gveOportunidades.WritePdfToResponse("Oportunidades.pdf");
                        break;
                    case "RTF":
                        gveOportunidades.WriteRtfToResponse("Oportunidades.rtf");
                        break;
                    case "CSV":
                        gveOportunidades.WriteCsvToResponse("Oportunidades.csv");
                        break;
                    case "XLS":
                        gveOportunidades.WriteXlsToResponse("Oportunidades.xls");
                        break;
                    case "XLSX":
                        gveOportunidades.WriteXlsxToResponse("Oportunidades.xlsx");
                        break;
                }
            }
        }
    }
}