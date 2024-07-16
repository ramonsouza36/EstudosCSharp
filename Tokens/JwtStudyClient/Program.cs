using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

internal class Program
{
    static HttpClient client = new HttpClient();
    static async Task<string> RunAsync()
    {
        client.BaseAddress = new Uri("http://localhost:5033");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var user = new User()
        {
            Id = 1,
            Name = "Ramon",
            Email = "teste@teste.com",
            Password = "123456",
            Roles = new[] { "Admin" }
        };

        HttpResponseMessage response = await client.PostAsJsonAsync("/encode", user);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        var res = await response.Content.ReadFromJsonAsync<string>();   
        var json = JsonSerializer.Serialize<string>(res);
        HttpContent content = new StringContent(json,UnicodeEncoding.UTF8, "application/json");
        response = await client.PostAsync("/decode",content);
        return res;

    }
    private static async Task Main(string[] args)
    {
        var response = await RunAsync();
    }
}