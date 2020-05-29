using GMB.Model.AppsInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task Update(Apps user);
    }
}
