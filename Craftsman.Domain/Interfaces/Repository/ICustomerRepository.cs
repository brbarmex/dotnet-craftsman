using System.Threading.Tasks;
using Craftsman.Domain.Models;
using Craftsman.Shared.ValueObjects;

namespace Craftsman.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> CheckIfCustomerAlreadyExistsByCpf(Cpf cpf);
        Task Save(Customer model);
    }
}