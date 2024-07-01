namespace ProjectTemplate.DataAccess
{
    public class DbAdapter
    {
        public static IDaoFactory GetFactory(string dataProvider) {
            switch (dataProvider)
            {    
                case "SqlExpress":
                case "SqlServer": return new SqlServer.Implementation.SqlServerDaoFactory();

                // Default: SqlServer
                default: return new SqlServer.Implementation.SqlServerDaoFactory();
            }
        }
    }
}
