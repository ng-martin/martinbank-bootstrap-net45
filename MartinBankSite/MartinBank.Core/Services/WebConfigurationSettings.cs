using MartinBank.Core.Interfaces;

namespace MartinBank.Core.Services
{
    public class WebConfigurationSettings : IWebConfigurationSettings
    {
        public string GetBankName()
        {
            return GetConfig("BankName");
        }

        private static string GetConfig(string key)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[key] != null)
            {
                return System.Configuration.ConfigurationManager.AppSettings[key];
            }
            return string.Empty;
        }
    }
}
