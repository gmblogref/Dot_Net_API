using GMB.Model.LoggingInfo;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMB.Repository.LoggingRepo
{
    /// <summary>
    /// Stored Procs for the ApplicationLog table in GMBUtilites database
    /// Using Insight Database Abstract Class Implementation
    /// https://github.com/jonwagner/Insight.Database/wiki/Auto-Interface-Implementation
    /// </summary>
    public abstract class ApplicationLogRepository
    {
        [Sql("ApplicationLog_Insert", Schema = "dbo")]
        public abstract Task<int> InsertLog(ApplicationLog app);
    }
}
