using System;
using System.Data;
using FTS.Common.BaseClasses.CORE.GenericServicedComponent;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    public class ResponseDS
    {
        public DataSet DS { get; set; }
        public string ErrorShort { get; set; }
        public string ErrorLong { get; set; }
        public ResponseDS() { }
        public ResponseDS(DataSet ds)
        {
            DS = ds;
        }
        public ResponseDS(string errorShort, string errorLong)
        {
            ErrorShort = errorShort; ErrorLong = errorLong;
        }
    }

    public class Common
    {
        public static ResponseDS GetById(GenericRetrieve obj, int id)
        {
            try {
                var ds = obj.GetByID(id);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        public static ResponseDS Update(GenericUpdate obj, DataSet ds)
        {
            try {
                ds = obj.Update(ds);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }
    }
}
