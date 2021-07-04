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

        public async Task<IEnumerable<ViewSellerFullData>> GetViewSellerFullData()
        {
            var sql = @"SELECT 
	                        s.""Id"", 								    s.""CreatedAt"", 		s.""UpdatedAt"", 
	                        s.""Deleted"", 							    s.""PersonId"", 		s.""Code"",
	                        COALESCE(np.""Name"", lp.""LegalName"") 	AS Name,
                            ph.""Ddd"",                                 ph.""Number""           AS PhoneNumer,
                            em.""Address""                              AS EmailAddress,        ad.""ZipCode"",
                            ad.""Street"",                              ad.""Number"",          ad.""City"",
                            ad.""State""
                        FROM 
				                        public.""Seller"" 			    AS s
	                        INNER JOIN 	public.""Person"" 			    AS p 				    ON s.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""NaturalPerson"" 		AS np 				    ON np.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""LegalPerson"" 	        AS lp 				    ON lp.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Phone"" 	            AS ph 				    ON ph.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Email"" 	            AS em 				    ON em.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Address"" 	            AS ad 				    ON ad.""PersonId"" = p.""Id""
                        WHERE
                            s.""Deleted"" = false;";

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
