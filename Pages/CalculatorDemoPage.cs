namespace SpecflowSeleniumMayBatchProject.Pages
{
    public class CalculatorDemoPage : Driver
    {
        public CalculatorDemoPage(IWebDriver _driver) //constructor - ctor
            => driver = _driver;


        #region start of elements

        private IWebElement numbers(string value) =>
            driver.FindMyElementAndWait(By.Id($"{value}-number"));
        private IWebElement result => 
            driver.FindMyElementAndWait(By.Id("result"));
        private IWebElement addButton =>
            driver.FindMyElement(By.Id("add-button"));

        #endregion end of elements


        #region start of methods

        public void EnterNumber(string flag, string number) 
            => driver.EnterNumberExtension(numbers(flag), number);

        public void clickAddButton() => addButton.ClickAddButton();

        public bool GetResult() 
            => result.GetAttribute("value").Equals("");

        #endregion end of methods
    }
}
