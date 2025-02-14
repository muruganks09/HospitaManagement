using Patient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application
{
    public interface IPatientService
    {

        Task<Patients> GetByPatientId(string patientId);   

        Task<Patients> Insert(Patients patient);

        Task<IList<Patients>> GetPatientList(long rowFrom, long rowCount);

        Task<Patients> Delete(string patiendId);
    }
}
