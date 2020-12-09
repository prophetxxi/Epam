using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverLab.Pages
{
    public class Smartphones
    {
        private const string PAGE_URL = "https://shop.huawei.by/smart/";

        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item']//button[@class='standart-btn']")]
        protected readonly IWebElement addButton;

        public Smartphones(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public Smartphones AddToBasketPhoneMate30Pro()
        {
            addButton.Click();
            return this;
        }
    }
}
