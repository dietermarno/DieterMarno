using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Banco_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodBco = 0;
        private string _DescBco = string.Empty;
        private string _NroDescBco = string.Empty;
        private string _NroAgencia = string.Empty;
        private string _NroCedenteAg = string.Empty;
        private string _NroConvenio = string.Empty;
        private string _NroCarteira = string.Empty;
        private string _Instrucao = string.Empty;
        private string _Instrucao2 = string.Empty;
        private string _DvNroAgencia = string.Empty;
        private string _DvNroCedenteAg = string.Empty;
        private Int16 _RegistroCobranca = 0;
        private Int32 _SequenciaRemessa = 0;
        private string _CodigoEmpresaBanco = string.Empty;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_CodBco { get { return _PK_CodBco; } set { _PK_CodBco = value; } }
        public string DescBco { get { return _DescBco.Left(30); } set { _DescBco = value; } }
        public string NroDescBco { get { return _NroDescBco.Left(30); } set { _NroDescBco = value; } }
        public string NroAgencia { get { return _NroAgencia.Left(6); } set { _NroAgencia = value; } }
        public string NroCedenteAg { get { return _NroCedenteAg.Left(20); } set { _NroCedenteAg = value; } }
        public string NroConvenio { get { return _NroConvenio.Left(10); } set { _NroConvenio = value; } }
        public string NroCarteira { get { return _NroCarteira.Left(10); } set { _NroCarteira = value; } }
        public string Instrucao { get { return _Instrucao; } set { _Instrucao = value; } }
        public string Instrucao2 { get { return _Instrucao2; } set { _Instrucao2 = value; } }
        public string DvNroAgencia { get { return _DvNroAgencia.Left(3); } set { _DvNroAgencia = value; } }
        public string DvNroCedenteAg { get { return _DvNroCedenteAg.Left(3); } set { _DvNroCedenteAg = value; } }
        public Int16 RegistroCobranca { get { return _RegistroCobranca; } set { _RegistroCobranca = value; } }
        public Int32 SequenciaRemessa { get { return _SequenciaRemessa; } set { _SequenciaRemessa = value; } }
        public string CodigoEmpresaBanco { get { return _CodigoEmpresaBanco.Left(20); } set { _CodigoEmpresaBanco = value; } }
        public Banco_Fields()
        {
            //****************
            //* Inicialização
            //****************
            _PK_CodBco = 0;
            _DescBco = string.Empty;
            _NroDescBco = string.Empty;
            _NroAgencia = string.Empty;
            _NroCedenteAg = string.Empty;
            _NroConvenio = string.Empty;
            _NroCarteira = string.Empty;
            _Instrucao = string.Empty;
            _Instrucao2 = string.Empty;
            _DvNroAgencia = string.Empty;
            _RegistroCobranca = 0;
            _SequenciaRemessa = 0;
            _CodigoEmpresaBanco = string.Empty;
        }
    }
    public class Banco_Manager
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
        public Banco_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Banco_Fields GetRecord(Int32 CodBanco)
        {
            //**************
            //* Declarações
            //**************
            Banco_Fields oBanco = new Banco_Fields();
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
                SQL = "SELECT * FROM banco WHERE CodBco = " + CodBanco;
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
                    oBanco.PK_CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
                    oBanco.DescBco = !DBNull.Value.Equals(oRow["DescBco"]) ? oRow["DescBco"].ToString() : string.Empty;
                    oBanco.NroDescBco = !DBNull.Value.Equals(oRow["NroDescBco"]) ? oRow["NroDescBco"].ToString() : string.Empty;
                    oBanco.NroAgencia = !DBNull.Value.Equals(oRow["NroAgencia"]) ? oRow["NroAgencia"].ToString() : string.Empty;
                    oBanco.NroCedenteAg = !DBNull.Value.Equals(oRow["NroCedenteAg"]) ? oRow["NroCedenteAg"].ToString() : string.Empty;
                    oBanco.NroConvenio = !DBNull.Value.Equals(oRow["NroConvenio"]) ? oRow["NroConvenio"].ToString() : string.Empty;
                    oBanco.NroCarteira = !DBNull.Value.Equals(oRow["NroCarteira"]) ? oRow["NroCarteira"].ToString() : string.Empty;
                    oBanco.Instrucao = !DBNull.Value.Equals(oRow["Instrucao"]) ? oRow["Instrucao"].ToString() : string.Empty;
                    oBanco.Instrucao2 = !DBNull.Value.Equals(oRow["Instrucao2"]) ? oRow["Instrucao2"].ToString() : string.Empty;
                    oBanco.DvNroAgencia = !DBNull.Value.Equals(oRow["DvNroAgencia"]) ? oRow["DvNroAgencia"].ToString() : string.Empty;
                    oBanco.RegistroCobranca = !DBNull.Value.Equals(oRow["RegistroCobranca"]) ? Convert.ToInt16("0" + oRow["RegistroCobranca"]) : (Int16)0;
                    oBanco.SequenciaRemessa = !DBNull.Value.Equals(oRow["SequenciaRemessa"]) ? Convert.ToInt32("0" + oRow["SequenciaRemessa"]) : 0;
                    oBanco.CodigoEmpresaBanco = !DBNull.Value.Equals(oRow["CodigoEmpresaBanco"]) ? oRow["CodigoEmpresaBanco"].ToString() : string.Empty;
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
            return oBanco;
        }
        public Int32 ApplyRecord(Banco_Fields oBanco, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //******************************
            //* Atualiza ou insere registro
            //******************************
            SQL = "REPLACE INTO banco (";
            SQL += "CodBco,";
            SQL += "DescBco,";
            SQL += "NroDescBco,";
            SQL += "NroAgencia,";
            SQL += "NroCedenteAg,";
            SQL += "NroConvenio,";
            SQL += "NroCarteira,";
            SQL += "Instrucao,";
            SQL += "Instrucao2,";
            SQL += "DvNroAgencia,";
            SQL += "RegistroCobranca,";
            SQL += "SequenciaRemessa,";
            SQL += "CodigoEmpresaBanco";
            SQL += ") VALUES (";
            SQL += oBanco.PK_CodBco + ",";
            SQL += "'" + oBanco.DescBco.SQLFilter() + "',";
            SQL += "'" + oBanco.NroDescBco.SQLFilter() + "',";
            SQL += "'" + oBanco.NroAgencia.SQLFilter() + "',";
            SQL += "'" + oBanco.NroCedenteAg.SQLFilter() + "',";
            SQL += "'" + oBanco.NroConvenio.SQLFilter() + "',";
            SQL += "'" + oBanco.NroCarteira.SQLFilter() + "',";
            SQL += "'" + oBanco.Instrucao.SQLFilter() + "',";
            SQL += "'" + oBanco.Instrucao2.SQLFilter() + "',";
            SQL += "'" + oBanco.DvNroAgencia.SQLFilter() + "',";
            SQL += oBanco.RegistroCobranca + ",";
            SQL += oBanco.SequenciaRemessa + ",";
            SQL += "'" + oBanco.CodigoEmpresaBanco.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oBanco.PK_CodBco = oDBManager.ExecuteCommand(SQL, Import);

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
            return oBanco.PK_CodBco;
        }
        public bool DeleteRecord(Banco_Fields oBanco)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //******************************
            //* O código do banco é válido?
            //******************************
            if (oBanco.PK_CodBco != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM banco WHERE CodBco = " + oBanco.PK_CodBco;
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
                _ErrorText = "Informe o código do banco.";
                _Error = true;
                return false;
            }
        }
    }
}
