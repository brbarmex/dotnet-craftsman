using System.Threading.Tasks;

namespace Craftsman.Shared.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Save(TEntity model);
    }
}