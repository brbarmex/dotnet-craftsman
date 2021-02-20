using System;
using Craftsman.Domain.Interfaces;
using Craftsman.Infrastructure.DataBase.Context;

namespace Craftsman.Infrastructure.DataBase.UoW
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CraftsmanContext DbContext;

        public UnitOfWork(CraftsmanContext context)
        => DbContext = context;

        public void BeginTransaction()
        => DbContext.Transaction = DbContext.Connection.BeginTransaction();

        public void Commit()
        => DbContext.Transaction.Commit();

        public void Rollback()
        => DbContext.Transaction.Rollback();

        public void Dispose()
        => DbContext.Transaction?.Dispose();
    }
}