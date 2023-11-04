using System.Text;
using System.Text.Json;
public class Operacao
{
    public void Escrita()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        Console.WriteLine("Digite o conteúdo: ");
        string? content = Console.ReadLine();
        using (FileStream fs = File.Create(path))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(content);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Conteúdo escrito com sucesso!");
    }

    public void EscritaNoFinal()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        Console.WriteLine("Digite o conteúdo: ");
        string? content = Console.ReadLine();
        using (FileStream ts = File.Open(path, FileMode.Append, FileAccess.Write))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(content);
            //escrita
            ts.Write(info, 0, info.Length);
        }
        Console.WriteLine("Conteúdo escrito com sucesso!");
    }

    public void Leitura()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();

        var r = File.ReadAllText(path);
        Console.WriteLine(r);
    }

    public void Copiar()
    {
        Console.WriteLine("Escolha o caminho inicial: ");
        string? path = Console.ReadLine();
        Console.WriteLine("Escolha o caminho de destino: ");
        string? path2 = Console.ReadLine();

        MemoryStream destination = new MemoryStream();
        using (FileStream fs = File.Open(path, FileMode.Open))
        {
            fs.CopyTo(destination);
        }

        using (FileStream rs = File.Create(path2))
        {
            byte[] info = destination.ToArray();
            //escrita
            rs.Write(info, 0, info.Length);
        }

        Console.WriteLine("Conteúdo copiado e escrito com sucesso!");
    }

    public void UltimoAcesso()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        DateTime dt = File.GetLastAccessTimeUtc(path); 

        Console.WriteLine(dt);
    }

    public void EscreverJson()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        Console.WriteLine("Escreva o nome da propriedade: ");
        string? nome = Console.ReadLine();
        Console.WriteLine("Escreva o valor da propriedade: ");
        string? valorProp = Console.ReadLine();
        Dictionary<string, string> dic = new Dictionary<string, string>
        {
            { nome, valorProp }
        };
        string? jsonstring = JsonSerializer.Serialize<Dictionary<string, string>>(dic);       
        using (FileStream fs = File.Create(path))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(jsonstring);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Conteúdo escrito com sucesso!");
    }
    public void EscreverFinalJson()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        Console.WriteLine("Escreva o nome da propriedade: ");
        string? nome = Console.ReadLine();
        Console.WriteLine("Escreva o valor da propriedade: ");
        string? valorProp = Console.ReadLine();

        string? jsonstring  = File.ReadAllText(path);
        var content = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonstring);
        content.Add(nome,valorProp);
        
        string? jsonNewString = JsonSerializer.Serialize<Dictionary<string, string>>(content);       
        using (FileStream fs = File.Create(path))
        {   
            byte[] info = new UTF8Encoding(true).GetBytes(jsonNewString);
            //escrita
            fs.Write(info, 0, info.Length);

        }
        Console.WriteLine("Conteúdo escrito com sucesso!");
    }

    public void LerJson()
    {
        Console.WriteLine("Escolha o caminho: ");
        string? path = Console.ReadLine();
        string? jsonstring  = File.ReadAllText(path);
        var content = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonstring);       
        
        foreach( KeyValuePair<string, string> kvp in content )
        {
            Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
        }
    }
}