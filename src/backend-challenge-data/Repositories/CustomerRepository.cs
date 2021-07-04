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
    public class CustomerRepository
            : BaseRepository, ICustomerRepository
    {
        #region Constructors

        public CustomerRepository()
            => TableName = nameof(Customer);

        #endregion

        #region Methods

        public override void Init(IDbConnection dbConnection)
            => base.Init(dbConnection);

        public override void Init(IDbTransaction dbTransaction)
            => base.Init(dbTransaction);

        public override Task<bool> InsertAsync<Entity>(Entity value)
            => Task.FromResult(true);

        public async Task<IEnumerable<ViewCustomerFullData>> GetViewCustomerFullData()
        {
            var sql = @"SELECT 
	                        c.""Id"", 								    c.""CreatedAt"", 	c.""UpdatedAt"", 
	                        c.""Deleted"", 							    c.""PersonId"", 	c.""Code"",
	                        COALESCE(np.""Name"", lp.""LegalName"") 	AS Name,
                            ph.""Ddd"",                                 ph.""Number""       AS PhoneNumer,
                            em.""Address""                              AS EmailAddress,    ad.""ZipCode"",
                            ad.""Street"",                              ad.""Number"",      ad.""City"",
                            ad.""State""
                        FROM 
				                        public.""Customer"" 			AS c
	                        INNER JOIN 	public.""Person"" 			    AS p 				ON c.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""NaturalPerson"" 		AS np 			    ON np.""PersonId"" = p.""Id""
	                        LEFT JOIN 	public.""LegalPerson"" 	        AS lp 				ON lp.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Phone"" 	            AS ph 				ON ph.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Email"" 	            AS em 				ON em.""PersonId"" = p.""Id""
                            LEFT JOIN 	public.""Address"" 	            AS ad 				ON ad.""PersonId"" = p.""Id""
                        WHERE
                            c.""Deleted"" = false;";

            return await this.QueryAsync<ViewCustomerFullData>(sql);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Id", id, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Customer""
                        WHERE
	                        ""Id"" = @Id;";

            return await QueryFirstOrDefaultAsync<Customer>(sql, parameters);
        }

        public async Task<Customer> GetByPersonIdAsync(Guid personId)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@PersonId", personId, DbType.Guid);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Customer""
                        WHERE
	                        ""PersonId"" = @PersonId;";

            return await QueryFirstOrDefaultAsync<Customer>(sql, parameters);
        }

        public async Task<Customer> GetByCodeAsync(string code)
        {
            var parameters = new DynamicParameters()
                .AddParameter("@Code", code, DbType.String);

            var sql = @"SELECT 
	                        ""Id"", 		""CreatedAt"", 	    ""UpdatedAt"", 
	                        ""Deleted"", 	""PersonId"", 	    ""Code""
                        FROM 
	                        public.""Customer""
                        WHERE
	                        ""Code"" = @Code;";

            return await QueryFirstOrDefaultAsync<Customer>(sql, parameters);
        }

        #endregion
    }
}
