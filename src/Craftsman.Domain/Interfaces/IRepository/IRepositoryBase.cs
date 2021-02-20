using System.Threading.Tasks;

namespace Craftsman.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Save(TEntity model);
    }
}