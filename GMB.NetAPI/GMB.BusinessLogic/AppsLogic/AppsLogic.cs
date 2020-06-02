using GMB.BusinessLogic.Utilities;
using GMB.Model.AppsInfo;
using GMB.Repository;
using GMB.Repository.AppsRepo;
using System;
using System.Collections.Generic;
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

        public async Task<RequestResponse> Update(Apps app)
        {
            try
            {
                await repo.UpdateApplication(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RequestResponse.Failed;
            }

            return RequestResponse.Successful;
        }
    }
}
