namespace WebApp.Models
{
    public class Encomenda
    {
        public int EncomendaID { get; set; }
        public int UserID { get; set; } // FK para a tabela Users
        public DateTime DataEncomenda { get; set; } // Data da encomenda
        public decimal Total { get; set; } // Valor total da encomenda
        public string Estado { get; set; } // Exemplo: Pendente, Enviado, Entregue, Cancelado

        // Propriedades adicionais
        public string NumeroRastreamento { get; set; } // Número de rastreamento
        public string Status { get; set; } // Status atual da encomenda
        public string LocalizacaoAtual { get; set; } // Localização atual
        public DateTime? DataUltimaAtualizacao { get; set; } // Última atualização
        public List<string> Historico { get; set; } // Histórico de rastreamento
    }
}
