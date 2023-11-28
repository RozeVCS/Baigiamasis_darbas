using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsHomePageLoaded()
        {
           
            By homePageLocator = By.XPath("//div[@class='home-page-content']");
            return wait.Until(d => d.FindElements(homePageLocator).Count > 0);
        }

        public bool IsMainMenuDisplayed()
        {
            
            By mainMenuLocator = By.XPath("//nav[@id='main-menu']");
            return wait.Until(d => d.FindElement(mainMenuLocator).Displayed);
        }

        public AuthorsPage NavigateToAuthorsPage()
        {
            
            By authorsLinkLocator = By.XPath("//nav[@id='main-menu']//a[contains(text(),'Authors')]");
            wait.Until(ExpectedConditions.ElementToBeClickable(authorsLinkLocator)).Click();

            
            return new AuthorsPage(driver);
        }
    }
}