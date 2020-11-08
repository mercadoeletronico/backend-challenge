<img src="me.svg" width="200" alt="ME">

# Back-end Challenge

Explicação da solução apresentada!

## :white_check_mark: Visão Geral

Embora a solução do problema apresentado fosse muito simples, a idéia neste projeto foi demonstrar como pode ser a arquitetura e modelagem de uma aplicação com alta complexidade devido ao alto consumo de seus endpoints, além disso, um código bem estruturado e com suas camadas bem delimitadas facilita a manutenção e ampliação. 

Por isso, a arquitetura escolhida foi "Ports and Adapters", inspirada na "Arquitetura Hexagonal". 
Conforme o post: [DDD, Hexagonal, Onion, Clean, CQRS, … How I put it all together](https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/ "Herberto Graça"). 
Dessa forma possuímos no  núcleo da aplicação o nosso Domínio e o mesmo é propagado para camadas mais externas *(Domain Services e Application Services)* por meio de "Adaptadores" *(interfaces)* e implementadas por "Portas". Da mesma fora componentes externos, tratados geralmente como sendo de "Infraestrutura" também podem ser plugados nessas camadas. 

## :cake: Camadas da Aplicação PedidosME

<img src="images\Solution Layers.png" alt="Layers"> 

__Através deste diagrama podemos identificar as responsabilidades de cada camada.__ 

1. **WebAPI**: é a camada mais externa da aplicação, responsável por realizar o carregamento da aplicação como um todo e por isso além de mapear, receber e redirecionar as  Web Requests essa camada também é responsável por orquestrar a configuração de todo o ambiente da aplicação e dar vazão a exceções ocorridas. 
2. **Domain**: é a camada mais interna da aplicação, responsável por modelar as entidades e garantir exatidão das regras de negócio, esta camada também orquestra a persistência dos dados, sendo assim expõe uma interface com os métodos necessários para realizar a persistência ou consulta de dados persistidos no banco. Esta interface é implementada pela camada de Acesso a dados.
3. **Infra**: É uma camada de suporte, responsável por agrupar *features* que o domínio consome de forma a separar melhor responsabilidades. Assim o domínio pode se manter mais leve e focado no negócio e delegar responsabilidades para infra, tais como: acesso a dados, enfileiramento de requisições e outros.
4. **Utilities**: É também uma camada de suporte porém mais leve, responsável por agrupar funcionalidades que qualquer uma das outras camadas possa vir a utilizar, porém deve haver cuidado para que soluções de Infra não acabem migrando para essa camada, o que causaria um forte acoplamento das demais camadas com questões de Infra.

## :exclamation: Instruções para execução
* Mantenha o projeto PedidosME como Startup Project, o Swagger foi incluido e esta configurado no launchsettings.json.
* O banco de dados utilizado foi InMemmory e o mesmo já é carregado com alguns dados semeados. Os dados semeados estão no Projeto: PedidosME.Data, classe SeedExtensions 

<img src="images\seedExtensions.png" alt="Seed"> 

Existem três pedidos previamente criados, o pedido "123456" possui características semelhantes aos casos de teste apresentado no desafio para mudança de status.

## :zap: Patterns e APIs utilizados 

* Asynchronous Programming: Todas as WebRequests são assíncronas e transmitem o CancellationToken até as camadas mais internas permitindo que solicitações long running seja canceladas, garantindo melhor performance ao servidor.

* Interface Segregation Principle: Os métodos e comportamentos que precisam ser acessados por outros projetos são expostos através de Interfaces bem definidas com escopo limitado. 

* Repository Pattern: Regras de negócio que dependem e precisam ser persistidas foram encapsuladas dentro da interface IPedidoRepository.cs esta interface é implementada no projeto de Infra específico para acesso a dados. 

* Depnedency Injection: O projeto MercadoEletronico.Utilities.DependencyInjection possui uma classe capaz de ser plugada na startup.cs para configurar o ServiceCllection e resolver todas as dependências.

* Serilog: Serilog está configurado para funcionar em todas as camadas por meio de injeção de dependência. 

* Observer e Observable Pattern: pro meio do Mediatr, as WebRequests recebidas na API são lançadas para o manipulador de eventos dentro da camada de negócio mantendo o acoplamento baixo e com alta responsividade, inclusive permitindo mais de um manipulador para a mesma request. Também apenas para demonstração foi criado um evento ao consultar um pedido. Nas imagens a seguir podemos ver a implementação do evento. 

<img src="images\pedido_event.png" alt="Evento de Pedido"> 

<img src="images\event_publishing.png" alt="Evento Publicado"> 

<img src="images\event_handling.png" alt="Evento Manipulado"> 

O resultado final é apresentado no console do Kestrel, quando um pedido é consultado.

<img src="images\bus_message.png" alt="Bus"> 

* SpecificationPattern: Para atender o requisito de mudança de status do desafio uma classe de Specification foi criada dentro do Aggregate de Pedido. A classe StatusPedido especifica por meio de *predicados* quis características um pedido deve atender para ser considerado de um determinado status.

## :zap: Detalhes da solução

<img src="images\folders.png" alt="Pastas"> 

A solution está dividida em pastas conforme a imagem. 

Começando pela pasta Domínio, podemos observar a organização do código conforme imagem. 

<img src="images\folders_domain.png" alt="Pastas do Domínio"> 

Na pasta Entitity está a organização de entidades para este projeto.

Na pasta Core foi criada a Entidade Base que deve deve ser implementada pelas demais entidades

<img src="images\folders_domain_opened.png" alt="Pastas do Domínio"> 
<img src="images\Entity.png" alt="Entity"> 

Pode-se notar nesta entidade que é uma classe abstrata, as demais entidades, no caso Pedido e PedidoItem implementam esta classe. 
Sendo assim todas as entidades possuem as seguintes características:
* Propriedades "IsValid" e "ValidationResult" que devem ser implementadas 
  * Onde ValidationResult é uma estrutura de dados da API FluentValidation.
* Propriedade ID que recebe um GUID no momento que o objeto for construído.
* Override de Equals garante que a entidade poderá ser comparada com outra através do ID ainda que suas referências sejam diferentes.
* Override de GetHashCode que torna-se obrigatório uma vez a o método Equals foi sobre escrito.

<img src="images\pedido_aggregate.png" alt="Entity"> 

A pasta PedidoAggregate contém as entidades relacionadas para atender os requisitos do desafio. 
A pasta Validators contém regras de validação com FluentValidation, algumas regras simples foram criadas apenas para demonstrar sua utilização. 
As regras são validadas no construtor de cada entidade e o resultado da validação armazenado na propriedade ValidationResult
A propriedade IsValid contém  uma regra simples, caso não hajam mensagem IsValid será "true".

<img src="images\Entidade_Pedido.png" alt="Entidade Pedido"> 

## :dart: Testes 

<img src="images\testes.png" alt="Testes"> 

Foram criados dois projetos de testes utilizando-se Xunit, um projeto para testes de unidade e outro para testes de integração.
Neste caso os testes de unidade basicamente testam as validações das entidades.
Já os testes de integração estão divididos em testes relacionados a operações CRUD, arquivo DatabaseTest.cs. E testes relacionados a regra de negócio para mudança de status dos pedidos, arquivo SpecificationTests.cs 

<img src="images\testes_executados.png" alt="Testes Executados">  

## :pray: Agradecimento 

Agradeço a oportunidade de demonstrar um pouco do meu conhecimento neste projeto. 
Fico feliz e estou a disposição para debater esta solução!
