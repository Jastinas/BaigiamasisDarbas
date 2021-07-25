using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class SkytechMainPage : BasePage
    {
        private const string PageAdress = "https://www.skytech.lt/";
        private IWebElement _InputUsername => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(1) > div:nth-child(2) > input[type=text]"));
        private IWebElement _InputPassword => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(2) > div:nth-child(2) > input[type=password]"));
        private IWebElement _LoginButton => Driver.FindElement(By.CssSelector("#submit-login > div > input"));

        public SkytechMainPage(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SkytechMainPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAdress)
                Driver.Url = PageAdress;
            return this;
        }

        public SkytechMainPage SurveyApklausa(bool informacijosIssamumas, bool vizualinisPateikimas, bool kaina, bool nezinau, bool kita)
        {
            IWebElement informacijosIssamumasCheckbox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(2) > td:nth-child(1) > input[type=radio]"));
            if (informacijosIssamumas != informacijosIssamumasCheckbox.Selected)
                informacijosIssamumasCheckbox.Click();
            IWebElement vizualinisPateikimasCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(3) > td:nth-child(1) > input[type=radio]"));
            if (vizualinisPateikimas != vizualinisPateikimasCheckBox.Selected)
                vizualinisPateikimasCheckBox.Click();
            IWebElement kainaCheckbox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(4) > td:nth-child(1) > input[type=radio]"));
            if (kaina != kainaCheckbox.Selected)
                kainaCheckbox.Click();
            IWebElement nezinauCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(5) > td:nth-child(1) > input[type=radio]"));
            if (nezinau != nezinauCheckBox.Selected)
                nezinauCheckBox.Click();
            IWebElement kitaCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(6) > td:nth-child(1) > input[type=radio]"));
            if (kita != kitaCheckBox.Selected)
                kitaCheckBox.Click();
            Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(7) > td > input.poll-button")).Click();
            IWebElement findText = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(12) > td > b"));
            Assert.IsTrue(findText.Text.Contains("Viso balsų:"), $"Expected {"Viso balsų:"}, but was {findText.Text}");
            return this;
        }

        public SkytechMainPage SurveyAnkstesneApklausa(bool nuolaida, bool kaina, bool nezinau) 
        {
            Driver.FindElement(By.CssSelector("#leftpanel > div:nth-child(5) > ul > li:nth-child(4) > a")).Click();
            IWebElement nuolaidaCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(2) > td:nth-child(1) > input[type=radio]"));
            if (nuolaida != nuolaidaCheckBox.Selected)
                nuolaidaCheckBox.Click();
            IWebElement kainaCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(3) > td:nth-child(1) > input[type=radio]"));
            if (kaina != kainaCheckBox.Selected)
                kainaCheckBox.Click();
            IWebElement nezinauCheckBox = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(4) > td:nth-child(1) > input[type=radio]"));
            if (nezinau != nezinauCheckBox.Selected)
                nezinauCheckBox.Click();
            Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(5) > td > input.poll-button")).Click();
            IWebElement findText = Driver.FindElement(By.CssSelector("#poll > form > table > tbody > tr:nth-child(8) > td > b"));
            Assert.IsTrue(findText.Text.Contains("Viso balsų:"), $"Expected {"Viso balsų:"}, but was {findText.Text}");
            return this;
        }

        public SkytechMainPage LogIn() 
        {
            Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.topmenu-wrap > div > div > a.link-login")).Click();
            _InputUsername.SendKeys("Jastinasjankauskas@yahoo.com");
            _InputPassword.SendKeys("Labas123");
            _LoginButton.Click();
            IWebElement findText = Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.topmenu-wrap > div > div"));
            Assert.IsTrue(findText.Text.Contains("Sveiki, Justinai!"), $"Expected {"Sveiki, Justinai!"}, but was {findText.Text}");
            return this;
        }
      
    }
}
