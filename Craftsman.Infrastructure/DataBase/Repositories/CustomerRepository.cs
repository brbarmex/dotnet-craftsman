using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.Models;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.ValueObjects;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly IUnitOfWork _uow;

        public CustomerRepository(CraftsmanContext context, IUnitOfWork unitOfWork) : base(context)
        => _uow = unitOfWork;

        public void BeginTransaction()
        => _uow.BeginTransaction();


        public void Rollback()
        => _uow.Rollback();

        public Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf)
        {
            return default;
        }

        public Task Save(Customer model)
        {
            return default;
        }

        public void Commit()
        => _uow.Commit();
    }
}