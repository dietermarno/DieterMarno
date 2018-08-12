using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Profissao_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodProf = 0;
        private string _Descricao = string.Empty;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_CodProf { get { return _PK_CodProf; } set { _PK_CodProf = value; } }
        public string Descricao { get { return _Descricao.Left(30); } set { _Descricao = value; } }
        public Profissao_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_CodProf = 0;
	        _Descricao = string.Empty;
        }
    }
    public class Profissao_Manager
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
        public Profissao_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Profissao_Fields GetRecord(Int32 CodProf)
        {
            //**************
            //* Declarações
            //**************
            Profissao_Fields oProfissao = new Profissao_Fields();
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
                SQL = "SELECT * FROM profissao WHERE CodProf = " + CodProf;
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
                    oProfissao.PK_CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;
                    oProfissao.Descricao = !DBNull.Value.Equals(oRow["Descricao"]) ? oRow["Descricao"].ToString() : string.Empty;
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
            return oProfissao;
        }
        public Int32 ApplyRecord(Profissao_Fields oProfissao, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO profissao (";
            SQL += "CodProf,";
            SQL += "Descricao";
            SQL += ") VALUES (";
            SQL += oProfissao.PK_CodProf + ",";
            SQL += "'" + oProfissao.Descricao.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oProfissao.PK_CodProf = oDBManager.ExecuteCommand(SQL, Import);

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
            return oProfissao.PK_CodProf;
        }
        public bool DeleteRecord(Profissao_Fields oProfissao)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //**********************************
            //* O código da profissão é válido?
            //**********************************
            if (oProfissao.PK_CodProf != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM classifica WHERE TipoCli = " + oProfissao.PK_CodProf;
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
