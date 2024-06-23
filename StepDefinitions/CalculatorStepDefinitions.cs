namespace SpecflowSeleniumMayBatchProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions : Driver
    {
        readConfigData readConfigData;
        CalculatorDemoPage demoPage;
        public CalculatorStepDefinitions(IObjectContainer container) 
        {
            driver = container.Resolve<IWebDriver>();
            readConfigData = container.Resolve<readConfigData>();
            demoPage = container.Resolve<CalculatorDemoPage>();
        }

        [Given(@"I am on Calculator demo page")]
        public void GivenIAmOnCalculatorDemoPage()
        {
            driver.Navigate().GoToUrl(readConfigData.GetUrl1("QA:url1"));
        }

        [Given("the \"(.*)\" number is \"(.*)\"")]
        public void GivenTheSecondNumberIs(string flag, string number)
        {
            demoPage.EnterNumber(flag, number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            demoPage.clickAddButton();
        }

        [Then("the result should be \"(.*)\"")]
        public void ThenTheResultShouldBe(string expected)
        {
            WebDriverWait wait = 
                new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            wait.Until(x => !demoPage.GetResult());
            var actual = driver.FindElement(By.Id("result"))
                .GetAttribute("value");

            Assert.That(
                expected, 
                Is.EqualTo(actual),
                $"The expected: {expected} feature file data does not match web value data: {actual} it should be {actual}");
        }
    }
}