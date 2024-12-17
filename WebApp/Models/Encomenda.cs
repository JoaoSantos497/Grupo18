namespace WebApp.Models
{
    public class Encomenda
    {
        public required int UserID { get; set; } // FK para a tabela Users
        public required DateTime DataEncomenda { get; set; } // Data da encomenda
        public required decimal Total { get; set; } // Valor total da encomenda
        public required string Estado { get; set; } // Exemplo: Pendente, Enviado, Entregue, Cancelado

        // Propriedades adicionais
        public required string NumeroRastreamento { get; set; } // Número de rastreamento
        public required string Status { get; set; } // Status atual da encomenda
        public required string LocalizacaoAtual { get; set; } // Localização atual
        public required DateTime? DataUltimaAtualizacao { get; set; } // Última atualização
        public required List<string> Historico { get; set; } // Histórico de rastreamento
        public int EncomendaID { get; internal set; }
    }
}
