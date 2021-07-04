using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_datatypes.Entities;
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

        public async Task<bool> InsertAsync(OrderItem orderItem)
        {
            orderItem.ChargeToInsert();

            var parameters = new DynamicParameters()
                .AddParameter("@Id", orderItem.Id, DbType.Guid)
                .AddParameter("@CreatedAt", orderItem.CreatedAt, DbType.DateTime)
                .AddParameter("@UpdatedAt", orderItem.CreatedAt, DbType.DateTime)
                .AddParameter("@Deleted", orderItem.Deleted, DbType.Boolean)
                .AddParameter("@OrderId", orderItem.OrderId, DbType.Guid)
                .AddParameter("@ProductId", orderItem.ProductId, DbType.Guid)
                .AddParameter("@Quantity", orderItem.Quantity, DbType.Decimal)
                .AddParameter("@UnitaryValue", orderItem.UnitaryValue, DbType.Decimal);

            var sql = @"INSERT INTO 
	                        ""OrderItem""(
	                        ""Id"", 			""CreatedAt"", 		    ""UpdatedAt"", 
	                        ""Deleted"", 		""OrderId"", 			""ProductId"", 
	                        ""Quantity"", 	    ""UnitaryValue"")
                        VALUES (
	                        @Id, 			    @CreatedAt, 		    @UpdatedAt, 
	                        @Deleted, 	        @OrderId, 		        @ProductId, 
	                        @Quantity, 	        @UnitaryValue);";

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

        public async Task<IEnumerable<OrderItem>> GetByOrderIdAsync(Guid orderId)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", orderId, DbType.Guid);

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

        public async Task<IEnumerable<ViewOrderItemFullData>> GetByViewOrderItemOrderIdAsync(Guid orderId)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", orderId, DbType.Guid);

            var sql = @"SELECT 
	                        o_i.""Id"", 			            p.""ReferenceCode"" 		AS ProductReferenceCode,
	                        p.""Description"" 		            AS ProductDescription,      o_i.""Quantity"",
                            o_i.""UnitaryValue""
                        FROM 
				                        public.""OrderItem""	AS o_i
	                        INNER JOIN 	public.""Order"" 		AS o 		                ON o.""Id"" = o_i.""OrderId""
                            INNER JOIN 	public.""Product"" 		AS p 		                ON p.""Id"" = o_i.""ProductId""
                        WHERE
	                        o.""Id"" = @Id
                            AND
                            o.""Deleted"" = false;";                            

            return await QueryAsync<ViewOrderItemFullData>(sql, parameters);
        }

        #endregion
    }
}
