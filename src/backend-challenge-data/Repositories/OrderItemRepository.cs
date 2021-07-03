using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_domain_datatypes.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Abstract;
using Vrnz2.Infra.Repository.Extensions;

namespace backend_challenge_data.Repositories
{
    public class OrderItemRepository
        : BaseRepository, IOrderItemRepository
    {
        #region Constructors

        public OrderItemRepository()
            => TableName = nameof(OrderItem);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public async override Task<bool> InsertAsync<Entity>(Entity value)
        {
            var order = value as OrderItem;

            var parameters = new DynamicParameters()
                .AddParameter("@Id", Guid.NewGuid(), DbType.Guid)
                .AddParameter("@CreatedAt", DateTimeOffset.UtcNow, DbType.DateTime)
                .AddParameter("@UpdatedAt", DateTimeOffset.UtcNow, DbType.DateTime)
                .AddParameter("@Deleted", false, DbType.Boolean)
                .AddParameter("@OrderId", order.OrderId, DbType.Guid)
                .AddParameter("@ProductId", order.ProductId, DbType.Guid)
                .AddParameter("@Quantity", order.Quantity, DbType.Decimal)
                .AddParameter("@UnitaryValue", order.UnitaryValue, DbType.Decimal);

            var sql = @"INSERT INTO 
	                        public.""OrderItem""(
	                        ""Id"", 			""CreatedAt"", 		    ""UpdatedAt"", 
	                        ""Deleted"", 		""OrderId"", 			""ProductId"", 
	                        ""Quantity"", 	    ""UnitaryValue"")
                        VALUES (
	                        ""@Id"", 			""@CreatedAt"", 		""@UpdatedAt"", 
	                        ""@Deleted"", 	    ""@OrderId"", 		    ""@ProductId"", 
	                        ""@Quantity"", 	    ""@UnitaryValue"");";

            var result = await ExecuteAsync(sql, parameters);

            return (result > 0);
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        o_i.""Id"", 			o_i.""CreatedAt"", 		        o_i.""UpdatedAt"", 
	                        o_i.""Deleted"", 		o_i.""OrderId"", 			    o_i.""ProductId"", 
	                        o_i.""Quantity"", 	    o_i.""UnitaryValue""
                        FROM 
                            public.""OrderItem""	AS o_i
                        WHERE
	                        o_i.""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<OrderItem>(sql, parameters);
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        o_i.""Id"", 			            o_i.""CreatedAt"", 		    o_i.""UpdatedAt"", 
	                        o_i.""Deleted"", 		            o_i.""OrderId"", 			o_i.""ProductId"", 
	                        o_i.""Quantity"", 	                o_i.""UnitaryValue""
                        FROM 
				                        public.""OrderItem""	AS o_i
	                        INNER JOIN 	public.""Order"" 		AS o 		                ON o.""Id"" = o_i.""OrderId""
                        WHERE
	                        o.""Id"" = @Id;";

            return await QueryAsync<OrderItem>(sql, parameters);
        }

        public async Task<IEnumerable<OrderItem>> GetByOrderNumberAsync(string orderNumber)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Number", orderNumber, DbType.String);

            var sql = @"SELECT 
	                        o_i.""Id"", 			            o_i.""CreatedAt"", 		    o_i.""UpdatedAt"", 
	                        o_i.""Deleted"", 		            o_i.""OrderId"", 			o_i.""ProductId"", 
	                        o_i.""Quantity"", 	                o_i.""UnitaryValue""
                        FROM 
				                        public.""OrderItem""	AS o_i
	                        INNER JOIN 	public.""Order"" 		AS o 		                ON o.""Id"" = o_i.""OrderId""
                        WHERE
	                        o.""Number"" = @Number;";

            return await QueryAsync<OrderItem>(sql, parameters);
        }

        #endregion
    }
}
