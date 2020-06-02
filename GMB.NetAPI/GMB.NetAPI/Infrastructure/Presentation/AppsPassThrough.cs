using GMB.BusinessLogic.AppsLogic;
using GMB.BusinessLogic.Utilities;
using GMB.Model.AppsInfo;
using GMB.NetAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMB.NetAPI.Infrastructure.Presentation
{
    /// <summary>
    /// Pass though layer from controller to business logic
    /// Does model mapping TO and FROM Apps Logic
    /// </summary>
    public class AppsPassThrough
    {
        private IAppsLogic AppsLogic;

        public AppsPassThrough(IAppsLogic appsLogic)
        {
            // Possible ArgumentNullException
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=netcore-3.1

            AppsLogic = appsLogic;
        }

        /// <summary>
        /// Add new app to database
        /// return ID of new app
        /// </summary>
        /// <param name="app"></param>
        /// <returns>
        /// App Id of new app
        /// </returns>
        public async Task<int> AddApp(AppsRequestModel app)
        {
            Apps a = new Apps
            {
                AppDesc = app.AppDesc,
                AppName = app.AppName
            };

            return await AppsLogic.Insert(a);
        }

        /// <summary>
        /// Get all apps that are in database
        /// </summary>
        /// <returns>
        /// List of all apps
        /// </returns>
        public async Task<IEnumerable<Apps>> GetAllApps()
        {
            return await AppsLogic.GetAll();
        }

        /// <summary>
        /// Update app with new information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="app"></param>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
        public async Task<RequestResponse> UpdateApp(int id, AppsRequestModel app)
        {
            Apps a = new Apps
            {
                AppsId = id,
                AppDesc = app.AppDesc,
                AppName = app.AppName
            };

            return await AppsLogic.Update(a);
        }
    }
}