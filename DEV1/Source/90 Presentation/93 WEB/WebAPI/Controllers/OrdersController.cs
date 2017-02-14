﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using FTS.BusinessLogic.FTS.Facade;
using FTS.Common.Constants.CORE;
using FTS.Common.Constants.FTS;
using FTS.Common.Libraries.CORE.SQLSelectStatement;
using FTS.DataAccess.FTS.Orders;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController: Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("InOrderById/{id:int}")]
        public ResponseDS InOrderById(int id)
        {
            var obj = new InOrdersR();
            var rds = Common.GetById(obj, id, false);
            Common.DataRowFieldToJson(rds.DS, "XML_Data");
            return rds;
        }

        [HttpGet("OutOrderById/{id:int}")]
        public ResponseDS OutOrderById(int id)
        {
            var obj = new OutOrdersR();
            var rds = Common.GetById(obj, id, false);
            Common.DataRowFieldToJson(rds.DS, "XML_Data");
            return rds;
        }

        public class RequestBankId
        {
            public int BankId;
        }
        public class RequestOrdersCounters : RequestBankId
        {
            public DateTime FromDate;
            public DateTime ToDate;
            public string Currency;
        }
        public class RequestOrdersList: RequestOrdersCounters
        {
            public int Status;
            public string MsgIO;
            public int NrRows;
        }
        public class RequestIncomingCover: RequestBankId
        {
            public string Currency;
            public string Amount;
            public string Reference;
            public string CorrespBIC;
            public string ValueDate;
        }
        public class RequestIncomingCoverOrderId: RequestIncomingCover
        {
            public int OrderId;
        }
        public class RequestInOrdersByRef: RequestBankId
        {
            public string Reference;
        }
        public class RequestInOrdersByOrigOrderId
        {
            public int OrigOrderId;
            public DataAccessServers Db;
        }
        public class RequestOutOrdersByTUN: RequestBankId
        {
            public string Tun;
            public DataAccessServers Db;
        }
        public class RequestOutOrdersByFwdFromId
        {
            public int InOrderId;
            public DataAccessServers Db;
        }
        public class RequestOutOrdersByStatus: RequestBankId
        {
            public FTSOutgoingOrderStatus Status;
            public DateTime EntryDate;
        }

       // Get order counters for orders monitor
       [HttpPost("OrdersCounters")]
        public ResponseDS OrdersCounters([FromBody]RequestOrdersCounters r)
        {
            var obj = new OrdersFacadeR();
            try {
                var ds =
                    obj.GetOrdersMonitorCounters2(r.BankId, r.FromDate, r.ToDate, r.Currency);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        // Get order list for orders monitor
        [HttpPost("OrdersList")]
        public ResponseDS Post([FromBody]RequestOrdersList r)
        {
            var obj = new OrdersFacadeR();
            try {
                var ds =
                    obj.GetOrdersForMonitor2(
                        r.BankId, r.Status, r.MsgIO, r.FromDate, r.ToDate, r.Currency, r.NrRows);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingAllPossibleCovers")]
        public ResponseDS IncomingAllPossibleCovers([FromBody]int orderId)
        {
            var obj = new IncomingCoverR();
            try {
                var ds = obj.GetAllPossibleCovers(orderId);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingCover202ForCover")]
        public ResponseDS IncomingCover202ForCover([FromBody]RequestIncomingCoverOrderId r)
        {
            var obj = new IncomingCoverR();
            try {
                var ds = obj.Get202ForCover(
                    r.BankId, r.OrderId, r.Currency,
                    r.Amount, r.Reference, r.CorrespBIC, r.ValueDate);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingConfirmationOrdersForMT900")]
        public ResponseDS IncomingConfirmationOrdersForMT900([FromBody]RequestIncomingCover r)
        {
            var obj = new IncomingCoverR();
            try {
                var ds = obj.GetConfirmationOrders_For_MT900(
                    r.BankId, r.Currency,
                    r.Amount, r.Reference, r.CorrespBIC, r.ValueDate);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingConfirmationOrders")]
        public ResponseDS IncomingConfirmationOrders([FromBody]RequestIncomingCover r)
        {
            var obj = new IncomingCoverR();
            try {
                var ds = obj.GetConfirmationOrders(
                    r.BankId, r.Currency,
                    r.Amount, r.Reference, r.CorrespBIC, r.ValueDate);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingExtraitOrders")]
        public ResponseDS IncomingExtraitOrders([FromBody]RequestIncomingCover r)
        {
            var obj = new IncomingCoverR();
            try {
                var ds = obj.GetExtraitOrders(
                    r.BankId, r.Currency,
                    r.Amount, r.Reference, r.CorrespBIC, r.ValueDate);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("IncomingCustomerCreditTransferOrders")]
        public ResponseDS IncomingCustomerCreditTransferOrders([FromBody]RequestIncomingCover r)
        {
            var obj = new IncomingCoverR();
            var amount = decimal.Parse(r.Amount.Replace(".", ","));
            try {
                var ds = obj.GetCustomerCreditTransferOrders(
                    r.BankId, r.Currency,
                    amount, r.Reference, r.CorrespBIC, r.ValueDate);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("InOrdersByOrigOrderId")]
        public ResponseDS InOrdersByOrigOrderId([FromBody]RequestInOrdersByOrigOrderId r)
        {
            var obj = new InOrdersR();
            try {
                var ds = obj.GetByOrigOrderId(
                    r.OrigOrderId, SQLSelectStatement.HintOption.NoHint, r.Db);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("InOrdersByOtherCoverId")]
        public ResponseDS InOrdersByOtherCoverId([FromBody]int recvRepId)
        {
            var obj = new InOrdersR();
            try {
                var ds = obj.Get_DiasOnbyOtherCoverId(recvRepId);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("InOrdersByRef")]
        public ResponseDS InOrdersByRef([FromBody]RequestInOrdersByRef r)
        {
            var obj = new InOrdersR();
            try {
                var ds = obj.GetByRef(
                    r.BankId, r.Reference, FTSMessageTypes.CustomerCreditTransfer.ToString("D"));
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("OutOrdersByFwdFromId")]
        public ResponseDS OutOrdersByFwdFromId([FromBody]RequestOutOrdersByFwdFromId r)
        {
            var obj = new OutOrdersR();
            try {
                var ds = obj.GetbyFwdFromId(r.InOrderId, SQLSelectStatement.HintOption.NoHint, r.Db);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("OutOrdersByStatus")]
        public ResponseDS OutOrdersByStatus([FromBody]RequestOutOrdersByStatus r)
        {
            var obj = new OutOrdersR();
            try {
                var ds = obj.GetByStatus(r.BankId, (int)r.Status, r.EntryDate.ToString("yyyyMMdd"));
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("OutOrdersByTUN")]
        public ResponseDS OutOrdersByTUN([FromBody]RequestOutOrdersByTUN r)
        {
            var obj = new OutOrdersR();
            try {
                var ds = obj.GetByTUN(r.BankId, r.Tun, r.Db);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpPost("InOrdersAdd")]
        public ResponseDS InOrdersAdd([FromBody]DataSet ds)
        {
            var obj = new InOrdersU();
            Common.DataRowFieldToXml(ds, "XML_Data");
            return Common.Update(obj, ds);
        }

        [HttpPost("OutOrdersAdd")]
        public ResponseDS OutOrdersAdd([FromBody]DataSet ds)
        {
            var obj = new OutOrdersU();
            Common.DataRowFieldToXml(ds, "XML_Data");
            return Common.Update(obj, ds);
        }

        [HttpPut("InOrdersUpdate")]
        public ResponseDS InOrdersUpdate([FromBody]DataSet ds)
        {
            var obj = new InOrdersU();
            ds.AcceptChanges();
            ds.Tables[0].Rows[0].SetModified();
            Common.DataRowFieldToXml(ds, "XML_Data");
            return Common.Update(obj, ds);
        }

        [HttpPut("OutOrdersUpdate")]
        public ResponseDS OutOrdersUpdate([FromBody]DataSet ds)
        {
            var obj = new OutOrdersU();
            ds.AcceptChanges();
            ds.Tables[0].Rows[0].SetModified();
            Common.DataRowFieldToXml(ds, "XML_Data");
            return Common.Update(obj, ds);
        }

    }
}
