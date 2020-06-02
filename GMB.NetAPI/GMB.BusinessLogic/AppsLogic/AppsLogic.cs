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

        /// <summary>
        /// Get all apps that are in database
        /// </summary>
        /// <returns>
        /// List of all apps
        /// </returns>
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

        /// <summary>
        /// Add new app to database
        /// return ID of new app
        /// </summary>
        /// <param name="app"></param>
        /// <returns>
        /// App Id of new app
        /// </returns>
        public async Task<int> Insert(Apps app)
        {
            try
            {
                // TODO -- Why am I not getting the ID returned and getting ExecuteScalar error ???
                var appId = await repo.InsertApplication(app);
                return appId;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return -1;
        }

        /// <summary>
        /// Update app with new information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="app"></param>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
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
