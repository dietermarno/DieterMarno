using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Cliente_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_CodCli = 0;
        private string _Nome = string.Empty;
        private string _LocalTrab = string.Empty;
        private Int32 _CodProf = 0;
        private Int32 _CodBco = 0;
        private Int32 _TipoCli = 0;
        private Int32 _SitCli = 0;
        private Int32 _PostoVen = 0;
        private Int32 _CodPromotor = 0;
        private string _Titular = string.Empty;
        private string _MneCli = string.Empty;
        private string _LeiKandir = string.Empty;
        private string _StatusCli = string.Empty;
        private double _IndicePontosCli = 0;
        private double _PercentPontosCli = 0;
        private Int32 _CodEmissor = 0;
        private Int32 _CodTerceiro = 0;
        private string _GeraFatPDF = string.Empty;
        private Int16 _AgrupaCodCtbForn = 0;
        private Int16 _AgrupaTipoCobra = 0;
        private Int16 _AgrupaCatProd = 0;
        private Int16 _AgrupaProd = 0;
        private Int16 _AgrupaForn = 0;
        private Int16 _AgrupaCC = 0;
        private Int16 _AgrupaPax = 0;
        private Int16 _AgrupaReq = 0;
        private string _PeriodoFatura = string.Empty;
        private Int16 _ItensFatura = 0;
        private Int16 _AgrupaReqCliente = 0;
        private string _Contato = string.Empty;
        private string _Sexo = string.Empty;
        private string _EndRes = string.Empty;
        private string _FoneRes = string.Empty;
        private string _FaxRes = string.Empty;
        private Int32 _CodCidadeRes = 0;
        private string _CEPRes = string.Empty;
        private Int16 _TempoRes = 0;
        private string _Filiacao = string.Empty;
        private DateTime? _DataNasc = null;
        private string _CIC = string.Empty;
        private string _RG = string.Empty;
        private string _Orgao = string.Empty;
        private string _RGUF = string.Empty;
        private string _Nacionalidade = string.Empty;
        private string _Naturalidade = string.Empty;
        private string _InscrEstadual = string.Empty;
        private string _CGC = string.Empty;
        private string _EstadoCivil = string.Empty;
        private string _EMail = string.Empty;
        private string _Passaporte = string.Empty;
        private DateTime? _ValidPassaporte = null;
        private string _NomeVisto1 = string.Empty;
        private string _NomeVisto2 = string.Empty;
        private DateTime? _ValidVisto1 = null;
        private DateTime? _ValidVisto2 = null;
        private string _EndTrab = string.Empty;
        private Int32 _CodCidadeTrab = 0;
        private string _CEPTrab = string.Empty;
        private string _FoneTrab = string.Empty;
        private string _FaxTrab = string.Empty;
        private Int16 _TempoTrab = 0;
        private double _Renda = 0;
        private string _RefCom = string.Empty;
        private string _FoneRefCom = string.Empty;
        private string _RefBco = string.Empty;
        private string _FoneRefBco = string.Empty;
        private string _Cia1 = string.Empty;
        private string _NroCia1 = string.Empty;
        private string _Cia2 = string.Empty;
        private string _NroCia2 = string.Empty;
        private string _Cia3 = string.Empty;
        private string _NroCia3 = string.Empty;
        private string _Cia4 = string.Empty;
        private string _NroCia4 = string.Empty;
        private DateTime? _DataCad = null;
        private string _CodContabil = string.Empty;
        private string _Fumante = string.Empty;
        private string _Assento = string.Empty;
        private string _EndCobr = string.Empty;
        private Int32 _CodCidadeCobr = 0;
        private string _CEPCobr = string.Empty;
        private string _EndCorresp = string.Empty;
        private string _SitCredito = string.Empty;
        private string _Observacoes = string.Empty;
        private string _CartaoCred1 = string.Empty;
        private string _CartaoCred2 = string.Empty;
        private string _CartaoCred3 = string.Empty;
        private string _CartaoCred4 = string.Empty;
        private string _NroCartao1 = string.Empty;
        private string _NroCartao2 = string.Empty;
        private string _NroCartao3 = string.Empty;
        private string _NroCartao4 = string.Empty;
        private string _ValidCartao1 = string.Empty;
        private string _ValidCartao2 = string.Empty;
        private string _ValidCartao3 = string.Empty;
        private string _ValidCartao4 = string.Empty;
        private string _TituloMala = string.Empty;
        private string _TipoPessoa = string.Empty;
        private string _VenctoCartao1 = string.Empty;
        private string _VenctoCartao2 = string.Empty;
        private string _VenctoCartao3 = string.Empty;
        private string _VenctoCartao4 = string.Empty;
        private DateTime? _DtUltimaAlteracao = null;
        private string _UltimaAlteracaoPor = string.Empty;
        private DateTime? _EmissVisto1 = null;
        private DateTime? _EmissVisto2 = null;
        private string _Funcao = string.Empty;
        private string _ChaveLivre1 = string.Empty;
        private string _ChaveLivre2 = string.Empty;
        private string _AssinaNewsletter = string.Empty;
        private string _TipoNewsletter = string.Empty;
        private string _CreditoDinCC = string.Empty;
        private string _CreditoCheque = string.Empty;
        private string _CreditoOutros = string.Empty;
        private string _PotCres = string.Empty;
        private string _ValEstra = string.Empty;
        private string _ContaEBTA = string.Empty;
        private string _Fantasia = string.Empty;
        private string _Bairro = string.Empty;
        private string _TitularCartao1 = string.Empty;
        private string _TitularCartao2 = string.Empty;
        private string _TitularCartao3 = string.Empty;
        private string _CSCartao1 = string.Empty;
        private string _CSCartao2 = string.Empty;
        private string _CSCartao3 = string.Empty;
        private double _VlrTxBco = 0;
        private string _ContaCTA = string.Empty;
        private string _ContaVisa = string.Empty;
        private string _ObrigaCentroCusto = string.Empty;
        private string _ObrigaObservacao = string.Empty;
        private double _LimiteUnit = 0;
        private string _InscrMunicipal = string.Empty;
        private string _EMailNFSe = string.Empty;

        //*******************
        //* Campos da tabela
        //*******************
	    public Int32 PK_CodCli { get { return _PK_CodCli; } set { _PK_CodCli = value; } }
	    public string Nome { get { return _Nome.Left(40); } set { _Nome = value; } }
        public string LocalTrab { get { return _LocalTrab.Left(40); } set { _LocalTrab = value; } }
	    public Int32 CodProf { get { return _CodProf; } set { _CodProf = value; } }
	    public Int32 CodBco { get { return _CodBco; } set { _CodBco = value; } }
	    public Int32 TipoCli { get { return _TipoCli; } set { _TipoCli = value; } }
	    public Int32 SitCli { get { return _SitCli; } set { _SitCli = value; } }
	    public Int32 PostoVen { get { return _PostoVen; } set { _PostoVen = value; } }
	    public Int32 CodPromotor { get { return _CodPromotor; } set { _CodPromotor = value; } }
        public string Titular { get { return _Titular.Left(1); } set { _Titular = value; } }
        public string MneCli { get { return _MneCli.Left(14); } set { _MneCli = value; } }
        public string LeiKandir { get { return _LeiKandir.Left(1); } set { _LeiKandir = value; } }
        public string StatusCli { get { return _StatusCli.Left(1); } set { _StatusCli = value; } }
	    public double IndicePontosCli { get { return _IndicePontosCli; } set { _IndicePontosCli = value; } }
	    public double PercentPontosCli { get { return _PercentPontosCli; } set { _PercentPontosCli = value; } }
	    public Int32 CodEmissor { get { return _CodEmissor; } set { _CodEmissor = value; } }
	    public Int32 CodTerceiro { get { return _CodTerceiro; } set { _CodTerceiro = value; } }
        public string GeraFatPDF { get { return _GeraFatPDF.Left(1); } set { _GeraFatPDF = value; } }
	    public Int16 AgrupaCodCtbForn { get { return _AgrupaCodCtbForn; } set { _AgrupaCodCtbForn = value; } }
	    public Int16 AgrupaTipoCobra { get { return _AgrupaTipoCobra; } set { _AgrupaTipoCobra = value; } }
	    public Int16 AgrupaCatProd { get { return _AgrupaCatProd; } set { _AgrupaCatProd = value; } }
	    public Int16 AgrupaProd { get { return _AgrupaProd; } set { _AgrupaProd = value; } }
	    public Int16 AgrupaForn { get { return _AgrupaForn; } set { _AgrupaForn = value; } }
	    public Int16 AgrupaCC { get { return _AgrupaCC; } set { _AgrupaCC = value; } }
	    public Int16 AgrupaPax { get { return _AgrupaPax; } set { _AgrupaPax = value; } }
	    public Int16 AgrupaReq { get { return _AgrupaReq; } set { _AgrupaReq = value; } }
        public string PeriodoFatura { get { return _PeriodoFatura.Left(20); } set { _PeriodoFatura = value; } }
	    public Int16 ItensFatura { get { return _ItensFatura; } set { _ItensFatura = value; } }
	    public Int16 AgrupaReqCliente { get { return _AgrupaReqCliente; } set { _AgrupaReqCliente = value; } }
        public string Contato { get { return _Contato.Left(40); } set { _Contato = value; } }
        public string Sexo { get { return _Sexo.Left(1); } set { _Sexo = value; } }
        public string EndRes { get { return _EndRes.Left(40); } set { _EndRes = value; } }
        public string FoneRes { get { return _FoneRes.Left(20); } set { _FoneRes = value; } }
        public string FaxRes { get { return _FaxRes.Left(20); } set { _FaxRes = value; } }
	    public Int32 CodCidadeRes { get { return _CodCidadeRes; } set { _CodCidadeRes = value; } }
        public string CEPRes { get { return _CEPRes.Left(9); } set { _CEPRes = value; } }
	    public Int16 TempoRes { get { return _TempoRes; } set { _TempoRes = value; } }
        public string Filiacao { get { return _Filiacao.Left(70); } set { _Filiacao = value; } }
	    public DateTime? DataNasc { get { return _DataNasc; } set { _DataNasc = value; } }
        public string CIC { get { return _CIC.Left(11); } set { _CIC = value; } }
        public string RG { get { return _RG.Left(11); } set { _RG = value; } }
        public string Orgao { get { return _Orgao.Left(5); } set { _Orgao = value; } }
        public string RGUF { get { return _RGUF.Left(2); } set { _RGUF = value; } }
        public string Nacionalidade { get { return _Nacionalidade.Left(25); } set { _Nacionalidade = value; } }
        public string Naturalidade { get { return _Naturalidade.Left(25); } set { _Naturalidade = value; } }
        public string InscrEstadual { get { return _InscrEstadual.Left(14); } set { _InscrEstadual = value; } }
        public string CGC { get { return _CGC.Left(14); } set { _CGC = value; } }
        public string EstadoCivil { get { return _EstadoCivil.Left(1); } set { _EstadoCivil = value; } }
        public string EMail { get { return _EMail.Left(60); } set { _EMail = value; } }
        public string Passaporte { get { return _Passaporte.Left(10); } set { _Passaporte = value; } }
	    public DateTime? ValidPassaporte { get { return _ValidPassaporte; } set { _ValidPassaporte = value; } }
        public string NomeVisto1 { get { return _NomeVisto1.Left(10); } set { _NomeVisto1 = value; } }
	    public string NomeVisto2 { get { return _NomeVisto2.Left(10); } set { _NomeVisto2 = value; } }
	    public DateTime? ValidVisto1 { get { return _ValidVisto1; } set { _ValidVisto1 = value; } }
	    public DateTime? ValidVisto2 { get { return _ValidVisto2; } set { _ValidVisto2 = value; } }
        public string EndTrab { get { return _EndTrab.Left(40); } set { _EndTrab = value; } }
	    public Int32 CodCidadeTrab { get { return _CodCidadeTrab; } set { _CodCidadeTrab = value; } }
        public string CEPTrab { get { return _CEPTrab.Left(9); } set { _CEPTrab = value; } }
        public string FoneTrab { get { return _FoneTrab.Left(20); } set { _FoneTrab = value; } }
        public string FaxTrab { get { return _FaxTrab.Left(20); } set { _FaxTrab = value; } }
	    public Int16 TempoTrab { get { return _TempoTrab; } set { _TempoTrab = value; } }
	    public double Renda { get { return _Renda; } set { _Renda = value; } }
        public string RefCom { get { return _RefCom.Left(40); } set { _RefCom = value; } }
        public string FoneRefCom { get { return _FoneRefCom.Left(20); } set { _FoneRefCom = value; } }
        public string RefBco { get { return _RefBco; } set { _RefBco = value; } }
        public string FoneRefBco { get { return _FoneRefBco.Left(20); } set { _FoneRefBco = value; } }
        public string Cia1 { get { return _Cia1.Left(20); } set { _Cia1 = value; } }
        public string NroCia1 { get { return _NroCia1.Left(15); } set { _NroCia1 = value; } }
        public string Cia2 { get { return _Cia2.Left(20); } set { _Cia2 = value; } }
        public string NroCia2 { get { return _NroCia2.Left(15); } set { _NroCia2 = value; } }
        public string Cia3 { get { return _Cia3.Left(20); } set { _Cia3 = value; } }
        public string NroCia3 { get { return _NroCia3.Left(15); } set { _NroCia3 = value; } }
        public string Cia4 { get { return _Cia4.Left(20); } set { _Cia4 = value; } }
        public string NroCia4 { get { return _NroCia4.Left(15); } set { _NroCia4 = value; } }
	    public DateTime? DataCad { get { return _DataCad; } set { _DataCad = value; } }
        public string CodContabil { get { return _CodContabil.Left(10); } set { _CodContabil = value; } }
        public string Fumante { get { return _Fumante.Left(1); } set { _Fumante = value; } }
        public string Assento { get { return _Assento.Left(1); } set { _Assento = value; } }
        public string EndCobr { get { return _EndCobr.Left(40); } set { _EndCobr = value; } }
	    public Int32 CodCidadeCobr { get { return _CodCidadeCobr; } set { _CodCidadeCobr = value; } }
        public string CEPCobr { get { return _CEPCobr.Left(9); } set { _CEPCobr = value; } }
        public string EndCorresp { get { return _EndCorresp.Left(1); } set { _EndCorresp = value; } }
        public string SitCredito { get { return _SitCredito.Left(1); } set { _SitCredito = value; } }
        public string Observacoes { get { return _Observacoes; } set { _Observacoes = value; } }
        public string CartaoCred1 { get { return _CartaoCred1.Left(12); } set { _CartaoCred1 = value; } }
        public string CartaoCred2 { get { return _CartaoCred2.Left(12); } set { _CartaoCred2 = value; } }
        public string CartaoCred3 { get { return _CartaoCred3.Left(12); } set { _CartaoCred3 = value; } }
        public string CartaoCred4 { get { return _CartaoCred4.Left(12); } set { _CartaoCred4 = value; } }
        public string NroCartao1 { get { return _NroCartao1.Left(20); } set { _NroCartao1 = value; } }
        public string NroCartao2 { get { return _NroCartao2.Left(20); } set { _NroCartao2 = value; } }
        public string NroCartao3 { get { return _NroCartao3.Left(20); } set { _NroCartao3 = value; } }
        public string NroCartao4 { get { return _NroCartao4.Left(20); } set { _NroCartao4 = value; } }
        public string ValidCartao1 { get { return _ValidCartao1.Left(6); } set { _ValidCartao1 = value; } }
        public string ValidCartao2 { get { return _ValidCartao2.Left(6); } set { _ValidCartao2 = value; } }
        public string ValidCartao3 { get { return _ValidCartao3.Left(6); } set { _ValidCartao3 = value; } }
        public string ValidCartao4 { get { return _ValidCartao4.Left(6); } set { _ValidCartao4 = value; } }
        public string TituloMala { get { return _TituloMala.Left(40); } set { _TituloMala = value; } }
        public string TipoPessoa { get { return _TipoPessoa.Left(1); } set { _TipoPessoa = value; } }
        public string VenctoCartao1 { get { return _VenctoCartao1.Left(2); } set { _VenctoCartao1 = value; } }
        public string VenctoCartao2 { get { return _VenctoCartao2.Left(2); } set { _VenctoCartao2 = value; } }
        public string VenctoCartao3 { get { return _VenctoCartao3.Left(2); } set { _VenctoCartao3 = value; } }
        public string VenctoCartao4 { get { return _VenctoCartao4.Left(2); } set { _VenctoCartao4 = value; } }
	    public DateTime? DtUltimaAlteracao { get { return _DtUltimaAlteracao; } set { _DtUltimaAlteracao = value; } }
        public string UltimaAlteracaoPor { get { return _UltimaAlteracaoPor.Left(20); } set { _UltimaAlteracaoPor = value; } }
	    public DateTime? EmissVisto1 { get { return _EmissVisto1; } set { _EmissVisto1 = value; } }
	    public DateTime? EmissVisto2 { get { return _EmissVisto2; } set { _EmissVisto2 = value; } }
	    public string Funcao { get { return _Funcao.Left(30); } set { _Funcao = value; } }
	    public string ChaveLivre1 { get { return _ChaveLivre1.Left(30); } set { _ChaveLivre1 = value; } }
	    public string ChaveLivre2 { get { return _ChaveLivre2.Left(30); } set { _ChaveLivre2 = value; } }
	    public string AssinaNewsletter { get { return _AssinaNewsletter.Left(1); } set { _AssinaNewsletter = value; } }
	    public string TipoNewsletter { get { return _TipoNewsletter.Left(1); } set { _TipoNewsletter = value; } }
	    public string CreditoDinCC { get { return _CreditoDinCC.Left(1); } set { _CreditoDinCC = value; } }
	    public string CreditoCheque { get { return _CreditoCheque.Left(1); } set { _CreditoCheque = value; } }
	    public string CreditoOutros { get { return _CreditoOutros.Left(1); } set { _CreditoOutros = value; } }
	    public string PotCres { get { return _PotCres.Left(1); } set { _PotCres = value; } }
	    public string ValEstra { get { return _ValEstra.Left(1); } set { _ValEstra = value; } }
	    public string ContaEBTA { get { return _ContaEBTA.Left(16); } set { _ContaEBTA = value; } }
	    public string Fantasia { get { return _Fantasia.Left(40); } set { _Fantasia = value; } }
	    public string Bairro { get { return _Bairro.Left(25); } set { _Bairro = value; } }
	    public string TitularCartao1 { get { return _TitularCartao1.Left(40); } set { _TitularCartao1 = value; } }
	    public string TitularCartao2 { get { return _TitularCartao2.Left(40); } set { _TitularCartao2 = value; } }
	    public string TitularCartao3 { get { return _TitularCartao3.Left(40); } set { _TitularCartao3 = value; } }
	    public string CSCartao1 { get { return _CSCartao1.Left(5); } set { _CSCartao1 = value; } }
	    public string CSCartao2 { get { return _CSCartao2.Left(5); } set { _CSCartao2 = value; } }
	    public string CSCartao3 { get { return _CSCartao3.Left(5); } set { _CSCartao3 = value; } }
	    public double VlrTxBco { get { return _VlrTxBco; } set { _VlrTxBco = value; } }
	    public string ContaCTA { get { return _ContaCTA.Left(16); } set { _ContaCTA = value; } }
	    public string ContaVisa { get { return _ContaVisa.Left(16); } set { _ContaVisa = value; } }
	    public string ObrigaCentroCusto { get { return _ObrigaCentroCusto.Left(1); } set { _ObrigaCentroCusto = value; } }
	    public string ObrigaObservacao { get { return _ObrigaObservacao.Left(1); } set { _ObrigaObservacao = value; } }
	    public double LimiteUnit { get { return _LimiteUnit; } set { _LimiteUnit = value; } }
	    public string InscrMunicipal { get { return _InscrMunicipal.Left(14); } set { _InscrMunicipal = value; } }
	    public string EMailNFSe { get { return _EMailNFSe.Left(60); } set { _EMailNFSe = value; } }
        public Cliente_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_CodCli = 0;
            _Nome = string.Empty;
            _LocalTrab = string.Empty;
            _CodProf = 0;
            _CodBco = 0;
            _TipoCli = 0;
            _SitCli = 0;
            _PostoVen = 0;
            _CodPromotor = 0;
            _Titular = string.Empty;
            _MneCli = string.Empty;
            _LeiKandir = string.Empty;
            _StatusCli = string.Empty;
            _IndicePontosCli = 0;
            _PercentPontosCli = 0;
            _CodEmissor = 0;
            _CodTerceiro = 0;
            _GeraFatPDF = string.Empty;
            _AgrupaCodCtbForn = 0;
            _AgrupaTipoCobra = 0;
            _AgrupaCatProd = 0;
            _AgrupaProd = 0;
            _AgrupaForn = 0;
            _AgrupaCC = 0;
            _AgrupaPax = 0;
            _AgrupaReq = 0;
            _PeriodoFatura = string.Empty;
            _ItensFatura = 0;
            _AgrupaReqCliente = 0;
            _Contato = string.Empty;
            _Sexo = string.Empty;
            _EndRes = string.Empty;
            _FoneRes = string.Empty;
            _FaxRes = string.Empty;
            _CodCidadeRes = 0;
            _CEPRes = string.Empty;
            _TempoRes = 0;
            _Filiacao = string.Empty;
            _DataNasc = null;
            _CIC = string.Empty;
            _RG = string.Empty;
            _Orgao = string.Empty;
            _RGUF = string.Empty;
            _Nacionalidade = string.Empty;
            _Naturalidade = string.Empty;
            _InscrEstadual = string.Empty;
            _CGC = string.Empty;
            _EstadoCivil = string.Empty;
            _EMail = string.Empty;
            _Passaporte = string.Empty;
            _ValidPassaporte = null;
            _NomeVisto1 = string.Empty;
            _NomeVisto2 = string.Empty;
            _ValidVisto1 = null;
            _ValidVisto2 = null;
            _EndTrab = string.Empty;
            _CodCidadeTrab = 0;
            _CEPTrab = string.Empty;
            _FoneTrab = string.Empty;
            _FaxTrab = string.Empty;
            _TempoTrab = 0;
            _Renda = 0;
            _RefCom = string.Empty;
            _FoneRefCom = string.Empty;
            _RefBco = string.Empty;
            _FoneRefBco = string.Empty;
            _Cia1 = string.Empty;
            _NroCia1 = string.Empty;
            _Cia2 = string.Empty;
            _NroCia2 = string.Empty;
            _Cia3 = string.Empty;
            _NroCia3 = string.Empty;
            _Cia4 = string.Empty;
            _NroCia4 = string.Empty;
            _DataCad = null;
            _CodContabil = string.Empty;
            _Fumante = string.Empty;
            _Assento = string.Empty;
            _EndCobr = string.Empty;
            _CodCidadeCobr = 0;
            _CEPCobr = string.Empty;
            _EndCorresp = string.Empty;
            _SitCredito = string.Empty;
            _Observacoes = string.Empty;
            _CartaoCred1 = string.Empty;
            _CartaoCred2 = string.Empty;
            _CartaoCred3 = string.Empty;
            _CartaoCred4 = string.Empty;
            _NroCartao1 = string.Empty;
            _NroCartao2 = string.Empty;
            _NroCartao3 = string.Empty;
            _NroCartao4 = string.Empty;
            _ValidCartao1 = string.Empty;
            _ValidCartao2 = string.Empty;
            _ValidCartao3 = string.Empty;
            _ValidCartao4 = string.Empty;
            _TituloMala = string.Empty;
            _TipoPessoa = string.Empty;
            _VenctoCartao1 = string.Empty;
            _VenctoCartao2 = string.Empty;
            _VenctoCartao3 = string.Empty;
            _VenctoCartao4 = string.Empty;
            _DtUltimaAlteracao = null;
            _UltimaAlteracaoPor = string.Empty;
            _EmissVisto1 = null;
            _EmissVisto2 = null;
            _Funcao = string.Empty;
            _ChaveLivre1 = string.Empty;
            _ChaveLivre2 = string.Empty;
            _AssinaNewsletter = string.Empty;
            _TipoNewsletter = string.Empty;
            _CreditoDinCC = string.Empty;
            _CreditoCheque = string.Empty;
            _CreditoOutros = string.Empty;
            _PotCres = string.Empty;
            _ValEstra = string.Empty;
            _ContaEBTA = string.Empty;
            _Fantasia = string.Empty;
            _Bairro = string.Empty;
            _TitularCartao1 = string.Empty;
            _TitularCartao2 = string.Empty;
            _TitularCartao3 = string.Empty;
            _CSCartao1 = string.Empty;
            _CSCartao2 = string.Empty;
            _CSCartao3 = string.Empty;
            _VlrTxBco = 0;
            _ContaCTA = string.Empty;
            _ContaVisa = string.Empty;
            _ObrigaCentroCusto = string.Empty;
            _ObrigaObservacao = string.Empty;
            _LimiteUnit = 0;
            _InscrMunicipal = string.Empty;
            _EMailNFSe = string.Empty;
        }
    }
    public class Cliente_Manager
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
        public Cliente_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Cliente_Fields GetRecord(Int32 CodCliente)
        {
            //**************
            //* Declarações
            //**************
            Cliente_Fields oCliente = new Cliente_Fields();
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
                SQL = "SELECT * FROM clientes WHERE codcli = " + CodCliente;
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
	                oCliente.PK_CodCli = !DBNull.Value.Equals(oRow["CodCli"]) ? Convert.ToInt32("0" + oRow["CodCli"]) : 0;
	                oCliente.Nome = !DBNull.Value.Equals(oRow["Nome"]) ? oRow["Nome"].ToString() : string.Empty;
	                oCliente.LocalTrab = !DBNull.Value.Equals(oRow["LocalTrab"]) ? oRow["LocalTrab"].ToString() : string.Empty;
	                oCliente.CodProf = !DBNull.Value.Equals(oRow["CodProf"]) ? Convert.ToInt32("0" + oRow["CodProf"]) : 0;
	                oCliente.CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
	                oCliente.TipoCli = !DBNull.Value.Equals(oRow["TipoCli"]) ? Convert.ToInt32("0" + oRow["TipoCli"]) : 0;
	                oCliente.SitCli = !DBNull.Value.Equals(oRow["SitCli"]) ? Convert.ToInt32("0" + oRow["SitCli"]) : 0;
	                oCliente.PostoVen = !DBNull.Value.Equals(oRow["PostoVen"]) ? Convert.ToInt32("0" + oRow["PostoVen"]) : 0;
	                oCliente.CodPromotor = !DBNull.Value.Equals(oRow["CodPromotor"]) ? Convert.ToInt32("0" + oRow["CodPromotor"]) : 0;
	                oCliente.Titular = !DBNull.Value.Equals(oRow["Titular"]) ? oRow["Titular"].ToString() : string.Empty;
	                oCliente.MneCli = !DBNull.Value.Equals(oRow["MneCli"]) ? oRow["MneCli"].ToString() : string.Empty;
	                oCliente.LeiKandir = !DBNull.Value.Equals(oRow["LeiKandir"]) ? oRow["LeiKandir"].ToString() : string.Empty;
	                oCliente.StatusCli = !DBNull.Value.Equals(oRow["StatusCli"]) ? oRow["StatusCli"].ToString() : string.Empty;
	                oCliente.IndicePontosCli = !DBNull.Value.Equals(oRow["IndicePontosCli"]) ? Convert.ToDouble("0" + oRow["IndicePontosCli"]) : 0;
	                oCliente.PercentPontosCli = !DBNull.Value.Equals(oRow["PercentPontosCli"]) ? Convert.ToDouble("0" + oRow["PercentPontosCli"]) : 0;
	                oCliente.CodEmissor = !DBNull.Value.Equals(oRow["CodEmissor"]) ? Convert.ToInt32("0" + oRow["CodEmissor"]) : 0;
	                oCliente.CodTerceiro = !DBNull.Value.Equals(oRow["CodTerceiro"]) ? Convert.ToInt32("0" + oRow["CodTerceiro"]) : 0;
	                oCliente.GeraFatPDF = !DBNull.Value.Equals(oRow["GeraFatPDF"]) ? oRow["GeraFatPDF"].ToString() : string.Empty;
	                oCliente.AgrupaCodCtbForn = !DBNull.Value.Equals(oRow["AgrupaCodCtbForn"]) ? Convert.ToInt16("0" + oRow["AgrupaCodCtbForn"]) : (Int16)0;
	                oCliente.AgrupaTipoCobra = !DBNull.Value.Equals(oRow["AgrupaTipoCobra"]) ? Convert.ToInt16("0" + oRow["AgrupaTipoCobra"]) : (Int16)0;
	                oCliente.AgrupaCatProd = !DBNull.Value.Equals(oRow["AgrupaCatProd"]) ? Convert.ToInt16("0" + oRow["AgrupaCatProd"]) : (Int16)0;
	                oCliente.AgrupaProd = !DBNull.Value.Equals(oRow["AgrupaProd"]) ? Convert.ToInt16("0" + oRow["AgrupaProd"]) : (Int16)0;
	                oCliente.AgrupaForn = !DBNull.Value.Equals(oRow["AgrupaForn"]) ? Convert.ToInt16("0" + oRow["AgrupaForn"]) : (Int16)0;
	                oCliente.AgrupaCC = !DBNull.Value.Equals(oRow["AgrupaCC"]) ? Convert.ToInt16("0" + oRow["AgrupaCC"]) : (Int16)0;
	                oCliente.AgrupaPax = !DBNull.Value.Equals(oRow["AgrupaPax"]) ? Convert.ToInt16("0" + oRow["AgrupaPax"]) : (Int16)0;
	                oCliente.AgrupaReq = !DBNull.Value.Equals(oRow["AgrupaReq"]) ? Convert.ToInt16("0" + oRow["AgrupaReq"]) : (Int16)0;
	                oCliente.PeriodoFatura = !DBNull.Value.Equals(oRow["PeriodoFatura"]) ? oRow["PeriodoFatura"].ToString() : string.Empty;
	                oCliente.ItensFatura = !DBNull.Value.Equals(oRow["ItensFatura"]) ? Convert.ToInt16("0" + oRow["ItensFatura"]) : (Int16)0;
	                oCliente.AgrupaReqCliente = !DBNull.Value.Equals(oRow["AgrupaReqCliente"]) ? Convert.ToInt16("0" + oRow["AgrupaReqCliente"]) : (Int16)0;
	                oCliente.Contato = !DBNull.Value.Equals(oRow["Contato"]) ? oRow["Contato"].ToString() : string.Empty;
	                oCliente.Sexo = !DBNull.Value.Equals(oRow["Sexo"]) ? oRow["Sexo"].ToString() : string.Empty;
	                oCliente.EndRes = !DBNull.Value.Equals(oRow["EndRes"]) ? oRow["EndRes"].ToString() : string.Empty;
	                oCliente.FoneRes = !DBNull.Value.Equals(oRow["FoneRes"]) ? oRow["FoneRes"].ToString() : string.Empty;
	                oCliente.FaxRes = !DBNull.Value.Equals(oRow["FaxRes"]) ? oRow["FaxRes"].ToString() : string.Empty;
	                oCliente.CodCidadeRes = !DBNull.Value.Equals(oRow["CodCidadeRes"]) ? Convert.ToInt32("0" + oRow["CodCidadeRes"]) : 0;
	                oCliente.CEPRes = !DBNull.Value.Equals(oRow["CEPRes"]) ? oRow["CEPRes"].ToString() : string.Empty;
	                oCliente.TempoRes = !DBNull.Value.Equals(oRow["TempoRes"]) ? Convert.ToInt16("0" + oRow["TempoRes"]) : (Int16)0;
	                oCliente.Filiacao = !DBNull.Value.Equals(oRow["Filiacao"]) ? oRow["Filiacao"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["DataNasc"])) 
                        oCliente.DataNasc = Convert.ToDateTime(oRow["DataNasc"]);
	                oCliente.CIC = !DBNull.Value.Equals(oRow["CIC"]) ? oRow["CIC"].ToString() : string.Empty;
	                oCliente.RG = !DBNull.Value.Equals(oRow["RG"]) ? oRow["RG"].ToString() : string.Empty;
	                oCliente.Orgao = !DBNull.Value.Equals(oRow["Orgao"]) ? oRow["Orgao"].ToString() : string.Empty;
	                oCliente.RGUF = !DBNull.Value.Equals(oRow["RGUF"]) ? oRow["RGUF"].ToString() : string.Empty;
	                oCliente.Nacionalidade = !DBNull.Value.Equals(oRow["Nacionalidade"]) ? oRow["Nacionalidade"].ToString() : string.Empty;
	                oCliente.Naturalidade = !DBNull.Value.Equals(oRow["Naturalidade"]) ? oRow["Naturalidade"].ToString() : string.Empty;
	                oCliente.InscrEstadual = !DBNull.Value.Equals(oRow["InscrEstadual"]) ? oRow["InscrEstadual"].ToString() : string.Empty;
	                oCliente.CGC = !DBNull.Value.Equals(oRow["CG"]) ? oRow["CG"].ToString() : string.Empty;
	                oCliente.EstadoCivil = !DBNull.Value.Equals(oRow["EstadoCivil"]) ? oRow["EstadoCivil"].ToString() : string.Empty;
	                oCliente.EMail = !DBNull.Value.Equals(oRow["EMail"]) ? oRow["EMail"].ToString() : string.Empty;
	                oCliente.Passaporte = !DBNull.Value.Equals(oRow["Passaporte"]) ? oRow["Passaporte"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["ValidPassaporte"])) 
                        oCliente.ValidPassaporte = Convert.ToDateTime(oRow["ValidPassaporte"]);
	                oCliente.NomeVisto1 = !DBNull.Value.Equals(oRow["NomeVisto1"]) ? oRow["NomeVisto1"].ToString() : string.Empty;
	                oCliente.NomeVisto2 = !DBNull.Value.Equals(oRow["NomeVisto2"]) ? oRow["NomeVisto2"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["ValidVisto1"])) 
                        oCliente.ValidVisto1 = Convert.ToDateTime(oRow["ValidVisto1"]);
	                if (!DBNull.Value.Equals(oRow["ValidVisto2"])) 
                        oCliente.ValidVisto2 = Convert.ToDateTime(oRow["ValidVisto2"]);
	                oCliente.EndTrab = !DBNull.Value.Equals(oRow["EndTrab"]) ? oRow["EndTrab"].ToString() : string.Empty;
	                oCliente.CodCidadeTrab = !DBNull.Value.Equals(oRow["CodCidadeTrab"]) ? Convert.ToInt32("0" + oRow["CodCidadeTrab"]) : 0;
	                oCliente.CEPTrab = !DBNull.Value.Equals(oRow["CEPTrab"]) ? oRow["CEPTrab"].ToString() : string.Empty;
	                oCliente.FoneTrab = !DBNull.Value.Equals(oRow["FoneTrab"]) ? oRow["FoneTrab"].ToString() : string.Empty;
	                oCliente.FaxTrab = !DBNull.Value.Equals(oRow["FaxTrab"]) ? oRow["FaxTrab"].ToString() : string.Empty;
	                oCliente.TempoTrab = !DBNull.Value.Equals(oRow["TempoTrab"]) ? Convert.ToInt16("0" + oRow["TempoTrab"]) : (Int16)0;
	                oCliente.Renda = !DBNull.Value.Equals(oRow["Renda"]) ? Convert.ToInt32("0" + oRow["Renda"]) : 0;
	                oCliente.RefCom = !DBNull.Value.Equals(oRow["RefCom"]) ? oRow["RefCom"].ToString() : string.Empty;
	                oCliente.FoneRefCom = !DBNull.Value.Equals(oRow["FoneRefCom"]) ? oRow["FoneRefCom"].ToString() : string.Empty;
	                oCliente.RefBco = !DBNull.Value.Equals(oRow["RefBco"]) ? oRow["RefBco"].ToString() : string.Empty;
	                oCliente.FoneRefBco = !DBNull.Value.Equals(oRow["FoneRefBco"]) ? oRow["FoneRefBco"].ToString() : string.Empty;
	                oCliente.Cia1 = !DBNull.Value.Equals(oRow["Cia1"]) ? oRow["Cia1"].ToString() : string.Empty;
	                oCliente.NroCia1 = !DBNull.Value.Equals(oRow["NroCia1"]) ? oRow["NroCia1"].ToString() : string.Empty;
	                oCliente.Cia2 = !DBNull.Value.Equals(oRow["Cia2"]) ? oRow["Cia2"].ToString() : string.Empty;
	                oCliente.NroCia2 = !DBNull.Value.Equals(oRow["NroCia2"]) ? oRow["NroCia2"].ToString() : string.Empty;
	                oCliente.Cia3 = !DBNull.Value.Equals(oRow["Cia3"]) ? oRow["Cia3"].ToString() : string.Empty;
	                oCliente.NroCia3 = !DBNull.Value.Equals(oRow["NroCia3"]) ? oRow["NroCia3"].ToString() : string.Empty;
	                oCliente.Cia4 = !DBNull.Value.Equals(oRow["Cia4"]) ? oRow["Cia4"].ToString() : string.Empty;
	                oCliente.NroCia4 = !DBNull.Value.Equals(oRow["NroCia4"]) ? oRow["NroCia4"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["DataCad"])) 
                        oCliente.DataCad = Convert.ToDateTime(oRow["DataCad"]);
	                oCliente.CodContabil = !DBNull.Value.Equals(oRow["CodContabil"]) ? oRow["CodContabil"].ToString() : string.Empty;
	                oCliente.Fumante = !DBNull.Value.Equals(oRow["Fumante"]) ? oRow["Fumante"].ToString() : string.Empty;
	                oCliente.Assento = !DBNull.Value.Equals(oRow["Assento"]) ? oRow["Assento"].ToString() : string.Empty;
	                oCliente.EndCobr = !DBNull.Value.Equals(oRow["EndCobr"]) ? oRow["EndCobr"].ToString() : string.Empty;
	                oCliente.CodCidadeCobr = !DBNull.Value.Equals(oRow["CodCidadeCobr"]) ? Convert.ToInt32("0" + oRow["CodCidadeCobr"]) : (Int16)0;
	                oCliente.CEPCobr = !DBNull.Value.Equals(oRow["CEPCobr"]) ? oRow["CEPCobr"].ToString() : string.Empty;
	                oCliente.EndCorresp = !DBNull.Value.Equals(oRow["EndCorresp"]) ? oRow["EndCorresp"].ToString() : string.Empty;
	                oCliente.SitCredito = !DBNull.Value.Equals(oRow["SitCredito"]) ? oRow["SitCredito"].ToString() : string.Empty;
	                oCliente.Observacoes = !DBNull.Value.Equals(oRow["Observacoes"]) ? oRow["Observacoes"].ToString() : string.Empty;
	                oCliente.CartaoCred1 = !DBNull.Value.Equals(oRow["CartaoCred1"]) ? oRow["CartaoCred1"].ToString() : string.Empty;
	                oCliente.CartaoCred2 = !DBNull.Value.Equals(oRow["CartaoCred2"]) ? oRow["CartaoCred2"].ToString() : string.Empty;
	                oCliente.CartaoCred3 = !DBNull.Value.Equals(oRow["CartaoCred3"]) ? oRow["CartaoCred3"].ToString() : string.Empty;
	                oCliente.CartaoCred4 = !DBNull.Value.Equals(oRow["CartaoCred4"]) ? oRow["CartaoCred4"].ToString() : string.Empty;
	                oCliente.NroCartao1 = !DBNull.Value.Equals(oRow["NroCartao1"]) ? oRow["NroCartao1"].ToString() : string.Empty;
	                oCliente.NroCartao2 = !DBNull.Value.Equals(oRow["NroCartao2"]) ? oRow["NroCartao2"].ToString() : string.Empty;
	                oCliente.NroCartao3 = !DBNull.Value.Equals(oRow["NroCartao3"]) ? oRow["NroCartao3"].ToString() : string.Empty;
	                oCliente.NroCartao4 = !DBNull.Value.Equals(oRow["NroCartao4"]) ? oRow["NroCartao4"].ToString() : string.Empty;
	                oCliente.ValidCartao1 = !DBNull.Value.Equals(oRow["ValidCartao1"]) ? oRow["ValidCartao1"].ToString() : string.Empty;
	                oCliente.ValidCartao2 = !DBNull.Value.Equals(oRow["ValidCartao2"]) ? oRow["ValidCartao2"].ToString() : string.Empty;
	                oCliente.ValidCartao3 = !DBNull.Value.Equals(oRow["ValidCartao3"]) ? oRow["ValidCartao3"].ToString() : string.Empty;
	                oCliente.ValidCartao4 = !DBNull.Value.Equals(oRow["ValidCartao4"]) ? oRow["ValidCartao4"].ToString() : string.Empty;
	                oCliente.TituloMala = !DBNull.Value.Equals(oRow["TituloMala"]) ? oRow["TituloMala"].ToString() : string.Empty;
	                oCliente.TipoPessoa = !DBNull.Value.Equals(oRow["TipoPessoa"]) ? oRow["TipoPessoa"].ToString() : string.Empty;
	                oCliente.VenctoCartao1 = !DBNull.Value.Equals(oRow["VenctoCartao1"]) ? oRow["VenctoCartao1"].ToString() : string.Empty;
	                oCliente.VenctoCartao2 = !DBNull.Value.Equals(oRow["VenctoCartao2"]) ? oRow["VenctoCartao2"].ToString() : string.Empty;
	                oCliente.VenctoCartao3 = !DBNull.Value.Equals(oRow["VenctoCartao3"]) ? oRow["VenctoCartao3"].ToString() : string.Empty;
	                oCliente.VenctoCartao4 = !DBNull.Value.Equals(oRow["VenctoCartao4"]) ? oRow["VenctoCartao4"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["DtUltimaAlteracao"])) 
                        oCliente.DtUltimaAlteracao = Convert.ToDateTime(oRow["DtUltimaAlteracao"]);
	                oCliente.UltimaAlteracaoPor = !DBNull.Value.Equals(oRow["UltimaAlteracaoPor"]) ? oRow["UltimaAlteracaoPor"].ToString() : string.Empty;
	                if (!DBNull.Value.Equals(oRow["EmissVisto1"])) 
                        oCliente.EmissVisto1 = Convert.ToDateTime(oRow["EmissVisto1"]);
	                if (!DBNull.Value.Equals(oRow["EmissVisto2"])) 
                        oCliente.EmissVisto2 = Convert.ToDateTime(oRow["EmissVisto2"]);
	                oCliente.Funcao = !DBNull.Value.Equals(oRow["Funcao"]) ? oRow["Funcao"].ToString() : string.Empty;
	                oCliente.ChaveLivre1 = !DBNull.Value.Equals(oRow["ChaveLivre1"]) ? oRow["ChaveLivre1"].ToString() : string.Empty;
	                oCliente.ChaveLivre2 = !DBNull.Value.Equals(oRow["ChaveLivre2"]) ? oRow["ChaveLivre2"].ToString() : string.Empty;
	                oCliente.AssinaNewsletter = !DBNull.Value.Equals(oRow["AssinaNewsletter"]) ? oRow["AssinaNewsletter"].ToString() : string.Empty;
	                oCliente.TipoNewsletter = !DBNull.Value.Equals(oRow["TipoNewsletter"]) ? oRow["TipoNewsletter"].ToString() : string.Empty;
	                oCliente.CreditoDinCC = !DBNull.Value.Equals(oRow["CreditoDinCC"]) ? oRow["CreditoDinCC"].ToString() : string.Empty;
	                oCliente.CreditoCheque = !DBNull.Value.Equals(oRow["CreditoCheque"]) ? oRow["CreditoCheque"].ToString() : string.Empty;
	                oCliente.CreditoOutros = !DBNull.Value.Equals(oRow["CreditoOutros"]) ? oRow["CreditoOutros"].ToString() : string.Empty;
	                oCliente.PotCres = !DBNull.Value.Equals(oRow["PotCres"]) ? oRow["PotCres"].ToString() : string.Empty;
	                oCliente.ValEstra = !DBNull.Value.Equals(oRow["ValEstra"]) ? oRow["ValEstra"].ToString() : string.Empty;
	                oCliente.ContaEBTA = !DBNull.Value.Equals(oRow["ContaEBTA"]) ? oRow["ContaEBTA"].ToString() : string.Empty;
	                oCliente.Fantasia = !DBNull.Value.Equals(oRow["Fantasia"]) ? oRow["Fantasia"].ToString() : string.Empty;
	                oCliente.Bairro = !DBNull.Value.Equals(oRow["Bairro"]) ? oRow["Bairro"].ToString() : string.Empty;
	                oCliente.TitularCartao1 = !DBNull.Value.Equals(oRow["TitularCartao1"]) ? oRow["TitularCartao1"].ToString() : string.Empty;
	                oCliente.TitularCartao2 = !DBNull.Value.Equals(oRow["TitularCartao2"]) ? oRow["TitularCartao2"].ToString() : string.Empty;
	                oCliente.TitularCartao3 = !DBNull.Value.Equals(oRow["TitularCartao3"]) ? oRow["TitularCartao3"].ToString() : string.Empty;
	                oCliente.CSCartao1 = !DBNull.Value.Equals(oRow["CSCartao1"]) ? oRow["CSCartao1"].ToString() : string.Empty;
	                oCliente.CSCartao2 = !DBNull.Value.Equals(oRow["CSCartao2"]) ? oRow["CSCartao2"].ToString() : string.Empty;
	                oCliente.CSCartao3 = !DBNull.Value.Equals(oRow["CSCartao3"]) ? oRow["CSCartao3"].ToString() : string.Empty;
	                oCliente.VlrTxBco = !DBNull.Value.Equals(oRow["VlrTxBco"]) ? Convert.ToDouble("0" + oRow["VlrTxBco"]) : 0;
	                oCliente.ContaCTA = !DBNull.Value.Equals(oRow["ContaCTA"]) ? oRow["ContaCTA"].ToString() : string.Empty;
	                oCliente.ContaVisa = !DBNull.Value.Equals(oRow["ContaVisa"]) ? oRow["ContaVisa"].ToString() : string.Empty;
	                oCliente.ObrigaCentroCusto = !DBNull.Value.Equals(oRow["ObrigaCentroCusto"]) ? oRow["ObrigaCentroCusto"].ToString() : string.Empty;
	                oCliente.ObrigaObservacao = !DBNull.Value.Equals(oRow["ObrigaObservacao"]) ? oRow["ObrigaObservacao"].ToString() : string.Empty;
	                oCliente.LimiteUnit = !DBNull.Value.Equals(oRow["LimiteUnit"]) ? Convert.ToDouble("0" + oRow["LimiteUnit"]) : 0;
	                oCliente.InscrMunicipal = !DBNull.Value.Equals(oRow["InscrMunicipal"]) ? oRow["InscrMunicipal"].ToString() : string.Empty;
	                oCliente.EMailNFSe = !DBNull.Value.Equals(oRow["EMailNFSe"]) ? oRow["EMailNFSe"].ToString() : string.Empty;
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
            return oCliente;
        }
        public Int32 ApplyRecord(Cliente_Fields oCliente, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //******************************
            //* Atualiza ou insere registro
            //******************************
            SQL = "REPLACE INTO clientes (";
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
            SQL += oCliente.PK_CodCli + ",";
            SQL += "'" + oCliente.Nome.SQLFilter() + "',";
            SQL += "'" + oCliente.LocalTrab.SQLFilter() + "',";
            SQL += oCliente.CodProf.ToString() + ",";
            SQL += oCliente.CodBco.ToString() + ",";
            SQL += oCliente.TipoCli.ToString() + ",";
            SQL += oCliente.SitCli.ToString() + ",";
            SQL += oCliente.PostoVen.ToString() + ",";
            SQL += oCliente.CodPromotor.ToString() + ",";
            SQL += "'" + oCliente.Titular.SQLFilter() + "',";
            SQL += "'" + oCliente.MneCli.SQLFilter() + "',";
            SQL += "'" + oCliente.LeiKandir.SQLFilter() + "',";
            SQL += "'" + oCliente.StatusCli.SQLFilter() + "',";
            SQL += oCliente.IndicePontosCli.ToDBNumeric(6) + ",";
            SQL += oCliente.PercentPontosCli.ToDBNumeric(6) + ",";
            SQL += oCliente.CodEmissor.ToString() + ",";
            SQL += oCliente.CodTerceiro.ToString() + ",";
            SQL += "'" + oCliente.GeraFatPDF.SQLFilter() + "',";
            SQL += oCliente.AgrupaCodCtbForn.ToString() + ",";
            SQL += oCliente.AgrupaTipoCobra.ToString() + ",";
            SQL += oCliente.AgrupaCatProd.ToString() + ",";
            SQL += oCliente.AgrupaProd.ToString() + ",";
            SQL += oCliente.AgrupaForn.ToString() + ",";
            SQL += oCliente.AgrupaCC.ToString() + ",";
            SQL += oCliente.AgrupaPax.ToString() + ",";
            SQL += oCliente.AgrupaReq.ToString() + ",";
            SQL += "'" + oCliente.PeriodoFatura.SQLFilter() + "',";
            SQL += oCliente.ItensFatura.ToString() + ",";
            SQL += oCliente.AgrupaReqCliente.ToString() + ",";
            SQL += "'" + oCliente.Contato.SQLFilter() + "',";
            SQL += "'" + oCliente.Sexo.SQLFilter() + "',";
            SQL += "'" + oCliente.EndRes.SQLFilter() + "',";
            SQL += "'" + oCliente.FoneRes.SQLFilter() + "',";
            SQL += "'" + oCliente.FaxRes.SQLFilter() + "',";
            SQL += oCliente.CodCidadeRes.ToString() + ",";
            SQL += "'" + oCliente.CEPRes.SQLFilter() + "',";
            SQL += oCliente.TempoRes.ToString() + ",";
            SQL += "'" + oCliente.Filiacao.SQLFilter() + "',";
            SQL += oCliente.DataNasc.ToDBDate() + ",";
            SQL += "'" + oCliente.CIC.SQLFilter() + "',";
            SQL += "'" + oCliente.RG.SQLFilter() + "',";
            SQL += "'" + oCliente.Orgao.SQLFilter() + "',";
            SQL += "'" + oCliente.RGUF.SQLFilter() + "',";
            SQL += "'" + oCliente.Nacionalidade.SQLFilter() + "',";
            SQL += "'" + oCliente.Naturalidade.SQLFilter() + "',";
            SQL += "'" + oCliente.InscrMunicipal.SQLFilter() + "',";
            SQL += "'" + oCliente.CGC.SQLFilter() + "',";
            SQL += "'" + oCliente.EstadoCivil.SQLFilter() + "',";
            SQL += "'" + oCliente.EMail.SQLFilter() + "',";
            SQL += "'" + oCliente.Passaporte.SQLFilter() + "',";
            SQL += oCliente.ValidPassaporte.ToDBDate() + ",";
            SQL += "'" + oCliente.NomeVisto1.SQLFilter() + "',";
            SQL += "'" + oCliente.NomeVisto2.SQLFilter() + "',";
            SQL += oCliente.ValidVisto1.ToDBDate() + ",";
            SQL += oCliente.ValidVisto2.ToDBDate() + ",";
            SQL += "'" + oCliente.EndTrab.SQLFilter() + "',";
            SQL += oCliente.CodCidadeTrab.ToString() + ",";
            SQL += "'" + oCliente.CEPTrab.SQLFilter() + "',";
            SQL += "'" + oCliente.FoneTrab.SQLFilter() + "',";
            SQL += "'" + oCliente.FaxTrab.SQLFilter() + "',";
            SQL += oCliente.TempoTrab.ToString() + ",";
            SQL += oCliente.Renda.ToDBNumeric(2) + ",";
            SQL += "'" + oCliente.RefCom.SQLFilter() + "',";
            SQL += "'" + oCliente.FoneRefCom.SQLFilter() + "',";
            SQL += "'" + oCliente.RefBco.SQLFilter() + "',";
            SQL += "'" + oCliente.FoneRefBco.SQLFilter() + "',";
            SQL += "'" + oCliente.Cia1.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCia1.SQLFilter() + "',";
            SQL += "'" + oCliente.Cia2.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCia2.SQLFilter() + "',";
            SQL += "'" + oCliente.Cia3.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCia3.SQLFilter() + "',";
            SQL += "'" + oCliente.Cia4.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCia4.SQLFilter() + "',";
            SQL += oCliente.DataCad.ToDBDate() + ",";
            SQL += "'" + oCliente.CodContabil.SQLFilter() + "',";
            SQL += "'" + oCliente.Fumante.SQLFilter() + "',";
            SQL += "'" + oCliente.Assento.SQLFilter() + "',";
            SQL += "'" + oCliente.EndCobr.SQLFilter() + "',";
            SQL += oCliente.CodCidadeCobr.ToString() + ",";
            SQL += "'" + oCliente.CEPCobr.SQLFilter() + "',";
            SQL += "'" + oCliente.EndCorresp.SQLFilter() + "',";
            SQL += "'" + oCliente.SitCredito.SQLFilter() + "',";
            SQL += "'" + oCliente.Observacoes.SQLFilter() + "',";
            SQL += "'" + oCliente.CartaoCred1.SQLFilter() + "',";
            SQL += "'" + oCliente.CartaoCred2.SQLFilter() + "',";
            SQL += "'" + oCliente.CartaoCred3.SQLFilter() + "',";
            SQL += "'" + oCliente.CartaoCred4.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCartao1.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCartao2.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCartao3.SQLFilter() + "',";
            SQL += "'" + oCliente.NroCartao4.SQLFilter() + "',";
            SQL += "'" + oCliente.ValidCartao1.SQLFilter() + "',";
            SQL += "'" + oCliente.ValidCartao2.SQLFilter() + "',";
            SQL += "'" + oCliente.ValidCartao3.SQLFilter() + "',";
            SQL += "'" + oCliente.ValidCartao4.SQLFilter() + "',";
            SQL += "'" + oCliente.TituloMala.SQLFilter() + "',";
            SQL += "'" + oCliente.TipoPessoa.SQLFilter() + "',";
            SQL += "'" + oCliente.VenctoCartao1.SQLFilter() + "',";
            SQL += "'" + oCliente.VenctoCartao2.SQLFilter() + "',";
            SQL += "'" + oCliente.VenctoCartao3.SQLFilter() + "',";
            SQL += "'" + oCliente.VenctoCartao4.SQLFilter() + "',";
            SQL += oCliente.DtUltimaAlteracao.ToDBDate() + ",";
            SQL += "'" + oCliente.UltimaAlteracaoPor.SQLFilter() + "',";
            SQL += oCliente.EmissVisto1.ToDBDate() + ",";
            SQL += oCliente.EmissVisto2.ToDBDate() + ",";
            SQL += "'" + oCliente.Funcao.SQLFilter() + "',";
            SQL += "'" + oCliente.ChaveLivre1.SQLFilter() + "',";
            SQL += "'" + oCliente.ChaveLivre2.SQLFilter() + "',";
            SQL += "'" + oCliente.AssinaNewsletter.SQLFilter() + "',";
            SQL += "'" + oCliente.TipoNewsletter.SQLFilter() + "',";
            SQL += "'" + oCliente.CreditoDinCC.SQLFilter() + "',";
            SQL += "'" + oCliente.CreditoCheque.SQLFilter() + "',";
            SQL += "'" + oCliente.CreditoOutros.SQLFilter() + "',";
            SQL += "'" + oCliente.PotCres.SQLFilter() + "',";
            SQL += "'" + oCliente.ValEstra.SQLFilter() + "',";
            SQL += "'" + oCliente.ContaEBTA.SQLFilter() + "',";
            SQL += "'" + oCliente.Fantasia.SQLFilter() + "',";
            SQL += "'" + oCliente.Bairro.SQLFilter() + "',";
            SQL += "'" + oCliente.TitularCartao1.SQLFilter() + "',";
            SQL += "'" + oCliente.TitularCartao2.SQLFilter() + "',";
            SQL += "'" + oCliente.TitularCartao3.SQLFilter() + "',";
            SQL += "'" + oCliente.CSCartao1.SQLFilter() + "',";
            SQL += "'" + oCliente.CSCartao2.SQLFilter() + "',";
            SQL += "'" + oCliente.CSCartao3.SQLFilter() + "',";
            SQL += oCliente.VlrTxBco.ToDBNumeric(6) + ",";
            SQL += "'" + oCliente.ContaCTA.SQLFilter() + "',";
            SQL += "'" + oCliente.ContaVisa.SQLFilter() + "',";
            SQL += "'" + oCliente.ObrigaCentroCusto.SQLFilter() + "',";
            SQL += "'" + oCliente.ObrigaObservacao.SQLFilter() + "',";
            SQL += oCliente.LimiteUnit.ToDBNumeric(2) + ",";
            SQL += "'" + oCliente.InscrMunicipal.SQLFilter() + "',";
            SQL += "'" + oCliente.EMailNFSe.SQLFilter() + "')";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oCliente.PK_CodCli = oDBManager.ExecuteCommand(SQL, Import);

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
            return oCliente.PK_CodCli;
        }
        public bool DeleteRecord(Cliente_Fields oCliente)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //********************************
            //* O código do cliente é válido?
            //********************************
            if (oCliente.PK_CodCli != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM clientes WHERE CodCli = " + oCliente.PK_CodCli;
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
                _ErrorText = "Informe o código do cliente.";
                _Error = true;
                return false;
            }
        }
    }
}
