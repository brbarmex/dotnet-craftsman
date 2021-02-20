using System.Threading.Tasks;
using Craftsman.Domain.Interfaces;
using Craftsman.Infrastructure.DataBase.Context;

namespace Craftsman.Infrastructure.DataBase.Repositories
{
    public abstract class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected CraftsmanContext _db;

        protected Repository(CraftsmanContext context)
        => _db = context;

        public abstract  Task Save(TEntity model);
    }
}