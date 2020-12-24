# Backend Challenge - Mercado Eletrônico

## Instruções

Esta solução foi desenvolvida utilizando as seguintes versões:

- Java 12.0.2
- JUnit 5
- Maven 3.6.3
- Spring Boot 2.4.0

A partir do terminal, baixe o projeto a partir desta branch para sua máquina local. Ao acessar o diretório raiz do projeto, pelo terminal, utilize os seguintes comandos:

1. Limpar pasta target

```
mvn clean
```

2. Build

```
mvn package
```

3. Executar a aplicação

```
mvn spring-boot:run
```

Para executar apenas os testes de unidade e integração:

```
mvn test
```


### Utilizando a aplicação


Através de alguma aplicação cliente (como o postman ou similar), será possível acessar as seguintes urls:

1. GET, POST, PUT, DELETE

```
http://localhost:8080/api/pedido
```

2. POST

```
http://localhost:8080/api/status
```

O payload para as APIs está descrito no README do problema.