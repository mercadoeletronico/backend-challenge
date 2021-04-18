using MercadoEletronico.Challenge.Domain.Models.Entities;
using MercadoEletronico.Challenge.Domain.Services.Interfaces.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.DataAccess.Repositories
{
    public class PedidoRepository: Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DatabaseContext context) 
            : base(context)
        {
        }

        protected override IIncludableQueryable<Pedido, object> DefaultInclusions(DbSet<Pedido> dbSet)
        {
            return dbSet.Include(p => p.Itens);
        }

        public override async Task UpdateAsync(Pedido @object) 
        {
            var entity = await DefaultInclusions(_context.Pedidos)
                .FirstOrDefaultAsync(p => p.Id == @object.Id);

            if (entity is null)
            {
                throw new ArgumentException($"Entity '{@object.GetType().Name}' with id {@object.Id} was not found");
            }

            entity.Itens = @object.Itens;

            await _context.SaveChangesAsync();
        }
    }
}
