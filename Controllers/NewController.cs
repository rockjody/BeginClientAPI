using BeginClientAPI.Models;
using BeginClientAPI.BusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeginClientAPI.Controllers
{
    public class NewController : ApiController
    {
        // GET api/<controller>     
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public object Post([FromBody] LoanOriginationInfo[] loanOriginationInfo)
        {
            var errors = Validation.LoanOriginationInfo(loanOriginationInfo);
            if (errors.Count == 0)
            {
                var dataResult = DataAccess.WriteLoanOriginationInfo(loanOriginationInfo);
                if (dataResult == 1)
                {
                    return HttpStatusCode.OK;
                }
                else
                {
                    // ToDo: discuss with team
                    return HttpStatusCode.NotAcceptable;
                }
            }
            else
                // ToDo: discuss
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    new
                    {
                        Errors = errors
                    });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}