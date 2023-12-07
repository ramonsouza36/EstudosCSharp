var builder = WebApplication.CreateBuilder(args);

var tarefasService = new TarefasService();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/tarefas", async () =>
{
    List<Tarefas> tarefas = tarefasService.GetTarefas();
    return tarefas;
});

app.MapGet("/tarefas/{id}", async (int id) =>
{
    Tarefas tarefa = tarefasService.GetTarefaPorId(id);
    return tarefa;
});

app.MapPost("/tarefas/add", async (Tarefas tarefa) =>
{
    tarefasService.SetTarefas(tarefa);
});

app.MapPut("/tarefas/completa/{id}", async (int id) =>
{
    tarefasService.CompletarTarefaPorId(id);
});

app.MapPut("/tarefas/excluir/{id}", async (int id) =>
{
    tarefasService.ExcluirTarefaPorId(id);
});


app.Run();
