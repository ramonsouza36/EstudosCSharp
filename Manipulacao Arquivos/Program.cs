// See https://aka.ms/new-console-template for more information

Console.WriteLine("Escolha a opção: ");
Console.WriteLine("1 - Escrever um novo arquivo");
Console.WriteLine("2 - Escrever em um arquivo já existente");
Console.WriteLine("3 - ler de um arquivo");
Console.WriteLine("4 - Copiar de um arquivo para outro");
Console.WriteLine("5 - Verificar último acesso");
Console.WriteLine("6 - Escrever um arquivo json");
Console.WriteLine("7 - Adicionar propriedade no json");
Console.WriteLine("8 - Ler um arquivo json");
Console.WriteLine("\nDigite a opção: ");
var opcao = Console.ReadLine();

Operacao  operacao = new Operacao();

switch(opcao)
{
    case "1":
        operacao.Escrita();
        break;
    case "2":
        operacao.EscritaNoFinal();
        break;
    case "3":
        operacao.Leitura();
        break;
    case "4":
        operacao.Copiar();
        break;
    case "5":
        operacao.UltimoAcesso();
        break;
    case "6":
        operacao.EscreverJson();
        break;
    case "7":
        operacao.EscreverFinalJson();
        break;
    case "8":
        operacao.LerJson();
        break;
}
