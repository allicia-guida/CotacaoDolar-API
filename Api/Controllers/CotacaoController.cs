using Microsoft.AspNetCore.Mvc;

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
        return Ok(json);
    }
}