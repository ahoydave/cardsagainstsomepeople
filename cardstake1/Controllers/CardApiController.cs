using cardstake1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Web;

namespace cardstake1.Controllers
{
    public class CardApiController : ApiController
    {
        // GET: api/CardApi
        [Route("api/cardapi/A"), HttpGet]
        public string GetAnswer()
        {
            return CardRepo.Instance.GetNextAnswer().text;
        }

        [Route("api/cardapi/Q"), HttpGet]
        public string GetQuestion()
        {
            return CardRepo.Instance.GetNextQuestion().text;
        }

        // GET: api/CardApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CardApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CardApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CardApi/5
        public void Delete(int id)
        {
        }
    }
}
