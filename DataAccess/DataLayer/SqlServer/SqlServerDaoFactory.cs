namespace ProjectTemplate.DataAccess.SqlServer.Implementation
{
    public class SqlServerDaoFactory : IDaoFactory
    {
        /// <summary>
        /// Gets a Sql Server's User DAO
        /// </summary>
        public IUserDao UserDao
        {
            get { return new SqlServerUserDao(); }
        }
    }
}