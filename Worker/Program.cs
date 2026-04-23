using System.Text.Json;

// URL da API externa que fornece a cotação do dólar
var url = "https://economia.awesomeapi.com.br/json/last/USD-BRL";

using var httpClient = new HttpClient();

// Executa continuamente a atualização da cotação a cada intervalo definido
while (true) {

try
{
    // Realiza a requisição HTTP para obter os dados atualizados
    var response = await httpClient.GetStringAsync(url);
    
    // Converte o JSON retornado pela API e acessa a propriedade da cotação do dólar
    using JsonDocument doc = JsonDocument.Parse(response);

    // Acessa o objeto da cotação USD para BRL retornado pela API
    var usdBrL = doc.RootElement.GetProperty("USDBRL");

    // Extrai o valor atual do dólar (campo "bid" da API)
    var valor = usdBrL.GetProperty("bid").GetString();

    // Define a data e hora atual da coleta da cotação
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
    Console.WriteLine($"[{DateTime.Now}] Cotação atualizada com sucesso!");
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao buscar cotação: {ex.Message}");
}

    // Aguarda por um minuto antes de realizar a próxima atualização da cotação
    await Task.Delay(TimeSpan.FromMinutes(1));

}
