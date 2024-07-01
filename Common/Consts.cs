namespace ProjectTemplate.Common
{
    public static class Consts
    {
        #region " Configuration Setting "
        public const string APP_SETTINGS_JSON = "appsettings.json";
        public const string APP_SETTINGS = "AppSettings";
        public const string APP_SETTINGS_SECRET_KEY = "SecretKey";
        #endregion


        #region " Warning Message "
        public const string MSG_TOKEN_IS_REQUIRED = "Token is required.";
        public const string MSG_TOKEN_IS_INVALID = "Token is invalid.";
        public const string MSG_INCORRECT_USER_NAME_OR_PASSWORD = "Username and/or password that you have entered is incorrect.";
        #endregion


        #region " Database Configuration "
        public const string DB_DATA_PROVIDER = "SqlServer";
        public const string DB_CONNECTION_STRING_DATA_PROVIDER = "DataProvider";
        public const string DB_CONNECTION_STRING_NAME = "ConnectionStringName";
        #endregion

    }
}
