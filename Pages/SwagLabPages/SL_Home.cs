namespace SpecflowSeleniumMayBatchProject.Pages.SwagLabPages;

public class SL_Home : Driver
{
    public SL_Home(IWebDriver _driver)
       => driver = _driver;


    #region start of locator

    private IWebElement username =>
        driver.FindMyElementAndWait(By.Id("user-name"));
    private IWebElement password =>
        driver.FindMyElementAndWait(By.Id("password"));
    private IWebElement loginBtn =>
        driver.FindMyElement(By.Id("login-button"));

    #region end of locators

    #endregion start of methods
    public void EnterUerAndPass(Table table)
    {
        username.SendKeys(table.Rows[0]["username"]);
        password.SendKeys(table.Rows[0]["password"]);
    }

    public void ClickLoginButton() => loginBtn.Click();

    #endregion end of methods
}