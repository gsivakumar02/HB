using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using FTS.Common.BaseClasses.CORE.GenericServicedComponent;
using FTS.Common.Constants.GTS;
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

        // Get order by msgio and Id
        // msgio: I: out-order, O: in-order
        [HttpGet("{msgio:length(1)}/{id:int}")]
        public ResponseDS Get(string msgio, int id)
        {
            GenericRetrieve obj;
            if (msgio == MsgIO.I.ToString()) {
                obj = new OutOrdersR();
            } else {
                obj = new InOrdersR();
            }
            return Common.GetById(obj, id);
        }

        public class RequestGetCounters
        {
            public int BankId { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public string Currency { get; set; }
        }

        public class RequestGetOrderList: RequestGetCounters
        {
            public int Status { get; set; }
            public string MsgIO { get; set; }
            public int NrRows { get; set; }
        }

        // Get order counters for orders monitor
        [HttpPost("Counters")]
        public ResponseDS Post([FromBody]RequestGetCounters r)
        {
            var obj = new OrdersFacadeR();
            try {
                var ds =
                    obj.GetOrdersMonitorCounters2(r.BankId, r.FromDate, r.ToDate, r.Currency);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                obj.Dispose();
                return new ResponseDS(ex.Message, ex.ToString());
            }
        }

        // Get order list for orders monitor
        [HttpPost("List")]
        public ResponseDS Post([FromBody]RequestGetOrderList r)
        {
            var obj = new OrdersFacadeR();
            try {
                var ds =
                    obj.GetOrdersForMonitor2(
                        r.BankId, r.Status, r.MsgIO, r.FromDate, r.ToDate, r.Currency, r.NrRows);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                obj.Dispose();
                return new ResponseDS(ex.Message, ex.ToString());
            }
        }

        private GenericUpdate GetGenericUpdate(string msgio)
        {
            if (msgio == MsgIO.I.ToString()) {
                return new OutOrdersU();
            } else {
                return new InOrdersU();
            }
        }

        // Add order api/orders/I/1/<DataSet>
        [HttpPost("{msgio:length(1)}")]
        public ResponseDS Post(string msgio, [FromBody]DataSet ds)
        {
            var obj = GetGenericUpdate(msgio);
            return Common.Update(obj, ds);
        }

        // Update order api/orders/O/1/<DataSet>
        [HttpPut("{msgio:length(1)}")]
        public ResponseDS Put(string msgio, [FromBody]DataSet ds)
        {
            var obj = GetGenericUpdate(msgio);
            ds.AcceptChanges();
            ds.Tables[0].Rows[0].SetModified();
            return Common.Update(obj, ds);
        }
    }
}
