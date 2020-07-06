using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMB.NetAPI.Models
{
    /// <summary>
    /// User Accounts request model
    /// </summary>
    public class UserAccountsRequestModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}