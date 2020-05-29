using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMB.Model.UserInfo;

namespace GMB.BusinessLogic.UserAccountsLogic
{
    /// <summary>
    /// Interface for User Accounts Business Logic
    /// </summary>
    public interface IUserAccountsLogic
    {
        Task Delete(int userAccountId);
        Task<IEnumerable<UserAccounts>> GetAll();
        Task<UserAccounts> GetById(int userAccountsId);
        Task<int> Insert(UserAccounts user);
        Task Update(UserAccounts user);
    }
}
