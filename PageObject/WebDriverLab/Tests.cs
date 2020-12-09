using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverLab.Pages;

namespace WebDriverLab
{
    public class Tests
    {
        IWebDriver driver;
        private readonly int FirstTestExpectedResult = 3198;
        private readonly string SecondTestEstexpectedResult = "Ваша корзина пуста";

        [SetUp]
        public void BrowserSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://shop.huawei.by/");
        }

        [Test]
        public void AddToBasketTwoProducts()
        {

            HuaweiMainPage page = new HuaweiMainPage(driver);
            Smartphones smartPhonespage =
                page.OpenHomePage()
                .OpenSmartphones()
                .AddToBasketPhoneMate30Pro();
            Tablets tabletsPage =
                page.OpenTablets()
                .AddToBasketMatePad();
            int basketPage =
                page.OpenBasketPage()
                .GetPrice()
                .GetTotalPriceOfTwoProducts();
            Assert.AreEqual(basketPage, FirstTestExpectedResult);
        }

        [Test]
        public void OrderZeroProducts()
        {
            HuaweiMainPage test = new HuaweiMainPage(driver);
            test.OpenHomePage().AddPhoneMate30Pro();
            string basketPage =
                test.OpenBasketPage()
                .EditNumberOfProducts()
                .OrderProduct()
                .WaitForElement()
                .GetStatusBasketPage();
            Assert.AreEqual(basketPage, SecondTestEstexpectedResult);
        }

        [TearDown]
        public void BrowserTearDown()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
