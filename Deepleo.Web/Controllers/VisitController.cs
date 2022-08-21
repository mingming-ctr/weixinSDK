using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Deepleo.Web.Models;
using Deepleo.Web.Services;
using Newtonsoft.Json;

namespace Deepleo.Web.Controllers
{
    public class VisitController : ApiController
    {
        // GET api/visit
        public string Get(string openId)
        {
            DataSet ds = UserManager.UserVisit(openId);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // GET api/visit/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/visit
        public void Post([FromBody]UserModel p)
        {

        }

        // PUT api/visit/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/visit/5
        public void Delete(int id)
        {
        }
    }
}
