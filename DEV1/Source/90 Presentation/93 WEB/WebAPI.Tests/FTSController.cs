using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Tests
{
    [TestClass]
    public class FTSController
    {
        [TestMethod]
        public void TestCorrespondentBICsByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.FTSController();
            var rds = obj.CorrespondentBICsByBankId(1);
        }
        [TestMethod]
        public void TestCorrespondentAccountsByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.FTSController();
            var rds = obj.CorrespondentAccountsByBankId(1);
        }
        [TestMethod]
        public void TestActiveServiceTypesByBankId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.FTSController();
            var rds = obj.ActiveServiceTypesByBankId(1);
        }
    }
}
