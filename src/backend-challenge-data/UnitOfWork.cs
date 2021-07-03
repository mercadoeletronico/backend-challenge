using backend_challenge_data.Repositories;
using backend_challenge_data.Repositories.Interfaces;
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

            AddRepository<ICustomerRepository, CustomerRepository>()
                .AddRepository<ISellerRepository, SellerRepository>()
                .AddRepository<IPriceListRepository, PriceListRepository>()
                .AddRepository<IProductRepository, ProductRepository>()
                .AddRepository<IOrderRepository, OrderRepository>()
                .AddRepository<IOrderItemRepository, OrderItemRepository>()
                .AddRepository<IOrderItemApprovalRepository, OrderItemApprovalRepository>();
        }

        #endregion
    }
}
