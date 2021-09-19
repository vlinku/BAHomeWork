using NUnit.Framework;


namespace BATask.Test
{
  class BATest : BaseTest
  {
    

    [Test]
    public static void DressSearch()
    {
      _BApage.NavigateToPage();
      _BApage.MyStoreSearchClick("dresses");
      _BApage.CompareSearchResult("dresses");
      _BApage.SelectDress();
      _BApage.AddDressToCart("0");
      _BApage.ProceedToCheck();
      _BApage.EnterEmail("BATask@mail.com");
      _BApage.EnterPassword("Vilnius");
      _BApage.ClickSignIn();
      _BApage.ToCheckoutAfterAddress();
      _BApage.ShippingClicks();
      _BApage.Payment();
      _BApage.CheckOrderConfirmation("Your order on My Store is complete.");


    }
    
  }
}
