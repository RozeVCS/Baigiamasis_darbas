using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static Framework.Driver;

[TestFixture]
public class BookCategoriesTests
{
    IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.pegasas.lt/");
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void BookCategoriesNavigation()
    {
        DriverHomePage homePage = new DriverHomePage(driver);

        Assert.That(homePage.IsHomePageLoaded(), "Home page did not load successfully.");

        DriverBooksPage booksPage = homePage.NavigateToBooksPage();
        Assert.That(booksPage.IsBooksPageLoaded(), "Books page did not load successfully.");

        DriverFictionBooksPage fictionBooksPage = booksPage.SelectBookCategory("Fiction");
        Assert.That(fictionBooksPage.IsFictionBooksPageLoaded(), "Fiction books page did not load successfully.");

        DriverBookDetailsPage bookDetailsPage = fictionBooksPage.ClickOnBook(0);
        Assert.That(bookDetailsPage.IsBookDetailsPageLoaded(), "Book details page did not load successfully.");

        string expectedAuthor = "Expected Author";
        string actualAuthor = bookDetailsPage.GetBookAuthor();
        Assert.AreEqual(expectedAuthor, actualAuthor, "Unexpected author on the details page.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

