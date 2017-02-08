using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using FTS.Common.Libraries.CORE.GlobalFunctions;
using FTS.DataAccess.FTS.Orders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController: Controller
    {
        // GET: api/orders
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        public class ResponseDS
        {
            public DataSet DS { get; set; }
            public string ErrorShort { get; set; }
            public string ErrorLong { get; set; }
            public ResponseDS(DataSet ds)
            {
                DS = ds;
            }
            public ResponseDS(string errorShort, string errorLong)
            {
                ErrorShort = errorShort; ErrorLong = ErrorLong;
            }

        }

        // POST api/orders
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // POST api/orders
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

        [HttpPost("OrderList")]
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

        // PUT api/orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/orders/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
