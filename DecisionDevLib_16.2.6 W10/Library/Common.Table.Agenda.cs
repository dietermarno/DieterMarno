using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.ComponentModel;
using DevExpress.Web;
using Decision.Database;
using Decision.Extensions;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Decision.TableManager
{
    [XmlRootAttribute("ResourceIds")]
    public class Agenda_Resources
    {
        public Agenda_ResourceId ResourceId = new Agenda_ResourceId();
    }
    public class Agenda_ResourceId
    {
        [XmlAttribute]
        public string Type = "System.Int32";
        [XmlAttribute]
        public Int32 Value = 0;
    }
    public class Agenda_Apontamentos_Fields
    {
        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_CodApontamento { get; set; }
        public Int32 CodPromotor { get; set; }
        public Int32 CodCliente { get; set; }
        public Int32 CodOportunidade { get; set; }
        public Int32 CodOrcamento { get; set; }
        public Int32 Situacao { get; set; }
        public Int32 Tipo { get; set; }
        public Int32 Etiqueta { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Recorrencia { get; set; }
        public string Despertador { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public bool Dia_Inteiro { get; set; }
        public bool Exportacao { get; set; }
        public Agenda_Apontamentos_Fields()
        {
            //****************
            //* Inicialização
            //****************
            PK_CodApontamento = 0;
            CodPromotor = 0;
            CodCliente = 0;
            CodOportunidade = 0;
            CodOrcamento = 0;
            Situacao = 0;
            Tipo = 0;
            Etiqueta = 0;
            Assunto = string.Empty;
            Descricao = string.Empty;
            Local = string.Empty;
            Recorrencia = string.Empty;
            Despertador = string.Empty;
            Inicio = null;
            Fim = null;
            Dia_Inteiro = false;
            Exportacao = true;
        }
    }
    public class Agenda_Apontamentos_Manager
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
        public Agenda_Apontamentos_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public bool SynchronizeOppotunities()
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);

            //*******************
            //* Proteção de erro
            //*******************
            try
            {
                //*****************************************
                //* Remove registros automáticos da agenda
                //*****************************************
                string SQL = "DELETE FROM agenda_apontamentos WHERE exportacao = 1";
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //*********************************
                //* Atualiza lista de apontamentos
                //*********************************
                SQL = "INSERT INTO agenda_apontamentos ";
                SQL += "(codpromotor, situacao, tipo, etiqueta, assunto, descricao, local,";
                SQL += "recorrencia,despertador, inicio, fim, dia_inteiro,exportacao) ";
                SQL += "SELECT oportunidade.cod_promotor, 2, 0, 2, concat('Retorno agendado: ', oportunidade.contato_nome),";
                SQL += "oportunidade.descricao, 'Escritório', null, null, oportunidade.proximo_contato,";
                SQL += "DATE_ADD(oportunidade.proximo_contato,INTERVAL 30 MINUTE), 0, 1 ";
                SQL += "FROM oportunidade WHERE oportunidade.proximo_contato_realizado = false";
                oDBManager.ExecuteCommand(SQL);
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
            return !_Error;
        }
        public Int32 ApplyCustomerScheduler(Agenda_Apontamentos_Fields oAgenda)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //*************************************************************
            //* Já existe apontamento de aniversário para o cliente atual?
            //*************************************************************
            SQL = "SELECT codapontamento FROM agenda_apontamentos WHERE codcliente = " + oAgenda.CodCliente;
            oTable = oDBManager.ExecuteQuery(SQL);

            //********************************
            //* Novo registro ou atualização?
            //********************************
            if (oTable.Rows.Count == 0)
            {
                //**************************************************
                //* Cria novo agendamento de aniversário de cliente
                //**************************************************
                SQL = "INSERT INTO agenda_apontamentos (";
                SQL += "recrusos,";
                SQL += "codcliente,";
                SQL += "codoportunidade,";
                SQL += "codorcamento,";
                SQL += "codpromotor,";
                SQL += "situacao,";
                SQL += "tipo,";
                SQL += "etiqueta,";
                SQL += "assunto,";
                SQL += "descricao,";
                SQL += "local,";
                SQL += "recorrencia,";
                SQL += "despertador,";
                SQL += "inicio,";
                SQL += "fim,";
                SQL += "dia_inteiro,";
                SQL += "exportacao";
                SQL += ") VALUES (";
                SQL += "'" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += oAgenda.CodCliente + ",";
                SQL += oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodOrcamento + ",";
                SQL += oAgenda.CodPromotor == 0 ? "null" : oAgenda.CodPromotor + ",";
                SQL += oAgenda.Situacao + ",";
                SQL += oAgenda.Tipo + ",";
                SQL += oAgenda.Etiqueta + ",";
                SQL += "'" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "'" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "'" + oAgenda.Local.SQLFilter() + "',";
                SQL += "'" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "'" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "'" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "'" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += Convert.ToInt16(oAgenda.Exportacao) + ")";
            }
            else
            {
                //*************************************************
                //* Atualiza agendamento de aniversário de cliente
                //*************************************************
                SQL = "UPDATE agenda_apontamentos SET ";
                SQL += "recursos = '" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += "codcliente = " + oAgenda.CodCliente + ",";
                SQL += "codoportunidade = " + oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodPromotor == 0 ? "codpromotor = null," : "codpromotor = " + oAgenda.CodPromotor + ",";
                SQL += "situacao = " + oAgenda.Situacao + ",";
                SQL += "tipo = " +  oAgenda.Tipo + ",";
                SQL += "etiqueta = " + oAgenda.Etiqueta + ",";
                SQL += "assunto = '" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "descricao = '" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "local = '" + oAgenda.Local.SQLFilter() + "',";
                SQL += "recorrencia = '" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "despertador = '" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "inicio = '" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "fim = '" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "dia_inteiro = " + Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += "exportacao = " + Convert.ToInt16(oAgenda.Exportacao) + " ";
                SQL += "WHERE codcliente = " + oAgenda.CodOrcamento;
            }

            //**************************
            //* Executa comando formado
            //**************************
            if (oTable.Rows.Count == 0)
                oAgenda.PK_CodApontamento = oDBManager.ExecuteCommand(SQL);
            else
                oDBManager.ExecuteCommand(SQL);

            //***************************
            //* Obtem status da operação
            //***************************
            _ErrorText = oDBManager.ErrorMessage;
            _Error = oDBManager.Error;

            //*************************
            //* Retorna chave primária
            //*************************
            return oAgenda.PK_CodApontamento;
        }
        public Int32 ApplyOpportunityScheduler(Agenda_Apontamentos_Fields oAgenda)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //***************************************************
            //* Já existe agendamento para a oportunidade atual?
            //***************************************************
            SQL = "SELECT codapontamento FROM agenda_apontamentos WHERE ";
            SQL += "codoportunidade = " + oAgenda.CodOportunidade + " AND ";
            SQL += "etiqueta = " + oAgenda.Etiqueta;
            oTable = oDBManager.ExecuteQuery(SQL);

            //********************************
            //* Novo registro ou atualização?
            //********************************
            if (oTable.Rows.Count == 0)
            {
                //***************************************************
                //* Cria novo agendamento de contato da oportunidade
                //***************************************************
                SQL = "INSERT INTO agenda_apontamentos (";
                SQL += "recursos,";
                SQL += "codcliente,";
                SQL += "codoportunidade,";
                SQL += "codorcamento,";
                SQL += "codpromotor,";
                SQL += "situacao,";
                SQL += "tipo,";
                SQL += "etiqueta,";
                SQL += "assunto,";
                SQL += "descricao,";
                SQL += "local,";
                SQL += "recorrencia,";
                SQL += "despertador,";
                SQL += "inicio,";
                SQL += "fim,";
                SQL += "dia_inteiro,";
                SQL += "exportacao";
                SQL += ") VALUES (";
                SQL += "'" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += oAgenda.CodCliente + ",";
                SQL += oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodOrcamento + ",";
                SQL += oAgenda.CodPromotor == 0 ? "null" : oAgenda.CodPromotor + ",";
                SQL += oAgenda.Situacao + ",";
                SQL += oAgenda.Tipo + ",";
                SQL += oAgenda.Etiqueta + ",";
                SQL += "'" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "'" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "'" + oAgenda.Local.SQLFilter() + "',";
                SQL += "'" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "'" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "'" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "'" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += Convert.ToInt16(oAgenda.Exportacao) + ")";
            }
            else
            {
                //**************************************************
                //* Atualiza agendamento de contato da oportunidade
                //**************************************************
                SQL = "UPDATE agenda_apontamentos SET ";
                SQL += "recursos = '" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += "codcliente = " + oAgenda.CodCliente + ",";
                SQL += "codoportunidade = " + oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodPromotor == 0 ? "codpromotor = null," : "codpromotor = " + oAgenda.CodPromotor + ",";
                SQL += "situacao = " + oAgenda.Situacao + ",";
                SQL += "tipo = " + oAgenda.Tipo + ",";
                SQL += "etiqueta = " + oAgenda.Etiqueta + ",";
                SQL += "assunto = '" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "descricao = '" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "local = '" + oAgenda.Local.SQLFilter() + "',";
                SQL += "recorrencia = '" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "despertador = '" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "inicio = '" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "fim = '" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "dia_inteiro = " + Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += "exportacao = " + Convert.ToInt16(oAgenda.Exportacao) + " ";
                SQL += "WHERE ";
                SQL += "codoportunidade = " + oAgenda.CodOportunidade + " AND ";
                SQL += "etiqueta = " + oAgenda.Etiqueta;
            }

            //**************************
            //* Executa comando formado
            //**************************
            if (oTable.Rows.Count == 0)
                oAgenda.PK_CodApontamento = oDBManager.ExecuteCommand(SQL);
            else
                oDBManager.ExecuteCommand(SQL);

            //***************************
            //* Obtem status da operação
            //***************************
            _ErrorText = oDBManager.ErrorMessage;
            _Error = oDBManager.Error;

            //*************************
            //* Retorna chave primária
            //*************************
            return oAgenda.PK_CodApontamento;
        }
        public Int32 ApplyBudgetScheduler(Agenda_Apontamentos_Fields oAgenda)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //************************************************
            //* Já existe agendamento para o orçamento atual?
            //************************************************
            SQL = "SELECT codapontamento FROM agenda_apontamentos WHERE codorcamento = " + oAgenda.CodOrcamento;
            oTable = oDBManager.ExecuteQuery(SQL);

            //********************************
            //* Novo registro ou atualização?
            //********************************
            if (oTable.Rows.Count == 0)
            {
                //************************************************
                //* Cria novo agendamento de contato do orçamento
                //************************************************
                SQL = "INSERT INTO agenda_apontamentos (";
                SQL += "recursos,";
                SQL += "codcliente,";
                SQL += "codoportunidade,";
                SQL += "codorcamento,";
                SQL += "codpromotor,";
                SQL += "situacao,";
                SQL += "tipo,";
                SQL += "etiqueta,";
                SQL += "assunto,";
                SQL += "descricao,";
                SQL += "local,";
                SQL += "recorrencia,";
                SQL += "despertador,";
                SQL += "inicio,";
                SQL += "fim,";
                SQL += "dia_inteiro,";
                SQL += "exportacao";
                SQL += ") VALUES (";
                SQL += "'" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += oAgenda.CodCliente + ",";
                SQL += oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodOrcamento + ",";
                SQL += oAgenda.CodPromotor == 0 ? "null" : oAgenda.CodPromotor + ",";
                SQL += oAgenda.Situacao + ",";
                SQL += oAgenda.Tipo + ",";
                SQL += oAgenda.Etiqueta + ",";
                SQL += "'" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "'" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "'" + oAgenda.Local.SQLFilter() + "',";
                SQL += "'" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "'" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "'" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "'" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += Convert.ToInt16(oAgenda.Exportacao) + ")";
            }
            else
            {
                //***********************************************
                //* Atualiza agendamento de contato do orçamento
                //***********************************************
                SQL = "UPDATE agenda_apontamentos SET ";
                SQL += "recursos = '" + GetResourceXML(oAgenda.CodPromotor).SQLFilter() + "',";
                SQL += "codcliente = " + oAgenda.CodCliente + ",";
                SQL += "codoportunidade = " + oAgenda.CodOportunidade + ",";
                SQL += oAgenda.CodPromotor == 0 ? "codpromotor = null," : "codpromotor = " + oAgenda.CodPromotor + ",";
                SQL += "situacao = " + oAgenda.Situacao + ",";
                SQL += "tipo = " + oAgenda.Tipo + ",";
                SQL += "etiqueta = " + oAgenda.Etiqueta + ",";
                SQL += "assunto = '" + oAgenda.Assunto.SQLFilter() + "',";
                SQL += "descricao = '" + oAgenda.Descricao.SQLFilter() + "',";
                SQL += "local = '" + oAgenda.Local.SQLFilter() + "',";
                SQL += "recorrencia = '" + oAgenda.Recorrencia.SQLFilter() + "',";
                SQL += "despertador = '" + oAgenda.Despertador.SQLFilter() + "',";
                SQL += "inicio = '" + oAgenda.Inicio.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "fim = '" + oAgenda.Fim.Value.ToString("yyyy-MM-dd HH:mm") + "',";
                SQL += "dia_inteiro = " + Convert.ToInt16(oAgenda.Dia_Inteiro) + ",";
                SQL += "exportacao = " + Convert.ToInt16(oAgenda.Exportacao) + " ";
                SQL += "WHERE codorcamento = " + oAgenda.CodOrcamento;
            }

            //**************************
            //* Executa comando formado
            //**************************
            if (oTable.Rows.Count == 0)
                oAgenda.PK_CodApontamento = oDBManager.ExecuteCommand(SQL);
            else
                oDBManager.ExecuteCommand(SQL);

            //***************************
            //* Obtem status da operação
            //***************************
            _ErrorText = oDBManager.ErrorMessage;
            _Error = oDBManager.Error;

            //*************************
            //* Retorna chave primária
            //*************************
            return oAgenda.PK_CodApontamento;
        }
        public string GetResourceXML(Int32 CodPromotor)
        {
            //*************************
            //* Estrutura de RESOURCES
            //*************************
            Agenda_Resources oResource = new Agenda_Resources();
            oResource.ResourceId.Value = CodPromotor;

            //********************************
            //* Estrutura vazia de NAMESPACES
            //********************************
            XmlSerializerNamespaces oNS = new XmlSerializerNamespaces();
            oNS.Add("", "");

            //*********************************
            //* Serializa removendo NAMESPACES
            //*********************************
            XmlSerializer oSerializer = new XmlSerializer(typeof(Agenda_Resources));
            MemoryStream oStream = new MemoryStream();
            oSerializer.Serialize(oStream, oResource,oNS);

            //************************
            //* Remove declaração XML
            //************************
            string XMLDoc = Encoding.UTF8.GetString(oStream.ToArray());
            XDocument oXMLDoc = XDocument.Parse(XMLDoc);
            oXMLDoc.Declaration = null;

            //********************
            //* Retorna XML final
            //********************
            return oXMLDoc.ToString();
        }
    }
}