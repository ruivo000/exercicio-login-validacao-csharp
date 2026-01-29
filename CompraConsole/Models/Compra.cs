using CompraConsole.Enums;
namespace CompraConsole.Models
{
    public class Compra
    {
        public int Idade { get; set; }
        public decimal ValorOriginal { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public FormaPagamento FormaPagamento { get; set; }

        public decimal DescontoTotal { get; set; }
        public decimal ValorFinal { get; set; }
    }
}