using ProjectTemplate.Common;
using System.Configuration;

namespace ProjectTemplate.DataAccess
{
    public static class DataAccessObject
    {
        ////private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        ////private static readonly string connectionStringName = ConfigurationSettingService.GetAppSetting(Consts.DB_CONNECTION_STRING_NAME);

        private static readonly string dataProvider = ConfigurationSettingService.GetAppSetting(Consts.DB_DATA_PROVIDER);
        private static readonly IDaoFactory factory = DaoFactories.GetFactory(dataProvider);

        /// <summary>
        /// Gets a user data access object.
        /// </summary>
        public static IUserDao UserDao
        {
            get { return factory.UserDao; }
        }


        ////public static IProductDao ProductDao
        ////{
        ////    get { return factory.ProductDao; }
        ////}
    }
}
