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
            try
            {
                var appList = await repo.GetAllApplications();
                return appList;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public async Task<int> Insert(Apps app)
        {
            try
            {
                // TODO -- Why am I not getting the ID returned ???
                var x = await repo.InsertApplication(app);
                return x;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return -1;
        }

        public async Task Update(Apps app)
        {
            await repo.UpdateApplication(app);
        }
    }
}
