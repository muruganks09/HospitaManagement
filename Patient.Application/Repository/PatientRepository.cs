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

        public async Task<IList<Patients>> GetPatientList(long rowFrom, long rowCount) 
        {
            var param = new DynamicParameters();
            param.Add("@RowFrom", rowFrom);
            param.Add("@RowCount", rowCount);

            return (await SqlMapper.QueryAsync<Patients>(_unitOfWork.Connection,
              "GetPatients",
              param,
              commandType: CommandType.StoredProcedure,
              transaction: _unitOfWork.Transaction)).ToList();
        }

        public async Task UpdatePatient(Patients patient) 
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

        public async Task Delete(string patientId) 
        {
            await SqlMapper.ExecuteAsync(_unitOfWork.Connection,
              "DELETE FROM [dbo].[Patient] WHERE PatientId = @PatientId",
              new { PatientId = patientId }, 
              transaction: _unitOfWork.Transaction);
        }
    }
}
