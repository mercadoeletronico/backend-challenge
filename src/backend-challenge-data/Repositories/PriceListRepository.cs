using backend_challenge_data.Repositories.Interfaces;
using backend_challenge_datatypes.Entities;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using Vrnz2.Infra.Repository.Abstract;
using Vrnz2.Infra.Repository.Extensions;

namespace backend_challenge_data.Repositories
{
    public class PriceListRepository
        : BaseRepository, IPriceListRepository
    {
        #region Constructors

        public PriceListRepository()
            => TableName = nameof(PriceList);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public override Task<bool> InsertAsync<Entity>(Entity value)
            => Task.FromResult(true);

        public async Task<PriceList> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 			""CreatedAt"", 		""UpdatedAt"", 
	                        ""Deleted"", 		""SellerId"", 		""ProductId"", 
	                        ""UnitaryValue""
                        FROM 
	                        public.""PriceList""
                        WHERE
	                        ""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<PriceList>(sql, parameters);
        }

        public async Task<PriceList> GetByProductIdSellerIdAsync(Guid productId, Guid sellerId)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@ProductId", productId, DbType.Guid)
                .AddParameter("@SellerId", sellerId, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 			""CreatedAt"", 		""UpdatedAt"", 
	                        ""Deleted"", 		""SellerId"", 		""ProductId"", 
	                        ""UnitaryValue""
                        FROM 
	                        public.""PriceList""
                        WHERE
	                        ""ProductId"" = @ProductId 
                            AND
                            ""SellerId"" = @SellerId;";

            return await QueryFirstOrDefaultAsync<PriceList>(sql, parameters);
        }

        #endregion
    }
}
