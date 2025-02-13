﻿using Patient.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure
{
    public interface IUnitOfWorkCommand<T>
    {
        Task<T> Invoke(IUnitOfWork uow);
    }
}
