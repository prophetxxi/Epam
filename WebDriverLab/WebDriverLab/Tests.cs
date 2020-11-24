using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverLab
{
    class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://shop.huawei.by");
        }

        [Test]
        public void Testcase()
        {
            IWebElement phonesList = driver.FindElement(By.LinkText("Смартфоны"));
            phonesList.Click();

            IWebElement allPhonesListLink = driver.FindElement(By.LinkText("Все Смартфоны"));
            allPhonesListLink.Click();

            IWebElement phoneMate30Pro = driver.FindElement(By.LinkText("Смартфон Huawei Mate 30 Pro LIO-L29 8GB/256GB (серебристый)"));
            phoneMate30Pro.Click();

            IWebElement addPhoneMate30Pro = driver.FindElement(By.CssSelector("button.empty-btn.new-cart"));
            addPhoneMate30Pro.Click();

            IWebElement tabletsList = driver.FindElement(By.LinkText("Планшеты"));
            tabletsList.Click();

            IWebElement tabletsListLink = driver.FindElement(By.LinkText("Все Планшеты"));
            tabletsListLink.Click();

            IWebElement tabletMatePad = driver.FindElement(By.LinkText("Планшет Huawei MatePad 10.4 LTE 4GB/64GB (BAH3-L09) (полночный серый)"));
            tabletMatePad.Click();

            IWebElement addTabletMatePad = driver.FindElement(By.CssSelector("button.empty-btn.new-cart"));
            addTabletMatePad.Click();

            IWebElement orderBasketLink = driver.FindElement(By.ClassName("basket-icon"));
            orderBasketLink.Click();

            IWebElement isProductsInOrderBasket = driver.FindElement(By.ClassName("order-info-block"));

            Assert.NotNull(isProductsInOrderBasket);
        }

        [TearDown]
        public void TearDownTests()
        {
            //driver.Quit();
        }

    }
}
