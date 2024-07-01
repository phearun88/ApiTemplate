namespace ProjectTemplate.DataAccess.Oracle.Implementation
{
    public class OracleDaoFactory : IDaoFactory
    {
        /// <summary>
        /// Gets a Oracle's User DAO
        /// </summary>
        public IUserDao UserDao
        {
            get { return new OracleUserDao(); }
        }
    }
}