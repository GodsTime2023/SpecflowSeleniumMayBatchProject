namespace SpecflowSeleniumMayBatchProject.Hooks
{
    [Binding]
    public class BaseHook : Browser
    {
        IObjectContainer container;
        public BaseHook(IObjectContainer objectContainer) 
            => container = objectContainer;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            InitializeBrowser("Chrome");
            container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario() => TearDown();
    }
}