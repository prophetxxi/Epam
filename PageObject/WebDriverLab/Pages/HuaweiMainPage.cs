using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverLab.Pages
{
    public class HuaweiMainPage
    {
        private static readonly string HOMEPAGE_URL = @"https://shop.huawei.by/";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='product-item']//button[@class='standart-btn']")]
        protected readonly IWebElement addPhone;
        
        public HuaweiMainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public HuaweiMainPage OpenHomePage()
        {
            driver.Navigate().GoToUrl(HOMEPAGE_URL);
            return this;
        }

        public HuaweiMainPage AddPhoneMate30Pro()
        {
            addPhone.Click();
            return this;
        }

        public Smartphones OpenSmartphones()
        {
            return new Smartphones(driver);
        }

        public Tablets OpenTablets()
        {
            return new Tablets(driver);
        }

        public BasketPage OpenBasketPage()
        {
            return new BasketPage(driver);
        }
    }
}
