namespace SpecflowSeleniumMayBatchProject.Pages
{
    public class CalculatorDemoPage : Driver
    {
        //constructor - ctor
        public CalculatorDemoPage(IWebDriver _driver) 
            => driver = _driver;

        //Elements
        private IWebElement numbers(string value) =>
            driver.FindElement(By.Id($"{value}-number"));
        private IWebElement result => 
            driver.FindElement(By.Id("result"));
        private IWebElement addButton =>
            driver.FindElement(By.Id("add-button"));


        //Methods
        public void EnterNumber(string flag, string number)
            => numbers(flag).SendKeys(number);

        public void clickAddButton() => addButton.Click();

        public bool GetResult() 
            => result.GetAttribute("value").Equals("");
    }
}
