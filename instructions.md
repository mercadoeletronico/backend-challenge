# Instruções
```
Projeto pode ser executado pela IDE ou acessando pelo terminal "cd ORDER.API"e executando 
"dotnet run" para acessar o swagger do projeto basta acessar: 

https://localhost:5001/swagger/index.html
```


# Projeto
```
Projeto criado em .NET 5 utilizando DDD e banco de dados InMemory, para os testes unitarios 
foi escolhido NUnit
```

# Comentarios
```
Todas as exception da controller são tratadas dentro do arquivo ORDER.API/Filter/ExceptionFilter

Para consultar as injeções de dependencias o arquvio ORDER.API/Extensions/ServiceCollectionExtensions

Os testes pedidos dentro do README.md estão implementados dentro dos testes unitários

Optei por não realizar testes unitários para criação de pedidos devido a ser um CRUD basico
acredito que o ideial é testar a regra de negocio, por isso a StatusService esta com 100% de 
cobertura de testes
```