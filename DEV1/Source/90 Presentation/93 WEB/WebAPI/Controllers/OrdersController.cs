using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
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
            var rds = Common.GetById(obj, id);
            Common.DataRowFieldToJson(rds.DS, "XML_Data");
            return rds;
        }

        [HttpGet("OutOrderById/{id:int}")]
        public ResponseDS OutOrderById(int id)
        {
            var obj = new OutOrdersR();
            var rds = Common.GetById(obj, id);
            Common.DataRowFieldToJson(rds.DS, "XML_Data");
            return rds;
        }

        public class RequestBankId
        {
            public int BankId { get; set; }
        }

        public class RequestOrdersCounters : RequestBankId
        {
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string Currency { get; set; }
        }

        public class RequestOrdersList: RequestOrdersCounters
        {
            public int Status { get; set; }
            public string MsgIO { get; set; }
            public int NrRows { get; set; }
        }

        public class RequestOutOrdersByTUN: RequestBankId
        {
            public string Tun { get; set; }
            public DataAccessServers Db { get; set; }
        }

        public class RequestOutOrdersByFwdFromId
        {
            public int InOrderId { get; set; }
            public DataAccessServers Db { get; set; }
        }

        public class RequestOutOrdersByStatus: RequestBankId
        {
            public FTSOutgoingOrderStatus Status { get; set; }
            public DateTime EntryDate { get; set; }
        }

        public class RequestInOrdersByRef: RequestBankId
        {
            public string Reference { get; set; }
        }
        public class RequestInOrdersByOrigOrderId
        {
            public int OrigOrderId { get; set; }
            public DataAccessServers Db { get; set; }
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

        // InOrdersR.GetByOrigOrderId
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

        // InOrdersR.Get_DiasOnbyOtherCoverId
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

        // InOrdersR.GetByRef
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

        // OutOrdersR.GetbyFwdFromId
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

        // OutOrdersR.GetByStatus
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

        // OutOrdersR.GetByTUN
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
