<img src="me.svg" width="200" alt="ME">

# Back-end Challenge

Bem-vindo(a) ao nosso teste para desenvolvedores(as) back-end.

## :clipboard: Instruções

1. Faça o fork e clone esse repositório.
2. Trabalhe no que foi solicitado.
3. Crie um arquivo chamado `instructions.md` com todas as informações necessárias para executar sua aplicação.
4. Faça um pull request com o seu código e qualquer outro artefato que você julgue necessário, ou se preferir, envie um link direto para o seu repositório, se for privado lembre-se de dar o acesso necessário.
5. Notifique por e-mail a pessoa responsável por seu processo seletivo no Mercado Eletrônico.

## :dart: O que vamos avaliar? O que buscamos?

Queremos entender como você modela um problema e o transforma em código, como você estrutura, como você testa. Enviar uma aplicação funcionando é o ideal, mas mesmo que não esteja 100 % envie o código para que possamos analisar até onde você chegou. 

O problema que vamos apresentar não tem uma lógica complexa, mas implemente seu código pensando em um sistema extensível e de alta concorrência no uso, é muito importante que você aplique SOLID em tudo que fizer.

## :computer: Tecnologias

1. Nossa stack de desenvolvimento é predominantemente C# e Java, então nossa sugestão é que você utilize .NET Core para C# ou Spring para Java.
2. Teste seu código, crie Unit tests e/ou Integration tests.
3. A aplicação deve ser self contained, use um database em memória, por exemplo o H2 no caso do Spring. 

## :zap: O Desafio

Você deve construir uma API que terá dois endpoints:

###	Endpoint – Pedido

Sua aplicação deve expor em `http://localhost:{porta}/api/pedido` uma API RESTful. (GET, POST, PUT, DELETE)

O conteúdo de um Pedido possui o seguinte payload:

```json
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

O conteúdo desse Pedido e Itens deverá ser persistido em banco de dados. Fique à vontade para criar as validações que você considerar necessárias.

###	Endpoint – Mudança de Status de Pedido

Sua aplicação deve receber um POST em `http://localhost:{porta}/api/status` com o seguinte payload:

```json
{
  "status":"XXX",
  "itensAprovados":0,
  "valorAprovado":0,
  "pedido":"XXX"
}
```

E terá o seguinte response, baseado nas regras detalhadas a seguir:

```json
{
  "pedido":"123456",
  "status": ["STATUS_1", "STATUS_2", "STATUS_...n"]
}
```

O status não precisa ser persistido em banco de dados, basta retornar na API.

Exemplos de requests e responses baseados no payload do pedido descrito anteriormente:

#### #1

*request*
```json
{
  "status":"APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 20,
  "pedido":"123456"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["APROVADO"]
}
```

#### #2

*request*
```json
{
  "status":"APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 10,
  "pedido":"123456"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["APROVADO_VALOR_A_MENOR"]
}
```

#### #3

*request*
```json
{
  "status":"APROVADO",
  "itensAprovados": 4,
  "valorAprovado": 21,
  "pedido":"123456"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR"]
}
```

#### #4

*request*
```json
{
  "status":"APROVADO",
  "itensAprovados": 2,
  "valorAprovado": 20,
  "pedido":"123456"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["APROVADO_QTD_A_MENOR"]
}
```

#### #5

*request*
```json
{
  "status":"REPROVADO",
  "itensAprovados": 0,
  "valorAprovado": 0,
  "pedido":"123456"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["REPROVADO"]
}
```

#### #6

*request*
```json
{
  "status":"APROVADO",
  "itensAprovados": 3,
  "valorAprovado": 20,
  "pedido":"123456-N"
}
```
*response*
```json
{
  "pedido":"123456",
  "status": ["CODIGO_PEDIDO_INVALIDO"]
}
```

### :pencil: Lógica de Negócio

**Dado (Given)** o status **Quando (When)**

    pedido não for localizado no banco de dados.

**Então (Then)** retorne

```json
{
  "status": "CODIGO_PEDIDO_INVALIDO"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    status for igual a REPROVADO

**Então (Then)** retorne

```json
{
  "status": "REPROVADO"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    itensAprovados for igual a quantidade de itens do pedido.

    valorAprovado for igual o valor total do pedido.

    status for igual a APROVADO.

**Então (Then)** retorne

```json
{
  "status": "APROVADO"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    valorAprovado for menor que o valor total do pedido

    status for igual a APROVADO

**Então (Then)** retorne

```json
{
  "status": "APROVADO_VALOR_A_MENOR"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    itensAprovados for menor que a quantidade de itens do pedido.

    status for igual a APROVADO

**Então (Then)** retorne

```json
{
  "status": "APROVADO_QTD_A_MENOR"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    valorAprovado for maior que o valor total do pedido

    status for igual a APROVADO

**Então (Then)** retorne

```json
{
  "status": "APROVADO_VALOR_A_MAIOR"
}
```

-----

**Dado (Given)**  o status **Quando (When)**

    pedido for localizado no banco de dados.

    itensAprovados for maior que a quantidade de itens do pedido.

    status for igual a APROVADO

**Então (Then)** retorne

```json
{
  "status": "APROVADO_QTD_A_MAIOR"
}
```

-----

#### Informações finais

Uma tentativa de mudança de status deverá passar por todas essas regras descritas e a API deverá retornar todos os status gerados, observe que as validações são compartilhadas entre as regras, reutilize código (**DRY**).

Observe que:

1. O valor total do pedido é composto pela somatória do valor calculado de cada item (precoUnitario * qtd).

2. A quantidade total de itens do pedido é composta pela somatória da qtd de cada item.
