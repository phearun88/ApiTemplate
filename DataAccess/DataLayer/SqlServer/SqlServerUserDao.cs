using ProjectTemplate.DataAccess.Models;
using System;
using System.Data;
using System.Linq;
namespace ProjectTemplate.DataAccess.SqlServer
{
    public class SqlServerUserDao : IUserDao
    {
        /// <summary>
        /// Gets a specific user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            string sql =
            @" select userId, userName from users " +
            " where userId = @userId ";
            object[] parms = { "@userId", userId };
            var result = Db.ReadList(sql, Make, parms).FirstOrDefault();
            return result == null ? new User() : (User)result;
        }

        /// <summary>
        /// Login using user name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            // For Testing Only
            return true;

            string sql =
            @" select userId, userName from users " +
            " where userId = @userId " +
            " and password = @password "; ;
            object[] parms = { "@userName", userName, "@password", password };
            var result = Db.ReadList(sql, Make, parms).FirstOrDefault();
            return result == null ? false : result.UserId > 0;

        }

        /// <summary>
        /// Creates User object from IDataReader.
        /// </summary>
        private static Func<IDataReader, User> Make = reader =>
        new User
        {
            UserId = (int)reader["userId"],
            UserName = reader["userName"].ToString()
        };

        /// <summary>
        /// Creates query parameter list from User object.
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>Name value parameter list</returns>
        private object[] Take(User user)
        {
            return new object[]
            {
                "@userId", user.UserId,
                "@userName", user.UserName
            };
        }
    }
}