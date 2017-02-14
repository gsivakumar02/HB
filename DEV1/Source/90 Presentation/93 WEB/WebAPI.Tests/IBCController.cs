using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Tests
{
    [TestClass]
    public class IBCController
    {
        [TestMethod]
        public void TestOrderCategoriesByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.IBCController();
            var rds = obj.OrderCategoriesByBankId(1);
        }
    }
}
