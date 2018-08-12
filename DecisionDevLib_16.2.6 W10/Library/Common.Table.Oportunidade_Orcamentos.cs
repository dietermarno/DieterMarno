using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Oportunidade_Orcamentos_Fields
    {
        //*******************
        //* Campos da tabela
        //*******************
	    public Int32 PK_cod_orcamento = 0;
	    public Int32 nro_oportunidade = 0;
	    public DateTime? data_orcamento = null;
	    public DateTime? proximo_contato = null;
        public string produto = string.Empty;
        public string assunto = string.Empty;
        public double valor = 0;
        public string html_orcamento = string.Empty;
	    public string html_resposta = string.Empty;
        public string html_interno = string.Empty;
        public Int16 estagio_orcamento = 0;
        public bool pendencia = false;
        
        public Oportunidade_Orcamentos_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        PK_cod_orcamento = 0;
	        nro_oportunidade = 0;
	        data_orcamento = null;
	        proximo_contato = null;
            produto = string.Empty;
            assunto = string.Empty;
            valor = 0;
	        html_orcamento = string.Empty;
	        html_resposta = string.Empty;
            estagio_orcamento = 0;
            pendencia = false;
        }
    }
    public class Oportunidade_Orcamentos_Manager
    {
        //***************
        //* Propriedades
        //***************
        private bool _Error = false;
        private string _ErrorText = string.Empty;
        private string _ConnectionString;
        public bool Error { get { return _Error; } }
        public string ErrorText { get { return _ErrorText; } }
        public string ConnectionString { get { return _ConnectionString; } }
        public Oportunidade_Orcamentos_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Oportunidade_Orcamentos_Fields GetRecord(Int32 PK_cod_orcamento)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //*****************
                //* Obtem registro
                //*****************
                SQL = "SELECT * FROM oportunidade_orcamentos WHERE cod_orcamento = " + PK_cod_orcamento;
                oTable = oDBManager.ExecuteQuery(SQL);
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*********************************
            //* A pesquisa retornou registros?
            //*********************************
            if (oTable != null)
            {
                //***********************************
                //* A pesquisa localizou o registro?
                //***********************************
                if (oTable.Rows.Count == 1)
                {
                    //*******************************
                    //* Copia dados para a estrutura
                    //*******************************
                    DataRow oRow = oTable.Rows[0];
                    oOrcamento.PK_cod_orcamento = !DBNull.Value.Equals(oRow["cod_orcamento"]) ? Convert.ToInt32("0" + oRow["cod_orcamento"]) : 0;
                    oOrcamento.nro_oportunidade = !DBNull.Value.Equals(oRow["nro_oportunidade"]) ? Convert.ToInt32("0" + oRow["nro_oportunidade"]) : 0;
                    if (!DBNull.Value.Equals(oRow["data_orcamento"]))
                        oOrcamento.data_orcamento = Convert.ToDateTime(oRow["data_orcamento"]);
                    if (!DBNull.Value.Equals(oRow["proximo_contato"]))
                        oOrcamento.proximo_contato = Convert.ToDateTime(oRow["proximo_contato"]);
                    oOrcamento.produto = !DBNull.Value.Equals(oRow["produto"]) ? oRow["produto"].ToString() : string.Empty;
                    oOrcamento.assunto = !DBNull.Value.Equals(oRow["assunto"]) ? oRow["assunto"].ToString() : string.Empty;
                    oOrcamento.valor = !DBNull.Value.Equals(oRow["valor"]) ? Convert.ToDouble("0" + oRow["valor"]) : (double)0;
                    oOrcamento.html_orcamento = !DBNull.Value.Equals(oRow["html_orcamento"]) ? oRow["html_orcamento"].ToString() : string.Empty;
                    oOrcamento.html_resposta = !DBNull.Value.Equals(oRow["html_resposta"]) ? oRow["html_resposta"].ToString() : string.Empty;
                    oOrcamento.html_interno = !DBNull.Value.Equals(oRow["html_interno"]) ? oRow["html_interno"].ToString() : string.Empty;
                    oOrcamento.estagio_orcamento = !DBNull.Value.Equals(oRow["estagio_orcamento"]) ? Convert.ToInt16("0" + oRow["estagio_orcamento"]) : (Int16)0;
                    oOrcamento.pendencia = !DBNull.Value.Equals(oRow["pendencia"]) ? Convert.ToBoolean(oRow["pendencia"]) : false;
                }
            }
            else
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = "O Resultado da pesquisa retornou nulo";
                _Error = true;
            }

            //****************
            //* Retorna dados
            //****************
            return oOrcamento;
        }
        public Oportunidade_Orcamentos_Fields GetAcceptedBudget(Int32 nro_oportunidade)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //*****************
                //* Obtem registro
                //*****************
                SQL = "SELECT * FROM oportunidade_orcamentos WHERE ";
                SQL += "nro_oportunidade = " + nro_oportunidade + " AND ";
                SQL += "estagio_orcamento = " + (int)Lists.OptionLists.OrcamentoEstagio.Aceito;
                oTable = oDBManager.ExecuteQuery(SQL);
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*********************************
            //* A pesquisa retornou registros?
            //*********************************
            if (oTable != null)
            {
                //***********************************
                //* A pesquisa localizou o registro?
                //***********************************
                if (oTable.Rows.Count == 1)
                {
                    //*******************************
                    //* Copia dados para a estrutura
                    //*******************************
                    DataRow oRow = oTable.Rows[0];
                    oOrcamento.PK_cod_orcamento = !DBNull.Value.Equals(oRow["cod_orcamento"]) ? Convert.ToInt32("0" + oRow["cod_orcamento"]) : 0;
                    oOrcamento.nro_oportunidade = !DBNull.Value.Equals(oRow["nro_oportunidade"]) ? Convert.ToInt32("0" + oRow["nro_oportunidade"]) : 0;
                    if (!DBNull.Value.Equals(oRow["data_orcamento"]))
                        oOrcamento.data_orcamento = Convert.ToDateTime(oRow["data_orcamento"]);
                    if (!DBNull.Value.Equals(oRow["proximo_contato"]))
                        oOrcamento.proximo_contato = Convert.ToDateTime(oRow["proximo_contato"]);
                    oOrcamento.produto = !DBNull.Value.Equals(oRow["produto"]) ? oRow["produto"].ToString() : string.Empty;
                    oOrcamento.assunto = !DBNull.Value.Equals(oRow["assunto"]) ? oRow["assunto"].ToString() : string.Empty;
                    oOrcamento.valor = !DBNull.Value.Equals(oRow["valor"]) ? Convert.ToDouble("0" + oRow["valor"]) : (double)0;
                    oOrcamento.html_orcamento = !DBNull.Value.Equals(oRow["html_orcamento"]) ? oRow["html_orcamento"].ToString() : string.Empty;
                    oOrcamento.html_resposta = !DBNull.Value.Equals(oRow["html_resposta"]) ? oRow["html_resposta"].ToString() : string.Empty;
                    oOrcamento.html_interno = !DBNull.Value.Equals(oRow["html_interno"]) ? oRow["html_interno"].ToString() : string.Empty;
                    oOrcamento.estagio_orcamento = !DBNull.Value.Equals(oRow["estagio_orcamento"]) ? Convert.ToInt16("0" + oRow["estagio_orcamento"]) : (Int16)0;
                    oOrcamento.pendencia = !DBNull.Value.Equals(oRow["pendencia"]) ? Convert.ToBoolean(oRow["pendencia"]) : false;
                }
                else
                {
                    //*************************
                    //* Devole estrutura vazia
                    //*************************
                    oOrcamento.PK_cod_orcamento = 0;
                    oOrcamento.nro_oportunidade = nro_oportunidade;
                    oOrcamento.data_orcamento = null;
                    oOrcamento.proximo_contato = null;
                    oOrcamento.produto = string.Empty;
                    oOrcamento.assunto = string.Empty;
                    oOrcamento.valor = 0;
                    oOrcamento.html_orcamento = string.Empty;
                    oOrcamento.html_resposta = string.Empty;
                    oOrcamento.html_interno = string.Empty;
                    oOrcamento.estagio_orcamento = 0;
                    oOrcamento.pendencia = false;
                }
            }
            else
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = "O Resultado da pesquisa retornou nulo";
                _Error = true;
            }

            //****************
            //* Retorna dados
            //****************
            return oOrcamento;
        }
        public List<Oportunidade_Orcamentos_Fields> GetRecords(Int32 nro_oportunidade)
        {
            //**************
            //* Declarações
            //**************
            List<Oportunidade_Orcamentos_Fields> oOrcamentos = new List<Oportunidade_Orcamentos_Fields>();
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //******************
                //* Obtem registros
                //******************
                SQL = "SELECT * FROM oportunidade_orcamentos ";
                SQL += "WHERE nro_oportunidade = " + nro_oportunidade + " ORDER BY cod_orcamento DESC";
                oTable = oDBManager.ExecuteQuery(SQL);
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*********************************
            //* A pesquisa retornou registros?
            //*********************************
            if (oTable != null)
            {
                //***********************************
                //* A pesquisa localizou o registro?
                //***********************************
                foreach (DataRow oRow in oTable.Rows)
                {
                    //*******************************
                    //* Copia dados para a estrutura
                    //*******************************
                    oOrcamento = new Oportunidade_Orcamentos_Fields();
                    oOrcamento.PK_cod_orcamento = !DBNull.Value.Equals(oRow["cod_orcamento"]) ? Convert.ToInt32("0" + oRow["cod_orcamento"]) : 0;
                    oOrcamento.nro_oportunidade = !DBNull.Value.Equals(oRow["nro_oportunidade"]) ? Convert.ToInt32("0" + oRow["nro_oportunidade"]) : 0;
                    if (!DBNull.Value.Equals(oRow["data_orcamento"]))
                        oOrcamento.data_orcamento = Convert.ToDateTime(oRow["data_orcamento"]);
                    if (!DBNull.Value.Equals(oRow["proximo_contato"]))
                        oOrcamento.proximo_contato = Convert.ToDateTime(oRow["proximo_contato"]);
                    oOrcamento.produto = !DBNull.Value.Equals(oRow["produto"]) ? oRow["produto"].ToString() : string.Empty;
                    oOrcamento.assunto = !DBNull.Value.Equals(oRow["assunto"]) ? oRow["assunto"].ToString() : string.Empty;
                    oOrcamento.valor = !DBNull.Value.Equals(oRow["valor"]) ? Convert.ToDouble("0" + oRow["valor"]) : (double)0;
                    oOrcamento.html_orcamento = !DBNull.Value.Equals(oRow["html_orcamento"]) ? oRow["html_orcamento"].ToString() : string.Empty;
                    oOrcamento.html_resposta = !DBNull.Value.Equals(oRow["html_resposta"]) ? oRow["html_resposta"].ToString() : string.Empty;
                    oOrcamento.html_interno = !DBNull.Value.Equals(oRow["html_interno"]) ? oRow["html_interno"].ToString() : string.Empty;
                    oOrcamento.estagio_orcamento = !DBNull.Value.Equals(oRow["estagio_orcamento"]) ? Convert.ToInt16("0" + oRow["estagio_orcamento"]) : (Int16)0;
                    oOrcamento.pendencia = !DBNull.Value.Equals(oRow["pendencia"]) ? Convert.ToBoolean(oRow["pendencia"]) : false;
                    oOrcamentos.Add(oOrcamento);
                }
            }
            else
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = "O Resultado da pesquisa retornou nulo";
                _Error = true;
            }

            //********************
            //* Retorna registros
            //********************
            return oOrcamentos;
        }
        public bool DeleteRecord(Int32 PK_cod_orcamento)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //**************************
            //* O código foi fornecido?
            //**************************
            if (PK_cod_orcamento != 0)
            {
                try 
                {
                    //******************
                    //* Remove registro
                    //******************
                    SQL = "DELETE FROM oportunidade_orcamentos WHERE ";
                    SQL += "oportunidade_orcamentos.cod_orcamento = 0" + PK_cod_orcamento;
                    oDBManager.ExecuteCommand(SQL);

                    //************************************
                    //* Devolve status e mensagem de erro
                    //************************************
                    _ErrorText = oDBManager.ErrorMessage;
                    _Error = oDBManager.Error;

                    //***********************
                    //* Excluído com sucesso
                    //***********************
                    if (!oDBManager.Error)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    //*******************
                    //* Erro no processo
                    //*******************
                    return false;
                }
            }
            else
            {
                //***********************
                //* Código não fornecido
                //***********************
                return false;
            }
        }
        public Int32 ApplyRecord(Oportunidade_Orcamentos_Fields oOrcamento)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //***************************
            //* Inserção ou atualização?
            //***************************
            if (oOrcamento.PK_cod_orcamento == 0)
            {
                //****************
                //* Cria registro
                //****************
                SQL = "INSERT INTO oportunidade_orcamentos (";
                SQL += "cod_orcamento,";
                SQL += "nro_oportunidade,";
                SQL += "data_orcamento,";
                SQL += "proximo_contato,";
                SQL += "produto,";
                SQL += "assunto,";
                SQL += "valor,";
                SQL += "html_orcamento,";
                SQL += "html_resposta,";
                SQL += "html_interno,";
                SQL += "estagio_orcamento,";
                SQL += "pendencia";
                SQL += ") VALUES (";
                SQL += oOrcamento.PK_cod_orcamento.ToString() + ",";
                SQL += oOrcamento.nro_oportunidade.ToString() + ",";
                SQL += DBNull.Value.Equals(oOrcamento.data_orcamento) ? "null," : "'" + oOrcamento.data_orcamento.Value.ToString("yyyy-MM-dd") + "',";
                SQL += DBNull.Value.Equals(oOrcamento.proximo_contato) ? "null," : "'" + oOrcamento.proximo_contato.Value.ToString("yyyy-MM-dd") + "',";
                SQL += "'" + oOrcamento.produto.SQLFilter() + "',";
                SQL += "'" + oOrcamento.assunto.SQLFilter() + "',";
                SQL += oOrcamento.valor.ToString().ToDBCurrency() + ",";
                SQL += "'" + oOrcamento.html_orcamento.SQLFilter() + "',";
                SQL += "'" + oOrcamento.html_resposta.SQLFilter() + "',";
                SQL += "'" + oOrcamento.html_interno.SQLFilter() + "',";
                SQL += "'" + oOrcamento.estagio_orcamento.ToString() + "',";
                SQL += oOrcamento.pendencia.ToString() + ")";
            }
            else
            {
                //********************
                //* Atualiza registro
                //********************
                SQL = "UPDATE oportunidade_orcamentos SET ";
                SQL += "cod_orcamento = " + oOrcamento.PK_cod_orcamento.ToString() + ",";
                SQL += "nro_oportunidade = " + oOrcamento.nro_oportunidade.ToString() + ",";
                SQL += "data_orcamento = " + (DBNull.Value.Equals(oOrcamento.data_orcamento) ? "null," : "'" + oOrcamento.data_orcamento.Value.ToString("yyyy-MM-dd") + "',");
                SQL += "proximo_contato = " + (DBNull.Value.Equals(oOrcamento.proximo_contato) ? "null," : "'" + oOrcamento.proximo_contato.Value.ToString("yyyy-MM-dd") + "',");
                SQL += "produto = '" + oOrcamento.produto.SQLFilter() + "',";
                SQL += "assunto = '" + oOrcamento.assunto.SQLFilter() + "',";
                SQL += "valor = " + oOrcamento.valor.ToString().ToDBCurrency() + ",";
                SQL += "html_orcamento = '" + oOrcamento.html_orcamento.SQLFilter() + "',";
                SQL += "html_resposta = '" + oOrcamento.html_resposta.SQLFilter() + "',";
                SQL += "html_interno = '" + oOrcamento.html_interno.SQLFilter() + "',";
                SQL += "estagio_orcamento = " + oOrcamento.estagio_orcamento.ToString() + ",";
                SQL += "pendencia = " + oOrcamento.pendencia.ToString() + " ";
                SQL += "WHERE cod_orcamento = " + oOrcamento.PK_cod_orcamento;
            }

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                if (oOrcamento.PK_cod_orcamento == 0)
                    oOrcamento.PK_cod_orcamento = oDBManager.ExecuteCommand(SQL);
                else
                    oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //*************************
            //* Retorna chave primária
            //*************************
            return oOrcamento.PK_cod_orcamento;
        }
        public bool UpdateBudgetAnswer(Oportunidade_Orcamentos_Fields oOrcamento)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTableOrcamento = new DataTable();
            string SQL = string.Empty;

            //**************************************************
            //* Atualiza status e texto da reposta do orçamento
            //**************************************************
            SQL = "UPDATE oportunidade_orcamentos SET ";
            SQL += "html_resposta = '" + oOrcamento.html_resposta.SQLFilter() + "' ";
            SQL += "WHERE cod_orcamento = " + oOrcamento.PK_cod_orcamento;
            oDBManager.ExecuteCommand(SQL);

            //************************************
            //* Devolve status e mensagem de erro
            //************************************
            _ErrorText = oDBManager.ErrorMessage;
            _Error = oDBManager.Error;

            //********************************
            //* Atualização foi bem sucedida?
            //********************************
            if (oDBManager.Error)
                return false;
            else
                return true;
        }
        public bool UpdateInternalNotes(Oportunidade_Orcamentos_Fields oOrcamento)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTableOrcamento = new DataTable();
            string SQL = string.Empty;

            //**************************************************
            //* Atualiza status e texto da reposta do orçamento
            //**************************************************
            SQL = "UPDATE oportunidade_orcamentos SET ";
            SQL += "html_interno = '" + oOrcamento.html_interno.SQLFilter() + "' ";
            SQL += "WHERE cod_orcamento = " + oOrcamento.PK_cod_orcamento;
            oDBManager.ExecuteCommand(SQL);

            //************************************
            //* Devolve status e mensagem de erro
            //************************************
            _ErrorText = oDBManager.ErrorMessage;
            _Error = oDBManager.Error;

            //********************************
            //* Atualização foi bem sucedida?
            //********************************
            if (oDBManager.Error)
                return false;
            else
                return true;
        }
    }
}
