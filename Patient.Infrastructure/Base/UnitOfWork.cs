using Patient.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        IDbConnection _connection;
        public IDbConnection Connection => _connection ??= _connectionProvider.Connection;

        public IDbTransaction Transaction { get; private set; }

        readonly IDbConnectionProvider _connectionProvider;

        public UnitOfWork(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public void BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new Exception($"New transaction is not allowed. An active transaction already exists.");
            }

            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
            Transaction = null;
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Transaction = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Transaction?.Dispose();
                Transaction = null;

                _connection?.Dispose();
                _connection = null;
            }
        }
    }
}
