using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.ComponentModel;
using DevExpress.Web;
using Decision.Database;

namespace Decision.TableManager
{
    public class Agenda_Etiqueta_Fields
    {
        //*******************
        //* Campos da tabela
        //*******************
        public Int32 CodEtiqueta { get; set; }
        public string Descricao { get; set; }
        public Int32 Cor_RED { get; set; }
        public Int32 Cor_GREEN { get; set; }
        public Int32 Cor_BLUE { get; set; }
        public Agenda_Etiqueta_Fields()
        {
            //****************
            //* Inicialização
            //****************
            CodEtiqueta = 0;
            Descricao = string.Empty;
            Cor_RED = 0;
            Cor_GREEN = 0;
            Cor_BLUE = 0;
        }
    }
    public class Agenda_Etiqueta_Manager
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
        public Agenda_Etiqueta_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public List<Agenda_Etiqueta_Fields> GetSchedulerCustomLabels()
        {
            //**************
            //* Declarações
            //**************
            List<Agenda_Etiqueta_Fields> oEtiquetas = new List<Agenda_Etiqueta_Fields>();
            Agenda_Etiqueta_Fields oEtiqueta = new Agenda_Etiqueta_Fields();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();

            //*******************
            //* Proteção de erro
            //*******************
            try
            {
                //****************************************
                //* Obtem lista de etiquetas customizadas
                //****************************************
                string SQL = "SELECT * FROM agenda_etiqueta ORDER BY codetiqueta";
                oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //*****************************
                //* Monta coleção de etiquetas
                //*****************************
                for (Int32 CEtiqueta = 0; CEtiqueta < oTable.Rows.Count; CEtiqueta++)
                {
                    DataRow oRow = oTable.Rows[CEtiqueta];
                    oEtiqueta = new Agenda_Etiqueta_Fields();
                    oEtiqueta.CodEtiqueta = Convert.ToInt32(oRow["codetiqueta"]);
                    oEtiqueta.Descricao = oRow["descricao"].ToString();
                    oEtiqueta.Cor_BLUE = Convert.ToInt32(oRow["cor_blue"]);
                    oEtiqueta.Cor_GREEN = Convert.ToInt32(oRow["cor_green"]);
                    oEtiqueta.Cor_RED = Convert.ToInt32(oRow["cor_red"]);
                    oEtiquetas.Add(oEtiqueta);
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

            //********************************
            //* Devolve resultado da operação
            //********************************
            return oEtiquetas;
        }
    }
}