using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Lista_Requesicoes_Fields
    {
        //*********************
        //* Variáveis privadas 
        //*********************
        private Int32 _NroProcesso = 0;
        private Int32 _NroRequis = 0;
        private string _Produto = string.Empty;
        private string _Pax = string.Empty;
        private DateTime? _DataIn = null;
        private DateTime? _DataOut = null;

        //*******************
        //* Campos da tabela 
        //*******************
        public Int32 NroProcesso { get { return _NroProcesso; } set { _NroProcesso = value; } }
        public Int32 NroRequis { get { return _NroRequis; } set { _NroRequis = value; } }
        public string Produto { get { return _Produto; } set { _Produto = value; } }
        public string Pax { get { return _Pax; } set { _Pax = value; } }
        public DateTime? DataIn { get { return _DataIn; } set { _DataIn = value; } }
        public DateTime? DataOut { get { return _DataOut; } set { _DataOut = value; } }

        //****************
        //* Inicialização
        //****************
        public Lista_Requesicoes_Fields()
        {
            _NroProcesso = 0;
            _NroRequis = 0;
            _Produto = string.Empty;
            _Pax = string.Empty;
            _DataIn = null;
            _DataOut = null;
        }
    }
    public class Requisicao_Fields
    {
        //*********************
        //* Variáveis privadas 
        //*********************
        private Int32 _NroRequis = 0;
        private DateTime? _Emissao = null;
        private string _Status = string.Empty;
        private string _Localizador = string.Empty;
        private Int32 _CodPosto = 0;
        private string _TipoVenda = string.Empty;
        private string _Moeda = string.Empty;
        private Int32 _CodProduto = 0;
        private Int32 _CodFornec = 0;
        private string _NroTkt = string.Empty;
        private string _SitTkt = string.Empty;
        private Int32 _CodCli = 0;
        private string _CentroCusto = string.Empty;
        private string _Pax = string.Empty;
        private string _Trecho = string.Empty;
        private string _Obs1 = string.Empty;
        private double _VlrTotal = 0;
        private double _VlrTaxas = 0;
        private double _VlrAdmin = 0;
        private double _VlrSinal = 0;
        private double _VlrDesc = 0;
        private double _VlrAcres = 0;
        private double _VlrEntrada = 0;
        private double _VlrCambio = 0;
        private string _FormaRecbto = string.Empty;
        private DateTime? _DtVencto = null;
        private Int32 _CodBco = 0;
        private Int32 _NroFatura = 0;
        private Int32 _NroRecibo = 0;
        private DateTime? _VenctoFornec = null;
        private string _CodIncent = string.Empty;
        private Int32 _CodAgencia = 0;
        private double _IndAgencia = 0;
        private string _BaseCalcAgencia = string.Empty;
        private double _ComissAgencia = 0;
        private double _ValComAgencia = 0;
        private string _CalcAgencia = string.Empty;
        private double _IncentAgencia = 0;
        private double _ValIncAgencia = 0;
        private Int32 _CodPromotor = 0;
        private double _IndPromotor = 0;
        private string _BaseCalcPromotor = string.Empty;
        private double _ComissPromotor = 0;
        private double _ValComPromotor = 0;
        private string _CalcPromotor = string.Empty;
        private double _IncentPromotor = 0;
        private double _ValIncPromotor = 0;
        private Int32 _CodEmissor = 0;
        private double _IndEmissor = 0;
        private string _BaseCalcEmissor = string.Empty;
        private double _ComissEmissor = 0;
        private double _ValComEmissor = 0;
        private string _CalcEmissor = string.Empty;
        private double _IncentEmissor = 0;
        private double _ValIncEmissor = 0;
        private double _IndFornec = 0;
        private double _ComissFornec = 0;
        private double _ValComFornec = 0;
        private string _CalcFornec = string.Empty;
        private double _IncentFornec = 0;
        private double _ValIncFornec = 0;
        private double _DescCli = 0;
        private double _IncentCli = 0;
        private double _ValIncCli = 0;
        private Int32 _NumOp = 0;
        private Int32 _NumVoucher = 0;
        private Int32 _CodAgrup = 0;
        private Int32 _CodEvento = 0;
        private Int32 _CodContaDestino = 0;
        private Int32 _CodContaOrigem = 0;
        private string _EmitiuFatura = string.Empty;
        private string _EmitiuRecibo = string.Empty;
        private string _EmitiuBloqueto = string.Empty;
        private DateTime? _DtQuitaFatura = null;
        private DateTime? _DtQuitaFornecedor = null;
        private string _Obs2 = string.Empty;
        private DateTime? _DtViagem = null;
        private string _MoedaRecebto = string.Empty;
        private DateTime? _DtRetorno = null;
        private string _AbateComissTer = string.Empty;
        private DateTime? _DataRecebe = null;
        private string _DescSobre = string.Empty;
        private double _IndicePontos = 0;
        private double _PercentPontos = 0;
        private double _QtdePontos = 0;
        private DateTime? _DtUltimaAlteracao = null;
        private string _UltimaAlteracaoPor = string.Empty;
        private string _NossaNF = string.Empty;
        private string _NrFaturaFornec = string.Empty;
        private string _NrDoctoFornec = string.Empty;
        private string _SitComisEmissor = string.Empty;
        private string _SitComisPromotor = string.Empty;
        private string _SitComisTerceiro = string.Empty;
        private double _VlrAcresFatCli = 0;
        private double _VlrISS = 0;
        private double _VlrIR = 0;
        private double _VlrCPMF = 0;
        private string _SituacaoRequisicao = string.Empty;
        private Int32 _CodCidadeReq = 0;
        private double _VlrTarifaCheia = 0;
        private DateTime? _DataFatura = null;
        private double _PercLeiKandir = 0;
        private double _VlrLeiKandirTarifa = 0;
        private double _VlrLeiKandirTaxa = 0;
        private DateTime? _DtEncaminha = null;
        private DateTime? _DtRecRetencao = null;
        private double _NroProcesso = 0;
        private string _BaseDesc = string.Empty;
        private double _PercLeiKandirTx = 0;
        private Int32 _CodConsolidador = 0;
        private string _AbateComissFor = string.Empty;
        private string _DoctoBaixa = string.Empty;
        private string _MoedaPagto = string.Empty;
        private double _VlrCambioPagto = 0;
        private Int32 _NumCotiza = 0;
        private double _VlrTxIntermedia = 0;
        private double _PercDesRepasse = 0;
        private double _VlrRepasse = 0;
        private DateTime? _DtLanctoReq = null;
        private double _VlrTxOutras = 0;
        private string _Obs3 = string.Empty;
        private string _NroProtocoloCli = string.Empty;
        private DateTime? _DataEncProtCli = null;
        private DateTime? _DataRecDarfCli = null;
        private string _NroCarta = string.Empty;
        private string _NossaNFCli = string.Empty;
        private double _QtdeProd = 0;
        private string _NrAutorizacao = string.Empty;

        //*******************
        //* Campos da tabela 
        //*******************
        public Int32 NroRequis { get { return _NroRequis; } set { _NroRequis = value; } }
        public DateTime? Emissao { get { return _Emissao; } set { _Emissao = value; } }
        public string Status { get { return _Status.Left(2); } set { _Status = value; } }
        public string Localizador { get { return _Localizador.Left(30); } set { _Localizador = value; } }
        public Int32 CodPosto { get { return _CodPosto; } set { _CodPosto = value; } }
        public string TipoVenda { get { return _TipoVenda.Left(1); } set { _TipoVenda = value; } }
        public string Moeda { get { return _Moeda.Left(1); } set { _Moeda = value; } }
        public Int32 CodProduto { get { return _CodProduto; } set { _CodProduto = value; } }
        public Int32 CodFornec { get { return _CodFornec; } set { _CodFornec = value; } }
        public string NroTkt { get { return _NroTkt.Left(13); } set { _NroTkt = value; } }
        public string SitTkt { get { return _SitTkt.Left(2); } set { _SitTkt = value; } }
        public Int32 CodCli { get { return _CodCli; } set { _CodCli = value; } }
        public string CentroCusto { get { return _CentroCusto.Left(35); } set { _CentroCusto = value; } }
        public string Pax { get { return _Pax.Left(76); } set { _Pax = value; } }
        public string Trecho { get { return _Trecho.Left(50); } set { _Trecho = value; } }
        public string Obs1 { get { return _Obs1.Left(50); } set { _Obs1 = value; } }
        public double VlrTotal { get { return _VlrTotal; } set { _VlrTotal = value; } }
        public double VlrTaxas { get { return _VlrTaxas; } set { _VlrTaxas = value; } }
        public double VlrAdmin { get { return _VlrAdmin; } set { _VlrAdmin = value; } }
        public double VlrSinal { get { return _VlrSinal; } set { _VlrSinal = value; } }
        public double VlrDesc { get { return _VlrDesc; } set { _VlrDesc = value; } }
        public double VlrAcres { get { return _VlrAcres; } set { _VlrAcres = value; } }
        public double VlrEntrada { get { return _VlrEntrada; } set { _VlrEntrada = value; } }
        public double VlrCambio { get { return _VlrCambio; } set { _VlrCambio = value; } }
        public string FormaRecbto { get { return _FormaRecbto.Left(1); } set { _FormaRecbto = value; } }
        public DateTime? DtVencto { get { return _DtVencto; } set { _DtVencto = value; } }
        public Int32 CodBco { get { return _CodBco; } set { _CodBco = value; } }
        public Int32 NroFatura { get { return _NroFatura; } set { _NroFatura = value; } }
        public Int32 NroRecibo { get { return _NroRecibo; } set { _NroRecibo = value; } }
        public DateTime? VenctoFornec { get { return _VenctoFornec; } set { _VenctoFornec = value; } }
        public string CodIncent { get { return _CodIncent.Left(6); } set { _CodIncent = value; } }
        public Int32 CodAgencia { get { return _CodAgencia; } set { _CodAgencia = value; } }
        public double IndAgencia { get { return _IndAgencia; } set { _IndAgencia = value; } }
        public string BaseCalcAgencia { get { return _BaseCalcAgencia.Left(1); } set { _BaseCalcAgencia = value; } }
        public double ComissAgencia { get { return _ComissAgencia; } set { _ComissAgencia = value; } }
        public double ValComAgencia { get { return _ValComAgencia; } set { _ValComAgencia = value; } }
        public string CalcAgencia { get { return _CalcAgencia.Left(1); } set { _CalcAgencia = value; } }
        public double IncentAgencia { get { return _IncentAgencia; } set { _IncentAgencia = value; } }
        public double ValIncAgencia { get { return _ValIncAgencia; } set { _ValIncAgencia = value; } }
        public Int32 CodPromotor { get { return _CodPromotor; } set { _CodPromotor = value; } }
        public double IndPromotor { get { return _IndPromotor; } set { _IndPromotor = value; } }
        public string BaseCalcPromotor { get { return _BaseCalcPromotor.Left(1); } set { _BaseCalcPromotor = value; } }
        public double ComissPromotor { get { return _ComissPromotor; } set { _ComissPromotor = value; } }
        public double ValComPromotor { get { return _ValComPromotor; } set { _ValComPromotor = value; } }
        public string CalcPromotor { get { return _CalcPromotor.Left(1); } set { _CalcPromotor = value; } }
        public double IncentPromotor { get { return _IncentPromotor; } set { _IncentPromotor = value; } }
        public double ValIncPromotor { get { return _ValIncPromotor; } set { _ValIncPromotor = value; } }
        public Int32 CodEmissor { get { return _CodEmissor; } set { _CodEmissor = value; } }
        public double IndEmissor { get { return _IndEmissor; } set { _IndEmissor = value; } }
        public string BaseCalcEmissor { get { return _BaseCalcEmissor.Left(1); } set { _BaseCalcEmissor = value; } }
        public double ComissEmissor { get { return _ComissEmissor; } set { _ComissEmissor = value; } }
        public double ValComEmissor { get { return _ValComEmissor; } set { _ValComEmissor = value; } }
        public string CalcEmissor { get { return _CalcEmissor.Left(1); } set { _CalcEmissor = value; } }
        public double IncentEmissor { get { return _IncentEmissor; } set { _IncentEmissor = value; } }
        public double ValIncEmissor { get { return _ValIncEmissor; } set { _ValIncEmissor = value; } }
        public double IndFornec { get { return _IndFornec; } set { _IndFornec = value; } }
        public double ComissFornec { get { return _ComissFornec; } set { _ComissFornec = value; } }
        public double ValComFornec { get { return _ValComFornec; } set { _ValComFornec = value; } }
        public string CalcFornec { get { return _CalcFornec.Left(1); } set { _CalcFornec = value; } }
        public double IncentFornec { get { return _IncentFornec; } set { _IncentFornec = value; } }
        public double ValIncFornec { get { return _ValIncFornec; } set { _ValIncFornec = value; } }
        public double DescCli { get { return _DescCli; } set { _DescCli = value; } }
        public double IncentCli { get { return _IncentCli; } set { _IncentCli = value; } }
        public double ValIncCli { get { return _ValIncCli; } set { _ValIncCli = value; } }
        public Int32 NumOp { get { return _NumOp; } set { _NumOp = value; } }
        public Int32 NumVoucher { get { return _NumVoucher; } set { _NumVoucher = value; } }
        public Int32 CodAgrup { get { return _CodAgrup; } set { _CodAgrup = value; } }
        public Int32 CodEvento { get { return _CodEvento; } set { _CodEvento = value; } }
        public Int32 CodContaDestino { get { return _CodContaDestino; } set { _CodContaDestino = value; } }
        public Int32 CodContaOrigem { get { return _CodContaOrigem; } set { _CodContaOrigem = value; } }
        public string EmitiuFatura { get { return _EmitiuFatura.Left(1); } set { _EmitiuFatura = value; } }
        public string EmitiuRecibo { get { return _EmitiuRecibo.Left(1); } set { _EmitiuRecibo = value; } }
        public string EmitiuBloqueto { get { return _EmitiuBloqueto.Left(1); } set { _EmitiuBloqueto = value; } }
        public DateTime? DtQuitaFatura { get { return _DtQuitaFatura; } set { _DtQuitaFatura = value; } }
        public DateTime? DtQuitaFornecedor { get { return _DtQuitaFornecedor; } set { _DtQuitaFornecedor = value; } }
        public string Obs2 { get { return _Obs2; } set { _Obs2 = value; } }
        public DateTime? DtViagem { get { return _DtViagem; } set { _DtViagem = value; } }
        public string MoedaRecebto { get { return _MoedaRecebto.Left(1); } set { _MoedaRecebto = value; } }
        public DateTime? DtRetorno { get { return _DtRetorno; } set { _DtRetorno = value; } }
        public string AbateComissTer { get { return _AbateComissTer.Left(1); } set { _AbateComissTer = value; } }
        public DateTime? DataRecebe { get { return _DataRecebe; } set { _DataRecebe = value; } }
        public string DescSobre { get { return _DescSobre.Left(1); } set { _DescSobre = value; } }
        public double IndicePontos { get { return _IndicePontos; } set { _IndicePontos = value; } }
        public double PercentPontos { get { return _PercentPontos; } set { _PercentPontos = value; } }
        public double QtdePontos { get { return _QtdePontos; } set { _QtdePontos = value; } }
        public DateTime? DtUltimaAlteracao { get { return _DtUltimaAlteracao; } set { _DtUltimaAlteracao = value; } }
        public string UltimaAlteracaoPor { get { return _UltimaAlteracaoPor.Left(20); } set { _UltimaAlteracaoPor = value; } }
        public string NossaNF { get { return _NossaNF.Left(15); } set { _NossaNF = value; } }
        public string NrFaturaFornec { get { return _NrFaturaFornec.Left(8); } set { _NrFaturaFornec = value; } }
        public string NrDoctoFornec { get { return _NrDoctoFornec.Left(8); } set { _NrDoctoFornec = value; } }
        public string SitComisEmissor { get { return _SitComisEmissor.Left(3); } set { _SitComisEmissor = value; } }
        public string SitComisPromotor { get { return _SitComisPromotor.Left(3); } set { _SitComisPromotor = value; } }
        public string SitComisTerceiro { get { return _SitComisTerceiro.Left(3); } set { _SitComisTerceiro = value; } }
        public double VlrAcresFatCli { get { return _VlrAcresFatCli; } set { _VlrAcresFatCli = value; } }
        public double VlrISS { get { return _VlrISS; } set { _VlrISS = value; } }
        public double VlrIR { get { return _VlrIR; } set { _VlrIR = value; } }
        public double VlrCPMF { get { return _VlrCPMF; } set { _VlrCPMF = value; } }
        public string SituacaoRequisicao { get { return _SituacaoRequisicao.Left(1); } set { _SituacaoRequisicao = value; } }
        public Int32 CodCidadeReq { get { return _CodCidadeReq; } set { _CodCidadeReq = value; } }
        public double VlrTarifaCheia { get { return _VlrTarifaCheia; } set { _VlrTarifaCheia = value; } }
        public DateTime? DataFatura { get { return _DataFatura; } set { _DataFatura = value; } }
        public double PercLeiKandir { get { return _PercLeiKandir; } set { _PercLeiKandir = value; } }
        public double VlrLeiKandirTarifa { get { return _VlrLeiKandirTarifa; } set { _VlrLeiKandirTarifa = value; } }
        public double VlrLeiKandirTaxa { get { return _VlrLeiKandirTaxa; } set { _VlrLeiKandirTaxa = value; } }
        public DateTime? DtEncaminha { get { return _DtEncaminha; } set { _DtEncaminha = value; } }
        public DateTime? DtRecRetencao { get { return _DtRecRetencao; } set { _DtRecRetencao = value; } }
        public double NroProcesso { get { return _NroProcesso; } set { _NroProcesso = value; } }
        public string BaseDesc { get { return _BaseDesc.Left(1); } set { _BaseDesc = value; } }
        public double PercLeiKandirTx { get { return _PercLeiKandirTx; } set { _PercLeiKandirTx = value; } }
        public Int32 CodConsolidador { get { return _CodConsolidador; } set { _CodConsolidador = value; } }
        public string AbateComissFor { get { return _AbateComissFor.Left(1); } set { _AbateComissFor = value; } }
        public string DoctoBaixa { get { return _DoctoBaixa.Left(15); } set { _DoctoBaixa = value; } }
        public string MoedaPagto { get { return _MoedaPagto.Left(1); } set { _MoedaPagto = value; } }
        public double VlrCambioPagto { get { return _VlrCambioPagto; } set { _VlrCambioPagto = value; } }
        public Int32 NumCotiza { get { return _NumCotiza; } set { _NumCotiza = value; } }
        public double VlrTxIntermedia { get { return _VlrTxIntermedia; } set { _VlrTxIntermedia = value; } }
        public double PercDesRepasse { get { return _PercDesRepasse; } set { _PercDesRepasse = value; } }
        public double VlrRepasse { get { return _VlrRepasse; } set { _VlrRepasse = value; } }
        public DateTime? DtLanctoReq { get { return _DtLanctoReq; } set { _DtLanctoReq = value; } }
        public double VlrTxOutras { get { return _VlrTxOutras; } set { _VlrTxOutras = value; } }
        public string Obs3 { get { return _Obs3; } set { _Obs3 = value; } }
        public string NroProtocoloCli { get { return _NroProtocoloCli.Left(20); } set { _NroProtocoloCli = value; } }
        public DateTime? DataEncProtCli { get { return _DataEncProtCli; } set { _DataEncProtCli = value; } }
        public DateTime? DataRecDarfCli { get { return _DataRecDarfCli; } set { _DataRecDarfCli = value; } }
        public string NroCarta { get { return _NroCarta.Left(20); } set { _NroCarta = value; } }
        public string NossaNFCli { get { return _NossaNFCli.Left(15); } set { _NossaNFCli = value; } }
        public double QtdeProd { get { return _QtdeProd; } set { _QtdeProd = value; } }
        public string NrAutorizacao { get { return _NrAutorizacao.Left(50); } set { _NrAutorizacao = value; } }
        public Requisicao_Fields()
        {
            //****************
            //* Inicialização 
            //****************
            _NroRequis = 0;
            _Emissao = null;
            _Status = string.Empty;
            _Localizador = string.Empty;
            _CodPosto = 0;
            _TipoVenda = string.Empty;
            _Moeda = string.Empty;
            _CodProduto = 0;
            _CodFornec = 0;
            _NroTkt = string.Empty;
            _SitTkt = string.Empty;
            _CodCli = 0;
            _CentroCusto = string.Empty;
            _Pax = string.Empty;
            _Trecho = string.Empty;
            _Obs1 = string.Empty;
            _VlrTotal = 0;
            _VlrTaxas = 0;
            _VlrAdmin = 0;
            _VlrSinal = 0;
            _VlrDesc = 0;
            _VlrAcres = 0;
            _VlrEntrada = 0;
            _VlrCambio = 0;
            _FormaRecbto = string.Empty;
            _DtVencto = null;
            _CodBco = 0;
            _NroFatura = 0;
            _NroRecibo = 0;
            _VenctoFornec = null;
            _CodIncent = string.Empty;
            _CodAgencia = 0;
            _IndAgencia = 0;
            _BaseCalcAgencia = string.Empty;
            _ComissAgencia = 0;
            _ValComAgencia = 0;
            _CalcAgencia = string.Empty;
            _IncentAgencia = 0;
            _ValIncAgencia = 0;
            _CodPromotor = 0;
            _IndPromotor = 0;
            _BaseCalcPromotor = string.Empty;
            _ComissPromotor = 0;
            _ValComPromotor = 0;
            _CalcPromotor = string.Empty;
            _IncentPromotor = 0;
            _ValIncPromotor = 0;
            _CodEmissor = 0;
            _IndEmissor = 0;
            _BaseCalcEmissor = string.Empty;
            _ComissEmissor = 0;
            _ValComEmissor = 0;
            _CalcEmissor = string.Empty;
            _IncentEmissor = 0;
            _ValIncEmissor = 0;
            _IndFornec = 0;
            _ComissFornec = 0;
            _ValComFornec = 0;
            _CalcFornec = string.Empty;
            _IncentFornec = 0;
            _ValIncFornec = 0;
            _DescCli = 0;
            _IncentCli = 0;
            _ValIncCli = 0;
            _NumOp = 0;
            _NumVoucher = 0;
            _CodAgrup = 0;
            _CodEvento = 0;
            _CodContaDestino = 0;
            _CodContaOrigem = 0;
            _EmitiuFatura = string.Empty;
            _EmitiuRecibo = string.Empty;
            _EmitiuBloqueto = string.Empty;
            _DtQuitaFatura = null;
            _DtQuitaFornecedor = null;
            _Obs2 = string.Empty;
            _DtViagem = null;
            _MoedaRecebto = string.Empty;
            _DtRetorno = null;
            _AbateComissTer = string.Empty;
            _DataRecebe = null;
            _DescSobre = string.Empty;
            _IndicePontos = 0;
            _PercentPontos = 0;
            _QtdePontos = 0;
            _DtUltimaAlteracao = null;
            _UltimaAlteracaoPor = string.Empty;
            _NossaNF = string.Empty;
            _NrFaturaFornec = string.Empty;
            _NrDoctoFornec = string.Empty;
            _SitComisEmissor = string.Empty;
            _SitComisPromotor = string.Empty;
            _SitComisTerceiro = string.Empty;
            _VlrAcresFatCli = 0;
            _VlrISS = 0;
            _VlrIR = 0;
            _VlrCPMF = 0;
            _SituacaoRequisicao = string.Empty;
            _CodCidadeReq = 0;
            _VlrTarifaCheia = 0;
            _DataFatura = null;
            _PercLeiKandir = 0;
            _VlrLeiKandirTarifa = 0;
            _VlrLeiKandirTaxa = 0;
            _DtEncaminha = null;
            _DtRecRetencao = null;
            _NroProcesso = 0;
            _BaseDesc = string.Empty;
            _PercLeiKandirTx = 0;
            _CodConsolidador = 0;
            _AbateComissFor = string.Empty;
            _DoctoBaixa = string.Empty;
            _MoedaPagto = string.Empty;
            _VlrCambioPagto = 0;
            _NumCotiza = 0;
            _VlrTxIntermedia = 0;
            _PercDesRepasse = 0;
            _VlrRepasse = 0;
            _DtLanctoReq = null;
            _VlrTxOutras = 0;
            _Obs3 = string.Empty;
            _NroProtocoloCli = string.Empty;
            _DataEncProtCli = null;
            _DataRecDarfCli = null;
            _NroCarta = string.Empty;
            _NossaNFCli = string.Empty;
            _QtdeProd = 0;
            _NrAutorizacao = string.Empty;
        }
    }
    public class Requisicao_Manager
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
        public Requisicao_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão 
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Int32 ApplyRecord(Requisicao_Fields oRequisicao_Fields)
        {
            //**************
            //* Declarações 
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //******************************
            //* Atualiza ou insere registro 
            //******************************
            SQL = "REPLACE INTO requisicao (";
            SQL += "NroRequis,";
            SQL += "Emissao,";
            SQL += "Status,";
            SQL += "Localizador,";
            SQL += "CodPosto,";
            SQL += "TipoVenda,";
            SQL += "Moeda,";
            SQL += "CodProduto,";
            SQL += "CodFornec,";
            SQL += "NroTkt,";
            SQL += "SitTkt,";
            SQL += "CodCli,";
            SQL += "CentroCusto,";
            SQL += "Pax,";
            SQL += "Trecho,";
            SQL += "Obs1,";
            SQL += "VlrTotal,";
            SQL += "VlrTaxas,";
            SQL += "VlrAdmin,";
            SQL += "VlrSinal,";
            SQL += "VlrDesc,";
            SQL += "VlrAcres,";
            SQL += "VlrEntrada,";
            SQL += "VlrCambio,";
            SQL += "FormaRecbto,";
            SQL += "DtVencto,";
            SQL += "CodBco,";
            SQL += "NroFatura,";
            SQL += "NroRecibo,";
            SQL += "VenctoFornec,";
            SQL += "CodIncent,";
            SQL += "CodAgencia,";
            SQL += "IndAgencia,";
            SQL += "BaseCalcAgencia,";
            SQL += "ComissAgencia,";
            SQL += "ValComAgencia,";
            SQL += "CalcAgencia,";
            SQL += "IncentAgencia,";
            SQL += "ValIncAgencia,";
            SQL += "CodPromotor,";
            SQL += "IndPromotor,";
            SQL += "BaseCalcPromotor,";
            SQL += "ComissPromotor,";
            SQL += "ValComPromotor,";
            SQL += "CalcPromotor,";
            SQL += "IncentPromotor,";
            SQL += "ValIncPromotor,";
            SQL += "CodEmissor,";
            SQL += "IndEmissor,";
            SQL += "BaseCalcEmissor,";
            SQL += "ComissEmissor,";
            SQL += "ValComEmissor,";
            SQL += "CalcEmissor,";
            SQL += "IncentEmissor,";
            SQL += "ValIncEmissor,";
            SQL += "IndFornec,";
            SQL += "ComissFornec,";
            SQL += "ValComFornec,";
            SQL += "CalcFornec,";
            SQL += "IncentFornec,";
            SQL += "ValIncFornec,";
            SQL += "DescCli,";
            SQL += "IncentCli,";
            SQL += "ValIncCli,";
            SQL += "NumOp,";
            SQL += "NumVoucher,";
            SQL += "CodAgrup,";
            SQL += "CodEvento,";
            SQL += "CodContaDestino,";
            SQL += "CodContaOrigem,";
            SQL += "EmitiuFatura,";
            SQL += "EmitiuRecibo,";
            SQL += "EmitiuBloqueto,";
            SQL += "DtQuitaFatura,";
            SQL += "DtQuitaFornecedor,";
            SQL += "Obs2,";
            SQL += "DtViagem,";
            SQL += "MoedaRecebto,";
            SQL += "DtRetorno,";
            SQL += "AbateComissTer,";
            SQL += "DataRecebe,";
            SQL += "DescSobre,";
            SQL += "IndicePontos,";
            SQL += "PercentPontos,";
            SQL += "QtdePontos,";
            SQL += "DtUltimaAlteracao,";
            SQL += "UltimaAlteracaoPor,";
            SQL += "NossaNF,";
            SQL += "NrFaturaFornec,";
            SQL += "NrDoctoFornec,";
            SQL += "SitComisEmissor,";
            SQL += "SitComisPromotor,";
            SQL += "SitComisTerceiro,";
            SQL += "VlrAcresFatCli,";
            SQL += "VlrISS,";
            SQL += "VlrIR,";
            SQL += "VlrCPMF,";
            SQL += "SituacaoRequisicao,";
            SQL += "CodCidadeReq,";
            SQL += "VlrTarifaCheia,";
            SQL += "DataFatura,";
            SQL += "PercLeiKandir,";
            SQL += "VlrLeiKandirTarifa,";
            SQL += "VlrLeiKandirTaxa,";
            SQL += "DtEncaminha,";
            SQL += "DtRecRetencao,";
            SQL += "NroProcesso,";
            SQL += "BaseDesc,";
            SQL += "PercLeiKandirTx,";
            SQL += "CodConsolidador,";
            SQL += "AbateComissFor,";
            SQL += "DoctoBaixa,";
            SQL += "MoedaPagto,";
            SQL += "VlrCambioPagto,";
            SQL += "NumCotiza,";
            SQL += "VlrTxIntermedia,";
            SQL += "PercDesRepasse,";
            SQL += "VlrRepasse,";
            SQL += "DtLanctoReq,";
            SQL += "VlrTxOutras,";
            SQL += "Obs3,";
            SQL += "NroProtocoloCli,";
            SQL += "DataEncProtCli,";
            SQL += "DataRecDarfCli,";
            SQL += "NroCarta,";
            SQL += "NossaNFCli,";
            SQL += "QtdeProd,";
            SQL += "NrAutorizacao";
            SQL += ") VALUES (";
            SQL += oRequisicao_Fields.NroRequis.ToString() + ",";
            SQL += oRequisicao_Fields.Emissao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.Status.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Localizador.ToString() + "',";
            SQL += oRequisicao_Fields.CodPosto.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.TipoVenda.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Moeda.ToString() + "',";
            SQL += oRequisicao_Fields.CodProduto.ToString() + ",";
            SQL += oRequisicao_Fields.CodFornec.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.NroTkt.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitTkt.ToString() + "',";
            SQL += oRequisicao_Fields.CodCli.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.CentroCusto.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Pax.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Trecho.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Obs1.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrTotal.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrTaxas.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrAdmin.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrSinal.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrDesc.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrAcres.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrEntrada.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrCambio.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.FormaRecbto.ToString() + "',";
            SQL += oRequisicao_Fields.DtVencto.ToDBDate() + ",";
            SQL += oRequisicao_Fields.CodBco.ToString() + ",";
            SQL += oRequisicao_Fields.NroFatura.ToString() + ",";
            SQL += oRequisicao_Fields.NroRecibo.ToString() + ",";
            SQL += oRequisicao_Fields.VenctoFornec.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.CodIncent.ToString() + "',";
            SQL += oRequisicao_Fields.CodAgencia.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcAgencia.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcAgencia.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncAgencia.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodPromotor.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncPromotor.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodEmissor.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.IndFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ComissFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.DescCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.IncentCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncCli.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.NumOp.ToString() + ",";
            SQL += oRequisicao_Fields.NumVoucher.ToString() + ",";
            SQL += oRequisicao_Fields.CodAgrup.ToString() + ",";
            SQL += oRequisicao_Fields.CodEvento.ToString() + ",";
            SQL += oRequisicao_Fields.CodContaDestino.ToString() + ",";
            SQL += oRequisicao_Fields.CodContaOrigem.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.EmitiuFatura.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.EmitiuRecibo.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.EmitiuBloqueto.ToString() + "',";
            SQL += oRequisicao_Fields.DtQuitaFatura.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DtQuitaFornecedor.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.Obs2.ToString() + "',";
            SQL += oRequisicao_Fields.DtViagem.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.MoedaRecebto.ToString() + "',";
            SQL += oRequisicao_Fields.DtRetorno.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.AbateComissTer.ToString() + "',";
            SQL += oRequisicao_Fields.DataRecebe.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.DescSobre.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IndicePontos.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.PercentPontos.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.QtdePontos.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtUltimaAlteracao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.UltimaAlteracaoPor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NossaNF.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NrFaturaFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NrDoctoFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisTerceiro.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrAcresFatCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrISS.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrIR.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrCPMF.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.SituacaoRequisicao.ToString() + "',";
            SQL += oRequisicao_Fields.CodCidadeReq.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTarifaCheia.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DataFatura.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.PercLeiKandir.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrLeiKandirTarifa.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrLeiKandirTaxa.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtEncaminha.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DtRecRetencao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.NroProcesso.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseDesc.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.PercLeiKandirTx.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodConsolidador.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.AbateComissFor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.DoctoBaixa.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.MoedaPagto.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrCambioPagto.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.NumCotiza.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTxIntermedia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.PercDesRepasse.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrRepasse.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtLanctoReq.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTxOutras.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.Obs3.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NroProtocoloCli.ToString() + "',";
            SQL += oRequisicao_Fields.DataEncProtCli.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DataRecDarfCli.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.NroCarta.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NossaNFCli.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.QtdeProd.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.NrAutorizacao.ToString() + "',";
            SQL += oRequisicao_Fields.NroRequis.ToString() + ",";
            SQL += oRequisicao_Fields.Emissao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.Status.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Localizador.ToString() + "',";
            SQL += oRequisicao_Fields.CodPosto.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.TipoVenda.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Moeda.ToString() + "',";
            SQL += oRequisicao_Fields.CodProduto.ToString() + ",";
            SQL += oRequisicao_Fields.CodFornec.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.NroTkt.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitTkt.ToString() + "',";
            SQL += oRequisicao_Fields.CodCli.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.CentroCusto.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Pax.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Trecho.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.Obs1.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrTotal.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrTaxas.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrAdmin.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrSinal.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrDesc.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrAcres.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrEntrada.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrCambio.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.FormaRecbto.ToString() + "',";
            SQL += oRequisicao_Fields.DtVencto.ToDBDate() + ",";
            SQL += oRequisicao_Fields.CodBco.ToString() + ",";
            SQL += oRequisicao_Fields.NroFatura.ToString() + ",";
            SQL += oRequisicao_Fields.NroRecibo.ToString() + ",";
            SQL += oRequisicao_Fields.VenctoFornec.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.CodIncent.ToString() + "',";
            SQL += oRequisicao_Fields.CodAgencia.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcAgencia.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcAgencia.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentAgencia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncAgencia.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodPromotor.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentPromotor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncPromotor.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodEmissor.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.IndEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseCalcEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.ComissEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncEmissor.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.IndFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ComissFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValComFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.CalcFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IncentFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncFornec.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.DescCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.IncentCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.ValIncCli.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.NumOp.ToString() + ",";
            SQL += oRequisicao_Fields.NumVoucher.ToString() + ",";
            SQL += oRequisicao_Fields.CodAgrup.ToString() + ",";
            SQL += oRequisicao_Fields.CodEvento.ToString() + ",";
            SQL += oRequisicao_Fields.CodContaDestino.ToString() + ",";
            SQL += oRequisicao_Fields.CodContaOrigem.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.EmitiuFatura.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.EmitiuRecibo.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.EmitiuBloqueto.ToString() + "',";
            SQL += oRequisicao_Fields.DtQuitaFatura.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DtQuitaFornecedor.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.Obs2.ToString() + "',";
            SQL += oRequisicao_Fields.DtViagem.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.MoedaRecebto.ToString() + "',";
            SQL += oRequisicao_Fields.DtRetorno.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.AbateComissTer.ToString() + "',";
            SQL += oRequisicao_Fields.DataRecebe.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.DescSobre.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.IndicePontos.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.PercentPontos.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.QtdePontos.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtUltimaAlteracao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.UltimaAlteracaoPor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NossaNF.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NrFaturaFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NrDoctoFornec.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisEmissor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisPromotor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.SitComisTerceiro.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrAcresFatCli.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrISS.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrIR.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrCPMF.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.SituacaoRequisicao.ToString() + "',";
            SQL += oRequisicao_Fields.CodCidadeReq.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTarifaCheia.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DataFatura.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.PercLeiKandir.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrLeiKandirTarifa.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrLeiKandirTaxa.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtEncaminha.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DtRecRetencao.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.NroProcesso.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.BaseDesc.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.PercLeiKandirTx.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.CodConsolidador.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.AbateComissFor.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.DoctoBaixa.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.MoedaPagto.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.VlrCambioPagto.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.NumCotiza.ToString() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTxIntermedia.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.PercDesRepasse.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.VlrRepasse.ToDBNumeric(6) + ",";
            SQL += oRequisicao_Fields.DtLanctoReq.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.VlrTxOutras.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.Obs3.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NroProtocoloCli.ToString() + "',";
            SQL += oRequisicao_Fields.DataEncProtCli.ToDBDate() + ",";
            SQL += oRequisicao_Fields.DataRecDarfCli.ToDBDate() + ",";
            SQL += "'" + oRequisicao_Fields.NroCarta.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.NossaNFCli.ToString() + "',";
            SQL += "'" + oRequisicao_Fields.QtdeProd.ToDBNumeric(6) + ",";
            SQL += "'" + oRequisicao_Fields.NrAutorizacao.ToString() + "'" + ")";

            //****************************
            //* Controla erro de execução 
            //****************************
            try
            {
                //**************************
                //* Executa comando formado 
                //**************************
                oRequisicao_Fields.NroRequis = oDBManager.ExecuteCommand(SQL);

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
            return oRequisicao_Fields.NroRequis;
        }
        public Requisicao_Fields GetRecord(Int32 NroRequis)
        {
            //**************
            //* Declarações 
            //**************
            Requisicao_Fields oRequisicao_Fields = new Requisicao_Fields();
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
                SQL = "SELECT * FROM requisicao WHERE NroRequis = " + NroRequis.ToString();
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
                //**********************************
                //* A pesquisa localizou o registro? 
                //***********************************
                if (oTable.Rows.Count == 1)
                {
                    //*******************************
                    //* Copia dados para a estrutura 
                    //*******************************
                    DataRow oRow = oTable.Rows[0];
                    oRequisicao_Fields.NroRequis = !DBNull.Value.Equals(oRow["NroRequis"]) ? Convert.ToInt32("0" + oRow["NroRequis"]) : 0;
                    if (!DBNull.Value.Equals(oRow["Emissao"]))
                        oRequisicao_Fields.Emissao = Convert.ToDateTime(oRow["Emissao"]);
                    oRequisicao_Fields.Status = !DBNull.Value.Equals(oRow["Status"]) ? oRow["Status"].ToString() : string.Empty;
                    oRequisicao_Fields.Localizador = !DBNull.Value.Equals(oRow["Localizador"]) ? oRow["Localizador"].ToString() : string.Empty;
                    oRequisicao_Fields.CodPosto = !DBNull.Value.Equals(oRow["CodPosto"]) ? Convert.ToInt32("0" + oRow["CodPosto"]) : 0;
                    oRequisicao_Fields.TipoVenda = !DBNull.Value.Equals(oRow["TipoVenda"]) ? oRow["TipoVenda"].ToString() : string.Empty;
                    oRequisicao_Fields.Moeda = !DBNull.Value.Equals(oRow["Moeda"]) ? oRow["Moeda"].ToString() : string.Empty;
                    oRequisicao_Fields.CodProduto = !DBNull.Value.Equals(oRow["CodProduto"]) ? Convert.ToInt32("0" + oRow["CodProduto"]) : 0;
                    oRequisicao_Fields.CodFornec = !DBNull.Value.Equals(oRow["CodFornec"]) ? Convert.ToInt32("0" + oRow["CodFornec"]) : 0;
                    oRequisicao_Fields.NroTkt = !DBNull.Value.Equals(oRow["NroTkt"]) ? oRow["NroTkt"].ToString() : string.Empty;
                    oRequisicao_Fields.SitTkt = !DBNull.Value.Equals(oRow["SitTkt"]) ? oRow["SitTkt"].ToString() : string.Empty;
                    oRequisicao_Fields.CodCli = !DBNull.Value.Equals(oRow["CodCli"]) ? Convert.ToInt32("0" + oRow["CodCli"]) : 0;
                    oRequisicao_Fields.CentroCusto = !DBNull.Value.Equals(oRow["CentroCusto"]) ? oRow["CentroCusto"].ToString() : string.Empty;
                    oRequisicao_Fields.Pax = !DBNull.Value.Equals(oRow["Pax"]) ? oRow["Pax"].ToString() : string.Empty;
                    oRequisicao_Fields.Trecho = !DBNull.Value.Equals(oRow["Trecho"]) ? oRow["Trecho"].ToString() : string.Empty;
                    oRequisicao_Fields.Obs1 = !DBNull.Value.Equals(oRow["Obs1"]) ? oRow["Obs1"].ToString() : string.Empty;
                    oRequisicao_Fields.VlrTotal = !DBNull.Value.Equals(oRow["VlrTotal"]) ? Convert.ToDouble("0" + oRow["VlrTotal"]) : 0;
                    oRequisicao_Fields.VlrTaxas = !DBNull.Value.Equals(oRow["VlrTaxas"]) ? Convert.ToDouble("0" + oRow["VlrTaxas"]) : 0;
                    oRequisicao_Fields.VlrAdmin = !DBNull.Value.Equals(oRow["VlrAdmin"]) ? Convert.ToDouble("0" + oRow["VlrAdmin"]) : 0;
                    oRequisicao_Fields.VlrSinal = !DBNull.Value.Equals(oRow["VlrSinal"]) ? Convert.ToDouble("0" + oRow["VlrSinal"]) : 0;
                    oRequisicao_Fields.VlrDesc = !DBNull.Value.Equals(oRow["VlrDesc"]) ? Convert.ToDouble("0" + oRow["VlrDesc"]) : 0;
                    oRequisicao_Fields.VlrAcres = !DBNull.Value.Equals(oRow["VlrAcres"]) ? Convert.ToDouble("0" + oRow["VlrAcres"]) : 0;
                    oRequisicao_Fields.VlrEntrada = !DBNull.Value.Equals(oRow["VlrEntrada"]) ? Convert.ToDouble("0" + oRow["VlrEntrada"]) : 0;
                    oRequisicao_Fields.VlrCambio = !DBNull.Value.Equals(oRow["VlrCambio"]) ? Convert.ToDouble("0" + oRow["VlrCambio"]) : 0;
                    oRequisicao_Fields.FormaRecbto = !DBNull.Value.Equals(oRow["FormaRecbto"]) ? oRow["FormaRecbto"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DtVencto"]))
                        oRequisicao_Fields.DtVencto = Convert.ToDateTime(oRow["DtVencto"]);
                    oRequisicao_Fields.CodBco = !DBNull.Value.Equals(oRow["CodBco"]) ? Convert.ToInt32("0" + oRow["CodBco"]) : 0;
                    oRequisicao_Fields.NroFatura = !DBNull.Value.Equals(oRow["NroFatura"]) ? Convert.ToInt32("0" + oRow["NroFatura"]) : 0;
                    oRequisicao_Fields.NroRecibo = !DBNull.Value.Equals(oRow["NroRecibo"]) ? Convert.ToInt32("0" + oRow["NroRecibo"]) : 0;
                    if (!DBNull.Value.Equals(oRow["VenctoFornec"]))
                        oRequisicao_Fields.VenctoFornec = Convert.ToDateTime(oRow["VenctoFornec"]);
                    oRequisicao_Fields.CodIncent = !DBNull.Value.Equals(oRow["CodIncent"]) ? oRow["CodIncent"].ToString() : string.Empty;
                    oRequisicao_Fields.CodAgencia = !DBNull.Value.Equals(oRow["CodAgencia"]) ? Convert.ToInt32("0" + oRow["CodAgencia"]) : 0;
                    oRequisicao_Fields.IndAgencia = !DBNull.Value.Equals(oRow["IndAgencia"]) ? Convert.ToDouble("0" + oRow["IndAgencia"]) : 0;
                    oRequisicao_Fields.BaseCalcAgencia = !DBNull.Value.Equals(oRow["BaseCalcAgencia"]) ? oRow["BaseCalcAgencia"].ToString() : string.Empty;
                    oRequisicao_Fields.ComissAgencia = !DBNull.Value.Equals(oRow["ComissAgencia"]) ? Convert.ToDouble("0" + oRow["ComissAgencia"]) : 0;
                    oRequisicao_Fields.ValComAgencia = !DBNull.Value.Equals(oRow["ValComAgencia"]) ? Convert.ToDouble("0" + oRow["ValComAgencia"]) : 0;
                    oRequisicao_Fields.CalcAgencia = !DBNull.Value.Equals(oRow["CalcAgencia"]) ? oRow["CalcAgencia"].ToString() : string.Empty;
                    oRequisicao_Fields.IncentAgencia = !DBNull.Value.Equals(oRow["IncentAgencia"]) ? Convert.ToDouble("0" + oRow["IncentAgencia"]) : 0;
                    oRequisicao_Fields.ValIncAgencia = !DBNull.Value.Equals(oRow["ValIncAgencia"]) ? Convert.ToDouble("0" + oRow["ValIncAgencia"]) : 0;
                    oRequisicao_Fields.CodPromotor = !DBNull.Value.Equals(oRow["CodPromotor"]) ? Convert.ToInt32("0" + oRow["CodPromotor"]) : 0;
                    oRequisicao_Fields.IndPromotor = !DBNull.Value.Equals(oRow["IndPromotor"]) ? Convert.ToDouble("0" + oRow["IndPromotor"]) : 0;
                    oRequisicao_Fields.BaseCalcPromotor = !DBNull.Value.Equals(oRow["BaseCalcPromotor"]) ? oRow["BaseCalcPromotor"].ToString() : string.Empty;
                    oRequisicao_Fields.ComissPromotor = !DBNull.Value.Equals(oRow["ComissPromotor"]) ? Convert.ToDouble("0" + oRow["ComissPromotor"]) : 0;
                    oRequisicao_Fields.ValComPromotor = !DBNull.Value.Equals(oRow["ValComPromotor"]) ? Convert.ToDouble("0" + oRow["ValComPromotor"]) : 0;
                    oRequisicao_Fields.CalcPromotor = !DBNull.Value.Equals(oRow["CalcPromotor"]) ? oRow["CalcPromotor"].ToString() : string.Empty;
                    oRequisicao_Fields.IncentPromotor = !DBNull.Value.Equals(oRow["IncentPromotor"]) ? Convert.ToDouble("0" + oRow["IncentPromotor"]) : 0;
                    oRequisicao_Fields.ValIncPromotor = !DBNull.Value.Equals(oRow["ValIncPromotor"]) ? Convert.ToDouble("0" + oRow["ValIncPromotor"]) : 0;
                    oRequisicao_Fields.CodEmissor = !DBNull.Value.Equals(oRow["CodEmissor"]) ? Convert.ToInt32("0" + oRow["CodEmissor"]) : 0;
                    oRequisicao_Fields.IndEmissor = !DBNull.Value.Equals(oRow["IndEmissor"]) ? Convert.ToDouble("0" + oRow["IndEmissor"]) : 0;
                    oRequisicao_Fields.BaseCalcEmissor = !DBNull.Value.Equals(oRow["BaseCalcEmissor"]) ? oRow["BaseCalcEmissor"].ToString() : string.Empty;
                    oRequisicao_Fields.ComissEmissor = !DBNull.Value.Equals(oRow["ComissEmissor"]) ? Convert.ToDouble("0" + oRow["ComissEmissor"]) : 0;
                    oRequisicao_Fields.ValComEmissor = !DBNull.Value.Equals(oRow["ValComEmissor"]) ? Convert.ToDouble("0" + oRow["ValComEmissor"]) : 0;
                    oRequisicao_Fields.CalcEmissor = !DBNull.Value.Equals(oRow["CalcEmissor"]) ? oRow["CalcEmissor"].ToString() : string.Empty;
                    oRequisicao_Fields.IncentEmissor = !DBNull.Value.Equals(oRow["IncentEmissor"]) ? Convert.ToDouble("0" + oRow["IncentEmissor"]) : 0;
                    oRequisicao_Fields.ValIncEmissor = !DBNull.Value.Equals(oRow["ValIncEmissor"]) ? Convert.ToDouble("0" + oRow["ValIncEmissor"]) : 0;
                    oRequisicao_Fields.IndFornec = !DBNull.Value.Equals(oRow["IndFornec"]) ? Convert.ToDouble("0" + oRow["IndFornec"]) : 0;
                    oRequisicao_Fields.ComissFornec = !DBNull.Value.Equals(oRow["ComissFornec"]) ? Convert.ToDouble("0" + oRow["ComissFornec"]) : 0;
                    oRequisicao_Fields.ValComFornec = !DBNull.Value.Equals(oRow["ValComFornec"]) ? Convert.ToDouble("0" + oRow["ValComFornec"]) : 0;
                    oRequisicao_Fields.CalcFornec = !DBNull.Value.Equals(oRow["CalcFornec"]) ? oRow["CalcFornec"].ToString() : string.Empty;
                    oRequisicao_Fields.IncentFornec = !DBNull.Value.Equals(oRow["IncentFornec"]) ? Convert.ToDouble("0" + oRow["IncentFornec"]) : 0;
                    oRequisicao_Fields.ValIncFornec = !DBNull.Value.Equals(oRow["ValIncFornec"]) ? Convert.ToDouble("0" + oRow["ValIncFornec"]) : 0;
                    oRequisicao_Fields.DescCli = !DBNull.Value.Equals(oRow["DescCli"]) ? Convert.ToDouble("0" + oRow["DescCli"]) : 0;
                    oRequisicao_Fields.IncentCli = !DBNull.Value.Equals(oRow["IncentCli"]) ? Convert.ToDouble("0" + oRow["IncentCli"]) : 0;
                    oRequisicao_Fields.ValIncCli = !DBNull.Value.Equals(oRow["ValIncCli"]) ? Convert.ToDouble("0" + oRow["ValIncCli"]) : 0;
                    oRequisicao_Fields.NumOp = !DBNull.Value.Equals(oRow["NumOp"]) ? Convert.ToInt32("0" + oRow["NumOp"]) : 0;
                    oRequisicao_Fields.NumVoucher = !DBNull.Value.Equals(oRow["NumVoucher"]) ? Convert.ToInt32("0" + oRow["NumVoucher"]) : 0;
                    oRequisicao_Fields.CodAgrup = !DBNull.Value.Equals(oRow["CodAgrup"]) ? Convert.ToInt32("0" + oRow["CodAgrup"]) : 0;
                    oRequisicao_Fields.CodEvento = !DBNull.Value.Equals(oRow["CodEvento"]) ? Convert.ToInt32("0" + oRow["CodEvento"]) : 0;
                    oRequisicao_Fields.CodContaDestino = !DBNull.Value.Equals(oRow["CodContaDestino"]) ? Convert.ToInt32("0" + oRow["CodContaDestino"]) : 0;
                    oRequisicao_Fields.CodContaOrigem = !DBNull.Value.Equals(oRow["CodContaOrigem"]) ? Convert.ToInt32("0" + oRow["CodContaOrigem"]) : 0;
                    oRequisicao_Fields.EmitiuFatura = !DBNull.Value.Equals(oRow["EmitiuFatura"]) ? oRow["EmitiuFatura"].ToString() : string.Empty;
                    oRequisicao_Fields.EmitiuRecibo = !DBNull.Value.Equals(oRow["EmitiuRecibo"]) ? oRow["EmitiuRecibo"].ToString() : string.Empty;
                    oRequisicao_Fields.EmitiuBloqueto = !DBNull.Value.Equals(oRow["EmitiuBloqueto"]) ? oRow["EmitiuBloqueto"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DtQuitaFatura"]))
                        oRequisicao_Fields.DtQuitaFatura = Convert.ToDateTime(oRow["DtQuitaFatura"]);
                    if (!DBNull.Value.Equals(oRow["DtQuitaFornecedor"]))
                        oRequisicao_Fields.DtQuitaFornecedor = Convert.ToDateTime(oRow["DtQuitaFornecedor"]);
                    oRequisicao_Fields.Obs2 = !DBNull.Value.Equals(oRow["Obs2"]) ? oRow["Obs2"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DtViagem"]))
                        oRequisicao_Fields.DtViagem = Convert.ToDateTime(oRow["DtViagem"]);
                    oRequisicao_Fields.MoedaRecebto = !DBNull.Value.Equals(oRow["MoedaRecebto"]) ? oRow["MoedaRecebto"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DtRetorno"]))
                        oRequisicao_Fields.DtRetorno = Convert.ToDateTime(oRow["DtRetorno"]);
                    oRequisicao_Fields.AbateComissTer = !DBNull.Value.Equals(oRow["AbateComissTer"]) ? oRow["AbateComissTer"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DataRecebe"]))
                        oRequisicao_Fields.DataRecebe = Convert.ToDateTime(oRow["DataRecebe"]);
                    oRequisicao_Fields.DescSobre = !DBNull.Value.Equals(oRow["DescSobre"]) ? oRow["DescSobre"].ToString() : string.Empty;
                    oRequisicao_Fields.IndicePontos = !DBNull.Value.Equals(oRow["IndicePontos"]) ? Convert.ToDouble("0" + oRow["IndicePontos"]) : 0;
                    oRequisicao_Fields.PercentPontos = !DBNull.Value.Equals(oRow["PercentPontos"]) ? Convert.ToDouble("0" + oRow["PercentPontos"]) : 0;
                    oRequisicao_Fields.QtdePontos = !DBNull.Value.Equals(oRow["QtdePontos"]) ? Convert.ToDouble("0" + oRow["QtdePontos"]) : 0;
                    if (!DBNull.Value.Equals(oRow["DtUltimaAlteracao"]))
                        oRequisicao_Fields.DtUltimaAlteracao = Convert.ToDateTime(oRow["DtUltimaAlteracao"]);
                    oRequisicao_Fields.UltimaAlteracaoPor = !DBNull.Value.Equals(oRow["UltimaAlteracaoPor"]) ? oRow["UltimaAlteracaoPor"].ToString() : string.Empty;
                    oRequisicao_Fields.NossaNF = !DBNull.Value.Equals(oRow["NossaNF"]) ? oRow["NossaNF"].ToString() : string.Empty;
                    oRequisicao_Fields.NrFaturaFornec = !DBNull.Value.Equals(oRow["NrFaturaFornec"]) ? oRow["NrFaturaFornec"].ToString() : string.Empty;
                    oRequisicao_Fields.NrDoctoFornec = !DBNull.Value.Equals(oRow["NrDoctoFornec"]) ? oRow["NrDoctoFornec"].ToString() : string.Empty;
                    oRequisicao_Fields.SitComisEmissor = !DBNull.Value.Equals(oRow["SitComisEmissor"]) ? oRow["SitComisEmissor"].ToString() : string.Empty;
                    oRequisicao_Fields.SitComisPromotor = !DBNull.Value.Equals(oRow["SitComisPromotor"]) ? oRow["SitComisPromotor"].ToString() : string.Empty;
                    oRequisicao_Fields.SitComisTerceiro = !DBNull.Value.Equals(oRow["SitComisTerceiro"]) ? oRow["SitComisTerceiro"].ToString() : string.Empty;
                    oRequisicao_Fields.VlrAcresFatCli = !DBNull.Value.Equals(oRow["VlrAcresFatCli"]) ? Convert.ToDouble("0" + oRow["VlrAcresFatCli"]) : 0;
                    oRequisicao_Fields.VlrISS = !DBNull.Value.Equals(oRow["VlrISS"]) ? Convert.ToDouble("0" + oRow["VlrISS"]) : 0;
                    oRequisicao_Fields.VlrIR = !DBNull.Value.Equals(oRow["VlrIR"]) ? Convert.ToDouble("0" + oRow["VlrIR"]) : 0;
                    oRequisicao_Fields.VlrCPMF = !DBNull.Value.Equals(oRow["VlrCPMF"]) ? Convert.ToDouble("0" + oRow["VlrCPMF"]) : 0;
                    oRequisicao_Fields.SituacaoRequisicao = !DBNull.Value.Equals(oRow["SituacaoRequisicao"]) ? oRow["SituacaoRequisicao"].ToString() : string.Empty;
                    oRequisicao_Fields.CodCidadeReq = !DBNull.Value.Equals(oRow["CodCidadeReq"]) ? Convert.ToInt32("0" + oRow["CodCidadeReq"]) : 0;
                    oRequisicao_Fields.VlrTarifaCheia = !DBNull.Value.Equals(oRow["VlrTarifaCheia"]) ? Convert.ToDouble("0" + oRow["VlrTarifaCheia"]) : 0;
                    if (!DBNull.Value.Equals(oRow["DataFatura"]))
                        oRequisicao_Fields.DataFatura = Convert.ToDateTime(oRow["DataFatura"]);
                    oRequisicao_Fields.PercLeiKandir = !DBNull.Value.Equals(oRow["PercLeiKandir"]) ? Convert.ToDouble("0" + oRow["PercLeiKandir"]) : 0;
                    oRequisicao_Fields.VlrLeiKandirTarifa = !DBNull.Value.Equals(oRow["VlrLeiKandirTarifa"]) ? Convert.ToDouble("0" + oRow["VlrLeiKandirTarifa"]) : 0;
                    oRequisicao_Fields.VlrLeiKandirTaxa = !DBNull.Value.Equals(oRow["VlrLeiKandirTaxa"]) ? Convert.ToDouble("0" + oRow["VlrLeiKandirTaxa"]) : 0;
                    if (!DBNull.Value.Equals(oRow["DtEncaminha"]))
                        oRequisicao_Fields.DtEncaminha = Convert.ToDateTime(oRow["DtEncaminha"]);
                    if (!DBNull.Value.Equals(oRow["DtRecRetencao"]))
                        oRequisicao_Fields.DtRecRetencao = Convert.ToDateTime(oRow["DtRecRetencao"]);
                    oRequisicao_Fields.NroProcesso = !DBNull.Value.Equals(oRow["NroProcesso"]) ? Convert.ToDouble("0" + oRow["NroProcesso"]) : 0;
                    oRequisicao_Fields.BaseDesc = !DBNull.Value.Equals(oRow["BaseDesc"]) ? oRow["BaseDesc"].ToString() : string.Empty;
                    oRequisicao_Fields.PercLeiKandirTx = !DBNull.Value.Equals(oRow["PercLeiKandirTx"]) ? Convert.ToDouble("0" + oRow["PercLeiKandirTx"]) : 0;
                    oRequisicao_Fields.CodConsolidador = !DBNull.Value.Equals(oRow["CodConsolidador"]) ? Convert.ToInt32("0" + oRow["CodConsolidador"]) : 0;
                    oRequisicao_Fields.AbateComissFor = !DBNull.Value.Equals(oRow["AbateComissFor"]) ? oRow["AbateComissFor"].ToString() : string.Empty;
                    oRequisicao_Fields.DoctoBaixa = !DBNull.Value.Equals(oRow["DoctoBaixa"]) ? oRow["DoctoBaixa"].ToString() : string.Empty;
                    oRequisicao_Fields.MoedaPagto = !DBNull.Value.Equals(oRow["MoedaPagto"]) ? oRow["MoedaPagto"].ToString() : string.Empty;
                    oRequisicao_Fields.VlrCambioPagto = !DBNull.Value.Equals(oRow["VlrCambioPagto"]) ? Convert.ToDouble("0" + oRow["VlrCambioPagto"]) : 0;
                    oRequisicao_Fields.NumCotiza = !DBNull.Value.Equals(oRow["NumCotiza"]) ? Convert.ToInt32("0" + oRow["NumCotiza"]) : 0;
                    oRequisicao_Fields.VlrTxIntermedia = !DBNull.Value.Equals(oRow["VlrTxIntermedia"]) ? Convert.ToDouble("0" + oRow["VlrTxIntermedia"]) : 0;
                    oRequisicao_Fields.PercDesRepasse = !DBNull.Value.Equals(oRow["PercDesRepasse"]) ? Convert.ToDouble("0" + oRow["PercDesRepasse"]) : 0;
                    oRequisicao_Fields.VlrRepasse = !DBNull.Value.Equals(oRow["VlrRepasse"]) ? Convert.ToDouble("0" + oRow["VlrRepasse"]) : 0;
                    if (!DBNull.Value.Equals(oRow["DtLanctoReq"]))
                        oRequisicao_Fields.DtLanctoReq = Convert.ToDateTime(oRow["DtLanctoReq"]);
                    oRequisicao_Fields.VlrTxOutras = !DBNull.Value.Equals(oRow["VlrTxOutras"]) ? Convert.ToDouble("0" + oRow["VlrTxOutras"]) : 0;
                    oRequisicao_Fields.Obs3 = !DBNull.Value.Equals(oRow["Obs3"]) ? oRow["Obs3"].ToString() : string.Empty;
                    oRequisicao_Fields.NroProtocoloCli = !DBNull.Value.Equals(oRow["NroProtocoloCli"]) ? oRow["NroProtocoloCli"].ToString() : string.Empty;
                    if (!DBNull.Value.Equals(oRow["DataEncProtCli"]))
                        oRequisicao_Fields.DataEncProtCli = Convert.ToDateTime(oRow["DataEncProtCli"]);
                    if (!DBNull.Value.Equals(oRow["DataRecDarfCli"]))
                        oRequisicao_Fields.DataRecDarfCli = Convert.ToDateTime(oRow["DataRecDarfCli"]);
                    oRequisicao_Fields.NroCarta = !DBNull.Value.Equals(oRow["NroCarta"]) ? oRow["NroCarta"].ToString() : string.Empty;
                    oRequisicao_Fields.NossaNFCli = !DBNull.Value.Equals(oRow["NossaNFCli"]) ? oRow["NossaNFCli"].ToString() : string.Empty;
                    oRequisicao_Fields.QtdeProd = !DBNull.Value.Equals(oRow["QtdeProd"]) ? Convert.ToDouble("0" + oRow["QtdeProd"]) : 0;
                    oRequisicao_Fields.NrAutorizacao = !DBNull.Value.Equals(oRow["NrAutorizacao"]) ? oRow["NrAutorizacao"].ToString() : string.Empty;
                }
                else
                {
                    //************************************
                    //* Devolve status e mensagem de erro 
                    //************************************
                    _ErrorText = "O resultado da pesquisa retornou nulo";
                    _Error = true;
                }
            }

            //****************
            //* Retorna dados 
            //****************
            return oRequisicao_Fields;
        }
        public bool DeleteRecord(Int32 NroRequis)
        {
            //**************
            //* Declarações 
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //********************************
            //* O código do cliente é válido?
            //********************************
            try
            {
                //******************
                //* Exclui registro 
                //******************
                SQL = "DELETE FROM requisicao WHERE NroRequis = " + NroRequis.ToString();
                oDBManager.ExecuteCommand(SQL);

                //************************************
                //* Devolve status e mensagem de erro 
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;
                return true;
            }
            catch (Exception oException)
            {
                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oException.Message;
                _Error = true;
                return false;
            }
        }
        public List<Lista_Requesicoes_Fields> GetReqsFromProcess(Int32 NroProcess)
        {
            //**************
            //* Declarações 
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            List<Lista_Requesicoes_Fields> oRequisicoes = new List<Lista_Requesicoes_Fields>();
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
                SQL = "SELECT ";
                SQL += "requisicao.nroprocesso,";
                SQL += "requisicao.nrorequis,";
                SQL += "requisicao.pax AS pax,";
                SQL += "produtos.descprod AS produto,";
                SQL += "requisicao.dtviagem AS datain,";
                SQL += "requisicao.dtretorno AS dataout ";
                SQL += "FROM requisicao ";
                SQL += "LEFT JOIN produtos ON produtos.codprod = requisicao.codproduto ";
                SQL += "WHERE nroprocesso = " + NroProcess.ToString();
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

            //****************************
            //* A pesquisa retornou nula? 
            //****************************
            if (oTable != null)
            {
                //*********************************
                //* A pesquisa retornou registros? 
                //*********************************
                if (oTable.Rows.Count > 0)
                {
                    //**********************************
                    //* A pesquisa localizou o registro? 
                    //***********************************
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        //**************
                        //* Monta lista
                        //**************
                        Lista_Requesicoes_Fields oRequisicao = new Lista_Requesicoes_Fields();
                        oRequisicao.NroProcesso = Convert.ToInt32(oRow["NroProcesso"]);
                        oRequisicao.NroRequis = Convert.ToInt32(oRow["NroRequis"]);
                        oRequisicao.Pax = oRow["Pax"].ToString();
                        oRequisicao.Produto = oRow["Produto"].ToString();
                        oRequisicao.DataIn = (DateTime?)oRow["DataIn"];
                        oRequisicao.DataOut = (DateTime?)oRow["DataOut"];
                        oRequisicoes.Add(oRequisicao);
                    }
                }
                else
                {
                    //************************************
                    //* Devolve status e mensagem de erro 
                    //************************************
                    _ErrorText = "Zero registros retornados";
                    _Error = true;
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
            return oRequisicoes;
        }
    }
}
