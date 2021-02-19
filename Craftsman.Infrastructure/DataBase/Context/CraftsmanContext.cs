using System;
using System.Data;
using Craftsman.Infrastructure.Settings;
using Npgsql;

namespace Craftsman.Infrastructure.DataBase.Context
{
    public sealed class CraftsmanContext : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public CraftsmanContext()
        {
            Connection = new NpgsqlConnection(GlobalSettings.StringConnection);
            Connection.Open();
        }

        public void Dispose() => Connection?.Close();
    }
}