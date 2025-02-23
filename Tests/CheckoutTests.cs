using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoShop.Base;
using SauceDemoShop.Pages;
using System.Linq;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class CheckoutTests : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
            cartPage = new CartPage(_driver);
            checkoutPage = new CheckoutPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        [AllureFeature("Checkout")]
        public void SuccessfulCheckoutTest()
        {
            productPage.AddMultipleProductsToCart(3);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            checkoutPage.StartCheckout();
            checkoutPage.EnterCheckoutInformation("John", "Doe", "12345");

            // Obtener los precios y totales
            var itemPrices = checkoutPage.GetItemPrices();
            var itemTotal = checkoutPage.GetItemTotal();
            var taxTotal = checkoutPage.GetTaxTotal();

            // Verificar que la suma de precios de los ítems + impuestos sea igual al total
            Assert.That(itemTotal + taxTotal, Is.EqualTo(itemPrices.Sum() + taxTotal).Within(0.01));

            checkoutPage.FinishCheckout();
            Assert.That(checkoutPage.GetConfirmationMessage(), Does.Contain("Thank you for your order!"));
        }

        [Test]
        [AllureFeature("Checkout")]
        public void CheckoutWithMissingDetailsTest()
        {
            productPage.AddProductToCart();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            checkoutPage.StartCheckout();
            checkoutPage.EnterCheckoutInformation("", "Doe", "12345");

            // Verificar que el mensaje de error sea el esperado
            Assert.That(checkoutPage.GetErrorMessage(), Does.Contain("Error: First Name is required"));
        }
    }
}
