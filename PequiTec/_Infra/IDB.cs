using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PequiTec._Infra
{
    public interface IDB:IDisposable
    {
        IDbConnection Getconnection();
    }
}
