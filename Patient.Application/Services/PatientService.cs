using Microsoft.Extensions.Options;
using Patient.Application.Commands.Patient;
using Patient.Domain.Entities;
using Patient.Infrastructure;
using Patient.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Services
{
    public class PatientService : TransactionalService, IPatientService
    {
        public PatientService(IDbConnectionProvider connectionProvider) : base(connectionProvider)
        {

        }

        public async Task<Patients> GetByPatientId(string patientId)
        {
            return await Execute(new GetByPatientIdCommand(patientId));  
        }

        public async Task<Patients> Insert(Patients patient)
        {         
            return await Execute(new InsertPatientCommand(patient));
        }

    }
}
