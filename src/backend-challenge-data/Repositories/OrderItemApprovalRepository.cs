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
    public class OrderItemApprovalRepository
        : BaseRepository, IOrderItemApprovalRepository
    {
        #region Constructors

        public OrderItemApprovalRepository()
            => TableName = nameof(OrderItemApproval);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public async Task<bool> InsertAsync<Entity>(OrderItemApproval orderItemApproval)
        {
            orderItemApproval.ChargeToInsert();

            var parameters = new DynamicParameters()
                .AddParameter("@Id", orderItemApproval.Id, DbType.Guid)
                .AddParameter("@CreatedAt", orderItemApproval.CreatedAt, DbType.DateTime)
                .AddParameter("@UpdatedAt", orderItemApproval.UpdatedAt, DbType.DateTime)
                .AddParameter("@Deleted", orderItemApproval.Deleted, DbType.Boolean)
                .AddParameter("@OrderItemId", orderItemApproval.OrderItemId, DbType.Guid)
                .AddParameter("@Quantity", orderItemApproval.Quantity, DbType.Decimal)
                .AddParameter("@UnitaryValue", orderItemApproval.UnitaryValue, DbType.Decimal);

            var sql = @"INSERT INTO 
	                        public.""OrderItemApproval""(
	                        ""Id"", 			""CreatedAt"", 		    ""UpdatedAt"", 
	                        ""Deleted"", 		""OrderItemId"",	    ""Quantity"",
                            ""UnitaryValue"")
                        VALUES (
	                        ""@Id"", 			""@CreatedAt"", 		""@UpdatedAt"", 
	                        ""@Deleted"", 	    ""@OrderItemId"", 		""@Quantity"",
                            ""@UnitaryValue"");";

            var result = await ExecuteAsync(sql, parameters);

            return (result > 0);
        }

        public async Task<OrderItemApproval> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        o_i_a.""Id"", 			    o_i_a.""CreatedAt"", 		        o_i_a.""UpdatedAt"", 
	                        o_i_a.""Deleted"", 		    o_i_a.""OrderId"", 			        o_i_a.""ProductId"", 
	                        o_i_a.""Quantity"", 	    o_i_a.""UnitaryValue""
                        FROM 
                            public.""OrderItemApproval""	AS o_i_a
                        WHERE
	                        o_i_a.""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<OrderItemApproval>(sql, parameters);
        }

        public async Task<IEnumerable<OrderItemApproval>> GetByOrderItemIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        o_i_a.""Id"", 		    o_i_a.""CreatedAt"", 	    o_i_a.""UpdatedAt"", 
	                        o_i_a.""Deleted"", 	    o_i_a.""OrderItemId"",      o_i_a.""Quantity"",     
                            o_i_a.""UnitaryValue""
                        FROM 
				                        public.""OrderItemApproval""	        AS o_i_a
                            INNER JOIN 	public.""OrderItem""	                AS o_i 		ON o_i.""Id"" = o_i_a.""OrderItemId""
                        WHERE
	                        o_i.""Id"" = @Id;";

            return await QueryAsync<OrderItemApproval>(sql, parameters);
        }

        public async Task<IEnumerable<OrderItemApproval>> GetByOrderIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        o_i_a.""Id"", 		    o_i_a.""CreatedAt"", 	    o_i_a.""UpdatedAt"", 
	                        o_i_a.""Deleted"", 	    o_i_a.""OrderItemId"",      o_i_a.""Quantity"",     
                            o_i_a.""UnitaryValue""
                        FROM 
				                        public.""OrderItemApproval""	        AS o_i_a
                            INNER JOIN 	public.""OrderItem""	                AS o_i 		ON o_i.""Id"" = o_i_a.""OrderItemId""
	                        INNER JOIN 	public.""Order"" 		                AS o 		ON o.""Id"" = o_i.""OrderId""
                        WHERE
	                        o.""Id"" = @Id;";

            return await QueryAsync<OrderItemApproval>(sql, parameters);
        }

        #endregion
    }
}
