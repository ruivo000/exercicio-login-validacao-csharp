
using System.Linq;

Console.WriteLine("Digite seu login:");
string login = Console.ReadLine();
if (string.IsNullOrWhiteSpace(login) || !login.All(char.IsLetter))
{
    Console.WriteLine("Login inválido. Use apenas letras e não deixe vazio.");
    return;
}
Console.WriteLine("Login válido");
Console.WriteLine("Digite sua senha(APENAS NÚMEROS)");
bool senhaValida = int.TryParse(Console.ReadLine(), out int senha);

if (!senhaValida)
{
    Console.WriteLine("Erro: Digite apenas números.");
    return;
}
else{
    Console.WriteLine("Senha válida!");
}
