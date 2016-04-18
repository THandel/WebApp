using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp;

namespace WebApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestLinqController()
        {
            var controller = new WebApp.Controllers.LinqDatasController();
        }
    }
}
