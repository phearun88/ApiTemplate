using ProjectTemplate.DataAccess.Models;
namespace ProjectTemplate.DataAccess
{
    /// <summary>
    /// Defines methods to access users.
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// Gets a specific user by id
        /// </summary>
        /// <param name="userId">Unique user identifier</param>
        /// <returns>user</returns>
        User GetUser(int userId);

        /// <summary>
        /// Login using user name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>true/false</returns>
        bool Login(string userName, string password);
    }
}