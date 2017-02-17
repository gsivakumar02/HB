using System;
using System.Web.Http;
using FTS.Common.Constants.CORE;
using FTS.DataAccess.FTS.OnlineConfigurator;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [RoutePrefix("api/FTS")]
    public class FTSController: ApiController
    {
        [Route("CorrespondentBICsByBankId/{bankId:int}")]
        public ResponseDS CorrespondentBICsByBankId(int bankId)
        {
            var cmdText =
                "SELECT DISTINCT BIC,CCY"
                + " FROM FTS_Correspondents WHERE Enabled=1 AND BankId=" + bankId;
            return Common.GetBySelect(DataAccessServers.FTS, "FTS_Correspondents_Distinct", cmdText);
        }

        [Route("CorrespondentAccountsByBankId/{bankId:int}")]
        public ResponseDS CorrespondentAccountsByBankId(int bankId)
        {
            var cmdText =
                "SELECT BIC,CCY,Account,Enabled,AccountType"
                + " FROM FTS_Correspondents WHERE Enabled=1 AND BankId=" + bankId;
            return Common.GetBySelect(DataAccessServers.FTS, "FTS_Correspondents", cmdText);
        }

        [Route("ActiveServiceTypesByBankId/{bankId:int}")]
        public ResponseDS ActiveServiceTypesByBankId(int bankId)
        {
            var obj = new ActiveServiceTypesR();
            try {
                var ds = obj.GetActiveServiceTypesByBankId(bankId);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }
    }
}