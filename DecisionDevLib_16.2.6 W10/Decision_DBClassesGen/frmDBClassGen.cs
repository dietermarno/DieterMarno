using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using Decision.Lists;
using Decision.Database;
using Decision.Util;
using Decision.Extensions;
using Decision.TableManager;

namespace Decision_DBClassesGen
{
    public partial class frmDBClassGenerator : Form
    {
        public frmDBClassGenerator()
        {
            InitializeComponent();
        }
        private string GetFieldType(string TypeNameSize)
        {
            //****************************
            //* Remove números e símbolos
            //****************************
            string pattern = "[(0123456789),]";
            string replacement = "";
            Regex oRegularEx = new Regex(pattern);
            return oRegularEx.Replace(TypeNameSize, replacement).ToUpper();
        }
        private string GetFieldSize(string TypeNameSize)
        {
            //****************
            //* Obtem tamanho
            //****************
            return TypeNameSize.GetNumeric();
        }
        private string GetMasterConnection()
        {
            //**************
            //* Declarações
            //**************
            string Conexao = string.Empty;

            //***********************
            //* Obtem conexão MASTER
            //***********************
            System.Xml.Linq.XDocument oXdoc = System.Xml.Linq.XDocument.Load("Web.config");
            IEnumerable<XElement> oElements = oXdoc.Element("configuration").Element("connectionStrings").Elements();
            foreach (XElement oElement in oElements)
                if (oElement.Attribute("name").Value == "Master")
                {
                    Conexao = oElement.Attribute("connectionString").Value;
                    break;
                }

            //******************
            //* Retorna conexão
            //******************
            return Conexao;
        }
        private string GetDatabaseConnection(Int32 DatabaseID)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(GetMasterConnection());
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;

            //**********************************
            //* Obtem string de conexão MASTER
            //**********************************
            SQL = "SELECT conexao_driver,";
            SQL += "conexao_server,";
            SQL += "conexao_database,";
            SQL += "conexao_port,";
            SQL += "conexao_user,";
            SQL += "conexao_password ";
            SQL += "FROM agencias_cadastro ";
            SQL += "WHERE agencias_cadastro.codigo = " + DatabaseID;
            oTable = oDBManager.ExecuteQuery(SQL);

            //**********************
            //* A instância existe?
            //**********************
            if (oTable.Rows.Count == 1)
            {
                //*************************************************
                //* Obtem dados de conexão para montagem da string
                //*************************************************
                DataRow oRow = oTable.Rows[0];
                string conexao_driver = oRow.Field<string>("conexao_driver");
                string conexao_server = oRow.Field<string>("conexao_server");
                string conexao_database = oRow.Field<string>("conexao_database");
                string conexao_port = oRow.Field<object>("conexao_port").ToString();
                string conexao_user = oRow.Field<string>("conexao_user");
                string conexao_password = Crypto.DecryptString(oRow.Field<string>("conexao_password"));

                //********************
                //* Driver ODBC/MySQL
                //********************
                Conexao = String.Format("Driver={{{0}}};Server={1};Database={2};Port={3};UID={4};Password={5};persist security info=True;",
                                        conexao_driver, conexao_server, conexao_database, conexao_port, conexao_user, conexao_password);
            }

            //*****************
            //* Libera objetos
            //*****************
            oTable.Dispose();
            oDBManager.Dispose();

            //******************
            //* Retorna conexão
            //******************
            return Conexao;
        }
        private void GetDatabaseList()
        {
            //********************
            //* Declara variáveis
            //********************
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;

            //***************************
            //* Define string de conexão
            //***************************
            DBManager oDBManager = new DBManager(GetMasterConnection());

            //**********************************
            //* Obtem string de conexão MASTER
            //**********************************
            SQL = "SELECT codigo, conexao_nome FROM agencias_cadastro ORDER BY conexao_nome";
            oTable = oDBManager.ExecuteQuery(SQL);

            //************************
            //* Lista bancos de dados
            //************************
            this.cboDatabase.Properties.Items.Clear();
            foreach (DataRow oRow in oTable.Rows)
            {
                //*******************
                //* Insere novo ítem
                //*******************
                ComboItem oItem = new ComboItem(oRow["conexao_nome"].ToString(), Convert.ToInt32(oRow["codigo"]));
                this.cboDatabase.Properties.Items.Add(oItem);
            }

            //*****************
            //* Libera objetos
            //*****************
            oTable.Dispose();
            oDBManager.Dispose();
        }
        private void GetTableList(object oSelectedItem)
        {
            //****************************
            //* Obtem seleção de database
            //****************************
            ComboItem oItem = (ComboItem)oSelectedItem;

            //********************
            //* Declara variáveis
            //********************
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;

            //**************************************************
            //* Obtem string de conexão do database selecionado
            //**************************************************
            DBManager oDBManager = new DBManager(GetDatabaseConnection(Convert.ToInt32(oItem.id)));

            //**********************************
            //* Obtem string de conexão MASTER
            //**********************************
            SQL = "SHOW TABLES";
            oTable = oDBManager.ExecuteQuery(SQL);

            //****************************************
            //* Lista tabelas do banco de dados atual
            //****************************************
            this.cboTables.Properties.Items.Clear();
            foreach (DataRow oRow in oTable.Rows)
            {
                //*******************
                //* Insere novo ítem
                //*******************
                oItem = new ComboItem(oRow[0].ToString(), 0);
                this.cboTables.Properties.Items.Add(oItem);
            }

            //*****************
            //* Libera objetos
            //*****************
            oTable.Dispose();
            oDBManager.Dispose();
        }
        private void GetFieldList(object oSelectedItem)
        {
            //************************************
            //* Existe seleção de banco e tabela?
            //************************************
            if (this.cboDatabase.SelectedIndex == -1 || this.cboTables.SelectedIndex == -1)
                return;

            //****************************
            //* Obtem seleção de database
            //****************************
            ComboItem oItem = (ComboItem)oSelectedItem;

            //********************
            //* Declara variáveis
            //********************
            TreeListNode oNodeRoot = null;
            TreeListNode oNode = null;
            DataTable oTable = new DataTable();
            string Conexao = string.Empty;
            string SQL = string.Empty;

            //**************************************************
            //* Obtem string de conexão do database selecionado
            //**************************************************
            DBManager oDBManager = new DBManager(GetDatabaseConnection(Convert.ToInt32(((ComboItem)this.cboDatabase.SelectedItem).id)));

            //**********************************
            //* Obtem string de conexão MASTER
            //**********************************
            SQL = "DESCRIBE " + oItem.text;
            oTable = oDBManager.ExecuteQuery(SQL);

            //****************************************
            //* Lista tabelas do banco de dados atual
            //****************************************
            this.trvFields.ClearNodes();
            foreach (DataRow oRow in oTable.Rows)
            {
                //*******************
                //* Insere novo ítem
                //*******************
                oNode = this.trvFields.AppendNode(new object[] { oRow["Field"].ToString(),
                                                                 GetFieldType(oRow["Type"].ToString()),
                                                                 GetFieldSize(oRow["Type"].ToString()),
                                                                 oRow["Null"].ToString() == "YES" ? "SIM" : "NÃO",
                                                                 oRow["Extra"].ToString().IndexOf("auto_increment") > -1 ? "SIM" : "NÃO",
                                                                 oRow["Null"].ToString() == "NO",
                                                                 oRow["Key"].ToString() == "PRI"}, oNodeRoot);
            }

            //*****************
            //* Libera objetos
            //*****************
            oTable.Dispose();
            oDBManager.Dispose();
        }
        private string GetFunctionPrimaryKeys()
        {
            //**************
            //* Declarações
            //**************
            string PrimaryKeys = string.Empty;

            //******************
            //* Lista de campos
            //******************
            foreach (TreeListNode oNode in this.trvFields.Nodes)
            {
                //***************************************
                //* O campo faz parte da chave primária?
                //***************************************
                if (Convert.ToBoolean(oNode.GetValue(6)))
                {
                    //******************************
                    //* Deve acrescentar separador?
                    //******************************
                    if (PrimaryKeys != string.Empty)
                        PrimaryKeys += ", ";
                    
                    //***********************
                    //* Define tipo de dados
                    //***********************
                    switch (oNode.GetValue(1).ToString())
                    {
                        case "DATE":
                            PrimaryKeys += "DateTime? " + oNode.GetValue(0);
                            break;

                        case "DATETIME":
                            PrimaryKeys += "DateTime? " + oNode.GetValue(0);
                            break;

                        case "TINYINT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "TINYINT UNSIGNED":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "SMALLINT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "SMALLINT UNSIGNED":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "MEDIUMINT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "MEDIUMINT UNSIGNED":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "INT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "INT UNSIGNED":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "BIGINT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "BIGINT UNSIGNED":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "BIT":
                            PrimaryKeys += "Int32 " + oNode.GetValue(0);
                            break;

                        case "CHAR":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "VARCHAR":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "TINYTEXT":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "TEXT":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "MEDIUMTEXT":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "LONGTEXT":
                            PrimaryKeys += "string " + oNode.GetValue(0);
                            break;

                        case "FLOAT":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "FLOAT UNSIGNED":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "DOUBLE":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "DOUBLE UNSIGNED":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "DECIMAL":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "DECIMAL UNSIGNED":
                            PrimaryKeys += "double " + oNode.GetValue(0);
                            break;

                        case "TINYBLOB":
                            PrimaryKeys += "byte[] " + oNode.GetValue(0);
                            break;

                        case "BLOB":
                            PrimaryKeys += "byte[] " + oNode.GetValue(0);
                            break;

                        case "MEDIUMBLOB":
                            PrimaryKeys += "byte[] " + oNode.GetValue(0);
                            break;

                        case "LONGBLOB":
                            PrimaryKeys += "byte[] " + oNode.GetValue(0);
                            break;
                    }
                }
            }

            //***************************
            //* Retorna chaves primárias
            //***************************
            return PrimaryKeys;
        }
        private string GetQueryPrimaryKeys()
        {
            //**************
            //* Declarações
            //**************
            string PrimaryKeys = string.Empty;

            //******************
            //* Lista de campos
            //******************
            foreach (TreeListNode oNode in this.trvFields.Nodes)
            {
                //***************************************
                //* O campo faz parte da chave primária?
                //***************************************
                if (Convert.ToBoolean(oNode.GetValue(6)))
                {
                    //******************************
                    //* Deve acrescentar separador?
                    //******************************
                    if (PrimaryKeys != string.Empty)
                        PrimaryKeys += " AND ";
                    
                    //***********************
                    //* Define tipo de dados
                    //***********************
                    switch (oNode.GetValue(1).ToString())
                    {
                        case "DATE":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBDate() + \"";
                            break;

                        case "DATETIME":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBDate() + \"";
                            break;
                            
                        case "TINYINT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "TINYINT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "SMALLINT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "SMALLINT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "MEDIUMINT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "MEDIUMINT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "INT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "INT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;
                            
                        case "BIGINT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "BIGINT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;

                        case "BIT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToString() + \"";
                            break;
                            
                        case "CHAR":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "VARCHAR":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "TINYTEXT":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "TEXT":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "MEDIUMTEXT":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "LONGTEXT":
                            PrimaryKeys += oNode.GetValue(0) + " = '\" + " + oNode.GetValue(0) + ".ToString().SQLFilter() + \"'";
                            break;

                        case "FLOAT":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "FLOAT UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "DOUBLE":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "DOUBLE UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "DECIMAL":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "DECIMAL UNSIGNED":
                            PrimaryKeys += oNode.GetValue(0) + " = \" + " + oNode.GetValue(0) + ".ToDBNumeric(4) + \"";
                            break;

                        case "TINYBLOB":
                            PrimaryKeys += oNode.GetValue(0) + " = '0x\" + " + oNode.GetValue(0) + ".ToHexString() + \"'";
                            break;

                        case "BLOB":
                            PrimaryKeys += oNode.GetValue(0) + " = '0x\" + " + oNode.GetValue(0) + ".ToHexString() + \"'";
                            break;

                        case "MEDIUMBLOB":
                            PrimaryKeys += oNode.GetValue(0) + " = '0x\" + " + oNode.GetValue(0) + ".ToHexString() + \"'";
                            break;

                        case "LONGBLOB":
                            PrimaryKeys += oNode.GetValue(0) + " = '0x\" + " + oNode.GetValue(0) + ".ToHexString() + \"'";
                            break;
                    }
                }
            }

            //***************************
            //* Retorna chaves primárias
            //***************************
            if (PrimaryKeys.EndsWith(" + \""))
                PrimaryKeys = PrimaryKeys.Left(PrimaryKeys.Length - 4);
            if (PrimaryKeys.EndsWith(" + \"'"))
                PrimaryKeys += "\"";
            return PrimaryKeys;
        }
        private string GetCodeKeyName()
        {
            //**************
            //* Declarações
            //**************
            string PrimaryKey = string.Empty;

            //******************
            //* Lista de campos
            //******************
            foreach (TreeListNode oNode in this.trvFields.Nodes)
            {
                //**************************
                //* O campo é autonumerado?
                //**************************
                if (oNode.GetValue(4).ToString() == "SIM")
                {
                    //***************
                    //* Retorna nome
                    //***************
                    PrimaryKey = oNode.GetValue(0).ToString();
                }
            }

            //**************************
            //* O campo foi localizado?
            //**************************
            if (PrimaryKey == string.Empty)
            {
                //*******************************************
                //* Se não localizou, devolve chave primária
                //*******************************************
                foreach (TreeListNode oNode in this.trvFields.Nodes)
                {
                    //**************************
                    //* O campo é autonumerado?
                    //**************************
                    if (Convert.ToBoolean(oNode.GetValue(6)))
                    {
                        //***************
                        //* Retorna nome
                        //***************
                        PrimaryKey = oNode.GetValue(0).ToString();
                    }
                }
            }

            //******************
            //* Lista de campos
            //******************
            return PrimaryKey;
        }
        private void RemoveAllNameSpaces()
        {
            //********************************
            //* Remove todos os 30 namespaces
            //********************************
            for (int Counter = 0; Counter < 30; Counter++)
                AppConfig.RemoveSetting("ClassesGen_Includes" + Counter);
        }
        private void SaveAllNameSpaces()
        {
            //**********************************
            //* Atualiza todos os 30 namespaces
            //**********************************
            for (int Counter = 0; Counter < 30; Counter++)
                if (Counter < this.lstIncludes.Items.Count)
                    AppConfig.AddUpdateAppSettings("ClassesGen_Includes" + Counter, this.lstIncludes.Items[Counter].ToString().Trim());
        }
        private void LoadAppConfig()
        {
            //*************************
            //* Campos de configuração
            //*************************
            this.txtNameSpace.Text = AppConfig.ReadSetting("ClassesGen_NameSpace");

            //**************************
            //* Obtem lista de includes
            //**************************
            for (int Counter = 0; Counter < 30; Counter++)
                if (AppConfig.ReadSetting("ClassesGen_Includes" + Counter) != string.Empty)
                    this.lstIncludes.Items.Add(AppConfig.ReadSetting("ClassesGen_Includes" + Counter));

        }
        private string DefineIncludes()
        {
            //****************************
            //* Define inclusões da class
            //****************************
            string Includes = string.Empty;
            for (int Counter = 0; Counter < this.lstIncludes.Items.Count; Counter++)
                Includes += "using " + this.lstIncludes.Items[Counter].ToString() + ";\r\n";
            return Includes;
        }
        private string DefineNameSpace()
        {
            //*******************
            //* Define NameSpace
            //*******************
            string NameSpace = string.Empty;
            NameSpace += "namespace " + this.txtNameSpace.Text.Trim() + "\r\n";
            NameSpace += "{\r\n";
            NameSpace += "<C>";
            NameSpace += "}\r\n";
            return NameSpace;
        }
        private string DefineDataClass()
        {
            //**************
            //* Declarações
            //**************
            string PrivateMembers = string.Empty;
            string PublicMembers = string.Empty;
            string StartMembers = string.Empty;

            //*******************
            //* Linha de chamada
            //*******************
            PrivateMembers += "\tpublic class " + this.txtNomeClasseDados.Text.Trim() + "\r\n";
            PrivateMembers += "\t{\r\n";

            StartMembers += "\t\tpublic " + this.txtNomeClasseDados.Text.Trim() + "()" + "\r\n";
            StartMembers += "\t\t{\r\n";

            //**************
            //* Comentários
            //**************
            PrivateMembers += "\t\t//*********************\r\n";
            PrivateMembers += "\t\t//* Variáveis privadas \r\n";
            PrivateMembers += "\t\t//*********************\r\n";

            PublicMembers += "\t\t//*******************\r\n";
            PublicMembers += "\t\t//* Campos da tabela \r\n";
            PublicMembers += "\t\t//*******************\r\n";

            StartMembers += "\t\t\t//****************\r\n";
            StartMembers += "\t\t\t//* Inicialização \r\n";
            StartMembers += "\t\t\t//****************\r\n";

            //******************
            //* Lista de campos
            //******************
            foreach (TreeListNode oNode in this.trvFields.Nodes)
            {
                //***********************
                //* Define tipo de dados
                //***********************
                switch (oNode.GetValue(1).ToString())
                {
                    case "DATE":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = null;\r\n";
                        PrivateMembers += "\t\tprivate DateTime? _" + oNode.GetValue(0) + " = null;\r\n";
                        PublicMembers += "\t\tpublic DateTime? " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;
                    
                    case "DATETIME":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = null;\r\n";
                        PrivateMembers += "\t\tprivate DateTime? _" + oNode.GetValue(0) + " = null;\r\n";
                        PublicMembers += "\t\tpublic DateTime? " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "TINYINT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "TINYINT UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "SMALLINT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "SMALLINT UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "MEDIUMINT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "MEDIUMINT_UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "INT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "INT UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "BIGINT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "BIGINT UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "BIT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate Int32 _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic Int32 " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "CHAR":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + ".Left(" + oNode.GetValue(2) + "); } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "VARCHAR":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + ".Left(" + oNode.GetValue(2) + "); } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "TINYTEXT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "TEXT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "MEDIUMTEXT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "LONGTEXT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PrivateMembers += "\t\tprivate string _" + oNode.GetValue(0) + " = string.Empty;\r\n";
                        PublicMembers += "\t\tpublic string " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "FLOAT":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "FLOAT UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "DOUBLE":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "DOUBLE UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "DECIMAL":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "DECIMAL UNSIGNED":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = 0;\r\n";
                        PrivateMembers += "\t\tprivate double _" + oNode.GetValue(0) + " = 0;\r\n";
                        PublicMembers += "\t\tpublic double " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "TINYBLOB":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = new byte[0];\r\n";
                        PrivateMembers += "\t\tprivate byte[] _" + oNode.GetValue(0) + " = {};\r\n";
                        PublicMembers += "\tpublic byte[] " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "BLOB":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = new byte[0];\r\n";
                        PrivateMembers += "\t\tprivate byte[] _" + oNode.GetValue(0) + " = {};\r\n";
                        PublicMembers += "\t\tpublic byte[] " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "MEDIUMBLOB":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = new byte[0];\r\n";
                        PrivateMembers += "\t\tprivate byte[] _" + oNode.GetValue(0) + " = {};\r\n";
                        PublicMembers += "\t\tpublic byte[] " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;

                    case "LONGBLOB":
                        StartMembers += "\t\t\t_" + oNode.GetValue(0) + " = new byte[0];\r\n";
                        PrivateMembers += "\t\tprivate byte[] _" + oNode.GetValue(0) + " = {};\r\n";
                        PublicMembers += "\t\tpublic byte[] " + oNode.GetValue(0) + " { get { return _" + oNode.GetValue(0) + "; } set { _" + oNode.GetValue(0) + " = value; } }\r\n";
                        break;
                }
            }

            //***********
            //* Finaliza
            //***********
            PrivateMembers += "\r\n";
            StartMembers += "\t\t}\r\n";

            //**************************
            //* Retorna classe de dados
            //**************************
            return PrivateMembers + PublicMembers + "\r\n" + StartMembers + "\t}\r\n";
        }
        private string DefineManagerClass()
        {
            //**************
            //* Declarações
            //**************
            string ClassDeclaration = string.Empty;
            string ApplyRecord = string.Empty;
            string GetRecord = string.Empty;
            string DeleteRecord = string.Empty;
            string DataRestore = string.Empty;
            string ReplaceFields = string.Empty;
            string ReplaceData = string.Empty;

            //*******************
            //* Linha de chamada
            //*******************
            ClassDeclaration += "\tpublic class " + this.txtNomeClasseGerenciamento.Text.Trim() + "\r\n";
            ClassDeclaration += "\t{\r\n";
            ClassDeclaration += "\t\t//***************\r\n";
            ClassDeclaration += "\t\t//* Propriedades \r\n";
            ClassDeclaration += "\t\t//***************\r\n";
            ClassDeclaration += "\t\tprivate bool _Error = false;\r\n";
            ClassDeclaration += "\t\tprivate string _ErrorText = string.Empty;\r\n";
            ClassDeclaration += "\t\tprivate string _ConnectionString;\r\n";
            ClassDeclaration += "\t\tpublic bool Error { get { return _Error; } }\r\n";
            ClassDeclaration += "\t\tpublic string ErrorText { get { return _ErrorText; } }\r\n";
            ClassDeclaration += "\t\tpublic string ConnectionString { get { return _ConnectionString; } }\r\n";
            ClassDeclaration += "\r\n";
            ClassDeclaration += "\t\tpublic " + this.txtNomeClasseGerenciamento.Text.Trim() + "(string DBConnectionString)\r\n";
            ClassDeclaration += "\t\t{\r\n";
            ClassDeclaration += "\t\t\t//*****************\r\n";
            ClassDeclaration += "\t\t\t//* Define conexão \r\n";
            ClassDeclaration += "\t\t\t//*****************\r\n";
            ClassDeclaration += "\t\t\t_ConnectionString = DBConnectionString;\r\n";
            ClassDeclaration += "\t\t}\r\n";
            ClassDeclaration += "\t\t<C>";
            ClassDeclaration += "\t}";
            ClassDeclaration += "\r\n";

            //*********************
            //* Função ApplyRecord
            //*********************
            ApplyRecord += "\t\tpublic Int32 ApplyRecord(" + this.txtNomeClasseDados.Text.Trim() + " o" + this.txtNomeClasseDados.Text.Trim() + ")\r\n";
            ApplyRecord += "\t\t{\r\n";
            ApplyRecord += "\t\t\t//**************\r\n";
            ApplyRecord += "\t\t\t//* Declarações \r\n";
            ApplyRecord += "\t\t\t//**************\r\n";
            ApplyRecord += "\t\t\tDBManager oDBManager = new DBManager(ConnectionString);\r\n";
            ApplyRecord += "\t\t\tstring SQL = string.Empty;\r\n";
            ApplyRecord += "\r\n";
            ApplyRecord += "\t\t\t//******************************\r\n";
            ApplyRecord += "\t\t\t//* Atualiza ou insere registro \r\n";
            ApplyRecord += "\t\t\t//******************************\r\n";
            ApplyRecord += "\t\t\tSQL = \"REPLACE INTO " + ((ComboItem)this.cboTables.SelectedItem).text.Trim() + " (\";\r\n";
            ApplyRecord += "<C>\r\n";
            ApplyRecord += "\t\t\t//****************************\r\n";
            ApplyRecord += "\t\t\t//* Controla erro de execução \r\n";
            ApplyRecord += "\t\t\t//****************************\r\n";
            ApplyRecord += "\t\t\ttry\r\n";
            ApplyRecord += "\t\t\t{\r\n";
            ApplyRecord += "\t\t\t\t//**************************\r\n";
            ApplyRecord += "\t\t\t\t//* Executa comando formado \r\n";
            ApplyRecord += "\t\t\t\t//**************************\r\n";
            ApplyRecord += "\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + GetCodeKeyName() + " = oDBManager.ExecuteCommand(SQL);\r\n";
            ApplyRecord += "\t\t\t\t\r\n";
            ApplyRecord += "\t\t\t\t//************************************\r\n";
            ApplyRecord += "\t\t\t\t//* Devolve status e mensagem de erro \r\n";
            ApplyRecord += "\t\t\t\t//************************************\r\n";
            ApplyRecord += "\t\t\t\t_ErrorText = oDBManager.ErrorMessage;\r\n";
            ApplyRecord += "\t\t\t\t_Error = oDBManager.Error;\r\n";
            ApplyRecord += "\t\t\t}\r\n";
            ApplyRecord += "\t\t\tcatch (Exception oException)\r\n";
            ApplyRecord += "\t\t\t{\r\n";
            ApplyRecord += "\t\t\t\t//************************************\r\n";
            ApplyRecord += "\t\t\t\t//* Devolve status e mensagem de erro \r\n";
            ApplyRecord += "\t\t\t\t//************************************\r\n";
            ApplyRecord += "\t\t\t\t_ErrorText = oException.Message;\r\n";
            ApplyRecord += "\t\t\t\t_Error = true;\r\n";
            ApplyRecord += "\t\t\t}\r\n";
            ApplyRecord += "\t\t\t\r\n";
            ApplyRecord += "\t\t\t//*************************\r\n";
            ApplyRecord += "\t\t\t//* Retorna chave primária\r\n";
            ApplyRecord += "\t\t\t//*************************\r\n";
            ApplyRecord += "\t\t\treturn o" + this.txtNomeClasseDados.Text.Trim() + "." + GetCodeKeyName() + ";\r\n";
            ApplyRecord += "\t\t}\r\n";
            
            //*******************
            //* Função GetRecord
            //*******************
            GetRecord += "\t\tpublic " + this.txtNomeClasseDados.Text.Trim() + " GetRecord(" + GetFunctionPrimaryKeys() + ")\r\n";
            GetRecord += "\t\t{\r\n";
            GetRecord += "\t\t\t//**************\r\n";
            GetRecord += "\t\t\t//* Declarações \r\n";
            GetRecord += "\t\t\t//**************\r\n";
            GetRecord += "\t\t\t" + this.txtNomeClasseDados.Text.Trim() + " o" + this.txtNomeClasseDados.Text.Trim() + " = new " + this.txtNomeClasseDados.Text.Trim() + "();\r\n";
            GetRecord += "\t\t\tDBManager oDBManager = new DBManager(ConnectionString);\r\n";
            GetRecord += "\t\t\tDataTable oTable = new DataTable();\r\n";
            GetRecord += "\t\t\tstring SQL = string.Empty;\r\n";
            GetRecord += "\r\n";
            GetRecord += "\t\t\t//****************************\r\n";
            GetRecord += "\t\t\t//* Controla erro de execução \r\n";
            GetRecord += "\t\t\t//****************************\r\n";
            GetRecord += "\t\t\ttry\r\n";
            GetRecord += "\t\t\t{\r\n";
            GetRecord += "\t\t\t\t//*****************\r\n";
            GetRecord += "\t\t\t\t//* Obtem registro \r\n";
            GetRecord += "\t\t\t\t//*****************\r\n";
            GetRecord += "\t\t\t\tSQL = \"SELECT * FROM " + ((ComboItem)this.cboTables.SelectedItem).text.Trim() + " WHERE " + GetQueryPrimaryKeys() + ";\r\n";
            GetRecord += "\t\t\t\toTable = oDBManager.ExecuteQuery(SQL);\r\n";
            GetRecord += "\r\n";
            GetRecord += "\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t//* Devolve status e mensagem de erro \r\n";
            GetRecord += "\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t_ErrorText = oDBManager.ErrorMessage;\r\n";
            GetRecord += "\t\t\t\t_Error = oDBManager.Error;\r\n";
            GetRecord += "\t\t\t}\r\n";
            GetRecord += "\t\t\tcatch (Exception oException)\r\n";
            GetRecord += "\t\t\t{\r\n";
            GetRecord += "\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t//* Devolve status e mensagem de erro\r\n";
            GetRecord += "\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t_ErrorText = oException.Message;\r\n";
            GetRecord += "\t\t\t\t_Error = true;\r\n";
            GetRecord += "\t\t\t}\r\n";
            GetRecord += "\r\n";
            GetRecord += "\t\t\t//*********************************\r\n";
            GetRecord += "\t\t\t//* A pesquisa retornou registros? \r\n";
            GetRecord += "\t\t\t//*********************************\r\n";
            GetRecord += "\t\t\tif (oTable != null)\r\n";
            GetRecord += "\t\t\t{\r\n";
            GetRecord += "\t\t\t\t//**********************************\r\n";
            GetRecord += "\t\t\t\t//* A pesquisa localizou o registro? \r\n";
            GetRecord += "\t\t\t\t//***********************************\r\n";
            GetRecord += "\t\t\t\tif (oTable.Rows.Count == 1)\r\n";
            GetRecord += "\t\t\t\t{\r\n";
            GetRecord += "\t\t\t\t\t//*******************************\r\n";
            GetRecord += "\t\t\t\t\t//* Copia dados para a estrutura \r\n";
            GetRecord += "\t\t\t\t\t//*******************************\r\n";
            GetRecord += "\t\t\t\t\tDataRow oRow = oTable.Rows[0];\r\n";
            GetRecord += "<C>";
            GetRecord += "\t\t\t\t}\r\n";
            GetRecord += "\t\t\t\telse\r\n";
            GetRecord += "\t\t\t\t{\r\n";
            GetRecord += "\t\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t\t//* Devolve status e mensagem de erro \r\n";
            GetRecord += "\t\t\t\t\t//************************************\r\n";
            GetRecord += "\t\t\t\t\t_ErrorText = \"O resultado da pesquisa retornou nulo\";\r\n";
            GetRecord += "\t\t\t\t\t_Error = true;\r\n";
            GetRecord += "\t\t\t\t}\r\n";
            GetRecord += "\t\t\t}\r\n";
            GetRecord += "\t\t\t\r\n";
            GetRecord += "\t\t\t//****************\r\n";
            GetRecord += "\t\t\t//* Retorna dados \r\n";
            GetRecord += "\t\t\t//****************\r\n";
            GetRecord += "\t\t\treturn o" + this.txtNomeClasseDados.Text.Trim() + ";\r\n";
            GetRecord += "\t\t}\r\n";

            //**********************
            //* Função DeleteRecord
            //**********************
            DeleteRecord += "\t\tpublic bool DeleteRecord(" + GetFunctionPrimaryKeys() + ")\r\n";
            DeleteRecord += "\t\t{\r\n";
            DeleteRecord += "\t\t\t//**************\r\n";
            DeleteRecord += "\t\t\t//* Declarações \r\n";
            DeleteRecord += "\t\t\t//**************\r\n";
            DeleteRecord += "\t\t\tDBManager oDBManager = new DBManager(ConnectionString);\r\n";
            DeleteRecord += "\t\t\tstring SQL = string.Empty;\r\n";
            DeleteRecord += "\t\t\t\r\n";
            DeleteRecord += "\t\t\t//********************************\r\n";
            DeleteRecord += "\t\t\t//* O código do cliente é válido?\r\n";
            DeleteRecord += "\t\t\t//********************************\r\n";
            DeleteRecord += "\t\t\ttry\r\n";
            DeleteRecord += "\t\t\t{\r\n";
            DeleteRecord += "\t\t\t\t//******************\r\n";
            DeleteRecord += "\t\t\t\t//* Exclui registro \r\n";
            DeleteRecord += "\t\t\t\t//******************\r\n";
            DeleteRecord += "\t\t\t\tSQL = \"DELETE FROM " + ((ComboItem)this.cboTables.SelectedItem).text.Trim() + " WHERE " + GetQueryPrimaryKeys() + ";\r\n";
            DeleteRecord += "\t\t\t\toDBManager.ExecuteCommand(SQL);\r\n";
            DeleteRecord += "\t\t\t\t\r\n";
            DeleteRecord += "\t\t\t\t//************************************\r\n";
            DeleteRecord += "\t\t\t\t//* Devolve status e mensagem de erro \r\n";
            DeleteRecord += "\t\t\t\t//************************************\r\n";
            DeleteRecord += "\t\t\t\t_ErrorText = oDBManager.ErrorMessage;\r\n";
            DeleteRecord += "\t\t\t\t_Error = oDBManager.Error;\r\n";
            DeleteRecord += "\t\t\t\treturn true;\r\n";
            DeleteRecord += "\t\t\t}\r\n";
            DeleteRecord += "\t\t\tcatch (Exception oException)\r\n";
            DeleteRecord += "\t\t\t{\r\n";
            DeleteRecord += "\t\t\t\t//************************************\r\n";
            DeleteRecord += "\t\t\t\t//* Devolve status e mensagem de erro\r\n";
            DeleteRecord += "\t\t\t\t//************************************\r\n";
            DeleteRecord += "\t\t\t\t_ErrorText = oException.Message;\r\n";
            DeleteRecord += "\t\t\t\t_Error = true;\r\n";
            DeleteRecord += "\t\t\t\treturn false;\r\n";
            DeleteRecord += "\t\t\t}\r\n";
            DeleteRecord += "\t\t}\r\n";

            //******************
            //* Lista de campos
            //******************
            foreach (TreeListNode oNode in this.trvFields.Nodes)
            {
                //******************************
                //* Nomeção de campos (REPLACE)
                //******************************
                ReplaceFields += "\t\t\tSQL += \"" + oNode.GetValue(0) + ",\";\r\n";

                //***********************
                //* Define tipo de dados
                //***********************
                switch (oNode.GetValue(1).ToString())
                {
                    case "DATE":
                        DataRestore += "\t\t\t\t\tif (!DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]))\r\n";
                        DataRestore += "\t\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = Convert.ToDateTime(oRow[\"" + oNode.GetValue(0) + "\"]);\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBDate() + \",\";\r\n";
                        break;

                    case "DATETIME":
                        DataRestore += "\t\t\t\t\tif (!DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]))\r\n";
                        DataRestore += "\t\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = Convert.ToDateTime(oRow[\"" + oNode.GetValue(0) + "\"]);\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBDate() + \",\";\r\n";
                        break;

                    case "TINYINT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "TINYINT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "SMALLINT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "SMALLINT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "MEDIUMINT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "MEDIUMINT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "INT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "INT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "BIGINT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "BIGINT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "BIT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToInt32(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \",\";\r\n";
                        break;

                    case "CHAR":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "VARCHAR":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "TINYTEXT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "TEXT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "MEDIUMTEXT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "LONGTEXT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? oRow[\"" + oNode.GetValue(0) + "\"].ToString() : string.Empty;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToString() + \"',\";\r\n";
                        break;

                    case "FLOAT":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "FLOAT UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "DOUBLE":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "DOUBLE UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "DECIMAL":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "DECIMAL UNSIGNED":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? Convert.ToDouble(\"0\" + oRow[\"" + oNode.GetValue(0) + "\"]) : 0;\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToDBNumeric(6) + \",\";\r\n";
                        break;

                    case "TINYBLOB":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? (byte[])oRow[\"" + oNode.GetValue(0) + "\"] : \"0x\";\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToHexString() + '\",\";\r\n";
                        break;
                        
                    case "BLOB":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? (byte[])oRow[\"" + oNode.GetValue(0) + "\"] : \"0x\";\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToHexString() + '\",\";\r\n";
                        break;

                    case "MEDIUMBLOB":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? (byte[])oRow[\"" + oNode.GetValue(0) + "\"] : \"0x\";\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToHexString() + '\",\";\r\n";
                        break;

                    case "LONGBLOB":
                        DataRestore += "\t\t\t\t\to" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + " = !DBNull.Value.Equals(oRow[\"" + oNode.GetValue(0) + "\"]) ? (byte[])oRow[\"" + oNode.GetValue(0) + "\"] : \"0x\";\r\n";
                        ReplaceData += "\t\t\tSQL += \"'\" + o" + this.txtNomeClasseDados.Text.Trim() + "." + oNode.GetValue(0) + ".ToHexString() + '\",\";\r\n";
                        break;
                }
            }

            //***************************
            //* Finaliza lista de campos
            //***************************
            if (ReplaceData.EndsWith(" + \",\";\r\n"))
                ReplaceData = ReplaceData.Left(ReplaceData.Length - 9);
            if (ReplaceData.EndsWith(" + \"',\";\r\n"))
                ReplaceData += ReplaceData.Left(ReplaceData.Length - 5) + "\"";

            //**************************
            //* Retorna classe de dados
            //**************************
            string FinalClass = string.Empty;
            FinalClass += ApplyRecord.Replace("<C>", ReplaceFields.Left(ReplaceFields.Length - 5) + "\";\r\n" + 
                                              "\t\t\tSQL += \") VALUES (\";\r\n" +  ReplaceData + " + \")\";\r\n");
            FinalClass += "\r\n";
            FinalClass += GetRecord.Replace("<C>", DataRestore);
            FinalClass += "\r\n";
            FinalClass += DeleteRecord;
            FinalClass = ClassDeclaration.Replace("<C>", "\r\n" + FinalClass);
            return FinalClass;
        }
        private string GenerateClasses()
        {
            //**************
            //* Declarações
            //**************
            string FinalClass = string.Empty;

            //****************
            //* Define seções
            //****************
            FinalClass += DefineIncludes() + "\r\n";
            FinalClass += DefineNameSpace().Replace("<C>", DefineDataClass() + "\r\n" + DefineManagerClass());

            //***********************
            //* Retorna string final
            //***********************
            return FinalClass;
        }
        private void frmDBClassGenerator_Load(object sender, EventArgs e)
        {
            //**********************
            //* Obtem configurações
            //**********************
            LoadAppConfig();

            //***************************
            //* Obtem lista de databases
            //***************************
            GetDatabaseList();
        }
        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            //***************************
            //* Obtem lista de databases
            //***************************
            if (this.cboDatabase.SelectedIndex != -1)
            {
                GetTableList(this.cboDatabase.EditValue);
                this.cboTables.Focus();
            }
        }
        private void cboTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //***************************
            //* Obtem lista de databases
            //***************************
            if (this.cboTables.SelectedIndex != -1)
            {
                //*********************************************
                //* Nome da classe de dados e de gerenciamento
                //*********************************************
                string TableName = ((ComboItem)this.cboTables.EditValue).text;
                string ClassName = string.Empty;
                if (TableName.Length > 0)
                    ClassName += TableName.Substring(0, 1).ToUpper();
                if (TableName.Length > 1)
                    ClassName += TableName.Right(TableName.Length - 1).ToLower();
                this.txtNomeClasseDados.Text = ClassName + "_Fields";
                this.txtNomeClasseGerenciamento.Text = ClassName + "_Manager";

                //******************
                //* Lista de campos
                //******************
                GetFieldList(this.cboTables.EditValue);
                this.trvFields.Focus();
            }
        }
        private void cmdAdicionaInclude_Click(object sender, EventArgs e)
        {
            //**********************************
            //* O usuário informou IDNameSpace?
            //**********************************
            if (this.txtIDNameSpace.Text.Trim() == string.Empty)
            {
                string Message = "Por favor, informe a identificação do NameSpace.";
                MessageBox.Show(Message, "Inclusão de NameSpace");
                return;
            }

            //*******************
            //* Salva Name Space
            //*******************
            this.lstIncludes.Items.Add(this.txtIDNameSpace.Text.Trim());
            RemoveAllNameSpaces();
            SaveAllNameSpaces();
            this.txtIDNameSpace.ResetText();
            this.txtIDNameSpace.Focus();
        }
        private void cmdDeleteInclude_Click(object sender, EventArgs e)
        {
            //*********************************
            //* Existe seleção de IDNameSpace?
            //*********************************
            if (this.lstIncludes.SelectedIndex == -1)
            {
                string Message = "Por favor, selecione a identificação do NameSpace.";
                MessageBox.Show(Message, "Exclusão de NameSpace");
                return;
            }

            //*******************
            //* Salva Name Space
            //*******************
            this.lstIncludes.Items.RemoveAt(this.lstIncludes.SelectedIndex);
            RemoveAllNameSpaces();
            SaveAllNameSpaces();
            this.txtIDNameSpace.Focus();
        }
        private void txtNameSpace_Leave(object sender, EventArgs e)
        {
            //*********************
            //* Atualiza namespace
            //*********************
            AppConfig.AddUpdateAppSettings("ClassesGen_NameSpace", this.txtNameSpace.Text.Trim());
        }
        private void cmdCopiar_Click(object sender, EventArgs e)
        {
            //****************************
            //* A tabela foi selecionada?
            //****************************
            if (this.cboTables.SelectedIndex != -1)
            {
                //***************
                //* Gera classes
                //***************
                string GeneratedClasses = GenerateClasses();
                Clipboard.Clear();
                Clipboard.SetText(GeneratedClasses);
            }
        }
        private void cmdExibir_Click(object sender, EventArgs e)
        {
            //****************************
            //* A tabela foi selecionada?
            //****************************
            if (this.cboTables.SelectedIndex != -1)
            {
                //********************************
                //* Exibe diálogo de visualização
                //********************************
                this.memVisualizacao.Text = GenerateClasses();
                this.grcVisualizacao.Location = new Point(0, 0);
                this.grcVisualizacao.Width = this.Size.Width - 18;
                this.grcVisualizacao.Height = this.Size.Height - 38;
                this.grcVisualizacao.Show();
            }
        }
        private void cmdAnalisar_Click(object sender, EventArgs e)
        {
            //***************************
            //* Obtem lista de databases
            //***************************
            if (this.cboTables.SelectedIndex != -1)
            {
                //*********************************************
                //* Nome da classe de dados e de gerenciamento
                //*********************************************
                string TableName = ((ComboItem)this.cboTables.EditValue).text;
                string ClassName = string.Empty;
                if (TableName.Length > 0)
                    ClassName += TableName.Substring(0, 1).ToUpper();
                if (TableName.Length > 1)
                    ClassName += TableName.Right(TableName.Length - 1).ToLower();
                this.txtNomeClasseDados.Text = ClassName + "_Fields";
                this.txtNomeClasseGerenciamento.Text = ClassName + "_Manager";

                //******************
                //* Lista de campos
                //******************
                GetFieldList(this.cboTables.EditValue);
                this.trvFields.Focus();
            }
        }
        private void cmdFecharVisualizador_Click(object sender, EventArgs e)
        {
            //***********************
            //* Esconde visualização
            //***********************
            this.grcVisualizacao.Hide();
        }
    }
}
