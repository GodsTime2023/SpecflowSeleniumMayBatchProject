namespace SpecflowSeleniumMayBatchProject.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// This method will clear an input field and enter new value into the field
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="flag"></param>
        /// <param name="number"></param>
        public static void EnterNumberExtension(this IWebDriver driver, 
            IWebElement element, string number)
        {
            element.Clear(); 
            element.SendKeys(number); 
        }

        /// <summary>
        /// This method will find an element and click on it
        /// </summary>
        /// <param name="element"></param>
        public static void ClickAddButton(this IWebDriver driver, By locator)
        {
            driver.FindElement(locator).Click();
        }

        /// <summary>
        /// This method will find an element and click on it
        /// </summary>
        /// <param name="element"></param>
        public static void ClickAddButton(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// This method will find an element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement FindMyElement(this IWebDriver driver, By locator)
        {
            return driver.FindElement(locator);
        }

        /// <summary>
        /// This method will find an element and wait until displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static IWebElement FindMyElementAndWait(this IWebDriver driver, 
            By locator, int time = 30)
        {
            Thread.Sleep(1000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);
        }
    }
}
