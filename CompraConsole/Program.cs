using CompraConsole.Models;
using CompraConsole.Services;
using CompraConsole.Utils;

namespace CompraConsole
{
    internal class Program
    {
        static void Main()
        {
            var service = new CompraService();

            do
            {
                int idade = Input.LerInt("Digite sua idade:");
                if (!service.ClientePodeComprar(idade))
                {
                    Console.WriteLine("Acesso negado: menor de idade.");
                    continue;
                }

                decimal valor = Input.LerDecimal("Digite o valor da compra:");
                if (valor <= 0)
                {
                    Console.WriteLine("Valor inválido. Deve ser maior que zero.");
                    continue;
                }

                var compra = new Compra
                {
                    Idade = idade,
                    ValorOriginal = valor,
                    TipoCliente = Input.LerTipoCliente(),
                    FormaPagamento = Input.LerFormaPagamento()
                };

                service.CalcularTotais(compra);

                // Operador ternário
                string tipoClienteTexto = compra.TipoCliente == Enums.TipoCliente.Vip ? "VIP" : "Comum";

                Console.WriteLine("\n===== RESUMO =====");
                Console.WriteLine($"Cliente: {tipoClienteTexto}");
                Console.WriteLine($"Pagamento: {compra.FormaPagamento}");
                Console.WriteLine($"Valor original: R$ {compra.ValorOriginal:F2}");
                Console.WriteLine($"Desconto total: R$ {compra.DescontoTotal:F2}");
                Console.WriteLine($"Valor final: R$ {compra.ValorFinal:F2}");
                Console.WriteLine("==================\n");

            } while (Input.LerContinuar());
        }
    }
}
