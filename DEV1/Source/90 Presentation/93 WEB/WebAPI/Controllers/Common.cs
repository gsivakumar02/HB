using System;
using System.Data;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using FTS.Common.BaseClasses.CORE.GenericServicedComponent;
using FTS.Common.Constants.CORE;
using FTS.Common.Libraries.CORE.SQLSelectStatement;
using FTS.DataAccess.CORE.SQLDataAccess;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    public class DataSetIsNullException: Exception
    {
        public DataSetIsNullException() : base("DataSet is null") { }
    }

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
        public static void XmlDataAttributesToElements(XmlDocument xmlDocument)
        {
            if (xmlDocument == null || !xmlDocument.HasChildNodes || !xmlDocument.ChildNodes[0].HasChildNodes)
                return;
            XmlElement element = (XmlElement)xmlDocument.ChildNodes[0].ChildNodes[0];
            foreach (XmlAttribute xmlAttribute in element.Attributes) {
                element.AppendChild(xmlDocument.CreateElement(xmlAttribute.Name)).InnerText = xmlAttribute.Value;
            }
            element.Attributes.RemoveAll();
        }

        public static void XmlDataElementsToAttributes(XmlDocument xmlDocument)
        {
            if (xmlDocument == null || !xmlDocument.HasChildNodes || !xmlDocument.ChildNodes[0].HasChildNodes)
                return;
            XmlElement element = (XmlElement)xmlDocument.ChildNodes[0].ChildNodes[0];
            foreach (XmlNode childNode in element.ChildNodes) {
                element.SetAttribute(childNode.Name, childNode.InnerXml);
            }
            element.IsEmpty = true;
        }

        public static void DataRowFieldToJson(DataSet ds, string fieldName)
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0) {
                var dr = ds.Tables[0].Rows[0];
                var doc = new XmlDocument();
                doc.LoadXml((string)dr[fieldName]);
                XmlDataAttributesToElements(doc);
                dr[fieldName] = JsonConvert.SerializeXmlNode(doc);
            }
        }

        public static void DataRowFieldToXml(DataSet ds, string fieldName)
        {
            if (ds != null && ds.Tables[0].Rows.Count > 0 && fieldName != "") {
                var dr = ds.Tables[0].Rows[0];
                var doc = JsonConvert.DeserializeXmlNode((string)dr[fieldName]);
                XmlDataElementsToAttributes(doc);
                dr[fieldName] = doc.OuterXml;
            }
        }

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

        public static ResponseDS Update(GenericUpdate obj, DataSet ds, bool isAdd, string xmlField)
        {
            try {
                if (ds == null)
                    throw new DataSetIsNullException();
                if (!isAdd) {
                    ds.AcceptChanges();
                    ds.Tables[0].Rows[0].SetModified();
                }
                DataRowFieldToXml(ds, xmlField);
                ds = obj.Update(ds);
                  return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }
    }
}
