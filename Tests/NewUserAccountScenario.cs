using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

    [TearDown]
    public void BaseTearDown()
    {
        driver.Quit();
    }
}

[TestFixture]
public class UserRegistrationTests : BaseTest
{
    [Test]
    public void NewUserAccountRegistration()
    {
        try
        {
            
            HomePage homePage = new HomePage(driver);
            RegistrationPage registrationPage = homePage.NavigateToRegistrationPage();
            Assert.That(registrationPage.IsRegistrationPageLoaded(), "Registration page did not load successfully.");

            
            registrationPage.FillRegistrationForm("Simon", "Julia", "simon.sirn@gmail.com", "password123");

            
            HomePage loggedInHomePage = registrationPage.ClickRegisterButton();
            Assert.That(loggedInHomePage.IsUserLoggedIn(), "User is not logged in after registration.");

            
            string expectedUserName = "Simon Julia"; 
            string actualUserName = loggedInHomePage.GetLoggedInUserName();
            Assert.AreEqual(expectedUserName, actualUserName, "Unexpected user name displayed after registration.");

            
            Assert.IsTrue(loggedInHomePage.IsWelcomeMessageDisplayed(), "Welcome message is not displayed after registration.");
        }
    }

}
}
     
