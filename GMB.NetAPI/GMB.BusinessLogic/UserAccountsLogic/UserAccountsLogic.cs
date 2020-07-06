using GMB.BusinessLogic.Utilities;
using GMB.CryptoService;
using GMB.Model.UserInfo;
using GMB.Repository;
using GMB.Repository.UserRepo;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Delete user accounts by ID
        /// </summary>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
        public async Task<RequestResponse> Delete(int userAccountsId)
        {
            try
            {
                await repo.DeleteUserAccount(userAccountsId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RequestResponse.Failed;
            }

            return RequestResponse.Successful;
        }

        /// <summary>
        /// Get all user accounts that are in database
        /// </summary>
        /// <returns>
        /// List of all User Accounts
        /// </returns>
        public async Task<IEnumerable<UserAccounts>> GetAll()
        {
            var userList = await repo.GetAllUserAccounts();
            return userList;
        }

        /// <summary>
        /// Get all user accounts that are in database
        /// </summary>
        /// <returns>
        /// Specified User Account if found
        /// Null otherwise
        /// </returns>
        public async Task<UserAccounts> GetById(int userAccountId)
        {
            var user = await repo.GetByIdUserAccount(userAccountId);
            if (user != null)
            {
                return user;
            }

            return null;
        }

        /// <summary>
        /// Add new user account to database
        /// return ID of new app
        /// </summary>
        /// <param name="app"></param>
        /// <returns>
        /// UserAccountId of new user account
        /// </returns>
        public async Task<int> Insert(UserAccounts user)
        {
            try
            {
                var result = await repo.InsertUserAccount(user);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return -1;
        }

        /// <summary>
        /// Update user account with new information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="app"></param>
        /// <returns>
        /// RequestResponse enum code
        /// </returns>
        public async Task<RequestResponse> Update(UserAccounts user)
        {
            try
            {
                await repo.UpdateUserAccount(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RequestResponse.Failed;
            }

            return RequestResponse.Successful;
        }

        /// <summary>
        /// Validate user account exists
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> ValidateUserAccount(UserAccounts user)
        {
            try
            {
                var enc = new Encryption().Encrypt(user.Password);
                var dec = new Decryption().Decrypt(enc);
                var result = await repo.ValidateUserAccount(user.UserName, new Encryption().Encrypt(user.Password));

                if(result != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
