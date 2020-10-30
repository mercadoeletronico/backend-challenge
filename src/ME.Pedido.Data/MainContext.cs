using System;
using System.Linq;
using System.Threading.Tasks;
using ME.Core.Data;
using ME.Pedido.Domain;
using Microsoft.EntityFrameworkCore;

namespace ME.Pedido.Data
{
    public class MainContext : DbContext, IUnitOfWork
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }


        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);

        //    //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
