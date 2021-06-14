using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Infraestrutura.Mapeamentos;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinhaAplicacao.Infraestrutura
{
    public class MinhaAplicacaoDbContext : DbContext
    {
        public MinhaAplicacaoDbContext(DbContextOptions<MinhaAplicacaoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configurações Básicas

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion

            #region Configurações Entidades

            modelBuilder.ApplyConfiguration(new PedidoMapeamento());
            modelBuilder.ApplyConfiguration(new ItemItemPedidoMapeamento());

            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHoraCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHoraCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraModificado") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataHoraModificado").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataHoraCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
