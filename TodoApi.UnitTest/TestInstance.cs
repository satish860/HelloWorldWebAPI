using HelloWorldWebAPI.Controller;
using HelloWorldWebAPI.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.UnitTest
{
    public static class TestInstance
    {
        public static dynamic HiloRangeQuery = new HiloRangeQuery();

        public static dynamic HiloController = new HiloController(HiloRangeQuery);
    }
}
