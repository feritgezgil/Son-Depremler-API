using SonDepremlerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SonDepremlerApi.Controllers
{
    public class DepremController : ApiController
    {
        public IEnumerable<Deprem> Get(string id = "0")
        {
            Deprem d = new Deprem();
            return d.Get(Convert.ToInt32(id));
        }
    }
}
