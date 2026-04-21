# projeto-integrador-2

Repositório do projeto integrador 2 - Semestre 01/2026

## Como executar com Docker

Certifique-se de ter o [Docker](https://www.docker.com/) instalado e em execução.

Na raiz do repositório, execute:

```bash
docker-compose up --build
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
