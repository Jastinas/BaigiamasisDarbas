using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class SkytechPageTest : BaseTest
    {
        [Test]
        public void Test1SearhBarAndAddToCart()
        {
            _skytechCartPage.NavigateToDefaultPage().SearchBarInputTextAndSearh("Elgato");
        }

        [Test]
        public void Test2MenuBarAndAddToCart()
        {
            _skytechCartPage.NavigateToDefaultPage().FindProductAndAddToCart();
        }

        [Test]
        public void Test3CreatePost()
        {
            _skytechForumPage.NavigateToDefaultPage().LoginInForum().WritePost("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų");
        }

        [Test]
        public void Test4SpamCheck()
        {
            _skytechForumPage.NavigateToDefaultPage().SpamPreventionCheck("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų");
        }

        [Test]
        public void Test5CreatePostWithPoll()
        {
            //List max 10 elementu
            List<string> options = new List<string>();
            options.Add("Vienas");
            options.Add("Du");
            options.Add("Trys");
            _skytechForumPage.NavigateToDefaultPage().WritePostWithPoll("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų", "Kodėl?", options);
        }

        [Test]
        public void Test6Survey()
        {
            _skytechMainPage.NavigateToDefaultPage().SurveyApklausa(true, false, false, false, false).SurveyAnkstesneApklausa(false, true, false);
        }

        [Test]
        public void Test7Login()
        {
            _skytechMainPage.NavigateToDefaultPage().LogIn();
        }
    }
}
