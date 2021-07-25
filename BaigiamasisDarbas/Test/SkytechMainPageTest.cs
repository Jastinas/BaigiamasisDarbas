using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class SkytechMainPageTest : BaseTest
    {
        
        [Test]
        public void Test1Survey()
        {
            _skytechMainPage.NavigateToDefaultPage().SurveyApklausa(true, false, false, false, false).SurveyAnkstesneApklausa(false, true, false);
        }

        [Test]
        public void TestLogin()
        {
            _skytechMainPage.NavigateToDefaultPage().LogIn();
        }
    }
}
