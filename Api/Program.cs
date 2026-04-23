var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços necessários para a API e documentação Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Habilita o Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Permite servir arquivos estáticos (HTML, CSS, JS)
app.UseDefaultFiles();
app.UseStaticFiles();

// Mapear Controllers para as rotas da API
app.MapControllers();

app.Run();
