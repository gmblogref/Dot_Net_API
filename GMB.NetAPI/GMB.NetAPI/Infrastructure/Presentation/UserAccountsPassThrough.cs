using GMB.BusinessLogic.UserAccountsLogic;
using GMB.BusinessLogic.Utilities;
using GMB.Model.UserInfo;
using GMB.NetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GMB.NetAPI.Infrastructure.Presentation
{
    /// <summary>
    /// Pass though layer from controller to business logic
    /// Does model mapping TO and FROM user accounts Logic
    /// </summary>
    public class UserAccountsPassThrough
    {
        private IUserAccountsLogic UserAccountsLogic;

        public UserAccountsPassThrough(IUserAccountsLogic userAccountsLogic)
        {
            // Possible ArgumentNullException
            // https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception?view=netcore-3.1

            UserAccountsLogic = userAccountsLogic;
        }

        /// <summary>
        /// Add new user account to database
        /// return ID of new app
        /// </summary>
        /// <param name="app"></param>
        /// <returns>
        /// UserAccountId of new user account
        /// </returns>
        public async Task<int> AddUser(UserAccountsRequestModel user)
        {
            UserAccounts ua = new UserAccounts
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                BirthDate = user.BirthDate
            };

            return await UserAccountsLogic.Insert(ua);
        }

        /// <summary>
        /// Delete user accounts by ID
        /// </summary>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
        public async Task<RequestResponse> DeleteUserAccountById(int userAccountsId)
        {
            return await UserAccountsLogic.Delete(userAccountsId);
        }

        /// <summary>
        /// Get all user accounts that are in database
        /// </summary>
        /// <returns>
        /// List of all User Accounts
        /// </returns>
        public async Task<IEnumerable<UserAccounts>> GetAllUserAccounts()
        {
            return await UserAccountsLogic.GetAll();
        }

        /// <summary>
        /// Get all user accounts that are in database
        /// </summary>
        /// <returns>
        /// Specified User Account if found
        /// Null otherwise
        /// </returns>
        public async Task<UserAccounts> GetUserAccountById(int userAccountId)
        {
            return await UserAccountsLogic.GetById(userAccountId);
        }

        /// <summary>
        /// Update user account with new information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="app"></param>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
        public async Task<RequestResponse> UpdateUserAccount(int userAccountsId, UserAccountsRequestModel user)
        {
            UserAccounts ua = new UserAccounts
            {
                UserAccountsId = userAccountsId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                BirthDate = user.BirthDate
            };

            return await UserAccountsLogic.Update(ua);
        }
    }
}