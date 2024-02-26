namespace GerenciadorFinanceiro.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime DataRegistro {  get; set; }
        public bool TipoTransacao { get; set; }
        public string? Categoria {  get; set; }
        public int IdCategoria { get; set; }
        public decimal Valor { get; set; }
        public bool Recorrencia { get; set; }
        public bool Parcelado { get; set; }
        public int NumParcelas { get; set; }
        public int ParcelasPagas { get; set;}
    }
}
