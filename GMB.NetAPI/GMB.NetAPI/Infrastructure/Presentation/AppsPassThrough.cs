using GMB.BusinessLogic.AppsLogic;
using GMB.Model.AppsInfo;
using GMB.NetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;

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
        /// <returns></returns>
        public async Task<int> AddApp(AppsRequestModel app)
        {
            Apps a = new Apps
            {
                AppDesc = app.AppDesc,
                AppName = app.AppName
            };

            return await AppsLogic.Insert(a);
        }

        public async Task<IEnumerable<Apps>> GetAllApps()
        {
            return await AppsLogic.GetAll();
        }
    }
}