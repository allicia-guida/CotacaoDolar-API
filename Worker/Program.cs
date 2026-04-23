using System.Text.Json;

var url = "https://economia.awesomeapi.com.br/json/last/USD-BRL";

using var httpClient = new HttpClient();

try
{
    var response = await httpClient.GetStringAsync(url);
    using JsonDocument doc = JsonDocument.Parse(response);
    var usdBrL = doc.RootElement.GetProperty("USDBRL");
    var valor = usdBrL.GetProperty("bid").GetString();
    var data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    var resultado = new
    {
        valor = valor,
        data = data
    };
    var json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions 
    {
        WriteIndented = true 
    });

    var caminhoArquivo = Path.Combine("..", "Api", "data.json");
    File.WriteAllText(caminhoArquivo, json);
    Console.WriteLine("Cotação atualizada com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao buscar cotação: {ex.Message}");
}
