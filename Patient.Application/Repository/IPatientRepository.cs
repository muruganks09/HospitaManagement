using Patient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public interface IPatientRepository
    {
        Task InsertPatient(Patients patient);

        Task<Patients> GetByPatientId(string patientId); 
    }
}
