using Core.Entities.Pedido;
using Core.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Dapper.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        #region properties
        private IDatabaseContext _context;
        #endregion

        #region constructors
        public PedidoRepository(IDatabaseContext context)
        {
            _context = context;
        }
        #endregion

        #region actions Pedido
        public Task<IEnumerable<Pedido>> GetByCodigoAsync(string codigo)
        {
            var pedidoDictionary = new Dictionary<long, Pedido>();
            return _context.Connection.QueryAsync<Pedido, ItemPedido, Pedido>($"SELECT Pedido.PedidoId, Pedido.Codigo,ItemPedido.ItemPedidoId, ItemPedido.PedidoId, ItemPedido.Descricao, ItemPedido.Quantidade, ItemPedido.PrecoUnitario FROM Pedido inner join ItemPedido ON Pedido.PedidoId = ItemPedido.PedidoId where Pedido.Codigo = {codigo}",
                 (pedido, itemPedido) =>
                 {
                     Pedido pedidoEntry;

                     if (!pedidoDictionary.TryGetValue(pedido.PedidoId, out pedidoEntry))
                     {
                         pedidoEntry = pedido;
                         pedido.Itens = new System.Collections.Generic.List<ItemPedido>();
                         pedidoDictionary.Add(pedidoEntry.PedidoId, pedidoEntry);
                     }

                     pedidoEntry.Itens.Add(itemPedido);
                     return pedidoEntry;
                 }, splitOn: "PedidoId");         
        }

        public Task<IEnumerable<Pedido>> GetAllAsync()
        {
            var pedidoDictionary = new Dictionary<long, Pedido>();
            return _context.Connection.QueryAsync<Pedido, ItemPedido, Pedido>($"SELECT Pedido.PedidoId, Pedido.Codigo,ItemPedido.ItemPedidoId, ItemPedido.PedidoId, ItemPedido.Descricao, ItemPedido.Quantidade, ItemPedido.PrecoUnitario FROM Pedido inner join ItemPedido ON Pedido.PedidoId = ItemPedido.PedidoId",
                 (pedido, itemPedido) =>
                 {
                     Pedido pedidoEntry;

                     if (!pedidoDictionary.TryGetValue(pedido.PedidoId, out pedidoEntry))
                     {
                         pedidoEntry = pedido;
                         pedido.Itens = new System.Collections.Generic.List<ItemPedido>();
                         pedidoDictionary.Add(pedidoEntry.PedidoId, pedidoEntry);
                     }

                     pedidoEntry.Itens.Add(itemPedido);
                     return pedidoEntry;
                 }, splitOn: "PedidoId");
        }

        public Task<IEnumerable<Pedido>> AddAsync(Pedido entity)
        {
            _context.Connection.ExecuteScalarAsync($"Insert into Pedido (Codigo) values ({entity.Codigo})");            
            
            entity.PedidoId = GetPedidoIdByCodigo(entity.Codigo);           
            AddItemPedidoAsync(entity);

            return GetByCodigoAsync(entity.Codigo);
        }

        public Task<IEnumerable<Pedido>> UpdateAsync(Pedido entity)
        {
            entity.PedidoId = GetPedidoIdByCodigo(entity.Codigo);
            
            DeleteAllItemPedidoAsync(entity);
            AddItemPedidoAsync(entity);

            return GetByCodigoAsync(entity.Codigo);
        }

        public void DeleteAsync(Pedido entity)
        {
            DeleteAllItemPedidoAsync(entity);
            _context.Connection.ExecuteScalarAsync($"Delete from Pedido Where PedidoId = {entity.PedidoId}");
            
        }

        public IEnumerable<Pedido> GetStatusPedido()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private actions ItemPedido  
        public void AddItemPedidoAsync(Pedido entity)
        {
            foreach(var item in entity.Itens)
                _context.Connection.ExecuteScalarAsync($"Insert into ItemPedido (Descricao,PrecoUnitario,Quantidade,PedidoId) values ({item.Descricao},{item.PrecoUnitario},{item.Quantidade},{entity.PedidoId})");
        }

        public void DeleteAllItemPedidoAsync(Pedido entity)
        {
            _context.Connection.ExecuteScalarAsync($"Delete from ItemPedido where PedidoId = {entity.PedidoId}");
        }

        private int GetPedidoIdByCodigo(string codigo)
        {
            return _context.Connection.QueryFirst<int>($"SELECT PedidoId FROM Pedido where Pedido.Codigo = {codigo}");
        }


        #endregion

    }
}
