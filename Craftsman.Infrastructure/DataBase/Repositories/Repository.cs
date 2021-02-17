using System.Threading.Tasks;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CraftsmanContext DbContext;

        protected Repository(CraftsmanContext context)
        => DbContext = context;

        public Task Save(TEntity model)
        {
            throw new System.NotImplementedException();
        }
    }
}