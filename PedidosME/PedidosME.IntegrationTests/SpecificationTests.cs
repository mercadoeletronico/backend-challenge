using MediatR;
using MercadoEletronico.Utilities.Bus;
using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PedidosME.BusServices;
using PedidosME.Data.DataContext;
using PedidosME.Data.Repositories;
using PedidosME.Domain.Entities.PedidoAggregate;
using PedidosME.Domain.PedidoAggregate.Entities;
using PedidosME.Domain.Services;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PedidosME.IntegrationTests
{
    public class SpecificationTests
    {
        private readonly ServiceProvider services;
        public SpecificationTests(ITestOutputHelper output)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.TestOutput(output)
            .CreateLogger();

            

            services = new ServiceCollection().
                AddDbContext<DbContext, PedidosMEDbContext>(opt => opt.UseInMemoryDatabase("PedidosME"))
                .AddScoped(typeof(IGenericRepository<>), typeof(DefaultRepository<>))
                .AddScoped<IPedidoRepository, PedidoRepository>()
                .AddScoped<IPedidoServices,PedidoServices>()
                .AddSingleton<IBusServices, BusProvider>()
                .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddLogging()
                .BuildServiceProvider();

            
        }

        [Fact(DisplayName = "Aprovar Pedido passando quantidade e valor total corretos")]
        public async Task Solicitacao_Aprovado_Com_QTD_E_Valor_Igual_Ao_Pedido_Deve_Ser_Aprovado()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();
            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }
            

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456",
                    ItensAprovados = 3,
                    ValorAprovado = 20,
                    Status = "APROVADO"
                },
                token);

            Assert.True(result.Status.FirstOrDefault() == "APROVADO");
        }

        

        [Fact(DisplayName = "Aprovar pedido com valor menor que o valor do Pedido")]
        public async Task Solicitacao_Aprovado_Com_Valor_Menor_Deve_Ser_Aprovado_Valor_A_Menor()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();

            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456",
                    ItensAprovados = 3,
                    ValorAprovado = 10,
                    Status = "APROVADO"
                },
                token);

            Assert.True(result.Status.FirstOrDefault() == "APROVADO_VALOR_A_MENOR");
        }

        [Fact(DisplayName = "Aprovar pedido com valor a maior e quantidade a maior que o pedido original")]
        private async Task Solicitacao_Aprovado_Com_Valor_E_Quantidade_Maior_Deve_Conter_2_Status_A_Maior()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();

            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456",
                    ItensAprovados = 4,
                    ValorAprovado = 21,
                    Status = "APROVADO"
                },
                token);


            Assert.True(result.Status.Count() == 2);

            string[] status = new string[]{ "APROVADO_VALOR_A_MAIOR", "APROVADO_QTD_A_MAIOR" };
            foreach (var s in result.Status)
            {
                Assert.Contains<string>(s,status);
            }
        }
        [Fact(DisplayName = "Aprovar pedido com quantidade menor que a do Pedido")]
        public async Task Solicitacao_Aprovado_Com_QTD_Menor_Deve_Ser_Aprovado_QTD_A_Menor()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();

            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456",
                    ItensAprovados = 2,
                    ValorAprovado = 20,
                    Status = "APROVADO"
                },
                token);

            Assert.True(result.Status.FirstOrDefault() == "APROVADO_QTD_A_MENOR");
        }

        [Fact(DisplayName = "Reprovar pedido deve retornar Reprovado")]
        public async Task Solicitacao_Reprovado()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();

            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456",
                    ItensAprovados = 0,
                    ValorAprovado = 0,
                    Status = "REPROVADO"
                },
                token);

            Assert.True(result.Status.Count() == 1);
            Assert.True(result.Status.FirstOrDefault() == "REPROVADO");
        }

        [Fact(DisplayName = "Aprovar pedido que não existe deve retornar Pedido Inválido")]
        public async Task Solicitacao_Aprovado_Para_Pedido_Invalido()
        {
            var token = new CancellationTokenSource().Token;
            var pedidoRep = services.GetService<IGenericRepository<Pedido>>();

            var pedido = await pedidoRep.GetByKeysAsync(token, "123456");
            if (pedido == null)
            {
                await AdicionarPedidoBase(pedidoRep, token);
            }

            var pedidoServices = services.GetService<IPedidoServices>();
            var result = await pedidoServices.DefinirStatusPedido(
                new Domain.DTOs.AtualizarStatusDTO()
                {
                    pedido = "123456-N",
                    ItensAprovados = 3,
                    ValorAprovado = 2,
                    Status = "APROVADO"
                },
                token);

            Assert.True(result.Status.Count() == 1);
            Assert.True(result.Status.FirstOrDefault() == "CODIGO_PEDIDO_INVALIDO");
        }

        private static async Task AdicionarPedidoBase(IGenericRepository<Pedido> pedidoRep, CancellationToken token)
        {
            await pedidoRep.AddAsync(new Pedido("123456",
                            new List<ItemPedido>()
                            {
                    ItemPedido.Criar("123456","Produto 1",10,1),
                    ItemPedido.Criar("123456","Produto 2",5,1),
                    ItemPedido.Criar("123456","Produto 2",5,1)
                            }), token);

            await pedidoRep.CommitAsync(token);
        }
    }
}
