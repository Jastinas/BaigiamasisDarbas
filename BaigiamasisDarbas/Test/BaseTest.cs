using BaigiamasisDarbas.Drivers;
using BaigiamasisDarbas.Page;
using BaigiamasisDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static SkytechMainPage _skytechMainPage;
        public static SkytechCartPage _skytechCartPage;
        public static SkytechForumPage _skytechForumPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _skytechMainPage = new SkytechMainPage(driver);
            _skytechCartPage = new SkytechCartPage(driver);
            _skytechForumPage = new SkytechForumPage(driver);
        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
    }
}
