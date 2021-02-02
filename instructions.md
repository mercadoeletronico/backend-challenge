#Pré-requisitos

- Java 11
- Docker 20.10
- Docker-compose 1.27.4

#Execução

Na raiz do projeto.
###windows
```bash
run.cmd
```
### unix-like
```bash
run.sh
```

#Libs utilizadas

- Spring-boot 2.4.1
- R2DBC-H2 0.8.4
- Lombok 1.18.16
- faker 0.16
- H2 1.4.2

#Testes

````bash
mvnw test
````

#Endpoint

Criar um novo pedido
```http request
POST http://locahost:8080/api/pedido HTTP/1.1
content-type: application/json

{
  "pedido":"123456",
  "itens": [
      {
        "descricao": "Item A",
        "precoUnitario": 10,
        "qtd": 1
      },
      {
        "descricao": "Item B",
        "precoUnitario": 5,
        "qtd": 2
      }
  ]
}
```

Buscar um pedido
```http request
GET http://locahost:8080/api/pedido/{pedido} HTTP/1.1
```

Alterar um pedido
```http request
PUT http://locahost:8080/api/pedido/{pedido} HTTP/1.1
content-type: application/json

{
  "pedido": "{PEDIDO}",
  "itens": [
      {
        "descricao": "Item A",
        "precoUnitario": 10,
        "qtd": 1
      },
      {
        "descricao": "Item B",
        "precoUnitario": 5,
        "qtd": 2
      }
  ]
}
```

Deletar um pedido
```http request
DELETE http://locahost:8080/api/pedido/{pedido} HTTP/1.1
```

"Alterar" status do pedido.


```http request
POST http://localhost:8080/api/status/
content-type: application/json

{
  "status":"XXX",
  "itensAprovados":0,
  "valorAprovado":0,
  "pedido":"XXX"
}
```
Regras de negócio no [README.md](README.md)