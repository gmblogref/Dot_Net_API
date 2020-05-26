using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMB.Repository
{
    public class GMBDataConnection
    {
        public T GetAs<T>() where T : class
        {
            return DBConnectionSettings.GetConnectionAs<T>("GMBDataConnection");
        }

        public T GetParallelAs<T>() where T : class
        {
            return DBConnectionSettings.GetParallelConnectionAs<T>("GMBDataConnection");
        }
    }

    public class GMAUtilitiesConnection
    {
        public T GetAs<T>() where T : class
        {
            return DBConnectionSettings.GetConnectionAs<T>("GMAUtilitiesConnection");
        }

        public T GetParallelAs<T>() where T : class
        {
            return DBConnectionSettings.GetParallelConnectionAs<T>("GMAUtilitiesConnection");
        }
    }
}
