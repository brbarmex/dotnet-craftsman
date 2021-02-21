using System.Threading.Tasks;
using AutoMapper;
using Craftsman.Domain.Entities;
using Craftsman.Domain.Interfaces;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.ValueObjects;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Infrastructure.DataBase.PersistentObject;
using Dapper;
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

        public async Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf)
        =>  await _db
                  .Connection
                  .ExecuteScalarAsync<bool>("select count(1) from customer_base where customer_document = @Cpf", new{ Cpf = cpf.ToString() }).ConfigureAwait(false);

        public override async Task Save(Customer model)
        => await _db
                .Connection
                .InsertAsync(_mapper.Map<CustomerPO>(model),_db.Transaction)
                .ConfigureAwait(false);

        public override async Task<Customer> SaveAndReturnRow(Customer model)
        {
            var _id = await _db
                .Connection
                .InsertAsync(_mapper.Map<CustomerPO>(model),_db.Transaction)
                .ConfigureAwait(false);

            var row = await _db.Connection.GetAsync<CustomerPO>(_id).ConfigureAwait(false);

            return _mapper.Map<Customer>(row);
        }
    }
}