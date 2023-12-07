using System.Net.Http.Headers;

class Program
{
    private static async Task Main(string[] args)
    {
        var service = new TarefasClientService();
        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000")
        };
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        Console.WriteLine("Escolha a opção: ");
        Console.WriteLine("1 - Ver todas as tarefas");
        Console.WriteLine("2 - Ver uma tarefa pelo Id");
        Console.WriteLine("3 - Cadastrar uma nova tarefa");
        Console.WriteLine("4 - Completar uma tarefa");
        Console.WriteLine("5 - Completar uma tarefa");
        Console.WriteLine("\nDigite a opção: ");
        var opcao = Console.ReadLine();

        switch(opcao)
        {
            case "1":
                await service.GetTarefasAsync(client);
                break;
            case "2":
                await service.GetTarefasPorIdAsync(client);
                break;
            case "3":
                await service.SetTarefasAsync(client);
                break;
            case "4":
                await service.CompletarTarefadAsync(client);
                break;
            case "5":
                await service.ExcluirTarefadAsync(client);
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }

}