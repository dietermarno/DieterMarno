using System.ComponentModel;

namespace Decision.Lists
{
    public class ComboItem
    {
        public string text { get; set; }
        public object id { get; set; }
        public ComboItem(string ItemText, object ItemValue)
        {
            text = ItemText;
            id = ItemValue;
        }
        public override string ToString()
        {
            return text;
        }
    }
    public static class OptionLists
    {
        public enum OportunidadeStuacao : int 
        {
            [Description("Qualificação")]
            Qualificacao = 1,
            [Description("Análise do Cliente")]
            Analise = 2,
            [Description("Fechado Ganhou")]
            Ganhou = 3,
            [Description("Fechado Perdeu")]
            Perdeu = 4
        }
        public enum OportunidadeCanalEntrada : int
        {
            [Description("Site")]
            Site = 1,
            [Description("Redes Sociais")]
            RedesSociais = 2,
            [Description("BLOG")]
            BLOG = 3,
            [Description("E-mail Marketing")]
            EmailMarketing = 4,
            [Description("Telefone")]
            Telefone = 5,
            [Description("Material Impresso")]
            MaterialImpresso = 6,
            [Description("Rádio")]
            Radio = 7,
            [Description("Televisão")]
            Televisao = 8,
            [Description("Indicação")]
            Indicacao = 9,
            [Description("Presencial")]
            Presencial = 10,
            [Description("Cliente")]
            Cliente = 11
        }
        public enum OrcamentoEstagio : int
        {
            [Description("Cotação")]
            Cotacao = 1,
            [Description("Enviado")]
            Enviado = 2,
            [Description("Aceito")]
            Aceito = 3,
            [Description("Recusado")]
            Recusado = 4
        }
        public enum AgendaEtiqueta : int
        {
            [Description("Nenhum")]
            Nenhum = 0,
            [Description("Importante")]
            Importante = 1,
            [Description("Negócio")]
            Negocio = 2,
            [Description("Pessoal")]
            Pessoal = 3,
            [Description("Férias")]
            Ferias = 4,
            [Description("Presença Obrigatória")]
            PresencaObrigatoria = 5,
            [Description("Viagem Necessária")]
            ViagemNecessaria = 6,
            [Description("Necessita Preparação")]
            Necessita_Preparacao = 7,
            [Description("Celebração")]
            Celebracao = 8,
            [Description("Chamada Telefônica")]
            Chamada_Telefonica = 9,
            [Description("Pré-Viagem")]
            Pre_Viagem = 10,
            [Description("Pós-Viagem")]
            Pos_Viagem = 11,
            [Description("Oportunidade")]
            Oportunidade = 12,
            [Description("Cotação")]
            Cotacao = 13
        }
        public enum AgendaStatus : int
        {
            [Description("Livre")]
            Livre = 0,
            [Description("Tentativa")]
            Tentativa = 1,
            [Description("Ocupado")]
            Ocupado = 2,
            [Description("Fora Escritório")]
            Fora_Escritorio = 3,
            [Description("Trabalhando em outro lugar")]
            Trabalhando_Outro_Lugar = 4
        }
        public enum Seguranca : int
        {
            #region "Agenda de compromissos"

            [Description("Acesso ao cadastro de agendamento de compromissos")]
            Cadastro_Agenda = 1,
            [Description("Restringir registros de agendamento de compromissos")]
            Cadastro_Agenda_Restingir = 5,
            
            #endregion

            #region "Cadastro de Clientes"

            [Description("Acesso ao cadastro de clientes")]
            Cadastro_Clientes = 8,

            #endregion

            #region "Oportunidades de negócios"

            [Description("Acesso ao cadastro de oportunidades de negócio")]
            Cadastro_Oportunidade = 2,
            [Description("Restringir registros do cadastro de oportunidades de negócio")]
            Cadastro_Oportunidade_Restringir = 6,

            #endregion

            #region "Cadastro de usuários"

            [Description("Acesso ao cadastro de usuários")]
            Cadastro_Usuario = 3,

            #endregion

            #region "Cadastro de grupos de segurança"

            [Description("Acesso ao cadastro de grupos de segurança")]
            Cadastro_Permissoes = 4,

            #endregion

            #region "Configurações Gerais"

            [Description("Acesso ao gerenciamento de configurações")]
            Gerenciamento_Configuracoes = 7

            #endregion
        }
    }
}