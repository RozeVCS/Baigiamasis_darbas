using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using static Framework.Driver;

[TestFixture]
public class BuyBookTests
{
    IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        InitializeDriver();
        OpenPage("https://www.pegasas.lt/");
        GetDriver().Manage().Window.Maximize();
    }

    [Test]
    public void BuyBookScenario()
    {
        HomePage homePage = new HomePage(GetDriver());

        
        BooksPage booksPage = homePage.NavigateToBooksPage();
        Assert.That(booksPage.IsBooksPageLoaded(), "Books page did not load successfully.");

        
        BookDetailsPage bookDetailsPage = booksPage.ClickOnBook(0);
        Assert.That(bookDetailsPage.IsBookDetailsPageLoaded(), "Book details page did not load successfully.");

        
        bookDetailsPage.AddToCart();

        
        ShoppingCartPage shoppingCartPage = bookDetailsPage.GoToShoppingCart();
        Assert.That(shoppingCartPage.IsShoppingCartPageLoaded(), "Shopping cart page did not load successfully.");

        
        CheckoutPage checkoutPage = shoppingCartPage.ContinueToCheckout();
        Assert.That(checkoutPage.IsCheckoutPageLoaded(), "Checkout page did not load successfully.");

        
        checkoutPage.FillBillingInformation("Luke", "Julia", "luke.lars@gmail.com", "364 Street", "City", "12345", "123456789");
        checkoutPage.FillPaymentInformation("Luke Lars", "3827717222", "10/16", "281");

        
        OrderConfirmationPage orderConfirmationPage = checkoutPage.PlaceOrder();
        Assert.That(orderConfirmationPage.IsOrderConfirmationPageLoaded(), "Order confirmation page did not load successfully.");

        
        Assert.That(orderConfirmationPage.IsOrderSuccessful(), "Order was not successful.");
    }

        string expectedOrderDetails = "Order placed successfully for book: " + bookDetailsPage.GetBookTitle();
        string actualOrderDetails = orderConfirmationPage.GetOrderConfirmationMessage();
        Assert.AreEqual(expectedOrderDetails, actualOrderDetails, "Unexpected order details on the confirmation page.");

    [TearDown]
    public void TearDown()
    {
        QuitDriver();
    }
}