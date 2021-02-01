# Desafio Dev Java
 Criação do Endpoint – Pedidos
 
 ## Considerações iniciais
 Antes de dar início, certifique-se que tenha em sua máquina:
 - [ ] Maven;
 - [ ] Java 8;
 
## Tecnologias Utilizadas
 - Spring Boot 2.4.2
 - Java 1.8
 - Maven 3.6.2
 - Lombok 1.8
 - Swagger 2
 - Embedded H2

## Primeios passos

Faça o `clone` do projeto com o seguinte comando: `git clone
https://github.com/luizbsilva/backend-challenge.git`


## Executando Aplicação
Na pasta raiz do projeto utilizar o comando 
``` mvn spring-boot:run ``` 
(Caso necessário use [Maven](http://maven.apache.org/install.html))

Para compilar e gerar build do projeto utilize os comando ```mvn compile``` e ```mvn package``` este comando deverá gerar um executável.

## Observações
Para que não haja problemas com a visualização do código, configure sua IDE para aceitar as anotações do Lombok (Mais info [Lombok](https://projectlombok.org/))

A aplicação está configurada para acessar o console do h2 pelo path ```http://localhost:8080/api/h2-console```

O Swagger está disponível no path ```http://localhost:8080/api/swagger-ui.html```
