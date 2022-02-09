# Baixar o SDK do .NET 5.0 de acordo com o sistema operacional

Link: <a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">.NET 5.0</a>

# Baixar o executável no Google Drive
Link <a href="https://drive.google.com/file/d/1YpeeZ56-eiAeED6hFJxZ2DvZ6gupup6d/view?usp=sharing">ME-backend-challenge</a>

## Rodando a aplicação
1. Descompactar os arquivos, coloquei como Zip porque o Windows já reconhece os arquivos sem a necessidade de instalar outro compactador.

2. Clicar no arquivo <b>teste-me.exe</b>
	Deverá aparecer o console da seguinte maneira, confome imagem abaixo:
	<img src="https://cdn.discordapp.com/attachments/886407612537663488/941049728349659246/unknown.png">
3. Acessar a URL: http://localhost:5000/swagger

4. Caso o Navegador apresente alguma restrição de acesso, você deverá permitir, pois o SSL não está configurado, conforme imagem abaixo.

	<img src="https://cdn.discordapp.com/attachments/886407612537663488/941050632083738715/unknown.png">

5. Clique em avançado e depois em Continue até localhost

6. Deverá abrir o Swagger, por padrão uma aplicação publicada não permite a exibição, mas eu deixei para facilitar a interação com o sistema. A interface do swagger está abaixo:

	<img src="https://cdn.discordapp.com/attachments/886407612537663488/941051342246514688/unknown.png">

## Interagindo com a aplicação pelo Swagger

1. Para cadastrar um Pedido,
clique no [POST]/api/Pedido, em seguida em "Try it out", preencha os dados do pedido conforme o arquivo Json e depois clique em Execute.

Abaixo, um exemplo de um objeto de Pedido

```json
{
  "pedido":"123456",
  "itens": [
  {
    "descricao": "Item A",
    "precoUnitario": 10,
    "quantidade": 1
  },
  {
    "descricao": "Item B",
    "precoUnitario": 5,
    "quantidade": 2
  }
  ]
}
```

2. Para consultar todos os Pedido, 
clique no [GET] /api/Pedido, em seguida em "Try it out" e depois clique em Execute.

3. Para consultar um Pedido específico,
clique no [GET]/api/Pedido/{id}, em seguida em "Try it out", forneça o número do Pedido e depois clique em Execute.

4. Para atualizar um Pedido específico,
clique no [PUT]/api/Pedido/{id}, em seguida em "Try it out", forneça o número do Pedido que deseja alterar e os itens que deseja alterar e depois clique em Execute.


5. Para deletar um Pedido específico,
clique no [DELETE]/api/Pedido/{id}, em seguida em "Try it out", forneça o número do Pedido e depois clique em Execute.

Abaixo o exemplo de um objeto de Pedido que foi deletado
	<img src="https://cdn.discordapp.com/attachments/886407612537663488/941054264753684490/unknown.png">

### O Swagger apresenta as respostas por meio do conteúdo exibido em Reponse Body e Reponse Headers.

6. Para acompanhar a Mudança de Status de um pedido,

clique no [POST]/api/Status,  em seguida em "Try it out", preencha os dados do, status, pedido, itens aprovados e valor aprovado, conforme o arquivo Json e depois clique em Execute.

Abaixo, um exemplo do objeto para Mudança de Status

```json
{
  "status": "APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 20,
  "pedido": 123456
}
```

Para encerrar a aplicação, vá até o console onde está aberta e precione CTRL + C




### Referências

https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
http://www.macoratti.net/17/08/efcore_inmemo1.htm
https://medium.com/desenvolvendo-com-paixao/o-que-%C3%A9-solid-o-guia-completo-para-voc%C3%AA-entender-os-5-princ%C3%ADpios-da-poo-2b937b3fc530
http://www.macoratti.net/19/09/aspnc_utst1.htm
http://www.macoratti.net/19/09/aspc_utst2.htm
https://xunit.net/docs/getting-started/netcore/cmdline

PS: não consegui rodar os testes fora do Visual Studio :(
PS2: não consigo mudar o nome do atributo da classe item de quantidade para qtd :P

