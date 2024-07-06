namespace SpecflowSeleniumMayBatchProject.Hooks
{
    [Binding]
    public class BaseHook : Browser
    {
        IObjectContainer container;
        private static ScenarioContext? _scenarioContext;
        private static ExtentReports? _extentReport;
        private static ExtentSparkReporter? _extentSparkReporter;
        private static ExtentTest? _feature;
        private static ExtentTest? _scenario;

        public BaseHook(IObjectContainer objectContainer) 
            => container = objectContainer;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            _extentSparkReporter =
            new ExtentSparkReporter(GetCurrentDirectory());
            _extentReport = new ExtentReports();
            _extentReport.AttachReporter(_extentSparkReporter);
        }
        public static string GetCurrentDirectory()
        {
            var path = Directory.GetParent(
                Directory.GetCurrentDirectory())?.Parent?.Parent
                + "\\Reports\\report.html";
            return path;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (null != featureContext)
            {
                _feature = _extentReport?.CreateTest<Feature>(featureContext.FeatureInfo.Title,
                    featureContext.FeatureInfo.Description);
            }
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            InitializeBrowser("Chrome");
            container.RegisterInstanceAs(driver);
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature?.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title,
                    scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public void AfterStep()
        {
            ExtentTest? stepNode = null;
            //Method to add take screen shot when test fail
            var mediaEntity =
                CaptureScreenShotAndReturnModel(driver, _scenarioContext?.ScenarioInfo.Title.Trim());

            try
            {
                stepNode = _scenario?.CreateNode(
                new GherkinKeyword(_scenarioContext?.StepContext.StepInfo.StepDefinitionType.ToString()),
                 _scenarioContext?.StepContext.StepInfo.Text);

                //Add tables to report
                if (_scenarioContext?.StepContext.StepInfo.Table != null)
                {
                    stepNode?.Log(Status.Info, $"|{string.Join("|", _scenarioContext.StepContext.StepInfo.Table.Header)}|");
                    foreach (var row in _scenarioContext.StepContext.StepInfo.Table.Rows)
                    {
                        stepNode?.Log(Status.Info, $"|{string.Join("|", row.Values)}|");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Media CaptureScreenShotAndReturnModel(IWebDriver driver, string ScreenShotName)
            {
                var Screenshot = ((ITakesScreenshot)driver)
                    .GetScreenshot().AsBase64EncodedString;
                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot, ScreenShotName).Build();
            }

            //Conditional statement to check what error was thrown then state the error in report
            if (_scenarioContext?.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            {
                List<ScenarioExecutionStatus> failTypes = new List<ScenarioExecutionStatus>()
            {
                ScenarioExecutionStatus.BindingError,
                ScenarioExecutionStatus.TestError,
                ScenarioExecutionStatus.UndefinedStep,
                ScenarioExecutionStatus.StepDefinitionPending
            };

                if (failTypes.Any())
                {
                    stepNode?.Fail("This step failed", mediaEntity);
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            TearDown();
        }

        [AfterTestRun]
        public static void AftertestRun()
        {
            //Flushes to ensure the report is printed 
            _extentReport?.Flush();
        }

        Media CaptureScreenShotAndReturnModel(IWebDriver driver, string ScreenShotName)
        {
            var Screenshot = ((ITakesScreenshot)driver)
                .GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot, ScreenShotName).Build();
        }
    }
}