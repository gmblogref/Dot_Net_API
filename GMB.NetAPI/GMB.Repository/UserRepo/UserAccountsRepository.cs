﻿using Insight.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMB.Model.UserInfo;

namespace GMB.Repository.UserRepo
{
    /// <summary>
    /// Stored Procs for the UserAccounts table in GMBData database
    /// Using Insight Database Abstract Class Implementation
    /// https://github.com/jonwagner/Insight.Database/wiki/Auto-Interface-Implementation
    /// </summary>
    public abstract class UserAccountsRepository
    {
        [Sql("UserAccounts_Delete", Schema = "dbo")]
        public abstract Task DeleteUserAccount(int userAccountsId);

        [Sql("UserAccounts_GetAll", Schema = "dbo")]
        public abstract Task<IEnumerable<UserAccounts>> GetAllUserAccounts();

        [Sql("UserAccounts_GetById", Schema = "dbo")]
        public abstract Task<UserAccounts> GetByIdUserAccount(int userAccountsId);

        [Sql("UserAccounts_Insert", Schema = "dbo")]
        public abstract Task<int> InsertUserAccount(UserAccounts user);

        [Sql("UserAccounts_Update", Schema = "dbo")]
        public abstract Task UpdateUserAccount(UserAccounts user);
    }
}
