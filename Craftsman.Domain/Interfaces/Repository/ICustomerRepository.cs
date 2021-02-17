using System.Threading.Tasks;
using Craftsman.Domain.Models;
using Craftsman.Shared.Interfaces;
using Craftsman.Shared.ValueObjects;

namespace Craftsman.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf);
        Task Save(Customer model);
    }
}