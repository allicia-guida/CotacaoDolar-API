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
        if (!System.IO.File.Exists(path))
        {
            return NotFound("Arquivo de dados não encontrado.");
        }

        var json = System.IO.File.ReadAllText(path);
        var cotacao = JsonSerializer.Deserialize<Cotacao>(json);

        return Ok(cotacao);
    }
}