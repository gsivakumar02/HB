using System;
using System.Web.Http;
using FTS.DataAccess.CBO.Banks;
using FTS.DataAccess.CBO.Services;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [RoutePrefix("api/CBO")]
    public class CBOController: ApiController
    {
        [HttpGet]
        [Route("BankById/{id:int}")]
        public ResponseDS BankById(int id)
        {
            var obj = new BanksR();
            return Common.GetById(obj, id, true);
        }

        [HttpGet]
        [Route("SubBanksByBankId/{bankId:int}")]
        public ResponseDS SubBanksByBankId(int bankId)
        {
            var obj = new BanksR();
            try {
                var ds = obj.GetSubBanks(bankId, true);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpGet]
        [Route("BranchesByBankId/{bankId}")]
        public ResponseDS BranchesByBankId(int bankId)
        {
            var obj = new BranchesR();
            try {
                var ds = obj.GetByField("BankId", bankId, true);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        [HttpGet]
        [Route("IsoCodes")]
        public ResponseDS IsoCodes()
        {
            var obj = new ReturnIsoCodesR();
            try {
                var ds = obj.GetAdHoc(true);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }
    }
}