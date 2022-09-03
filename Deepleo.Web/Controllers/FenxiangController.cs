using Deepleo.Web.Models;
using Deepleo.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Deepleo.Web.Controllers
{
    public class FenxiangController : ApiController
    {
        // GET api/fenxiang
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/fenxiang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/fenxiang
        public string Post([FromBody]FenxiangModel p)
        {
            DataSet ds = FenxiangManager.CreateFenxiang(p);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // PUT api/fenxiang/5
        public string Put(int id, [FromBody]FenxiangModel p)
        {
            DataSet ds = FenxiangManager.UpdateFenxiang(p);
            string result = ds.Tables[0].Rows[0]["result"].ToString();
            return result;
        }

        // DELETE api/fenxiang/5
        public void Delete(int id)
        {
        }
    }
}
