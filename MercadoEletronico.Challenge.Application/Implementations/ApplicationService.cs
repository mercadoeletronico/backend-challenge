using MercadoEletronico.Challenge.Application.Interfaces;
using MercadoEletronico.Challenge.Domain.Services.Interfaces;
using MercadoEletronico.Challenge.Util;
using MercadoEletronico.Challenge.Util.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MercadoEletronico.Challenge.Application.Implementations
{
    public abstract class ApplicationService<T> : IApplicationService<T> where T : class
    {
        protected readonly IDomainService<T> _domainService;
        private readonly ILogger<ApplicationService<T>> _logger;

        public ApplicationService(
            IDomainService<T> domainService,
            ILogger<ApplicationService<T>> logger)
        {
            _logger = logger;
            _domainService = domainService;
        }

        public async Task<Result> AddAsync(T @object)
        {
            return await Catch(() => _domainService.AddAsync(@object));
        }

        public async Task<Result> AddRangeAsync(IEnumerable<T> objects)
        {
            return await Catch(() => _domainService.AddRangeAsync(objects));
        }

        public async Task<Result> DeleteAsync(T @object)
        {
            return await Catch(() => _domainService.DeleteAsync(@object));
        }

        public async Task<Result> DeleteByIdAsync(string id)
        {
            return await Catch(() => _domainService.DeleteByIdAsync(id));
        }

        public async Task<Result<IEnumerable<T>>> GetAllAsync()
        {
            return await Catch(() => _domainService.GetAllAsync());
        }

        public async Task<Result<IEnumerable<T>>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await Catch(() => _domainService.GetByExpressionAsync(expression));
        }

        public async Task<Result<T>> GetByIdAsync(string id)
        {
            return await Catch(() => _domainService.GetByIdAsync(id));
        }

        public async Task<Result> UpdateAsync(T @object)
        {
            return await Catch(() => _domainService.UpdateAsync(@object));
        }

        public async Task<Result> UpdateRangeAsync(IEnumerable<T> objects)
        {
            return await Catch(() => _domainService.UpdateRangeAsync(objects));
        }

        protected async Task<Result<U>> Catch<U>(Func<Task<U>> func)
        {
            try
            {
                var @object = await func();

                if (@object is null)
                {
                    var message = "Information requested not found";
                    _logger.LogWarning(message);
                    return new Result<U>(ResultStatus.NotFound, message);
                }

                return new Result<U>(ResultStatus.Success, @object);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");

                var status = ex.GetResultStatus();

                return new Result<U>(status, ex.Message);
            }
        }

        protected async Task<Result> Catch(Func<Task> func)
        {
            try
            {
                await func();

                return new Result<T>(ResultStatus.Success);
            }
            catch (Exception ex)
            {
                ResultStatus status = ex.GetResultStatus();

                return new Result(status, ex.Message);
            }
        }
    }
}
