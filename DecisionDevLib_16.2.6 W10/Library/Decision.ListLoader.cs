using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using DevExpress.Web;

using Decision.Extensions;
using Decision.Lists;
using Decision.Database;
using Decision.TableManager;

namespace Decision.Lists
{
    public static class ListLoader
    {
        public static void Popula_CBO_OrcamentoSituacao(ASPxComboBox oCombo)
        {
            //********************************
            //* Insere situações do orçamento
            //********************************
            foreach (OptionLists.OportunidadeStuacao oOpcao in Enum.GetValues(typeof(OptionLists.OportunidadeStuacao)))
                oCombo.Items.Add(new ListEditItem(oOpcao.GetDescription(),(int)oOpcao));
        }
        public static void Popula_CBO_CanalEntrada(ASPxComboBox oCombo)
        {
            //***************************
            //* Insere canais de entrada
            //***************************
            foreach (OptionLists.OportunidadeCanalEntrada oOpcao in Enum.GetValues(typeof(OptionLists.OportunidadeCanalEntrada)))
                oCombo.Items.Add(new ListEditItem(oOpcao.GetDescription(), (int)oOpcao));
        }
        public static void Popula_CBO_EstagioOrcamento(ASPxComboBox oCombo)
        {
            //******************************
            //* Insere estágio do orçamento
            //******************************
            foreach (OptionLists.OrcamentoEstagio oOpcao in Enum.GetValues(typeof(OptionLists.OrcamentoEstagio)))
                oCombo.Items.Add(new ListEditItem(oOpcao.GetDescription(), (int)oOpcao));
        }
        public static void Popula_CBO_Atendentes(ASPxComboBox oCombo, object SessionLoginInfo)
        {
            //**************
            //* Declarações
            //**************
            List<Promotor_Fields> oPromotorData = new List<Promotor_Fields>();
            Promotor_Manager oPromotorManager = new Promotor_Manager(DBConnection.GetConnectionFromSession(SessionLoginInfo));

            //****************************
            //* Obtem lista de promotores
            //****************************
            oPromotorData = oPromotorManager.Get_NomePromotor_Like(string.Empty);

            //************************
            //* Insere ítens na lista
            //************************
            if (!oPromotorManager.Error)
                foreach (Promotor_Fields oPromotor in oPromotorData)
                    oCombo.Items.Add(oPromotor.NomePromotor, oPromotor.PK_CodPromotor);
        }
        public static void Popula_LST_Orcamentos(ASPxListBox oList, Int32 Nro_Oportunidade, object SessionLoginInfo)
        {
            //**************
            //* Declarações
            //**************
            List<Oportunidade_Orcamentos_Fields> oOrcamentos = new List<Oportunidade_Orcamentos_Fields>();
            Oportunidade_Orcamentos_Manager oOportunidadeOrcamentosManager = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(SessionLoginInfo));
            string ItemText = string.Empty;

            //********************************************
            //* Obtem lista de orçamentos da oportunidade
            //********************************************
            oOrcamentos = oOportunidadeOrcamentosManager.GetRecords(Nro_Oportunidade);

            //************************
            //* Insere ítens na lista
            //************************
            if (!oOportunidadeOrcamentosManager.Error)
            {
                foreach (Oportunidade_Orcamentos_Fields oOrcamento in oOrcamentos)
                {
                    if (oOrcamento.data_orcamento != null)
                    {
                        ItemText = "N° " + oOrcamento.PK_cod_orcamento;
                        ItemText += " - " + ObtemEstagioOrcamento(oOrcamento.estagio_orcamento);
                        ItemText += " (" + oOrcamento.data_orcamento.Value.ToString("dd/MM/yyyy") + ")";
                        oList.Items.Add(ItemText, oOrcamento.PK_cod_orcamento);
                    }
                }
            }
        }
        public static string ObtemEstagioOrcamento(Int16 CodEstagioOrcamento)
        {
            //**************
            //* Declarações
            //**************
            string EstagioOrcamento = string.Empty;

            //********************************************
            //* Retorna descrição do estágio do orçamento
            //********************************************
            switch (CodEstagioOrcamento)
            {
                case (int)Lists.OptionLists.OrcamentoEstagio.Cotacao:
                    EstagioOrcamento = Lists.OptionLists.OrcamentoEstagio.Cotacao.GetDescription();
                    break;
                case (int)Lists.OptionLists.OrcamentoEstagio.Aceito:
                    EstagioOrcamento = Lists.OptionLists.OrcamentoEstagio.Aceito.GetDescription();
                    break;
                case (int)Lists.OptionLists.OrcamentoEstagio.Enviado:
                    EstagioOrcamento = Lists.OptionLists.OrcamentoEstagio.Enviado.GetDescription();
                    break;
                case (int)Lists.OptionLists.OrcamentoEstagio.Recusado:
                    EstagioOrcamento = Lists.OptionLists.OrcamentoEstagio.Recusado.GetDescription();
                    break;
            }

            //*******************************
            //* Devolve descrição do estágio
            //*******************************
            return EstagioOrcamento;
        }
    }
}