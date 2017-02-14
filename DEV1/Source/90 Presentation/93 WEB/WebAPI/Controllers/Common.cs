using System;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using FTS.Common.BaseClasses.CORE.GenericServicedComponent;
using FTS.Common.Constants.CORE;
using FTS.Common.Libraries.CORE.SQLSelectStatement;
using FTS.DataAccess.CORE.SQLDataAccess;

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
        public static ResponseDS GetById(GenericRetrieve obj, int id, bool withCache)
        {
            try {
                var ds = obj.GetByID(id, DataAccessServers.FTS, SQLSelectStatement.HintOption.NoHint, withCache);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        public static ResponseDS GetBySelect(DataAccessServers db, string tablename, string cmdText)
        {
            var obj = new SQLDataAccess();
            try {
                var ds =
                    obj.GetDataSet(
                        tablename, cmdText, CommandType.Text, db, false);
                ds.Tables[0].TableName = tablename;
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

        public static void DataRowFieldToJson(DataSet ds, string fieldName)
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                var dr = ds.Tables[0].Rows[0];
                var doc = new XmlDocument();
                doc.LoadXml((string)dr[fieldName]);
                dr[fieldName] = JsonConvert.SerializeXmlNode(doc);
            }
        }

        public static void DataRowFieldToXml(DataSet ds, string fieldName)
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                var dr = ds.Tables[0].Rows[0];
                var doc = JsonConvert.DeserializeXmlNode((string)dr[fieldName]);
                dr[fieldName] = doc.OuterXml;
            }
        }
    }
}
