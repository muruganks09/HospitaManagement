using Patient.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Application.Repository
{
    public class DbContext
    {
        readonly IUnitOfWork _unitOfWork;

        public static DbContext From(IUnitOfWork unitOfWork)
        {
            return new DbContext(unitOfWork);
        }

        public DbContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }


        IPatientRepository _patient;
        public IPatientRepository Patient => _patient ??= new PatientRepository(_unitOfWork);
    }
}
