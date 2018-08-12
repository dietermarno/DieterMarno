using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Classifica_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_TipoCli = 0;
        private string _DescTipoCli = string.Empty;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_TipoCli { get { return _PK_TipoCli; } set { _PK_TipoCli = value; } }
        public string DescTipoCli { get { return _DescTipoCli.Left(30); } set { _DescTipoCli = value; } }
        public Classifica_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_TipoCli = 0;
	        _DescTipoCli = string.Empty;
        }
    }
    public class Classifica_Manager
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
        public Classifica_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Classifica_Fields GetRecord(Int32 TipoCli)
        {
            //**************
            //* Declarações
            //**************
            Classifica_Fields oClassifica = new Classifica_Fields();
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
                SQL = "SELECT * FROM classifica WHERE TipoCli = " + TipoCli;
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
                    oClassifica.PK_TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;
                    oClassifica.DescTipoCli = !DBNull.Value.Equals(oRow["DescTipoCli"]) ? oRow["DescTipoCli"].ToString() : string.Empty;
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
            return oClassifica;
        }
        public Int32 ApplyRecord(Classifica_Fields oClassifica, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO classifica (";
            SQL += "TipoCli,";
            SQL += "DescTipoCli";
            SQL += ") VALUES (";
            SQL += oClassifica.PK_TipoCli + ",";
            SQL += "'" + oClassifica.DescTipoCli.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oClassifica.PK_TipoCli = oDBManager.ExecuteCommand(SQL, Import);

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
            return oClassifica.PK_TipoCli;
        }
        public bool DeleteRecord(Classifica_Fields oClassifica)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //**************************************
            //* O código da classificação é válido?
            //**************************************
            if (oClassifica.PK_TipoCli != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM classifica WHERE TipoCli = " + oClassifica.PK_TipoCli;
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
                _ErrorText = "Informe o código da classificação.";
                _Error = true;
                return false;
            }
        }
    }
}
