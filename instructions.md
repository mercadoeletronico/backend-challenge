# Desafio Back-end

Obrigado pela oportunidade!



#### Requisitos para rodar e testar o projeto:

- Visual Studio 2019
- DotnetCore 3.1
- Insomnia



#### Passo a passo

- ###### Visual Studio - Rodar a Aplicação

Clonar o repositório e abrir a solution no visual studio 2019.

E rodar a aplicação apertando F5 ou clicando no botão:

![image-20201030181002830](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030181002830.png) ou ![image-20201030181035033](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030181035033.png)

O Endpoint configurado para rodar no IIS Express é a "http://localhost:7922/api"

Sem o IIS o Endpoint é "http://localhost:5000/api"



- ###### Visual Studio - Testes

Foram desenvolvidos 14 testes unitários para validar o projeto domínio. Os testes foram escolhidos de acordo com a especificação de negócio de mudança de status e a integridade da entidade Pedido.

![image-20201030175533948](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030175533948.png)

Para rodar os testes, dentro do Visual Studio, clique em testes e depois "Run all tests"

![image-20201030182421594](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030182421594.png)



- ###### Insomnia

Para testar a API com o insomnia, importe o arquivo "Insomnia_2020-10-30.json" que está na pasta "insomnia" deste repositório. Nele consta o Workspace com os ambientes criados e os métodos para teste.

Para isso, basta clicar nas áreas destacadas na imagem

![image-20201030182029497](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030182029497.png)



Requests disponíveis no Workspace do Insomnia.

![image-20201030180050843](C:\Users\PH\AppData\Roaming\Typora\typora-user-images\image-20201030180050843.png)









#### Considerações e decisões

Foi desenvolvido um CRUD simples para o Pedido e a regra de negócio para aprovação do Pedido.

Além disso, adicionei algumas validações de integridade na entidade Pedido para não permitir quantidade ou valor menor que zero, para os itens do pedido. Seria interessante confirmar essa regra de negócio, mas para o desafio assumi que só seria possível valores positivos.

Quando a entidade Pedido não é válida, é retornada a seguinte mensagem para os verbos, post, put e delete.

*{*
  *"pedido": "1234567",*
  *"mensagem": "Pedido Inválido"*
*}*

A camada Core da solution, ficou apenas com os contratos e interface de marcação.

Criei um atributo ID tipo Guid para evitar conflitos na persistência dos itens do pedido.

##### 



