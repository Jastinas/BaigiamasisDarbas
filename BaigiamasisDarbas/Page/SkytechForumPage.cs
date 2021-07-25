using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class SkytechForumPage : BasePage
    {
        private const string PageAdress = "https://www.skytech.lt/forum/index.php";
        private IWebElement _InputUsername => Driver.FindElement(By.Id("username"));
        private IWebElement _InputPassword => Driver.FindElement(By.Id("password"));
        private IWebElement _LoginButton => Driver.FindElement(By.CssSelector(".button2"));
        private IWebElement _NewPostButtom => Driver.FindElement(By.CssSelector("#page-body > div:nth-child(3) > div.buttons > div > a"));

        public SkytechForumPage(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SkytechForumPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAdress)
                Driver.Url = PageAdress;
            return this;
        }

        public SkytechForumPage LoginInForum()
        {
            _InputUsername.SendKeys("Justians");
            _InputPassword.SendKeys("Labas123");
            _LoginButton.Click();
            return this;
        }

        public SkytechForumPage WritePost(string title, string message)
        {
            Driver.FindElement(By.CssSelector("#page-body > div.forabg > div > ul.topiclist.forums > li:nth-child(4) > dl > dt > a")).Click();
            _NewPostButtom.Click();
            IWebElement titleField = Driver.FindElement(By.CssSelector("#subject"));
            titleField.SendKeys(title);
            IWebElement messageBox = Driver.FindElement(By.CssSelector("#message"));
            messageBox.SendKeys(message);
            Thread.Sleep(2000);
            Driver.FindElement(By.CssSelector("#postform > div.panel.bg2 > div > fieldset > input.button1.default-submit-action")).Click();
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div[5]/div[4]/div/div[1]/ul/li[2]/a")).Click();
            Driver.FindElement(By.CssSelector("#confirm > div > div > fieldset > input:nth-child(7)")).Click();
            
            return this;
        }

        public SkytechForumPage SpamPreventionCheck(string title, string message)
        {
            Driver.FindElement(By.CssSelector("#page-body > div.forabg > div > ul.topiclist.forums > li:nth-child(4) > dl > dt > a")).Click();
            _NewPostButtom.Click();
            IWebElement titleField = Driver.FindElement(By.CssSelector("#subject"));
            titleField.SendKeys(title);
            IWebElement messageBox = Driver.FindElement(By.CssSelector("#message"));
            messageBox.SendKeys(message);
            Thread.Sleep(5000);
            Driver.FindElement(By.CssSelector("#postform > div.panel.bg2 > div > fieldset > input.button1.default-submit-action")).Click(); ;
            IWebElement spamText = Driver.FindElement(By.CssSelector("#postingbox > div > fieldset > p"));
            Assert.IsTrue(spamText.Text.Contains("Jūs negalite taip greitai rašyti kito pranešimo."), $"Expected {"Jūs negalite taip greitai rašyti kito pranešimo."}, but was {spamText.Text}");
            return this;
        }

        public SkytechForumPage WritePostWithPoll(string title, string message, string question, List<string> listofOptions)
        {
            Driver.FindElement(By.CssSelector("#page-body > div.forabg > div > ul.topiclist.forums > li:nth-child(4) > dl > dt > a")).Click();
            _NewPostButtom.Click();
            IWebElement titleField = Driver.FindElement(By.CssSelector("#subject"));
            titleField.SendKeys(title);
            IWebElement messageBox = Driver.FindElement(By.CssSelector("#message"));
            messageBox.SendKeys(message);
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div[5]/form/div[3]/ul/li[2]/a/span")).Click();
            IWebElement pollQestion = Driver.FindElement(By.CssSelector("#poll_title"));
            pollQestion.SendKeys(question);
            IWebElement pollOptions = Driver.FindElement(By.CssSelector("#poll_option_text"));
            foreach (string option in listofOptions)
            {
                pollOptions.SendKeys(option + "\n");
            }
            Thread.Sleep(5000);
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div[5]/form/div[2]/div/fieldset/input[4]")).Click();
            Driver.FindElement(By.XPath("/html/body/div[2]/div/div[5]/div[4]/div/div[1]/ul/li[2]/a")).Click();
            Driver.FindElement(By.CssSelector("#confirm > div > div > fieldset > input:nth-child(7)")).Click();
            return this;
        }
    }
}