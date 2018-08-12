<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master" AutoEventWireup="true" CodeBehind="oportunidades_edicao.aspx.cs" Inherits="Decision.oportunidades_edicao" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v16.2, Version=16.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:Content ID="cntOportunidades" ContentPlaceHolderID="cplCentral" runat="server">

    <script type="text/javascript">

        //**************
        //* Declarações
        //**************
        var oJSON;

        function EscondeScrollVertical(s, e)
        {
            //**************************
            //* Esconde scroll vertical
            //**************************
            s.GetInputElement().style.overflowY = 'hidden';
            AjustaAltura(s, e);
        }

        function AjustaAltura(s, e)
        {
            //*************************
            //* Ajusta altura do campo
            //*************************
            var minRows = 1;
            var maxRows = 26;
            var t = s.GetInputElement();
            if (t.scrollTop == 0) t.scrollTop = 1;
            while (t.scrollTop == 0) {
                if (t.rows > minRows)
                    t.rows--; else
                    break;
                t.scrollTop = 1;
                if (t.rows < maxRows)
                    t.style.overflowY = "hidden";
                if (t.scrollTop > 0) {
                    t.rows++;
                    break;
                }
            }
            while (t.scrollTop > 0) {
                if (t.rows < maxRows) {
                    t.rows++;
                    if (t.scrollTop == 0) t.scrollTop = 1;
                } else {
                    t.style.overflowY = "auto";
                    break;
                }
            }
        }

        function ValidaDataAtual(s, e)
        {
            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            var dataProposta = ASPxClientDateEdit.Cast(s).GetValue();
            var dataAtual = new Date();
            if (dataAtual > dataProposta)
            {
                //***********
                //* Notifica
                //***********
                e.isValid = false;
                e.errorText = "Data inferior a data atual";
            }
        }

        function ValidaDataViagem(s, e)
        {
            //*********************************
            //* Retorna para lista de cadastro
            //*********************************
            var startDateEdit = ASPxClientDateEdit.Cast(dteSaida);
            var startDate = startDateEdit.GetValue();

            var endDateEdit = ASPxClientDateEdit.Cast(dteRetorno);
            var endDate = endDateEdit.GetValue();

            if (startDate > endDate)
            {
                //***********
                //* Notifica
                //***********
                e.isValid = false;
                e.errorText = "Partida superior ao retorno";
            }
        }

        function InicializaJSON(s, e)
        {
            //*******************
            //* Apresenta LOADER
            //*******************
            pnlLoader.SetText("Carregando dados...");
            pnlLoader.Show();

            //***********************
            //* Solicita objeto JSON
            //***********************
            clbAtualizar.PerformCallback("");
        }

        function AjustaGuias(s, e)
        {
            //**************
            //* Fecha guias
            //**************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(false);
            nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(false);
            nvbEtapas.GetGroupByName("grpEncerramento").SetExpanded(false);

            //*********************
            //* Nova oportunidade?
            //*********************
            if (oJSON.oportunidade.PK_nro_oportunidade == 0)
            {
                //**************************
                //* Apenas guia de abertura
                //**************************
                nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);
                window.setTimeout("cboCanalEntrada.Focus()", 250);
            }
            else
            {
                //******************************************
                //* Determina abertura de acordo com status
                //******************************************
                switch (oJSON.oportunidade.cod_situacao)
                {
                    case 1:
                        //*******************
                        //* Guia de abertura
                        //*******************
                        nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);
                        window.setTimeout("cboCanalEntrada.Focus()", 250);
                        break;

                    case 2:
                        //************************************
                        //* Guia de orçamento ou encerramento
                        //************************************
                        if (oJSON.parametros["CodigoOrcamentoAceito"] == "0")
                        {
                            nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(true);
                            window.setTimeout("dteRetornoOrcamento.Focus()", 250);
                        }
                        else
                        {
                            nvbEtapas.GetGroupByName("grpEncerramento").SetExpanded(true);
                            window.setTimeout("txtValorEncerramento.Focus()", 250);
                        }
                        break;

                    case 3:
                        //********************
                        //* Guia de orçamento
                        //********************
                        nvbEtapas.GetGroupByName("grpEncerramento").SetExpanded(true);
                        window.setTimeout("txtValorEncerramento.Focus()", 250);
                        break;

                    case 4:
                        //********************
                        //* Guia de orçamento
                        //********************
                        nvbEtapas.GetGroupByName("grpEncerramento").SetExpanded(true);
                        window.setTimeout("txtValorEncerramento.Focus()", 250);
                        break;
                }
            }
        }

        function SalvaEtapa1(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //***************************
                //* Atualiza dados no objeto
                //***************************
                AtualizaJSON();

                //*********************************
                //* Atualiza registro via callback
                //*********************************
                oJSON.operacao = "Salvar_Etapa1";
                clbAtualizar.PerformCallback(JSON.stringify(oJSON));
            }
        }

        function SalvaEtapa2(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //****************************************************
            //* A etapa 1 (Abertura) foi corretamente preenchida?
            //****************************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //***************************
                //* Colapsa grupo da etapa 1
                //***************************
                nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(false);

                //***************************
                //* Expande grupo da etapa 2
                //***************************
                nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(true);

                //*****************************************************
                //* A etapa 2 (orçamento) foi corretamente preenchida?
                //*****************************************************
                if (ASPxClientEdit.ValidateGroup("Orcamento"))
                {
                    //*************************************************
                    //* Obtem código do orçamento e índice selecionado
                    //*************************************************
                    var Indice_Orcamento = 0;
                    var CodOrcamento = 0;
                    if (lstOrcamentos.GetSelectedIndex() != -1)
                        CodOrcamento = lstOrcamentos.GetSelectedItem().value;
                    Indice_Orcamento = lstOrcamentos.GetSelectedIndex();

                    //***************************
                    //* Atualiza dados no objeto
                    //***************************
                    AtualizaJSON();

                    //*********************************
                    //* Atualiza registro via callback
                    //*********************************
                    oJSON.operacao = "Salvar_Etapa2";
                    if (Indice_Orcamento > -1)
                        oJSON.parametros["IndiceOrcamento"] = Indice_Orcamento;
                    else
                        oJSON.parametros["IndiceOrcamento"] = 0;
                    oJSON.parametros["CodigoOrcamento"] = CodOrcamento;
                    clbAtualizar.PerformCallback(JSON.stringify(oJSON));
                }
            }
        }

        function SalvaEtapa3(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //****************************************************
            //* A etapa 1 (Abertura) foi corretamente preenchida?
            //****************************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //***************************
                //* Colapsa grupo da etapa 1
                //***************************
                nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(false);

                //***************************
                //* Expande grupo da etapa 2
                //***************************
                nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(true);

                //*****************************************************
                //* A etapa 2 (orçamento) foi corretamente preenchida?
                //*****************************************************
                if (ASPxClientEdit.ValidateGroup("Orcamento"))
                {
                    //***************************
                    //* Colapsa grupo da etapa 2
                    //***************************
                    nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(false);

                    //***************************
                    //* Expande grupo da etapa 3
                    //***************************
                    nvbEtapas.GetGroupByName("grpEncerramento").SetExpanded(true);

                    //********************************************************
                    //* A etapa 3 (encerramento) foi corretamente preenchida?
                    //********************************************************
                    if (ASPxClientEdit.ValidateGroup("Encerramento"))
                    {
                        //***************************
                        //* Atualiza dados no objeto
                        //***************************
                        AtualizaJSON();

                        //*********************************
                        //* Atualiza registro via callback
                        //*********************************
                        oJSON.operacao = "Salvar_Etapa3";
                        clbAtualizar.PerformCallback(JSON.stringify(oJSON));
                    }
                }
            }
        }
     
        function NovoOrcamento(s, e)
        {
            //*******************************
            //* Cancela execução no servidor
            //*******************************
            e.processOnServer = false;

            //*****************************************
            //* Há registro salvo para a oportunidade?
            //*****************************************
            if (oJSON.oportunidade.PK_nro_oportunidade > 0)
            {
                //********************************************
                //* Anula valores anteriores e desfaz seleção
                //********************************************
                lstOrcamentos.SetSelectedIndex(-1);
                cboEstagioOrcamento.SetSelectedIndex(0);
                dteRetornoOrcamento.SetValue(new Date());
                data_contato = new Date();
                data_contato.setDate(data_contato.getDate() + 2);
                dteProximoContatoOrcamento.SetValue(data_contato);
                txtProduto.SetText("");
                txtAssunto.SetText("");
                txtValorOrcamento.SetValue(0);
                htmOrcamento.SetHtml("");
                htmOrcamento.Focus();
                oJSON.parametros["IndiceOrcamento"] = "-1";
                oJSON.parametros["CodigoOrcamento"] = "0";
                oJSON.parametros["CodigoOrcamentoAceito"] = "0";
            }
            else
            {
                //**************************
                //* Exibe popup com retorno
                //**************************
                var Mensagem = "<br/><br/>Os dados da oportunidade ainda não foram salvos.";
                Mensagem += "<br/><br/>Para criar um novo orçamento, salve os dados de abertura da oportunidade antes.";
                jQuery("#divResposta").attr('align', 'center');
                jQuery("#divResposta").html(Mensagem);
                popResposta.SetHeaderText("Aviso");
                popResposta.AdjustSize();
                popResposta.Show();
            }
        }

        function ExcluiOrcamento(s, e)
        {
            //******************************
            //* Impede execução em servidor
            //******************************
            e.processOnServer = false;

            //***********************************
            //* Determina ação baseado no SENDER
            //***********************************
            if (s.mainElement.id.indexOf("cmdExcluirOrcamento") != -1 && lstOrcamentos.GetSelectedIndex() != -1)
                {
                    //**********************************
                    //* Abre exclusão e aguarda retorno
                    //**********************************
                    popExclusao.Show();
                    return;
                }
            else
                popExclusao.Hide();

            //********************************
            //* Existe orçamento selecionado?
            //********************************
            if (lstOrcamentos.GetSelectedIndex() != -1)
            {
                //********************
                //* Notifica exclusão
                //********************
                pnlLoader.SetText("Excluindo orçamento...");
                pnlLoader.Show();

                //****************************
                //* Obtem código do orçamento
                //****************************
                var Indice_Orcamento = 0;
                var CodOrcamento = 0;
                if (lstOrcamentos.GetSelectedIndex() != -1)
                    CodOrcamento = lstOrcamentos.GetSelectedItem().value;
                Indice_Orcamento = lstOrcamentos.GetSelectedIndex();

                //****************************
                //* Define dados do orçamento
                //****************************
                oJSON.operacao = "Excluir_Orcamento";
                oJSON.parametros["IndiceOrcamento"] = Indice_Orcamento;
                oJSON.parametros["CodigoOrcamento"] = CodOrcamento;

                //*******************************
                //* Exclui registro via callback
                //*******************************
                clbAtualizar.PerformCallback(JSON.stringify(oJSON));
            }
            else
            {
                //**************************
                //* Exibe popup com retorno
                //**************************
                var Mensagem = "<br/><br/>Não há orçamento selecionado a ser excluído.";
                jQuery("#divResposta").attr('align', 'center');
                jQuery("#divResposta").html(Mensagem);
                popResposta.SetHeaderText("Aviso");
                popResposta.AdjustSize();
                popResposta.Show();
                popExclusao.Hide();
            }
        }

        function SelecionaOrcamento(s, e)
        {
            //********************************
            //* Provoca atualização do editor
            //********************************

            //Salva índice da seleção
            oJSON.parametros["IndiceOrcamento"] = e.index;
            oJSON.parametros["CodigoOrcamento"] = oJSON.orcamentos[e.index].PK_cod_orcamento;

            //Data Retorno Orçamento
            dteRetornoOrcamento.SetValue(oJSON.orcamentos[e.index].data_orcamento);

            //Estágio do orçamento
            cboEstagioOrcamento.SetValue(oJSON.orcamentos[e.index].estagio_orcamento);

            //Data do Próximo Contato
            dteProximoContatoOrcamento.SetValue(oJSON.orcamentos[e.index].proximo_contato);

            //Nome do produto
            txtProduto.SetText(oJSON.orcamentos[e.index].produto);

            //Assunto do orçamento
            txtAssunto.SetText(oJSON.orcamentos[e.index].assunto);

            //Valor do orçamento
            if (oJSON.orcamentos[e.index].valor != null)
                txtValorOrcamento.SetValue(oJSON.orcamentos[e.index].valor);
            else
                txtValorOrcamento.SetValue(0);
            
            //HTML do Orçamento
            htmOrcamento.SetHtml(oJSON.orcamentos[e.index].html_orcamento);
        }

        function VerResposta(s, e)
        {
            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //***************************
                //* Colapsa grupo da etapa 1
                //***************************
                nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(false);

                //***************************
                //* Expande grupo da etapa 2
                //***************************
                nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(true);

                //*****************************************************
                //* A etapa 2 (orçamento) foi corretamente preenchida?
                //*****************************************************
                if (ASPxClientEdit.ValidateGroup("Orcamento"))
                {
                    //********************************
                    //* Existe orçamento selecionado?
                    //********************************
                    if (lstOrcamentos.GetSelectedIndex() != -1)
                    {
                        //*******************************
                        //* Exibe painel de carregamento
                        //*******************************
                        pnlLoader.SetText("Consultando dados...");
                        pnlLoader.Show();

                        //****************************
                        //* Obtem código do orçamento
                        //****************************
                        Cod_Orcamento = oJSON.parametros["CodigoOrcamento"];

                        //**************************************
                        //* Define parâmetros e realiza chamada
                        //**************************************
                        oJSON.operacao = "Coletar_Resposta";
                        oJSON.parametros["CodigoOrcamento"] = Cod_Orcamento;
                        clbAtualizar.PerformCallback(JSON.stringify(oJSON));
                    }
                    else
                    {
                        //**************************
                        //* Exibe popup com retorno
                        //**************************
                        var Mensagem = "<br/><br/>Não há um orçamento selecionado.";
                        Mensagem += "<br/><br/>É necessário salvar um orçamento, e enviá-lo antes de viaualizar a resposta do cliente.";
                        jQuery("#divResposta").attr('align', 'center');
                        jQuery("#divResposta").html(Mensagem);
                        popResposta.SetHeaderText("Resposta do Cliente");
                        popResposta.AdjustSize();
                        popResposta.Show();
                    }
                }
            }
        }

        function EnviarBoasVindas(s, e)
        {
            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //*****************************************
                //* Há registro salvo para a oportunidade?
                //*****************************************
                if (oJSON.oportunidade.PK_nro_oportunidade > 0)
                {
                    //********************
                    //* Notifica exclusão
                    //********************
                    pnlLoader.SetText("Enviando mensagem...");
                    pnlLoader.Show();

                    //****************************
                    //* Obtem código do orçamento
                    //****************************
                    var Cod_Orcamento = 0;
                    if (lstOrcamentos.GetSelectedIndex() != -1)
                        var Cod_Orcamento = lstOrcamentos.GetSelectedItem().value;

                    //***************************
                    //* Atualiza dados no objeto
                    //***************************
                    AtualizaJSON();

                    //***************************
                    //* Obtem dados via callback
                    //***************************
                    oJSON.operacao = "Enviar_Boas_Vindas";
                    oJSON.parametros["CodigoOrcamento"] = Cod_Orcamento;
                    clbAtualizar.PerformCallback(JSON.stringify(oJSON));
                }
                else
                {
                    //**************************
                    //* Exibe popup com retorno
                    //**************************
                    var Mensagem = "<br/><br/>Os dados da oportunidade ainda não foram salvos.";
                    Mensagem += "<br/><br/>Para enviar a mensagem, salve os dados de abertura da oportunidade antes.";
                    jQuery("#divResposta").attr('align', 'center');
                    jQuery("#divResposta").html(Mensagem);
                    popResposta.SetHeaderText("Envio de Boas Vindas");
                    popResposta.AdjustSize();
                    popResposta.Show();
                }
            }
        }

        function EnviarOrcamento(s, e)
        {
            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //***************************
            //* Expande grupo da etapa 1
            //***************************
            nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(true);

            //***************************************
            //* A etapa foi corretamente preenchida?
            //***************************************
            if (ASPxClientEdit.ValidateGroup("Abertura"))
            {
                //***************************
                //* Colapsa grupo da etapa 1
                //***************************
                nvbEtapas.GetGroupByName("grpAbertura").SetExpanded(false);

                //***************************
                //* Expande grupo da etapa 2
                //***************************
                nvbEtapas.GetGroupByName("grpOrcamento").SetExpanded(true);

                //*****************************************************
                //* A etapa 2 (orçamento) foi corretamente preenchida?
                //*****************************************************
                if (ASPxClientEdit.ValidateGroup("Orcamento"))
                {
                    //********************************
                    //* Existe orçamento selecionado?
                    //********************************
                    if (lstOrcamentos.GetSelectedIndex() != -1)
                    {
                        //****************************
                        //* Obtem código do orçamento
                        //****************************
                        var Cod_Orcamento = 0;
                        if (s.mainElement.id.indexOf("cmdEmailEncerramento") != -1)
                        {
                            //*******************************************
                            //* Obtem código dos orçamentos selecionados
                            //*******************************************
                            var Selecionados = lstOrcamentosAceitos.GetSelectedValues();
                            if (Selecionados.length < 1)
                            {
                                //**************************
                                //* Exibe popup com retorno
                                //**************************
                                var Mensagem = "<br/><br/>Selecione um ou mais orçamentos.";
                                Mensagem += "<br/><br/>Somente orçamentos aceitos podem ser enviados.";
                                jQuery("#divResposta").attr('align', 'center');
                                jQuery("#divResposta").html(Mensagem);
                                popResposta.SetHeaderText("Envio de Orçamento Aceito");
                                popResposta.AdjustSize();
                                popResposta.Show();
                                return
                            }

                            //*************************
                            //* Monta array de códigos
                            //*************************
                            oJSON.parametros["CodigoOrcamentoAceito"] = Selecionados.join();
                            oJSON.operacao = "Enviar_Orcamentos_Aceitos";
                        }
                        else
                        {
                            //********************************
                            //* Existe orçamento selecionado?
                            //********************************
                            if (oJSON.parametros["IndiceOrcamento"] == "-1")
                            {
                                //**************************
                                //* Exibe popup com retorno
                                //**************************
                                var Mensagem = "<br/><br/>Não há um orçamento selecionado.";
                                Mensagem += "<br/><br/>Para enviar a mensagem, salve os dados do orçamento antes de enviar.";
                                jQuery("#divResposta").attr('align', 'center');
                                jQuery("#divResposta").html(Mensagem);
                                popResposta.SetHeaderText("Envio de Orçamento");
                                popResposta.AdjustSize();
                                popResposta.Show();
                                return
                            }

                            //*************************
                            //* Apenas orçamento atual
                            //*************************
                            oJSON.parametros["CodigoOrcamentoAceito"] = "0";
                            oJSON.operacao = "Enviar_Orcamento";
                        }

                        //********************
                        //* Notifica exclusão
                        //********************
                        pnlLoader.SetText("Enviando mensagem...");
                        pnlLoader.Show();

                        //***************************
                        //* Atualiza dados no objeto
                        //***************************
                        AtualizaJSON();

                        //***************************
                        //* Obtem dados via callback
                        //***************************
                        clbAtualizar.PerformCallback(JSON.stringify(oJSON));
                    }
                    else
                    {
                        //**************************
                        //* Exibe popup com retorno
                        //**************************
                        var Mensagem = "<br/><br/>Não há um orçamento selecionado.";
                        Mensagem += "<br/><br/>Para enviar a mensagem, salve os dados do orçamento antes de enviar.";
                        jQuery("#divResposta").attr('align', 'center');
                        jQuery("#divResposta").html(Mensagem);
                        popResposta.SetHeaderText("Envio de Orçamento");
                        popResposta.AdjustSize();
                        popResposta.Show();
                    }
                }
            }
        }

        function LimpaDados(s, e)
        {
            //********************************************
            //* COLUNA STATUS - Cancela conteúdo anterior
            //********************************************
            cboSituacao.SetSelectedIndex(-1);
            dteNovoContato.SetDate(null);

            //**************************************
            //* ETAPA 1 - Cancela conteúdo anterior
            //**************************************
            dteDataOperacao.SetDate(null);
            cboCanalEntrada.SetSelectedIndex(-1);
            txtIndicadoPor.SetText("");
            cboAtendente.SetSelectedIndex(-1);
            txtContatoNome.SetText("");
            txtContatoEmail.SetText("");
            txtContatoTelefone.SetText("");
            txtDestino.SetText("");
            dteSaida.SetDate(null);
            dteRetorno.SetDate(null);
            txtAdultos.SetText("");
            txtCriancas.SetText("");
            memDescricao.SetText("");
            txtValorEstimado.SetText("");

            //**************************************
            //* ETAPA 2 - Cancela conteúdo anterior
            //**************************************
            dteRetornoOrcamento.SetDate(null);
            cboEstagioOrcamento.SetSelectedIndex(-1);
            lstOrcamentos.SetSelectedIndex(-1);
            dteProximoContatoOrcamento.SetDate(null);
            txtProduto.SetText("");
            txtAssunto.SetText("");
            txtValorOrcamento.SetValue(0);
            htmOrcamento.SetHtml("");

            //**************************************
            //* ETAPA 3 - Cancela conteúdo anterior
            //**************************************
            lstOrcamentosAceitos.UnselectAll();
            txtValorEncerramento.SetText("");
            dteEncerramento.SetDate(null);
            memObservacoesEncerramento.SetText("");
            memDadosSacado.SetText("");
            memListaPassageiros.SetText("");
        }

        function RetornoCallback(s, e)
        {
            //***************************************************
            //* Coleta retorno do callback e coverte para objeto
            //***************************************************
            oJSON = JSON.parse(e.result);

            //*******************************************
            //* Converte datas do formato JSON para DATE 
            //*******************************************
            ConverteDatas();

            //****************
            //* Trata retorno
            //****************
            switch (oJSON.operacao)
            {
                case "Salvar_Etapa1":

                    //***********************
                    //* Exibe mensagem final
                    //***********************
                    if (oJSON.error == "")
                        pnlLoader.SetText("Dados salvos com sucesso!");
                    else
                        pnlLoader.SetText("Falha ao salvar os dados!\n\n" + oJSON.error);

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Salvar_Etapa2":

                    //***********************
                    //* Exibe mensagem final
                    //***********************
                    pnlLoader.SetText("Dados salvos com sucesso!");

                    //******************
                    //* Recarrega dados
                    //******************
                    ExibeJSON(s, e);

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Salvar_Etapa3":

                    //***********************
                    //* Exibe mensagem final
                    //***********************
                    if (oJSON.error == "")
                    {
                        //***********************
                        //* Exibe mensagem final
                        //***********************
                        pnlLoader.SetText("Dados salvos com sucesso!");
                    }
                    else
                        pnlLoader.SetText("Falha ao salvar os dados!");

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Excluir_Orcamento":

                    //*******************************
                    //* O processo foi bem sucedido?
                    //*******************************
                    if (oJSON.error == "")
                    {
                        //***********************
                        //* Exibe mensagem final
                        //***********************
                        pnlLoader.SetText("Orçamento excluído com sucesso!");

                        //****************************
                        //* Remove orçamento do array
                        //****************************
                        Indice_Orcamento = oJSON.parametros["IndiceOrcamento"];
                        oJSON.orcamentos.splice(Indice_Orcamento, 1);
                        if (oJSON.orcamentos.length > 0)
                            oJSON.parametros["IndiceOrcamento"] = "0";
                        else
                            oJSON.parametros["IndiceOrcamento"] = "-1";

                        //******************
                        //* Recarrega dados
                        //******************
                        ExibeJSON(s, e);
                    }
                    else
                    {
                        //***********************
                        //* Exibe mensagem final
                        //***********************
                        pnlLoader.SetText("Falha ao excluir orçamento!");
                    }

                    //*******************************
                    //* Devolve código do formulário
                    //*******************************
                    break;

                case "Coletar_Resposta":

                    //********************
                    //* Esconde progresso
                    //********************
                    pnlLoader.Hide();

                    //****************************
                    //* Obtem índice do orçamento
                    //****************************
                    var Indice_Orcamento = parseInt(oJSON.parametros["IndiceOrcamento"]);

                    //**************
                    //* Houve erro?
                    //**************
                    if (oJSON.error == "")
                    {
                        //*******************
                        //* Existe resposta?
                        //*******************
                        if (oJSON.orcamentos[Indice_Orcamento].html_resposta != "")
                        {
                            //***************************************
                            //* Exibe popup com conteúdo da resposta
                            //***************************************
                            jQuery("#divResposta").attr('align', 'left');
                            jQuery("#divResposta").html(oJSON.orcamentos[Indice_Orcamento].html_resposta);
                            popResposta.SetHeaderText("Resposta do Cliente");
                            popResposta.AdjustSize();
                            popResposta.Show();
                        }
                        else
                        {
                            //***************************************
                            //* Exibe popup com conteúdo da resposta
                            //***************************************
                            jQuery("#divResposta").attr('align', 'center');
                            jQuery("#divResposta").html("<br/><br/>Não houve resposta do cliente.");
                            popResposta.SetHeaderText("Resposta do Cliente");
                            popResposta.AdjustSize();
                            popResposta.Show();
                        }

                        //******************
                        //* Recarrega dados
                        //******************
                        ExibeJSON(s, e);
                    }
                    break;

                case "Enviar_Boas_Vindas":

                    //*****************
                    //* Esconde loader
                    //*****************
                    pnlLoader.Hide();

                    //**************************
                    //* Exibe popup com retorno
                    //**************************
                    jQuery("#divResposta").attr('align', 'center');
                    if (oJSON.error != "")
                        jQuery("#divResposta").html("<br/><br/>Falha no envio:" + oJSON.error);
                    else
                        jQuery("#divResposta").html("<br/><br/>Mensagem enviada com sucesso.");
                    popResposta.SetHeaderText("Envio de Mensagem de Boas Vindas");
                    popResposta.AdjustSize();
                    popResposta.Show();
                    break;

                case "Enviar_Orcamento":

                    //*****************
                    //* Esconde loader
                    //*****************
                    pnlLoader.Hide();

                    //******************
                    //* Recarrega dados
                    //******************
                    ExibeJSON(s, e);

                    //**************************
                    //* Exibe popup com retorno
                    //**************************
                    jQuery("#divResposta").attr('align', 'center');
                    if (oJSON.error != "")
                        jQuery("#divResposta").html("<br/><br/>Falha no envio:" + oJSON.error);
                    else
                        jQuery("#divResposta").html("<br/><br/>Mensagem(s) enviada(s) com sucesso.");
                    popResposta.SetHeaderText("Envio de Orçamento");
                    popResposta.AdjustSize();
                    popResposta.Show();
                    break;

                case "Enviar_Orcamentos_Aceitos":

                    //*****************
                    //* Esconde loader
                    //*****************
                    pnlLoader.Hide();

                    //******************
                    //* Recarrega dados
                    //******************
                    ExibeJSON(s, e);

                    //**************************
                    //* Exibe popup com retorno
                    //**************************
                    jQuery("#divResposta").attr('align', 'center');
                    if (oJSON.error != "")
                        jQuery("#divResposta").html("<br/><br/>Falha no envio:" + oJSON.error);
                    else
                        jQuery("#divResposta").html("<br/><br/>Mensagem(s) enviada(s) com sucesso.");
                    popResposta.SetHeaderText("Envio de Orçamento");
                    popResposta.AdjustSize();
                    popResposta.Show();
                    break;

                case "Salvar_Comentario_Interno":

                    //*****************
                    //* Esconde loader
                    //*****************
                    pnlLoader.Hide();
                    break;

                case "Popular":

                    //*****************
                    //* Esconde loader
                    //*****************
                    pnlLoader.Hide();

                    //*********************
                    //* Atualiza interface
                    //*********************
                    ExibeJSON(s, e);

                    //****************************
                    //* Ajusta abertura das guias
                    //****************************
                    AjustaGuias(s, e);
            }

            //********************************
            //* Anula último erro de operação
            //********************************
            oJSON.parametros["funcao"] = "";
            oJSON.operacao = "";
            oJSON.error = "";

            //***********************************
            //* Remove loader modal em 1 segundo
            //***********************************
            setTimeout(function () { pnlLoader.Hide(); }, 500);
        }

        function AtualizaJSON(s, e)
        {
            //******************************************************
            //* Cancela processamento no server e notifica gravação
            //******************************************************
            pnlLoader.SetText("Executando solicitação...");
            pnlLoader.Show();

            //*************
            //* Constantes
            //*************
            const Orcamento_Cotacao = 1;
            const Orcamento_Enviado = 2;
            const Orcamento_Aceito = 3;
            const Orcamento_Recusado = 4;

            //-----------------------------------------------------------------------------------------------------------------
            //*********
            //* STATUS
            //*********
            //-----------------------------------------------------------------------------------------------------------------

            oJSON.oportunidade.proximo_contato = dteNovoContato.GetValue();
            oJSON.oportunidade.cod_situacao = cboSituacao.GetValue();

            //-----------------------------------------------------------------------------------------------------------------
            //**********
            //* ETAPA 1
            //**********
            //-----------------------------------------------------------------------------------------------------------------

            oJSON.oportunidade.data_operacao = dteDataOperacao.GetValue();
            oJSON.oportunidade.cod_canal_entrada = cboCanalEntrada.GetValue();
            oJSON.oportunidade.indicado_por = txtIndicadoPor.GetText();
            oJSON.oportunidade.cod_promotor = cboAtendente.GetValue();
            oJSON.oportunidade.contato_nome = txtContatoNome.GetText();
            oJSON.oportunidade.contato_emails = txtContatoEmail.GetText();
            oJSON.oportunidade.contato_telefone = txtContatoTelefone.GetText();
            oJSON.oportunidade.destino = txtDestino.GetText();
            oJSON.oportunidade.data_saida = dteSaida.GetValue();
            oJSON.oportunidade.data_retorno = dteRetorno.GetValue();
            oJSON.oportunidade.quantidade_adultos = txtAdultos.GetText();
            oJSON.oportunidade.quantidade_criancas = txtCriancas.GetText();
            oJSON.oportunidade.descricao = memDescricao.GetText();
            oJSON.oportunidade.valor_estimado = txtValorEstimado.GetValue();

            //-----------------------------------------------------------------------------------------------------------------
            //**********
            //* ETAPA 2
            //**********
            //-----------------------------------------------------------------------------------------------------------------

            //*************************************************
            //* Obtem código do orçamento e índice selecionado
            //*************************************************
            var Indice_Orcamento = -1;
            var CodOrcamento = 0;
            if (lstOrcamentos.GetSelectedIndex() != -1)
                CodOrcamento = lstOrcamentos.GetSelectedItem().value;
            Indice_Orcamento = lstOrcamentos.GetSelectedIndex();
            if (CodOrcamento != 0)
            {
                //Data Retorno Orçamento
                oJSON.orcamentos[Indice_Orcamento].data_orcamento = dteRetornoOrcamento.GetValue();

                //Estágio do orçamento
                oJSON.orcamentos[Indice_Orcamento].estagio_orcamento = cboEstagioOrcamento.GetValue();

                //Data do próximo contato
                oJSON.orcamentos[Indice_Orcamento].proximo_contato = dteProximoContatoOrcamento.GetValue();

                //Nome do produto
                oJSON.orcamentos[Indice_Orcamento].produto = txtProduto.GetText();

                //Assunto do orçamento
                oJSON.orcamentos[Indice_Orcamento].assunto = txtAssunto.GetText();

                //Valor do orçamento
                if (txtValorOrcamento.GetValue() != null)
                    oJSON.orcamentos[Indice_Orcamento].valor = txtValorOrcamento.GetValue();
                else
                    oJSON.orcamentos[Indice_Orcamento].valor = 0;

                //HTML do orçamento
                oJSON.orcamentos[Indice_Orcamento].html_orcamento = htmOrcamento.GetHtml();

                //HTML do comentário interno
                oJSON.orcamentos[Indice_Orcamento].html_interno = htmInterno.GetHtml();

                //Indice do orçamento
                oJSON.parametros["IndiceOrcamento"] = Indice_Orcamento;
            }
            else
            {
                //**********************
                //* Cria novo orçamento
                //**********************
                var data_orcamento = new Date();
                var proximo_contato = new Date();
                proximo_contato.setDate(proximo_contato.getDate() + 2);
                var NovoOrcamento = {
                    PK_cod_orcamento: 0,
                    nro_oportunidade: oJSON.parametros["CodigoOportunidade"],
                    data_orcamento: data_orcamento,
                    estagio_orcamento: Orcamento_Cotacao,
                    proximo_contato: proximo_contato,
                    produto: txtProduto.GetText(),
                    assunto: txtAssunto.GetText(),
                    valor: parseFloat("0" + txtValorOrcamento.GetValue()),
                    html_orcamento: htmOrcamento.GetHtml(),
                    html_resposta: "",
                    html_interno: "",
                    pendencia: false
                };
                oJSON.orcamentos.unshift(NovoOrcamento);
                oJSON.parametros["IndiceOrcamento"] = "0";
            }
            
            //-----------------------------------------------------------------------------------------------------------------
            //**********
            //* ETAPA 3
            //**********
            //-----------------------------------------------------------------------------------------------------------------

            //****************************
            //* Atualiza dados da etapa 3
            //****************************
            oJSON.oportunidade.data_encerramento = dteEncerramento.GetValue();
            if (txtValorEncerramento.GetValue() != null)
                oJSON.oportunidade.valor_fechado = txtValorEncerramento.GetValue();
            else
                oJSON.oportunidade.valor_fechado = 0;
            oJSON.oportunidade.observacoes = memObservacoesEncerramento.GetText();
            oJSON.oportunidade.dados_sacado = memDadosSacado.GetText();
            oJSON.oportunidade.lista_passageiros = memListaPassageiros.GetText();

            //*******************************************
            //* Obtem código dos orçamentos selecionados
            //*******************************************
            var Selecionados = lstOrcamentosAceitos.GetSelectedValues();
            if (Selecionados.length < 1)
            {
                //*************************
                //* Monta array de códigos
                //*************************
                oJSON.parametros["CodigoOrcamentoAceito"] = Selecionados.join();
            }
        }

        function ConverteDatas()
        {
            //************************
            //* Converte datas JQUERY
            //************************

            //Proximo Contato
            if (oJSON.oportunidade.proximo_contato != null)
            {
                var ProximoContato = parseInt(oJSON.oportunidade.proximo_contato.replace(/\/Date\((\d+)\)\//g, "$1"));
                oJSON.oportunidade.proximo_contato = new Date(ProximoContato);
            }

            //Data Operacao
            if (oJSON.oportunidade.data_operacao != null)
            {
                var DataOperacao = parseInt(oJSON.oportunidade.data_operacao.replace(/\/Date\((\d+)\)\//g, "$1"));
                oJSON.oportunidade.data_operacao = new Date(DataOperacao);
            }

            //Data Saída
            if (oJSON.oportunidade.data_saida != null)
            {
                var DataSaida = parseInt(oJSON.oportunidade.data_saida.replace(/\/Date\((\d+)\)\//g, "$1"));
                oJSON.oportunidade.data_saida = new Date(DataSaida);
            }

            //Data Retorno
            if (oJSON.oportunidade.data_retorno != null)
            {
                var DataRetorno = parseInt(oJSON.oportunidade.data_retorno.replace(/\/Date\((\d+)\)\//g, "$1"));
                oJSON.oportunidade.data_retorno = new Date(DataRetorno);
            }

            //Data Encerramento
            if (oJSON.oportunidade.data_encerramento != null) {
                var DataEncerramento = parseInt(oJSON.oportunidade.data_encerramento.replace(/\/Date\((\d+)\)\//g, "$1"));
                oJSON.oportunidade.data_encerramento = new Date(DataEncerramento);
            }

            //Datas de orçamentos
            for (var COrcamento = 0; COrcamento < oJSON.orcamentos.length; COrcamento++)
                {
                    //Data Retorno Orçamento
                    if (oJSON.orcamentos[COrcamento].data_orcamento != null)
                    {
                        var DataOrcamento = parseInt(oJSON.orcamentos[COrcamento].data_orcamento.replace(/\/Date\((\d+)\)\//g, "$1"));
                        oJSON.orcamentos[COrcamento].data_orcamento = new Date(DataOrcamento);
                        var ProximoContato = parseInt(oJSON.orcamentos[COrcamento].proximo_contato.replace(/\/Date\((\d+)\)\//g, "$1"));
                        oJSON.orcamentos[COrcamento].proximo_contato = new Date(ProximoContato);
                    }
                }
        }

        function ExibeJSON(s, e)
        {
            //*************
            //* Constantes
            //*************
            const Orcamento_Cotacao = 1;
            const Orcamento_Enviado = 2;
            const Orcamento_Aceito = 3;
            const Orcamento_Recusado = 4;
            const Oportunidade_Aberto = 1;
            const Oportunidade_Orçamento = 2;
            const Oportunidade_Analise = 3;
            const Oportunidade_Ganhou = 4;
            const Oportunidade_Perdeu = 5;

            //******************
            //* Limpa interface
            //******************
            LimpaDados();

            //**********************************************
            //* Reconstroi objetos a partir do retorno JSON
            //**********************************************
            if (oJSON.error == "")
            {
                //-----------------------------------------------------------------------------------------------------------------
                //*********
                //* STATUS
                //*********
                //-----------------------------------------------------------------------------------------------------------------
                if (oJSON.oportunidade.cod_situacao > 0)
                    cboSituacao.SetValue(oJSON.oportunidade.cod_situacao);
                else
                    cboSituacao.SetValue(Oportunidade_Aberto);

                data_contato = new Date();
                data_contato.setDate(data_contato.getDate() + 2);

                if (oJSON.oportunidade.proximo_contato != null)
                    dteNovoContato.SetValue(oJSON.oportunidade.proximo_contato);
                else
                    dteNovoContato.SetValue(data_contato);

                //-----------------------------------------------------------------------------------------------------------------
                //**********
                //* ETAPA 1
                //**********
                //-----------------------------------------------------------------------------------------------------------------

                //****************
                //* Associa dados
                //****************
                if (oJSON.oportunidade.data_operacao != null)
                    dteDataOperacao.SetValue(oJSON.oportunidade.data_operacao);
                else
                    dteDataOperacao.SetValue(new Date());
                if (oJSON.oportunidade.PK_nro_oportunidade > 0)
                    cboCanalEntrada.SetValue(oJSON.oportunidade.cod_canal_entrada);
                txtIndicadoPor.SetText(oJSON.oportunidade.indicado_por);
                if (oJSON.oportunidade.cod_promotor > 0)
                    cboAtendente.SetValue(oJSON.oportunidade.cod_promotor);
                txtContatoNome.SetText(oJSON.oportunidade.contato_nome);
                txtContatoEmail.SetText(oJSON.oportunidade.contato_emails);
                txtContatoTelefone.SetText(oJSON.oportunidade.contato_telefone);
                txtDestino.SetText(oJSON.oportunidade.destino);
                dteSaida.SetValue(oJSON.oportunidade.data_saida);
                dteRetorno.SetValue(oJSON.oportunidade.data_retorno);
                if (oJSON.oportunidade.PK_nro_oportunidade > 0)
                    txtAdultos.SetValue(oJSON.oportunidade.quantidade_adultos);
                if (oJSON.oportunidade.PK_nro_oportunidade > 0)
                    txtCriancas.SetValue(oJSON.oportunidade.quantidade_criancas);
                memDescricao.SetText(oJSON.oportunidade.descricao);
                if (oJSON.oportunidade.PK_nro_oportunidade > 0)
                    txtValorEstimado.SetValue(oJSON.oportunidade.valor_estimado);

                //-----------------------------------------------------------------------------------------------------------------
                //**********
                //* ETAPA 2
                //**********
                //-----------------------------------------------------------------------------------------------------------------
                var Indice_Orcamento = parseInt(oJSON.parametros["IndiceOrcamento"]);
                if (Indice_Orcamento > -1)
                {
                    //Data do orçamento
                    dteRetornoOrcamento.SetValue(oJSON.orcamentos[Indice_Orcamento].data_orcamento);

                    //Estágio do orçamento
                    cboEstagioOrcamento.SetValue(oJSON.orcamentos[Indice_Orcamento].estagio_orcamento);

                    //Data do Próximo Contato
                    dteProximoContatoOrcamento.SetValue(oJSON.orcamentos[Indice_Orcamento].proximo_contato);

                    //Nome do produto
                    txtProduto.SetText(oJSON.orcamentos[Indice_Orcamento].produto);

                    //Assunto
                    txtAssunto.SetText(oJSON.orcamentos[Indice_Orcamento].assunto);

                    //Valor
                    if (oJSON.orcamentos[Indice_Orcamento].valor != null)
                        txtValorOrcamento.SetValue(oJSON.orcamentos[Indice_Orcamento].valor);
                    else
                        txtValorOrcamento.SetValue(0);

                    //HTML do orçamento
                    htmOrcamento.SetHtml(oJSON.orcamentos[Indice_Orcamento].html_orcamento);

                    //HTML de comentários internos
                    htmInterno.SetHtml(oJSON.orcamentos[Indice_Orcamento].html_interno);
                }

                //Lista de orçamentos vazia
                if (oJSON.orcamentos.length == 0)
                {
                    //Data do orçamento
                    dteRetornoOrcamento.SetValue(new Date());

                    //Estágio do orçamento
                    cboEstagioOrcamento.SetValue(Orcamento_Aberto);

                    //Data do Próximo Contato
                    proximo_contato = new Date();
                    dteProximoContatoOrcamento.SetValue(proximo_contato.getDate() + 2);

                    //Nome do produto
                    txtProduto.SetText("");

                    //Assunto
                    txtAssunto.SetText("");

                    //Valor
                    txtValorOrcamento.SetValue(0);

                    //HTML do orçamento
                    htmOrcamento.SetHtml("");

                    //HTML de comentários internos
                    htmInterno.SetHtml("");
                }

                //Lista de orçamentos
                lstOrcamentos.ClearItems();
                for (COrcamento = oJSON.orcamentos.length - 1; COrcamento > -1; COrcamento--)
                {
                    //********************************************
                    //* Retorna descrição do estágio do orçamento
                    //********************************************
                    var EstagioOrcamento = "";
                    switch (oJSON.orcamentos[COrcamento].estagio_orcamento)
                    {
                        case Orcamento_Cotacao:
                            EstagioOrcamento = "Cotação";
                            break;
                        case Orcamento_Enviado:
                            EstagioOrcamento = "Enviado";
                            break;
                        case Orcamento_Aceito:
                            EstagioOrcamento = "Aceito";
                            break;
                        case Orcamento_Recusado:
                            EstagioOrcamento = "Recusado";
                            break;
                    }

                    //Data Retorno Orçamento
                    var DataOrcamento = oJSON.orcamentos[COrcamento].data_orcamento;
                    ItemText = "N° " + oJSON.orcamentos[COrcamento].PK_cod_orcamento;
                    ItemText += " - " + EstagioOrcamento;
                    ItemText += " (" + jQuery.datepicker.formatDate('dd/mm/yy', DataOrcamento) + ")";

                    //Define imagem
                    var ImageURL = "Images/bullet.png";
                    if (oJSON.orcamentos[COrcamento].pendencia && oJSON.orcamentos[COrcamento].html_resposta == "")
                        ImageURL = "Images/hourglass.png";
                    if (oJSON.orcamentos[COrcamento].pendencia && oJSON.orcamentos[COrcamento].html_resposta != "")
                        ImageURL = "Images/answer.png";

                    //Insere ítem
                    lstOrcamentos.InsertItem(0, ItemText, oJSON.orcamentos[COrcamento].PK_cod_orcamento, ImageURL);
                }

                //Seleciona índice
                if (Indice_Orcamento < lstOrcamentos.GetItemCount())
                    lstOrcamentos.SetSelectedIndex(Indice_Orcamento);

                //-----------------------------------------------------------------------------------------------------------------
                //**********
                //* ETAPA 3
                //**********
                //-----------------------------------------------------------------------------------------------------------------

                //****************************
                //* Atualiza dados da etapa 3
                //****************************
                txtValorEncerramento.SetValue(oJSON.oportunidade.valor_fechado);
                dteEncerramento.SetValue(oJSON.oportunidade.data_encerramento);
                memObservacoesEncerramento.SetText(oJSON.oportunidade.observacoes);
                memDadosSacado.SetText(oJSON.oportunidade.dados_sacado);
                memListaPassageiros.SetText(oJSON.oportunidade.lista_passageiros);

                //*************************************
                //* Popula lista de orçamentos aceitos
                //*************************************
                var OrcamentosAceitos = "";
                lstOrcamentosAceitos.ClearItems();
                for (COrcamento = 0; COrcamento < oJSON.orcamentos.length; COrcamento++)
                {
                    if (oJSON.orcamentos[COrcamento].estagio_orcamento == Orcamento_Aceito)
                    {
                        var DataOrcamento = oJSON.orcamentos[COrcamento].data_orcamento;
                        ItemText = "N° " + oJSON.orcamentos[COrcamento].PK_cod_orcamento + " - Aceito ";
                        ItemText += "(" + jQuery.datepicker.formatDate('dd/mm/yy', DataOrcamento) + ")";
                        lstOrcamentosAceitos.InsertItem(0, ItemText, oJSON.orcamentos[COrcamento].PK_cod_orcamento);
                        if (OrcamentosAceitos != "")
                            OrcamentosAceitos += ","
                        OrcamentosAceitos += oJSON.orcamentos[COrcamento].PK_cod_orcamento;
                    }
                }

                //*******************************************
                //* Obtem código dos orçamentos selecionados
                //*******************************************
                if (OrcamentosAceitos != "")
                    lstOrcamentosAceitos.SelectValues(OrcamentosAceitos);

                //*************************
                //* Salva lista de códigos
                //*************************
                oJSON.parametros["CodigoOrcamentoAceito"] = OrcamentosAceitos;
            }

            //*******************************
            //* Ocula painel de carregamento
            //*******************************
            pnlLoader.Hide();
        }

        function Recalcular(s, e)
        {
            //************************
            //* Recalcula total final 
            //************************
            e.processOnServer = false;
            var ValorFinal = 0;
            for (var COrcamento = 0; COrcamento < oJSON.orcamentos.length; COrcamento++)
                ValorFinal += oJSON.orcamentos[COrcamento].valor;
            txtValorEncerramento.SetValue(ValorFinal);
        }

        function ComentarioInterno(s, e)
        {
            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //********************************
            //* Existe orçamento selecionado?
            //********************************
            if (oJSON.parametros["IndiceOrcamento"] == "-1")
            {
                //**************************
                //* Exibe popup com retorno
                //**************************
                var Mensagem = "<br/><br/>Não há um orçamento selecionado.";
                Mensagem += "<br/><br/>Para editar ou visualizar um comentário, salve os dados do orçamento.";
                jQuery("#divResposta").attr('align', 'center');
                jQuery("#divResposta").html(Mensagem);
                popResposta.SetHeaderText("Envio de Orçamento");
                popResposta.AdjustSize();
                popResposta.Show();
                return
            }

            //************************
            //* Exibe POPUP de edição
            //************************
            popComentarioInterno.Show();

            //*******************************
            //* HTML de comentários internos
            //*******************************
            var Indice_Orcamento = oJSON.parametros["IndiceOrcamento"];
            htmInterno.SetHtml(oJSON.orcamentos[Indice_Orcamento].html_interno);
        }

        function SalvarComentarioInterno(s, e)
        {
            //*******************************
            //* Cancela execução no servidor 
            //*******************************
            e.processOnServer = false;

            //*************************************************
            //* Obtem código do orçamento e índice selecionado
            //*************************************************
            var Indice_Orcamento = 0;
            var CodOrcamento = 0;
            if (lstOrcamentos.GetSelectedIndex() != -1)
                CodOrcamento = lstOrcamentos.GetSelectedItem().value;
            Indice_Orcamento = lstOrcamentos.GetSelectedIndex();

            //***************************
            //* Atualiza dados no objeto
            //***************************
            AtualizaJSON();

            //****************
            //* Esconde popup
            //****************
            popComentarioInterno.Hide();

            //*********************************
            //* Atualiza registro via callback
            //*********************************
            oJSON.operacao = "Salvar_Comentario_Interno";
            oJSON.parametros["IndiceOrcamento"] = Indice_Orcamento;
            oJSON.parametros["CodigoOrcamento"] = CodOrcamento;
            clbAtualizar.PerformCallback(JSON.stringify(oJSON));
        }

    </script>

    <div align="center" style="align-content: center; width: 95%;">
        <div align="left">
            <br />
            <dx:ASPxButton ID="cmdRetornar" runat="server" Text="< Retornar" Width="100px" OnClick="cmdRetornar_Click" />
            <br />
            <br />
            <dx:ASPxLabel ID="lblTitulo" CssClass="TextoCinza20" runat="server" Text="" />
        </div>
        <br />
        <br />
        <dx:ASPxNavBar ID="nvbEtapas" ClientInstanceName="nvbEtapas" runat="server" Width="100%" EnableClientSideAPI="true" CssClass="TextoCinza16">
            <Groups>
                <dx:NavBarGroup Name="grpAbertura" Text="Situação da oportunidade" Expanded="true" ShowExpandButton="False" AllowExpanding="false">
                    <ContentTemplate>
                        <dx:ASPxFormLayout ID="layComando" ColCount="2" runat="server" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" CssClass="TextoCinza16">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                            <Items>
                                <dx:LayoutItem Caption="Situação" CaptionSettings-VerticalAlign="Middle" CaptionCellStyle-CssClass="TituloCampo">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboSituacao" ClientInstanceName="cboSituacao" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Theme="MetropolisBlue" Width="100%" ValueType="System.Int16" DropDownStyle="DropDownList" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Próximo contato em:" CaptionSettings-VerticalAlign="Middle" CaptionCellStyle-CssClass="TituloCampo">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteNovoContato" ClientInstanceName="dteNovoContato" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" EditFormat="Custom" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" TimeSectionProperties-Visible="True" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ClientSideEvents Validation="function(s, e) { ValidaDataAtual(s, e) }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false" EnableCustomValidation="true">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                                <TimeSectionProperties>
                                                    <TimeEditProperties EditFormatString="HH:mm" />
                                                </TimeSectionProperties>
                                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                    <CaptionSettings VerticalAlign="Middle"></CaptionSettings>
                                </dx:LayoutItem>
                            </Items>
                            <SettingsItems ShowCaption="True"></SettingsItems>
                        </dx:ASPxFormLayout>
                    </ContentTemplate>
                </dx:NavBarGroup>
                <dx:NavBarGroup Name="grpAbertura" Text="Abertura">
                    <ContentTemplate>

                        <!-- ********************* -->
                        <!-- * DADOS DE ABERTURA * -->
                        <!-- ********************* -->
                        <dx:ASPxFormLayout ID="layAbertura" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                            <Items>
                                <dx:LayoutItem Caption="Data da operação" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteDataOperacao" ClientInstanceName="dteDataOperacao" runat="server" Width="100%" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" UseMaskBehavior="true" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Origem" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboCanalEntrada" ClientInstanceName="cboCanalEntrada" runat="server" Theme="MetropolisBlue" Width="100%" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" ValidationSettings-Display="Static" ValueType="System.Int32"  DropDownStyle="DropDownList" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Atendente" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboAtendente" ClientInstanceName="cboAtendente" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Theme="MetropolisBlue" Width="100%" ValueType="System.Int32" IncrementalFilteringMode="Contains"  DropDownStyle="DropDownList" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ClientSideEvents Validation="function(s, e) { e.isValid = s.GetSelectedIndex()==-1 ? false : true; }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" EnableCustomValidation="true" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Pessoa contatada" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtContatoNome" ClientInstanceName="txtContatoNome" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="60">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Observação" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtIndicadoPor" ClientInstanceName="txtIndicadoPor" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="60">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Endereço de E-mail" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTokenBox ID="txtContatoEmail" ClientInstanceName="txtContatoEmail" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTokenBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Telefone Contato" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtContatoTelefone" ClientInstanceName="txtContatoTelefone" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" ValidationSettings-Display="Dynamic" MaxLength="20">
                                                <MaskSettings Mask="(99) 9999-99999" PromptChar=" " />
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Destino" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtDestino" ClientInstanceName="txtDestino" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="200">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Data da saída" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteSaida" ClientInstanceName="dteSaida" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" AllowMouseWheel="false">
                                                <ClientSideEvents Validation="function(s, e) { ValidaDataAtual(s, e) }" />
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false" EnableCustomValidation="true">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Data da retorno" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteRetorno" ClientInstanceName="dteRetorno" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ClientSideEvents Validation="function(s, e) { ValidaDataViagem(s, e) }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" EnableCustomValidation="true" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Qtde de Adultos" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtAdultos" ClientInstanceName="txtAdultos" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="50">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Qtde de Crianças" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtCriancas" ClientInstanceName="txtCriancas" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="50">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Descrição" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxMemo ID="memDescricao" ClientInstanceName="memDescricao" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%">
                                                <ClientSideEvents Init="function(s, e) { EscondeScrollVertical(s, e) }" KeyUp="function(s, e) { AjustaAltura(s, e); }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Valor Estimado" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtValorEstimado" ClientInstanceName="txtValorEstimado" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" DisplayFormatString="C" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Abertura" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                        <div align="right" style="width: 100%;">
                            <dx:ASPxButton ID="cmdEnviarEmail" runat="server" Text="Enviar E-mail" Width="100px">
                                <ClientSideEvents Click="function(s, e) { EnviarBoasVindas(s, e) }" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="cmdSalvarAbertura" runat="server" Text="Salvar" Width="100px">
                                <ClientSideEvents Click="function(s, e) { SalvaEtapa1(s, e) }" />
                            </dx:ASPxButton>
                        </div>
                        <br />
                    </ContentTemplate>
                </dx:NavBarGroup>
                <dx:NavBarGroup Name="grpOrcamento" Text="Or&#231;amento">
                    <ContentTemplate>

                        <!-- ************* -->
                        <!-- * ORÇAMENTO * -->
                        <!-- ************* -->
                        <dx:ASPxFormLayout ID="layOrcamento0" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                            <Items>
                                <dx:LayoutItem Caption="Data do Orçamento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteRetornoOrcamento" ClientInstanceName="dteRetornoOrcamento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" Height="35px" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Orcamento" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Estágio do orçamento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxComboBox ID="cboEstagioOrcamento" ClientInstanceName="cboEstagioOrcamento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Theme="Moderno" Width="100%" ValueType="System.Int32"  DropDownStyle="DropDownList" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Orcamento" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxComboBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Próximo Contato" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteProximoContatoOrcamento" ClientInstanceName="dteProximoContatoOrcamento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" EditFormat="Custom" DisplayFormatString="dd/MM/yyyy HH:mm" EditFormatString="dd/MM/yyyy HH:mm" TimeSectionProperties-Visible="True" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                                <ClientSideEvents Validation="function(s, e) { ValidaDataAtual(s, e) }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Orcamento" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false" EnableCustomValidation="true">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                                <TimeSectionProperties>
                                                    <TimeEditProperties EditFormatString="HH:mm" />
                                                </TimeSectionProperties>
                                                <FocusedStyle CssClass="CampoSemBordasFocus"></FocusedStyle>
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Produto" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtProduto" ClientInstanceName="txtProduto" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Orcamento" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Assunto" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxTextBox ID="txtAssunto" ClientInstanceName="txtAssunto" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" MaxLength="100">
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Orcamento" ErrorFrameStyle-VerticalAlign="Bottom" CausesValidation="false">
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Valor do Orçamento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtValorOrcamento" ClientInstanceName="txtValorOrcamento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" DisplayFormatString="C" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                        <dx:ASPxFormLayout ID="layOrcamento1" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="False" SettingsItemCaptions-Location="Top">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                            <Items>
                                <dx:LayoutItem Width="20%" Caption="Orçamentos" CaptionSettings-VerticalAlign="Top" VerticalAlign="Top">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <div align="center">
                                                <dx:ASPxButton ID="cmdNovoOrcamento" ClientInstanceName="cmdNovoOrcamento" runat="server" Text="Novo orçamento" Width="100px">
                                                    <ClientSideEvents Click="function(s, e) { NovoOrcamento(s, e) }" />
                                                </dx:ASPxButton>
                                            </div>
                                            <br />
                                            <br />
                                            Orçamentos:
                                            <br />
                                            <dx:ASPxListBox ID="lstOrcamentos" ClientInstanceName="lstOrcamentos" runat="server" Width="200px" Height="300px" EncodeHtml="false" ValueType="System.Int32" EnableSynchronization="False">
                                                <ClientSideEvents SelectedIndexChanged="function(s, e) { SelecionaOrcamento(s, e); }"></ClientSideEvents>
                                                <ItemImage Width="16" Height="16" />
                                            </dx:ASPxListBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="80%" Caption="" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxHtmlEditor ID="htmOrcamento" ClientInstanceName="htmOrcamento" runat="server" Width="100%" Height="432px" Settings-AllowDesignView="True" Settings-AllowPreview="False" Settings-AllowHtmlView="False">
                                                <ClientSideEvents BeginCallback="function(s, e) { pnlLoader.Show(); }" EndCallback="function(s, e) { pnlLoader.Hide(); }" />
                                            </dx:ASPxHtmlEditor>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                        <table style="width: 100%;">
                            <tr>
                                <td align="center" style="width: 20%; text-align: center; vertical-align: top;">
                                    &nbsp;
                                </td>
                                <td align="right" style="width: 80%; vertical-align: top;">
                                    <dx:ASPxButton ID="cmdComentarioInterno" runat="server" Text="Comentário Interno" Width="100px">
                                        <ClientSideEvents Click="function(s, e) { ComentarioInterno(s, e); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="cmdRespostaOrcamento" runat="server" Text="Ver Resposta" Width="100px">
                                        <ClientSideEvents Click="function(s, e) { VerResposta(s, e); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="cmdEmailOrcamento" runat="server" Text="Enviar E-mail" Width="100px">
                                        <ClientSideEvents Click="function(s, e) { EnviarOrcamento(s, e); }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="cmdExcluirOrcamento" runat="server" Text="Excluir" Width="100px">
                                        <ClientSideEvents Click="function(s, e) { ExcluiOrcamento(s, e) }" />
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="cmdSalvarOrcamento" runat="server" Text="Salvar" Width="100px">
                                        <ClientSideEvents Click="function(s, e) { SalvaEtapa2(s, e) }" />
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ContentTemplate>
                </dx:NavBarGroup>
                <dx:NavBarGroup Name="grpEncerramento" Text="Encerramento">
                    <ContentTemplate>

                        <!-- **************** -->
                        <!-- * ENCERRAMENTO * -->
                        <!-- **************** -->
                        <dx:ASPxFormLayout ID="layEncerramento" runat="server" ColCount="2" Width="100%" RequiredMarkDisplayMode="None" SettingsItems-ShowCaption="True" Styles-LayoutGroup-Cell-Paddings-PaddingBottom="8px">
                            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="800" />
                            <Items>
                                <dx:LayoutItem Caption="Valor Fechado" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxSpinEdit ID="txtValorEncerramento" ClientInstanceName="txtValorEncerramento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" DisplayFormatString="C" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                            </dx:ASPxSpinEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Caption="Data do Encerramento" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxDateEdit ID="dteEncerramento" ClientInstanceName="dteEncerramento" Caption="" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%" UseMaskBehavior="true" AllowMouseWheel="false">
                                                <ClearButton DisplayMode="Always" />
                                            </dx:ASPxDateEdit>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Observações gerais" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxMemo ID="memObservacoesEncerramento" ClientInstanceName="memObservacoesEncerramento" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%">
                                                <ClientSideEvents Init="function(s, e) { EscondeScrollVertical(s, e) }" KeyUp="function(s, e) { AjustaAltura(s, e); }" />
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Dados do sacado" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxMemo ID="memDadosSacado" ClientInstanceName="memDadosSacado" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%">
                                                <ClientSideEvents Init="function(s, e) { EscondeScrollVertical(s, e) }" KeyUp="function(s, e) { AjustaAltura(s, e); }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Encerramento" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Lista de passageiros" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxMemo ID="memListaPassageiros" ClientInstanceName="memListaPassageiros" CssClass="CampoSemBordas" FocusedStyle-CssClass="CampoSemBordasFocus" runat="server" Width="100%">
                                                <ClientSideEvents Init="function(s, e) { EscondeScrollVertical(s, e) }" KeyUp="function(s, e) { AjustaAltura(s, e); }" />
                                                <ValidationSettings ErrorTextPosition="Right" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Encerramento" CausesValidation="false">
                                                    <RequiredField ErrorText="Informação obrigatória" IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxMemo>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                                <dx:LayoutItem Width="100%" Caption="Seleção orçamentos" CaptionCellStyle-CssClass="TituloCampo" CaptionSettings-VerticalAlign="Middle">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer runat="server">
                                            <dx:ASPxListBox ID="lstOrcamentosAceitos" ClientInstanceName="lstOrcamentosAceitos" runat="server" ValueType="System.String" RepeatColumns="3" Width="300px" SelectionMode="CheckColumn">
                                            </dx:ASPxListBox>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                            </Items>
                        </dx:ASPxFormLayout>
                        <table style="width: 100%;">
                            <tr>
                                <td style="vertical-align: top; width: 100%" class="CampoSemBordas">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 100%">
                                    <br />
                                    <div align="right">
                                        <dx:ASPxButton ID="cmdRecalcular" ClientInstanceName="cmdRecalcular" runat="server" Text="Atualizar Valor" Width="100px">
                                            <ClientSideEvents Click="function(s, e) { Recalcular(s, e); }" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="cmdEmailEncerramento" ClientInstanceName="cmdEmailEncerramento" runat="server" Text="Enviar E-mail" Width="100px">
                                            <ClientSideEvents Click="function(s, e) { EnviarOrcamento(s, e); }" />
                                        </dx:ASPxButton>
                                        <dx:ASPxButton ID="cmdSalvarEncerramento" ClientInstanceName="cmdSalvarEncerramento" runat="server" Text="Salvar" Width="100px">
                                            <ClientSideEvents Click="function(s, e) { SalvaEtapa3(s, e); }" />
                                        </dx:ASPxButton>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </dx:NavBarGroup>
            </Groups>
            <GroupHeaderStyle CssClass="TextoCinza20">
            </GroupHeaderStyle>
        </dx:ASPxNavBar>
        <br />
        <br />
    </div>
    <dx:ASPxCallback ID="clbAtualizar" ClientInstanceName="clbAtualizar" runat="server" OnCallback="clbAtualizar_Callback" EnableCallbackCompression="true" EnableViewState="false">
        <ClientSideEvents Init="function(s, e) { InicializaJSON(); }" CallbackComplete="function(s, e) { RetornoCallback(s, e); }" />
    </dx:ASPxCallback>
    <dx:ASPxPopupControl ID="popExclusao" runat="server" AllowDragging="True" AllowResize="False" 
        ViewStateMode="Disabled" CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Width="300px" MinWidth="300px" Height="200px" HeaderText="Confirmação de Exclusão" 
        Theme="MetropolisBlue" ClientInstanceName="popExclusao" EnableHierarchyRecreation="False" Modal="true">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div align="center">
                    <br />
                    <br />
                    <span class="TextoCinza16">Confirma a exclusão do orçamento?</span>
                    <br />
                    <br />
                    <br />
                    <dx:ASPxButton ID="cmdExcluir" runat="server" Text="Excluir" Theme="MetropolisBlue" Width="100px">
                        <ClientSideEvents Click="function(s, e) { ExcluiOrcamento(s, e); }"></ClientSideEvents>
                    </dx:ASPxButton>
                    <dx:ASPxButton ID="cmdCancelar" runat="server" Text="Cancelar" Theme="MetropolisBlue" Width="100px">
                        <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popExclusao.Hide(); }"></ClientSideEvents>
                    </dx:ASPxButton>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popResposta" runat="server" AllowDragging="True" AllowResize="False" ViewStateMode="Disabled"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Width="800px" MinWidth="300px" MaxHeight="600px" HeaderText="Resposta do Cliente" Theme="MetropolisBlue"
        ClientInstanceName="popResposta" EnableHierarchyRecreation="False" Modal="true">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div style="padding: 15px;" id="divResposta" class="TextoCinza16">
                </div>
                <div align="center">
                    <br />
                    <br />
                    <dx:ASPxButton ID="cmdFecharMensagem" runat="server" Text="Fechar" Theme="MetropolisBlue" Width="100px">
                        <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popResposta.Hide(); }"></ClientSideEvents>
                    </dx:ASPxButton>
                    <br />
                    <br />
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popComentarioInterno" runat="server" AllowDragging="True" AllowResize="False" ViewStateMode="Disabled"
        CloseAction="CloseButton" EnableViewState="False" PopupHorizontalAlign="WindowCenter" 
        PopupVerticalAlign="WindowCenter" Width="800px" MinWidth="800px" Height="600px" MinHeight="600px" HeaderText="Comentário Interno" 
        Theme="MetropolisBlue" ClientInstanceName="popComentarioInterno" EnableHierarchyRecreation="False" Modal="true">
        <HeaderStyle BackColor="#cccccc" ForeColor="#ffffff" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxHtmlEditor ID="htmInterno" ClientInstanceName="htmInterno" runat="server" Width="95%" Height="480px" Settings-AllowDesignView="True" Settings-AllowPreview="False" Settings-AllowHtmlView="False">
                    <ClientSideEvents BeginCallback="function(s, e) { pnlLoader.Show(); }" EndCallback="function(s, e) { pnlLoader.Hide(); }" />
                </dx:ASPxHtmlEditor>
                <br />
                <table style="width: 95%;">
                    <tr>
                        <td align="center" style="width: 20%; text-align: center; vertical-align: top;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 80%; vertical-align: top;">
                            <dx:ASPxButton ID="cmdSalvarComentarioInterno" runat="server" Text="Salvar" Width="100px">
                                <ClientSideEvents Click="function(s, e) { SalvarComentarioInterno(s, e) }" />
                            </dx:ASPxButton>
                            <dx:ASPxButton ID="cmdCancelarComentarioInterno" runat="server" Text="Cancelar" Width="100px">
                                <ClientSideEvents Click="function(s, e) { e.processOnServer = false; popComentarioInterno.Hide(); }" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxLoadingPanel ID="pnlLoader" runat="server" ClientInstanceName="pnlLoader" Modal="True" Theme="MetropolisBlue" />
</asp:Content>
