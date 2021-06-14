using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaAplicacao.Infraestrutura.Repositorios
{
    public class PedidoRepositorio : RepositorioBase<int, Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(MinhaAplicacaoDbContext contexto)
            : base(contexto)
        {
        }

        public async Task<Pedido> SelecionarPorNumero(string numero, params Expression<Func<Pedido, object>>[] propriedades)
        {
            return await this.SelecionarPor(u => u.Numero.Equals(numero), propriedades)
                             .FirstOrDefaultAsync();
        }
    }
}
