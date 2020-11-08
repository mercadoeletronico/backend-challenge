using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PedidosME.Data.DataContext;
using PedidosME.Domain.PedidoAggregate.Entities;
using System.Linq;
using System;
using Xunit;
using PedidosME.Data.Repositories;
using PedidosME.Domain.Entities.PedidoAggregate;
using System.Threading.Tasks;
using System.Threading;

namespace PedidosME.IntegrationTests
{
    public class DatabaseTests
    {
        private readonly ServiceProvider services;
        public DatabaseTests()
        {
            services = new ServiceCollection().
                AddDbContext<DbContext, PedidosMEDbContext>(opt => opt.UseInMemoryDatabase("PedidosME"))
                .AddScoped(typeof(IGenericRepository<>),typeof(DefaultRepository<>))
                .AddScoped<IPedidoRepository,PedidoRepository>()
                .BuildServiceProvider();

        }
        [Fact(DisplayName ="Validar se banco de dados foi semeado")]
        public async Task Instanciar_ContextoDoBanco()
        {
            //Teste com Repositório Genérico
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();
            var itemPedidoRep = services.GetService<IGenericRepository<ItemPedido>>();
            var pedidos = pedidoRep.GetAll(noTracking: true, includeProperties: "Itens");
            var itemsPedido = itemPedidoRep.GetAll();
            Assert.True(pedidos.Any());
            var token = new CancellationTokenSource();
            await pedidoRep.AddAsync(Pedido.Criar("xadd1"), token.Token);
            await itemPedidoRep.AddAsync(ItemPedido.Criar("xadd1", "teste", 1, 1),token.Token);
            await itemPedidoRep.CommitAsync(token.Token);
            var pedido = pedidoRep.GetAll(filter: x => x.Codigo == "xadd1").FirstOrDefault();
            Assert.True(pedido.Itens.Any());
            Assert.True(itemsPedido.Any());
        }

        [Fact(DisplayName = "Validar se Itens de pedido estão associados ao pedido")]
        public async Task Obter_Itens_De_Pedido()
        {
            //Teste com Repositório específico
            var pedidoRep = services.GetService<IPedidoRepository>();
            var pedido = await pedidoRep.ObterPedidoPorCodigo ("123456", new CancellationTokenSource().Token);
            Assert.True(pedido.Itens.Count() == 3);
        }

        

    }
}
