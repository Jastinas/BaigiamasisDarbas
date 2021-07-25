using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Test
{
    public class SkytechCartPageTest : BaseTest
    {
        [Test]
        public void TestSearhBarAndAddToCart() 
        {
            _skytechCartPage.NavigateToDefaultPage().SearchBarInputTextAndSearh("Elgato");
        }
        
        
        
        [Test]
        public void TestMenuBarAndAddToCart() 
        {
            _skytechCartPage.NavigateToDefaultPage().FindProductAndAddToCart();
        }
    }
}
