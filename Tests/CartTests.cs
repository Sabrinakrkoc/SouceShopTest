using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoShop.Base;
using SauceDemoShop.Pages;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class CartTests : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private CartPage cartPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
            cartPage = new CartPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        [AllureFeature("Cart")]
        public void AddAndRemoveProductFromCartTest()
        {
            productPage.AddProductToCart();
            Assert.That(productPage.GetCartItemCount(), Is.EqualTo(1));

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/cart.html");
            cartPage.RemoveProductFromCart();
            Assert.That(cartPage.GetCartItemCount(), Is.EqualTo(0));
        }
    };
}