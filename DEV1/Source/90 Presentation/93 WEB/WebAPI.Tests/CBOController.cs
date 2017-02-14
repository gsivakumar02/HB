using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Tests
{
    [TestClass]
    public class CBOController
    {
        [TestMethod]
        public void TestBankById()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.CBOController();
            var rds = obj.BankById(1);
        }
        [TestMethod]
        public void TestSubBanksByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.CBOController();
            var rds = obj.SubBanksByBankId(1);
        }
        [TestMethod]
        public void TestBranchesByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.CBOController();
            var rds = obj.BranchesByBankId(1);
        }
        [TestMethod]
        public void TestIsoCodes()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.CBOController();
            var rds = obj.IsoCodes();
        }
    }
}
