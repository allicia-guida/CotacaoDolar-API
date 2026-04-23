# CotacaoDolar-API

Aplicação simples feita em .NET 8 para consultar a cotação do dólar, salvar o resultado em um arquivo JSON e exibir essas informações por uma API e por uma página HTML.

A solução é composta por dois serviços:
- **API:** responsável por expor os dados via endpoint.
- **Worker:** responsável por buscar a cotação em uma API externa e salvar localmente.

## Fluxo da aplicação

- O `Worker` busca a cotação atual do dólar.  
- O `Worker` grava o valor e a data no arquivo `Api/data.json`.  
- A `Api` lê esse arquivo e retorna os dados em JSON.  
- A página HTML consome a API e mostra o valor na tela.

## Tecnologias utilizadas

- .NET 8
- ASP.NET
- Console Application
- HTML, CSS e JavaScript

## Estrutura do projeto

- `Api/`: projeto da API ASP.NET Core  
- `Api/Controllers/CotacaoController.cs`: endpoint que retorna a cotação  
- `Api/wwwroot/index.html`: tela HTML simples para visualizar os dados  
- `Api/data.json`: arquivo com a última cotação salva  
- `Worker/`: projeto console responsável por atualizar a cotação  
- `Worker/Program.cs`: rotina que consulta a API externa e grava o JSON  

## Como executar:

## 1. Iniciar o Worker

Na pasta do projeto, execute:

dotnet run --project Worker

## Como acessar:

Com a API em execução, você pode acessar:

- Swagger: `http://localhost:5298/swagger`
- Tela HTML: `http://localhost:5298/`

## Exemplo de retorno da API

json:
{
  "valor": "4.9847",
  "data": "23/04/2026 14:28:32"
}

## Observações:

- O `Worker` depende de acesso a internet para consultar a cotação.
- A API depende da existência do arquivo `Api/data.json`.
- O projeto foi feito com foco didatico e estrutura simples.
