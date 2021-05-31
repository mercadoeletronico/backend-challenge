## Tecnologia e Design partten
1. Net 5.0
2. EF Core 5.0
3. AutoMapper
4. FluentValidator
5. MediatR
6. Swagger UI
7. UnitOfWork
8. Domain Driven Design
9. SOLID 
10. Clean Code
11. Domain Validations
12. CQRS (parte)

## Comandos Runs
Projeto foi criado para usar tanto o VS code como o Visual studio.

Projeto principal ME.PurchaseOrder.API para rodar
```
dotnet run --project ME.PurchaseOrder.API\ME.PurchaseOrder.API.csproj 
```
Para rodar os testes, será necessario que o projeto "ME.PurchaseOrder.API\ME.PurchaseOrder.API" esteje em execução via console.
```
dotnet test 
```
ou se preferir gerar o relatório de coverage.
```
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```
