namespace SpecflowSeleniumMayBatchProject.StepDefinitions;

[Binding]
public class SaucedemoStepDefinitions : Driver
{
    readConfigData readConfigData;
    SL_Home slHome;
    SL_product slProduct;
    SL_Basket slbasket;

    public SaucedemoStepDefinitions(IObjectContainer container)
    {
        driver = container.Resolve<IWebDriver>();
        readConfigData = container.Resolve<readConfigData>();
        slHome = container.Resolve<SL_Home>();
        slProduct = container.Resolve<SL_product>();
        slbasket = container.Resolve<SL_Basket>();
    }

    [Given(@"I am on SwagLab login page")]
    public void GivenIAmOnSwagLabLoginPage()
    {
        driver.Navigate().GoToUrl(readConfigData.GetUrl1("QA:url2"));
    }

    [Given(@"I enter the following credentials")]
    public void GivenIEnterTheFollowingCredentials(Table table)
    {
        slHome.EnterUerAndPass(table);
    }

    [When(@"I click login button")]
    public void WhenIClickLoginButton()
    {
        slHome.ClickLoginButton();
    }

    [Then(@"I am on product page")]
    public void ThenIAmOnProductPage()
    {
        var isDisplayed = slProduct.IsProductPageHeaderdisplayed();
        Assert.That(isDisplayed, Is.EqualTo(true));
    }

    [When(@"I add item to cart")]
    public void WhenIAddItemToCart()
    {
        //for loop example
        //int itemcount = 2;
        //for (int i = 0; i <= itemcount; i++)
        //{
        //    slProduct.AddItemToCart(i);
        //}

        int itemCount = 2;
        int i = 0;

        //While loop example
        //while (i <= itemCount)
        //{
        //    slProduct.AddItemToCart(i);
        //    i++;
        //}

        //do while loop example
        //do{ slProduct.AddItemToCart(i); i++; } while (i <= itemCount);

        //Foreeach loop example
        foreach (var item in slProduct.AddItemToCart())
        {
            if (i <= itemCount)
            {
                slProduct.AddItemToCart().ElementAt(i).Click();
                i++;
            }
            else
            {
                break;
            }
        }
    }

    [When(@"I click the basket")]
    public void WhenIClickTheBasket()
    {
        slProduct.ClickCart();
    }

    [Then(@"total item in cart is (.*)")]
    public void ThenTotalItemInCartIs(int expectedCount)
    {
        var actualcount = slbasket.GetItemCount();
        Assert.That(actualcount, Is.EqualTo(expectedCount));
        Thread.Sleep(3000);
    }
}
