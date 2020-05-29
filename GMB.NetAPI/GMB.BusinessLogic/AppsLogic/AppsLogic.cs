using GMB.Model.AppsInfo;
using GMB.Repository;
using GMB.Repository.AppsRepo;
using GMB.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMB.BusinessLogic.AppsLogic
{
    /// <summary>
    /// Apps business logic
    /// </summary>
    public class AppsLogic : IAppsLogic
    {
        AppsRepository repo;
        public AppsLogic(GMBDataConnection connection)
        {
            this.repo = connection.GetAs<AppsRepository>();
        }

        public async Task<IEnumerable<Apps>> GetAll()
        {
            var appList = await repo.GetAllApplications();
            return appList;
        }

        public async Task<int> Insert(Apps app)
        {
            return await repo.InsertApplication(app);
        }

        public async Task Update(Apps app)
        {
            await repo.UpdateApplication(app);
        }
    }
}
