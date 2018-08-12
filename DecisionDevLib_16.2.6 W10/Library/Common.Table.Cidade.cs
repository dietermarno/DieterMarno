using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Cidade_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodCidade = 0;
        private string _UF = string.Empty;
        private string _NomeCidade = string.Empty;
        private string _DDD = string.Empty;
        private Int32 _CodPais = 0;
        private string _Sigla = string.Empty;
        private string _ObsCidade = string.Empty;
        private Int32 _CodIBGE = 0;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_CodCidade { get { return _PK_CodCidade; } set { _PK_CodCidade = value; } }
        public string UF { get { return _UF.Left(2); } set { _UF = value; } }
        public string NomeCidade { get { return _NomeCidade.Left(25); } set { _NomeCidade = value; } }
        public string DDD { get { return _DDD.Left(4); } set { _DDD = value; } }
        public Int32 CodPais { get { return _CodPais; } set { _CodPais = value; } }
        public string Sigla { get { return _Sigla.Left(3); } set { _Sigla = value; } }
        public string ObsCidade { get { return _ObsCidade; } set { _ObsCidade = value; } }
        public Int32 CodIBGE { get { return _CodIBGE; } set { _CodIBGE = value; } }
        public Cidade_Fields()
        {
            //****************
            //* Inicialização
            //****************
            _PK_CodCidade = 0;
            _UF = string.Empty;
            _NomeCidade = string.Empty;
            _DDD = string.Empty;
            _CodPais = 0;
            _Sigla = string.Empty;
            _ObsCidade = string.Empty;
            _CodIBGE = 0;
        }
    }
    public class Cidade_Manager
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
        public Cidade_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Cidade_Fields GetRecord(Int32 CodCidade)
        {
            //**************
            //* Declarações
            //**************
            Cidade_Fields oCidade = new Cidade_Fields();
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
                SQL = "SELECT * FROM cidade WHERE CodCidade = " + CodCidade;
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
                    oCidade.PK_CodCidade = !DBNull.Value.Equals(oRow["CodCidade"]) ? Convert.ToInt32("0" + oRow["CodCidade"]) : 0;
                    oCidade.UF = !DBNull.Value.Equals(oRow["UF"]) ? oRow["UF"].ToString() : string.Empty;
                    oCidade.NomeCidade = !DBNull.Value.Equals(oRow["NomeCidade"]) ? oRow["NomeCidade"].ToString() : string.Empty;
                    oCidade.DDD = !DBNull.Value.Equals(oRow["DDD"]) ? oRow["DDD"].ToString() : string.Empty;
                    oCidade.CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                    oCidade.Sigla = !DBNull.Value.Equals(oRow["Sigla"]) ? oRow["Sigla"].ToString() : string.Empty;
                    oCidade.ObsCidade = !DBNull.Value.Equals(oRow["ObsCidade"]) ? oRow["ObsCidade"].ToString() : string.Empty;
                    oCidade.CodIBGE = !DBNull.Value.Equals(oRow["CodIBGE"]) ? Convert.ToInt32("0" + oRow["CodIBGE"]) : 0;
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
            return oCidade;
        }
        public Int32 ApplyRecord(Cidade_Fields oCidade, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO cidade (";
            SQL += "CodCidade,";
            SQL += "UF,";
            SQL += "NomeCidade,";
            SQL += "DDD,";
            SQL += "CodPais,";
            SQL += "Sigla,";
            SQL += "ObsCidade,";
            SQL += "CodIBGE";
            SQL += ") VALUES (";
            SQL += oCidade.PK_CodCidade + ",";
            SQL += "'" + oCidade.UF.SQLFilter() + "',";
            SQL += "'" + oCidade.NomeCidade.SQLFilter() + "',";
            SQL += "'" + oCidade.DDD.SQLFilter() + "',";
            SQL += oCidade.CodPais.ToString() + ",";
            SQL += "'" + oCidade.Sigla.SQLFilter() + "',";
            SQL += "'" + oCidade.ObsCidade.SQLFilter() + "',";
            SQL += oCidade.CodIBGE.ToString() + ")";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oCidade.PK_CodCidade = oDBManager.ExecuteCommand(SQL, Import);

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
            return oCidade.PK_CodCidade;
        }
        public bool DeleteRecord(Cidade_Fields oCidade)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*******************************
            //* O código da cidade é válido?
            //*******************************
            if (oCidade.PK_CodCidade != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM cidade WHERE CodCidade = " + oCidade.PK_CodCidade;
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
                _ErrorText = "Informe o código da cidade.";
                _Error = true;
                return false;
            }
        }
    }
}
