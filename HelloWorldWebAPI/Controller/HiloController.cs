using HelloWorldWebAPI.Model;
using HelloWorldWebAPI.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HelloWorldWebAPI.Controller
{
    public class HiloController:ApiController
    {
        private readonly IQueryFor<string, HiloRangeResult> Query;
        public HiloController(IQueryFor<string,HiloRangeResult> query)
        {
            this.Query = query;
        }

        public HiloRangeResult GetNextRange(string id)
        {
            return this.Query.ExecuteWith(id);
        }
    }
}