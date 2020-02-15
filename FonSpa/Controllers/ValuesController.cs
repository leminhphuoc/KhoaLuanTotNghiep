using System.Collections.Generic;
using System.Web.Http;

namespace FonNature.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new System.NotSupportedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new System.NotSupportedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new System.NotSupportedException();
        }
    }
}
