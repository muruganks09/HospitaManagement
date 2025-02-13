using Patient.Infrastructure.Providers;
using Patient.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure
{
    public class TransactionalService
    {
        readonly IDbConnectionProvider _connectionProvider;

        public TransactionalService(IDbConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected async Task<T> Execute<T>(IUnitOfWorkCommand<T> cmd)
        {
            T result = default(T);

            using (var unitOfWork = new UnitOfWork(_connectionProvider))
            {
                try
                {
                    result = await cmd.Invoke(unitOfWork);
                }
                catch (Exception)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            return result;
        }
    }
}
