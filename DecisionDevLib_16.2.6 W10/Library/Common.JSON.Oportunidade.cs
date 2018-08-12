using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Decision.Database;
using Decision.Extensions;

namespace Decision.TableManager
{
    public class Oportunidade_JSON
    {
        //*******************
        //* Campos da tabela
        //*******************
        Dictionary<string, string> _parametros = new Dictionary<string, string>();
        private string _operacao = string.Empty;
        private Oportunidade_Fields _oportunidade = new Oportunidade_Fields();
        private Oportunidade_Orcamentos_Fields[] _orcamentos = new Oportunidade_Orcamentos_Fields[0];
        private string _error = string.Empty;

        public Oportunidade_JSON()
        {
            //****************
            //* Inicialização
            //****************
            _parametros = new Dictionary<string, string>();
            _operacao = string.Empty;
            _oportunidade = new Oportunidade_Fields();
            _orcamentos = new Oportunidade_Orcamentos_Fields[0];
        }

        //***************
        //* Propriedades
        //***************
        public Dictionary<string, string> parametros { get { return _parametros; } set { _parametros = value; } }
        public string operacao { get { return _operacao; } set { _operacao = value; } }
        public Oportunidade_Fields oportunidade { get { return _oportunidade; } set { _oportunidade = value; } }
        public Oportunidade_Orcamentos_Fields[] orcamentos { get { return _orcamentos; } set { _orcamentos = value; } }
        public string error { get { return _error; } set { _error = value; } }
    }
}
