using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;

namespace Craftsman.Infrastructure.DataBase.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CraftsmanContext DbContext;

        public UnitOfWork(CraftsmanContext context)
        => DbContext = context;

        public void BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
    }
}