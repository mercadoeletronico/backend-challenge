using MercadoEletronico.Utilities.Data;
using Microsoft.EntityFrameworkCore;
using PedidosME.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedidosME.Data.Repositories
{
    public class DefaultRepository<T> : GenericRepository<T> where T : class
    {
        public DefaultRepository(DbContext context) : base(context)
        {
            context.Database.EnsureCreated();
        }
    }
}
