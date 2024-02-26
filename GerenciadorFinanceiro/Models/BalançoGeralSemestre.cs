namespace GerenciadorFinanceiro.Models
{
    public class BalançoGeralSemestre
    {
        public int Mes { get; set; }
        public decimal TotalRecebido { get; set; }
        public decimal TotalGasto { get; set; }
        public decimal TotalEconomizado { get; set; }
    }
}
