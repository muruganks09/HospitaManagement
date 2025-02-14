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
    public class DeletePatientCommand : IUnitOfWorkCommand<Patients>
    {
        readonly string _pateintId;

        public DeletePatientCommand(string pateintId)
        {
            _pateintId = pateintId;
        }

        public async Task<Patients> Invoke(IUnitOfWork uow)
        {
            var dbContext = Repository.DbContext.From(uow);

            uow.BeginTransaction();

            await dbContext.Patient.Delete(_pateintId);

            uow.Commit();

            return new Patients();
        }
    }
}
