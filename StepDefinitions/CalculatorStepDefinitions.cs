namespace SpecflowSeleniumMayBatchProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions : Driver
    {
        readConfigData readConfigData;
        CalculatorDemoPage demoPage;
        //string result1;
        //string result2;
        Dictionary<string, List<string>> resultsCollection;

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
                expected, Is.EqualTo(actual),
                $"The expected: {expected} feature file data does not match web value data: {actual} it should be {actual}");
        }

        [When(@"I add the follow:")]
        public void WhenIAddTheFollow(IEnumerable<tabDat> data)
        {
            //int flag = 0;
            //foreach (var value in table.Rows)
            //{
            //    demoPage.EnterNumber(value.Keys.First(),
            //        value.Values.First());

            //    demoPage.EnterNumber(value.Keys.ElementAt(1),
            //        value.Values.ElementAt(1));
            //    demoPage.clickAddButton();

            //    WebDriverWait wait =
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            //    wait.Until(x => !demoPage.GetResult());
            //    Thread.Sleep(2000);
            //    var res1 = flag.Equals(0)
            //        ? result1 = driver.FindElement(By.Id("result"))
            //          .GetAttribute("value")
            //        : flag.Equals(1)
            //        ? result2 = driver.FindElement(By.Id("result"))
            //          .GetAttribute("value")
            //        : null!;
            //    flag++;
            //}

            //var data = table.CreateSet<tabDat>(); //deserialization
            List<string> resultList = new List<string>();
            foreach (var val in data)
            {
                demoPage.EnterNumber(data.FirstOrDefault()?
                    .GetType().GetProperty("first")?.Name!,
                    val.first);

                demoPage.EnterNumber(data.FirstOrDefault()?
                    .GetType().GetProperty("second")?.Name!,
                    val.second);

                demoPage.clickAddButton();
                WebDriverWait wait =
                new WebDriverWait(driver, TimeSpan.FromSeconds(1));

                wait.Until(x => !demoPage.GetResult());
                Thread.Sleep(1000);

                string result = driver.FindElement(By.Id("result"))
                    .GetAttribute("value");
                resultList.Add(result);
                val.results.Add("result", resultList);
                resultsCollection = val.results;
            }
        }

        [Then(@"the result should be:")]
        public void ThenTheResultShouldBe(Table table)
        {
            //var tableData0 = table.Rows[0].Values.First();
            //var tableData1 = table.Rows[1].Values.First();

            //Assert.AreEqual(tableData0, result1);
            //Assert.AreEqual(tableData1, result2);

            var expectedData = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                expectedData.Add(table.Rows[i].FirstOrDefault().Value);
            }

            foreach (KeyValuePair<string, List<string>> actualData
                    in resultsCollection)
            {
                Assert.AreEqual(expectedData, actualData.Value);
            }
        }

        public class tabDat
        {
            public string first { get; set; }
            public string second { get; set; }
            public Dictionary<string, List<string>> results
                = new Dictionary<string, List<string>>();
        }
    }
}