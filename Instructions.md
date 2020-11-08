<img src="images\me.svg" width="200" alt="ME">

# Back-end Challenge

Explicação da solução apresentada!

## :white_check_mark: Visão Geral

Embora a solução do problema apresentado fosse muito simples, a idéia neste projeto foi demonstrar como pode ser a arquitetura e modelagem de uma aplicação com alta complexidade devido ao alto consumo de seus endpoints e que sofrem mudanças constantemente. 

Por isso, a arquitetura escolhida foi "Ports and Adapters", inspirada na "Arquitetura Hexagonal". 
Conforme o post: [DDD, Hexagonal, Onion, Clean, CQRS, … How I put it all together](https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/ "Herberto Graça"). 
Dessa forma possuímos no  núcleo da aplicação o nosso Domínio e o mesmo é propagado para camadas mais externas *(Domain Services e Application Services)* por meio de "Adaptadores" *(interfaces)* e implementadas por "Portas". Da mesma fora componentes externos, tratados geralmente como sendo de "Infraestrutura" também podem ser plugados nessas camadas. 

## :cake: Camadas da Aplicação

<img src="images\Solution Layers.png" alt="Layers"> 

__Através deste diagrama podemos identificar as responsábilidades de cada camada.__ 

1. **WebAPI**: é a camada mais externa da aplicação, responsável por realizar o carregamento da aplicação como um todo e por isso além de mapear, receber e redirecionar as  Web Requests essa camada também é responsável por orquestrar a configuração de todo o ambiente da aplicação e dar vazão a exceções ocorridas. 
2. **Domain**: é a camada mais interna da aplicação, responsável por modelar as entidades e garantir exatidão das regras de negócio, esta camada também orquestra a persistência dos dados, sendo assim expõe uma interface com os métodos necessários para realizar a persistência ou consulta de dados persistidos no banco. Esta interface é implementada pela camada de Acesso a dados.
3. **Infra**: É uma camada de suporte, responsável por agrupar features que o domínio consome de forma a separar melhor responsábilidades. Assim o domínio pode se manter mais leve e focado no negócio e delegar responsábilidades para infra, tais como: acesso a dados, enfileiramento de requisições e outros.
4. **Utilities**: É também uma camada de suporte porém mais leve, responsável por agrupar funcionalidades que qualquer uma das outras camadas possa vir a utilizar, porém deve haver cuidado para que soluções de Infra não acabem migrando para essa camada, o que causaria um forte acoplamento das demais camadas com questões de Infra.


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
..* Onde ValidationResult é uma estrutura de dados da API FluentValidation.
* Propriedade ID que recebe um GUID no momento que o objeto for construído.
* Override de Equal garante que a entidade poderá ser comparada com outra através do ID ainda que suas referências sejam diferentes.
* Override de GetHashCode que torna-se obrigatório uma vez a o método Equals foi sobre escrito.

