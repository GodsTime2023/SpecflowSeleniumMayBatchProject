namespace SpecflowSeleniumMayBatchProject.Pages.SwagLabPages;

public class SL_product : Driver
{
    WebDriverWait wait;
    public SL_product(IWebDriver _driver)
    {
        driver = _driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    #region start of locator
    IWebElement productPageHeader => 
        driver.FindElement(By.XPath("//*[@class='header_label']/div"));
    IReadOnlyCollection<IWebElement> addToCartButton => 
        driver.FindElements(By.XPath("//*[text()='Add to cart']"));
    IWebElement basketIcon => driver.FindElement(By.ClassName("shopping_cart_link"));
    
    

    #region end of locators

    #endregion start of methods
    public bool IsProductPageHeaderdisplayed()
    {
        wait.Until(d => productPageHeader.Displayed);
        return productPageHeader.Displayed;
    }

    public void AddItemToCart(int index)=> addToCartButton.ElementAt(index).Click();
    public IReadOnlyCollection<IWebElement> AddItemToCart() => addToCartButton;
    public void ClickCart()
    {
        basketIcon.Click();
        wait.Until(d => d.FindElement(By.ClassName("cart_item")));
    }

    #endregion end of methods
}
