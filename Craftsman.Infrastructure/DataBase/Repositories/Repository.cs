using System.Threading.Tasks;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CraftsmanContext _dataBase;

        protected Repository(CraftsmanContext context)
        => _dataBase = context;

        public abstract  Task Save(TEntity model);
    }
}