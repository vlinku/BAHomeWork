using BATask.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace BATask.Test
{
  public class BaseTest
  {
    public static IWebDriver Chrome;
    public static BAPage _BApage;


    [OneTimeSetUp]
    public static void SetUp()
    {
      Chrome = new ChromeDriver();

      Chrome.Manage().Window.Maximize();
      Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      _BApage = new BAPage(Chrome);
    }

    [OneTimeTearDown]
    public static void TearDown()
    {
      Chrome.Quit();
    }
  }
}

