using System;
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

        public async Task<bool> CheckIfCustomerAlreadyExistsByGuidId(Guid id)
        => await _db
                .Connection
                .ExecuteScalarAsync<bool>("select count(1) from customer_base where customer_id = @Id", new{ Id = id }).ConfigureAwait(false);
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

        public override async Task<Customer> GetByGuid(Guid id)
        => _mapper.Map<Customer>(await _db.Connection.GetAsync<CustomerPO>(id).ConfigureAwait(false));

        public async Task<bool> UpdateAddress(Guid id ,Address address)
        => (await _db.Connection
                    .ExecuteAsync("UPDATE customer_base SET customer_street=@Customer_Street ,customer_zipcode=@Customer_Zipcode, customer_country=@Customer_Country, customer_city=@Customer_City WHERE customer_id=@Customer_Id",
                    new
                    {
                        Customer_Id = id,
                        Customer_Street = address.Street,
                        Customer_City = address.City,
                        Customer_Country = address.Country,
                        Customer_ZipCode = address.ZipCode.ToString()
                    }, _db.Transaction).ConfigureAwait(false)) > 0;

        public Task<bool> CheckIfCustomerExists(Guid id)
        {
            return Task.FromResult(false);
        }
    }
}