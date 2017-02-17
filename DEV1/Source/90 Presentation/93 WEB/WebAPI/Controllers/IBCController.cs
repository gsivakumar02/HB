using System;
using System.Web.Http;
using FTS.DataAccess.IBC.Data;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [RoutePrefix("api/IBC")]
    public class IBCController: ApiController
    {
        [Route("OrderCategoriesByBankId/{bankId:int}")]
        public ResponseDS OrderCategoriesByBankId(int bankId)
        {
            var obj = new OrderCategoriesR();
            try {
                var ds = obj.GetOrderCategoriesByBankId(bankId);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

    }
}