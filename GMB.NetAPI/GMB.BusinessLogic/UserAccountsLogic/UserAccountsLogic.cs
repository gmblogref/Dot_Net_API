using GMB.Model.UserInfo;
using GMB.Repository;
using GMB.Repository.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMB.BusinessLogic.UserAccountsLogic
{
    /// <summary>
    /// User Accounts business logic
    /// </summary>
    public class UserAccountsLogic : IUserAccountsLogic
    {
        UserAccountsRepository repo;
        public UserAccountsLogic(GMBDataConnection connection)
        {
            this.repo = connection.GetAs<UserAccountsRepository>();
        }

        public async Task Delete(int userId)
        {
            await repo.DeleteUserAccount(userId);
        }

        public async Task<IEnumerable<UserAccounts>> GetAll()
        {
            var userList = await repo.GetAllUserAccounts();
            return userList;
        }

        public async Task<UserAccounts> GetById(int userId)
        {
            return await repo.GetByIdUserAccount(userId);
        }

        public async Task<int> Insert(UserAccounts user)
        {
            return await repo.InsertUserAccount(user);
        }

        public async Task Update(UserAccounts user)
        {
            await repo.UpdateUserAccount(user);
        }
    }
}
