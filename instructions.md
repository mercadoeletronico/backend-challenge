### :pencil: Instruções para execução

#### #1 Pré-requisitos

* JDK 11 

#### #2 Execução da aplicação

Na pasta do projeto, executar em terminal:
```
mvn spring-boot:run
```

Após compilação, o swagger-ui com a definição do serviço estará disponível em http://localhost:8080/api/swagger-ui.html

#### #3 Execução dos testes

Na pasta do projeto, executar em terminal:
```
mvn clean test
```

Após compilação, os dados de cobertura estarão disponíveis em target\site\jacoco\index.html