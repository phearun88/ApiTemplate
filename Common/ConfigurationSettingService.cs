namespace ProjectTemplate.Common
{
    public static class ConfigurationSettingService
    {
        public static string GetAppSetting(string appSettingName)
        {
            return new ConfigurationBuilder().AddJsonFile(Consts.APP_SETTINGS_JSON).Build().GetSection(Consts.APP_SETTINGS)[appSettingName];
        }
        

    }
}
