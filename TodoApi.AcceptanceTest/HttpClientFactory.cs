using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using HelloWorldWebAPI;

namespace TodoApi.AcceptanceTest
{
    public class HttpClientFactory
    {
        public static HttpClient CreateClient()
        {
            System.Diagnostics.Debugger.Launch();
            var baseAddress = new Uri("http://localhost:8082/");
            var httpSelfhostConfiguration = new HttpSelfHostConfiguration(baseAddress);
            httpSelfhostConfiguration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            HttpSelfHostServer server = new HttpSelfHostServer(httpSelfhostConfiguration);
            new TodoBootStrap()
                .ConfigureContainer()
                .ConfigureRoute(httpSelfhostConfiguration)
                .ConfigureDatabaseForTest()
                .SeedDatabase();
            HttpClient client = new HttpClient(server);
            client.BaseAddress = baseAddress;
            return client;
        }
    }
}
