using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.ComponentModel;
using DevExpress.Web;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Promotor_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodPromotor = 0;
        private string _NomePromotor = string.Empty;
        private string _End = string.Empty;
        private string _Fone1 = string.Empty;
        private string _RamalFone1 = string.Empty;
        private string _Fone2 = string.Empty;
        private string _RamalFone2 = string.Empty;
        private string _Fax = string.Empty;
        private string _RamalFax = string.Empty;
        private string _CEP = string.Empty;
        private Int32 _CodCidade = 0;
        private string _Tipo = string.Empty;
        private string _EMail = string.Empty;
        private string _HTTP = string.Empty;
        private string _Obs = string.Empty;
        private string _Status = string.Empty;
        private Int32 _CodRestrito = 0;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_CodPromotor { get { return _PK_CodPromotor; } set { _PK_CodPromotor = value; } }
        public string NomePromotor { get { return _NomePromotor.Left(40); } set { _NomePromotor = value; } }
        public string End { get { return _End.Left(40); } set { _End = value; } }
        public string Fone1 { get { return _Fone1.Left(20); }  set { _Fone1 = value; } }
        public string RamalFone1 { get { return _RamalFone1.Left(5); } set { _RamalFone1 = value; } }
        public string Fone2 { get { return _Fone2.Left(20); } set { _Fone2 = value; } }
        public string RamalFone2 { get { return _RamalFone2.Left(5); } set { _RamalFone2 = value; } }
        public string Fax { get { return _Fax.Left(20); } set { _Fax = value; } }
        public string RamalFax { get { return _RamalFax.Left(5); } set { _RamalFax = value; } }
        public string CEP { get { return _CEP.Left(9); } set { _CEP = value; } }
        public Int32 CodCidade { get { return _CodCidade; } set { _CodCidade = value; } }
        public string Tipo { get { return _Tipo.Left(1); } set { _Tipo = value; } }
        public string EMail { get { return _EMail.Left(60); } set { _EMail = value; } }
        public string HTTP { get { return _HTTP.Left(60); } set { _HTTP = value; } }
        public string Obs { get { return _Obs; } set { _Obs = value; } }
        public string Status { get { return _Status.Left(1); } set { _Status = value; } }
        public Int32 CodRestrito { get { return _CodRestrito; } set { _CodRestrito = value; } }
        public Promotor_Fields()
        {
            //****************
            //* Inicialização
            //****************
            _PK_CodPromotor = 0;
            _NomePromotor = string.Empty;
            _End = string.Empty;
            _Fone1 = string.Empty;
            _RamalFone1 = string.Empty;
            _Fone2 = string.Empty;
            _RamalFone2 = string.Empty;
            _Fax = string.Empty;
            _RamalFax = string.Empty;
            _CEP = string.Empty;
            _CodCidade = 0;
            _Tipo = string.Empty;
            _EMail = string.Empty;
            _HTTP = string.Empty;
            _Obs = string.Empty;
            _Status = string.Empty;
            _CodRestrito = 0;
        }
    }
    public class Promotor_Manager
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
        public Promotor_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public List<Promotor_Fields> Get_NomePromotor_Like(string NomePromotor)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<Promotor_Fields> oPromotores = new List<Promotor_Fields>();
            Promotor_Fields oPromotor = new Promotor_Fields();

            //*******************
            //* Proteção de erro
            //*******************
            try
            {
                //****************************
                //* Obtem lista de promotores
                //****************************
                string SQL = "SELECT * FROM promotor WHERE ";
                SQL += "nomepromotor LIKE '%" + NomePromotor + "%' AND ";
                SQL += "codpromotor<>0 ORDER BY nomepromotor";
                DataTable oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //***********************************
                //* Devolve resultado nulo como erro
                //***********************************
                if (oTable != null)
                {
                    //*****************************
                    //* Copia registros para array
                    //*****************************
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oPromotor = new Promotor_Fields();
                        oPromotor.PK_CodPromotor = !DBNull.Value.Equals(oRow["codpromotor"]) ? Convert.ToInt32("0" + oRow["codpromotor"]) : 0;
                        oPromotor.NomePromotor = !DBNull.Value.Equals(oRow["nomepromotor"]) ? oRow["nomepromotor"].ToString() : string.Empty;
                        oPromotor.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;
                        oPromotor.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;
                        oPromotor.RamalFone1 = !DBNull.Value.Equals(oRow["ramalfone1"]) ? oRow["ramalfone1"].ToString() : string.Empty;
                        oPromotor.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;
                        oPromotor.RamalFone2 = !DBNull.Value.Equals(oRow["ramalfone2"]) ? oRow["ramalfone2"].ToString() : string.Empty;
                        oPromotor.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;
                        oPromotor.RamalFax = !DBNull.Value.Equals(oRow["ramalfax"]) ? oRow["ramalfax"].ToString() : string.Empty;
                        oPromotor.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;
                        oPromotor.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;
                        oPromotor.Tipo = !DBNull.Value.Equals(oRow["tipo"]) ? oRow["tipo"].ToString() : string.Empty;
                        oPromotor.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;
                        oPromotor.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;
                        oPromotor.Obs = !DBNull.Value.Equals(oRow["obs"]) ? oRow["obs"].ToString() : string.Empty;
                        oPromotor.Status = !DBNull.Value.Equals(oRow["status"]) ? oRow["status"].ToString() : string.Empty;
                        oPromotor.CodRestrito = !DBNull.Value.Equals(oRow["codrestrito"]) ? Convert.ToInt32("0" + oRow["codrestrito"]) : 0;
                        oPromotores.Add(oPromotor);
                    }
                }
                else
                {
                    //***********************************
                    //* Devolve resultado nulo como erro
                    //***********************************
                    _ErrorText = "O Resultado da pesquisa retornou nulo";
                    _Error = true;
                }
            }
            catch (Exception oException)
            {
                //****************
                //* Devolve falha
                //****************
                _ErrorText = oException.Message;
                _Error = true;
            }

            //****************
            //* Devolve lista
            //****************
            return oPromotores;
        }
        public Int32 ApplyRecord(Promotor_Fields oPromotor, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO promotor (";
            SQL += "CodPromotor,";
            SQL += "NomePromotor,";
            SQL += "End,";
            SQL += "Fone1,";
            SQL += "RamalFone1,";
            SQL += "Fone2,";
            SQL += "RamalFone2,";
            SQL += "Fax,";
            SQL += "RamalFax,";
            SQL += "CEP,";
            SQL += "CodCidade,";
            SQL += "Tipo,";
            SQL += "EMail,";
            SQL += "HTTP,";
            SQL += "Obs,";
            SQL += "Status,";
            SQL += "CodRestrito";
            SQL += ") VALUES (";
            SQL += oPromotor.PK_CodPromotor.ToString() + ",";
            SQL += "'" + oPromotor.NomePromotor.SQLFilter() + "',";
            SQL += "'" + oPromotor.End.SQLFilter() + "',";
            SQL += "'" + oPromotor.Fone1.SQLFilter() + "',";
            SQL += "'" + oPromotor.RamalFone1.SQLFilter() + "',";
            SQL += "'" + oPromotor.Fone2.SQLFilter() + "',";
            SQL += "'" + oPromotor.RamalFone2.SQLFilter() + "',";
            SQL += "'" + oPromotor.Fax.SQLFilter() + "',";
            SQL += "'" + oPromotor.RamalFax.SQLFilter() + "',";
            SQL += "'" + oPromotor.CEP.SQLFilter() + "',";
            SQL += oPromotor.CodCidade.ToString() + ",";
            SQL += "'" + oPromotor.Tipo.SQLFilter() + "',";
            SQL += "'" + oPromotor.EMail.SQLFilter() + "',";
            SQL += "'" + oPromotor.HTTP.SQLFilter() + "',";
            SQL += "'" + oPromotor.Obs.SQLFilter() + "',";
            SQL += "'" + oPromotor.Status.SQLFilter() + "',";
            SQL += oPromotor.CodRestrito.ToString() + ")";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oPromotor.PK_CodPromotor = oDBManager.ExecuteCommand(SQL, Import);

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
            return oPromotor.PK_CodPromotor;
        }
        public bool DeleteRecord(Promotor_Fields oPromotor)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //*********************************
            //* O código do promotor é válido?
            //*********************************
            if (oPromotor.PK_CodPromotor != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM promotor WHERE CodPromotor = " + oPromotor.PK_CodPromotor;
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
                _ErrorText = "Informe o código do promotor.";
                _Error = true;
                return false;
            }
        }
    }
}