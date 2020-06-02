using GMB.Model.AppsInfo;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMB.Repository.AppsRepo
{
    /// <summary>
    /// Stored Procs for the Apps table in GMBData database
    /// Using Insight Database Abstract Class Implementation
    /// https://github.com/jonwagner/Insight.Database/wiki/Auto-Interface-Implementation
    /// </summary>
    public abstract class AppsRepository
    {
        [Sql("Apps_GetAll", Schema = "dbo")]
        public abstract Task<IEnumerable<Apps>> GetAllApplications();

        [Sql("Apps_Insert", Schema = "dbo")]
        public abstract Task<int> InsertApplication(Apps app);

        [Sql("Apps_Update", Schema = "dbo")]
        public abstract Task UpdateApplication(Apps app);
    }
}
