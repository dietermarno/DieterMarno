using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Runtime.InteropServices;
using DevExpress.Web;
using Decision.Extensions;
using Decision.LoginManager;
using Decision.Database;
using Decision.Lists;
using Decision.Util;

namespace Decision.Secutiry
{
    public class Security_Fields
    {
        //*****************************************
        //* Propriedades de uma chave de segurança
        //*****************************************
        private Int32 _CodigoAgrupamento = 0;
        private Int32 _CodigoPermissao = 0;
        private Int32 _CodigoGrupo = 0;
        private string _DescricaoGrupo = string.Empty;
        private string _ChavePermissao = string.Empty;
        private string _DescricaoPermissao = string.Empty;
        private string _Posicao = string.Empty;
        private bool _Simples = false;
        private bool _Autorizacao = false;
        private bool _Inclusao = false;
        private bool _Alteracao = false;
        private bool _Exclusao = false;
        public Int32 CodigoAgrupamento { get { return _CodigoAgrupamento; } set { _CodigoAgrupamento = value; } }
        public Int32 CodigoPermissao { get { return _CodigoPermissao; } set { _CodigoPermissao = value; } }
        public Int32 CodigoGrupo { get { return _CodigoGrupo; } set { _CodigoGrupo = value; } }
        public Int32 DescricaoGrupo { get { return _CodigoGrupo; } set { _CodigoGrupo = value; } }
        public string ChavePermissao { get { return _ChavePermissao; } set { _ChavePermissao = value; } }
        public string DescricaoPermissao { get { return _DescricaoPermissao; } set { _DescricaoPermissao = value; } }
        public string Posicao { get { return _Posicao; } set { _Posicao = value; } }
        public bool Simples { get { return _Simples; } set { _Simples = value; } }
        public bool Autorizacao { get { return _Autorizacao; } set { _Autorizacao = value; } }
        public bool Inclusao { get { return _Inclusao; } set { _Inclusao = value; } }
        public bool Alteracao { get { return _Alteracao; } set { _Alteracao = value; } }
        public bool Exclusao { get { return _Exclusao; } set { _Exclusao = value; } }
        public Security_Fields([Optional, DefaultParameterValue(0)] Int32 CodAgrupamento,
                               [Optional, DefaultParameterValue(0)] Int32 CodPermissao,
                               [Optional, DefaultParameterValue("")] string ChavePermissao,
                               [Optional, DefaultParameterValue("")] string DescricaoPermissao,
                               [Optional, DefaultParameterValue("")] string Posicao,
                               [Optional, DefaultParameterValue(0)] Int32 CodGrupo,
                               [Optional, DefaultParameterValue("")] string DescricaoGrupo,
                               [Optional, DefaultParameterValue(false)] bool Simples,
                               [Optional, DefaultParameterValue(false)] bool Autorizacao,
                               [Optional, DefaultParameterValue(false)] bool Inclusao,
                               [Optional, DefaultParameterValue(false)] bool Alteracao,
                               [Optional, DefaultParameterValue(false)] bool Exclusao)
        {
            //********************************
            //* Define dados de inicialização
            //********************************
            _CodigoAgrupamento = CodAgrupamento;
            _CodigoPermissao = CodPermissao;
            _ChavePermissao = ChavePermissao;
            _DescricaoPermissao = DescricaoPermissao;
            _Posicao = Posicao;
            _CodigoGrupo = CodGrupo;
            _DescricaoGrupo = DescricaoGrupo;
            _Simples = Simples;
            _Autorizacao = Autorizacao;
            _Inclusao = Inclusao;
            _Alteracao = Alteracao;
            _Exclusao = Exclusao;
        }
    }
    public class Security_Manager
    {
        //***************************
        //* Nome do menu à localizar
        //***************************
        string MenuText = string.Empty;

        //********************************
        //* Coleção de ítens de segurança
        //********************************
        List<Security_Fields> _Permissions = new List<Security_Fields>();
        public List<Security_Fields> Permissions { get { return _Permissions; } set { _Permissions = value; } }
        public string DatabaseUpdate(string ConnectionString, string DataBaseName)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            DataTable oTablePermissoesOld = new DataTable();
            DataTable oTablePermissoesNew = new DataTable();
            DataTable oTable = new DataTable();
            string Log = string.Empty;
            string SQL = string.Empty;

            try
            {
                #region "Criação da tabela AGENDA_APONTAMENTOS";

                //**************************************
                //* Localiza tabela AGENDA_APONTAMENTOS
                //**************************************
                SQL = "SHOW TABLES LIKE '%agenda_apontamentos%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //************************************************
                //* A tabela AGENDA_APONTAMENTOS deve ser criada?
                //************************************************
                if (oTable.Rows.Count == 0)
                {
                    //*****************************************
                    //* Cria nova lista de AGENDA_APONTAMENTOS
                    //*****************************************
                    SQL = "CREATE TABLE `agenda_apontamentos` (";
                    SQL += "`codapontamento` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária do agendamento',";
                    SQL += "`recursos` TEXT NULL COMMENT 'Código do usuário relacionado',";
                    SQL += "`codpromotor` INT(6) UNSIGNED NULL DEFAULT '0' COMMENT 'Código do promotor',";
                    SQL += "`codcliente` INT(6) UNSIGNED NULL DEFAULT '0' COMMENT 'Código do cliente vinculado ao agendamento',";
                    SQL += "`codoportunidade` INT(6) UNSIGNED NULL DEFAULT '0' COMMENT 'Código da oportunidade vinculada ao agendamento',";
                    SQL += "`codorcamento` INT(6) UNSIGNED NULL DEFAULT '0' COMMENT 'Código do Código do orçamento vinculado ao agendamento',";
                    SQL += "`situacao` INT(6) UNSIGNED NULL DEFAULT '0' COMMENT 'Situação do agendamento',";
                    SQL += "`tipo` INT(6) NULL DEFAULT '0' COMMENT 'Tipo de agendamento',";
                    SQL += "`etiqueta` INT(6) NULL DEFAULT '0' COMMENT 'Texto da etiqueta',";
                    SQL += "`assunto` VARCHAR(250) NULL DEFAULT '' COMMENT 'Assunto do agendamento',";
                    SQL += "`descricao` VARCHAR(250) NULL DEFAULT '' COMMENT 'Descrição do agendamento',";
                    SQL += "`local` VARCHAR(250) NULL DEFAULT '' COMMENT 'Local do compromisso ou agendamento',";
                    SQL += "`recorrencia` VARCHAR(250) NULL DEFAULT '' COMMENT 'Recorrência do agendamento',";
                    SQL += "`despertador` VARCHAR(250) NULL DEFAULT '' COMMENT 'Despertador do agendamento',";
                    SQL += "`inicio` DATETIME NULL DEFAULT NULL COMMENT 'Data inicial do agendamento',";
                    SQL += "`fim` DATETIME NULL DEFAULT NULL COMMENT 'Data final do agendamento',";
                    SQL += "`dia_inteiro` TINYINT(1) NULL DEFAULT '0' COMMENT 'Evento de dia inteiro',";
                    SQL += "`exportacao` TINYINT(1) NULL DEFAULT '0' COMMENT 'Registro proveniente de exportação (0=Não, 1=Sim)',";
                    SQL += "PRIMARY KEY (`codapontamento`),";
                    SQL += "INDEX `exportacao` (`exportacao`),";
                    SQL += "INDEX `codcliente` (`codcliente`),";
                    SQL += "INDEX `codoportunidade` (`codoportunidade`),";
                    SQL += "INDEX `codorcamento` (`codorcamento`),";
                    SQL += "INDEX `codpromotor` (`codpromotor`)";
                    SQL += ") COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_APONTAMENTOS criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_APONTAMENTOS já existe.<br />";
                }

                #endregion

                #region "Criação da tabela AGENDA_ETIQUETA";

                //**********************************
                //* Localiza tabela AGENDA_ETIQUETA
                //**********************************
                SQL = "SHOW TABLES LIKE '%agenda_etiqueta%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //********************************************
                //* A tabela AGENDA_ETIQUETA deve ser criada?
                //********************************************
                if (oTable.Rows.Count == 0)
                {
                    //*************************************
                    //* Cria nova lista de AGENDA_ETIQUETA
                    //*************************************
                    SQL = "CREATE TABLE `agenda_etiqueta` (";
                    SQL += "`codetiqueta` INT(6) NULL DEFAULT '0' COMMENT 'Código da etiqueta',";
                    SQL += "`descricao` VARCHAR(50) NULL DEFAULT '' COMMENT 'Descrição da etiqueta',";
                    SQL += "`cor_red` INT(6) NULL DEFAULT '0' COMMENT 'Cor RED para etiqueta',";
                    SQL += "`cor_green` INT(6) NULL DEFAULT '0' COMMENT 'Cor GREEN para etiqueta',";
                    SQL += "`cor_blue` INT(6) NULL DEFAULT '0' COMMENT 'Cor BLUE para etiqueta'";
                    SQL += ") COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //**********************************
                    //* Dados da tabela AGENDA_ETIQUETA
                    //**********************************
                    SQL = "INSERT INTO `agenda_etiqueta` VALUES ";
                    SQL += "(0, 'Nenhum', 255, 255, 255),";
                    SQL += "(1, 'Importante', 255, 194, 190),";
                    SQL += "(2, 'Negócio', 168, 213, 255),";
                    SQL += "(3, 'Pessoal', 193, 244, 156),";
                    SQL += "(4, 'Férias', 243, 228, 199),";
                    SQL += "(5, 'Presença Obrigatória', 244, 206, 147),";
                    SQL += "(6, 'Viagem Necessária', 199, 144, 255),";
                    SQL += "(7, 'Necessita Preparação', 207, 219, 152),";
                    SQL += "(8, 'Celebração', 141, 233, 223),";
                    SQL += "(9, 'Chamada Telefônica', 255, 247, 165),";
                    SQL += "(10, 'Pré-Viagem', 255, 128, 0),";
                    SQL += "(11, 'Pós-Viagem', 255, 77, 77),";
                    SQL += "(12, 'Oportunidade', 0, 217, 54),";
                    SQL += "(13, 'Cotação', 255, 0, 127)";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_ETIQUETA criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_ETIQUETA já existe.<br />";
                }

                #endregion

                #region "Criação da tabela AGENDA_STATUS";

                //********************************
                //* Localiza tabela AGENDA_STATUS
                //********************************
                SQL = "SHOW TABLES LIKE '%agenda_status%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //******************************************
                //* A tabela AGENDA_STATUS deve ser criada?
                //******************************************
                if (oTable.Rows.Count == 0)
                {
                    //***********************************
                    //* Cria nova lista de AGENDA_STATUS
                    //***********************************
                    SQL = "CREATE TABLE `agenda_status` (";
                    SQL += "`codstatus` INT(6) NULL DEFAULT '0' COMMENT 'Código do status',";
                    SQL += "`descricao` VARCHAR(50) NULL DEFAULT '' COMMENT 'Descrição do status'";
                    SQL += ") COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //********************************
                    //* Dados da tabela AGENDA_STATUS
                    //********************************
                    SQL = "INSERT INTO `agenda_status` VALUES ";
                    SQL += "(0, 'Livre'),";
                    SQL += "(1, 'Tentativa'),";
                    SQL += "(2, 'Ocupado'),";
                    SQL += "(3, 'Fora Escritório'),";
                    SQL += "(4, 'Trabalhando em outro lugar');";
                    oDBManager.ExecuteCommand(SQL);
                    
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_STATUS criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela AGENDA_STATUS já existe.<br />";
                }

                #endregion

                #region "Criação da tabela CONFIG";

                //*************************
                //* Localiza tabela CONFIG
                //*************************
                SQL = "SHOW TABLES LIKE '%config%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //***********************************
                //* A tabela CONFIG deve ser criada?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //****************************
                    //* Cria nova lista de CONFIG
                    //****************************
                    SQL = "CREATE TABLE `config` (";
                    SQL += "`codigo` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`smtp_autenticacao` TINYINT(1) NOT NULL DEFAULT '1' COMMENT 'Autenticação SMTP (0 = Não, 1 = Sim)',";
                    SQL += "`smtp_endereco` VARCHAR(100) NOT NULL DEFAULT '' COMMENT 'Endereço do servidor de distribuição SMTP',";
                    SQL += "`smtp_porta` SMALLINT(1) NOT NULL DEFAULT '587' COMMENT 'Porta de comunicação SMTP',";
                    SQL += "`smtp_usuario` VARCHAR(100) NOT NULL DEFAULT '' COMMENT 'Nome do usuário ou nome@dominio (SMTP autenticado)',";
                    SQL += "`smtp_senha` VARCHAR(50) NOT NULL DEFAULT '' COMMENT 'Senha de autenticação SMTP',";
                    SQL += "`smtp_ssl` TINYINT(1) NOT NULL DEFAULT '1' COMMENT 'Usar SSL com SMTP (Secure Socket Layer)',";
                    SQL += "`smtp_tls` TINYINT(1) NOT NULL DEFAULT '1' COMMENT 'Usar TLS/STARTTLS com SMTP',";
                    SQL += "PRIMARY KEY (`codigo`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela CONFIG criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela CONFIG já existe.<br />";
                }

                #endregion

                #region "Criação da tabela OPORTUNIDADE";

                //*******************************
                //* Localiza tabela OPORTUNIDADE
                //*******************************
                SQL = "SHOW TABLES LIKE '%oportunidade%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //*****************************************
                //* A tabela OPORTUNIDADE deve ser criada?
                //*****************************************
                if (oTable.Rows.Count == 0)
                {
                    //**********************************
                    //* Cria nova lista de OPORTUNIDADE
                    //**********************************
                    SQL = "CREATE TABLE `oportunidade` (";
                    SQL += "`nro_oportunidade` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`cod_promotor` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Código do promotor de vendas',";
                    SQL += "`data_operacao` DATETIME NULL DEFAULT NULL COMMENT 'Data da operação',";
                    SQL += "`cod_situacao` TINYINT(10) NOT NULL DEFAULT '1' COMMENT '1 = Aberto, 2 = Orçamento, 3 = Analise do Cliente, 4 = Ganhou, 5 = Perdeu',";
                    SQL += "`contato_nome` VARCHAR(60) NOT NULL DEFAULT '' COMMENT 'Nome da pessoa da contato',";
                    SQL += "`contato_emails` TEXT NOT NULL COMMENT 'Lista de e-mails de contato separador por \",\"',";
                    SQL += "`contato_telefone` VARCHAR(20) NOT NULL DEFAULT '' COMMENT 'Telefone de contato',";
                    SQL += "`destino` VARCHAR(200) NOT NULL DEFAULT '' COMMENT 'Destino da viagem',";
                    SQL += "`data_saida` DATETIME NULL DEFAULT NULL COMMENT 'Data da saída',";
                    SQL += "`data_retorno` DATETIME NULL DEFAULT NULL COMMENT 'Data de retorno',";
                    SQL += "`descricao` TEXT NULL COMMENT 'Descrição da viagem',";
                    SQL += "`proximo_contato` DATETIME NULL DEFAULT NULL COMMENT 'Data do próximo contato',";
                    SQL += "`proximo_contato_realizado` TINYINT(1) NULL DEFAULT '0' COMMENT 'Contato efetuado (0 = Não, 1 = Sim)',";
                    SQL += "`valor_estimado` DOUBLE(15,2) NULL DEFAULT '0.00' COMMENT 'Valor estimado da viagem',";
                    SQL += "`cod_canal_entrada` INT(1) NULL DEFAULT '1' COMMENT 'Canal de entrada (Site, Redes Sociais, BLOG, E-mail Marketing, Telefone, Material Impresso, Rádio, Televisão, Indicação, Presencial',";
                    SQL += "`indicado_por` VARCHAR(60) NULL DEFAULT '' COMMENT 'Nome da pessoa que indicou',";
                    SQL += "`quantidade_adultos` VARCHAR(50) NULL DEFAULT '' COMMENT 'Quantidade de adultos',";
                    SQL += "`quantidade_criancas` VARCHAR(50) NULL DEFAULT '' COMMENT 'Quantidade de crianças',";
                    SQL += "`data_encerramento` DATETIME NULL DEFAULT NULL COMMENT 'Data de encerramento',";
                    SQL += "`valor_fechado` DOUBLE(15,2) NULL DEFAULT '0.00' COMMENT 'Valor fechado da viagem',";
                    SQL += "`observacoes` MEDIUMTEXT NULL COMMENT 'Observações gerais',";
                    SQL += "`dados_sacado` MEDIUMTEXT NULL COMMENT 'Dados do sacado para cobrança (provisório)',";
                    SQL += "`lista_passageiros` MEDIUMTEXT NULL COMMENT 'Lista de passageiros (nome | tipo,nome | tipo)',";
                    SQL += "PRIMARY KEY (`nro_oportunidade`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE já existe.<br />";
                }

                #endregion

                #region "Criação da tabela OPORTUNIDADE_CANAL";

                //*************************************
                //* Localiza tabela OPORTUNIDADE_CANAL
                //*************************************
                SQL = "SHOW TABLES LIKE '%oportunidade_canal%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //***********************************************
                //* A tabela OPORTUNIDADE_CANAL deve ser criada?
                //***********************************************
                if (oTable.Rows.Count == 0)
                {
                    //****************************************
                    //* Cria nova lista de OPORTUNIDADE_CANAL
                    //****************************************
                    SQL = "CREATE TABLE `oportunidade_canal` (";
                    SQL += "`codigo` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`descricao` VARCHAR(20) NOT NULL DEFAULT '' COMMENT 'Descrição do canal de entrada',";
                    SQL += "PRIMARY KEY (`codigo`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //*************************************
                    //* Dados da tabela OPORTUNIDADE_CANAL
                    //*************************************
                    SQL = "INSERT INTO `oportunidade_canal` VALUES ";
                    SQL += "(1, 'Site'),";
                    SQL += "(2, 'Redes Sociais'),";
                    SQL += "(3, 'BLOG'),";
                    SQL += "(4, 'E-mail Marketing'),";
                    SQL += "(5, 'Telefone'),";
                    SQL += "(6, 'Material Impresso'),";
                    SQL += "(7, 'Rádio'),";
                    SQL += "(8, 'Televisão'),";
                    SQL += "(9, 'Indicação'),";
                    SQL += "(10, 'Presencial'),";
                    SQL += "(11, 'Cliente');";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_CANAL criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_CANAL já existe.<br />";
                }

                #endregion

                #region "Criação da tabela OPORTUNIDADE_ESTAGIO";

                //***************************************
                //* Localiza tabela OPORTUNIDADE_ESTAGIO
                //***************************************
                SQL = "SHOW TABLES LIKE '%oportunidade_estagio%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //*************************************************
                //* A tabela OPORTUNIDADE_ESTAGIO deve ser criada?
                //*************************************************
                if (oTable.Rows.Count == 0)
                {
                    //******************************************
                    //* Cria nova lista de OPORTUNIDADE_ESTAGIO
                    //******************************************
                    SQL = "CREATE TABLE `oportunidade_estagio` (";
                    SQL += "`codigo` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`descricao` VARCHAR(20) NOT NULL DEFAULT '' COMMENT 'Descrição do estágio do orçamento',";
                    SQL += "PRIMARY KEY (`codigo`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //***************************************
                    //* Dados da tabela OPORTUNIDADE_ESTAGIO
                    //***************************************
                    SQL = "INSERT INTO `oportunidade_estagio` VALUES ";
                    SQL += "(1, 'Cotação'), ";
                    SQL += "(2, 'Enviado'), ";
                    SQL += "(3, 'Aceito'), ";
                    SQL += "(4, 'Recusado'); ";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_ESTAGIO criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_ESTAGIO já existe.<br />";
                }

                #endregion

                #region "Criação da tabela OPORTUNIDADE_ORCAMENTOS";

                //******************************************
                //* Localiza tabela OPORTUNIDADE_ORCAMENTOS
                //******************************************
                SQL = "SHOW TABLES LIKE '%oportunidade_orcamentos%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //****************************************************
                //* A tabela OPORTUNIDADE_ORCAMENTOS deve ser criada?
                //****************************************************
                if (oTable.Rows.Count == 0)
                {
                    //*********************************************
                    //* Cria nova lista de OPORTUNIDADE_ORCAMENTOS
                    //*********************************************
                    SQL = "CREATE TABLE `oportunidade_orcamentos` (";
                    SQL += "`cod_orcamento` INT(1) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`nro_oportunidade` INT(1) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Número da oportunidade',";
                    SQL += "`data_orcamento` DATETIME NULL DEFAULT NULL COMMENT 'Data do orçamento',";
                    SQL += "`proximo_contato` DATETIME NULL DEFAULT NULL COMMENT 'Data do próximo contato',";
                    SQL += "`produto` VARCHAR(100) NULL DEFAULT '' COMMENT 'Nome do produto orçado',";
                    SQL += "`assunto` VARCHAR(100) NULL DEFAULT '' COMMENT 'Assunto tratado no orçamento',";
                    SQL += "`valor` DOUBLE(15,2) NULL DEFAULT '0.00' COMMENT 'Valor do orçamento',";
                    SQL += "`html_orcamento` LONGTEXT NULL COMMENT 'HTML da composição do orçamento',";
                    SQL += "`html_resposta` LONGTEXT NULL COMMENT 'HTML da composição da resposta do cliente',";
                    SQL += "`html_interno` LONGTEXT NULL COMMENT 'HTML da composição dos comentários internos',";
                    SQL += "`estagio_orcamento` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Estágio do orçamento (1 = Aberto, 2 = Qualificação, 3 = Aceito, 4 = Recusado)',";
                    SQL += "`pendencia` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Pendência de retorno do orçamento (0 = Sem pendência, 1 = Pendente)',";
                    SQL += "PRIMARY KEY (`cod_orcamento`), INDEX `nro_oportunidade` (`nro_oportunidade`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_ORCAMENTOS criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_ORCAMENTOS já existe.<br />";
                }

                #endregion

                #region "Criação da tabela OPORTUNIDADE_SITUACAO";

                //****************************************
                //* Localiza tabela OPORTUNIDADE_SITUACAO
                //****************************************
                SQL = "SHOW TABLES LIKE '%oportunidade_situacao%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //**************************************************
                //* A tabela OPORTUNIDADE_SITUACAO deve ser criada?
                //**************************************************
                if (oTable.Rows.Count == 0)
                {
                    //*******************************************
                    //* Cria nova lista de OPORTUNIDADE_SITUACAO
                    //*******************************************
                    SQL = "CREATE TABLE `oportunidade_situacao` (";
                    SQL += "`codigo` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`descricao` VARCHAR(20) NOT NULL DEFAULT '' COMMENT 'Descrição da situação',";
                    SQL += "PRIMARY KEY (`codigo`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB";
                    oDBManager.ExecuteCommand(SQL);

                    //****************************************
                    //* Dados da tabela OPORTUNIDADE_SITUACAO
                    //****************************************
                    SQL = "INSERT INTO `oportunidade_situacao` VALUES ";
                    SQL += "(1, 'Qualificação'),";
                    SQL += "(2, 'Análise do Cliente'),";
                    SQL += "(3, 'Fechado Ganhou'),";
                    SQL += "(4, 'Fechado Perdeu');";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_SITUACAO criada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela OPORTUNIDADE_SITUACAO já existe.<br />";
                }

                #endregion

                #region "Atualização da tabela USUARIOS"

                //*******************************************
                //* Obtem lista de campos da tabela USUARIOS
                //*******************************************
                SQL = "DESCRIBE usuarios";
                oTable = oDBManager.ExecuteQuery(SQL);

                //******************************************
                //* A tabela de usuários já foi atualizada?
                //******************************************
                if (oTable.Rows.Count == 9)
                {
                    //******************************
                    //* Atualiza tabela de USUARIOS
                    //******************************
                    SQL = "ALTER TABLE `usuarios` ";
                    SQL += "ADD COLUMN `CodUsuario` INT(10) NOT NULL AUTO_INCREMENT COMMENT 'Chave primária' FIRST,";
                    SQL += "ADD COLUMN `CodPromotor` INT(10) NOT NULL DEFAULT '0' COMMENT 'Código do promotor' AFTER `CodUsuario`,";
                    SQL += "ADD COLUMN `nome` VARCHAR(60) NOT NULL DEFAULT '' COMMENT 'Nome completo do usuário' AFTER `CodPromotor`,";
                    SQL += "ADD COLUMN `telefone` VARCHAR(20) NOT NULL DEFAULT '' COMMENT 'Telefone do usuário' AFTER `nome`,";
                    SQL += "ADD COLUMN `ativo` TINYINT(1) NOT NULL DEFAULT '0' COMMENT '0 = Usuário Inativo, 1 = Usuário Ativo' AFTER `telefone`,";
                    SQL += "ADD COLUMN `email_endereco` VARCHAR(100) NOT NULL DEFAULT '' COMMENT 'Endereco de email' AFTER `ativo`,";
                    SQL += "ADD COLUMN `email_copia` TINYINT(1) NOT NULL DEFAULT '0' COMMENT 'Comunicados do sistema (0 = Não recebe, 1 = Recebe)' AFTER `email_endereco`,";
                    SQL += "ADD COLUMN `smtp_autenticacao` TINYINT(1) NOT NULL DEFAULT '0' COMMENT 'Autenticação SMTP (0 = Não, 1 = Sim)' AFTER `email_copia`,";
                    SQL += "ADD COLUMN `smtp_endereco` VARCHAR(100) NOT NULL DEFAULT '' COMMENT 'Endereço do servidor de distribuição SMTP' AFTER `smtp_autenticacao`,";
                    SQL += "ADD COLUMN `smtp_porta` SMALLINT(1) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Porta de comunicação SMTP' AFTER `smtp_endereco`,";
                    SQL += "ADD COLUMN `smtp_usuario` VARCHAR(100) NOT NULL DEFAULT '' COMMENT 'Nome do usuário ou nome@dominio (SMTP autenticado)' AFTER `smtp_porta`,";
                    SQL += "ADD COLUMN `smtp_senha` VARCHAR(50) NOT NULL DEFAULT '' COMMENT 'Senha de autenticação SMTP' AFTER `smtp_usuario`,";
                    SQL += "ADD COLUMN `smtp_ssl` TINYINT(1) NOT NULL DEFAULT '0' COMMENT 'Usar SSL com SMTP (Secure Socket Layer)' AFTER `smtp_senha`,";
                    SQL += "ADD COLUMN `smtp_tls` TINYINT(1) NOT NULL DEFAULT '0' COMMENT 'Usar TLS/STARTTLS com SMTP' AFTER `smtp_ssl`,";
                    SQL += "ADD PRIMARY KEY (`CodUsuario`)";
                    oDBManager.ExecuteCommand(SQL);

                    //****************************
                    //* Obtem senhas dos USUARIOS
                    //****************************
                    SQL = "SELECT CodUsuario, Senha FROM usuarios";
                    oTable = oDBManager.ExecuteQuery(SQL);

                    //**************************
                    //* Atualiza lista de senas
                    //**************************
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        SQL = "UPDATE usuarios SET ativo = 1, senha = '" + Crypto.UpdatePwd(oRow["Senha"].ToString()) + "' ";
                        SQL += "WHERE CodUsuario = " + oRow["CodUsuario"].ToString();
                        oDBManager.ExecuteCommand(SQL);
                    }

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela USUARIOS atualizada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela USUARIOS não necessita atualizações.<br />";
                }

                #endregion

                #region "Criação e atualiza a tabela PERMISSOES_OPCOES"

                //************************************
                //* Localiza tabela PERMISSOES_OPCOES
                //************************************
                SQL = "SHOW TABLES LIKE '%permissoes_opcoes%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //**********************************************
                //* A tabela PERMISSOES_OPCOES deve ser criada?
                //**********************************************
                if (oTable.Rows.Count == 0)
                {
                    //********************************
                    //* Cria nova lista de permissões
                    //********************************
                    SQL = "CREATE TABLE `permissoes_opcoes` (";
                    SQL += "`codpermissao` INT(5) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`chavepermissao` VARCHAR(50) NOT NULL DEFAULT '' COMMENT 'Identificador da permissão',";
                    SQL += "`descricaopermissao` VARCHAR(200) NOT NULL DEFAULT '' COMMENT 'Descrição extensa da permissão',";
                    SQL += "`posicao` VARCHAR(50) NOT NULL DEFAULT '' COMMENT 'Posição da permissão na lista',";
                    SQL += "`posicaovb6` INT(5) NOT NULL DEFAULT '0' COMMENT 'Posição da permissão na string de permissões VB6',";
                    SQL += "`simples` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Tipo de permissao (0 = Acesso, Inclusão, Alteração, Exclusão | 1=Acesso)',";
                    SQL += "PRIMARY KEY (`codpermissao`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB AUTO_INCREMENT=1";
                    oDBManager.ExecuteCommand(SQL);

                    //***************************
                    //* Cria lista de permissões
                    //***************************
                    SQL = "INSERT INTO permissoes_opcoes (simples, posicaovb6, chavepermissao, posicao, descricaopermissao) VALUES ";
                    SQL += "(0, 0, 'Cadastro_Agenda', '001', 'Acesso ao cadastro de agendamento de compromissos'),";
                    SQL += "(0, 0, 'Cadastro_Oportunidades', '002', 'Acesso ao cadastro de oportunidades de negócio'),";
                    SQL += "(0, 0, 'Cadastro_Usuarios', '003', 'Acesso ao cadastro de usuários'),";
                    SQL += "(0, 0, 'Cadastro_Seguranca', '004', 'Acesso ao cadastro de grupos de segurança'),";
                    SQL += "(1, 0, 'Cadastro_Agenda_Restingir', '001.1', 'Restringir registros de agendamento de compromissos'),";
                    SQL += "(1, 0, 'Cadastro_Oportunidade_Restringir', '002.1', 'Restringir registros do cadastro de oportunidades de negócio'),";
                    SQL += "(1, 0, 'Gerenciamento_Configuracoes', '005', 'Acesso ao gerenciamento de configurações'),";
                    SQL += "(0, 0, 'Cadastro_Clientes', '006', 'Acesso ao cadastro de clientes'),";
                    SQL += "(0, 1,'AcessaCadastro',01,'Cadastros em Geral...'),";
                    SQL += "(0, 5,'AcessaOP',02,'Movimento de Ordens de Passagem...'),";
                    SQL += "(0, 9,'AcessaVoucher',03,'Movimento de Solicitações de Reserva & Voucher\\'s...'),";
                    SQL += "(0,13,'AcessaRequis',04,'Movimento de Requisições de Produtos e Serviços...'),";
                    SQL += "(1,17,'HabilitaNegoc',05,'Permite nas Requisições Alterar as Negociações Sugeridas?'),";
                    SQL += "(1,18,'AtualizaNegoc',06,'Exige nas Requisições Confirmação para Capturar Regras de Negócio?'),";
                    SQL += "(1,19,'BaixaPagtoFornec',07,'Baixa de Pagamentos & Recebimentos Fornecedores?'),";
                    SQL += "(1,20,'PagamentoParcelas',08,'Baixa de Parcelas Clientes?'),";
                    SQL += "(0,21,'AcessaLancamentos',09,'Movimento de Despesas e Receitas Complementares...'),";
                    SQL += "(0,25,'AcessaEstoque',10,'Movimento do Estoque de Produtos...'),";
                    SQL += "(1,29,'ReemissaoFaturas',11,'Reemissão de Faturas?'),";
                    SQL += "(1,30,'ReemissaoRecibos',12,'Reemissão de Recibos Provenientes de Requisições?'),";
                    SQL += "(1,31,'GeracaoFaturas',13,'Geração e Consulta de Faturas?'),";
                    SQL += "(1,32,'BaixaFaturas',14,'Baixa de Faturas, Posterga Vencto Faturas e Baixa de Restrições?'),";
                    SQL += "(1,33,'CancelamentoFaturas',15,'Cancelamento de Faturas?'),";
                    SQL += "(1,34,'CancelamentoRecibos',16,'Cancelamento de Recibos?'),";
                    SQL += "(1,35,'PermiteStatusReqOK',17,'Permite nas Requisições Informar Status <OK>?'),";
                    SQL += "(1,36,'RelatoriosComerciais',18,'Relatórios Comerciais?'),";
                    SQL += "(1,37,'RelatoriosOperacionaisBasicos',19,'Relatórios Operacionais Básicos?'),";
                    SQL += "(1,38,'RelatoriosFinanceirosBasicos',20,'Relatórios Financeiros Básicos?'),";
                    SQL += "(0,38,'AcessaParamSistema',21,'Parâmetros do Sistema, Empresa, Unidades de Negócio...'),";
                    SQL += "(0,43,'AcessaNegocCliente',22,'Sub-cadastro das Regras de Negócio dos Clientes...'),";
                    SQL += "(0,47,'AcessaNegocFornec',23,'Sub-cadastro das Regras de Negócio dos Fornecedores...'),";
                    SQL += "(0,51,'AcessaNegocPromotor',24,'Sub-cadastro das Regras de Negócio dos Vendedores...'),";
                    SQL += "(1,55,'RelatoriosConferencia',25,'Relatórios de Conferência?'),";
                    SQL += "(0,56,'AcessaRecAvulso',26,'Recibos Avulsos...'),";
                    SQL += "(0,60,'AcessaCotiza',27,'Movimento de Cotizações...'),";
                    SQL += "(1,64,'AcessaReqContab',28,'Permite nas Requisições Visualizar Guia <Back Office Financeiro>?'),";
                    SQL += "(1,65,'AcessaReqMudaSinal',29,'Permite nas Requisições Mudar Sinal (+/-) de Valores?'),";
                    SQL += "(1,66,'ExigeClienteCIC',30,'Exige no Cadastro de Clientes o Preenchimento do CPF ou CNPJ?'),";
                    SQL += "(1,67,'ExigeFornecCNPJ',31,'Exige no Cadastro de Fornecedores o Preenchimento do CNPJ?'),";
                    SQL += "(0,68,'AcessaNota',32,'Notas Fiscais de Serviço...'),";
                    SQL += "(0,72,'AcessaVouchAvulso',33,'Vouchers Avulsos...'),";
                    SQL += "(1,76,'PermiteEmissao',34,'Permite nas Requisições Digitação das Data de Emissão?'),";
                    SQL += "(1,77,'PermiteTodasReq',35,'VisualizaRequisições Gravadas/Alteradas por Outro Usuário?'),";
                    SQL += "(1,78,'SugerePosto',36,'Restringe os Lançamento à Unidade de Negócio do Usuário?'),";
                    SQL += "(1,79,'DesabilitaRegras',37,'Desabilita Captura Automática de Todas as Regras de Negócio?'),";
                    SQL += "(1,80,'HabilitaArredonda',38,'Força Arredondamento das Comissões em Moeda Estrangeira nas Reqs?'),";
                    SQL += "(1,81,'PermiteCtrCambio',39,'Permite Controle de Câmbio (E/S)?'),";
                    SQL += "(1,82,'CapturaRegrasIncReq',40,'Captura Regras de Negócio e Atualiza Requisições ao Gravar Inclusão?'),";
                    SQL += "(1,83,'CapturaRegrasAltReq',41,'Captura Regras de Negócio e Atualiza Requisições ao Gravar Alteração?'),";
                    SQL += "(1,84,'AltStatusOK',42,'Permite Modificar o Status <OK> das Requisições para outro Status?'),";
                    SQL += "(1,85,'AltRequisStOK',43,'Permite Alterar as Requisições com Status <OK>?'),";
                    SQL += "(1,86,'VisualizaComisPagas',44,'Permite Visualizar nas Requisições Comissões e Incentivos Pagos?'),";
                    SQL += "(1,87,'ExigeDbCartaoAGT',45,'Exige Débitos do Cartão AGT ao Gravar Requisições Pagto Cartão AGT?'),";
                    SQL += "(1,88,'CreditoCliente',46,'Permite Alterar Situação Crédito e Tipo Cobrança do Cadastro Clientes?'),";
                    SQL += "(1,89,'SaldoContas',47,'Rotina de Atualização de Saldos de Contas Caixa/Bancos?'),";
                    SQL += "(1,90,'CadFinanceiros',48,'Habilita Cadastros Plano Contas, Tipos Cobrança e Contas Movimento?'),";
                    SQL += "(1,91,'RelatoriosOperacionaisAvancados',49,'Relatórios Operacionais Avançados?'),";
                    SQL += "(1,92,'RelatoriosFinanceirosAvancados',50,'Relatórios Financeiros Avançados?'),";
                    SQL += "(1,93,'RequerContaBaixa',51,'Requer a Conta nas Baixas, Exceto Requisições Status <RE, PE, CA, FF>?'),";
                    SQL += "(1,94,'PermiteBaixaRetroativa',52,'Permite Baixas Retroativas à Data da Atualização do Saldo na Conta?'),";
                    SQL += "(1,95,'PermiteReembolso',53,'Habilita nas Requisições a Função Reembolso/Crédito?'),";
                    SQL += "(1,96,'HabilitaConta',54,'Habilita o campo Conta nas Requisições e nas Parcelas?'),";
                    SQL += "(1,97,'HabilitaVendedores',55,'Habilita Vínculo Vendedores no Cadastro de Clientes?'),";
                    SQL += "(1,98,'HabilitaRecStatusOK',56,'Habilita Emissão Recibos/Comprovantes Somente Reqs. Status <OK>?'),";
                    SQL += "(1,99,'RequerGruEven',57,'Exige os campos Grupo e Evento nas Requisições?'),";
                    SQL += "(1,100,'RequerTercStatusOK',58,'Exige o campo Terceiro/AGT mas Requisições com Status <OK>?'),";
                    SQL += "(1,101,'RequerPlanoUnidade',59,'Requer Vículo do Plano de Contas com a(s) Unidades de Negócio?'),";
                    SQL += "(1,102,'PermiteNroProcesso',60,'Permite Modificar o Nro do Processo nas Requisições?'),";
                    SQL += "(1,103,'PermiteNroRecibo',61,'Permite Modificar o Nro do Recibo nas Requisições?'),";
                    SQL += "(1,104,'IgnoraVinculoPostoCli',62,'Ignora nas Requisições Vínculo do cliente com Unidade de Negócio?'),";
                    SQL += "(1,105,'AlteraVenctoFatCli',63,'Permite Postergar/Alterar a Data de Vencimento de Faturas Clientes?'),";
                    SQL += "(1,106,'RequerForn',64,'Exige o campo Fornecedor nas Requisições?'),";
                    SQL += "(1,107,'SugerePECaptura',65,'Sugere o Status <PE> nas Requisições Capturadas de OPs?'),";
                    SQL += "(1,108,'RequerPlano',66,'Requer o Plano de Contas nos Lançamentos Complementares?'),";
                    SQL += "(1,109,'ArredondaCotiza',67,'Força o Arredondamento do Valor do Preço de Vendas nas Cotizações?'),";
                    SQL += "(0,110,'AcessaTarifario',68,'Habilita Cadastro de Tarifários?'),";
                    SQL += "(0,114,'AcessaCambioDiario',69,'Habilita Movimento de Câmbio Diário?'),";
                    SQL += "(0,118,'AcessaCotizacoes',70,'Habilita Movimento de Cotizações?'),";
                    SQL += "(1,122,'AcessaPreVendas',71,'Habilita Relatórios de Pré-Vendas?'),";
                    SQL += "(1,123,'AcessaPosVendas',72,'Habilita Relatórios de Pós-Vendas?'),";
                    SQL += "(1,124,'AcessaRelatorioClientes',73,'Habilita Relatórios de Clientes?'),";
                    SQL += "(1,125,'AcessaInterfaces',74,'Habilita Interfaces de Importação, Exportação e Conciliação?'),";
                    SQL += "(1,126,'RequerVoucherPago',75,'Requer Baixa Recebimento para Emissão de Vouchers?'),";
                    SQL += "(1,127,'SugereComisAGTnoDescCli',76,'Sugere Valor Comissão Terceiro/AGT no Valor do Desconto Cliente?'),";
                    SQL += "(1,128,'PermiteStatusReqInterfaces',77,'Permite nas Requisições Informa Status </G, /A, /S, /F, /X, /W, JJ, SU, GA, AD, SK, BR>?'),";
                    SQL += "(1,129,'PermiteAlterarReembolsoReqFechadas',78,'Permite alterar dados de reembolso para requisições com situação fechada?'),";
                    SQL += "(1,130,'PermiteAlterarVoucherReqFechadas',79,'Permite alterar dados de reserva/voucher para requsições com situação fechada?'),";
                    SQL += "(1,131,'PermiteAuditarTransações',80,'Permite auditar histórico de transações realizadas no banco de dados?'),";
                    SQL += "(1,132,'ControlaLimiteCredito',81,'Habilita controle de limite de crédito do cliente nas requisições?'),";
                    SQL += "(0,133,'FaturaAvulsaAcessa',82,'Faturas Avulsas - Recebtos Antecipados de Grupos...'),";
                    SQL += "(1,137,'FaturaAvulsaInclui',83,'Controle parcelas somatório bruto x total financiar iguais?'),";
                    SQL += "(1,138,'FaturaAvulsaAltera',84,'Habilita em <Relatórios -> Clientes -> a opção <Solicitações de Transfers>?'),";
                    SQL += "(1,139,'FaturaAvulsaExclui',85,'Pemite exclusão a fatura avulsa'),";
                    SQL += "(1,137,'SomatorioParcelas',86,'Controle parcelas somatório bruto x total financiar iguais ?'),";
                    SQL += "(1,138,'SolocitacaoTransfer',87,'Habilita em <Relatórios -> Clientes> a opção <Solicitações de Transfers> ?'),";
                    SQL += "(1,139,'ListagemClientes',88,'Habilita em Listagem de Clientes?'),";
                    SQL += "(1,140,'RestringeProdutosAoEvento',89,'Retringe produtos ao estoque do evento'),";
                    SQL += "(1,141,'RestringeAlterarReqsBaixadas',90,'Retringe alterar qualquer requisição com baixa recebimento ou pagamento')";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela PERMISSOES_OPCOES criada e atualizada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela PERMISSOES_OPCOES já existe.<br />";
                }

                #endregion

                #region "Criação e atualização da tabela PERMISSOES_GRUPOS";

                //************************************
                //* Localiza tabela PERMISSOES_GRUPOS
                //************************************
                SQL = "SHOW TABLES LIKE '%permissoes_grupos%'";
                oTable = oDBManager.ExecuteQuery(SQL);

                //**********************************************
                //* A tabela PERMISSOES_GRUPOS deve ser criada?
                //**********************************************
                if (oTable.Rows.Count == 0)
                {
                    //***********************************
                    //* Cria relação permissões x grupos
                    //***********************************
                    SQL = "CREATE TABLE `permissoes_grupos` (";
                    SQL += "`codagrupamento` INT(6) UNSIGNED NOT NULL AUTO_INCREMENT COMMENT 'Chave primária',";
                    SQL += "`codpermissao` INT(6) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Código da permissão',";
                    SQL += "`codgrupo` INT(6) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Código do grupo',";
                    SQL += "`acesso` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Possui acesso (0=Não, 1=Sim)',";
                    SQL += "`inclusao` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Pode incluir (0=Não, 1=Sim)',";
                    SQL += "`alteracao` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Pode alterar (0=Não, 1=Sim)',";
                    SQL += "`exclusao` TINYINT(1) UNSIGNED NULL DEFAULT '0' COMMENT 'Pode excluir (0=Não, 1=Sim)',";
                    SQL += "PRIMARY KEY (`codagrupamento`)) COLLATE='latin1_swedish_ci' ENGINE=InnoDB AUTO_INCREMENT=1";
                    oDBManager.ExecuteCommand(SQL);

                    //***********************
                    //* Seleciona permissões
                    //***********************
                    SQL = "SELECT CodPermissao, PosicaoVB6, Simples FROM permissoes_opcoes ";
                    SQL += "WHERE permissoes_opcoes.posicaovb6 > 0 ORDER BY posicaovb6";
                    oTablePermissoesNew = oDBManager.ExecuteQuery(SQL);

                    //*******************************
                    //* Seleciona permissões antigas
                    //*******************************
                    SQL = "SELECT CodGrupo, Status FROM permissoes ORDER BY CodGrupo";
                    oTablePermissoesOld = oDBManager.ExecuteQuery(SQL);

                    //***********************************************
                    //* Prepara parte inicial do comando de inserção
                    //***********************************************
                    SQL = "INSERT INTO permissoes_grupos (codpermissao, codgrupo, acesso, inclusao, alteracao, exclusao) VALUES ";

                    //*******************************************************************************
                    //* Obtem cada cojunto de permissões por grupo antigas em formato string (X e 0)
                    //*******************************************************************************
                    foreach (DataRow oRowOld in oTablePermissoesOld.Rows)
                    {
                        //***************************************************
                        //* Ajusta cara pemissão nova de acordo com a antiga
                        //***************************************************
                        foreach (DataRow oRowNew in oTablePermissoesNew.Rows)
                        {
                            //********************************************************
                            //* A posição atual extrapola a posição máximo do status?
                            //********************************************************
                            if (Convert.ToInt32(oRowNew["PosicaoVB6"]) < Convert.ToInt32(oRowOld["Status"].ToString().Length))
                            {
                                //*********************************
                                //* Permissão simples ou múltipla?
                                //*********************************
                                if (Convert.ToBoolean(oRowNew["Simples"]))
                                {
                                    //**********
                                    //* Simples
                                    //**********
                                    SQL += "(";
                                    SQL += oRowNew["CodPermissao"].ToString() + ",";
                                    SQL += oRowOld["CodGrupo"].ToString() + ",";

                                    //*********
                                    //* Acesso
                                    //*********
                                    if (oRowOld["Status"].ToString().Substring(Convert.ToInt32(oRowNew["PosicaoVB6"]) - 1, 1) == "X")
                                        SQL += "1,";
                                    else
                                        SQL += "0,";

                                    //***********
                                    //* Inclusão
                                    //***********
                                    SQL += "0,";

                                    //************
                                    //* Alteração
                                    //************
                                    SQL += "0,";

                                    //***********
                                    //* Exclusão
                                    //***********
                                    SQL += "0),";
                                }
                                else
                                {
                                    //***********
                                    //* Multipla
                                    //***********
                                    SQL += "(";
                                    SQL += oRowNew["CodPermissao"].ToString() + ",";
                                    SQL += oRowOld["CodGrupo"].ToString() + ",";

                                    //*********
                                    //* Acesso
                                    //*********
                                    if (oRowOld["Status"].ToString().Substring(Convert.ToInt32(oRowNew["PosicaoVB6"]) - 1, 1) == "X")
                                        SQL += "1,";
                                    else
                                        SQL += "0,";

                                    //***********
                                    //* Inclusão
                                    //***********
                                    if (oRowOld["Status"].ToString().Substring(Convert.ToInt32(oRowNew["PosicaoVB6"]) + 0, 1) == "X")
                                        SQL += "1,";
                                    else
                                        SQL += "0,";

                                    //************
                                    //* Alteração
                                    //************
                                    if (oRowOld["Status"].ToString().Substring(Convert.ToInt32(oRowNew["PosicaoVB6"]) + 1, 1) == "X")
                                        SQL += "1,";
                                    else
                                        SQL += "0,";

                                    //***********
                                    //* Exclusão
                                    //***********
                                    if (oRowOld["Status"].ToString().Substring(Convert.ToInt32(oRowNew["PosicaoVB6"]) + 2, 1) == "X")
                                        SQL += "1),";
                                    else
                                        SQL += "0),";
                                }
                            }
                        }
                    }

                    //********************
                    //* Executa inserções
                    //********************
                    if (SQL.EndsWith(",")) SQL = SQL.Left(SQL.Length - 1);
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela PERMISSOES_GRUPOS criada e atualizada com sucesso.<br />";
                }
                else
                {
                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Tabela PERMISSOES_GRUPOS já existe.<br />";
                }

                #endregion

                #region "Stored Routines - tabela CLIENTES"

                //*******************************************
                //* Localiza store procedure CLIENTES_SELECT
                //*******************************************
                SQL = "SHOW PROCEDURE STATUS WHERE db = '" + DataBaseName + "' AND name LIKE '%clientes_select%'";
                oTable = oDBManager.ExecuteQuery(SQL);
                
                //***********************************
                //* O store procedure SELECT existe?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //*********************************
                    //* CLIENTES - Seleção de registro
                    //*********************************
                    SQL = "CREATE DEFINER=`root`@`localhost` PROCEDURE `clientes_select`()\r\n";
                    SQL += "BEGIN\r\n";
                    SQL += "SELECT * FROM Clientes2 ";
                    SQL += "INNER JOIN Clientes1 ON Clientes1.CodCli = Clientes2.CodCli ";
                    SQL += "WHERE Clientes2.CodCli > 0;\r\n";
                    SQL += "END\r\n";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Stored Routine CLIENTES_SELECT criada com sucesso.<br />";
                }

                //*******************************************
                //* Localiza store procedure CLIENTES_DELETE
                //*******************************************
                SQL = "SHOW PROCEDURE STATUS WHERE db = '" + DataBaseName + "' AND name LIKE '%clientes_delete%'";
                oTable = oDBManager.ExecuteQuery(SQL);

                //***********************************
                //* O store procedure DELETE existe?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //**********************************
                    //* CLIENTES - Exclusão de registro
                    //**********************************
                    SQL = "CREATE DEFINER=`root`@`localhost` PROCEDURE `clientes_delete`(IN `CodCli` INT(10))\r\n";
                    SQL += "BEGIN\r\n";
                    SQL += "SET FOREIGN_KEY_CHECKS=0;\r\n";
                    SQL += "DELETE FROM Clientes1 WHERE CodCli = CodCli;\r\n";
                    SQL += "DELETE FROM Clientes2 WHERE CodCli = CodCli;\r\n";
                    SQL += "SET FOREIGN_KEY_CHECKS=1;\r\n";
                    SQL += "END\r\n";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Stored Routine CLIENTES_DELETE criada com sucesso.<br />";
                }

                //*******************************************
                //* Localiza store procedure CLIENTES_INSERT
                //*******************************************
                SQL = "SHOW PROCEDURE STATUS WHERE db = '" + DataBaseName + "' AND name LIKE '%clientes_insert%'";
                oTable = oDBManager.ExecuteQuery(SQL);

                //***********************************
                //* O store procedure INSERT existe?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //**********************************
                    //* CLIENTES - Inclusão de registro
                    //**********************************
                    SQL = "CREATE DEFINER=`root`@`localhost` PROCEDURE `clientes_insert`(";
                    SQL += "IN `AgrupaCatProd` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaCC` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaCodCtbForn` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaForn` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaPax` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaProd` VARCHAR(50),";
                    SQL += "IN `AgrupaReq` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaReqCliente` SMALLINT(5),";
                    SQL += "IN `AgrupaSolicitante` SMALLINT(5),";
                    SQL += "IN `AgrupaTipoCobra` TINYINT(1) UNSIGNED,";
                    SQL += "IN `Assento` CHAR(1),";
                    SQL += "IN `AssinaNewsletter` CHAR(1),";
                    SQL += "IN `Bairro` CHAR(25),";
                    SQL += "IN `CartaoCred1` CHAR(12),";
                    SQL += "IN `CartaoCred2` CHAR(12),";
                    SQL += "IN `CartaoCred3` CHAR(12),";
                    SQL += "IN `CartaoCred4` CHAR(12),";
                    SQL += "IN `CEPCobr` CHAR(9),";
                    SQL += "IN `CEPRes` CHAR(9),";
                    SQL += "IN `CEPTrab` CHAR(9),";
                    SQL += "IN `CGC` VARCHAR(50),";
                    SQL += "IN `ChaveLivre1` CHAR(30),";
                    SQL += "IN `ChaveLivre2` CHAR(30),";
                    SQL += "IN `Cia1` CHAR(20),";
                    SQL += "IN `Cia2` CHAR(20),";
                    SQL += "IN `Cia3` CHAR(20),";
                    SQL += "IN `Cia4` CHAR(20),";
                    SQL += "IN `CIC` CHAR(11),";
                    SQL += "IN `CodBco` INT(10),";
                    SQL += "IN `CodCidadeCobr` INT(10),";
                    SQL += "IN `CodCidadeRes` INT(10),";
                    SQL += "IN `CodCidadeTrab` INT(10),";
                    SQL += "IN `CodCli` INT(10),";
                    SQL += "IN `CodContabil` CHAR(10),";
                    SQL += "IN `CodEmissor` INT(10),";
                    SQL += "IN `CodProf` INT(10),";
                    SQL += "IN `CodPromotor` INT(10),";
                    SQL += "IN `CodTerceiro` INT(10),";
                    SQL += "IN `ContaCTA` CHAR(16),";
                    SQL += "IN `ContaEBTA` CHAR(15),";
                    SQL += "IN `Contato` CHAR(40),";
                    SQL += "IN `ContaVisa` CHAR(16),";
                    SQL += "IN `CreditoCheque` CHAR(1),";
                    SQL += "IN `CreditoDinCC` CHAR(1),";
                    SQL += "IN `CreditoOutros` CHAR(1),";
                    SQL += "IN `CSCartao1` CHAR(5),";
                    SQL += "IN `CSCartao2` CHAR(5),";
                    SQL += "IN `CSCartao3` CHAR(5),";
                    SQL += "IN `DataCad` DATETIME,";
                    SQL += "IN `DataNasc` DATETIME,";
                    SQL += "IN `DtUltimaAlteracao` DATETIME,";
                    SQL += "IN `EMail` CHAR(60),";
                    SQL += "IN `EMailNFSe` CHAR(60),";
                    SQL += "IN `EmissVisto1` DATETIME,";
                    SQL += "IN `EmissVisto2` DATETIME,";
                    SQL += "IN `EndCobr` CHAR(40),";
                    SQL += "IN `EndCorresp` CHAR(1),";
                    SQL += "IN `EndRes` CHAR(40),";
                    SQL += "IN `EndTrab` CHAR(40),";
                    SQL += "IN `EstadoCivil` VARCHAR(1),";
                    SQL += "IN `Fantasia` CHAR(40),";
                    SQL += "IN `FaxRes` CHAR(20),";
                    SQL += "IN `FaxTrab` CHAR(20),";
                    SQL += "IN `Filiacao` CHAR(70),";
                    SQL += "IN `FoneRefBco` CHAR(20),";
                    SQL += "IN `FoneRefCom` CHAR(20),";
                    SQL += "IN `FoneRes` CHAR(20),";
                    SQL += "IN `FoneTrab` CHAR(20),";
                    SQL += "IN `Fumante` CHAR(1),";
                    SQL += "IN `Funcao` CHAR(30),";
                    SQL += "IN `GeraFatPDF` CHAR(1),";
                    SQL += "IN `IndicePontosCli` DOUBLE(15,5),";
                    SQL += "IN `InscrEstadual` CHAR(14),";
                    SQL += "IN `InscrMunicipal` CHAR(14),";
                    SQL += "IN `ItensFatura` SMALLINT(5),";
                    SQL += "IN `LeiKandir` CHAR(1),";
                    SQL += "IN `LimiteUnit` DOUBLE(15,5),";
                    SQL += "IN `LocalTrab` CHAR(40),";
                    SQL += "IN `MneCli` CHAR(14),";
                    SQL += "IN `Nacionalidade` CHAR(25),";
                    SQL += "IN `Naturalidade` CHAR(25),";
                    SQL += "IN `Nome` CHAR(40),";
                    SQL += "IN `NomeVisto1` CHAR(10),";
                    SQL += "IN `NomeVisto2` CHAR(10),";
                    SQL += "IN `NroCartao1` CHAR(20),";
                    SQL += "IN `NroCartao2` CHAR(20),";
                    SQL += "IN `NroCartao3` CHAR(20),";
                    SQL += "IN `NroCartao4` CHAR(20),";
                    SQL += "IN `NroCia1` CHAR(15),";
                    SQL += "IN `NroCia2` CHAR(15),";
                    SQL += "IN `NroCia3` CHAR(15),";
                    SQL += "IN `NroCia4` CHAR(15),";
                    SQL += "IN `ObrigaCentroCusto` CHAR(1),";
                    SQL += "IN `ObrigaObservacao` CHAR(1),";
                    SQL += "IN `Observacoes` LONGTEXT,";
                    SQL += "IN `Orgao` CHAR(5),";
                    SQL += "IN `Passaporte` CHAR(40),";
                    SQL += "IN `PercentPontosCli` DOUBLE(15,5),";
                    SQL += "IN `PeriodoFatura` CHAR(20),";
                    SQL += "IN `PostoVen` INT(10),";
                    SQL += "IN `PotCres` CHAR(1),";
                    SQL += "IN `RefBco` LONGTEXT,";
                    SQL += "IN `RefCom` CHAR(40),";
                    SQL += "IN `Renda` DOUBLE(15,5),";
                    SQL += "IN `RG` CHAR(11),";
                    SQL += "IN `RGUF` CHAR(2),";
                    SQL += "IN `Sexo` CHAR(1),";
                    SQL += "IN `SitCli` VARCHAR(50),";
                    SQL += "IN `SitCredito` CHAR(1),";
                    SQL += "IN `StatusCli` CHAR(1),";
                    SQL += "IN `TempoRes` SMALLINT(5),";
                    SQL += "IN `TempoTrab` SMALLINT(5),";
                    SQL += "IN `TipoCli` INT(10),";
                    SQL += "IN `TipoNewsletter` CHAR(1),";
                    SQL += "IN `TipoPessoa` CHAR(1),";
                    SQL += "IN `Titular` CHAR(1),";
                    SQL += "IN `TitularCartao1` CHAR(40),";
                    SQL += "IN `TitularCartao2` CHAR(40),";
                    SQL += "IN `TitularCartao3` CHAR(40),";
                    SQL += "IN `TituloMala` CHAR(40),";
                    SQL += "IN `UltimaAlteracaoPor` CHAR(20),";
                    SQL += "IN `ValEstra` CHAR(1),";
                    SQL += "IN `ValidCartao1` CHAR(6),";
                    SQL += "IN `ValidCartao2` CHAR(6),";
                    SQL += "IN `ValidCartao3` CHAR(6),";
                    SQL += "IN `ValidCartao4` CHAR(6),";
                    SQL += "IN `ValidPassaporte` DATETIME,";
                    SQL += "IN `ValidVisto1` DATETIME,";
                    SQL += "IN `ValidVisto2` DATETIME,";
                    SQL += "IN `VenctoCartao1` CHAR(2),";
                    SQL += "IN `VenctoCartao2` CHAR(2),";
                    SQL += "IN `VenctoCartao3` CHAR(2),";
                    SQL += "IN `VenctoCartao4` CHAR(2),";
                    SQL += "IN `VlrTxBco` DOUBLE(15,5)";
                    SQL += ")\r\n";
                    SQL += "BEGIN\r\n";
                    SQL += "DECLARE CodCli INT;\r\n";
                    SQL += "SELECT Clientes2.CodCli FROM Clientes2 ORDER BY Clientes2.CodCli DESC LIMIT 1 INTO CodCli;\r\n";
                    SQL += "SET CodCli = CodCli + 1;\r\n";
                    SQL += "INSERT INTO Clientes2 (";
                    SQL += "CodCli,";
                    SQL += "Contato,";
                    SQL += "Sexo,";
                    SQL += "EndRes,";
                    SQL += "FoneRes,";
                    SQL += "FaxRes,";
                    SQL += "CodCidadeRes,";
                    SQL += "CEPRes,";
                    SQL += "TempoRes,";
                    SQL += "Filiacao,";
                    SQL += "DataNasc,";
                    SQL += "CIC,";
                    SQL += "RG,";
                    SQL += "Orgao,";
                    SQL += "RGUF,";
                    SQL += "Nacionalidade,";
                    SQL += "Naturalidade,";
                    SQL += "InscrEstadual,";
                    SQL += "CGC,";
                    SQL += "EstadoCivil,";
                    SQL += "EMail,";
                    SQL += "Passaporte,";
                    SQL += "ValidPassaporte,";
                    SQL += "NomeVisto1,";
                    SQL += "NomeVisto2,";
                    SQL += "ValidVisto1,";
                    SQL += "ValidVisto2,";
                    SQL += "EndTrab,";
                    SQL += "CodCidadeTrab,";
                    SQL += "CEPTrab,";
                    SQL += "FoneTrab,";
                    SQL += "FaxTrab,";
                    SQL += "TempoTrab,";
                    SQL += "Renda,";
                    SQL += "RefCom,";
                    SQL += "FoneRefCom,";
                    SQL += "RefBco,";
                    SQL += "FoneRefBco,";
                    SQL += "Cia1,";
                    SQL += "NroCia1,";
                    SQL += "Cia2,";
                    SQL += "NroCia2,";
                    SQL += "Cia3,";
                    SQL += "NroCia3,";
                    SQL += "Cia4,";
                    SQL += "NroCia4,";
                    SQL += "DataCad,";
                    SQL += "CodContabil,";
                    SQL += "Fumante,";
                    SQL += "Assento,";
                    SQL += "EndCobr,";
                    SQL += "CodCidadeCobr,";
                    SQL += "CEPCobr,";
                    SQL += "EndCorresp,";
                    SQL += "SitCredito,";
                    SQL += "Observacoes,";
                    SQL += "CartaoCred1,";
                    SQL += "CartaoCred2,";
                    SQL += "CartaoCred3,";
                    SQL += "CartaoCred4,";
                    SQL += "NroCartao1,";
                    SQL += "NroCartao2,";
                    SQL += "NroCartao3,";
                    SQL += "NroCartao4,";
                    SQL += "ValidCartao1,";
                    SQL += "ValidCartao2,";
                    SQL += "ValidCartao3,";
                    SQL += "ValidCartao4,";
                    SQL += "TituloMala,";
                    SQL += "TipoPessoa,";
                    SQL += "VenctoCartao1,";
                    SQL += "VenctoCartao2,";
                    SQL += "VenctoCartao3,";
                    SQL += "VenctoCartao4,";
                    SQL += "DtUltimaAlteracao,";
                    SQL += "UltimaAlteracaoPor,";
                    SQL += "EmissVisto1,";
                    SQL += "EmissVisto2,";
                    SQL += "Funcao,";
                    SQL += "ChaveLivre1,";
                    SQL += "ChaveLivre2,";
                    SQL += "AssinaNewsletter,";
                    SQL += "TipoNewsletter,";
                    SQL += "CreditoDinCC,";
                    SQL += "CreditoCheque,";
                    SQL += "CreditoOutros,";
                    SQL += "PotCres,";
                    SQL += "ValEstra,";
                    SQL += "ContaEBTA,";
                    SQL += "Fantasia,";
                    SQL += "Bairro,";
                    SQL += "TitularCartao1,";
                    SQL += "TitularCartao2,";
                    SQL += "TitularCartao3,";
                    SQL += "CSCartao1,";
                    SQL += "CSCartao2,";
                    SQL += "CSCartao3,";
                    SQL += "VlrTxBco,";
                    SQL += "ContaCTA,";
                    SQL += "ContaVisa,";
                    SQL += "ObrigaCentroCusto,";
                    SQL += "ObrigaObservacao,";
                    SQL += "LimiteUnit,";
                    SQL += "InscrMunicipal,";
                    SQL += "EMailNFSe";
                    SQL += ") VALUES (";
                    SQL += "CodCli,";
                    SQL += "Contato,";
                    SQL += "Sexo,";
                    SQL += "EndRes,";
                    SQL += "FoneRes,";
                    SQL += "FaxRes,";
                    SQL += "CodCidadeRes,";
                    SQL += "CEPRes,";
                    SQL += "TempoRes,";
                    SQL += "Filiacao,";
                    SQL += "DataNasc,";
                    SQL += "CIC,";
                    SQL += "RG,";
                    SQL += "Orgao,";
                    SQL += "RGUF,";
                    SQL += "Nacionalidade,";
                    SQL += "Naturalidade,";
                    SQL += "InscrEstadual,";
                    SQL += "CGC,";
                    SQL += "EstadoCivil,";
                    SQL += "EMail,";
                    SQL += "Passaporte,";
                    SQL += "ValidPassaporte,";
                    SQL += "NomeVisto1,";
                    SQL += "NomeVisto2,";
                    SQL += "ValidVisto1,";
                    SQL += "ValidVisto2,";
                    SQL += "EndTrab,";
                    SQL += "CodCidadeTrab,";
                    SQL += "CEPTrab,";
                    SQL += "FoneTrab,";
                    SQL += "FaxTrab,";
                    SQL += "TempoTrab,";
                    SQL += "Renda,";
                    SQL += "RefCom,";
                    SQL += "FoneRefCom,";
                    SQL += "RefBco,";
                    SQL += "FoneRefBco,";
                    SQL += "Cia1,";
                    SQL += "NroCia1,";
                    SQL += "Cia2,";
                    SQL += "NroCia2,";
                    SQL += "Cia3,";
                    SQL += "NroCia3,";
                    SQL += "Cia4,";
                    SQL += "NroCia4,";
                    SQL += "DataCad,";
                    SQL += "CodContabil,";
                    SQL += "Fumante,";
                    SQL += "Assento,";
                    SQL += "EndCobr,";
                    SQL += "CodCidadeCobr,";
                    SQL += "CEPCobr,";
                    SQL += "EndCorresp,";
                    SQL += "SitCredito,";
                    SQL += "Observacoes,";
                    SQL += "CartaoCred1,";
                    SQL += "CartaoCred2,";
                    SQL += "CartaoCred3,";
                    SQL += "CartaoCred4,";
                    SQL += "NroCartao1,";
                    SQL += "NroCartao2,";
                    SQL += "NroCartao3,";
                    SQL += "NroCartao4,";
                    SQL += "ValidCartao1,";
                    SQL += "ValidCartao2,";
                    SQL += "ValidCartao3,";
                    SQL += "ValidCartao4,";
                    SQL += "TituloMala,";
                    SQL += "TipoPessoa,";
                    SQL += "VenctoCartao1,";
                    SQL += "VenctoCartao2,";
                    SQL += "VenctoCartao3,";
                    SQL += "VenctoCartao4,";
                    SQL += "DtUltimaAlteracao,";
                    SQL += "UltimaAlteracaoPor,";
                    SQL += "EmissVisto1,";
                    SQL += "EmissVisto2,";
                    SQL += "Funcao,";
                    SQL += "ChaveLivre1,";
                    SQL += "ChaveLivre2,";
                    SQL += "AssinaNewsletter,";
                    SQL += "TipoNewsletter,";
                    SQL += "CreditoDinCC,";
                    SQL += "CreditoCheque,";
                    SQL += "CreditoOutros,";
                    SQL += "PotCres,";
                    SQL += "ValEstra,";
                    SQL += "ContaEBTA,";
                    SQL += "Fantasia,";
                    SQL += "Bairro,";
                    SQL += "TitularCartao1,";
                    SQL += "TitularCartao2,";
                    SQL += "TitularCartao3,";
                    SQL += "CSCartao1,";
                    SQL += "CSCartao2,";
                    SQL += "CSCartao3,";
                    SQL += "VlrTxBco,";
                    SQL += "ContaCTA,";
                    SQL += "ContaVisa,";
                    SQL += "ObrigaCentroCusto,";
                    SQL += "ObrigaObservacao,";
                    SQL += "LimiteUnit,";
                    SQL += "InscrMunicipal,";
                    SQL += "EMailNFSe);\r\n";
                    SQL += "INSERT INTO Clientes1 (";
                    SQL += "CodCli,";
                    SQL += "Nome,";
                    SQL += "LocalTrab,";
                    SQL += "CodProf,";
                    SQL += "CodBco,";
                    SQL += "TipoCli,";
                    SQL += "SitCli,";
                    SQL += "PostoVen,";
                    SQL += "CodPromotor,";
                    SQL += "Titular,";
                    SQL += "MneCli,";
                    SQL += "LeiKandir,";
                    SQL += "StatusCli,";
                    SQL += "IndicePontosCli,";
                    SQL += "PercentPontosCli,";
                    SQL += "CodEmissor,";
                    SQL += "CodTerceiro,";
                    SQL += "GeraFatPDF,";
                    SQL += "AgrupaCodCtbForn,";
                    SQL += "AgrupaTipoCobra,";
                    SQL += "AgrupaCatProd,";
                    SQL += "AgrupaProd,";
                    SQL += "AgrupaForn,";
                    SQL += "AgrupaCC,";
                    SQL += "AgrupaPax,";
                    SQL += "AgrupaReq,";
                    SQL += "PeriodoFatura,";
                    SQL += "ItensFatura,";
                    SQL += "AgrupaReqCliente,";
                    SQL += "AgrupaSolicitante";
                    SQL += ") VALUES (";
                    SQL += "CodCli,";
                    SQL += "Nome,";
                    SQL += "LocalTrab,";
                    SQL += "CodProf,";
                    SQL += "CodBco,";
                    SQL += "TipoCli,";
                    SQL += "SitCli,";
                    SQL += "PostoVen,";
                    SQL += "CodPromotor,";
                    SQL += "Titular,";
                    SQL += "MneCli,";
                    SQL += "LeiKandir,";
                    SQL += "StatusCli,";
                    SQL += "IndicePontosCli,";
                    SQL += "PercentPontosCli,";
                    SQL += "CodEmissor,";
                    SQL += "CodTerceiro,";
                    SQL += "GeraFatPDF,";
                    SQL += "AgrupaCodCtbForn,";
                    SQL += "AgrupaTipoCobra,";
                    SQL += "AgrupaCatProd,";
                    SQL += "AgrupaProd,";
                    SQL += "AgrupaForn,";
                    SQL += "AgrupaCC,";
                    SQL += "AgrupaPax,";
                    SQL += "AgrupaReq,";
                    SQL += "PeriodoFatura,";
                    SQL += "ItensFatura,";
                    SQL += "AgrupaReqCliente,";
                    SQL += "AgrupaSolicitante);\r\n";
                    SQL += "END\r\n";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Stored Routine CLIENTES_INSERT criada com sucesso.<br />";
                }

                //*******************************************
                //* Localiza store procedure CLIENTES_UPDATE
                //*******************************************
                SQL = "SHOW PROCEDURE STATUS WHERE db = '" + DataBaseName + "' AND name LIKE '%clientes_update%'";
                oTable = oDBManager.ExecuteQuery(SQL);

                //***********************************
                //* O store procedure UPDATE existe?
                //***********************************
                if (oTable.Rows.Count == 0)
                {
                    //*************************************
                    //* CLIENTES - Atualização de registro
                    //*************************************
                    SQL = "CREATE DEFINER=`root`@`localhost` PROCEDURE `clientes_update`(";
                    SQL += "IN `AgrupaCatProd` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaCC` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaCodCtbForn` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaForn` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaPax` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaProd` VARCHAR(50),";
                    SQL += "IN `AgrupaReq` TINYINT(1) UNSIGNED,";
                    SQL += "IN `AgrupaReqCliente` SMALLINT(5),";
                    SQL += "IN `AgrupaSolicitante` SMALLINT(5),";
                    SQL += "IN `AgrupaTipoCobra` TINYINT(1) UNSIGNED,";
                    SQL += "IN `Assento` CHAR(1),";
                    SQL += "IN `AssinaNewsletter` CHAR(1),";
                    SQL += "IN `Bairro` CHAR(25),";
                    SQL += "IN `CartaoCred1` CHAR(12),";
                    SQL += "IN `CartaoCred2` CHAR(12),";
                    SQL += "IN `CartaoCred3` CHAR(12),";
                    SQL += "IN `CartaoCred4` CHAR(12),";
                    SQL += "IN `CEPCobr` CHAR(9),";
                    SQL += "IN `CEPRes` CHAR(9),";
                    SQL += "IN `CEPTrab` CHAR(9),";
                    SQL += "IN `CGC` VARCHAR(50),";
                    SQL += "IN `ChaveLivre1` CHAR(30),";
                    SQL += "IN `ChaveLivre2` CHAR(30),";
                    SQL += "IN `Cia1` CHAR(20),";
                    SQL += "IN `Cia2` CHAR(20),";
                    SQL += "IN `Cia3` CHAR(20),";
                    SQL += "IN `Cia4` CHAR(20),";
                    SQL += "IN `CIC` CHAR(11),";
                    SQL += "IN `CodBco` INT(10),";
                    SQL += "IN `CodCidadeCobr` INT(10),";
                    SQL += "IN `CodCidadeRes` INT(10),";
                    SQL += "IN `CodCidadeTrab` INT(10),";
                    SQL += "IN `CodContabil` CHAR(10),";
                    SQL += "IN `CodEmissor` INT(10),";
                    SQL += "IN `CodProf` INT(10),";
                    SQL += "IN `CodPromotor` INT(10),";
                    SQL += "IN `CodTerceiro` INT(10),";
                    SQL += "IN `ContaCTA` CHAR(16),";
                    SQL += "IN `ContaEBTA` CHAR(15),";
                    SQL += "IN `Contato` CHAR(40),";
                    SQL += "IN `ContaVisa` CHAR(16),";
                    SQL += "IN `CreditoCheque` CHAR(1),";
                    SQL += "IN `CreditoDinCC` CHAR(1),";
                    SQL += "IN `CreditoOutros` CHAR(1),";
                    SQL += "IN `CSCartao1` CHAR(5),";
                    SQL += "IN `CSCartao2` CHAR(5),";
                    SQL += "IN `CSCartao3` CHAR(5),";
                    SQL += "IN `DataCad` DATETIME,";
                    SQL += "IN `DataNasc` DATETIME,";
                    SQL += "IN `DtUltimaAlteracao` DATETIME,";
                    SQL += "IN `EMail` CHAR(60),";
                    SQL += "IN `EMailNFSe` CHAR(60),";
                    SQL += "IN `EmissVisto1` DATETIME,";
                    SQL += "IN `EmissVisto2` DATETIME,";
                    SQL += "IN `EndCobr` CHAR(40),";
                    SQL += "IN `EndCorresp` CHAR(1),";
                    SQL += "IN `EndRes` CHAR(40),";
                    SQL += "IN `EndTrab` CHAR(40),";
                    SQL += "IN `EstadoCivil` VARCHAR(1),";
                    SQL += "IN `Fantasia` CHAR(40),";
                    SQL += "IN `FaxRes` CHAR(20),";
                    SQL += "IN `FaxTrab` CHAR(20),";
                    SQL += "IN `Filiacao` CHAR(70),";
                    SQL += "IN `FoneRefBco` CHAR(20),";
                    SQL += "IN `FoneRefCom` CHAR(20),";
                    SQL += "IN `FoneRes` CHAR(20),";
                    SQL += "IN `FoneTrab` CHAR(20),";
                    SQL += "IN `Fumante` CHAR(1),";
                    SQL += "IN `Funcao` CHAR(30),";
                    SQL += "IN `GeraFatPDF` CHAR(1),";
                    SQL += "IN `IndicePontosCli` DOUBLE(15,5),";
                    SQL += "IN `InscrEstadual` CHAR(14),";
                    SQL += "IN `InscrMunicipal` CHAR(14),";
                    SQL += "IN `ItensFatura` SMALLINT(5),";
                    SQL += "IN `LeiKandir` CHAR(1),";
                    SQL += "IN `LimiteUnit` DOUBLE(15,5),";
                    SQL += "IN `LocalTrab` CHAR(40),";
                    SQL += "IN `MneCli` CHAR(14),";
                    SQL += "IN `Nacionalidade` CHAR(25),";
                    SQL += "IN `Naturalidade` CHAR(25),";
                    SQL += "IN `Nome` CHAR(40),";
                    SQL += "IN `NomeVisto1` CHAR(10),";
                    SQL += "IN `NomeVisto2` CHAR(10),";
                    SQL += "IN `NroCartao1` CHAR(20),";
                    SQL += "IN `NroCartao2` CHAR(20),";
                    SQL += "IN `NroCartao3` CHAR(20),";
                    SQL += "IN `NroCartao4` CHAR(20),";
                    SQL += "IN `NroCia1` CHAR(15),";
                    SQL += "IN `NroCia2` CHAR(15),";
                    SQL += "IN `NroCia3` CHAR(15),";
                    SQL += "IN `NroCia4` CHAR(15),";
                    SQL += "IN `ObrigaCentroCusto` CHAR(1),";
                    SQL += "IN `ObrigaObservacao` CHAR(1),";
                    SQL += "IN `Observacoes` LONGTEXT,";
                    SQL += "IN `Orgao` CHAR(5),";
                    SQL += "IN `Original_CodCli` INT(10),";
                    SQL += "IN `Passaporte` CHAR(40),";
                    SQL += "IN `PercentPontosCli` DOUBLE(15,5),";
                    SQL += "IN `PeriodoFatura` CHAR(20),";
                    SQL += "IN `PostoVen` INT(10),";
                    SQL += "IN `PotCres` CHAR(1),";
                    SQL += "IN `RefBco` LONGTEXT,";
                    SQL += "IN `RefCom` CHAR(40),";
                    SQL += "IN `Renda` DOUBLE(15,5),";
                    SQL += "IN `RG` CHAR(11),";
                    SQL += "IN `RGUF` CHAR(2),";
                    SQL += "IN `Sexo` CHAR(1),";
                    SQL += "IN `SitCli` VARCHAR(50),";
                    SQL += "IN `SitCredito` CHAR(1),";
                    SQL += "IN `StatusCli` CHAR(1),";
                    SQL += "IN `TempoRes` SMALLINT(5),";
                    SQL += "IN `TempoTrab` SMALLINT(5),";
                    SQL += "IN `TipoCli` INT(10),";
                    SQL += "IN `TipoNewsletter` CHAR(1),";
                    SQL += "IN `TipoPessoa` CHAR(1),";
                    SQL += "IN `Titular` CHAR(1),";
                    SQL += "IN `TitularCartao1` CHAR(40),";
                    SQL += "IN `TitularCartao2` CHAR(40),";
                    SQL += "IN `TitularCartao3` CHAR(40),";
                    SQL += "IN `TituloMala` CHAR(40),";
                    SQL += "IN `UltimaAlteracaoPor` CHAR(20),";
                    SQL += "IN `ValEstra` CHAR(1),";
                    SQL += "IN `ValidCartao1` CHAR(6),";
                    SQL += "IN `ValidCartao2` CHAR(6),";
                    SQL += "IN `ValidCartao3` CHAR(6),";
                    SQL += "IN `ValidCartao4` CHAR(6),";
                    SQL += "IN `ValidPassaporte` DATETIME,";
                    SQL += "IN `ValidVisto1` DATETIME,";
                    SQL += "IN `ValidVisto2` DATETIME,";
                    SQL += "IN `VenctoCartao1` CHAR(2),";
                    SQL += "IN `VenctoCartao2` CHAR(2),";
                    SQL += "IN `VenctoCartao3` CHAR(2),";
                    SQL += "IN `VenctoCartao4` CHAR(2),";
                    SQL += "IN `VlrTxBco` DOUBLE(15,5)";
                    SQL += ")\r\n";
                    SQL += "BEGIN\r\n";
                    SQL += "UPDATE Clientes2 SET ";
                    SQL += "Contato = Contato,";
                    SQL += "Sexo = Sexo,";
                    SQL += "EndRes = EndRes,";
                    SQL += "FoneRes = FoneRes,";
                    SQL += "FaxRes = FaxRes,";
                    SQL += "CodCidadeRes = CodCidadeRes,";
                    SQL += "CEPRes = CEPRes,";
                    SQL += "TempoRes = TempoRes,";
                    SQL += "Filiacao = Filiacao,";
                    SQL += "DataNasc = DataNasc,";
                    SQL += "CIC = CIC,";
                    SQL += "RG = RG,";
                    SQL += "Orgao = Orgao,";
                    SQL += "RGUF = RGUF,";
                    SQL += "Nacionalidade = Nacionalidade,";
                    SQL += "Naturalidade = Naturalidade,";
                    SQL += "InscrEstadual = InscrEstadual,";
                    SQL += "CGC = CGC,";
                    SQL += "EstadoCivil = EstadoCivil,";
                    SQL += "EMail = EMail,";
                    SQL += "Passaporte = Passaporte,";
                    SQL += "ValidPassaporte = ValidPassaporte,";
                    SQL += "NomeVisto1 = NomeVisto1,";
                    SQL += "NomeVisto2 = NomeVisto2,";
                    SQL += "ValidVisto1 = ValidVisto1,";
                    SQL += "ValidVisto2 = ValidVisto2,";
                    SQL += "EndTrab = EndTrab,";
                    SQL += "CodCidadeTrab = CodCidadeTrab,";
                    SQL += "CEPTrab = CEPTrab,";
                    SQL += "FoneTrab = FoneTrab,";
                    SQL += "FaxTrab = FaxTrab,";
                    SQL += "TempoTrab = TempoTrab,";
                    SQL += "Renda = Renda,";
                    SQL += "RefCom = RefCom,";
                    SQL += "FoneRefCom = FoneRefCom,";
                    SQL += "RefBco = RefBco,";
                    SQL += "FoneRefBco = FoneRefBco,";
                    SQL += "Cia1 = Cia1,";
                    SQL += "NroCia1 = NroCia1,";
                    SQL += "Cia2 = Cia2,";
                    SQL += "NroCia2 = NroCia2,";
                    SQL += "Cia3 = Cia3,";
                    SQL += "NroCia3 = NroCia3,";
                    SQL += "Cia4 = Cia4,";
                    SQL += "NroCia4 = NroCia4,";
                    SQL += "DataCad = DataCad,";
                    SQL += "CodContabil = CodContabil,";
                    SQL += "Fumante = Fumante,";
                    SQL += "Assento = Assento,";
                    SQL += "EndCobr = EndCobr,";
                    SQL += "CodCidadeCobr = CodCidadeCobr,";
                    SQL += "CEPCobr = CEPCobr,";
                    SQL += "EndCorresp = EndCorresp,";
                    SQL += "SitCredito = SitCredito,";
                    SQL += "Observacoes = Observacoes,";
                    SQL += "CartaoCred1 = CartaoCred1,";
                    SQL += "CartaoCred2 = CartaoCred2,";
                    SQL += "CartaoCred3 = CartaoCred3,";
                    SQL += "CartaoCred4 = CartaoCred4,";
                    SQL += "NroCartao1 = NroCartao1,";
                    SQL += "NroCartao2 = NroCartao2,";
                    SQL += "NroCartao3 = NroCartao3,";
                    SQL += "NroCartao4 = NroCartao4,";
                    SQL += "ValidCartao1 = ValidCartao1,";
                    SQL += "ValidCartao2 = ValidCartao2,";
                    SQL += "ValidCartao3 = ValidCartao3,";
                    SQL += "ValidCartao4 = ValidCartao4,";
                    SQL += "TituloMala = TituloMala,";
                    SQL += "TipoPessoa = TipoPessoa,";
                    SQL += "VenctoCartao1 = VenctoCartao1,";
                    SQL += "VenctoCartao2 = VenctoCartao2,";
                    SQL += "VenctoCartao3 = VenctoCartao3,";
                    SQL += "VenctoCartao4 = VenctoCartao4,";
                    SQL += "DtUltimaAlteracao = DtUltimaAlteracao,";
                    SQL += "UltimaAlteracaoPor = UltimaAlteracaoPor,";
                    SQL += "EmissVisto1 = EmissVisto1,";
                    SQL += "EmissVisto2 = EmissVisto2,";
                    SQL += "Funcao = Funcao,";
                    SQL += "ChaveLivre1 = ChaveLivre1,";
                    SQL += "ChaveLivre2 = ChaveLivre2,";
                    SQL += "AssinaNewsletter = AssinaNewsletter,";
                    SQL += "TipoNewsletter = TipoNewsletter,";
                    SQL += "CreditoDinCC = CreditoDinCC,";
                    SQL += "CreditoCheque = CreditoCheque,";
                    SQL += "CreditoOutros = CreditoOutros,";
                    SQL += "PotCres = PotCres,";
                    SQL += "ValEstra = ValEstra,";
                    SQL += "ContaEBTA = ContaEBTA,";
                    SQL += "Fantasia = Fantasia,";
                    SQL += "Bairro = Bairro,";
                    SQL += "TitularCartao1 = TitularCartao1,";
                    SQL += "TitularCartao2 = TitularCartao2,";
                    SQL += "TitularCartao3 = TitularCartao3,";
                    SQL += "CSCartao1 = CSCartao1,";
                    SQL += "CSCartao2 = CSCartao2,";
                    SQL += "CSCartao3 = CSCartao3,";
                    SQL += "VlrTxBco = VlrTxBco,";
                    SQL += "ContaCTA = ContaCTA,";
                    SQL += "ContaVisa = ContaVisa,";
                    SQL += "ObrigaCentroCusto = ObrigaCentroCusto,";
                    SQL += "ObrigaObservacao = ObrigaObservacao,";
                    SQL += "LimiteUnit = LimiteUnit,";
                    SQL += "InscrMunicipal = InscrMunicipal,";
                    SQL += "EMailNFSe = EMailNFSe ";
                    SQL += "WHERE Clientes2.CodCli = Original_CodCli;\r\n";
                    SQL += "UPDATE Clientes1 SET ";
                    SQL += "Nome = Nome,";
                    SQL += "LocalTrab = LocalTrab,";
                    SQL += "CodProf = CodProf,";
                    SQL += "CodBco = CodBco,";
                    SQL += "TipoCli = TipoCli,";
                    SQL += "SitCli = SitCli,";
                    SQL += "PostoVen = PostoVen,";
                    SQL += "CodPromotor = CodPromotor,";
                    SQL += "Titular = Titular,";
                    SQL += "MneCli = MneCli,";
                    SQL += "LeiKandir = LeiKandir,";
                    SQL += "StatusCli = StatusCli,";
                    SQL += "IndicePontosCli = IndicePontosCli,";
                    SQL += "PercentPontosCli = PercentPontosCli,";
                    SQL += "CodEmissor = CodEmissor,";
                    SQL += "CodTerceiro = CodTerceiro,";
                    SQL += "GeraFatPDF = GeraFatPDF,";
                    SQL += "AgrupaCodCtbForn = AgrupaCodCtbForn,";
                    SQL += "AgrupaTipoCobra = AgrupaTipoCobra,";
                    SQL += "AgrupaCatProd = AgrupaCatProd,";
                    SQL += "AgrupaProd = AgrupaProd,";
                    SQL += "AgrupaForn = AgrupaForn,";
                    SQL += "AgrupaCC = AgrupaCC,";
                    SQL += "AgrupaPax = AgrupaPax,";
                    SQL += "AgrupaReq = AgrupaReq,";
                    SQL += "PeriodoFatura = PeriodoFatura,";
                    SQL += "ItensFatura = ItensFatura,";
                    SQL += "AgrupaReqCliente = AgrupaReqCliente,";
                    SQL += "AgrupaSolicitante = AgrupaSolicitante ";
                    SQL += "WHERE Clientes1.CodCli = Original_CodCli;\r\n";
                    SQL += "END\r\n";
                    oDBManager.ExecuteCommand(SQL);

                    //**************************
                    //* Insere progresso no LOG
                    //**************************
                    Log += "Stored Routine CLIENTES_UPDATE criada com sucesso.<br />";
                }

                #endregion
            }
            catch(Exception oException)
            {
                //**************************
                //* Insere progresso no LOG
                //**************************
                Log += "Houve falha no processo. Mensagem retornada:<br /><br />";
                Log += oException.Message;
            }


            //**************************
            //* Retorna LOG de execução
            //**************************
            return Log;
        }
        public Int32 InitializeSecurity(Login_Manager oLogin)
        {
            //***********************************
            //* Os dados de conexão são válidos?
            //***********************************
            if (oLogin.LoginInfo.Usuario_Codigo == 0)
                return 0;

            //********************************
            //* Coleção de ítens de segurança
            //********************************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTablePermissoes = new DataTable();
            DataTable oTableGrupos = new DataTable();
            string SQL = string.Empty;

            //****************************
            //* Obtem todas as permissões
            //****************************
            SQL = "SELECT ";
            SQL += "permissoes_opcoes.codpermissao,";
            SQL += "permissoes_opcoes.chavepermissao,";
            SQL += "permissoes_opcoes.descricaopermissao,";
            SQL += "permissoes_opcoes.posicao,";
            SQL += "permissoes_opcoes.simples,";
            SQL += "grupos.codgrupo,";
            SQL += "grupos.descgrupo,";
            SQL += "permissoes_grupos.codagrupamento,";
            SQL += "permissoes_grupos.acesso,";
            SQL += "permissoes_grupos.inclusao,";
            SQL += "permissoes_grupos.alteracao,";
            SQL += "permissoes_grupos.exclusao ";
            SQL += "FROM permissoes_grupos ";
            SQL += "LEFT JOIN permissoes_opcoes ON permissoes_opcoes.codpermissao = permissoes_grupos.codpermissao ";
            SQL += "LEFT JOIN grupos ON grupos.codgrupo = permissoes_grupos.codgrupo ";
            SQL += "WHERE permissoes_grupos.codgrupo = " + oLogin.LoginInfo.Usuario_CodigoGrupo + " ";
            SQL += "ORDER BY permissoes_opcoes.chavepermissao";
            oTablePermissoes = oDBManager.ExecuteQuery(SQL);

            //****************************
            //* Anula lista de permissões
            //****************************
            _Permissions.Clear();

            //************************************
            //* Recuperou permissões com sucesso?
            //************************************
            if (oTablePermissoes != null)
            {
                //******************************
                //* Carrega todas as permissões
                //******************************
                foreach (DataRow oRowPermissoes in oTablePermissoes.Rows)
                {
                    //********************
                    //* Adiciona pemissão
                    //********************
                    _Permissions.Add(new Security_Fields(
                                     Convert.ToInt32(oRowPermissoes["codagrupamento"]),
                                     Convert.ToInt32(oRowPermissoes["codpermissao"]),
                                     oRowPermissoes["chavepermissao"].ToString(),
                                     oRowPermissoes["descricaopermissao"].ToString(),
                                     oRowPermissoes["posicao"].ToString(),
                                     Convert.ToInt32("0" + oRowPermissoes["codgrupo"]),
                                     oRowPermissoes["descgrupo"].ToString(),
                                     Convert.ToBoolean(oRowPermissoes["simples"]),
                                     Convert.ToBoolean(oRowPermissoes["acesso"]),
                                     Convert.ToBoolean(oRowPermissoes["inclusao"]),
                                     Convert.ToBoolean(oRowPermissoes["alteracao"]),
                                     Convert.ToBoolean(oRowPermissoes["exclusao"])));
                }
            }

            //***********************************
            //* Retorna quantidade de permissões
            //***********************************
            return Permissions.Count;
        }
        public bool FindInText(MenuItem oItem)
        {
            //**************************
            //* Localiza texto idêntico
            //**************************
            return oItem.Text.Equals(MenuText);
        }
        public void MenuSecurity(Login_Manager oLogin, ASPxNavBar oMenu)
        {
            //**************
            //* Declarações
            //**************
            NavBarItem oItem;

            //***********************************
            //* Define permissão geral dos menus
            //***********************************
            //*** Agenda ***
            MenuText = "Agenda de Compromissos";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Agenda);

            //*** Oportunidades ***
            MenuText = "Gerenciamento de Oportunidades";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Oportunidade);

            //*** Segurança > Usuários ***
            MenuText = "Gerenciamento de Usuários";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Usuario);

            //*** Segurança > Grupos de Permissão ***
            MenuText = "Grupos de Permissões";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Permissoes);

            //*** Configurações > Envio de E-mail ***
            MenuText = "Envio de E-mail";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Gerenciamento_Configuracoes);

            //*** Cadastros > Cadastro de Clientes ***
            MenuText = "Cadastro de Clientes";
            oItem = oMenu.Items.FindByText(MenuText);
            oItem.Enabled = this.IsActive(oLogin, (int)OptionLists.Seguranca.Cadastro_Clientes);
        }
        public bool IsPermissionInGroup(Login_Manager oLogin, Int32 CodPermission, Int32 CodGroup, Int32 CodGrouping)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTablePermissoes = new DataTable();
            string SQL = string.Empty;

            //********************************************
            //* Localiza permissão específica em um grupo
            //********************************************
            SQL = "SELECT permissoes_grupos.codpermissao FROM permissoes_grupos WHERE ";
            SQL += "permissoes_grupos.codgrupo = " + CodGroup + " AND ";
            SQL += "permissoes_grupos.codpermissao = " + CodPermission;
            if (CodGrouping != 0)
                SQL += " AND permissoes_grupos.codagrupamento <> " + CodGrouping;
            oTablePermissoes = oDBManager.ExecuteQuery(SQL);

            //*****************************
            //* A permissão foi localizada
            //*****************************
            if (oTablePermissoes.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool IsSimpleGroupPermission(Login_Manager oLogin, Int32 CodGrouping)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTablePermissoes = new DataTable();
            string SQL = string.Empty;

            //****************************************
            //* Localiza permissão através do vínculo
            //****************************************
            SQL = "SELECT permissoes_opcoes.simples FROM permissoes_grupos ";
            SQL += "LEFT JOIN permissoes_opcoes ON permissoes_opcoes.codpermissao = permissoes_grupos.codpermissao ";
            SQL += "WHERE permissoes_grupos.codagrupamento = " + CodGrouping;
            oTablePermissoes = oDBManager.ExecuteQuery(SQL);

            //*****************************
            //* A permissão foi localizado
            //*****************************
            if (oTablePermissoes.Rows.Count > 0)
                return Convert.ToBoolean(oTablePermissoes.Rows[0]["simples"]);
            else
                return false;
        }
        public bool IsSimplePermission(Login_Manager oLogin, Int32 CodPermission)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(oLogin.LoginInfo.Master_ConexaoString);
            DataTable oTablePermissoes = new DataTable();
            string SQL = string.Empty;

            //****************************************
            //* Localiza permissão através do vínculo
            //****************************************
            SQL = "SELECT permissoes_opcoes.simples FROM permissoes_opcoes WHERE permissoes_opcoes.codpermissao = " + CodPermission;
            oTablePermissoes = oDBManager.ExecuteQuery(SQL);

            //*****************************
            //* A permissão foi localizado
            //*****************************
            if (oTablePermissoes.Rows.Count > 0)
                return Convert.ToBoolean(oTablePermissoes.Rows[0]["simples"]);
            else
                return false;
        }

        #region "IsActive"
            public bool IsActive(Login_Manager oLogin, Int32 PermissionCode)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.CodigoPermissao == PermissionCode);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Autorizacao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }
            public bool IsActive(Login_Manager oLogin, string PermissionName)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.ChavePermissao == PermissionName);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Autorizacao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }

        #endregion

        #region "CanUpdate"
            public bool CanUpdate(Login_Manager oLogin, Int32 PermissionCode)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.CodigoPermissao == PermissionCode);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Alteracao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }
            public bool CanUpdate(Login_Manager oLogin, string PermissionName)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.ChavePermissao == PermissionName);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Alteracao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }

        #endregion

        #region "CanDelete"
            public bool CanDelete(Login_Manager oLogin, Int32 PermissionCode)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.CodigoPermissao == PermissionCode);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Exclusao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }
            public bool CanDelete(Login_Manager oLogin, string PermissionName)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.ChavePermissao == PermissionName);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Exclusao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }

        #endregion

        #region "CanInsert"
            public bool CanInsert(Login_Manager oLogin, Int32 PermissionCode)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.CodigoPermissao == PermissionCode);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Inclusao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }
            public bool CanInsert(Login_Manager oLogin, string PermissionName)
            {
                //*************************************
                //* Localiza permissão dentro da lista
                //*************************************
                Security_Fields oPermission = Permissions.Find(oPermissionItem => oPermissionItem.ChavePermissao == PermissionName);
                if (oPermission != null)
                {
                    //*********************************
                    //* Devolve definição de permissão
                    //*********************************
                    return oPermission.Inclusao;
                }
                else
                {
                    //*************
                    //* Sem acesso
                    //*************
                    return false;
                }
            }

        #endregion
    }
}