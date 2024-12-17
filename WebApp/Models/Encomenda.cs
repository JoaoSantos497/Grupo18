namespace WebApp.Models
{
    public class Encomenda
    {
        public required string NumeroRastreamento { get; set; }
        public required string Status { get; set; }
        public required string LocalizacaoAtual { get; set; }
        public required DateTime DataUltimaAtualizacao { get; set; }
        public required List<string> Historico { get; set; }
    }
}
