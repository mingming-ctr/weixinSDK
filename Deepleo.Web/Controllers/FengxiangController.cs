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
    public class FengxiangController : ApiController
    {
        // GET api/fengxiang
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/fengxiang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/fengxiang
        public string Post([FromBody]FengxiangModel p)
        {
            DataSet ds = FengxiangManager.CreateFengxiang(p);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // PUT api/fengxiang/5
        public string Put(int id, [FromBody]FengxiangModel p)
        {
            DataSet ds = FengxiangManager.UpdateFengxiang(p);
            string result = ds.Tables[0].Rows[0]["result"].ToString();
            return result;
        }

        // DELETE api/fengxiang/5
        public void Delete(int id)
        {
        }
    }
}
