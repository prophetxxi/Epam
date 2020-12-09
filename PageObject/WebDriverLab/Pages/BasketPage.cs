using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebDriverLab.Pages
{
    public class BasketPage
    {
        private IWebDriver driver;
        private const string PAGE_URL = "https://shop.huawei.by/simplecheckout/#step_1";
        public string stringPrice;
        public int price;

        [FindsBy(How = How.Id, Using = "total_total")]
        protected readonly IWebElement totalPrice;

        [FindsBy(How = How.XPath, Using = "//div[@class='quantity-block']//input")]
        protected readonly IWebElement editNumber;

        [FindsBy(How = How.Id, Using = "simplecheckout_button_next")]
        protected readonly IWebElement orderProduct;

        [FindsBy(How = How.XPath, Using = "//div[@class='simplecheckout']//div[@class='content']")]
        protected readonly IWebElement basketEmpty;

        [FindsBy(How = How.XPath, Using = "//*[@id='simplecheckout_form_0']/div/div[3]/div/a")]
        protected readonly IWebElement pageReady;

        public BasketPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            this.driver = driver;
            PageFactory.InitElements(driver, page: this);
        }

        public int GetTotalPriceOfTwoProducts()
        {
            price = Int32.Parse(stringPrice);
            return price;
        }

        public BasketPage EditNumberOfProducts()
        {
            editNumber.SendKeys(Keys.Backspace);
            editNumber.SendKeys("0");
            return this;
        }

        public BasketPage OrderProduct()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("scroll(0,200)");
            orderProduct.Click();
            return this;
        }

        public BasketPage WaitForElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(pageReady));
            return this;
        }

        public string GetStatusBasketPage()
        {
            return basketEmpty.Text;
        }

        public BasketPage GetPrice()
        {
            stringPrice = totalPrice.Text;
            stringPrice = stringPrice.Split('\n')[1];
            stringPrice = stringPrice.Split('.')[0];
            stringPrice = stringPrice.Remove(1, 1);
            return this;
        }
    }
}
