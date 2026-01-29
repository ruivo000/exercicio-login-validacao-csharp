using CompraConsole.Enums;

namespace CompraConsole.Utils
{
    public static class Input
    {
        public static int LerInt(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string? texto = Console.ReadLine();

                if (int.TryParse(texto, out int valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Digite um número inteiro.");
            }
        }

        public static decimal LerDecimal(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string? texto = Console.ReadLine();

                
                texto = texto?.Replace(',', '.');

                if (decimal.TryParse(texto, System.Globalization.NumberStyles.Number,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Digite um número válido (ex: 199.90).");
            }
        }

        public static TipoCliente LerTipoCliente()
        {
            while (true)
            {
                Console.WriteLine("Tipo do cliente: 1-Comum | 2-VIP");
                int opcao = LerInt("Escolha:");

                if (Enum.IsDefined(typeof(TipoCliente), opcao))
                    return (TipoCliente)opcao;

                Console.WriteLine("Opção inválida. Digite 1 ou 2.");
            }
        }

        public static FormaPagamento LerFormaPagamento()
        {
            while (true)
            {
                Console.WriteLine("Forma de pagamento: 1-Dinheiro | 2-Cartão | 3-Pix");
                int opcao = LerInt("Escolha:");

                if (Enum.IsDefined(typeof(FormaPagamento), opcao))
                    return (FormaPagamento)opcao;

                Console.WriteLine("Opção inválida. Digite 1, 2 ou 3.");
            }
        }

        public static bool LerContinuar()
        {
            while (true)
            {
                Console.WriteLine("Deseja realizar outra compra? (S/N)");
                string? resp = Console.ReadLine()?.Trim().ToUpper();

                if (resp == "S") return true;
                if (resp == "N") return false;

                Console.WriteLine("Resposta inválida. Digite S ou N.");
            }
        }
    }
}
