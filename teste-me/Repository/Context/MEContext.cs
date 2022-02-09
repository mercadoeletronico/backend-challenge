using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_me.Models;

namespace teste_me.Repository.Context
{
    public class MEContext : DbContext
    {
        public MEContext(DbContextOptions<MEContext> options)
            : base(options)
        {}
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
