using System.Threading.Tasks;
using Craftsman.Domain.Interfaces.Repository;
using Craftsman.Domain.Models;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.ValueObjects;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CraftsmanContext context) : base(context)
        {
        }

        public Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Customer model)
        {
            throw new System.NotImplementedException();
        }
    }
}