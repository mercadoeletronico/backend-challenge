using System;
using System.Threading.Tasks;

using BackendChallenge.Adapters.DependencyInjection;
using BackendChallenge.Application.DependencyInjection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BackendChallenge.AcceptanceTests
{
    public abstract class AcceptanceTestBase
    {
        private readonly IServiceScopeFactory _scopeFactory;

        protected readonly IServiceProvider _provider;

        protected AcceptanceTestBase()
        {
            var services = new ServiceCollection();

            services.AddDatabaseInMemory();

            services.AddUseCases();

            _provider = services.BuildServiceProvider();

            _scopeFactory = _provider.GetService<IServiceScopeFactory>();
        }

        public async Task ExecuteScopeAsync(Func<IServiceProvider, Task> action)
        {
            using var scope = _scopeFactory.CreateScope();

            try
            {
                await action(scope.ServiceProvider);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }

        public async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
        {
            using var scope = _scopeFactory.CreateScope();

            try
            {
                return await action(scope.ServiceProvider);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task SendAsync(IRequest request)
        {
            return ExecuteScopeAsync(sp =>
            {
                var mediator = sp.GetService<IMediator>();

                return mediator.Send(request);
            });
        }
    }
}
