using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Infrastructure.Providers
{
    public interface IDbConnectionProvider
    {
        IDbConnection Connection { get; }
    }
}
