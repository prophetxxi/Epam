using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverLab.Pages
{
    public class Tablets
    {
        private const string PAGE_URL = "https://shop.huawei.by/planshet/";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item']//button[@class='standart-btn']")]
        protected readonly IWebElement addButton;

        public Tablets(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }   

        public Tablets AddToBasketMatePad()
        {
            addButton.Click();
            return this;
        }
    }
}
