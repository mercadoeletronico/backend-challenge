using Microsoft.Extensions.Options;
using Npgsql;
using System.Linq;
using Vrnz2.Infra.Repository.Abstract;
using Vrnz2.Infra.Repository.Settings;

namespace backend_challenge_data
{
    public class UnitOfWork
        : BaseUnitOfWork
    {
        #region Constructors

        public UnitOfWork(IOptions<ConnectionStrings> connectionStringsOptions)
        {
            var connectionString = connectionStringsOptions.Value.ConnectionsStrings.Single(s => Constants.DbName.Equals(s.Name));

            _connection = new NpgsqlConnection(connectionString.Value);

            AddRepository<IUserRepository, UserRepository>()
            .AddRepository<IGetUserClaimsRepository, GetUserClaimsRepository>();
        }

        #endregion
    }
}
