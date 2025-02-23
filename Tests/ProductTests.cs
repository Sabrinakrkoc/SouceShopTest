using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoShop.Base;
using SauceDemoShop.Pages;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class ProductTests : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
            Assert.That(productPage.IsLoggedIn(), Is.True, "Login failed, user not logged in.");
        }

        [Test]
        [AllureFeature("Product")]
        public void AddSingleProductToCartTest()
        {
            productPage.AddProductToCart();
            Assert.That(productPage.GetCartItemCount(), Is.EqualTo(1), "Product was not added to the cart.");
        }

        [Test]
        public void SortProductsByPriceLowToHighTest()
        {
            productPage.SortProductsByPriceLowToHigh(); // Ordenar los productos por precio de bajo a alto
            var prices = productPage.GetProductPrices(); // Obtener los precios de los productos
            var sortedPrices = prices.OrderBy(p => p).ToList();
            Assert.That(prices, Is.EqualTo(sortedPrices)); // Verificar que los precios están ordenados correctamente
        }

        [Test]
        [AllureFeature("Product")]
        public void AddMultipleProductsToCartTest()
        {
            productPage.AddMultipleProductsToCart(3);
            Assert.That(productPage.GetCartItemCount(), Is.EqualTo(3), "Multiple products were not added to the cart.");
        }

    }
}
