namespace SpecflowSeleniumMayBatchProject.Support
{
    public class readConfigData
    {
        private IConfigurationRoot _config;
        public readConfigData()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json");

            _config = builder.Build();
        }

        public string GetUrl1(string key) => _config[key]!;
    }
}