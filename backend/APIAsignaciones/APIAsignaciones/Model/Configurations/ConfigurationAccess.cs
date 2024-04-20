namespace APIAsignaciones.Model.Configurations
{
    public class ConfigurationAccess
    {
        public static readonly ConfigurationAccess Instance = new ConfigurationAccess();
        private IConfiguration _configuration;

        private ConfigurationAccess()
        {

        }

        public void Initialization(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string key)
        {
            return _configuration.GetConnectionString(key) ?? "";
        }
    }
}
