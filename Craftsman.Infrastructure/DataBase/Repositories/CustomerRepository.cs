using System;
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
            return Task.FromResult(false); // Temporally
        }

        public override async Task Save(Customer model)
        {
            await _dataBase
                    .Connection
                    .ExecuteAsync("INSERT INTO customer_base (customner_fullname, customer_name, customer_document, customer_email, customer_birthdate, customer_street, customer_zipcode, customer_country, customer_city) VALUES(@customner_fullname, @customer_name, @customer_document, @customer_email, @customer_birthdate, @customer_street, @customer_zipcode, @customer_country, @customer_city)",
                    new { customner_fullname = model.FullName,
                          customer_name = model.Name,
                          customer_document = model.Cpf.ToString(),
                          customer_email = model.Email.ToString(),
                          customer_birthdate = DateTime.Now,
                          customer_street = model.Address.Street,
                          customer_zipcode = model.Address.ZipCode.ToString(),
                          customer_country = model.Address.Country,
                          customer_city = model.Address.City },
                    _dataBase.Transaction)
                    .ConfigureAwait(false);
        }
    }
}