using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Pais_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodPais = 0;
        private string _DescPais = string.Empty;
        
        //*******************
        //* Campos da tabela
        //*******************
	    public Int32 PK_CodPais { get { return _PK_CodPais; } set { _PK_CodPais = value; } }
	    public string DescPais { get { return _DescPais.Left(20); } set { _DescPais = value; } }
        public Pais_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_CodPais = 0;
	        _DescPais = string.Empty;
        }
    }
    public class Pais_Manager
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
        public Pais_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Pais_Fields GetRecord(Int32 CodPais)
        {
            //**************
            //* Declarações
            //**************
            Pais_Fields oPais = new Pais_Fields();
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
                SQL = "SELECT * FROM pais WHERE CodPais = " + CodPais;
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
                    oPais.PK_CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                    oPais.DescPais = !DBNull.Value.Equals(oRow["DescPais"]) ? oRow["DescPais"].ToString() : string.Empty;
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
            return oPais;
        }
        public Int32 ApplyRecord(Pais_Fields oPais, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO pais (";
            SQL += "CodPais,";
            SQL += "DescPais";
            SQL += ") VALUES (";
            SQL += oPais.PK_CodPais + ",";
            SQL += "'" + oPais.DescPais.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oPais.PK_CodPais = oDBManager.ExecuteCommand(SQL, Import);

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
            return oPais.PK_CodPais;
        }
        public bool DeleteRecord(Pais_Fields oPais)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*****************************
            //* O código do pais é válido?
            //*****************************
            if (oPais.PK_CodPais!= 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM pais WHERE CodPais = " + oPais.PK_CodPais;
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
                _ErrorText = "Informe o código do país.";
                _Error = true;
                return false;
            }
        }
    }
}
