# Mercado Eletrônico - Backend Challenge

## Visão Geral

O desafio consiste em criar uma API RESTful para adicionar *Pedidos* e *Itens* e consultar o *Status* de cada pedido.

Para isto, foram utilizadas as seguintes tecnologias:

- Ubuntu 20.04 (LTS)
- Java 11.0.9
- Maven 3.6.3
- Spring Boot 2.4.1
- JUnit 5.0.1 (JUnit Jupiter)

## Instruções

Para executar o projeto, execute os seguintes passos:

1. Clone o projeto

2. Entre no diretório **backend-challenge**

3. Execute o seguinte comando para buildar o projeto

```
mvn clean install
```

4. Execute o seguinte comando para startar o servidor

```
mvn spring-boot:run
```

5. Execute o seguinte comando para executar apenas os testes

```
mvn test
```

### Utilizando a aplicação

Para utilizar o projeto é necessário utilizar um programa que emule o cliente, por exemplo o Postman.

Na aplicação cliente, selecione qualquer um dos métodos HTTP (GET, POST, PUT, DELETE) para consumir o servidor.

#### Endpoint - Pedido

O Endpoint de Pedido está disponível na seguinte URI

```
http://localhost:8090/api/pedido
```

#### Endpoint - Mudança de Status de Pedido

O Endpoint de Mudança de Status de Pedido está disponível na seguinte URI

```
http://localhost:8090/api/status
```

#### Database H2

O banco de dados em memória H2 também pode ser consultado a partir da URI

```
http://localhost:8090/h2
```

O usuário do H2 server é **sa** e não possui senha.
