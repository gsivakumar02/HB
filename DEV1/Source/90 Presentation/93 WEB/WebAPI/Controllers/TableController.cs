using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using FTS.Common.Constants.CORE;
using FTS.DataAccess.CORE.SQLDataAccess;

namespace APS.Presentation.Web.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TableController : Controller
    {
        // Get dataset from db by tablename and id
        [HttpGet("{db:int}/{tablename:length(1,128)}/{id:int}")]
        public ResponseDS Get(int db, string tablename, int id)
        {
            var obj = new SQLDataAccess();
            var cmdtext = "SELECT * FROM " + tablename + " WHERE Id=" + id;
            try {
                var ds =
                    obj.GetDataSet(
                        tablename, cmdtext, CommandType.Text, (DataAccessServers)db, false);
                ds.Tables[0].TableName = tablename;
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        // Add dataset to db
        [HttpPost]
        public ResponseDS Post([FromBody]DataSet ds)
        {
            var obj = new SQLDataAccessU();
            try {
                ds = obj.Update(ds);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }

        // Update dataset to db
        [HttpPut]
        public ResponseDS Put(string msgio, int id, [FromBody]DataSet ds)
        {
            ds.AcceptChanges();
            ds.Tables[0].Rows[0].SetModified();
            var obj = new SQLDataAccessU();
            try {
                ds = obj.Update(ds);
                return new ResponseDS(ds);
            } catch (Exception ex) {
                return new ResponseDS(ex.Message, ex.ToString());
            } finally { obj.Dispose(); }
        }
    }
}
