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
    public class ComboDataList
    {
        //*********************
        //* Variáveis privadas 
        //*********************
        private Int32 _ID = 0;
        private string _Column1 = string.Empty;
        private string _Column2 = string.Empty;
        private string _Column3 = string.Empty;
        private string _Column4 = string.Empty;
        private string _Column5 = string.Empty;

        //*******************
        //* Campos da tabela 
        //*******************
        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public string Column1 { get { return _Column1; } set { _Column1 = value; } }
        public string Column2 { get { return _Column2; } set { _Column2 = value; } }
        public string Column3 { get { return _Column3; } set { _Column3 = value; } }
        public string Column4 { get { return _Column4; } set { _Column4 = value; } }
        public string Column5 { get { return _Column5; } set { _Column5 = value; } }

        //****************
        //* Inicialização
        //****************
        public ComboDataList(Int32 ID = 0, string Col1 = "", string Col2 = "", string Col3 = "", string Col4 = "", string Col5 = "")
        {
            _ID = ID;
            _Column1 = Col1;
            _Column2 = Col2;
            _Column3 = Col3;
            _Column4 = Col4;
            _Column5 = Col5;
        }
    }
    public static class ComboBinder
    {
        public static List<ComboDataList> ComboClientes(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados
            //**************
            SQL = "SELECT clientes1.codcli, clientes1.nome FROM clientes1 ";
            SQL += "WHERE clientes1.codcli<>0 AND clientes1.statuscli='A' ";
            SQL += "ORDER BY clientes1.nome";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["CodCli"]), oRow["Nome"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboUnidadeNegocio(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT posto.postoven, posto.nomeposto, posto.descposto, posto.`end` AS endereco ";
            SQL += "FROM posto WHERE posto.postoven<>0 ORDER BY posto.nomeposto";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["PostoVen"]), 
                                                        oRow["NomePosto"].ToString() + " (" + oRow["NomePosto"].ToString() + ")",
                                                        oRow["endereco"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboProdutoServico(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT produtos.codprod, produtos.descprod FROM produtos ";
            SQL += "WHERE produtos.codprod<>0 AND produtos.statusprod='A' ";
            SQL += "ORDER BY produtos.descprod";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codprod"]),
                                                        oRow["descprod"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboConsolidador(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT ";
            SQL += "fornecedor.codfornec,";
            SQL += "fornecedor.nome ";
            SQL += "FROM fornecedor ";
            SQL += "WHERE ";
            SQL += "codfornec > 0 AND statusfor = 'A' AND ";
            SQL += "categoria IN ('Consolidador','Operadora') ";
            SQL += "ORDER BY nome";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codfornec"]),
                                                        oRow["nome"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboFornecedor(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT ";
            SQL += "fornecedor.codfornec,";
            SQL += "nome ";
            SQL += "FROM fornecedor ";
            SQL += "WHERE ";
            SQL += "fornecedor.codfornec > 0 AND ";
            SQL += "fornecedor.statusfor = 'A' ";
            SQL += "ORDER BY nome";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codfornec"]),
                                                        oRow["nome"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboCentroCusto(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT codcli, desccentrocusto FROM centroscusto ORDER BY desccentrocusto";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codcli"]),
                                                        oRow["desccentrocusto"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboEmissor(string ConnectionString, Int32 CodPromotor, Int32 CodAgencia)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string CodRestricao = string.Empty;
            string SQL = string.Empty;

            //*************************************************
            //* Há restrição de código de promotor ou agência? 
            //*************************************************
            if (CodAgencia > 0)
                CodRestricao = CodAgencia.ToString();
            if (CodPromotor >0)
                if (CodRestricao != string.Empty)
                    CodRestricao = "," + CodPromotor.ToString();
                else
                    CodRestricao = CodPromotor.ToString();

            //***************************************
            //* Há restrição de agência ou promotor?
            //***************************************
            if (CodRestricao != string.Empty)
            {
                //**********************
                //* Busca com restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND NOT codrestrito IN (" + CodRestricao + ") AND ";
                SQL += "tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            else
            {
                //**********************
                //* Busca sem restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codpromotor"]),
                                                        oRow["nomepromotor"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboGrupo(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT codagrup, descagrup FROM agrupamento WHERE codagrup > 0 AND statusgru = 'A' ORDER BY descagrup;";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codagrup"]),
                                                        oRow["descagrup"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboEvento(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT codevento, descevento FROM evento WHERE codevento > 0 AND statuseven = 'A' ORDER BY descevento;";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codevento"]),
                                                        oRow["descevento"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboPromotor(string ConnectionString, Int32 CodEmissor, Int32 CodAgencia)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string CodRestricao = string.Empty;
            string SQL = string.Empty;

            //*************************************************
            //* Há restrição de código de promotor ou agência? 
            //*************************************************
            if (CodAgencia > 0)
                CodRestricao = CodAgencia.ToString();
            if (CodEmissor > 0)
                if (CodRestricao != string.Empty)
                    CodRestricao = "," + CodEmissor.ToString();
                else
                    CodRestricao = CodEmissor.ToString();

            //***************************************
            //* Há restrição de agência ou promotor?
            //***************************************
            if (CodRestricao != string.Empty)
            {
                //**********************
                //* Busca com restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND NOT codrestrito IN (" + CodRestricao + ") AND ";
                SQL += "tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            else
            {
                //**********************
                //* Busca sem restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codpromotor"]),
                                                        oRow["nomepromotor"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboAgencia(string ConnectionString, Int32 CodEmissor, Int32 CodPromotor)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string CodRestricao = string.Empty;
            string SQL = string.Empty;

            //*************************************************
            //* Há restrição de código de promotor ou agência? 
            //*************************************************
            if (CodPromotor > 0)
                CodRestricao = CodPromotor.ToString();
            if (CodEmissor > 0)
                if (CodRestricao != string.Empty)
                    CodRestricao = "," + CodEmissor.ToString();
                else
                    CodRestricao = CodEmissor.ToString();

            //***************************************
            //* Há restrição de agência ou promotor?
            //***************************************
            if (CodRestricao != string.Empty)
            {
                //**********************
                //* Busca com restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND NOT codrestrito IN (" + CodRestricao + ") AND ";
                SQL += "tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            else
            {
                //**********************
                //* Busca sem restrição
                //**********************
                SQL = "SELECT codpromotor, nomepromotor FROM promotor WHERE ";
                SQL += "codpromotor > 0 AND tipo = 'E' AND status = 'A' ORDER BY nomepromotor";
            }
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codpromotor"]),
                                                        oRow["nomepromotor"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
        public static List<ComboDataList> ComboBanco(string ConnectionString)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<ComboDataList> oData = new List<ComboDataList>();
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //**************
            //* Obtem dados 
            //**************
            SQL = "SELECT codbco, descbco FROM banco WHERE codbco > 0 ORDER BY descbco";
            oTable = oDBManager.ExecuteQuery(SQL);

            //*******************************
            //* A consulta foi bem sucedida?
            //*******************************
            if (!oDBManager.Error)
                if (oTable != null)
                    if (oTable.Rows.Count > 0)
                        foreach (DataRow oRow in oTable.Rows)
                            oData.Add(new ComboDataList(Convert.ToInt32(oRow["codbco"]),
                                                        oRow["descbco"].ToString()));

            //****************
            //* Retorna dados
            //****************
            return oData;
        }
    }
}