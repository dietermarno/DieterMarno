using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Net.Configuration;
using Decision.Extensions;
using Decision.Lists;
using Decision.Database;
using Decision.TableManager;
using Decision.LoginManager;

namespace Decision.Util
{
    public class SendEmail
    {
        //*****************************
        //* Objetos privados do módulo
        //*****************************
        MailMessage oMailMessage = new MailMessage();
        Login_Manager oLogin = new Login_Manager();
        SmtpClient oSmtpClient = new SmtpClient();
        WebClient oHTTPClient = new WebClient();
        public SendEmail()
        {
            //************************
            //* Existe sessão válida?
            //************************
            if (HttpContext.Current.Session["Decision_LoginInfo"] == null)
                return;

            //***********************
            //* Obtem dados de login
            //***********************
            oLogin = (Login_Manager)HttpContext.Current.Session["Decision_LoginInfo"];

            //**************************************
            //* Obtem configuração de e-mail válida
            //**************************************
            if (!ObtemConfiguracaoUsuario())
                if (!ObtemConfiguracaoPadrao())
                    ObtemConfiguracaoWebConfig();
        }
        private bool ObtemConfiguracaoUsuario()
        {
            //*******************************************
            //* A configuração SMTP do usuário é válida?
            //*******************************************
            if (oLogin.LoginInfo.SMTP_endereco.Trim() == string.Empty || oLogin.LoginInfo.SMTP_porta < 25)
                return false;
            else
                if (oLogin.LoginInfo.SMTP_autenticacao)
                    if (oLogin.LoginInfo.SMTP_usuario.Trim() == string.Empty || oLogin.LoginInfo.SMTP_senha.Trim() == string.Empty)
                        return false;

            //*******************************
            //* Define configuração de envio
            //*******************************
            oSmtpClient.UseDefaultCredentials = !oLogin.LoginInfo.SMTP_autenticacao;
            oSmtpClient.Credentials = new NetworkCredential(oLogin.LoginInfo.SMTP_usuario.Trim(), oLogin.LoginInfo.SMTP_senha.Trim());
            oSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            oSmtpClient.EnableSsl = oLogin.LoginInfo.SMTP_ssl;
            oSmtpClient.Host = oLogin.LoginInfo.SMTP_endereco.Trim();
            oSmtpClient.Port = oLogin.LoginInfo.SMTP_porta;
            oSmtpClient.Timeout = 100000;
            return true;
        }
        private bool ObtemConfiguracaoPadrao()
        {
            //**************************************
            //* Obtem configurações gerais de envio
            //**************************************
            Config_Manager oConfigManager = new Config_Manager(oLogin.LoginInfo.Master_ConexaoString);
            Config_Fields oConfig = oConfigManager.GetRecord();

            //***********************************************
            //* Os dados da configuração padrão são válidos?
            //***********************************************
            if (oConfig.SMTP_Endereco.Trim() == string.Empty || oConfig.SMTP_Porta < 25)
                return false;
            else
                if (oConfig.SMTP_Autenticacao)
                    if (oConfig.SMTP_Usuario.Trim() == string.Empty || oConfig.SMTP_Senha.Trim() == string.Empty)
                        return false;

            //*******************************
            //* Define configuração de envio
            //*******************************
            oSmtpClient.UseDefaultCredentials = !oConfig.SMTP_Autenticacao;
            oSmtpClient.Credentials = new NetworkCredential(oConfig.SMTP_Usuario.Trim(), oConfig.SMTP_Senha.Trim());
            oSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            oSmtpClient.EnableSsl = oConfig.SMTP_SSL;
            oSmtpClient.Host = oConfig.SMTP_Endereco.Trim();
            oSmtpClient.Port = oConfig.SMTP_Porta;
            oSmtpClient.Timeout = 100000;
            return true;
        }
        private bool ObtemConfiguracaoWebConfig()
        {
            //*******************************************
            //* Obtem configurações gerais do WEB.CONFIG
            //*******************************************
            System.Configuration.Configuration oConfig;
            oConfig = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup oSettings;
            oSettings = (MailSettingsSectionGroup)oConfig.GetSectionGroup("system.net/mailSettings");

            //***********************************************
            //* Os dados da configuração padrão são válidos?
            //***********************************************
            if (oSettings.Smtp.Network.Host.Trim() == string.Empty || oSettings.Smtp.Network.Port < 25)
                return false;
            else
                if (!oSettings.Smtp.Network.DefaultCredentials)
                    if (oSettings.Smtp.Network.UserName.Trim() == string.Empty || oSettings.Smtp.Network.Password.Trim() == string.Empty)
                        return false;

            //*******************************
            //* Define configuração de envio
            //*******************************
            oSmtpClient.UseDefaultCredentials = oSettings.Smtp.Network.DefaultCredentials;
            oSmtpClient.Credentials = new NetworkCredential(oSettings.Smtp.Network.UserName.Trim(), oSettings.Smtp.Network.Password.Trim());
            oSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            oSmtpClient.EnableSsl = oSettings.Smtp.Network.EnableSsl;
            oSmtpClient.Host = oSettings.Smtp.Network.Host;
            oSmtpClient.Port = oSettings.Smtp.Network.Port;
            oSmtpClient.Timeout = 100000;
            return true;
        }
        public Login_Fields EnviaTesteSMTP(Login_Fields oJSON, Int32 Master_Codigo)
        {
            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //***************
            //* Efetua envio
            //***************
            try
            {
                //*******************************
                //* Define configuração de envio
                //*******************************
                oSmtpClient.UseDefaultCredentials = !oJSON.SMTP_autenticacao;
                oSmtpClient.Credentials = new NetworkCredential(oJSON.SMTP_usuario.Trim(), oJSON.SMTP_senha.Trim());
                oSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                oSmtpClient.EnableSsl = oJSON.SMTP_ssl;
                oSmtpClient.Host = oJSON.SMTP_endereco.Trim();
                oSmtpClient.Port = oJSON.SMTP_porta;
                oSmtpClient.Timeout = 10000;
                    
                //***************
                //* Captura HTML
                //***************
                oHTTPClient.Encoding = System.Text.Encoding.UTF8;
                string URL = "/smtp_teste_email.aspx";
                URL += "?CMA=" + Master_Codigo;
                URL += "&CPO=" + oJSON.Posto_Codigo;
                URL += "&Destinatario=" + oJSON.Parametros["NomeDestinatario"];
                string Html = oHTTPClient.DownloadString(HTML_Base + URL);

                //************************
                //* Define dados de envio
                //************************
                oMailMessage.To.Add(new MailAddress(oJSON.Parametros["EmailDestinatario"], oJSON.Parametros["NomeDestinatario"]));
                oMailMessage.Subject = "Teste de servidor de envio (SMTP)";
                oMailMessage.IsBodyHtml = true;
                oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                oMailMessage.Body = Html;

                //**************************
                //* Envia e retorna sucesso
                //**************************
                oSmtpClient.Send(oMailMessage);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.ErrorText = oException.Message;
                oJSON.Error = true;
                return oJSON;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            oJSON.ErrorText = string.Empty;
            oJSON.Error = false;
            return oJSON;
        }
        public Config_Fields EnviaTesteSMTP(Config_Fields oJSON, Int32 Master_Codigo, Int32 Posto_Codigo)
        {
            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //***************
            //* Efetua envio
            //***************
            try
            {
                //*******************************
                //* Define configuração de envio
                //*******************************
                oSmtpClient.UseDefaultCredentials = !oJSON.SMTP_Autenticacao;
                oSmtpClient.Credentials = new NetworkCredential(oJSON.SMTP_Usuario.Trim(), oJSON.SMTP_Senha.Trim());
                oSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                oSmtpClient.EnableSsl = oJSON.SMTP_SSL;
                oSmtpClient.Host = oJSON.SMTP_Endereco.Trim();
                oSmtpClient.Port = oJSON.SMTP_Porta;
                oSmtpClient.Timeout = 10000;

                //***************
                //* Captura HTML
                //***************
                oHTTPClient.Encoding = System.Text.Encoding.UTF8;
                string URL = "/smtp_teste_email.aspx";
                URL += "?CMA=" + Master_Codigo;
                URL += "&CPO=" + Posto_Codigo;
                URL += "&Destinatario=" + oJSON.Parametros["NomeDestinatario"];
                string Html = oHTTPClient.DownloadString(HTML_Base + URL);

                //************************
                //* Define dados de envio
                //************************
                oMailMessage.To.Add(new MailAddress(oJSON.Parametros["EmailDestinatario"], oJSON.Parametros["NomeDestinatario"]));
                oMailMessage.Subject = "Teste de servidor de envio (SMTP)";
                oMailMessage.IsBodyHtml = true;
                oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                oMailMessage.Body = Html;

                //**************************
                //* Envia e retorna sucesso
                //**************************
                oSmtpClient.Send(oMailMessage);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.ErrorText = oException.Message;
                oJSON.Error = true;
                return oJSON;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            oJSON.ErrorText = string.Empty;
            oJSON.Error = false;
            return oJSON;
        }
        public string EnviaRecuperacaoSenha(Int32 CodigoMaster, string NomeEmpresa, Int32 CodigoPosto, string NomeUsuario, string Email, string IDUsuario, string Senha)
        {
            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //***************
            //* Efetua envio
            //***************
            try
            {
                //***************
                //* Captura HTML
                //***************
                oHTTPClient.Encoding = System.Text.Encoding.UTF8;
                string URL = "/recuperar_senha_email.aspx";
                URL += "?CMA=" + CodigoMaster;
                URL += "&CPO=" + CodigoPosto;
                URL += "&empresa=" + NomeEmpresa;
                URL += "&email=" + Email;
                URL += "&usuario=" + IDUsuario;
                URL += "&senha=" + Senha;
                string Html = oHTTPClient.DownloadString(HTML_Base + URL);

                //************************
                //* Define dados de envio
                //************************
                if (NomeUsuario != string.Empty)
                    oMailMessage.To.Add(new MailAddress(Email, NomeUsuario));
                else
                    oMailMessage.To.Add(Email);
                oMailMessage.Subject = "Recuperação de Senha - Usuário " + IDUsuario;
                oMailMessage.IsBodyHtml = true;
                oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                oMailMessage.Body = Html;

                //**************************
                //* Envia e retorna sucesso
                //**************************
                oSmtpClient.Send(oMailMessage);
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                return oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return "Ok";
        }
        public Oportunidade_JSON EnviaBoasVindas(Oportunidade_JSON oJSON)
        {
            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //***************
            //* Captura HTML
            //***************
            oHTTPClient.Encoding = System.Text.Encoding.UTF8;
            string URL = "/oportunidades_boasvindas_email.aspx";
            URL += "?CMA=" + oJSON.parametros["CodigoMaster"];
            URL += "&CPO=" + oJSON.parametros["CodigoPosto"];
            URL += "&COP=" + oJSON.parametros["CodigoOportunidade"];
            URL += "&COR=0";
            string Html = oHTTPClient.DownloadString(HTML_Base + URL);

            //************************
            //* Define dados de envio
            //************************
            oMailMessage.To.Add(oJSON.oportunidade.contato_emails.MultiSeparator2Comma());
            oMailMessage.Subject = "Bem Vindo à " + oLogin.LoginInfo.Posto_Nome.ToUpper() + " - Solicitação de Proposta Recebida";
            oMailMessage.IsBodyHtml = true;
            oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            oMailMessage.Body = Html;

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oSmtpClient.Send(oMailMessage);
                oJSON.error = string.Empty;
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
        public Oportunidade_JSON EnviaOrcamento(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações 
            //**************
            Oportunidade_Manager oManagerOportunidade;
            oManagerOportunidade = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(HttpContext.Current.Session["Decision_LoginInfo"]));
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();

            Oportunidade_Orcamentos_Manager oManagerOrcamentos;
            oManagerOrcamentos = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(HttpContext.Current.Session["Decision_LoginInfo"]));
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();

            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //***************
            //* Captura HTML
            //***************
            oHTTPClient.Encoding = System.Text.Encoding.UTF8;
            string URL = "/oportunidades_orcamentonotificacao_email.aspx";
            URL += "?CMA=" + oJSON.parametros["CodigoMaster"];
            URL += "&CPO=" + oJSON.parametros["CodigoPosto"];
            URL += "&COP=" + oJSON.parametros["CodigoOportunidade"];
            URL += "&COR=" + oJSON.parametros["CodigoOrcamento"];
            string Html = oHTTPClient.DownloadString(HTML_Base + URL);

            //************************
            //* Define dados de envio
            //************************
            oMailMessage.To.Add(oJSON.oportunidade.contato_emails.MultiSeparator2Comma());
            oMailMessage.Subject = oLogin.LoginInfo.Posto_Nome.ToUpper() + " - Remessa de Orçamento";
            oMailMessage.IsBodyHtml = true;
            oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            oMailMessage.Body = Html;

            //***************
            //* Efetua envio
            //***************
            try
            {
                //**************************
                //* Envia e retorna sucesso
                //**************************
                oSmtpClient.Send(oMailMessage);

                //**************************************************
                //* Associa dados e altera situação da oportunidade
                //**************************************************
                oOportunidade = oJSON.oportunidade;
                oOportunidade.cod_situacao = (int)Lists.OptionLists.OportunidadeStuacao.Analise;
                oManagerOportunidade.ApplyRecord(oOportunidade);

                //***********************************************
                //* Associa dados e altera resposta do orçamento
                //***********************************************
                var Indice_Orcamento = Convert.ToInt32(oJSON.parametros["IndiceOrcamento"]);
                
                //*******************************************************************************************
                //* SERVER_DATA: Anula reposta anterior, marca como pendente e atualiza estágio do orçamento
                //*******************************************************************************************
                oOrcamento = oJSON.orcamentos[Indice_Orcamento];
                oOrcamento.html_resposta = "";
                oOrcamento.pendencia = true;
                oOrcamento.estagio_orcamento = (int)Lists.OptionLists.OrcamentoEstagio.Enviado;
                oManagerOrcamentos.ApplyRecord(oOrcamento);

                //*****************************************************************************************
                //* JSON_DATA: Anula reposta anterior, marca como pendente e atualiza estágio do orçamento
                //*****************************************************************************************
                oJSON.oportunidade.cod_situacao = oOportunidade.cod_situacao;
                oJSON.orcamentos[Indice_Orcamento].html_resposta = "";
                oJSON.orcamentos[Indice_Orcamento].pendencia = true;
                oJSON.orcamentos[Indice_Orcamento].estagio_orcamento = (int)Lists.OptionLists.OrcamentoEstagio.Enviado;

                //**********************************
                //* Marca processo como bm sucedido
                //**********************************
                oJSON.error = string.Empty;
            }
            catch (Exception oException)
            {
                //*************************
                //* Retorna falha de envio
                //*************************
                oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
        public Oportunidade_JSON EnviaOrcamentosAceitos(Oportunidade_JSON oJSON)
        {
            //**************
            //* Declarações 
            //**************
            Oportunidade_Manager oManagerOportunidade;
            oManagerOportunidade = new Oportunidade_Manager(DBConnection.GetConnectionFromSession(HttpContext.Current.Session["Decision_LoginInfo"]));
            Oportunidade_Fields oOportunidade = new Oportunidade_Fields();

            Oportunidade_Orcamentos_Manager oManagerOrcamentos;
            oManagerOrcamentos = new Oportunidade_Orcamentos_Manager(DBConnection.GetConnectionFromSession(HttpContext.Current.Session["Decision_LoginInfo"]));
            Oportunidade_Orcamentos_Fields oOrcamento = new Oportunidade_Orcamentos_Fields();

            //**********************************
            //* Obtem base de carregamento HTML
            //**********************************
            string HTML_Base = Properties.Settings.Default.html_base;

            //**************************
            //* Obtem array de seleções
            //**************************
            string[] oListaOrcamento = oJSON.parametros["CodigoOrcamentoAceito"].ToString().Split(',');

            //*********************************************************
            //* Executa rotina para cara orçamento da lista de seleção
            //*********************************************************
            for (Int32 CIndice = 0; CIndice < oJSON.orcamentos.Length; CIndice++)
            {
                //**************************************
                //* O orçamento atual deve ser enviado?
                //**************************************
                if (Array.IndexOf(oListaOrcamento, oJSON.orcamentos[CIndice].PK_cod_orcamento.ToString()) > -1)
                {
                    //***************
                    //* Captura HTML
                    //***************
                    oHTTPClient.Encoding = System.Text.Encoding.UTF8;
                    string URL = "/oportunidades_orcamentonotificacao_email.aspx";
                    URL += "?CMA=" + oJSON.parametros["CodigoMaster"];
                    URL += "&CPO=" + oJSON.parametros["CodigoPosto"];
                    URL += "&COP=" + oJSON.parametros["CodigoOportunidade"];
                    URL += "&COR=" + oJSON.orcamentos[CIndice].PK_cod_orcamento.ToString();
                    string Html = oHTTPClient.DownloadString(HTML_Base + URL);

                    //************************
                    //* Define dados de envio
                    //************************
                    oMailMessage.To.Add(oJSON.oportunidade.contato_emails.MultiSeparator2Comma());
                    oMailMessage.Subject = oLogin.LoginInfo.Posto_Nome.ToUpper() + " - ";
                    oMailMessage.Subject += "Confirmação de Orçamento N° " + oJSON.orcamentos[CIndice].PK_cod_orcamento.ToString();
                    oMailMessage.IsBodyHtml = true;
                    oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                    oMailMessage.Body = Html;

                    //***************
                    //* Efetua envio
                    //***************
                    try
                    {
                        //**************************
                        //* Envia e retorna sucesso
                        //**************************
                        oSmtpClient.Send(oMailMessage);

                        //**************************************************
                        //* Associa dados e altera situação da oportunidade
                        //**************************************************
                        oOportunidade = oJSON.oportunidade;
                        oOportunidade.cod_situacao = (int)Lists.OptionLists.OportunidadeStuacao.Analise;
                        oManagerOportunidade.ApplyRecord(oOportunidade);

                        //*******************************************************************************************
                        //* SERVER_DATA: Anula reposta anterior, marca como pendente e atualiza estágio do orçamento
                        //*******************************************************************************************
                        oOrcamento = oJSON.orcamentos[CIndice];
                        oOrcamento.html_resposta = "";
                        oOrcamento.pendencia = true;
                        oOrcamento.estagio_orcamento = (int)Lists.OptionLists.OrcamentoEstagio.Enviado;
                        oManagerOrcamentos.ApplyRecord(oOrcamento);

                        //*****************************************************************************************
                        //* JSON_DATA: Anula reposta anterior, marca como pendente e atualiza estágio do orçamento
                        //*****************************************************************************************
                        oJSON.oportunidade.cod_situacao = oOportunidade.cod_situacao;
                        oJSON.orcamentos[CIndice].html_resposta = "";
                        oJSON.orcamentos[CIndice].pendencia = true;
                        oJSON.orcamentos[CIndice].estagio_orcamento = (int)Lists.OptionLists.OrcamentoEstagio.Enviado;

                        //**********************************
                        //* Marca processo como bm sucedido
                        //**********************************
                        oJSON.error = string.Empty;
                    }
                    catch (Exception oException)
                    {
                        //*************************
                        //* Retorna falha de envio
                        //*************************
                        oJSON.error = "Erro ao enviar mensagem: " + oException.Message;
                    }
                }
            }

            //*****************************
            //* Retorna status da operação
            //*****************************
            return oJSON;
        }
    }
}