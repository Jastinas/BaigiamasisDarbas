using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class SkytechCartPage : BasePage
    {
        private const string PageAdress = "https://www.skytech.lt/shopping_cart.php";
        private IWebElement _SearchBarField => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.pageheader > table > tbody > tr > td:nth-child(2) > div > form > div.search-wrap > input.search-field.inactive"));
        private IWebElement _SearchBarButton => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.pageheader > table > tbody > tr > td:nth-child(2) > div > form > div.search-wrap.active > input.search-button"));

        public SkytechCartPage(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SkytechCartPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAdress)
                Driver.Url = PageAdress;
            return this;
        }

        public SkytechCartPage SearchBarInputTextAndSearh(string seacrhText)
        {
            _SearchBarField.SendKeys(seacrhText);
            _SearchBarButton.Click();
            Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(3) > td:nth-child(6) > div")).Click();
            Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(4) > td:nth-child(6) > div")).Click();
            NavigateToDefaultPage();
            IWebElement cartTotal = Driver.FindElement(By.CssSelector("#cart-total"));
            Assert.IsTrue(cartTotal.Text.Contains("Suma: 199.88 €"), $"Expected {"Suma: 199.88 €"}, but was {cartTotal.Text}");
            Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap-nofix > form > table > tbody > tr.pagerow > td > div > div.buttons-left > a:nth-child(2) > span")).Click();
            return this;
        }

        public SkytechCartPage FindProductAndAddToCart() 
        {
            Actions action = new Actions(Driver);
            IWebElement element = Driver.FindElement(By.CssSelector("#navbar > li:nth-child(1) > a"));
            action.MoveToElement(element).Build().Perform();
            Driver.FindElement(By.CssSelector("#navbar > li:nth-child(1) > div > div:nth-child(2) > div:nth-child(7) > a")).Click();
            Driver.FindElement(By.CssSelector(".visi-catlist-wrap > div:nth-child(1) > ul:nth-child(1) > li:nth-child(1) > a:nth-child(1)")).Click();
            Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(5) > td:nth-child(6) > div")).Click();
            NavigateToDefaultPage();
            IWebElement textCheck = Driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div[4]/div[2]/div[5]/form/div[1]/table[1]/tbody/tr[2]/td[1]"));
            Assert.IsTrue(textCheck.Text.Contains("ASU650SS-240GT-R"), $"Expected {"ASU650SS-240GT-R"}, but was {textCheck.Text}");
            Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap-nofix > form > table > tbody > tr.pagerow > td > div > div.buttons-left > a:nth-child(2)")).Click();
            return this;
        }
    }
}
