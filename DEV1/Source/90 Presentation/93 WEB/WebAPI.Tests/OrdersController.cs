using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Tests
{
    [TestClass]
    public class OrdersController
    {
        private const int DaysBack = 100;

        [TestMethod]
        public void TestInOrderById()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.InOrderById(1);
        }
        [TestMethod]
        public void TestOutOrderById()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrderById(1);
        }
        [TestMethod]
        public void TestOrdersCounters()
        {
            var d = DateTime.Now;
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestOrdersCounters() {
                BankId = 1, Currency = "EUR", FromDate =  d.AddDays(-DaysBack), ToDate = d};
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OrdersCounters(r);
        }
        [TestMethod]
        public void TestOrdersList()
        {
            var d = DateTime.Now;
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestOrdersList() {
                BankId = 1, Currency = "EUR", FromDate = d.AddDays(-DaysBack), ToDate = d,
                MsgIO = "O", Status = 1, NrRows = 100
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OrdersList(r);
        }
        [TestMethod]
        public void TestIncomingAllPossibleCovers()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingAllPossibleCovers(1);
        }
        [TestMethod]
        public void TestIncomingCover202ForCover()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestIncomingCoverOrderId() {
                BankId = 1, Amount = "10"
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingCover202ForCover(r);
        }
        [TestMethod]
        public void TestIncomingConfirmationOrdersForMT900()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestIncomingCover() {
                BankId = 1, Amount = "10"
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingConfirmationOrdersForMT900(r);
        }
        [TestMethod]
        public void TestIncomingConfirmationOrders()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestIncomingCoverOrderId() {
                BankId = 1, Amount = "10"
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingConfirmationOrders(r);
        }
        [TestMethod]
        public void TestIncomingExtraitOrders()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestIncomingCoverOrderId() {
                BankId = 1, Amount = "10"
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingExtraitOrders(r);
        }
        [TestMethod]
        public void TestIncomingCustomerCreditTransferOrders()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestIncomingCoverOrderId() {
                BankId = 1, Amount = "10"
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.IncomingCustomerCreditTransferOrders(r);
        }
        [TestMethod]
        public void TestInOrdersByOtherCoverId()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.InOrdersByOtherCoverId(1);
        }
        [TestMethod]
        public void TestOutOrdersByFwdFromId()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestOutOrdersByFwdFromId() {
                InOrderId = 1
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrdersByFwdFromId(r);
        }
        [TestMethod]
        public void TestOutOrdersByStatus()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestOutOrdersByStatus() {
                BankId = 1
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrdersByStatus(r);
        }
        [TestMethod]
        public void TestOutOrdersByTUN()
        {
            var r = new APS.Presentation.Web.WebAPI.Controllers.OrdersController.RequestOutOrdersByTUN() {
                BankId = 1
            };
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrdersByTUN(r);
        }
        [TestMethod]
        public void TestInOrdersAdd()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.InOrdersAdd(null);
        }
        [TestMethod]
        public void TestOutOrdersAdd()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrdersAdd(null);
        }
        [TestMethod]
        public void TestInOrdersUpdate()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.InOrdersUpdate(null);
        }
        [TestMethod]
        public void TestOutOrdersUpdate()
        {
            var obj = new APS.Presentation.Web.WebAPI.Controllers.OrdersController();
            var rds = obj.OutOrdersUpdate(null);
        }
    }
}
