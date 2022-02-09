<img src="me.svg" width="200" alt="ME">

# Introdução

A API desenvolvida neste desafio contém uma solução monolítica baseada na Clean Architecture e utiliza alguns conceitos do SOLID, como, por exemplo, o Dependency Inversion Principle (Princípio da inversão da dependência), pois a camada MercadoEletronicoAPI.Domain não depende de nenhuma outra camada. Todos os projetos contidos na solution utilizam o framework .Net 5.0.

O ORM utilizado na aplicação é o Entity Framework In Memory, e como o próprio nome sugere, não é necessária instalação de nenhum mecanismo de banco de dados, pois o mesmo é criado em memória durante execução da aplicação.

## CRUD em Pedidos (Orders):

1. Obter todos os pedidos. Caso não exista, retorna um array vazio.
2. Obter pedido pelo código do pedido: valida se existe o pedido com o código informado.
3. Cadastrar pedido: valida se o código do pedido informado já existe em outro pedido na base de dados. Em caso afirmativo não realiza o cadastro e retorna "Order code already exists."
4. Atualizar pedido: valida se existe pedido na base de dados que corresponda ao código do pedido informado na requisição. Em caso negativo retorna "CODIGO_PEDIDO_INVALIDO".
5. Deletar pedido: valida se existe pedido na base de dados que corresponda ao código do pedido informado na requisição. Em caso negativo retorna "CODIGO_PEDIDO_INVALIDO".

## Testes
Todos os itens de lógica de negócio solicitados no desafio foram implementados e podem ser testados através do consumo da API utilizando o Postman ou o próprio Swagger disponível na aplicação, e também podem ser testados através dos testes disponíveis na classe StatusServiceTest.

Alguns testes unitários também foram implementados para a entidade Order (pedido) e estão disponíveis na classe OrderUnitTest.

Ao executar a aplicação, o próprio sistema insere alguns pedidos e itens fictícios no banco de dados em memória para facilitar os testes e consumo dos endpoints. Esta inserção ocorre na classe FakeContext.cs.
