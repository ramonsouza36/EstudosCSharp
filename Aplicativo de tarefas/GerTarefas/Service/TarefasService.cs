using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class TarefasService
{
    public List<Tarefas>? GetTarefas()
    {
        string? jsonstring  = File.ReadAllText("/home/ramon/Documentos/tarefasDb.json");
        var content = JsonSerializer.Deserialize<List<Tarefas>>(jsonstring);
        return content;
    }

    public Tarefas? GetTarefaPorId(int id)
    {
        string? jsonstring  = File.ReadAllText("/home/ramon/Documentos/tarefasDb.json");
        var content = JsonSerializer.Deserialize<List<Tarefas>>(jsonstring);
        return content.FirstOrDefault(t => t.Id == id);
    }

    public void SetTarefas(Tarefas tarefas)
    {
        string? jsonstring  = File.ReadAllText("/home/ramon/Documentos/tarefasDb.json");
        var content = JsonSerializer.Deserialize<List<Tarefas>>(jsonstring);
        var id = content.Max(i => i.Id);
        tarefas.Id = ++id;
        content.Add(tarefas);
        string? newJsonstring = JsonSerializer.Serialize<List<Tarefas>>(content);       
        using (FileStream fs = File.Create("/home/ramon/Documentos/tarefasDb.json"))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(newJsonstring);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Tarefa cadastrada com sucesso!");
    }

    public void CompletarTarefaPorId(int id)
    {
        string? jsonstring  = File.ReadAllText("/home/ramon/Documentos/tarefasDb.json");
        var content = JsonSerializer.Deserialize<List<Tarefas>>(jsonstring);
        var tarefa = content.FirstOrDefault(i => i.Id == id);
        tarefa.Completa = true;
        tarefa.DataCompletada = DateTime.Now;
        string? newJsonstring = JsonSerializer.Serialize<List<Tarefas>>(content);       
        using (FileStream fs = File.Create("/home/ramon/Documentos/tarefasDb.json"))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(newJsonstring);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Tarefa cadastrada com sucesso!");
    }

    public void ExcluirTarefaPorId(int id)
    {
        string? jsonstring  = File.ReadAllText("/home/ramon/Documentos/tarefasDb.json");
        var content = JsonSerializer.Deserialize<List<Tarefas>>(jsonstring);
        var tarefa = content.FirstOrDefault(i => i.Id == id);
        content.Remove(tarefa);
        string? newJsonstring = JsonSerializer.Serialize<List<Tarefas>>(content);       
        using (FileStream fs = File.Create("/home/ramon/Documentos/tarefasDb.json"))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(newJsonstring);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Tarefa cadastrada com sucesso!");
    }

    
}