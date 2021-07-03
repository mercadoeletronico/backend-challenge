using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_datatypes.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Vrnz2.Infra.CrossCutting.Extensions;
using Vrnz2.Infra.Repository.Abstract;
using Vrnz2.Infra.Repository.Extensions;

namespace backend_challenge_data.Repositories
{
    public class OrderRepository
        : BaseRepository, IOrderRepository
    {
        #region Constructors

        public OrderRepository()
            => TableName = nameof(Order);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public async override Task<bool> InsertAsync<Entity>(Entity value)
        {
            var order = value as Order;

            var parameters = new DynamicParameters()
                .AddParameter("@Id", Guid.NewGuid(), DbType.Guid)
                .AddParameter("@CreatedAt", DateTimeOffset.UtcNow, DbType.DateTime)
                .AddParameter("@UpdatedAt", DateTimeOffset.UtcNow, DbType.DateTime)
                .AddParameter("@Deleted", false, DbType.Boolean)
                .AddParameter("@Number", order.Number, DbType.String)
                .AddParameter("@CustomerId", order.CustomerId, DbType.Guid)
                .AddParameter("@SellerId", order.SellerId, DbType.Guid);

            var sql = @"INSERT INTO 
	                        public.""Order""(
	                        ""Id"", 			""CreatedAt"", 	        ""UpdatedAt"", 
	                        ""Deleted"", 		""Number"", 	        ""CustomerId"", 
	                        ""SellerId"")
                        VALUES (
	                        ""@Id"", 			""@CreatedAt"", 	    ""@UpdatedAt"", 
	                        ""@Deleted"", 	    ""@Number"", 		    ""@CustomerId"", 
	                        ""@SellerId"");";

            var result = await ExecuteAsync(sql, parameters);

            return (result > 0);
        }

        public async Task<IEnumerable<ViewOrderFullData>> GetViewOrderFullData()
        {
            var sql = @"SELECT 
	                        o.""Number"",
	                        o.""CreatedAt"",
	                        o.""UpdatedAt"", 
	                        c.""Code"" 									    AS ""CustomerCode"", 
	                        COALESCE(np_c.""Name"", lp_c.""LegalName"") 	AS ""CustomerName"", 
	                        s.""Code"" 									    AS ""SellerCode"",
	                        COALESCE(np_s.""Name"", lp_s.""LegalName"") 	AS ""SellerName""
                        FROM 
					                        public.""Order"" 				AS o
	                        INNER JOIN 		public.""Customer"" 			AS c 		ON c.""Id"" = o.""CustomerId""
	                        LEFT JOIN 		public.""LegalPerson"" 	        AS lp_c 	ON lp_c.""PersonId"" = c.""PersonId""
	                        LEFT JOIN 		public.""NaturalPerson"" 		AS np_c 	ON np_c.""PersonId"" = c.""PersonId""
	                        INNER JOIN 		public.""Seller"" 			    AS s 		ON s.""Id"" = o.""CustomerId""
	                        LEFT JOIN 		public.""LegalPerson"" 	        AS lp_s 	ON lp_s.""PersonId"" = s.""PersonId""
	                        LEFT JOIN 		public.""NaturalPerson"" 		AS np_s 	ON np_s.""PersonId"" = s.""PersonId"";";

            return await this.QueryAsync<ViewOrderFullData>(sql);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);            

            var sql = @"SELECT 
                            ""Id"",             ""CreatedAt"",          ""UpdatedAt"", 
                            ""Deleted"",        ""Number"",             ""CustomerId"",         
                            ""SellerId"" 
                        FROM 
                            public.""Order""
                        WHERE
                            ""Id"" = @Id; ";

            return await QueryFirstOrDefaultAsync<Order>(sql, parameters);
        }

        public async Task<(bool Exists, Order order)> Exists(string number)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Number", number, DbType.String);

            var sql = @"SELECT 
                            ""Id"",             ""CreatedAt"",          ""UpdatedAt"", 
                            ""Deleted"",        ""Number"",             ""CustomerId"",         
                            ""SellerId"" 
                        FROM 
                            public.""Order""
                        WHERE
                            ""Number"" = @Number;";

            var order = await QueryFirstOrDefaultAsync<Order>(sql, parameters);

            return (order.IsNotNull(), order);
        }

        #endregion
    }
}
