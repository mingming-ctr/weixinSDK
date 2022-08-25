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
    public class ShuqianController : ApiController
    {
        // GET api/shuqian
        public string Get()
        {
            DataSet ds = ShuqianManager.GetShuqian();
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }
        // GET api/shuqian/5
        public string Get(string ID)
        {
            DataSet ds = ShuqianManager.GetShuqian(ID);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // POST api/shuqian
        public void Post([FromBody]string value)
        {
        }

        // PUT api/shuqian/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/shuqian/5
        public void Delete(int id)
        {
        }
    }
}
