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
    public class SellerRepository
            : BaseRepository, ISellerRepository
    {
        #region Constructors

        public SellerRepository()
            => TableName = nameof(Seller);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public override Task<bool> InsertAsync<Entity>(Entity value)
            => Task.FromResult(true);

        public async Task<IEnumerable<ViewSellerFullData>> GetViewSellerFullData()
        {
            var sql = @"SELECT 
	                        s.""Id"", 								    s.""CreatedAt"", 		s.""UpdatedAt"", 
	                        s.""Deleted"", 							    s.""PersonId"", 		s.""Code"",
	                        COALESCE(np.""Name"", lp.""LegalName"") 	AS Name
                        FROM 
				                        public.""Seller"" 			    AS s
	                        INNER JOIN 	public.""Person"" 			    AS p 				    ON s.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""NaturalPerson"" 		AS np 				    ON np.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""LegalPerson"" 	        AS lp 				    ON lp.""PersonId"" = p.""Id"";";

            return await this.QueryAsync<ViewSellerFullData>(sql);
        }

        public async Task<Seller> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Seller""
                        WHERE
	                        ""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<Seller>(sql, parameters);
        }

        public async Task<Seller> GetByPersonIdAsync(Guid personId)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@PersonId", personId, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Seller""
                        WHERE
	                        ""PersonId"" = @PersonId;";

            return await QueryFirstOrDefaultAsync<Seller>(sql, parameters);
        }

        public async Task<Seller> GetByCodeAsync(string code)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Code", code, DbType.String);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Seller""
                        WHERE
	                        ""Code"" = @Code;";

            return await QueryFirstOrDefaultAsync<Seller>(sql, parameters);
        }

        #endregion
    }
}
