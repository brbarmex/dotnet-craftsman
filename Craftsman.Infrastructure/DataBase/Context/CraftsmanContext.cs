using System;
using System.Data;
using System.Data.SqlClient;
using Craftsman.Infrastructure.Settings;

namespace Craftsman.Infrastructure.DataBase.Context
{
    public sealed class CraftsmanContext : IDisposable
    {
        public IDbConnection DbConnection { get; }
        public IDbTransaction Transaction { get; set; }

        public CraftsmanContext()
        {
            DbConnection = new SqlConnection(GlobalSettings.StringConnection);
            DbConnection.Open();
        }

        public void Dispose()
        => DbConnection?.Close();
    }
}