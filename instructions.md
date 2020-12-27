# Desafio ME

### Pré-requisitos
- Microsoft .Net Core SDK 3.1.XXX instalado 

### Passo-a-Passo
- Baixar o código;
- A solution está localizado em src/API;
- Realizar o build para baixar os pacotes do nuget;
- Executar os testes(integração e unitários);
- Clicar com o botão direto no projeto API e selecionar a opção "Set as Startup Project"
- Executar o projeto

O projeto será inicializado exibindo página do swagger com os endpoins de Pedido e Mudança de Status de Pedido disponíveis.

Vale ressaltar, que foi gerado o migration com os cenários expostos no git. Desta forma, é possível realizar os testes dos cenários através da rota "/api/status".

### Check-list
- .Net Core 3.1
- Arquitetura CQRS - escolhido por entender que nesse cenário haverá mais leitura do que escrita;
- SOLID;
- Padrões de projeto;
- Clean Code;
- Dapper in memory;
- Unit Tests;
- Integration Tests.

Quais dúvidas, estarei à disposição.



