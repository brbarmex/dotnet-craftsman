using System;
using System.Data;
using System.Data.SqlClient;
using Craftsman.Infrastructure.Settings;

namespace Craftsman.Infrastructure.DataBase.Context
{
    public sealed class CraftsmanContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public CraftsmanContext()
        {
            Connection = new SqlConnection(GlobalSettings.StringConnection);
            Connection.Open();
        }

        public void Dispose()
        => Connection?.Close();
    }
}