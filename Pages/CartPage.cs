using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoShop.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement RemoveButton => _wait.Until(d => d.FindElement(By.Id("remove-sauce-labs-backpack")));
        private IWebElement ShoppingCartBadge => _driver.FindElement(By.CssSelector(".shopping_cart_badge"));

        public void RemoveProductFromCart()
        {
            RemoveButton.Click();
        }

        public int GetCartItemCount()
        {
            try
            {
                return ShoppingCartBadge.Displayed ? int.Parse(ShoppingCartBadge.Text) : 0;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}
