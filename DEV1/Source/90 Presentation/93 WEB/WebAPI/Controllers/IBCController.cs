using System;
using Microsoft.AspNetCore.Mvc;
using FTS.DataAccess.IBC.Data;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class IBCController: Controller
    {
        [HttpGet("OrderCategoriesByBankId/{bankId:int}")]
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