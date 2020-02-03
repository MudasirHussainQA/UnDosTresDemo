using System;
using NUnit.Framework;
using WalmartDemo.Pages;

namespace WalmartDemo.Tests
{
    [TestFixture]
    public class UnitTest1 
    {
        

        

        [Test]
        public void RechargeTest()
        {
            var rechargepage = new RechargePage();
            rechargepage.RechargeProcess();

        }
    }
}
