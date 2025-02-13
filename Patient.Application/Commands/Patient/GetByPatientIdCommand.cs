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
    public class GetByPatientIdCommand : IUnitOfWorkCommand<Patients>
    {
        readonly string _patientId;

        public GetByPatientIdCommand(string patientId) 
        {
            _patientId = patientId;
        }

        public async Task<Patients> Invoke(IUnitOfWork uow)
        {
            var user = await Repository.DbContext.From(uow).Patient.GetByPatientId(_patientId);
            return user;
        }
    }
}
