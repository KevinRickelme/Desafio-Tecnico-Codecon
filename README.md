# Desafio Técnico: Performance e Análise de Dados via API

## Explicação [UMA API PARA ANALISAR DADOS DE 100 MIL USUÁRIOS - 1 sênior vs. 3 júniors - Codecon]((https://www.youtube.com/watch?v=AFtRYXJVO-4))
Assistindo ao vídeo me senti preparado para testar meus conhecimentos e finalizar o desafio proposto. Acessei o repositório do projeto e comecei o desenvolvimento. O Desafio foi finalizado em 56m08s e atende os requisitos técnicos propostos. Todo o projeto foi criado em WebAPI do C# utilizando .NET 8.

## Objetivo

Tive 1 hora para criar uma API que recebe um arquivo JSON com 100.000 usuários e oferece endpoints performáticos e bem estruturados para análise dos dados.

- [Exemplos de respostas esperadas na API](https://github.com/codecon-dev/desafio-1-1s-vs-3j/blob/main/exemplos-endpoints.json)
- [Arquivo com 100 mil usuários para importar](https://drive.google.com/file/d/1zOweCB2jidgHwirp_8oBnFyDgJKkWdDA/view?usp=sharing)
- [Arquivo com 1 mil usuário para teste](https://drive.google.com/file/d/1BX03cWxkvB_MbZN8_vtTJBDGiCufyO92/view?usp=sharing)

---

## JSON de entrada

O JSON contém uma lista de usuários com a seguinte estrutura:

```json
{
  "id": "uuid",
  "name": "string",
  "age": "int",
  "score": "int",
  "active": "bool",
  "country": "string",
  "team": {
    "name": "string",
    "leader": "bool",
    "projects": [{ "name": "string", "completed": "bool" }]
  },
  "logs": [{ "date": "YYYY-MM-DD", "action": "login/logout" }]
}
```

---

## Endpoints obrigatórios

### `POST /users`

Recebe e armazena os usuários na memória. Pode simular um banco de dados em memória.

### `GET /superusers`

- Filtro: `score >= 900` e `active = true`
- Retorna os dados e o tempo de processamento da requisição.

### `GET /top-countries`

- Agrupa os superusuários por país.
- Retorna os 5 países com maior número de superusuários.

### `GET /team-insights`

- Agrupa por `team.name`.
- Retorna: total de membros, líderes, projetos concluídos e % de membros ativos.

### `GET /active-users-per-day`

- Conta quantos logins aconteceram por data.
- Query param opcional: `?min=3000` para filtrar dias com pelo menos 3.000 logins.

---

## Requisitos Técnicos

- Tempo de resposta < 1s por endpoint.
- Todos os endpoints precisam retornar o tempo de processamento (em milissegundos) e a timestamp da requisição
- Código limpo, modular, com funções bem definidas.
- Pode usar qualquer linguagem/framework.
- Documentação ou explicação final vale pontos bônus.
- Não pode usar IA.
