namespace SpecflowSeleniumMayBatchProject.Pages
{
    public class CalculatorDemoPage : Driver
    {
        public CalculatorDemoPage(IWebDriver _driver) //constructor - ctor
            => driver = _driver;


        #region start of elements

        private IWebElement numbers(string value) =>
            driver.FindElement(By.Id($"{value}-number"));
        private IWebElement result => 
            driver.FindElement(By.Id("result"));
        private IWebElement addButton =>
            driver.FindElement(By.Id("add-button"));

        #endregion end of elements


        #region start of methods

        public void EnterNumber(string flag, string number)
        {
            numbers(flag).Clear();
            numbers(flag).SendKeys(number);
        }

        public void clickAddButton() => addButton.Click();

        public bool GetResult() 
            => result.GetAttribute("value").Equals("");

        #endregion end of methods
    }
}
