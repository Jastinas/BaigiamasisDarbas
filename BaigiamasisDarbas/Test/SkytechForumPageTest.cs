using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class SkytechForumPageTest : BaseTest
    {
        [Test]
        public void Test1CreatePost() 
        {
            _skytechForumPage.NavigateToDefaultPage().LoginInForum().WritePost("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų");
        }

        [Test]
        public void Test2SpamCheck()
        {
            _skytechForumPage.NavigateToDefaultPage().SpamPreventionCheck("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų");
        }

        [Test]
        public void Test3CreatePostWithPoll()
        {
            //List max 10 elementu
            List<string> options = new List<string>();
            options.Add("Vienas");
            options.Add("Du");
            options.Add("Trys");
            _skytechForumPage.NavigateToDefaultPage().WritePostWithPoll("Skundas", "Viskas neveikia taip kaip norėčiau, kad veiktų", "Kodėl?", options);
        }

    }
}
