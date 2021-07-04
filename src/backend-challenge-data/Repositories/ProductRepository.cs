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
    public class ProductRepository
        : BaseRepository, IProductRepository
    {
        #region Constructors

        public ProductRepository()
            => TableName = nameof(Product);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public override Task<bool> InsertAsync<Entity>(Entity value)
            => Task.FromResult(true);

        public async Task<IEnumerable<Product>> GetAllAsync() 
        {
            var sql = @"SELECT 
	                        ""Id"", 			""CreatedAt"", 		""UpdatedAt"", 
	                        ""Deleted"", 		""ReferenceCode"", 	""Description""
                        FROM 
	                        public.""Product""
                        WHERE
                            ""Deleted"" = false;";

            return await QueryAsync<Product>(sql);
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 			""CreatedAt"", 		""UpdatedAt"", 
	                        ""Deleted"", 		""ReferenceCode"", 	""Description""
                        FROM 
	                        public.""Product""
                        WHERE
	                        ""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<Product>(sql, parameters);
        }

        public async Task<Product> GetByReferenceCodeAsync(string referenceCode)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@ReferenceCode", referenceCode, DbType.String);

            var sql = @"SELECT 
	                        ""Id"", 			""CreatedAt"", 		""UpdatedAt"", 
	                        ""Deleted"", 		""ReferenceCode"", 	""Description""
                        FROM 
	                        public.""Product""
                        WHERE
	                        ""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<Product>(sql, parameters);
        }

        #endregion
    }
}
