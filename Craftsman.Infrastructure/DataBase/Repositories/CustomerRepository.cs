using System.Threading.Tasks;
using AutoMapper;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.Models;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Infrastructure.DataBase.PersistentObject;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.ValueObjects;
using Dommel;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerRepository(CraftsmanContext context, IUnitOfWork unitOfWork, IMapper mapper) : base(context)
        {
             _uow = unitOfWork;
             _mapper = mapper;
        }

        public void BeginTransaction() => _uow.BeginTransaction();
        public void Rollback() => _uow.Rollback();
        public void Commit() => _uow.Commit();

        public Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf)
        {
            return Task.FromResult(false); // Temporally
        }

        public override async Task Save(Customer model)
        => await _dataBase
                .Connection
                .InsertAsync(_mapper.Map<CustomerPO>(model),_dataBase.Transaction)
                .ConfigureAwait(false);
    }
}