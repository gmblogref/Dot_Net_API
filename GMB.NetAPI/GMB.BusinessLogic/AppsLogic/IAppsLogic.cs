using GMB.BusinessLogic.Utilities;
using GMB.Model.AppsInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GMB.BusinessLogic.AppsLogic
{
    /// <summary>
    /// Interface for Apps business logic
    /// </summary>
    public interface IAppsLogic
    {
        Task<IEnumerable<Apps>> GetAll();
        Task<int> Insert(Apps user);
        Task<RequestResponse> Update(Apps user);
    }
}
