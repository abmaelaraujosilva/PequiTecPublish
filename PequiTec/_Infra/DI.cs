using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PequiTec._Infra
{
    public static class DI
    {
        public static IDB Sql()
        {
            return new SqlServer();
        }
    }
}