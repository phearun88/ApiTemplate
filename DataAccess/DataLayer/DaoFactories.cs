using ProjectTemplate.DataAccess.Oracle.Implementation;
using ProjectTemplate.DataAccess.SqlServer.Implementation;

namespace ProjectTemplate.DataAccess
{
    public class DaoFactories
    {
        public static IDaoFactory GetFactory(string dataProvider) {
            switch (dataProvider)
            {    
                case "SqlExpress":
                case "SqlServer": return new SqlServerDaoFactory();
                case "Oracle": return new OracleDaoFactory();

                // Default: SqlServer
                default: return new SqlServerDaoFactory();
            }
        }
    }
}

