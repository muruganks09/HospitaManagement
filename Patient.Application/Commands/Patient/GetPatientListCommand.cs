using Patient.Domain.Entities;
using Patient.Infrastructure;
using Patient.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Commands.Patient
{
    public class GetPatientListCommand : IUnitOfWorkCommand<IList<Patients>>
    {
        readonly long _rowFrom;
        readonly long _rowCount;

        public GetPatientListCommand(long rowFrom, long rowCount)
        {
            _rowFrom = rowFrom;
            _rowCount = rowCount;
        }

        public async Task<IList<Patients>> Invoke(IUnitOfWork uow)
        {
            var dbContext = Repository.DbContext.From(uow);

            return await dbContext.Patient.GetPatientList(_rowFrom, _rowCount);
        }
    }
}
