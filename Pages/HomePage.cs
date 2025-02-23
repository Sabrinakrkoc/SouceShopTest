using OpenQA.Selenium;

namespace SauceDemoShop.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly By _inventoryTitle = By.ClassName("title");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetInventoryTitle()
        {
            return _driver.FindElement(_inventoryTitle).Text;
        }
    }
}
