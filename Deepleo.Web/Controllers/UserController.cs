using Deepleo.Web.Models;
using Deepleo.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;

namespace Deepleo.Web.Controllers
{
    public class UserController : ApiController
    {
        // GET api/user
        public string Get(string openId)
        {
            DataSet ds = UserManager.UserFangwen(openId);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public string Post([FromBody]UserModel p)
        {
            DataSet ds =UserManager.CreateUser(p);
            string result = ds.Tables[0].Rows[0]["result"].ToString();
            return result;
        }

        // PUT api/user/5
        public string Put(string id, [FromBody]UserModel p)
        {
            DataSet ds = UserManager.UpdateUser(p);
            string result = ds.Tables[0].Rows[0]["result"].ToString();
            return result;
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
