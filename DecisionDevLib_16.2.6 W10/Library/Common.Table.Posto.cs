using System;
using System.IO;
using System.Text;
using System.Data;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Posto_Fields
    {
        //*********************
        //* Variáveis privadas
        //*********************
        private Int32 _PK_PostoVen = 0;
        private string __NomeCidade = string.Empty;
        private string __UF = string.Empty;
        private Int32 _CodCidade = 0;
        private string _DescPosto = string.Empty;
        private string _End = string.Empty;
        private string _CEP = string.Empty;
        private string _Fone1 = string.Empty;
        private string _Fone2 = string.Empty;
        private string _Fax = string.Empty;
        private string _EMail = string.Empty;
        private string _NomePosto = string.Empty;
        private string _CGC = string.Empty;
        private string _InscrMun = string.Empty;
        private string _Embratur = string.Empty;
        private string _Iata = string.Empty;
        private string _HTTP = string.Empty;
        private string _RestringeContas = string.Empty;
        private byte[] _LogoTipo = { };
        private string _CodEmpIntCtb = string.Empty;
        private double _UltimaNFPosto = 0;
        private double _UltimaFaturaPosto = 0;
        private double _UltimReciboPosto = 0;
        private double _UltimaNFPostoFreta = 0;
        private string _OmiteNroNFRodape = string.Empty;
        private Int32 _CodEmpNfe = 0;
        private string _ChavePrivadaNfe = string.Empty;
        private string _ChaveAcessoNfe = string.Empty;
        private Int32 _RegimeEspTributa = 0;
        private Int32 _OptanteSimplesNac = 0;
        private Int32 _TributoMunicipio = 0;
        private string _SerieRPS = string.Empty;
        private string _TipoRPS = string.Empty;
        private Int32 _NaturezaOperacao = 0;
        private Int32 _IncentivadorCultural = 0;
        private double _AliquotaISS = 0;
        private Int32 _CNAE = 0;

        //*******************
        //* Campos da tabela
        //*******************
        public Int32 PK_PostoVen { get { return _PK_PostoVen; } set { _PK_PostoVen = value; } }
        public string _NomeCidade { get { return __NomeCidade.Left(30); } set { __NomeCidade = value; } }
        public string _UF { get { return __UF.Left(30); } set { __UF = value; } }
        public Int32 CodCidade { get { return _CodCidade; } set { _CodCidade = value; } }
        public string DescPosto { get { return _DescPosto.Left(30); } set { _DescPosto = value; }  }
        public string End { get { return _End.Left(40); } set { _End = value; }  }
        public string CEP { get { return _CEP.Left(9); } set { _CEP = value; }  }
        public string Fone1 { get { return _Fone1.Left(20); } set { _Fone1 = value; }  }
        public string Fone2 { get { return _Fone2.Left(30); } set { _Fone2 = value; }  }
        public string Fax { get { return _Fax.Left(20); } set { _Fax = value; }  }
        public string EMail { get { return _EMail.Left(60); } set { _EMail = value; }  }
        public string NomePosto { get { return _NomePosto.Left(120); } set { _NomePosto = value; }  }
        public string CGC { get { return _CGC.Left(14); } set { _CGC = value; }  }
        public string InscrMun { get { return _InscrMun.Left(20); } set { _InscrMun = value; }  }
        public string Embratur { get { return _Embratur.Left(30); } set { _Embratur = value; }  }
        public string Iata { get { return _Iata.Left(9); } set { _Iata = value; }  }
        public string HTTP { get { return _HTTP.Left(60); } set { _HTTP = value; } }
        public string RestringeContas { get { return _RestringeContas.Left(90); } set { _RestringeContas = value; } }
        public byte[] LogoTipo { get { return _LogoTipo; } set { _LogoTipo = value; } }
        public string CodEmpIntCtb { get { return _CodEmpIntCtb.Left(10); } set { _CodEmpIntCtb = value; } }
        public double UltimaNFPosto { get { return _UltimaNFPosto; } set { _UltimaNFPosto = value; } }
        public double UltimaFaturaPosto { get { return _UltimaFaturaPosto; } set { _UltimaFaturaPosto = value; } }
        public double UltimReciboPosto { get { return _UltimReciboPosto; } set { _UltimReciboPosto = value; } }
        public double UltimaNFPostoFreta { get { return _UltimaNFPostoFreta; } set { _UltimaNFPostoFreta = value; } }
        public string OmiteNroNFRodape { get { return _OmiteNroNFRodape.Left(1); } set { _OmiteNroNFRodape = value; } }
        public Int32 CodEmpNfe { get { return _CodEmpNfe; } set { _CodEmpNfe = value; } }
	    public string ChavePrivadaNfe { get { return _ChavePrivadaNfe.Left(200); } set { _ChavePrivadaNfe = value; } }
        public string ChaveAcessoNfe { get { return _ChaveAcessoNfe.Left(200); } set { _ChaveAcessoNfe = value; } }
        public Int32 RegimeEspTributa { get { return _RegimeEspTributa; } set { _RegimeEspTributa = value; } }
        public Int32 OptanteSimplesNac { get { return _OptanteSimplesNac; } set { _OptanteSimplesNac = value; } }
        public Int32 TributoMunicipio { get { return _TributoMunicipio; } set { _TributoMunicipio = value; } }
        public string SerieRPS { get { return _SerieRPS.Left(10); } set { _SerieRPS = value; } }
        public string TipoRPS { get { return _TipoRPS.Left(10); } set { _TipoRPS = value; } }
        public Int32 NaturezaOperacao { get { return _NaturezaOperacao; } set { _NaturezaOperacao = value; } }
        public Int32 IncentivadorCultural { get { return _IncentivadorCultural; } set { _IncentivadorCultural = value; } }
        public double AliquotaISS { get { return _AliquotaISS; } set { _AliquotaISS = value; } }
        public Int32 CNAE { get { return _CNAE; } set { _CNAE = value; } }
        public Posto_Fields()
        {
            //****************
            //* Inicialização
            //****************
	        _PK_PostoVen = 0;
            __NomeCidade = string.Empty;
            __UF = string.Empty;
            _CodCidade = 0;
            _DescPosto = string.Empty;
            _End = string.Empty;
            _CEP = string.Empty;
            _Fone1 = string.Empty;
            _Fone2 = string.Empty;
            _Fax = string.Empty;
            _EMail = string.Empty;
            _NomePosto = string.Empty;
            _CGC = string.Empty;
            _InscrMun = string.Empty;
            _Embratur = string.Empty;
            _Iata = string.Empty;
            _HTTP = string.Empty;
            _RestringeContas = string.Empty;
            _LogoTipo = new byte[0];
            _CodEmpIntCtb = string.Empty;
            _UltimaNFPosto = 0;
            _UltimaFaturaPosto = 0;
            _UltimReciboPosto = 0;
            _UltimaNFPostoFreta = 0;
            _OmiteNroNFRodape = string.Empty;
            _CodEmpNfe = 0;
            _ChavePrivadaNfe = string.Empty;
            _ChaveAcessoNfe = string.Empty;
            _RegimeEspTributa = 0;
            _OptanteSimplesNac = 0;
            _TributoMunicipio = 0;
            _SerieRPS = string.Empty;
            _TipoRPS = string.Empty;
            _NaturezaOperacao = 0;
            _IncentivadorCultural = 0;
            _AliquotaISS = 0;
            _CNAE = 0;
        }
    }
    public class Posto_Manager
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
        public Posto_Manager(string DBConnectionString)
        {
            //*****************
            //* Define conexão
            //*****************
            _ConnectionString = DBConnectionString;
        }
        public Posto_Fields Get_Posto(Int32 PostoVen)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            Posto_Fields oPosto = new Posto_Fields();
            DataRow oRow;

            //*******************
            //* Proteção de erro
            //*******************
            try
            {
                //**************************
                //* Obtem posto pelo código
                //**************************
                string SQL = "SELECT posto.*,cidade.nomecidade, cidade.uf FROM posto ";
                SQL += "LEFT JOIN cidade ON posto.codcidade = cidade.codcidade ";
                SQL += "WHERE postoven = " + PostoVen;
                DataTable oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //***********************************
                //* Devolve resultado nulo como erro
                //***********************************
                if (oTable != null)
                {
                    //*****************************
                    //* O registro foi localizado?
                    //*****************************
                    if (oTable.Rows.Count == 1)
                    {
                        oRow = oTable.Rows[0];
                        oPosto.PK_PostoVen = !DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0;
                        oPosto.CodCidade = !DBNull.Value.Equals(oRow["codcidade"]) ? Convert.ToInt32("0" + oRow["codcidade"]) : 0;
                        oPosto._NomeCidade = !DBNull.Value.Equals(oRow["nomecidade"]) ? oRow["nomecidade"].ToString() : string.Empty;
                        oPosto._UF = !DBNull.Value.Equals(oRow["uf"]) ? oRow["uf"].ToString() : string.Empty;
                        oPosto.DescPosto = !DBNull.Value.Equals(oRow["descposto"]) ? oRow["descposto"].ToString() : string.Empty;
                        oPosto.End = !DBNull.Value.Equals(oRow["end"]) ? oRow["end"].ToString() : string.Empty;
                        oPosto.CEP = !DBNull.Value.Equals(oRow["cep"]) ? oRow["cep"].ToString() : string.Empty;
                        oPosto.Fone1 = !DBNull.Value.Equals(oRow["fone1"]) ? oRow["fone1"].ToString() : string.Empty;
                        oPosto.Fone2 = !DBNull.Value.Equals(oRow["fone2"]) ? oRow["fone2"].ToString() : string.Empty;
                        oPosto.Fax = !DBNull.Value.Equals(oRow["fax"]) ? oRow["fax"].ToString() : string.Empty;
                        oPosto.EMail = !DBNull.Value.Equals(oRow["email"]) ? oRow["email"].ToString() : string.Empty;
                        oPosto.NomePosto = !DBNull.Value.Equals(oRow["nomeposto"]) ? oRow["nomeposto"].ToString() : string.Empty;
                        oPosto.CGC = !DBNull.Value.Equals(oRow["cgc"]) ? oRow["cgc"].ToString() : string.Empty;
                        oPosto.InscrMun = !DBNull.Value.Equals(oRow["inscrmun"]) ? oRow["inscrmun"].ToString() : string.Empty;
                        oPosto.Embratur = !DBNull.Value.Equals(oRow["embratur"]) ? oRow["embratur"].ToString() : string.Empty;
                        oPosto.Iata = !DBNull.Value.Equals(oRow["iata"]) ? oRow["iata"].ToString() : string.Empty;
                        oPosto.HTTP = !DBNull.Value.Equals(oRow["http"]) ? oRow["http"].ToString() : string.Empty;
                        oPosto.RestringeContas = !DBNull.Value.Equals(oRow["restringecontas"]) ? oRow["restringecontas"].ToString() : string.Empty;
                        oPosto.LogoTipo = GetPicture(!DBNull.Value.Equals(oRow["postoven"]) ? Convert.ToInt32("0" + oRow["postoven"]) : 0);
                        oPosto.CodEmpIntCtb = !DBNull.Value.Equals(oRow["codempintctb"]) ? oRow["codempintctb"].ToString() : string.Empty;
                        oPosto.UltimaNFPosto = !DBNull.Value.Equals(oRow["ultimanfposto"]) ? Convert.ToInt32("0" + oRow["ultimanfposto"]) : 0;
                        oPosto.UltimaFaturaPosto = !DBNull.Value.Equals(oRow["ultimafaturaposto"]) ? Convert.ToInt32("0" + oRow["ultimafaturaposto"]) : 0;
                        oPosto.UltimReciboPosto = !DBNull.Value.Equals(oRow["ultimreciboposto"]) ? Convert.ToInt32("0" + oRow["ultimreciboposto"]) : 0;
                        oPosto.UltimaNFPostoFreta = !DBNull.Value.Equals(oRow["ultimanfpostofreta"]) ? Convert.ToInt32("0" + oRow["ultimanfpostofreta"]) : 0;
                        oPosto.OmiteNroNFRodape = !DBNull.Value.Equals(oRow["omitenronfrodape"]) ? oRow["omitenronfrodape"].ToString() : string.Empty;
                        oPosto.CodEmpNfe = !DBNull.Value.Equals(oRow["codempnfe"]) ? Convert.ToInt32("0" + oRow["codempnfe"]) : 0;
                        oPosto.ChavePrivadaNfe = !DBNull.Value.Equals(oRow["chaveprivadanfe"]) ? oRow["chaveprivadanfe"].ToString() : string.Empty;
                        oPosto.ChaveAcessoNfe = !DBNull.Value.Equals(oRow["chaveacessonfe"]) ? oRow["chaveacessonfe"].ToString() : string.Empty;
                        oPosto.RegimeEspTributa = !DBNull.Value.Equals(oRow["regimeesptributa"]) ? Convert.ToInt32("0" + oRow["regimeesptributa"]) : 0;
                        oPosto.OptanteSimplesNac = !DBNull.Value.Equals(oRow["optantesimplesnac"]) ? Convert.ToInt32("0" + oRow["optantesimplesnac"]) : 0;
                        oPosto.TributoMunicipio = !DBNull.Value.Equals(oRow["tributomunicipio"]) ? Convert.ToInt32("0" + oRow["tributomunicipio"]) : 0;
                        oPosto.SerieRPS = !DBNull.Value.Equals(oRow["serierps"]) ? oRow["serierps"].ToString() : string.Empty;
                        oPosto.TipoRPS = !DBNull.Value.Equals(oRow["tiporps"]) ? oRow["tiporps"].ToString() : string.Empty;
                        oPosto.NaturezaOperacao = !DBNull.Value.Equals(oRow["naturezaoperacao"]) ? Convert.ToInt32("0" + oRow["naturezaoperacao"]) : 0;
                        oPosto.IncentivadorCultural = !DBNull.Value.Equals(oRow["incentivadorcultural"]) ? Convert.ToInt32("0" + oRow["incentivadorcultural"]) : 0;
                        oPosto.AliquotaISS = !DBNull.Value.Equals(oRow["aliquotaiss"]) ? Convert.ToInt32("0" + oRow["aliquotaiss"]) : 0;
                        oPosto.CNAE = !DBNull.Value.Equals(oRow["cnae"]) ? Convert.ToInt32("0" + oRow["cnae"]) : 0;
                    }
                }
                else
                {
                    //***********************************
                    //* Devolve resultado nulo como erro
                    //***********************************
                    _ErrorText = "O Resultado da pesquisa retornou nulo";
                    _Error = true;
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

            //****************
            //* Devolve lista
            //****************
            return oPosto;
        }
        public byte[] GetPicture(Int32 CodigoPosto)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            byte[] buffer = { };

            //*******************
            //* Proteção de erro
            //*******************
            try
            {
                //****************************
                //* Obtem lista de promotores
                //****************************
                string SQL = "SELECT postoven, nomeposto, logotipo FROM posto WHERE postoven = " + CodigoPosto.ToString();
                DataTable oTable = oDBManager.ExecuteQuery(SQL);

                //************************************
                //* Devolve status e mensagem de erro
                //************************************
                _ErrorText = oDBManager.ErrorMessage;
                _Error = oDBManager.Error;

                //**************
                //* Houve erro?
                //**************
                if (!oDBManager.Error)
                {
                    //*******************
                    //* Obteve registro?
                    //*******************
                    if (oTable != null)
                        if (oTable.Rows.Count == 1)
                            buffer = (byte[])oTable.Rows[0]["logotipo"];
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

            //*************************
            //* Retorna array de bytes
            //*************************
            return buffer;
        }
        public Int32 ApplyRecord(Posto_Fields oPosto, bool Import = false)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //****************
            //* Cria registro
            //****************
            SQL = "REPLACE INTO posto (";
            SQL += "PostoVen,";
            SQL += "CodCidade,";
            SQL += "DescPosto,";
            SQL += "End,";
            SQL += "CEP,";
            SQL += "Fone1,";
            SQL += "Fone2,";
            SQL += "Fax,";
            SQL += "EMail,";
            SQL += "NomePosto,";
            SQL += "CGC,";
            SQL += "InscrMun,";
            SQL += "Embratur,";
            SQL += "Iata,";
            SQL += "HTTP,";
            SQL += "RestringeContas,";
            SQL += "LogoTipo,";
            SQL += "CodEmpIntCtb,";
            SQL += "UltimaNFPosto,";
            SQL += "UltimaFaturaPosto,";
            SQL += "UltimReciboPosto,";
            SQL += "UltimaNFPostoFreta,";
            SQL += "OmiteNroNFRodape,";
            SQL += "CodEmpNfe,";
            SQL += "ChavePrivadaNfe,";
            SQL += "ChaveAcessoNfe,";
            SQL += "RegimeEspTributa,";
            SQL += "OptanteSimplesNac,";
            SQL += "TributoMunicipio,";
            SQL += "SerieRPS,";
            SQL += "TipoRPS,";
            SQL += "NaturezaOperacao,";
            SQL += "IncentivadorCultural,";
            SQL += "AliquotaISS,";
            SQL += "CNAE";
            SQL += ") VALUES (";
            SQL += oPosto.PK_PostoVen.ToString() + ",";
            SQL += oPosto.CodCidade.ToString() + ",";
            SQL += "'" + oPosto.DescPosto.SQLFilter() + "',";
            SQL += "'" + oPosto.End.SQLFilter() + "',";
            SQL += "'" + oPosto.CEP.SQLFilter() + "',";
            SQL += "'" + oPosto.Fone1.SQLFilter() + "',";
            SQL += "'" + oPosto.Fone2.SQLFilter() + "',";
            SQL += "'" + oPosto.Fax.SQLFilter() + "',";
            SQL += "'" + oPosto.EMail.SQLFilter() + "',";
            SQL += "'" + oPosto.NomePosto.SQLFilter() + "',";
            SQL += "'" + oPosto.CGC.SQLFilter() + "',";
            SQL += "'" + oPosto.InscrMun.SQLFilter() + "',";
            SQL += "'" + oPosto.Embratur.SQLFilter() + "',";
            SQL += "'" + oPosto.Iata.SQLFilter() + "',";
            SQL += "'" + oPosto.HTTP.SQLFilter() + "',";
            SQL += "'" + oPosto.RestringeContas.SQLFilter() + "',";
            SQL += "'0x" + oPosto.LogoTipo.ToHexString() + "',";
            SQL += "'" + oPosto.CodEmpIntCtb.SQLFilter() + "',";
            SQL += oPosto.UltimaNFPosto.ToDBNumeric(2) + ",";
            SQL += oPosto.UltimaFaturaPosto.ToDBNumeric(2) + ",";
            SQL += oPosto.UltimReciboPosto.ToDBNumeric(2) + ",";
            SQL += oPosto.UltimaNFPostoFreta.ToDBNumeric(2) + ",";
            SQL += "'" + oPosto.OmiteNroNFRodape.SQLFilter() + "',";
            SQL += oPosto.CodEmpNfe.ToString() + ",";
            SQL += "'" + oPosto.ChavePrivadaNfe.SQLFilter() + "',";
            SQL += "'" + oPosto.ChaveAcessoNfe.SQLFilter() + "',";
            SQL += oPosto.RegimeEspTributa.ToString() + ",";
            SQL += oPosto.OptanteSimplesNac.ToString() + ",";
            SQL += oPosto.TributoMunicipio.ToString() + ",";
            SQL += "'" + oPosto.SerieRPS.SQLFilter() + "',";
            SQL += "'" + oPosto.TipoRPS.SQLFilter() + "',";
            SQL += oPosto.NaturezaOperacao.ToString() + ",";
            SQL += oPosto.IncentivadorCultural.ToString() + ",";
            SQL += oPosto.AliquotaISS.ToDBNumeric(4) + ",";
            SQL += oPosto.CNAE.ToString() + ")";

            //****************************
            //* Controla erro de execução
            //****************************
            try
            {
                //**************************
                //* Executa comando formado
                //**************************
                oPosto.PK_PostoVen = oDBManager.ExecuteCommand(SQL, Import);

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
            return oPosto.PK_PostoVen;
        }
        public bool DeleteRecord(Posto_Fields oPosto)
        {
            //**************
            //* Declarações
            //**************
            DBManager oDBManager = new DBManager(ConnectionString);
            string SQL = string.Empty;

            //******************************
            //* O código do posto é válido?
            //******************************
            if (oPosto.PK_PostoVen != 0)
            {
                //******************
                //* Exclui registro
                //******************
                SQL = "DELETE FROM posto WHERE PostoVen = " + oPosto.PK_PostoVen;
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
                _ErrorText = "Informe o código do posto.";
                _Error = true;
                return false;
            }
        }
    }
}