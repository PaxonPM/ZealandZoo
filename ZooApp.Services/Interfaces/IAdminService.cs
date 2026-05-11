using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// Validates the login credentials of an admin user.
        /// </summary>
        /// <param name="username">The username of the admin.</param>
        /// <param name="password">The password of the admin.</param>
        /// <returns>True if the credentials are valid, otherwise false.</returns>
        bool ValidateLogin(string username, string password);
    }
}
