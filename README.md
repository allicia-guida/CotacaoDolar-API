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

### Tecnologias utilizadas

- .NET 8
- C#
- Console Application
- HTML, CSS e JavaScript

### Estrutura do projeto

- `Api/`: projeto da API ASP.NET Core  
- `Api/Controllers/CotacaoController.cs`: endpoint que retorna a cotação  
- `Api/wwwroot/index.html`: tela HTML simples para visualizar os dados  
- `Api/data.json`: arquivo com a última cotação salva  
- `Worker/`: projeto console responsável por atualizar a cotação  
- `Worker/Program.cs`: rotina que consulta a API externa e grava o JSON  

## Decisões arquiteturais

- Separação entre API e Worker para manter as responsabilidades organizadas.
- Uso de arquivo JSON para persistência dos dados de forma simples, sem necessidade de banco de dados.
- Execução do Worker em loop com delay para realizar a atualização periódica da cotação.
- Estrutura mantida simples para facilitar o entendimento e a organização do projeto.

## Como executar:

### 1. Iniciar o Worker

Na pasta do projeto, execute:

dotnet run --project Worker

### 2. Iniciar a Api

Em outro terminal, execute:

dotnet run --project Api

Com isso, a API ficará disponível para consulta dos dados.

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

- O Worker depende de acesso à internet para consultar a cotação.
- A API depende da existência do arquivo `Api/data.json`.
- O projeto foi feito com foco didatico e estrutura simples.

### Melhorias futuras

- Containerização com Docker para facilitar a execução e padronização do ambiente
- Utilizar um banco de dados em vez de arquivo JSON.
- Melhorar a forma de execução do Worker, utilizando um agendador mais adequado.