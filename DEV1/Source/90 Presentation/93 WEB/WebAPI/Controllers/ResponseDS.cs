using System.Data;

namespace APS.Presentation.Web.WebAPI.Controllers
{
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
}
