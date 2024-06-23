namespace SpecflowSeleniumMayBatchProject
{
    public class Browser : Driver
    {
        public IWebDriver InitializeBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Chrome":
                    ChromeOptions Coptions = new ChromeOptions();
                    Coptions.AddArgument("--start-maximized");
                    driver = new ChromeDriver(Coptions);
                    break;
                case "Edge":
                    EdgeOptions Eoptions = new EdgeOptions();
                    Eoptions.AddArgument("--start-maximized");
                    driver = new EdgeDriver(Eoptions);
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }

        public void TearDown() => driver.Quit();
    }
}