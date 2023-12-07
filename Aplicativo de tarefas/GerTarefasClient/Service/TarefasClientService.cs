public class TarefasClientService
{
    public async Task GetTarefasAsync(HttpClient client)
    {
        HttpResponseMessage response = await client.GetAsync($"/tarefas");
        if (response.IsSuccessStatusCode)
        {
            var verTarefas = await response.Content.ReadAsAsync<List<Tarefas>>();
            foreach(var verTarefa in verTarefas)
                Console.WriteLine("\r\nId: " + verTarefa.Id.ToString() + "\r\nNome: " + verTarefa.Nome + "\r\nCompleta: " + verTarefa.Completa);
        }
    }

    public async Task GetTarefasPorIdAsync(HttpClient client)
    {
        Console.WriteLine("Digite o Id da Tarefa");
        var id = Console.ReadLine();
        Tarefas? verTarefa = null;
        HttpResponseMessage response = await client.GetAsync($"/tarefas/{int.Parse(id!)}");
        if (response.IsSuccessStatusCode)
        {
            verTarefa = await response.Content.ReadAsAsync<Tarefas>();
            Console.WriteLine("\r\nId: " + verTarefa.Id.ToString() + "\r\nNome: " + verTarefa.Nome + "\r\nCompleta: " + verTarefa.Completa);
        }
    }

    public async Task SetTarefasAsync(HttpClient client)
    {
        Tarefas? tarefa = new Tarefas();
        Console.WriteLine("Digite o nome da Tarefa");
        tarefa.Nome = Console.ReadLine();
        tarefa.Completa = false;
        tarefa.DataCompletada = DateTime.MinValue;
        HttpResponseMessage response = await client.PostAsJsonAsync($"/tarefas/add",tarefa);
        Console.WriteLine("Tarefa cadastrada com sucesso!");
    }

    public async Task CompletarTarefadAsync(HttpClient client)
    {
        Console.WriteLine("Digite o Id da Tarefa");
        var id = Console.ReadLine();
        HttpResponseMessage response = await client.PutAsync($"/tarefas/completa/{int.Parse(id!)}",null);
        if (response.IsSuccessStatusCode)
            Console.WriteLine("Tarefa completa com sucesso!");    
    }
    public async Task ExcluirTarefadAsync(HttpClient client)
    {
        Console.WriteLine("Digite o Id da Tarefa");
        var id = Console.ReadLine();
        HttpResponseMessage response = await client.PutAsync($"/tarefas/excluir/{int.Parse(id!)}",null);
        if (response.IsSuccessStatusCode)
            Console.WriteLine("Tarefa excluída com sucesso!");    
    }
}