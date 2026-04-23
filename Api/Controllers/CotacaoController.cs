using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Api.Models;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var path = "data.json";

        // Verifica se o arquivo de dados existe antes de tentar ler
        if (!System.IO.File.Exists(path))
        {
            return NotFound("Arquivo de dados não encontrado.");
        }

        // Lê o JSON gerado pelo Worker
        var json = System.IO.File.ReadAllText(path);

        // Converte o conteúdo do JSON para o objeto Cotacao
        var cotacao = JsonSerializer.Deserialize<Cotacao>(json);

        return Ok(cotacao);
    }
}