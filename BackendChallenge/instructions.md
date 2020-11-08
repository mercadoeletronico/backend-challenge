
### :pencil: Instruções

#### #1 Pré-requisitos

* .NET Core 3.1 SDK or later

#### #2 Executar testes de aceite

```
dotnet test ./BackendChallenge/tests/BackendChallenge.AcceptanceTests/BackendChallenge.AcceptanceTests.csproj -v n
```

#### #3 Executar serviço web

```
dotnet run --project ./BackendChallenge/source/app/BackendChallenge.Api/BackendChallenge.Api.csproj
```

Acesse a documentação da api em https://localhost:5001/swagger