using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Decision.Database;
using Decision.TableManager;
using Decision.Util;

namespace DecisionExchanger
{
    class Program
    {
        static void Main(string[] args)
        {
            //**************
            //* Declarações
            //**************
            string Mensagem = string.Empty;

            #region "Mensagem padrão"
            
            //*************************************************************************************
            //* Parâmetros de chamada (Rotinas de Importação e Exportação)
            //* DecisionExchanger.exe EMPRESA USUARIO SENHA OPERAÇÂO TABELA1, TABELA2, TABELA3...
            //*************************************************************************************
            Mensagem = "Utilize: DecisionExchanger.exe EMPRESA USUARIO SENHA OPERAÇÃO TABELA1 TABELA2 TABELA3...\r\n";
            Mensagem += "OPERAÇÃO: IMPORTAR ou EXPORTAR\r\n";
            Mensagem += "TABELAS: PAIS CIDADE BANCO PROFISSAO PROMOTOR POSTO SITUACAO CLASSIFICA CLIENTES\r\n";
            
            #endregion

            #region "Validação: quantidade de argumentos"

            //*****************************************
            //* Possui quantidade total de argumentos?
            //*****************************************
            if (args.Count() < 5)
            {
                //**********************
                //* Notifica e finaliza
                //**********************
                Mensagem = "Quantidade de parâmetros insuficiente.\r\n\r\n" + Mensagem;
                Console.Write(Mensagem);
                Console.Write("Pressione qualquer tecla...\r\n\r\n");
                Console.ReadKey();
                return;
            }

            #endregion

            #region "Validação: operação"

            //***********************
            //* A operação é válida?
            //***********************
            if (args[3].ToUpper() != "IMPORTAR" && args[3].ToUpper() != "EXPORTAR")
            {
                //**********************
                //* Notifica e finaliza
                //**********************
                Mensagem = "Operação inválida.\r\n\r\n" + Mensagem;
                Console.Write(Mensagem);
                Console.Write("Pressione qualquer tecla...\r\n\r\n");
                Console.ReadKey();
                return;
            }

            #endregion

            #region "Validação: lista de tabelas"

            //***********************************
            //* Os nomes de tabelas são válidos?
            //***********************************
            string Tabelas = "PAIS, CIDADE, BANCO, PROFISSAO, PROMOTOR, POSTO, SITUACAO, CLASSIFICA, CLIENTES";
            for(int PCount = 4; PCount < args.Length; PCount++)
            {
                //*****************************
                //* A tabela atual é inválida?
                //*****************************
                if (Tabelas.IndexOf(args[PCount].ToUpper()) == -1)
                {
                    //**********************
                    //* Notifica e finaliza
                    //**********************
                    Mensagem = "A um ou mais nomes de tabelas inválidos.\r\n\r\n" + Mensagem;
                    Console.Write(Mensagem);
                    Console.Write("Pressione qualquer tecla...\r\n\r\n");
                    Console.ReadKey();
                    return;
                }
            }

            #endregion

            #region "Notifica início do processo"

            //*********************
            //* Iniciando operação
            //*********************
            Mensagem = "Iniciando operação de ";
            Mensagem += args[3].ToUpper() == "IMPORTAR" ? "IMPORTAÇÃO" : "EXPORTAÇÃO";
            Mensagem += "...\r\n\r\n";
            Console.Write(Mensagem);

            #endregion

            #region "Execução das rotinas de importação ou exportação"

            //**********************************
            //* Executa operação em cada tabela
            //**********************************
            for (int PCount = 4; PCount < args.Length; PCount++)
            {
                //*************************************
                //* Define chamada pelo nome da tabela
                //*************************************
                switch(args[PCount].ToUpper())
                {
                    case "PAIS":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //***************************************
                            //* Notifica e executa importação (PAIS)
                            //***************************************
                            Mensagem = "Importando tabela PAIS...";
                            Console.Write(Mensagem);
                            ImportaPais(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //***************************************
                            //* Notifica e executa exportação (PAIS)
                            //***************************************
                            Mensagem = "Exportando tabela PAIS...";
                            Console.Write(Mensagem);
                            ExportaPais(args[0], args[1], args[2]);
                        }
                        break;

                    case "CIDADE":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //*****************************************
                            //* Notifica e executa importação (CIDADE)
                            //*****************************************
                            Mensagem = "Importando tabela CIDADE...";
                            Console.Write(Mensagem);
                            ImportaCidade(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //*****************************************
                            //* Notifica e executa exportação (CIDADE)
                            //*****************************************
                            Mensagem = "Exportando tabela CIDADE...";
                            Console.Write(Mensagem);
                            ExportaCidade(args[0], args[1], args[2]);
                        }
                        break;

                    case "BANCO":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //****************************************
                            //* Notifica e executa importação (BANCO)
                            //****************************************
                            Mensagem = "Importando tabela BANCO...";
                            Console.Write(Mensagem);
                            ImportaBanco(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //****************************************
                            //* Notifica e executa exportação (BANCO)
                            //****************************************
                            Mensagem = "Exportando tabela BANCO...";
                            Console.Write(Mensagem);
                            ExportaBanco(args[0], args[1], args[2]);
                        }
                        break;

                    case "PROFISSAO":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //********************************************
                            //* Notifica e executa importação (PROFISSAO)
                            //********************************************
                            Mensagem = "Importando tabela PROFISSAO...";
                            Console.Write(Mensagem);
                            ImportaProfissao(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //********************************************
                            //* Notifica e executa exportação (PROFISSAO)
                            //********************************************
                            Mensagem = "Exportando tabela PROFISSAO...";
                            Console.Write(Mensagem);
                            ExportaProfissao(args[0], args[1], args[2]);
                        }
                        break;

                    case "PROMOTOR":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //*******************************************
                            //* Notifica e executa importação (PROMOTOR)
                            //*******************************************
                            Mensagem = "Importando tabela PROMOTOR...";
                            Console.Write(Mensagem);
                            ImportaPromotor(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //*******************************************
                            //* Notifica e executa exportação (PROMOTOR)
                            //*******************************************
                            Mensagem = "Exportando tabela PROMOTOR...";
                            Console.Write(Mensagem);
                            ExportaPromotor(args[0], args[1], args[2]);
                        }
                        break;

                    case "POSTO":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //****************************************
                            //* Notifica e executa importação (POSTO)
                            //****************************************
                            Mensagem = "Importando tabela POSTO...";
                            Console.Write(Mensagem);
                            ImportaPosto(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //****************************************
                            //* Notifica e executa exportação (POSTO)
                            //****************************************
                            Mensagem = "Exportando tabela POSTO...";
                            Console.Write(Mensagem);
                            ExportaPosto(args[0], args[1], args[2]);
                        }
                        break;

                    case "SITUACAO":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //*******************************************
                            //* Notifica e executa importação (SITUACAO)
                            //*******************************************
                            Mensagem = "Importando tabela SITUACAO...";
                            Console.Write(Mensagem);
                            ImportaSituacao(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //*******************************************
                            //* Notifica e executa exportação (SITUACAO)
                            //*******************************************
                            Mensagem = "Exportando tabela SITUACAO...";
                            Console.Write(Mensagem);
                            ExportaSituacao(args[0], args[1], args[2]);
                        }
                        break;

                    case "CLASSIFICA":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //*********************************************
                            //* Notifica e executa importação (CLASSIFICA)
                            //*********************************************
                            Mensagem = "Importando tabela CLASSIFICA...";
                            Console.Write(Mensagem);
                            ImportaClassifica(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //*********************************************
                            //* Notifica e executa exportação (CLASSIFICA)
                            //*********************************************
                            Mensagem = "Exportando tabela CLASSIFICA...";
                            Console.Write(Mensagem);
                            ExportaClassifica(args[0], args[1], args[2]);
                        }
                        break;

                    case "CLIENTES":
                        if (args[3].ToUpper() == "IMPORTAR")
                        {
                            //*********************************************
                            //* Notifica e executa importação (CLASSIFICA)
                            //*********************************************
                            Mensagem = "Importando tabela CLIENTES...";
                            Console.Write(Mensagem);
                            ImportaClientes(args[0], args[1], args[2]);
                        }
                        else
                        {
                            //*********************************************
                            //* Notifica e executa exportação (CLASSIFICA)
                            //*********************************************
                            Mensagem = "Exportando tabela CLIENTES...";
                            Console.Write(Mensagem);
                            ExportaClientes(args[0], args[1], args[2]);
                        }
                        break;
                }
            }

            //********************
            //* Aguarda uma tecla
            //********************
            Console.Write("Pressione qualquer tecla...\r\n\r\n");
            Console.ReadKey();

            #endregion
        }
        static public void ExportaPais(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;
            
            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM pais";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaPais(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                  Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach(string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaCidade(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM cidade";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaCidade(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                    Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaBanco(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM banco";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaBanco(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                   Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaProfissao(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM profissao";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaProfissao(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                       Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaPromotor(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM promotor";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaPromotor(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                      Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaPosto(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM posto";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaPosto(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                   Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaSituacao(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM situacao";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaSituacao(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                      Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaClassifica(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM classifica";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {
                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaClassifica(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                        Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ExportaClientes(string Empresa, string Usuario, string Senha)
        {
            //**************
            //* Declarações
            //**************
            string ActiveConnection = DecisionExchanger.Properties.Settings.Default.ActiveConnectionName;
            string ConnectionString = ConfigurationManager.ConnectionStrings[ActiveConnection].ConnectionString;
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTable = new DataTable();
            string SQL = string.Empty;

            //********************************
            //* Deve alterar a URL de escuta?
            //********************************
            if (!System.Diagnostics.Debugger.IsAttached)
                oService.Endpoint.ListenUri = new Uri("http://www.presser.com.br");

            //*******************************
            //* Obtem dados da tabela origem
            //*******************************
            SQL = "SELECT * FROM Clientes1 ";
            SQL +="LEFT JOIN Clientes2 ON Clientes1.CodCli = Clientes2.CodCli";
            oTable = oDBManager.ExecuteQuery(SQL);

            //**************************
            //* Obtem XML a ser enviado
            //**************************
            if (oTable.Rows.Count > 0)
            {

                //**************************
                //* Obtem XML a ser enviado
                //**************************
                StringWriter oXMLWriter = new StringWriter();
                oTable.WriteXml(oXMLWriter);

                //**************************
                //* Define dados da chamada
                //**************************
                oResultado = oService.ImportaClientes(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario),
                                                      Crypto.EncryptString(Senha), Crypto.EncryptString(oXMLWriter.ToString()));
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaPais(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //**************************
            //* Define dados da chamada
            //**************************
            oResultado = oService.ExportaPais(Crypto.EncryptString(Empresa), Crypto.EncryptString(Usuario), Crypto.EncryptString(Senha));

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Pais_Manager oManager = new Pais_Manager(ConnectionString);
            Pais_Fields oFields = new Pais_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                oFields.DescPais = !DBNull.Value.Equals(oRow["DescPais"]) ? oRow["DescPais"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodPais)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Pais - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Pais - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaCidade(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Cidade_Manager oManager = new Cidade_Manager(ConnectionString);
            Cidade_Fields oFields = new Cidade_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodCidade = !DBNull.Value.Equals(oRow["CodCidade"]) ? Convert.ToInt32("0" + oRow["CodCidade"]) : 0;
                oFields.UF = !DBNull.Value.Equals(oRow["UF"]) ? oRow["UF"].ToString() : string.Empty;
                oFields.NomeCidade = !DBNull.Value.Equals(oRow["NomeCidade"]) ? oRow["NomeCidade"].ToString() : string.Empty;
                oFields.DDD = !DBNull.Value.Equals(oRow["DDD"]) ? oRow["DDD"].ToString() : string.Empty;
                oFields.CodPais = !DBNull.Value.Equals(oRow["CodPais"]) ? Convert.ToInt32("0" + oRow["CodPais"]) : 0;
                oFields.Sigla = !DBNull.Value.Equals(oRow["Sigla"]) ? oRow["Sigla"].ToString() : string.Empty;
                oFields.ObsCidade = !DBNull.Value.Equals(oRow["ObsCidade"]) ? oRow["ObsCidade"].ToString() : string.Empty;
                oFields.CodIBGE = !DBNull.Value.Equals(oRow["CodIBGE"]) ? Convert.ToInt32("0" + oRow["CodIBGE"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodCidade)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Cidade - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Cidade - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaBanco(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Banco_Manager oManager = new Banco_Manager(ConnectionString);
            Banco_Fields oFields = new Banco_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
                oFields.DescBco = !DBNull.Value.Equals(oRow["DescBco"]) ? oRow["DescBco"].ToString() : string.Empty;
                oFields.NroDescBco = !DBNull.Value.Equals(oRow["NroDescBco"]) ? oRow["NroDescBco"].ToString() : string.Empty;
                oFields.NroAgencia = !DBNull.Value.Equals(oRow["NroAgencia"]) ? oRow["NroAgencia"].ToString() : string.Empty;
                oFields.NroCedenteAg = !DBNull.Value.Equals(oRow["NroCedenteAg"]) ? oRow["NroCedenteAg"].ToString() : string.Empty;
                oFields.NroConvenio = !DBNull.Value.Equals(oRow["NroConvenio"]) ? oRow["NroConvenio"].ToString() : string.Empty;
                oFields.NroCarteira = !DBNull.Value.Equals(oRow["NroCarteira"]) ? oRow["NroCarteira"].ToString() : string.Empty;
                oFields.Instrucao = !DBNull.Value.Equals(oRow["Instrucao"]) ? oRow["Instrucao"].ToString() : string.Empty;
                oFields.Instrucao2 = !DBNull.Value.Equals(oRow["Instrucao2"]) ? oRow["Instrucao2"].ToString() : string.Empty;
                oFields.DvNroAgencia = !DBNull.Value.Equals(oRow["DvNroAgencia"]) ? oRow["DvNroAgencia"].ToString() : string.Empty;
                oFields.RegistroCobranca = !DBNull.Value.Equals(oRow["RegistroCobranca"]) ? Convert.ToInt16("0" + oRow["RegistroCobranca"]) : (Int16)0;
                oFields.SequenciaRemessa = !DBNull.Value.Equals(oRow["SequenciaRemessa"]) ? Convert.ToInt32("0" + oRow["SequenciaRemessa"]) : 0;
                oFields.CodigoEmpresaBanco = !DBNull.Value.Equals(oRow["CodigoEmpresaBanco"]) ? oRow["CodigoEmpresaBanco"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodBco)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Banco - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Banco - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaProfissao(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Profissao_Manager oManager = new Profissao_Manager(ConnectionString);
            Profissao_Fields oFields = new Profissao_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;
                oFields.Descricao = !DBNull.Value.Equals(oRow["Descricao"]) ? oRow["Descricao"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodProf)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Profissao - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Profissao - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaPromotor(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Promotor_Manager oManager = new Promotor_Manager(ConnectionString);
            Promotor_Fields oFields = new Promotor_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodPromotor = !DBNull.Value.Equals(oRow["codpromotor"]) ? Convert.ToInt32("0" + oRow["codpromotor"]) : 0;
                oFields.NomePromotor = !DBNull.Value.Equals(oRow["nomepromotor"]) ? oRow["nomepromotor"].ToString() : string.Empty;
                oFields.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;
                oFields.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;
                oFields.RamalFone1 = !DBNull.Value.Equals(oRow["ramalfone1"]) ? oRow["ramalfone1"].ToString() : string.Empty;
                oFields.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;
                oFields.RamalFone2 = !DBNull.Value.Equals(oRow["ramalfone2"]) ? oRow["ramalfone2"].ToString() : string.Empty;
                oFields.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;
                oFields.RamalFax = !DBNull.Value.Equals(oRow["ramalfax"]) ? oRow["ramalfax"].ToString() : string.Empty;
                oFields.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;
                oFields.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;
                oFields.Tipo = !DBNull.Value.Equals(oRow["tipo"]) ? oRow["tipo"].ToString() : string.Empty;
                oFields.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;
                oFields.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;
                oFields.Obs = !DBNull.Value.Equals(oRow["obs"]) ? oRow["obs"].ToString() : string.Empty;
                oFields.Status = !DBNull.Value.Equals(oRow["status"]) ? oRow["status"].ToString() : string.Empty;
                oFields.CodRestrito = !DBNull.Value.Equals(oRow["codrestrito"]) ? Convert.ToInt32("0" + oRow["codrestrito"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodPromotor)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Promotor - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Promotor - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaPosto(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Posto_Manager oManager = new Posto_Manager(ConnectionString);
            Posto_Fields oFields = new Posto_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_PostoVen = !DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0;
                oFields.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;
                oFields.DescPosto = !DBNull.Value.Equals(oRow["descposto"]) ? oRow["descposto"].ToString() : string.Empty;
                oFields.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;
                oFields.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;
                oFields.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;
                oFields.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;
                oFields.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;
                oFields.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;
                oFields.NomePosto = !DBNull.Value.Equals(oRow["nomeposto"]) ? oRow["nomeposto"].ToString() : string.Empty;
                oFields.CGC = !DBNull.Value.Equals(oRow["cgc"]) ? oRow["cgc"].ToString() : string.Empty;
                oFields.InscrMun = !DBNull.Value.Equals(oRow["inscrmun"]) ? oRow["inscrmun"].ToString() : string.Empty;
                oFields.Embratur = !DBNull.Value.Equals(oRow["embratur"]) ? oRow["embratur"].ToString() : string.Empty;
                oFields.Iata = !DBNull.Value.Equals(oRow["iata"]) ? oRow["iata"].ToString() : string.Empty;
                oFields.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;
                oFields.RestringeContas = !DBNull.Value.Equals(oRow["restringecontas"]) ? oRow["restringecontas"].ToString() : string.Empty;
                oFields.LogoTipo = oManager.GetPicture(!DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0);
                oFields.CodEmpIntCtb = !DBNull.Value.Equals(oRow["codempintctb"]) ? oRow["codempintctb"].ToString() : string.Empty;
                oFields.UltimaNFPosto = !DBNull.Value.Equals(oRow["ultimanfposto"]) ? Convert.ToInt32("0" + oRow["ultimanfposto"]) : 0;
                oFields.UltimaFaturaPosto = !DBNull.Value.Equals(oRow["ultimafaturaposto"]) ? Convert.ToInt32("0" + oRow["ultimafaturaposto"]) : 0;
                oFields.UltimReciboPosto = !DBNull.Value.Equals(oRow["ultimreciboposto"]) ? Convert.ToInt32("0" + oRow["ultimreciboposto"]) : 0;
                oFields.UltimaNFPostoFreta = !DBNull.Value.Equals(oRow["ultimanfpostofreta"]) ? Convert.ToInt32("0" + oRow["ultimanfpostofreta"]) : 0;
                oFields.OmiteNroNFRodape = !DBNull.Value.Equals(oRow["omitenronfrodape"]) ? oRow["omitenronfrodape"].ToString() : string.Empty;
                oFields.CodEmpNfe = !DBNull.Value.Equals(oRow["codempnfe"]) ? Convert.ToInt32("0" + oRow["codempnfe"]) : 0;
                oFields.ChavePrivadaNfe = !DBNull.Value.Equals(oRow["chaveprivadanfe"]) ? oRow["chaveprivadanfe"].ToString() : string.Empty;
                oFields.ChaveAcessoNfe = !DBNull.Value.Equals(oRow["chaveacessonfe"]) ? oRow["chaveacessonfe"].ToString() : string.Empty;
                oFields.RegimeEspTributa = !DBNull.Value.Equals(oRow["regimeesptributa"]) ? Convert.ToInt32("0" + oRow["regimeesptributa"]) : 0;
                oFields.OptanteSimplesNac = !DBNull.Value.Equals(oRow["optantesimplesnac"]) ? Convert.ToInt32("0" + oRow["optantesimplesnac"]) : 0;
                oFields.TributoMunicipio = !DBNull.Value.Equals(oRow["tributomunicipio"]) ? Convert.ToInt32("0" + oRow["tributomunicipio"]) : 0;
                oFields.SerieRPS = !DBNull.Value.Equals(oRow["serierps"]) ? oRow["serierps"].ToString() : string.Empty;
                oFields.TipoRPS = !DBNull.Value.Equals(oRow["tiporps"]) ? oRow["tiporps"].ToString() : string.Empty;
                oFields.NaturezaOperacao = !DBNull.Value.Equals(oRow["naturezaoperacao"]) ? Convert.ToInt32("0" + oRow["naturezaoperacao"]) : 0;
                oFields.IncentivadorCultural = !DBNull.Value.Equals(oRow["incentivadorcultural"]) ? Convert.ToInt32("0" + oRow["incentivadorcultural"]) : 0;
                oFields.AliquotaISS = !DBNull.Value.Equals(oRow["aliquotaiss"]) ? Convert.ToInt32("0" + oRow["aliquotaiss"]) : 0;
                oFields.CNAE = !DBNull.Value.Equals(oRow["cnae"]) ? Convert.ToInt32("0" + oRow["cnae"]) : 0;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_PostoVen)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Posto - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Posto - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaSituacao(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Situacao_Manager oManager = new Situacao_Manager(ConnectionString);
            Situacao_Fields oFields = new Situacao_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;
                oFields.DescSitCli = !DBNull.Value.Equals(oRow["DescSitCli"]) ? oRow["DescSitCli"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_SitCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Situacao - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Situacao - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaClassifica(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Classifica_Manager oManager = new Classifica_Manager(ConnectionString);
            Classifica_Fields oFields = new Classifica_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;
                oFields.DescTipoCli = !DBNull.Value.Equals(oRow["DescTipoCli"]) ? oRow["DescTipoCli"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_TipoCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Classifica - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Classifica - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
        static public void ImportaClientes(string Empresa, string Usuario, string Senha)
        {
            //********************
            //* Desencripta dados
            //********************
            svcDecisionExchanger.DecisionServicesSoapClient oService = new svcDecisionExchanger.DecisionServicesSoapClient();
            svcDecisionExchanger.RetornoWebService oResultado = new svcDecisionExchanger.RetornoWebService();
            Empresa = Crypto.DecryptString(Empresa);
            Usuario = Crypto.DecryptString(Usuario);
            Senha = Crypto.DecryptString(Senha);

            //******************
            //* Obtem datatable
            //******************
            DataSet oData = new DataSet();
            oData.ReadXml(new StringReader(Crypto.DecryptString(oResultado.XML)));

            //*********************
            //* Define gerenciador
            //*********************
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBTuris"].ConnectionString;
            Cliente_Manager oManager = new Cliente_Manager(ConnectionString);
            Cliente_Fields oFields = new Cliente_Fields();

            //********************************
            //* Realiza atualização da tabela
            //********************************
            foreach (DataRow oRow in oData.Tables[0].Rows)
            {
                //***************************
                //* Obtem valores dos campos
                //***************************
                oFields.PK_CodCli = !DBNull.Value.Equals(oRow["CodCli"]) ? Convert.ToInt32("0" + oRow["CodCli"]) : 0;
                oFields.Nome = !DBNull.Value.Equals(oRow["Nome"]) ? oRow["Nome"].ToString() : string.Empty;
                oFields.LocalTrab = !DBNull.Value.Equals(oRow["LocalTrab"]) ? oRow["LocalTrab"].ToString() : string.Empty;
                oFields.CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;
                oFields.CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
                oFields.TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;
                oFields.SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;
                oFields.PostoVen = !DBNull.Value.Equals(oRow["PostoVen"]) ? Convert.ToInt32("0" + oRow["PostoVen"]) : 0;
                oFields.CodPromotor = !DBNull.Value.Equals(oRow["CodPromotor"]) ? Convert.ToInt32("0" + oRow["CodPromotor"]) : 0;
                oFields.Titular = !DBNull.Value.Equals(oRow["Titular"]) ? oRow["Titular"].ToString() : string.Empty;
                oFields.MneCli = !DBNull.Value.Equals(oRow["MneCli"]) ? oRow["MneCli"].ToString() : string.Empty;
                oFields.LeiKandir = !DBNull.Value.Equals(oRow["LeiKandir"]) ? oRow["LeiKandir"].ToString() : string.Empty;
                oFields.StatusCli = !DBNull.Value.Equals(oRow["StatusCli"]) ? oRow["StatusCli"].ToString() : string.Empty;
                oFields.IndicePontosCli = !DBNull.Value.Equals(oRow["IndicePontosCli"]) ? Convert.ToDouble("0" + oRow["IndicePontosCli"]) : 0;
                oFields.PercentPontosCli = !DBNull.Value.Equals(oRow["PercentPontosCli"]) ? Convert.ToDouble("0" + oRow["PercentPontosCli"]) : 0;
                oFields.CodEmissor = !DBNull.Value.Equals(oRow["CodEmissor"]) ? Convert.ToInt32("0" + oRow["CodEmissor"]) : 0;
                oFields.CodTerceiro = !DBNull.Value.Equals(oRow["CodTerceiro"]) ? Convert.ToInt32("0" + oRow["CodTerceiro"]) : 0;
                oFields.GeraFatPDF = !DBNull.Value.Equals(oRow["GeraFatPDF"]) ? oRow["GeraFatPDF"].ToString() : string.Empty;
                oFields.AgrupaCodCtbForn = !DBNull.Value.Equals(oRow["AgrupaCodCtbForn"]) ? Convert.ToInt16("0" + oRow["AgrupaCodCtbForn"]) : (Int16)0;
                oFields.AgrupaTipoCobra = !DBNull.Value.Equals(oRow["AgrupaTipoCobra"]) ? Convert.ToInt16("0" + oRow["AgrupaTipoCobra"]) : (Int16)0;
                oFields.AgrupaCatProd = !DBNull.Value.Equals(oRow["AgrupaCatProd"]) ? Convert.ToInt16("0" + oRow["AgrupaCatProd"]) : (Int16)0;
                oFields.AgrupaProd = !DBNull.Value.Equals(oRow["AgrupaProd"]) ? Convert.ToInt16("0" + oRow["AgrupaProd"]) : (Int16)0;
                oFields.AgrupaForn = !DBNull.Value.Equals(oRow["AgrupaForn"]) ? Convert.ToInt16("0" + oRow["AgrupaForn"]) : (Int16)0;
                oFields.AgrupaCC = !DBNull.Value.Equals(oRow["AgrupaCC"]) ? Convert.ToInt16("0" + oRow["AgrupaCC"]) : (Int16)0;
                oFields.AgrupaPax = !DBNull.Value.Equals(oRow["AgrupaPax"]) ? Convert.ToInt16("0" + oRow["AgrupaPax"]) : (Int16)0;
                oFields.AgrupaReq = !DBNull.Value.Equals(oRow["AgrupaReq"]) ? Convert.ToInt16("0" + oRow["AgrupaReq"]) : (Int16)0;
                oFields.PeriodoFatura = !DBNull.Value.Equals(oRow["PeriodoFatura"]) ? oRow["PeriodoFatura"].ToString() : string.Empty;
                oFields.ItensFatura = !DBNull.Value.Equals(oRow["ItensFatura"]) ? Convert.ToInt16("0" + oRow["ItensFatura"]) : (Int16)0;
                oFields.AgrupaReqCliente = !DBNull.Value.Equals(oRow["AgrupaReqCliente"]) ? Convert.ToInt16("0" + oRow["AgrupaReqCliente"]) : (Int16)0;
                oFields.Contato = !DBNull.Value.Equals(oRow["Contato"]) ? oRow["Contato"].ToString() : string.Empty;
                oFields.Sexo = !DBNull.Value.Equals(oRow["Sexo"]) ? oRow["Sexo"].ToString() : string.Empty;
                oFields.EndRes = !DBNull.Value.Equals(oRow["EndRes"]) ? oRow["EndRes"].ToString() : string.Empty;
                oFields.FoneRes = !DBNull.Value.Equals(oRow["FoneRes"]) ? oRow["FoneRes"].ToString() : string.Empty;
                oFields.FaxRes = !DBNull.Value.Equals(oRow["FaxRes"]) ? oRow["FaxRes"].ToString() : string.Empty;
                oFields.CodCidadeRes = !DBNull.Value.Equals(oRow["CodCidadeRes"]) ? Convert.ToInt32("0" + oRow["CodCidadeRes"]) : 0;
                oFields.CEPRes = !DBNull.Value.Equals(oRow["CEPRes"]) ? oRow["CEPRes"].ToString() : string.Empty;
                oFields.TempoRes = !DBNull.Value.Equals(oRow["TempoRes"]) ? Convert.ToInt16("0" + oRow["TempoRes"]) : (Int16)0;
                oFields.Filiacao = !DBNull.Value.Equals(oRow["Filiacao"]) ? oRow["Filiacao"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["DataNasc"]))
                    oFields.DataNasc = Convert.ToDateTime(oRow["DataNasc"]);
                oFields.CIC = !DBNull.Value.Equals(oRow["CIC"]) ? oRow["CIC"].ToString() : string.Empty;
                oFields.RG = !DBNull.Value.Equals(oRow["RG"]) ? oRow["RG"].ToString() : string.Empty;
                oFields.Orgao = !DBNull.Value.Equals(oRow["Orgao"]) ? oRow["Orgao"].ToString() : string.Empty;
                oFields.RGUF = !DBNull.Value.Equals(oRow["RGUF"]) ? oRow["RGUF"].ToString() : string.Empty;
                oFields.Nacionalidade = !DBNull.Value.Equals(oRow["Nacionalidade"]) ? oRow["Nacionalidade"].ToString() : string.Empty;
                oFields.Naturalidade = !DBNull.Value.Equals(oRow["Naturalidade"]) ? oRow["Naturalidade"].ToString() : string.Empty;
                oFields.InscrEstadual = !DBNull.Value.Equals(oRow["InscrEstadual"]) ? oRow["InscrEstadual"].ToString() : string.Empty;
                oFields.CGC = !DBNull.Value.Equals(oRow["CGC"]) ? oRow["CGC"].ToString() : string.Empty;
                oFields.EstadoCivil = !DBNull.Value.Equals(oRow["EstadoCivil"]) ? oRow["EstadoCivil"].ToString() : string.Empty;
                oFields.EMail = !DBNull.Value.Equals(oRow["EMail"]) ? oRow["EMail"].ToString() : string.Empty;
                oFields.Passaporte = !DBNull.Value.Equals(oRow["Passaporte"]) ? oRow["Passaporte"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["ValidPassaporte"]))
                    oFields.ValidPassaporte = Convert.ToDateTime(oRow["ValidPassaporte"]);
                oFields.NomeVisto1 = !DBNull.Value.Equals(oRow["NomeVisto1"]) ? oRow["NomeVisto1"].ToString() : string.Empty;
                oFields.NomeVisto2 = !DBNull.Value.Equals(oRow["NomeVisto2"]) ? oRow["NomeVisto2"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["ValidVisto1"]))
                    oFields.ValidVisto1 = Convert.ToDateTime(oRow["ValidVisto1"]);
                if (!DBNull.Value.Equals(oRow["ValidVisto2"]))
                    oFields.ValidVisto2 = Convert.ToDateTime(oRow["ValidVisto2"]);
                oFields.EndTrab = !DBNull.Value.Equals(oRow["EndTrab"]) ? oRow["EndTrab"].ToString() : string.Empty;
                oFields.CodCidadeTrab = !DBNull.Value.Equals(oRow["CodCidadeTrab"]) ? Convert.ToInt32("0" + oRow["CodCidadeTrab"]) : 0;
                oFields.CEPTrab = !DBNull.Value.Equals(oRow["CEPTrab"]) ? oRow["CEPTrab"].ToString() : string.Empty;
                oFields.FoneTrab = !DBNull.Value.Equals(oRow["FoneTrab"]) ? oRow["FoneTrab"].ToString() : string.Empty;
                oFields.FaxTrab = !DBNull.Value.Equals(oRow["FaxTrab"]) ? oRow["FaxTrab"].ToString() : string.Empty;
                oFields.TempoTrab = !DBNull.Value.Equals(oRow["TempoTrab"]) ? Convert.ToInt16("0" + oRow["TempoTrab"]) : (Int16)0;
                oFields.Renda = !DBNull.Value.Equals(oRow["Renda"]) ? Convert.ToInt32("0" + oRow["Renda"]) : 0;
                oFields.RefCom = !DBNull.Value.Equals(oRow["RefCom"]) ? oRow["RefCom"].ToString() : string.Empty;
                oFields.FoneRefCom = !DBNull.Value.Equals(oRow["FoneRefCom"]) ? oRow["FoneRefCom"].ToString() : string.Empty;
                oFields.RefBco = !DBNull.Value.Equals(oRow["RefBco"]) ? oRow["RefBco"].ToString() : string.Empty;
                oFields.FoneRefBco = !DBNull.Value.Equals(oRow["FoneRefBco"]) ? oRow["FoneRefBco"].ToString() : string.Empty;
                oFields.Cia1 = !DBNull.Value.Equals(oRow["Cia1"]) ? oRow["Cia1"].ToString() : string.Empty;
                oFields.NroCia1 = !DBNull.Value.Equals(oRow["NroCia1"]) ? oRow["NroCia1"].ToString() : string.Empty;
                oFields.Cia2 = !DBNull.Value.Equals(oRow["Cia2"]) ? oRow["Cia2"].ToString() : string.Empty;
                oFields.NroCia2 = !DBNull.Value.Equals(oRow["NroCia2"]) ? oRow["NroCia2"].ToString() : string.Empty;
                oFields.Cia3 = !DBNull.Value.Equals(oRow["Cia3"]) ? oRow["Cia3"].ToString() : string.Empty;
                oFields.NroCia3 = !DBNull.Value.Equals(oRow["NroCia3"]) ? oRow["NroCia3"].ToString() : string.Empty;
                oFields.Cia4 = !DBNull.Value.Equals(oRow["Cia4"]) ? oRow["Cia4"].ToString() : string.Empty;
                oFields.NroCia4 = !DBNull.Value.Equals(oRow["NroCia4"]) ? oRow["NroCia4"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["DataCad"]))
                    oFields.DataCad = Convert.ToDateTime(oRow["DataCad"]);
                oFields.CodContabil = !DBNull.Value.Equals(oRow["CodContabil"]) ? oRow["CodContabil"].ToString() : string.Empty;
                oFields.Fumante = !DBNull.Value.Equals(oRow["Fumante"]) ? oRow["Fumante"].ToString() : string.Empty;
                oFields.Assento = !DBNull.Value.Equals(oRow["Assento"]) ? oRow["Assento"].ToString() : string.Empty;
                oFields.EndCobr = !DBNull.Value.Equals(oRow["EndCobr"]) ? oRow["EndCobr"].ToString() : string.Empty;
                oFields.CodCidadeCobr = !DBNull.Value.Equals(oRow["CodCidadeCobr"]) ? Convert.ToInt32("0" + oRow["CodCidadeCobr"]) : (Int16)0;
                oFields.CEPCobr = !DBNull.Value.Equals(oRow["CEPCobr"]) ? oRow["CEPCobr"].ToString() : string.Empty;
                oFields.EndCorresp = !DBNull.Value.Equals(oRow["EndCorresp"]) ? oRow["EndCorresp"].ToString() : string.Empty;
                oFields.SitCredito = !DBNull.Value.Equals(oRow["SitCredito"]) ? oRow["SitCredito"].ToString() : string.Empty;
                oFields.Observacoes = !DBNull.Value.Equals(oRow["Observacoes"]) ? oRow["Observacoes"].ToString() : string.Empty;
                oFields.CartaoCred1 = !DBNull.Value.Equals(oRow["CartaoCred1"]) ? oRow["CartaoCred1"].ToString() : string.Empty;
                oFields.CartaoCred2 = !DBNull.Value.Equals(oRow["CartaoCred2"]) ? oRow["CartaoCred2"].ToString() : string.Empty;
                oFields.CartaoCred3 = !DBNull.Value.Equals(oRow["CartaoCred3"]) ? oRow["CartaoCred3"].ToString() : string.Empty;
                oFields.CartaoCred4 = !DBNull.Value.Equals(oRow["CartaoCred4"]) ? oRow["CartaoCred4"].ToString() : string.Empty;
                oFields.NroCartao1 = !DBNull.Value.Equals(oRow["NroCartao1"]) ? oRow["NroCartao1"].ToString() : string.Empty;
                oFields.NroCartao2 = !DBNull.Value.Equals(oRow["NroCartao2"]) ? oRow["NroCartao2"].ToString() : string.Empty;
                oFields.NroCartao3 = !DBNull.Value.Equals(oRow["NroCartao3"]) ? oRow["NroCartao3"].ToString() : string.Empty;
                oFields.NroCartao4 = !DBNull.Value.Equals(oRow["NroCartao4"]) ? oRow["NroCartao4"].ToString() : string.Empty;
                oFields.ValidCartao1 = !DBNull.Value.Equals(oRow["ValidCartao1"]) ? oRow["ValidCartao1"].ToString() : string.Empty;
                oFields.ValidCartao2 = !DBNull.Value.Equals(oRow["ValidCartao2"]) ? oRow["ValidCartao2"].ToString() : string.Empty;
                oFields.ValidCartao3 = !DBNull.Value.Equals(oRow["ValidCartao3"]) ? oRow["ValidCartao3"].ToString() : string.Empty;
                oFields.ValidCartao4 = !DBNull.Value.Equals(oRow["ValidCartao4"]) ? oRow["ValidCartao4"].ToString() : string.Empty;
                oFields.TituloMala = !DBNull.Value.Equals(oRow["TituloMala"]) ? oRow["TituloMala"].ToString() : string.Empty;
                oFields.TipoPessoa = !DBNull.Value.Equals(oRow["TipoPessoa"]) ? oRow["TipoPessoa"].ToString() : string.Empty;
                oFields.VenctoCartao1 = !DBNull.Value.Equals(oRow["VenctoCartao1"]) ? oRow["VenctoCartao1"].ToString() : string.Empty;
                oFields.VenctoCartao2 = !DBNull.Value.Equals(oRow["VenctoCartao2"]) ? oRow["VenctoCartao2"].ToString() : string.Empty;
                oFields.VenctoCartao3 = !DBNull.Value.Equals(oRow["VenctoCartao3"]) ? oRow["VenctoCartao3"].ToString() : string.Empty;
                oFields.VenctoCartao4 = !DBNull.Value.Equals(oRow["VenctoCartao4"]) ? oRow["VenctoCartao4"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["DtUltimaAlteracao"]))
                    oFields.DtUltimaAlteracao = Convert.ToDateTime(oRow["DtUltimaAlteracao"]);
                oFields.UltimaAlteracaoPor = !DBNull.Value.Equals(oRow["UltimaAlteracaoPor"]) ? oRow["UltimaAlteracaoPor"].ToString() : string.Empty;
                if (!DBNull.Value.Equals(oRow["EmissVisto1"]))
                    oFields.EmissVisto1 = Convert.ToDateTime(oRow["EmissVisto1"]);
                if (!DBNull.Value.Equals(oRow["EmissVisto2"]))
                    oFields.EmissVisto2 = Convert.ToDateTime(oRow["EmissVisto2"]);
                oFields.Funcao = !DBNull.Value.Equals(oRow["Funcao"]) ? oRow["Funcao"].ToString() : string.Empty;
                oFields.ChaveLivre1 = !DBNull.Value.Equals(oRow["ChaveLivre1"]) ? oRow["ChaveLivre1"].ToString() : string.Empty;
                oFields.ChaveLivre2 = !DBNull.Value.Equals(oRow["ChaveLivre2"]) ? oRow["ChaveLivre2"].ToString() : string.Empty;
                oFields.AssinaNewsletter = !DBNull.Value.Equals(oRow["AssinaNewsletter"]) ? oRow["AssinaNewsletter"].ToString() : string.Empty;
                oFields.TipoNewsletter = !DBNull.Value.Equals(oRow["TipoNewsletter"]) ? oRow["TipoNewsletter"].ToString() : string.Empty;
                oFields.CreditoDinCC = !DBNull.Value.Equals(oRow["CreditoDinCC"]) ? oRow["CreditoDinCC"].ToString() : string.Empty;
                oFields.CreditoCheque = !DBNull.Value.Equals(oRow["CreditoCheque"]) ? oRow["CreditoCheque"].ToString() : string.Empty;
                oFields.CreditoOutros = !DBNull.Value.Equals(oRow["CreditoOutros"]) ? oRow["CreditoOutros"].ToString() : string.Empty;
                oFields.PotCres = !DBNull.Value.Equals(oRow["PotCres"]) ? oRow["PotCres"].ToString() : string.Empty;
                oFields.ValEstra = !DBNull.Value.Equals(oRow["ValEstra"]) ? oRow["ValEstra"].ToString() : string.Empty;
                oFields.ContaEBTA = !DBNull.Value.Equals(oRow["ContaEBTA"]) ? oRow["ContaEBTA"].ToString() : string.Empty;
                oFields.Fantasia = !DBNull.Value.Equals(oRow["Fantasia"]) ? oRow["Fantasia"].ToString() : string.Empty;
                oFields.Bairro = !DBNull.Value.Equals(oRow["Bairro"]) ? oRow["Bairro"].ToString() : string.Empty;
                oFields.TitularCartao1 = !DBNull.Value.Equals(oRow["TitularCartao1"]) ? oRow["TitularCartao1"].ToString() : string.Empty;
                oFields.TitularCartao2 = !DBNull.Value.Equals(oRow["TitularCartao2"]) ? oRow["TitularCartao2"].ToString() : string.Empty;
                oFields.TitularCartao3 = !DBNull.Value.Equals(oRow["TitularCartao3"]) ? oRow["TitularCartao3"].ToString() : string.Empty;
                oFields.CSCartao1 = !DBNull.Value.Equals(oRow["CSCartao1"]) ? oRow["CSCartao1"].ToString() : string.Empty;
                oFields.CSCartao2 = !DBNull.Value.Equals(oRow["CSCartao2"]) ? oRow["CSCartao2"].ToString() : string.Empty;
                oFields.CSCartao3 = !DBNull.Value.Equals(oRow["CSCartao3"]) ? oRow["CSCartao3"].ToString() : string.Empty;
                oFields.VlrTxBco = !DBNull.Value.Equals(oRow["VlrTxBco"]) ? Convert.ToDouble("0" + oRow["VlrTxBco"]) : 0;
                oFields.ContaCTA = !DBNull.Value.Equals(oRow["ContaCTA"]) ? oRow["ContaCTA"].ToString() : string.Empty;
                oFields.ContaVisa = !DBNull.Value.Equals(oRow["ContaVisa"]) ? oRow["ContaVisa"].ToString() : string.Empty;
                oFields.ObrigaCentroCusto = !DBNull.Value.Equals(oRow["ObrigaCentroCusto"]) ? oRow["ObrigaCentroCusto"].ToString() : string.Empty;
                oFields.ObrigaObservacao = !DBNull.Value.Equals(oRow["ObrigaObservacao"]) ? oRow["ObrigaObservacao"].ToString() : string.Empty;
                oFields.LimiteUnit = !DBNull.Value.Equals(oRow["LimiteUnit"]) ? Convert.ToDouble("0" + oRow["LimiteUnit"]) : 0;
                oFields.InscrMunicipal = !DBNull.Value.Equals(oRow["InscrMunicipal"]) ? oRow["InscrMunicipal"].ToString() : string.Empty;
                oFields.EMailNFSe = !DBNull.Value.Equals(oRow["EMailNFSe"]) ? oRow["EMailNFSe"].ToString() : string.Empty;

                //****************************
                //* Controla erro de execução
                //****************************
                try
                {
                    //**************************
                    //* Executa comando formado
                    //**************************
                    if (oManager.ApplyRecord(oFields, true) != oFields.PK_CodCli)
                        oResultado.Inserted++;
                    else
                        oResultado.Updated++;

                    //*************************
                    //* Houve erro na execução
                    //*************************
                    if (oManager.Error)
                    {
                        //*************************
                        //* Salva mensagem de erro
                        //*************************
                        oResultado.ErrorList.Add("Clientes - Importação: " + oManager.ErrorText);
                        oResultado.Error = true;
                        oResultado.Errors += 1;
                    }
                }
                catch (Exception oException)
                {
                    //*************************
                    //* Salva mensagem de erro
                    //*************************
                    oResultado.ErrorList.Add("Clientes - Importação: " + oException.Message);
                    oResultado.Error = true;
                    oResultado.Errors += 1;
                }
            }

            //*******************
            //* Exibe resultados
            //*******************
            if (oResultado.Error)
                foreach (string Erro in oResultado.ErrorList)
                    Console.Write(Erro + "\r\n");
            Console.Write("Inserções: " + oResultado.Inserted + ", Atualizações: " + oResultado.Updated + ", Erros:" + oResultado.Errors + "\r\n\r\n");
        }
    }
}
