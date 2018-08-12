using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Decision.Database;
using Decision.TableManager;

namespace Decision
{
    /// <summary>
    /// Summary description for exibe_logo_posto
    /// </summary>
    public class exibe_logo_posto : IHttpHandler
    {

        public void ProcessRequest(HttpContext oContext)
        {
            //**************
            //* Declarações
            //**************
            Int32 CodigoMaster = 0;
            Int32 CodigoPosto = 0;

            //*************************************************
            //* O código da agência e da proposta são válidos?
            //*************************************************
            if (oContext.Request.QueryString["CMA"] != null && oContext.Request.QueryString["CPO"] != null)
            {
                //*********************************************************
                //* Obtém código da instância da empresa e código do posto
                //*********************************************************
                CodigoMaster = Convert.ToInt32("0" + oContext.Request.QueryString["CMA"]);
                CodigoPosto = Convert.ToInt32("0" + oContext.Request.QueryString["CPO"]);

                //*******************************************
                //* Define tipo de conteúdo e captura imagem
                //*******************************************
                oContext.Response.ContentType = "image/jpeg";
                Stream oStream = GetImage(CodigoMaster, CodigoPosto);
                byte[] buffer = new byte[4096];
                int total_bytes = oStream.Read(buffer, 0, 4096);

                //**********************************
                //* Recuperou a imagem com sucesso?
                //**********************************
                while (total_bytes > 0)
                {
                    //**********************
                    //* Escreve 4Kb por vez
                    //**********************
                    oContext.Response.OutputStream.Write(buffer, 0, total_bytes);
                    total_bytes = oStream.Read(buffer, 0, 4096);
                }
            }
        }
        public Stream GetImage(Int32 CodigoMaster, Int32 CodigoPosto)
        {
            //***********************************
            //* Obtem string de conexão do posto
            //***********************************
            string Conexao = DBConnection.GetConnectionFromMaster(CodigoMaster);

            //***************************
            //* A nova conexão é válida?
            //***************************
            if (Conexao.IndexOf("Error") == -1)
            {
                //********************************************************
                //* Inicia gerenciador da tabela posto com a nova conexão
                //********************************************************
                Posto_Manager oPostoManager = new Posto_Manager(Conexao);
                Posto_Fields oPosto = new Posto_Fields();

                //***************************************************
                //* Cria memory stream baseado no conteúdo da imagem
                //***************************************************
                try
                {
                    return new MemoryStream((byte[])oPostoManager.GetPicture(CodigoPosto));
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}