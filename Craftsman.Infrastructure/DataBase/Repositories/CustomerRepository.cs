using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.Models;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.ValueObjects;
using Dapper;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly IUnitOfWork _uow;

        public CustomerRepository(CraftsmanContext context, IUnitOfWork unitOfWork) : base(context)
        => _uow = unitOfWork;

        public void BeginTransaction() => _uow.BeginTransaction();
        public void Rollback() => _uow.Rollback();
        public void Commit() => _uow.Commit();

        public Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf)
        {
            return default;
        }

        public override async Task Save(Customer model)
        {
            const string insertSqlQuery = "";

            await _dataBase
                    .Connection
                    .ExecuteAsync(insertSqlQuery,model,_dataBase.Transaction)
                    .ConfigureAwait(false);
        }
    }
}