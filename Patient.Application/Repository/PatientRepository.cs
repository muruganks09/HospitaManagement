using Dapper;
using Patient.Domain.Entities;
using Patient.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Repository
{
    public class PatientRepository : IPatientRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public PatientRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Patients> GetByPatientId(string patientID)  
        {
            var param = new DynamicParameters();
            param.Add("@PatientId", patientID.Trim().ToUpper());

            return (await SqlMapper.QueryAsync<Patients>(_unitOfWork.Connection,
           "GetPatientByPatientId",
           param,
           commandType:
           CommandType.StoredProcedure,
           transaction: _unitOfWork.Transaction)).FirstOrDefault();
        }

        public async Task InsertPatient(Patients patient)  
        {
            var param = new DynamicParameters();
            param.Add("@PatientId", patient.PatientId);
            param.Add("@Name", patient.Name);
            param.Add("@@PhoneNumber", patient.PhoneNumber);
            param.Add("@@DiseaseName", patient.DiseaseName);
            param.Add("@@DateOfBirth", patient.DateOfBirth);

            await SqlMapper.ExecuteAsync(
              _unitOfWork.Connection,
              "InsertPatient",
              param,
              commandType: CommandType.StoredProcedure,
              transaction: _unitOfWork.Transaction);
        }
    }
}
