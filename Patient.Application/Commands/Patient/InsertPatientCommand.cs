using Patient.Application.Repository;
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
    public class InsertPatientCommand : IUnitOfWorkCommand<Patients>
    {
        readonly Patients _patient;

        public InsertPatientCommand(Patients patient) 
        {
            _patient = patient;
        }

        public async Task<Patients> Invoke(IUnitOfWork uow)
        {
            var dbContext = DbContext.From(uow);

            uow.BeginTransaction();


            await dbContext.Patient.InsertPatient(_patient);

            uow.Commit();

            var result = await dbContext.Patient.GetByPatientId(_patient.PatientId);

            return result;
        }
    }
}
