using Core.Interfaces.Repositories;
using Infra.Data.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Data
{
    public class PedidoRepositoryTest : RepositoryTest
    {
        public readonly IPedidoRepository pedidoRepository;
        public PedidoRepositoryTest() => this.pedidoRepository = new PedidoRepository(this.Context);
    }
}
