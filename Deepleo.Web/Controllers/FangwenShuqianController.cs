using Deepleo.Web.Models;
using Deepleo.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Deepleo.Web.Controllers
{
    public class FangwenShuqianController : ApiController
    {
        // GET api/fangwenshuqian
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/fangwenshuqian/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/fangwenshuqian
        public string Post([FromBody]FangwenShuqianModel p)
        {
            var ds = FangwenShuqianManager.Create(p);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // PUT api/fangwenshuqian/5
        public void Put(int id, [FromBody]FangwenShuqianModel p)
        {
        }

        // DELETE api/fangwenshuqian/5
        public void Delete(int id)
        {
        }
    }
}
