# # Projeto Integrador II

Repositório do projeto integrador 2 - Semestre 01/2026
Membros do Grupo: Anderson de Oliveira, Andrew Henrique de Lara Girarde e André Luiz dos Santos

## Como executar com Docker

Certifique-se de ter o [Docker](https://www.docker.com/) instalado e em execução.

Na raiz do repositório, execute:

```bash
docker-compose up -d --build
```

Os serviços estarão disponíveis em:

| Serviço    | URL                   |
| ---------- | --------------------- |
| Frontend   | http://localhost      |
| Backend    | http://localhost:8080 |
| PostgreSQL | `localhost:5432`      |

Para parar os containers:

```bash
docker-compose down
```

> As credenciais padrão do banco de dados são `postgres/postgres` e o banco criado é `projetointegrador`. Você pode sobrescrevê-las criando um arquivo `.env` na raiz com as variáveis `POSTGRES_USER`, `POSTGRES_PASSWORD` e `POSTGRES_DB`.

# API

API REST desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** (PostgreSQL) e **AutoMapper**.

---

## 🚀 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- PostgreSQL rodando localmente na porta `5432`
  - Usuário: `postgres`
  - Senha: `postgres`

O banco de dados `projetointegrador` e a tabela `produtos` são criados automaticamente na primeira execução.

---

## ▶️ Como executar

```bash
cd backend/ProjetoIntegrador2/ProjetoIntegrador2.API
dotnet run
```

A API ficará disponível em `https://localhost:7000` (ou a porta exibida no terminal).  
O Swagger UI pode ser acessado em `https://localhost:<porta>/swagger`.

---

## 📋 Endpoints

### 🔵 Health

#### `GET /api/health`

Verifica se a API está em funcionamento.

**Requisição**

```http
GET /api/health
```

**Resposta** `200 OK`

```json
{
  "status": "Healthy",
  "timestamp": "2025-04-21T12:00:00.000Z"
}
```

---

### 🟢 Produtos

#### `GET /api/produto`

Retorna a listagem completa de todos os produtos cadastrados.

**Requisição**

```http
GET /api/produto
```

**Resposta** `200 OK`

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "codigo": "7893946366216",
    "descricao": "ABAFADOR RUÍDO TIPO CONCHA 10DB ARV100 VONDER",
    "ativo": true,
    "unid": "UN",
    "custo": 13.62,
    "preco": 24.516,
    "estoque": 2.0
  },
  {
    "id": "9b2e4a77-1234-4def-a890-1b2c3d4e5f60",
    "codigo": "7898554010018",
    "descricao": "ABAFADOR RUÍDO TIPO CONCHA 10DB COMBAT DELTA PLUS",
    "ativo": true,
    "unid": "UN",
    "custo": 8.79,
    "preco": 15.822,
    "estoque": 0.0
  }
]
```

**Exemplo com `curl`**

```bash
curl -X GET https://localhost:<porta>/api/produto \
     -H "Accept: application/json"
```

**Exemplo com PowerShell**

```powershell
Invoke-RestMethod -Uri "https://localhost:<porta>/api/produto" -Method Get
```

---

## 🗂️ Estrutura do projeto

```
ProjetoIntegrador2.API/
├── Controllers/
│   ├── HealthController.cs
│   └── ProdutoController.cs
├── Data/
│   ├── AppDbContext.cs
│   └── Seeds/
│       └── produtos.csv
├── DTOs/
│   ├── ProdutoDto.cs
│   ├── CreateProdutoDto.cs
│   └── UpdateProdutoDto.cs
├── Entities/
│   └── Produto.cs
├── Mappings/
│   └── ProdutoProfile.cs
├── appsettings.json
└── appsettings.Development.json
```

---

## 🛠️ Tecnologias utilizadas

| Tecnologia                     | Versão |
| ------------------------------ | ------ |
| ASP.NET Core                   | 8.0    |
| Entity Framework Core + Npgsql | 8.0    |
| AutoMapper                     | 12.0   |
| Swashbuckle (Swagger)          | 6.6    |
