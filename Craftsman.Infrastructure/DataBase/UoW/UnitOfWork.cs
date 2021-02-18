using System;
using Craftsman.Infrastructure.DataBase.Context;
using Craftsman.Shared.Interfaces;

namespace Craftsman.Infrastructure.DataBase.UoW
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CraftsmanContext DbContext;

        public UnitOfWork(CraftsmanContext context)
        => DbContext = context;

        public void BeginTransaction()
        => DbContext.Transaction = DbContext.DbConnection.BeginTransaction();

        public void Commit()
        => DbContext.Transaction.Commit();

        public void Rollback()
        => DbContext.Transaction.Rollback();

        public void Dispose()
        => DbContext.Transaction?.Dispose();
    }
}