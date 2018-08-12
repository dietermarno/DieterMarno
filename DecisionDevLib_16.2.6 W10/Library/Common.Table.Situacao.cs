using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Situacao_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_SitCli = 0;
        private string _DescSitCli = string.Empty;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_SitCli { get { return _PK_SitCli; } set { _PK_SitCli = value; } }
        public string DescSitCli { get { return _DescSitCli.Left(30); } set { _DescSitCli = value; } }
        public Situacao_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_SitCli = 0;
	        _DescSitCli = string.Empty;
        }
    }
    public class Situacao_Manager
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
        public Situacao_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Situacao_Fields GetRecord(Int32 SitCli)
        {
            //**************
            //* Declarações
            //**************
            Situacao_Fields oSituacao = new Situacao_Fields();
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
                SQL = "SELECT * FROM situacao WHERE SitCli = " + SitCli;
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
                    oSituacao.PK_SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;
                    oSituacao.DescSitCli = !DBNull.Value.Equals(oRow["DescSitCli"]) ? oRow["DescSitCli"].ToString() : string.Empty;
                }
            }
            else
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = "O resultado da pesquisa retornou nulo";
                _Error = true;
            }

            //****************
            //* Retorna dados
            //****************
            return oSituacao;
        }
        public Int32 ApplyRecord(Situacao_Fields oSituacao, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO situacao (";
            SQL += "SitCli,";
            SQL += "DescSitCli";
            SQL += ") VALUES (";
            SQL += oSituacao.PK_SitCli + ",";
            SQL += "'" + oSituacao.DescSitCli.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oSituacao.PK_SitCli = oDBManager.ExecuteCommand(SQL, Import);

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
            return oSituacao.PK_SitCli;
        }
        public bool DeleteRecord(Situacao_Fields oSituacao)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*********************************
            //* O código da situação é válido?
            //*********************************
            if (oSituacao.PK_SitCli != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM situacao WHERE SitCli = " + oSituacao.PK_SitCli;
                oDBManager.ExecuteCommand(SQL);

                //*****************************
                //* Retorna estado de execução
                //*****************************
                if (!oDBManager.Error)
                {
                    //*************
                    //* Retorna OK
                    //*************
                    _ErrorText = string.Empty;
                    _Error = false;
                    return true;
                }
                else
                {
                    //***************
                    //* Retorna erro
                    //***************
                    _ErrorText = oDBManager.ErrorMessage;
                    _Error = oDBManager.Error;
                    return false;
                }
            }
            else
            {
                //***************
                //* Retorna erro
                //***************
                _ErrorText = "Informe o código da profissão.";
                _Error = true;
                return false;
            }
        }
    }
}
