namespace SpecflowSeleniumMayBatchProject.Pages.SwagLabPages;

public class SL_Basket : Driver
{
    public SL_Basket(IWebDriver _driver)
       => driver = _driver;

    #region start of locator

    IReadOnlyCollection<IWebElement> cartItems => driver.FindElements(By.ClassName("cart_item"));

    #region end of locators

    #endregion start of methods

    public int GetItemCount() => cartItems.Count;

    #endregion end of methods
}