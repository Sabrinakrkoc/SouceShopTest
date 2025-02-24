using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemoShop.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IList<IWebElement> AddToCartButtons => _wait.Until(d => d.FindElements(By.CssSelector(".btn_inventory")));

        private IWebElement ShoppingCartBadge => _driver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement SortDropdown => _wait.Until(d => d.FindElement(By.CssSelector(".product_sort_container")));
        private IList<IWebElement> InventoryItemPrices => _wait.Until(d => d.FindElements(By.CssSelector(".inventory_item_price")));
        private IWebElement BurgerMenu => _wait.Until(d => d.FindElement(By.Id("react-burger-menu-btn")));
        private IWebElement LogoutButton => _wait.Until(d => d.FindElement(By.Id("logout_sidebar_link")));
        private IWebElement UserAvatar => _wait.Until(d => d.FindElement(By.CssSelector(".bm-burger-button")));

        public void AddProductToCart()
        {
            _wait.Until(d => AddToCartButtons.Count > 0); 
            AddToCartButtons.First().Click();
        }

        public void AddMultipleProductsToCart(int count)
        {
            _wait.Until(d => AddToCartButtons.Count >= count);
            for (int i = 0; i < count; i++)
            {
                AddToCartButtons[i].Click();
            }
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

        public void AddSpecificProductToCart(int productIndex)
        {
            var productButtons = _wait.Until(d => d.FindElements(By.CssSelector(".btn_inventory")));
            productButtons[productIndex].Click();
        }

        public void SortProductsByPriceLowToHigh()
        {
            SortDropdown.Click();
            _wait.Until(d => d.FindElement(By.CssSelector("option[value='lohi']"))).Click();
        }

        public List<decimal> GetProductPrices()
        {
            var priceElements = _wait.Until(d => d.FindElements(By.CssSelector(".inventory_item_price")));
            return priceElements.Select(e => decimal.Parse(e.Text.Trim('$'))).ToList();
        }

        public void Logout()
        {
            _wait.Until(d => UserAvatar.Displayed);
            BurgerMenu.Click();
            _wait.Until(d => d.FindElement(By.ClassName("bm-menu-wrap")));
            LogoutButton.Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                _wait.Until(d => UserAvatar.Displayed);
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
