using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BATask.Page
{
  public class BAPage : BasePage
  {
    private const string WebAddress = "http://automationpractice.com/index.php";

    private IWebElement MyStoreSearch => Driver.FindElement(By.Id("search_query_top"));
    private IWebElement DressResults => Driver.FindElement(By.XPath("//a[@title= 'Printed Summer Dress' and @href='http://automationpractice.com/index.php?id_product=5&controller=product&search_query=dresses&results=7']"));
    private IWebElement AddToCart => Driver.FindElement(By.XPath("//button[@name='Submit' and @class='exclusive']"));
    private IWebElement ProceedToCheckout => Driver.FindElement(By.XPath("//a[@title='Proceed to checkout']"));
    private IWebElement ProceedSecondCheckout => Driver.FindElement(By.CssSelector(".button.btn.btn-default.standard-checkout.button-medium"));
    private IWebElement AddEmail => Driver.FindElement(By.XPath("//input[@data-validate='isEmail' and @id = 'email']"));
    private IWebElement AddPassword => Driver.FindElement(By.XPath("//input[@data-validate='isPasswd' ]"));
    private IWebElement SigninButton => Driver.FindElement(By.Id("SubmitLogin"));
    private IWebElement AddressProceedToCheckOut => Driver.FindElement(By.XPath("//*[@id='center_column']/form/p/button"));
    private IWebElement TermsOfServiceBox => Driver.FindElement(By.XPath("//*[@id='cgv']"));
    private IWebElement ShippingProceedToCheckout => Driver.FindElement(By.XPath("//*[@id='form']/p/button"));
    private IWebElement PayByBankWire => Driver.FindElement(By.XPath("//*[@id='HOOK_PAYMENT']/div[1]/div"));
    private IWebElement IConfirmMyOrderButton => Driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));


    public BAPage(IWebDriver webdriver) : base(webdriver) { }

    public BAPage NavigateToPage()
    {
      if (Driver.Url != WebAddress)
        Driver.Url = WebAddress;
      return this;
    }

    public void MyStoreSearchClick(string dress)
    {
      MyStoreSearch.Click();
      MyStoreSearch.Clear();
      MyStoreSearch.SendKeys(dress);
      Actions PressEnter = new Actions(Driver);
      PressEnter.SendKeys(Keys.Enter);
      PressEnter.Build().Perform();
    }

    public void CompareSearchResult(string Search)
    {
      string SearchResult = Driver.FindElement(By.XPath("//span[@class= 'lighter']")).Text;
      Assert.AreEqual(Search.ToUpper(), SearchResult.Replace("\"", "").Replace("\"", ""), "Search result do not match keyword");
    }

    public void SelectDress()
    {
      Actions mouseHover = new Actions(Driver);
      mouseHover.MoveToElement(Driver.FindElement(By.CssSelector(".ajax_block_product.col-xs-12.col-sm-6.col-md-4.first-in-line.first-item-of-tablet-line.first-item-of-mobile-line"))).Perform();
      DressResults.Click();
    }

    public void AddDressToCart(string Total)
    {
      AddToCart.Click();
      string TotalProducts = Driver.FindElement(By.CssSelector(".ajax_block_products_total")).Text;
      Assert.AreNotEqual(Total, TotalProducts.Replace("$", ""), "Search result do not match keyword");
    }

    public void ProceedToCheck()
    {
      ProceedToCheckout.Click();
      ProceedSecondCheckout.Click();
    }

    public void EnterEmail(string email)
    {
      AddEmail.Click();
      AddEmail.Clear();
      AddEmail.SendKeys(email);
    }
    public void EnterPassword(string Password)
    {
      AddPassword.Click();
      AddPassword.Clear();
      AddPassword.SendKeys(Password);
    }

    public void ClickSignIn()
    {
      SigninButton.Click();
    }
    public void ToCheckoutAfterAddress()
    {
      AddressProceedToCheckOut.Click();
    }
    public void ShippingClicks()
    {
      TermsOfServiceBox.Click();
      ShippingProceedToCheckout.Click();
    }
    public void Payment()
    {
      PayByBankWire.Click();
      IConfirmMyOrderButton.Click();
    }

    public void CheckOrderConfirmation(string Compare)
    {
      string OrderConfirmation = Driver.FindElement(By.XPath("//*[@id='center_column']/div/p/strong")).Text;
      Assert.AreEqual(Compare, OrderConfirmation, "Order confirmation texts do not match");
    }

  }
}
