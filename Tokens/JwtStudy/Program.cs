
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "TokenAPI";
    config.Title = "TokenAPI v1";
    config.Version = "v1";
});
var ts = new TokenService();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "TodoAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/", () => "Hello World!");


app.MapPost("/encode", (User user) =>
{
    var token = ts.Generate(user);
    return Results.Ok(token);
});

app.MapPost("/decode", ([FromBody] string s) =>
{
    ts.Decode(s);
    return Results.Ok();
});


app.Run();
