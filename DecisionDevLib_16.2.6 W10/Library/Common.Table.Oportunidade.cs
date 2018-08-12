using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Oportunidade_Fields
    {
        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_nro_oportunidade = 0;
	    public Int32 cod_promotor = 0;
	    public DateTime? data_operacao = null;
	    public Int16 cod_situacao = 0;
	    public string contato_nome = string.Empty;
	    public string contato_emails = string.Empty;
	    public string contato_telefone = string.Empty;
	    public string destino = string.Empty;
	    public DateTime? data_saida = null;
	    public DateTime? data_retorno = null;
	    public string descricao  = string.Empty;
	    public DateTime? proximo_contato = null;
	    public bool proximo_contato_realizado = false;
	    public double valor_estimado = 0;
	    public Int32 cod_canal_entrada = 0;
	    public string indicado_por = string.Empty;
	    public string quantidade_adultos = string.Empty;
        public string quantidade_criancas = string.Empty;
        public DateTime? data_encerramento = null;
        public double valor_fechado = 0;
	    public string observacoes = string.Empty;
	    public string dados_sacado = string.Empty;
        public string lista_passageiros = string.Empty;
        public Oportunidade_Fields()
        {
            //****************
            //* Inicialização
            //****************
            PK_nro_oportunidade = 0;
	        cod_promotor = 0;
	        data_operacao = null;
	        cod_situacao = 0;
	        contato_nome = string.Empty;
	        contato_emails = string.Empty;
	        contato_telefone = string.Empty;
	        destino = string.Empty;
	        data_saida = null;
	        data_retorno = null;
	        descricao  = string.Empty;
	        proximo_contato = null;
	        proximo_contato_realizado = false;
	        valor_estimado = 0;
	        cod_canal_entrada = 0;
	        indicado_por = string.Empty;
	        quantidade_adultos = string.Empty;
	        quantidade_criancas = string.Empty;
	        valor_fechado = 0;
	        observacoes = string.Empty;
	        dados_sacado = string.Empty;
            lista_passageiros = string.Empty;
        }
    }
    public class Oportunidade_Manager
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
        public Oportunidade_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Oportunidade_Fields GetRecord(Int32 PK_nro_oportunidade)
        {
            //**************
            //* Declarações
            //**************
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();
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
                SQL = "SELECT * FROM oportunidade WHERE nro_oportunidade = " + PK_nro_oportunidade;
                oTable = oDBManager.ExecuteQuery(SQL);

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
                    oOportunidade.PK_nro_oportunidade = !DBNull.Value.Equals(oRow["nro_oportunidade"]) ? Convert.ToInt32("0" + oRow["nro_oportunidade"]) : 0;
                    oOportunidade.cod_promotor = !DBNull.Value.Equals(oRow["cod_promotor"]) ? Convert.ToInt32("0" + oRow["cod_promotor"]) : 0;
                    if (!DBNull.Value.Equals(oRow["data_operacao"])) 
                        oOportunidade.data_operacao = Convert.ToDateTime(oRow["data_operacao"]);
                    oOportunidade.cod_situacao = !DBNull.Value.Equals(oRow["cod_situacao"]) ? Convert.ToInt16("0" + oRow["cod_situacao"]) : (Int16)0;
                    oOportunidade.contato_nome = !DBNull.Value.Equals(oRow["contato_nome"]) ? oRow["contato_nome"].ToString() : string.Empty;
                    oOportunidade.contato_emails = !DBNull.Value.Equals(oRow["contato_emails"]) ? oRow["contato_emails"].ToString() : string.Empty;
                    oOportunidade.contato_telefone = !DBNull.Value.Equals(oRow["contato_telefone"]) ? oRow["contato_telefone"].ToString() : string.Empty;
                    oOportunidade.destino = !DBNull.Value.Equals(oRow["destino"]) ? oRow["destino"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["data_saida"]))
                        oOportunidade.data_saida = Convert.ToDateTime(oRow["data_saida"]);
                    if (!DBNull.Value.Equals(oRow["data_retorno"]))
                        oOportunidade.data_retorno =  Convert.ToDateTime(oRow["data_retorno"]);
                    oOportunidade.descricao = !DBNull.Value.Equals(oRow["descricao"]) ? oRow["descricao"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["proximo_contato"]))
                        oOportunidade.proximo_contato = Convert.ToDateTime(oRow["proximo_contato"]);
                    oOportunidade.proximo_contato_realizado = !DBNull.Value.Equals(oRow["proximo_contato_realizado"]) ? Convert.ToBoolean(oRow["proximo_contato_realizado"]) : false;
                    oOportunidade.valor_estimado = !DBNull.Value.Equals(oRow["valor_estimado"]) ? Convert.ToDouble("0" + oRow["valor_estimado"]) : 0;
                    oOportunidade.cod_canal_entrada = !DBNull.Value.Equals(oRow["cod_canal_entrada"]) ? Convert.ToInt32("0" + oRow["cod_canal_entrada"]) : 0;
                    oOportunidade.indicado_por = !DBNull.Value.Equals(oRow["indicado_por"]) ? oRow["indicado_por"].ToString() : string.Empty;
                    oOportunidade.quantidade_adultos = !DBNull.Value.Equals(oRow["quantidade_adultos"]) ? oRow["quantidade_adultos"].ToString() : string.Empty;
                    oOportunidade.quantidade_criancas = !DBNull.Value.Equals(oRow["quantidade_criancas"]) ? oRow["quantidade_criancas"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["data_encerramento"]))
                        oOportunidade.data_encerramento = Convert.ToDateTime(oRow["data_encerramento"]);
                    oOportunidade.valor_fechado = !DBNull.Value.Equals(oRow["valor_fechado"]) ? Convert.ToDouble("0" + oRow["valor_fechado"]) : 0;
                    oOportunidade.observacoes = !DBNull.Value.Equals(oRow["observacoes"]) ? oRow["observacoes"].ToString() : string.Empty;
                    oOportunidade.dados_sacado = !DBNull.Value.Equals(oRow["dados_sacado"]) ? oRow["dados_sacado"].ToString() : string.Empty;
                    oOportunidade.lista_passageiros = !DBNull.Value.Equals(oRow["lista_passageiros"]) ? oRow["lista_passageiros"].ToString() : string.Empty;
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
            return oOportunidade;
        }
        public Int32 ApplyRecord(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //***************************
            //* Inserção ou atualização?
            //***************************
            if (oOportunidade.PK_nro_oportunidade == 0)
            {
                //****************
                //* Cria registro
                //****************
                SQL = "INSERT INTO oportunidade (";
                SQL += "nro_oportunidade,";
                SQL += "cod_promotor,";
                SQL += "data_operacao,";
                SQL += "cod_situacao,";
                SQL += "contato_nome,";
                SQL += "contato_emails,";
                SQL += "contato_telefone,";
                SQL += "destino,";
                SQL += "data_saida,";
                SQL += "data_retorno,";
                SQL += "descricao,";
                SQL += "proximo_contato,";
                SQL += "proximo_contato_realizado,";
                SQL += "valor_estimado,";
                SQL += "cod_canal_entrada,";
                SQL += "indicado_por,";
                SQL += "quantidade_adultos,";
                SQL += "quantidade_criancas,";
                SQL += "data_encerramento,";
                SQL += "valor_fechado,";
                SQL += "observacoes,";
                SQL += "dados_sacado,";
                SQL += "lista_passageiros";
                SQL += ") VALUES (";
                SQL += oOportunidade.PK_nro_oportunidade.ToString() + ",";
                SQL += oOportunidade.cod_promotor.ToString() + ",";
                if (oOportunidade.data_operacao == null)
                    SQL +=  "null,";
                else
                    SQL += "'" + oOportunidade.data_operacao.Value.ToString("yyyy-MM-dd") + "',";
                SQL += oOportunidade.cod_situacao.ToString() + ",";
                SQL += "'" + oOportunidade.contato_nome.SQLFilter() + "',";
                SQL += "'" + oOportunidade.contato_emails.SQLFilter() + "',";
                SQL += "'" + oOportunidade.contato_telefone.SQLFilter() + "',";
                SQL += "'" + oOportunidade.destino.SQLFilter() + "',";
                if (oOportunidade.data_saida == null)
                    SQL += "null,";
                else
                    SQL += "'" + oOportunidade.data_saida.Value.ToString("yyyy-MM-dd") + "',";
                if (oOportunidade.data_retorno == null)
                    SQL += "null,";
                else
                    SQL += "'" + oOportunidade.data_retorno.Value.ToString("yyyy-MM-dd") + "',";
                SQL += "'" + oOportunidade.descricao.SQLFilter() + "',";
                if (oOportunidade.proximo_contato == null)
                    SQL +=  "null,";
                else
                    SQL += "'" + oOportunidade.proximo_contato.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += oOportunidade.proximo_contato_realizado.ToString() + ",";
                SQL += oOportunidade.valor_estimado.ToString().ToDBCurrency() + ",";
                SQL += oOportunidade.cod_canal_entrada.ToString() + ",";
                SQL += "'" + oOportunidade.indicado_por.SQLFilter() + "',";
                SQL += "'" + oOportunidade.quantidade_adultos.ToString() + "',";
                SQL += "'" + oOportunidade.quantidade_criancas.ToString() + "',";
                if (oOportunidade.data_encerramento == null)
                    SQL += "null,";
                else
                    SQL += "'" + oOportunidade.data_encerramento.Value.ToString("yyyy-MM-dd") + "',";
                SQL += oOportunidade.valor_fechado.ToString().ToDBCurrency() + ",";
                SQL += "'" + oOportunidade.observacoes.SQLFilter() + "',";
                SQL += "'" + oOportunidade.dados_sacado.SQLFilter() + "',";
                SQL += "'" + oOportunidade.lista_passageiros.SQLFilter() + "')";
            }
            else
            {
                //********************
                //* Atualiza registro
                //********************
                SQL = "UPDATE oportunidade SET ";
                SQL += "nro_oportunidade = " + oOportunidade.PK_nro_oportunidade.ToString() + ",";
                SQL += "cod_promotor = " + oOportunidade.cod_promotor.ToString() + ",";
                if (oOportunidade.data_operacao == null)
                    SQL += "data_operacao = null,";
                else
                    SQL += "data_operacao = '" + oOportunidade.data_operacao.Value.ToString("yyyy-MM-dd") + "',";
                SQL += "cod_situacao = " + oOportunidade.cod_situacao.ToString() + ",";
                SQL += "contato_nome = '" + oOportunidade.contato_nome.SQLFilter() + "',";
                SQL += "contato_emails = '" + oOportunidade.contato_emails.SQLFilter() + "',";
                SQL += "contato_telefone = '" + oOportunidade.contato_telefone.SQLFilter() + "',";
                SQL += "destino = '" + oOportunidade.destino.SQLFilter() + "',";
                if (oOportunidade.data_saida == null)
                    SQL += "data_saida = null,";
                else
                    SQL += "data_saida = '" + oOportunidade.data_saida.Value.ToString("yyyy-MM-dd") + "',";
                if (oOportunidade.data_retorno == null)
                    SQL += "data_retorno = null,";
                else
                    SQL += "data_retorno = '" + oOportunidade.data_retorno.Value.ToString("yyyy-MM-dd") + "',";
                SQL += "descricao = '" + oOportunidade.descricao.SQLFilter() + "',";
                if (oOportunidade.proximo_contato == null)
                    SQL += "proximo_contato = null,";
                else
                    SQL += "proximo_contato = '" + oOportunidade.proximo_contato.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "proximo_contato_realizado = " + oOportunidade.proximo_contato_realizado.ToString() + ",";
                SQL += "valor_estimado = " + oOportunidade.valor_estimado.ToString().ToDBCurrency() + ",";
                SQL += "cod_canal_entrada = " + oOportunidade.cod_canal_entrada.ToString() + ",";
                SQL += "indicado_por = '" + oOportunidade.indicado_por.SQLFilter() + "',";
                SQL += "quantidade_adultos = '" + oOportunidade.quantidade_adultos.ToString() + "',";
                SQL += "quantidade_criancas = '" + oOportunidade.quantidade_criancas.ToString() + "',";
                if (oOportunidade.data_encerramento == null)
                    SQL += "data_encerramento = null,";
                else
                    SQL += "data_encerramento = '" + oOportunidade.data_encerramento.Value.ToString("yyyy-MM-dd") + "',";
                SQL += "valor_fechado = " + oOportunidade.valor_fechado.ToString().ToDBCurrency() + ",";
                SQL += "observacoes = '" + oOportunidade.observacoes.SQLFilter() + "',";
                SQL += "dados_sacado = '" + oOportunidade.dados_sacado.SQLFilter() + "',";
                SQL += "lista_passageiros = '" + oOportunidade.lista_passageiros.SQLFilter() + "' ";
                SQL += "WHERE nro_oportunidade = " + oOportunidade.PK_nro_oportunidade;
            }

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                if (oOportunidade.PK_nro_oportunidade == 0)
                    oOportunidade.PK_nro_oportunidade = oDBManager.ExecuteCommand(SQL);
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
            return oOportunidade.PK_nro_oportunidade;
        }
        public bool UpdateClosing(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*************************************
            //* O código da oportunidade é válido?
            //*************************************
            if (oOportunidade.PK_nro_oportunidade != 0)
            {
                //********************************
                //* Define comando de atualização
                //********************************
                SQL = "UPDATE oportunidade SET ";
                SQL += "cod_situacao = 0" + oOportunidade.cod_situacao + ",";
                if (oOportunidade.proximo_contato != null)
                    SQL += "proximo_contato = '" + oOportunidade.proximo_contato.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                else
                    SQL += "proximo_contato = null,";
                SQL += "valor_fechado = 0" + oOportunidade.valor_fechado.ToString().ToDBCurrency() + ",";
                SQL += "observacoes = '" + oOportunidade.observacoes.SQLFilter() + "',";
                SQL += "dados_sacado = '" + oOportunidade.dados_sacado.SQLFilter() + "',";
                SQL += "lista_passageiros = '" + oOportunidade.lista_passageiros.SQLFilter() + "',";
                if (oOportunidade.data_encerramento != null)
                    SQL += "data_encerramento = '" + oOportunidade.data_encerramento.Value.ToString("yyyy-MM-dd") + "' ";
                else
                    SQL += "data_encerramento = null ";
                SQL += "WHERE nro_oportunidade = 0" +  oOportunidade.PK_nro_oportunidade;

                //*************************************
                //* O código da oportunidade é válido?
                //*************************************
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //*****************************
                //* Retorna estado de execução
                //*****************************
                if (!oDBManager.Error)
                    return true;
                else
                    return false;
            }
            else
            {
                //*****************************
                //* Retorna estado de execução
                //*****************************
                return false;
            }
        }
        public bool UpdateStage2(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*************************************
            //* O código da oportunidade é válido?
            //*************************************
            if (oOportunidade.PK_nro_oportunidade != 0)
            {
                //********************************
                //* Define comando de atualização
                //********************************
                SQL = "UPDATE oportunidade SET ";
                SQL += "cod_situacao = 0" + oOportunidade.cod_situacao + ",";
                if (oOportunidade.proximo_contato != null)
                    SQL += "proximo_contato = '" + oOportunidade.proximo_contato.Value.ToString("yyyy-MM-dd HH:mm") + "' ";
                else
                    SQL += "proximo_contato = null ";
                SQL += "WHERE nro_oportunidade = 0" + oOportunidade.PK_nro_oportunidade;

                //*************************************
                //* O código da oportunidade é válido?
                //*************************************
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //*****************************
                //* Retorna estado de execução
                //*****************************
                if (!oDBManager.Error)
                    return true;
                else
                    return false;
            }
            else
            {
                //*****************************
                //* Retorna estado de execução
                //*****************************
                return false;
            }
        }
        public bool DeleteRecord(Oportunidade_Fields oOportunidade)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*************************************
            //* O código da oportunidade é válido?
            //*************************************
            if (oOportunidade.PK_nro_oportunidade != 0)
            {
                //************************************************
                //* Exclui orçamentos relacionados à oportunidade
                //************************************************
                SQL = "DELETE FROM oportunidade_orcamentos WHERE nro_oportunidade = " + oOportunidade.PK_nro_oportunidade;
                oDBManager.ExecuteCommand(SQL);

                //**********************
                //* Exclui oportunidade
                //**********************
                SQL = "DELETE FROM oportunidade WHERE nro_oportunidade = " + oOportunidade.PK_nro_oportunidade;
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //*****************************
                //* Retorna estado de execução
                //*****************************
                if (!oDBManager.Error)
                    return true;
                else
                    return false;
            }
            else
            {
                //*****************************
                //* Retorna estado de execução
                //*****************************
                return false;
            }
        }
    }
}
