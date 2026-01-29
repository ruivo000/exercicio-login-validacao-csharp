using CompraConsole.Enums;
using CompraConsole.Models;

namespace CompraConsole.Services
{
    public class CompraService
    {
        public bool ClientePodeComprar(int idade)
        {
            return idade >= 18;
        }

        public void CalcularTotais(Compra compra)
        {
            decimal descontoPercentual = 0m;

            // Desconto por tipo de cliente + valor
            if (compra.TipoCliente == TipoCliente.Comum && compra.ValorOriginal >= 200m)
                descontoPercentual += 0.05m;
            else if (compra.TipoCliente == TipoCliente.Vip && compra.ValorOriginal < 200m)
                descontoPercentual += 0.10m;
            else if (compra.TipoCliente == TipoCliente.Vip && compra.ValorOriginal >= 200m)
                descontoPercentual += 0.20m;

            // Desconto extra por pagamento (switch)
            switch (compra.FormaPagamento)
            {
                case FormaPagamento.Dinheiro:
                    descontoPercentual += 0.05m;
                    break;
                case FormaPagamento.Pix:
                    descontoPercentual += 0.03m;
                    break;
                case FormaPagamento.Cartao:
                    break;
            }

            compra.DescontoTotal = compra.ValorOriginal * descontoPercentual;
            compra.ValorFinal = compra.ValorOriginal - compra.DescontoTotal;
        }
    }
}
