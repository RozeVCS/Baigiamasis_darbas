using Framework.Pages;
using Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using static Framework.Driver;

public class BaseTest
{
    protected IWebDriver driver;

    [SetUp]
    public void BaseSetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.pegasas.lt/");
        driver.Manage().Window.Maximize();
    }

    
}

[TestFixture]
public class BookSearchTests : BaseTest
{
    [Test]
    public void BookSearchFunction()
    {
        try
        {
            
            Pegasas homePage = new Pegasas HomePage(driver);

            
            homePage.EnterSearchQuery("The Catcher in the Rye");

            
            homePage.ClickSearchButton();

            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchResults = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='search-results']")));

            
            Assert.That(searchResults.Displayed, "Search results are not displayed.");

            
            Common.ClickElement("//div[@class='search-results']//div[@class='book'][1]");

            
            IWebElement bookDetails = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='book-details']")));

            
            Assert.That(bookDetails.Displayed, "Book details page did not load successfully.");

            
            string expectedBookTitle = "The Catcher in the Rye";
            string actualBookTitle = Common.GetElementText("//h1[@class='book-title']");
            Assert.Equals(expectedBookTitle, actualBookTitle, "Unexpected book title on the details page.");
        }
        finally
        {
            
        }
    }
}